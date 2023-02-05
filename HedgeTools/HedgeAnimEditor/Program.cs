using HedgeLib.Animations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HedgeAnimEditor
{
    internal static class Program
    {
        // Variables/Constants
        public static MainForm MainForm;
        public const string ProgramName = "Hedge Anim Editor";

        // Methods
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static GensAnimation LoadAnim(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            GensAnimation anim = null;

            // Checks if the file even exist.
            if (!File.Exists(fileInfo.FullName))
                throw new FileNotFoundException("The given archive does not exist.");

            // Checks if the file is not empty.
            if (fileInfo.Length == 0)
                throw new Exception("The given file is empty.");

            // TODO: Add support for other types of archive.
            if (fileInfo.Extension == UVAnimation.Extension)
            {
                anim = new UVAnimation();
            }
            else if (fileInfo.Extension == CameraAnimation.Extension)
            {
                anim = new CameraAnimation();
            }
            else if (fileInfo.Extension == VisibilityAnimation.Extension)
            {
                anim = new VisibilityAnimation();
            }
            else if (fileInfo.Extension == MaterialAnimation.Extension)
            {
                anim = new MaterialAnimation();
            }
            else
                throw new Exception("The given file has an unknown extension.");

            anim.Load(filePath);

            return anim;
        }
    }
}
