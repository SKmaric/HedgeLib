using HedgeLib.IO;
using System.IO;
using System.Xml.Linq;

namespace HedgeLib.Animations
{
    public class VisibilityAnimation : GensAnimation
    {
        // Variables/Constants
        public string ModelName { get => name; set => name = value; }
        public string MeshName { get => subname; set => subname = value; }
        public const string Extension = ".vis-anim";

        // Methods
        public override string GetAnimType()
        {
            return Extension;
        }

        public override void ReadNames(GensReader reader, uint stringTableOffset = 0)
        {
            uint modelNameOffset = reader.ReadUInt32();
            uint meshNameOffset = reader.ReadUInt32();
            ModelName = reader.GetString(modelNameOffset + (stringTableOffset + reader.Offset));
            MeshName = reader.GetString(meshNameOffset + (stringTableOffset + reader.Offset));
        }

        protected override void ReadXML(XElement root)
        {
            var modelNameAttr = root.Attribute("modelName");
            var meshNameAttr = root.Attribute("meshName");

            name = GetStringAttr(modelNameAttr);
            MeshName = GetStringAttr(meshNameAttr);

            base.ReadXML(root);
        }

        protected override void WriteXML(XElement root)
        {
            root.Name = "VisibilityAnimation";
            root.Add(new XAttribute("modelName", name));
            root.Add(new XAttribute("meshName", subname));
            root.Add(new XComment("Controls mesh visibility."));
            root.Add(new XComment("A keyframe with a value of 0 = A frame where the mesh is invisible."));
            root.Add(new XComment("A keyframe with a value of 1 = A frame where the mesh is visible."));
            base.WriteXML(root);
        }
    }
}