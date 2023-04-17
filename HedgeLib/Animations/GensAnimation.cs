using HedgeLib.Headers;
using HedgeLib.IO;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using System.Xml.Linq;

namespace HedgeLib.Animations
{
    public abstract class GensAnimation : FileBase
    {
        // Variables/Constants
        public GensHeader Header = new GensHeader();
        public List<Animation> Animations = new List<Animation>();
        protected string name;
        protected string subname;

        // Methods
        public override void Load(Stream fileStream)
        {
            Read(fileStream);
        }

        protected virtual void Read(Stream fileStream)
        {
            uint stringTable2Offset = 0;
            string animType = GetAnimType();
            // Header
            var reader = new GensReader(fileStream);
            Header.Read(reader);

            IDictionary<string, uint> animHeader = ReadAnimHeader(reader);

            // MetaData
            reader.JumpTo(animHeader["metaDataOffset"], false);

            ReadNames(reader, animHeader["stringTableOffset"]);

            uint animCount = reader.ReadUInt32();
            var animOffsets = new uint[animCount];
            for (uint i = 0; i < animCount; ++i)
            {
                animOffsets[i] = reader.ReadUInt32();
            }

            // Animations
            if (animType == PatternAnimation.Extension)
                stringTable2Offset = animHeader["stringTable2Offset"];

            for (uint i = 0; i < animCount; ++i)
            {
                reader.JumpTo(animOffsets[i], false);
                Animations.Add(new Animation(reader, animHeader["stringTableOffset"], animType, stringTable2Offset));
            }

            // Keyframes
            foreach (var anim in Animations)
            {
                foreach (var set in anim.KeyframeSets)
                {
                    set.ReadKeyframes(reader, animHeader["keyframesOffset"]);
                }
            }
        }

        public virtual IDictionary<string, uint> ReadAnimHeader(GensReader reader)
        {
            IDictionary<string, uint> animHeader = new Dictionary<string, uint>();

            animHeader.Add("metaDataOffset",reader.ReadUInt32());
            animHeader.Add("metaAnimsSize",reader.ReadUInt32());
            animHeader.Add("keyframesOffset",reader.ReadUInt32());
            animHeader.Add("keyframesSize",reader.ReadUInt32());
            animHeader.Add("stringTableOffset",reader.ReadUInt32());
            animHeader.Add("stringTableSize",reader.ReadUInt32());

            return animHeader;
        }

        public virtual void ReadNames(GensReader reader, uint stringTableOffset = 0)
        {
            return;
        }

        public abstract string GetAnimType();

        public override void Save(Stream fileStream)
        {
            Write(fileStream);
        }

        protected virtual void Write(Stream fileStream)
        {
            // WHY ARE SIZeS IN THE OFfSET TABlE SEGA YOU BUMS?>??!??!
            int stringTableSize = 0;
            var stringTable = new List<string>();
            int stringTable2Size = 0;
            var stringTable2 = new List<string>();
            var writer = new GensWriter(fileStream, Header);
            string animType = GetAnimType();

            writer.AddOffset("metaDataOffset");
            writer.AddOffset("metaAnimsSize");
            writer.AddOffset("keyframesOffset");
            writer.AddOffset("keyframesSize");
            writer.AddOffset("stringTableOffset");
            writer.AddOffset("stringTableSize");
            if (animType == PatternAnimation.Extension)
            {
                writer.AddOffset("stringTable2Offset");
                writer.AddOffset("stringTable2Size");
            }

            // MetaData
            uint metaDataOffset = (uint)fileStream.Position;
            writer.FillInOffset("metaDataOffset", false, false);
            if (!string.IsNullOrEmpty(name))
                AddStringToTable(name);
            if (!string.IsNullOrEmpty(subname))
                AddStringToTable(subname);

            writer.Write(Animations.Count);
            writer.AddOffsetTable("animsOffset", (uint)Animations.Count);

            // Animations
            int startIndex = 0;
            for (int i = 0; i < Animations.Count; ++i)
            {
                var anim = Animations[i];
                writer.FillInOffset($"animsOffset_{i}", false, false);
                AddStringToTable(anim.Name);
                anim.Write(writer, animType, ref startIndex, ref stringTableSize, ref stringTable, ref stringTable2Size, ref stringTable2, true);
            }

            // Keyframes
            uint keyframesOffset = (uint)fileStream.Position;
            writer.FillInOffset("keyframesOffset", false, false);
            writer.FillInOffset("metaAnimsSize", keyframesOffset -
                metaDataOffset, true, false);

            foreach (var anim in Animations)
            {
                foreach (var set in anim.KeyframeSets)
                {
                    set.WriteKeyframes(writer);
                }
            }

            // String Table
            uint stringTablePos = (uint)fileStream.Position;
            writer.FillInOffset("stringTableOffset", false, false);
            writer.FillInOffset("keyframesSize", stringTablePos -
                keyframesOffset, true, false);

            foreach (string str in stringTable)
            {
                writer.WriteNullTerminatedString(str);
            }

            writer.FixPadding(4);
            writer.FillInOffset("stringTableSize", (uint)fileStream.Position -
                stringTablePos, true, false);

            // String Table 2
            if (animType == PatternAnimation.Extension)
            {
                uint stringTable2Pos = (uint)fileStream.Position;
                writer.FillInOffset("stringTable2Offset", false, false);

                foreach (string str in stringTable2)
                {
                    writer.WriteNullTerminatedString(str);
                }

                writer.FixPadding(4);
                writer.FillInOffset("stringTable2Size", (uint)fileStream.Position -
                    stringTable2Pos, true, false);
            }

            writer.FinishWrite(Header, writeEOFNull: false);

            // Sub-Methods
            void AddStringToTable(string str)
            {
                writer.Write(stringTableSize);
                stringTableSize += str.Length + 1;
                stringTable.Add(str);
            }
        }

        public static GensAnimation ImportXML(string filePath)
        {
            using (var fs = File.OpenRead(filePath))
            {
                return ImportXML(fs);
            }
        }

        public static GensAnimation ImportXML(Stream fileStream)
        {
            var doc = XDocument.Load(fileStream);
            var root = doc.Root;

            GensAnimation anim;
            switch (root.Name.LocalName.ToLower())
            {
                case "uvanimation":
                    anim = new UVAnimation();
                    break;

                case "materialanimation":
                    anim = new MaterialAnimation();
                    break;

                case "visibilityanimation":
                    anim = new VisibilityAnimation();
                    break;

                case "cameraanimation":
                    anim = new CameraAnimation();
                    break;

                case "patternanimation":
                    anim = new PatternAnimation();
                    break;

                case "morphanimation":
                    anim = new MorphAnimation();
                    break;

                case "lightanimation":
                    anim = new LightAnimation();
                    break;

                default:
                    throw new NotSupportedException(
                        $"Cannot yet import this type of animation. (\"{root.Name.LocalName}\")");
            }

            var versionAttr = root.Attribute("version");
            uint.TryParse(versionAttr?.Value, out anim.Header.RootNodeType);

            anim.ReadXML(root);
            return anim;
        }

        protected virtual void ReadXML(XElement root)
        {
            string animtype = GetAnimType();
            foreach (var anim in root.Elements("Animation"))
            {
                Animations.Add(new Animation(anim, animtype));
            }
        }

        protected string GetStringAttr(XAttribute attr)
        {
            return (attr == null || attr.Value == null) ?
                string.Empty : attr.Value;
        }

        public virtual void ExportXML(string filePath)
        {
            using (var fs = File.Create(filePath))
            {
                ExportXML(fs);
            }
        }

        public virtual void ExportXML(FileStream fileStream)
        {
            var root = new XElement("GensAnim", new XAttribute(
                "version", Header.RootNodeType));

            WriteXML(root);

            var doc = new XDocument(root);
            doc.Save(fileStream);
        }

        protected virtual void WriteXML(XElement root)
        {
            foreach (var anim in Animations)
            {
                root.Add(anim.GenerateXElement(GetAnimType()));
            }
        }

        // Other
        public class Animation
        {
            // Variables/Constants
            public List<KeyframeSet> KeyframeSets = new List<KeyframeSet>();
            public string Name = "default";
            public float FPS, StartTime, EndTime;
            // Camera Variables
            public byte Flag1, Flag2, Flag3, Flag4;
            public Vector3 Position, Rotation, Aim;
            public float Twist, NearZ, FarZ, FOV, Aspect;
            //Light Variables
            public Vector4 ColorA, ColorB, ColorC, ColorD;
            public float InnerRange, OuterRange;
            public float Unk1, Unk2, Unk3, Unk4, Unk5, Unk6, Unk7;

            //public uint BlendTypeOffset { get; protected set; }
            //public string BlendType = "default";

            private string animType = "";

            // Constructors
            public Animation() { }
            public Animation(GensReader reader, uint stringTableOffset = 0, string type = "", uint stringTable2Offset = 0)
            {
                animType = type;
                Read(reader, stringTableOffset, stringTable2Offset);
            }

            public Animation(XElement elem, string type = "")
            {
                animType = type;
                ImportXElement(elem);
            }

            // Methods
            public void Read(GensReader reader, uint stringTableOffset = 0, uint stringTable2Offset = 0)
            {
                uint keyframeSetsCount = 0;

                //BlendTypeOffset = reader.ReadUInt32(); // texsetNameOffset for Forces?

                uint NameOffset = reader.ReadUInt32();
                Name = reader.GetString(NameOffset + (stringTableOffset + reader.Offset));

                if (animType == CameraAnimation.Extension ||
                    animType == LightAnimation.Extension)
                {
                    // Flags
                    Flag1 = reader.ReadByte();
                    Flag2 = reader.ReadByte();
                    Flag3 = reader.ReadByte();
                    Flag4 = reader.ReadByte();
                }

                FPS = reader.ReadSingle();
                StartTime = reader.ReadSingle();
                EndTime = reader.ReadSingle();

                // Keyframe Sets
                keyframeSetsCount = reader.ReadUInt32();

                if (animType == CameraAnimation.Extension)
                {
                    //Camera Specific Properties
                    Position = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    Rotation = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    Aim = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    Twist = reader.ReadSingle();
                    NearZ = reader.ReadSingle();
                    FarZ = reader.ReadSingle();
                    FOV = reader.ReadSingle();
                    Aspect = reader.ReadSingle();
                } else if (animType == LightAnimation.Extension)
                {
                    //Light Specific Properties
                    ColorA = new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    ColorB = new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    ColorC = new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    ColorD = new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    Position = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                    Unk1 = reader.ReadSingle();
                    Unk2 = reader.ReadSingle();
                    Unk3 = reader.ReadSingle();
                    Unk4 = reader.ReadSingle();
                    Unk5 = reader.ReadSingle();
                    InnerRange = reader.ReadSingle();
                    OuterRange = reader.ReadSingle();
                    Unk6 = reader.ReadSingle();
                    Unk7 = reader.ReadSingle();
                }

                for (uint i2 = 0; i2 < keyframeSetsCount; ++i2)
                {
                    KeyframeSets.Add(new KeyframeSet(reader, stringTableOffset, animType, stringTable2Offset));
                }
            }

            public void Write(GensWriter writer, string type, ref int startIndex, ref int stringTableSize,
                ref List<string> stringTable, ref int stringTable2Size,
                ref List<string> stringTable2, bool wroteBlendTypeOffset = false)
            {
                //if (!wroteBlendTypeOffset)
                //    writer.Write(0U);
                animType = type;

                if (animType == CameraAnimation.Extension ||
                    animType == LightAnimation.Extension)
                {
                    writer.Write(Flag1);
                    writer.Write(Flag2);
                    writer.Write(Flag3);
                    writer.Write(Flag4);
                }

                writer.Write(FPS);
                writer.Write(StartTime);
                writer.Write(EndTime);

                writer.Write(KeyframeSets.Count);

                if (animType == CameraAnimation.Extension)
                {
                    writer.Write(Position.X);
                    writer.Write(Position.Y);
                    writer.Write(Position.Z);
                    writer.Write(Rotation.X);
                    writer.Write(Rotation.Y);
                    writer.Write(Rotation.Z);
                    writer.Write(Aim.X);
                    writer.Write(Aim.Y);
                    writer.Write(Aim.Z);
                    writer.Write(Twist);
                    writer.Write(NearZ);
                    writer.Write(FarZ);
                    writer.Write(FOV);
                    writer.Write(Aspect);
                }
                else if (animType == LightAnimation.Extension)
                {
                    writer.Write(ColorA.X);
                    writer.Write(ColorA.Y);
                    writer.Write(ColorA.Z);
                    writer.Write(ColorA.W);
                    writer.Write(ColorB.X);
                    writer.Write(ColorB.Y);
                    writer.Write(ColorB.Z);
                    writer.Write(ColorB.W);
                    writer.Write(ColorC.X);
                    writer.Write(ColorC.Y);
                    writer.Write(ColorC.Z);
                    writer.Write(ColorC.W);
                    writer.Write(ColorD.X);
                    writer.Write(ColorD.Y);
                    writer.Write(ColorD.Z);
                    writer.Write(ColorD.W);
                    writer.Write(Position.X);
                    writer.Write(Position.Y);
                    writer.Write(Position.Z);
                    writer.Write(Unk1);
                    writer.Write(Unk2);
                    writer.Write(Unk3);
                    writer.Write(Unk4);
                    writer.Write(Unk5);
                    writer.Write(InnerRange);
                    writer.Write(OuterRange);
                    writer.Write(Unk6);
                    writer.Write(Unk7);
                }

                // Keyframe Sets
                foreach (var set in KeyframeSets)
                {
                    set.Write(writer, animType, startIndex, ref stringTableSize, ref stringTable, stringTable2Size);
                    foreach (var str in set.textureNames)
                    {
                        stringTable2Size += str.Length + 1;
                        stringTable2.Add(str);
                    }
                        
                    startIndex += set.Count;
                }
            }

            public void ImportXElement(XElement elem)
            {
                //animType = GetAnimType();
                //var blendTypeAttr = elem.Attribute("blendType");
                var nameAttr = elem.Attribute("name");
                var fpsAttr = elem.Attribute("fps");
                var startTimeAttr = elem.Attribute("startTime");
                var endTimeAttr = elem.Attribute("endTime");

                //BlendType = (blendTypeAttr == null ||
                //    string.IsNullOrEmpty(blendTypeAttr.Value)) ?
                //    "default" : blendTypeAttr.Value;

                Name = (nameAttr == null ||
                    string.IsNullOrEmpty(nameAttr.Value)) ?
                    "default" : nameAttr.Value;

                float.TryParse(fpsAttr?.Value, out FPS);
                float.TryParse(startTimeAttr?.Value, out StartTime);
                float.TryParse(endTimeAttr?.Value, out EndTime);

                if (animType == CameraAnimation.Extension ||
                    animType == LightAnimation.Extension)
                {
                    var flag1Attr = elem.Attribute("flag1");
                    var flag2Attr = elem.Attribute("flag2");
                    var flag3Attr = elem.Attribute("flag3");
                    var flag4Attr = elem.Attribute("flag4");

                    byte.TryParse(flag1Attr?.Value, out Flag1);
                    byte.TryParse(flag2Attr?.Value, out Flag2);
                    byte.TryParse(flag3Attr?.Value, out Flag3);
                    byte.TryParse(flag4Attr?.Value, out Flag4);

                    if (animType == CameraAnimation.Extension)
                    {
                        var positionAttr = elem.Attribute("position");
                        var rotationAttr = elem.Attribute("rotation");
                        var aimAttr = elem.Attribute("aim");
                        var twistAttr = elem.Attribute("twist");
                        var nearzAttr = elem.Attribute("nearz");
                        var farzAttr = elem.Attribute("farz");
                        var fovAttr = elem.Attribute("fov");
                        var aspectAttr = elem.Attribute("aspect");

                        Position = StringToVector3(positionAttr?.Value);
                        Rotation = StringToVector3(rotationAttr?.Value);
                        Aim = StringToVector3(aimAttr?.Value);
                        float.TryParse(twistAttr?.Value, out Twist);
                        float.TryParse(nearzAttr?.Value, out NearZ);
                        float.TryParse(farzAttr?.Value, out FarZ);
                        float.TryParse(fovAttr?.Value, out FOV);
                        float.TryParse(aspectAttr?.Value, out Aspect);
                    }
                    else if (animType == LightAnimation.Extension)
                    {
                        var coloraAttr = elem.Attribute("colora");
                        var colorbAttr = elem.Attribute("colorb");
                        var colorcAttr = elem.Attribute("colorc");
                        var colordAttr = elem.Attribute("colord");
                        var positionAttr = elem.Attribute("position");
                        var unk1Attr = elem.Attribute("unk1");
                        var unk2Attr = elem.Attribute("unk2");
                        var unk3Attr = elem.Attribute("unk3");
                        var unk4Attr = elem.Attribute("unk4");
                        var unk5Attr = elem.Attribute("unk5");
                        var innerrangeAttr = elem.Attribute("innerrange");
                        var outerrangeAttr = elem.Attribute("outerrange");
                        var unk6Attr = elem.Attribute("unk6");
                        var unk7Attr = elem.Attribute("unk7");

                        ColorA = StringToVector4(coloraAttr?.Value);
                        ColorB = StringToVector4(colorbAttr?.Value);
                        ColorC = StringToVector4(colorcAttr?.Value);
                        ColorD = StringToVector4(colordAttr?.Value);
                        Position = StringToVector3(positionAttr?.Value);
                        float.TryParse(unk1Attr?.Value, out Unk1);
                        float.TryParse(unk2Attr?.Value, out Unk2);
                        float.TryParse(unk3Attr?.Value, out Unk3);
                        float.TryParse(unk4Attr?.Value, out Unk4);
                        float.TryParse(unk5Attr?.Value, out Unk5);
                        float.TryParse(innerrangeAttr?.Value, out InnerRange);
                        float.TryParse(outerrangeAttr?.Value, out OuterRange);
                        float.TryParse(unk6Attr?.Value, out Unk6);
                        float.TryParse(unk7Attr?.Value, out Unk7);
                    }
                }

                foreach (var set in elem.Elements("KeyframeSet"))
                {
                    KeyframeSets.Add(new KeyframeSet(set, animType));
                }
            }

            public Vector3 StringToVector3(string sVector)
            {
                // Remove the parentheses
                if (sVector.StartsWith("(") && sVector.EndsWith(")"))
                {
                    sVector = sVector.Substring(1, sVector.Length - 2);
                }

                // split the items
                string[] sArray = sVector.Split(',');

                // store as a Vector3
                var result = new Vector3(
                    float.Parse(sArray[0]),
                    float.Parse(sArray[1]),
                    float.Parse(sArray[2]));

                return result;
            }

            public Vector4 StringToVector4(string sVector)
            {
                // Remove the parentheses
                if (sVector.StartsWith("(") && sVector.EndsWith(")"))
                {
                    sVector = sVector.Substring(1, sVector.Length - 2);
                }

                // split the items
                string[] sArray = sVector.Split(',');

                // store as a Vector3
                var result = new Vector4(
                    float.Parse(sArray[0]),
                    float.Parse(sArray[1]),
                    float.Parse(sArray[2]),
                    float.Parse(sArray[3]));

                return result;
            }


            public XElement GenerateXElement(string type = "")
            {
                animType = type;

                var elem = new XElement("Animation", 
                    //new XAttribute("blendType", BlendType),
                    new XAttribute("name", Name),
                    new XAttribute("fps", FPS),
                    new XAttribute("startTime", StartTime),
                    new XAttribute("endTime", EndTime));

                if (animType == CameraAnimation.Extension ||
                    animType == LightAnimation.Extension)
                {
                    elem.Add(
                        new XAttribute("flag1", Flag1),
                        new XAttribute("flag2", Flag2),
                        new XAttribute("flag3", Flag3),
                        new XAttribute("flag4", Flag4)
                    );

                    if (animType == CameraAnimation.Extension)
                    {
                        elem.Add(
                            new XAttribute("position", Position),
                            new XAttribute("rotation", Rotation),
                            new XAttribute("aim", Aim),
                            new XAttribute("twist", Twist),
                            new XAttribute("nearz", NearZ),
                            new XAttribute("farz", FarZ),
                            new XAttribute("fov", FOV),
                            new XAttribute("aspect", Aspect)
                        );
                    }
                    else if (animType == LightAnimation.Extension)
                    {
                        elem.Add(
                            new XAttribute("colora", ColorA),
                            new XAttribute("colorb", ColorB),
                            new XAttribute("colorc", ColorC),
                            new XAttribute("colord", ColorD),
                            new XAttribute("position", Position),
                            new XAttribute("unk1", Unk1),
                            new XAttribute("unk2", Unk1),
                            new XAttribute("unk3", Unk1),
                            new XAttribute("unk4", Unk1),
                            new XAttribute("unk5", Unk1),
                            new XAttribute("innerrange", InnerRange),
                            new XAttribute("outerrange", OuterRange),
                            new XAttribute("unk6", Unk6),
                            new XAttribute("unk7", Unk7)
                        );
                    }
                }

                foreach (var set in KeyframeSets)
                {
                    elem.Add(set.GenerateXElement());
                }

                return elem;
            }
        }

        public class KeyframeSet : List<Keyframe>
        {
            // Variables/Constants
            public byte Flag1 = 1, Flag2 = 1, Flag3, Flag4;
            private uint keyframeCount, startIndex;
            // Pattern Variables
            private uint namesCount, namesStartOffset;
            public List<string> textureNames = new List<string>();
            // Morph Variables
            private string name;

            private string animType = "";

            // Constructors
            public KeyframeSet() { }
            public KeyframeSet(GensReader reader, uint stringTableOffset, string type = "", uint stringTable2Offset = 0)
            {
                animType = type;
                Read(reader, stringTableOffset, stringTable2Offset);
            }

            public KeyframeSet(XElement elem, string type = "")
            {
                animType = type;
                ImportXElement(elem);
            }

            // Methods
            public void Read(GensReader reader, uint stringTableOffset, uint stringTable2Offset = 0)
            {
                if (animType == MorphAnimation.Extension)
                    name = reader.GetString(reader.ReadUInt32() + (stringTableOffset + reader.Offset));

                Flag1 = reader.ReadByte();
                Flag2 = reader.ReadByte();
                Flag3 = reader.ReadByte();
                Flag4 = reader.ReadByte();

                keyframeCount = reader.ReadUInt32();
                startIndex = reader.ReadUInt32();

                if (animType == PatternAnimation.Extension)
                {
                    namesCount = reader.ReadUInt32();
                    namesStartOffset = reader.ReadUInt32();

                    long curPos = reader.BaseStream.Position;
                    reader.BaseStream.Position = namesStartOffset + (stringTable2Offset + reader.Offset);
                    for (int i = 0; i < namesCount; i++)
                    {
                        textureNames.Add(reader.ReadNullTerminatedString());
                    }
                    reader.BaseStream.Position = curPos;
                }
            }

            public void Write(GensWriter writer, string type, int startIndex,
                ref int stringTableSize, ref List<string> stringTable, int startOffset = 0)
            {
                animType = type;

                if (animType == MorphAnimation.Extension)
                {
                    AddStringToTable(name, writer, ref stringTableSize, ref stringTable);
                }

                writer.Write(Flag1);
                writer.Write(Flag2);
                writer.Write(Flag3);
                writer.Write(Flag4);

                writer.Write(Count);
                writer.Write(startIndex);

                if (animType == PatternAnimation.Extension)
                {
                    writer.Write(textureNames.Count);
                    writer.Write(startOffset);
                }
            }

            void AddStringToTable(string str, GensWriter writer,
                ref int stringTableSize, ref List<string> stringTable)
            {
                writer.Write(stringTableSize);
                stringTableSize += str.Length + 1;
                stringTable.Add(str);
            }

            public void ReadKeyframes(ExtendedBinaryReader reader, uint keyframesOffset)
            {
                ReadKeyframes(reader, keyframesOffset, reader.Offset);
            }

            public void ReadKeyframes(BinaryReader reader,
                uint keyframesOffset, uint offset)
            {
                reader.BaseStream.Position = (keyframesOffset + offset +
                    (startIndex * Keyframe.Size));

                for (uint i = 0; i < keyframeCount; ++i)
                {
                    Add(new Keyframe(reader));
                }
            }

            public void WriteKeyframes(BinaryWriter writer)
            {
                foreach (var keyframe in this)
                {
                    keyframe.Write(writer);
                }
            }

            public void ImportXElement(XElement elem)
            {
                var flag1Attr = elem.Attribute("flag1");
                var flag2Attr = elem.Attribute("flag2");
                var flag3Attr = elem.Attribute("flag3");
                var flag4Attr = elem.Attribute("flag4");

                byte.TryParse(flag1Attr?.Value, out Flag1);
                byte.TryParse(flag2Attr?.Value, out Flag2);
                byte.TryParse(flag3Attr?.Value, out Flag3);
                byte.TryParse(flag4Attr?.Value, out Flag4);

                if (animType == MorphAnimation.Extension)
                {
                    var nameAttr = elem.Attribute("name");
                    name = (nameAttr == null ||
                        string.IsNullOrEmpty(nameAttr.Value)) ?
                        "default" : nameAttr.Value;
                }

                if (animType == PatternAnimation.Extension)
                {
                    foreach (var texture in elem.Elements("Texture"))
                    {
                        textureNames.Add(texture.Attribute("name").Value);
                    }
                }

                foreach (var keyframe in elem.Elements("Keyframe"))
                {
                    Add(new Keyframe(keyframe));
                }
            }

            public XElement GenerateXElement()
            {
                var elem = new XElement("KeyframeSet",
                    new XAttribute("flag1", Flag1),
                    new XAttribute("flag2", Flag2),
                    new XAttribute("flag3", Flag3),
                    new XAttribute("flag4", Flag4));

                if (animType == MorphAnimation.Extension)
                {
                    elem.Add(
                            new XAttribute("name", name));
                }

                if (animType == PatternAnimation.Extension)
                {
                    foreach (string texture in textureNames)
                    elem.Add(new XElement("Texture",
                        new XAttribute("name", texture)));
                }

                foreach (var keyframe in this)
                {
                    elem.Add(keyframe.GenerateXElement());
                }

                return elem;
            }
        }

        public class Keyframe
        {
            // Variables/Constants
            public float Index, Value;
            public const uint Size = 8;

            // Constructors
            public Keyframe() { }
            public Keyframe(BinaryReader reader)
            {
                Read(reader);
            }

            public Keyframe(XElement elem)
            {
                ImportXElement(elem);
            }

            // Methods
            public void Read(BinaryReader reader)
            {
                Index = reader.ReadSingle();
                Value = reader.ReadSingle();
            }

            public void Write(BinaryWriter writer)
            {
                writer.Write(Index);
                writer.Write(Value);
            }

            public void ImportXElement(XElement elem)
            {
                var indexAttr = elem.Attribute("index");
                var valueAttr = elem.Attribute("value");

                float.TryParse(indexAttr?.Value, out Index);
                float.TryParse(valueAttr?.Value, out Value);
            }

            public XElement GenerateXElement()
            {
                return new XElement("Keyframe",
                    new XAttribute("index", Index),
                    new XAttribute("value", Value));
            }
        }
    }
}