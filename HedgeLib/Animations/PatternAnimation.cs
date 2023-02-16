using HedgeLib.IO;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace HedgeLib.Animations
{
    public class PatternAnimation : GensAnimation
    {
        // Variables/Constants
        public string MaterialName { get => name; set => name = value; }
        public string MapName { get => subname; set => subname = value; }
        public const string Extension = ".pt-anim";

        // Methods
        public override string GetAnimType()
        {
            return Extension;
        }

        public override IDictionary<string, uint> ReadAnimHeader(GensReader reader)
        {
            IDictionary<string, uint> animHeader = new Dictionary<string, uint>();

            animHeader.Add("metaDataOffset", reader.ReadUInt32());
            animHeader.Add("metaAnimsSize", reader.ReadUInt32());
            animHeader.Add("keyframesOffset", reader.ReadUInt32());
            animHeader.Add("keyframesSize", reader.ReadUInt32());
            animHeader.Add("stringTableOffset", reader.ReadUInt32());
            animHeader.Add("stringTableSize", reader.ReadUInt32());
            animHeader.Add("stringTable2Offset", reader.ReadUInt32());
            animHeader.Add("stringTable2Size", reader.ReadUInt32());

            return animHeader;
        }

        public override void ReadNames(GensReader reader, uint stringTableOffset = 0)
        {
            uint materialNameOffset = reader.ReadUInt32();
            uint mapNameOffset = reader.ReadUInt32();
            MaterialName = reader.GetString(materialNameOffset + stringTableOffset + reader.Offset);
            MapName = reader.GetString(mapNameOffset + stringTableOffset + reader.Offset);
        }

        protected override void ReadXML(XElement root)
        {
            var matNameAttr = root.Attribute("materialName");
            var texNameAttr = root.Attribute("mapName");

            MaterialName = GetStringAttr(matNameAttr);
            MapName = GetStringAttr(texNameAttr);

            base.ReadXML(root);
        }

        protected override void WriteXML(XElement root)
        {
            root.Name = "PatternAnimation";
            root.Add(new XAttribute("materialName", name));
            root.Add(new XAttribute("mapName", subname));
            base.WriteXML(root);
        }
    }
}