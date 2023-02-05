using HedgeLib.IO;
using System.IO;
using System.Xml.Linq;

namespace HedgeLib.Animations
{
    public class CameraAnimation : GensAnimation
    {
        // Variables/Constants
        public const string Extension = ".cam-anim";

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
            root.Name = "CameraAnimation";
            root.Add(new XComment("KeyframeSet Flag1 = Camera Parameter channel (X,Y,Z etc.) to apply this animation to."));
            root.Add(new XComment("Keyframe Value = Override applied to the specified channel."));
            base.WriteXML(root);
        }
    }
}