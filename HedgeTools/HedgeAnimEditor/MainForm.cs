using HedgeLib;
using HedgeLib.Animations;
using System;
using System.IO;
using System.Windows.Forms;

namespace HedgeAnimEditor
{
    public partial class MainForm : Form
    {
        // Variables/Constants
        public GensAnimation GensAnimation;
        public string FileName;

        // Constructors
        public MainForm()
        {
            InitializeComponent();
        }

        // Methods
        public void OpenAnim(string filePath)
        {
            Console.WriteLine("Opening Animation File: {0}", (object)filePath);
            this.FileName = filePath;

            try
            {
                var anim = Program.LoadAnim(filePath);
                GensAnimation = anim;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Program.ProgramName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //this.Update();
        }

        public void SaveAnim(bool forceSaveAs = false)
        {
            if (forceSaveAs || string.IsNullOrEmpty(FileName))
            {
                var sfd = new SaveFileDialog()
                {
                    Title = "Save ANIM File...",
                    Filter = "Animation File|*.uv-anim;*.cam-anim;*.vis-anim;*.mat-anim",
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                FileName = sfd.FileName;
            }
            GensAnimation.Save(FileName, true);
        }

        public void SaveAnimXML(bool forceSaveAs = false)
        {
            if (forceSaveAs || string.IsNullOrEmpty(FileName))
            {
                var sfd = new SaveFileDialog()
                {
                    Title = "Save XML File...",
                    Filter = "Animation File XML|*.xml",
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                FileName = sfd.FileName;
            }
            GensAnimation.ExportXML(FileName);
        }

        // GUI Events
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Animation";
            openFileDialog.Filter = "Mirage Animation|*.uv-anim;*.cam-anim;*.vis-anim;*.mat-anim";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.OpenAnim(openFileDialog.FileName);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveAnim(true);
        }

        private void BtnOpenXML_Click(object sender, EventArgs e)
        {

        }

        private void BtnSaveXML_Click(object sender, EventArgs e)
        {
            SaveAnimXML(true);
        }
    }
}
