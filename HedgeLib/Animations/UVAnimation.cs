using HedgeLib.IO;
using System.IO;
using System.Xml.Linq;

namespace HedgeLib.Animations
{
    public class UVAnimation : GensAnimation
    {
        // Variables/Constants
        public string MaterialName { get => name; set => name = value; }
        public string MapName { get => subname; set => subname = value; }
        public const string Extension = ".uv-anim";

        // Methods

        public override string GetAnimType()
        {
            return Extension;
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
            root.Name = "UVAnimation";
            root.Add(new XAttribute("materialName", name));
            root.Add(new XAttribute("mapName", subname));
            //root.Add(new XComment("In Forces, textureName and Animation blendType are swapped."));
            root.Add(new XComment("KeyframeSet Flag1 = 0 : U, 1 : V"));
            root.Add(new XComment("KeyframeSet Flag2 = ?"));
            root.Add(new XComment("KeyframeSet Flag3 = 0 : linear interpolation, 1 : step interpolation"));
            base.WriteXML(root);
        }
    }
}