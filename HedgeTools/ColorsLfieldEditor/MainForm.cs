using HedgeLib;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace colors_lightfield_editor
{
    public partial class MainForm : Form
    {
        public LightfieldData LightfieldData = (LightfieldData)null;
        public string LoadedFilePath = "";
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open Lightfield";
            openFileDialog1.Filter = "Colors Lightfield|*.orc";
            OpenFileDialog openFileDialog2 = openFileDialog1;
            if (openFileDialog2.ShowDialog() != DialogResult.OK)
                return;
            this.OpenLightfield(openFileDialog2.FileName);
        }

        public void OpenLightfield(string filePath)
        {
            Console.WriteLine("Opening Lightfield File: {0}", (object)filePath);
            this.LoadedFilePath = filePath;
            this.LightfieldData = new LightfieldData();
            using (FileStream fileStream = File.OpenRead(filePath))
                this.LightfieldData.Load((Stream)fileStream);
            this.UpdateBlocks();
        }

        public void UpdateBlocks()
        {
            for (uint index = 0; (long)index < (long)this.LightfieldData.objs.Count; ++index)
                this.ListBox1.Items.Add((object)index);
            for (uint index = 0; (long)index < (long)this.LightfieldData.transforms.Count; ++index)
                this.ListBox2.Items.Add((object)index);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TxtNodeName.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].ObjectName;
            this.TxtColorID.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].ColorID.ToString();
            this.TxtShapeType.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].ShapeType.ToString();
            this.textBox2.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown2.ToString();
            this.textBox3.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown3.ToString();
            this.textBox4.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown4.ToString();
            this.textBox5.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown5.ToString();
            this.textBox6.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown6.ToString();
            this.textBox7.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown7.ToString();
            if (!this.ChkZUp.Checked)
            {
                this.textBox8.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown8.ToString();
                this.textBox9.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown9.ToString();
                this.textBox10.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown10.ToString();
            }
            else
            {
                this.textBox8.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown8.ToString();
                this.textBox9.Text = (this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown10 * -1f).ToString();
                this.textBox10.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].unknown9.ToString();
            }
            this.textBox11.Text = ((Vector4)this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation).W.ToString();
            this.textBox12.Text = ((Vector4)this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation).X.ToString();
            this.textBox13.Text = ((Vector4)this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation).Y.ToString();
            this.textBox14.Text = ((Vector4)this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation).Z.ToString();
            if (!this.ChkZUp.Checked)
            {
                this.textBox23.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation3.X.ToString();
                this.textBox24.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation3.Y.ToString();
                this.textBox25.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation3.Z.ToString();
            }
            else
            {
                this.textBox23.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation3.X.ToString();
                this.textBox24.Text = (this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation3.Z * -1f).ToString();
                this.textBox25.Text = this.LightfieldData.objs[this.ListBox1.SelectedIndex].Rotation3.Y.ToString();
            }
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox15.Text = this.LightfieldData.transforms[this.ListBox2.SelectedIndex].unknown1.ToString();
            this.textBox16.Text = this.LightfieldData.transforms[this.ListBox2.SelectedIndex].unknown2.ToString();
            this.textBox17.Text = this.LightfieldData.transforms[this.ListBox2.SelectedIndex].unknown3.ToString();
            this.textBox18.Text = this.LightfieldData.transforms[this.ListBox2.SelectedIndex].unknown4.ToString();
            this.textBox19.Text = this.LightfieldData.transforms[this.ListBox2.SelectedIndex].unknown5.ToString();
            this.textBox20.Text = this.LightfieldData.transforms[this.ListBox2.SelectedIndex].unknown6.ToString();
            this.textBox21.Text = this.LightfieldData.transforms[this.ListBox2.SelectedIndex].unknown7.ToString();
            this.textBox22.Text = this.LightfieldData.transforms[this.ListBox2.SelectedIndex].unknown8.ToString();
        }
    }
}
