using HedgeLib.IO;
using System.IO;
using System.Xml.Linq;

namespace HedgeLib.Animations
{
    public class UVAnimation : GensAnimation
    {
        // Variables/Constants
        public string MaterialName { get => name; set => name = value; }
        public string TextureName { get => subname; set => subname = value; }
        public const string Extension = ".uv-anim";

        // Methods

        public override string GetAnimType()
        {
            return Extension;
        }

        public override void ReadNames(GensReader reader, uint stringTableOffset = 0)
        {
            uint materialNameOffset = reader.ReadUInt32();
            uint textureNameOffset = reader.ReadUInt32();
            MaterialName = reader.GetString(materialNameOffset + (stringTableOffset + reader.Offset));
            TextureName = reader.GetString(textureNameOffset + (stringTableOffset + reader.Offset));
        }

        protected override void ReadXML(XElement root)
        {
            var matNameAttr = root.Attribute("materialName");
            var texNameAttr = root.Attribute("textureName");

            name = GetStringAttr(matNameAttr);
            TextureName = GetStringAttr(texNameAttr);

            base.ReadXML(root);
        }

        protected override void WriteXML(XElement root)
        {
            root.Name = "UVAnimation";
            root.Add(new XAttribute("materialName", name));
            root.Add(new XAttribute("textureName", subname));
            root.Add(new XComment("In Forces, textureName and Animation blendType are swapped."));
            base.WriteXML(root);
        }
    }
}