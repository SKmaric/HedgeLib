using HedgeLib.Animations;
using HedgeLib.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace HedgeAnimEditor
{
    internal static class Program
    {
        // Variables/Constants
        public static MainForm MainForm;
        public const string ProgramName = "Hedge Anim Editor";

        // Methods
        [STAThread]
        //static void Main()
        //{
        //    Application.SetHighDpiMode(HighDpiMode.SystemAware);
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new MainForm());
        //}

        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Error: No Input file was given!\n");
                ShowHelp();
                return;
            }

            // Checks if the input has .otf or .ttf
            if (!CheckExtension(args[0], ".xml", ".uv-anim", ".cam-anim", ".pt-anim", ".mat-anim", ".lit-anim", ".vis-anim", ".morph-anim"))
            {
                Console.WriteLine("Error: Input file doesn't have a .otf, .ttf or .scfnt extension!\n");
                ShowHelp();
                return;
            }

            bool isXml = args[0].ToLower().EndsWith(".xml");
            // Input
            FileInfo fileInfo = new FileInfo(args[0]);
            // Output
            string outputFilePath;
            if (isXml)
            {
                outputFilePath = Path.ChangeExtension(fileInfo.FullName, "");
            }
            else
            {
                outputFilePath = fileInfo.FullName + ".xml";
            }

            // Get output path
            if (args.Length > 1)
                outputFilePath = args[1];

            if (isXml)
            {
                ExportAnim(fileInfo, outputFilePath);
            }
            else
            {
                ExportXML(fileInfo, outputFilePath);
            }
        }

        public static bool CheckExtension(string current, params string[] expectedExtensions)
        {
            foreach (string ext in expectedExtensions)
                if (current.ToLower().EndsWith(ext))
                    return true;
            return false;
        }

        public static void ExportAnim(FileInfo fileInfo, string outputFile)
        {
            var anim = GensAnimation.ImportXML(fileInfo.FullName);
            outputFile = Path.ChangeExtension(outputFile, anim.Extension);
            anim.Save(outputFile, true);
        }

        public static void ExportXML(FileInfo fileInfo, string outputFile)
        {
            var anim = LoadAnim(fileInfo.FullName);
            anim.ExportXML(outputFile);
        }

        public static GensAnimation LoadAnim(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            GensAnimation anim = null;

            // Checks if the file even exist.
            if (!File.Exists(fileInfo.FullName))
                throw new FileNotFoundException("The given file does not exist.");

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
            else if (fileInfo.Extension == MorphAnimation.Extension)
            {
                anim = new MorphAnimation();
            }
            else if (fileInfo.Extension == PatternAnimation.Extension)
            {
                anim = new PatternAnimation();
            }
            else if (fileInfo.Extension == LightAnimation.Extension)
            {
                anim = new LightAnimation();
            }
            else
                throw new Exception("The given file has an unknown extension.");

            anim.Load(filePath);

            return anim;
        }
        public static void ShowHelp()
        {
            Console.WriteLine("HedgeAnimEditor input [output]");
            Console.WriteLine("By: SKmaric");

            Console.WriteLine();
            Console.WriteLine("Arguments (arguments surrounded by square brackets are optional):");
            Console.WriteLine("- input: \tPath to an ANIM or XML file.");
            Console.WriteLine("- [output]: \tPath to save the XML or ANIM file");

            Pause();
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
