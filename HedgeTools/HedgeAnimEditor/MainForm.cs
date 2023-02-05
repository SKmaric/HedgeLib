using HedgeLib;
using HedgeLib.Animations;
using System;
using System.IO;
using System.Windows.Forms;

namespace HedgeAnimEditor
{
    public partial class MainForm : Form
    {
        public GensAnimation GensAnimation;
        public string LoadedFilePath = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Animation";
            openFileDialog.Filter = "Mirage Animation|*.uv-anim;*.cam-anim;*.vis-anim;*.mat-anim";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.OpenAnim(openFileDialog.FileName);
        }

        public void OpenAnim(string filePath)
        {
            Console.WriteLine("Opening Animation File: {0}", (object)filePath);
            this.LoadedFilePath = filePath;

            try
            {
                var anim = Program.LoadAnim(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Program.ProgramName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //this.Update();
        }
    }
}
