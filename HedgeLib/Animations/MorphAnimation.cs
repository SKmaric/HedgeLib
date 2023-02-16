using HedgeLib.IO;
using System.IO;
using System.Xml.Linq;

namespace HedgeLib.Animations
{
    public class MorphAnimation : GensAnimation
    {
        // Variables/Constants
        public const string Extension = ".morph-anim";

        // Methods
        public override string GetAnimType()
        {
            return Extension;
        }

        protected override void ReadXML(XElement root)
        {
            base.ReadXML(root);
        }

        protected override void WriteXML(XElement root)
        {
            root.Name = "MorphAnimation";
            base.WriteXML(root);
        }
    }
}