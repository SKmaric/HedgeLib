using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace gens_lightfield_editor
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
            openFileDialog1.Filter = "Generations Lightfield|*.lft";
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
            for (uint index = 0; (long)index < (long)this.LightfieldData.Cubes.Count; ++index)
                this.ListBox1.Items.Add((object)index);
            for (uint index = 0; (long)index < (long)this.LightfieldData.Colors.Count; ++index)
                this.ListBox2.Items.Add((object)index);
            this.treeView1.Nodes.Add("0");
            foreach (TreeNode node1 in this.treeView1.Nodes)
            {
                if (this.LightfieldData.Cubes[Convert.ToInt32(node1.Text)].Type < 3U)
                {
                    int index1 = 0;
                    node1.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node1.Text)].Value.ToString());
                    TreeNodeCollection nodes1 = node1.Nodes;
                    uint num = this.LightfieldData.Cubes[Convert.ToInt32(node1.Text)].Value + 1U;
                    string text1 = num.ToString();
                    nodes1.Add(text1);
                    foreach (TreeNode node2 in this.treeView1.Nodes[0].Nodes)
                    {
                        if (this.LightfieldData.Cubes[Convert.ToInt32(node2.Text)].Type < 3U)
                        {
                            int index2 = 0;
                            node2.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node2.Text)].Value.ToString());
                            TreeNodeCollection nodes2 = node2.Nodes;
                            num = this.LightfieldData.Cubes[Convert.ToInt32(node2.Text)].Value + 1U;
                            string text2 = num.ToString();
                            nodes2.Add(text2);
                            foreach (TreeNode node3 in this.treeView1.Nodes[0].Nodes[index1].Nodes)
                            {
                                if (this.LightfieldData.Cubes[Convert.ToInt32(node3.Text)].Type < 3U)
                                {
                                    int index3 = 0;
                                    node3.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node3.Text)].Value.ToString());
                                    TreeNodeCollection nodes3 = node3.Nodes;
                                    num = this.LightfieldData.Cubes[Convert.ToInt32(node3.Text)].Value + 1U;
                                    string text3 = num.ToString();
                                    nodes3.Add(text3);
                                    foreach (TreeNode node4 in this.treeView1.Nodes[0].Nodes[index1].Nodes[index2].Nodes)
                                    {
                                        if (this.LightfieldData.Cubes[Convert.ToInt32(node4.Text)].Type < 3U)
                                        {
                                            int index4 = 0;
                                            node4.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node4.Text)].Value.ToString());
                                            TreeNodeCollection nodes4 = node4.Nodes;
                                            num = this.LightfieldData.Cubes[Convert.ToInt32(node4.Text)].Value + 1U;
                                            string text4 = num.ToString();
                                            nodes4.Add(text4);
                                            foreach (TreeNode node5 in this.treeView1.Nodes[0].Nodes[index1].Nodes[index2].Nodes[index3].Nodes)
                                            {
                                                if (this.LightfieldData.Cubes[Convert.ToInt32(node5.Text)].Type < 3U)
                                                {
                                                    int index5 = 0;
                                                    node5.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node5.Text)].Value.ToString());
                                                    TreeNodeCollection nodes5 = node5.Nodes;
                                                    num = this.LightfieldData.Cubes[Convert.ToInt32(node5.Text)].Value + 1U;
                                                    string text5 = num.ToString();
                                                    nodes5.Add(text5);
                                                    foreach (TreeNode node6 in this.treeView1.Nodes[0].Nodes[index1].Nodes[index2].Nodes[index3].Nodes[index4].Nodes)
                                                    {
                                                        if (this.LightfieldData.Cubes[Convert.ToInt32(node6.Text)].Type < 3U)
                                                        {
                                                            int index6 = 0;
                                                            node6.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node6.Text)].Value.ToString());
                                                            TreeNodeCollection nodes6 = node6.Nodes;
                                                            num = this.LightfieldData.Cubes[Convert.ToInt32(node6.Text)].Value + 1U;
                                                            string text6 = num.ToString();
                                                            nodes6.Add(text6);
                                                            foreach (TreeNode node7 in this.treeView1.Nodes[0].Nodes[index1].Nodes[index2].Nodes[index3].Nodes[index4].Nodes[index5].Nodes)
                                                            {
                                                                if (this.LightfieldData.Cubes[Convert.ToInt32(node7.Text)].Type < 3U)
                                                                {
                                                                    int index7 = 0;
                                                                    node7.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node7.Text)].Value.ToString());
                                                                    TreeNodeCollection nodes7 = node7.Nodes;
                                                                    num = this.LightfieldData.Cubes[Convert.ToInt32(node7.Text)].Value + 1U;
                                                                    string text7 = num.ToString();
                                                                    nodes7.Add(text7);
                                                                    foreach (TreeNode node8 in this.treeView1.Nodes[0].Nodes[index1].Nodes[index2].Nodes[index3].Nodes[index4].Nodes[index5].Nodes[index6].Nodes)
                                                                    {
                                                                        if (this.LightfieldData.Cubes[Convert.ToInt32(node8.Text)].Type < 3U)
                                                                        {
                                                                            int index8 = 0;
                                                                            node8.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node8.Text)].Value.ToString());
                                                                            TreeNodeCollection nodes8 = node8.Nodes;
                                                                            num = this.LightfieldData.Cubes[Convert.ToInt32(node8.Text)].Value + 1U;
                                                                            string text8 = num.ToString();
                                                                            nodes8.Add(text8);
                                                                            foreach (TreeNode node9 in this.treeView1.Nodes[0].Nodes[index1].Nodes[index2].Nodes[index3].Nodes[index4].Nodes[index5].Nodes[index6].Nodes[index7].Nodes)
                                                                            {
                                                                                if (this.LightfieldData.Cubes[Convert.ToInt32(node9.Text)].Type < 3U)
                                                                                {
                                                                                    node9.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node9.Text)].Value.ToString());
                                                                                    TreeNodeCollection nodes9 = node9.Nodes;
                                                                                    num = this.LightfieldData.Cubes[Convert.ToInt32(node9.Text)].Value + 1U;
                                                                                    string text9 = num.ToString();
                                                                                    nodes9.Add(text9);
                                                                                    foreach (TreeNode node10 in this.treeView1.Nodes[0].Nodes[index1].Nodes[index2].Nodes[index3].Nodes[index4].Nodes[index5].Nodes[index6].Nodes[index7].Nodes[index8].Nodes)
                                                                                    {
                                                                                        if (this.LightfieldData.Cubes[Convert.ToInt32(node10.Text)].Type < 3U)
                                                                                        {
                                                                                            node10.Nodes.Add(this.LightfieldData.Cubes[Convert.ToInt32(node10.Text)].Value.ToString());
                                                                                            TreeNodeCollection nodes10 = node10.Nodes;
                                                                                            num = this.LightfieldData.Cubes[Convert.ToInt32(node10.Text)].Value + 1U;
                                                                                            string text10 = num.ToString();
                                                                                            nodes10.Add(text10);
                                                                                        }
                                                                                    }
                                                                                    ++index8;
                                                                                }
                                                                            }
                                                                            ++index7;
                                                                        }
                                                                    }
                                                                    ++index6;
                                                                }
                                                            }
                                                            ++index5;
                                                        }
                                                    }
                                                    ++index4;
                                                }
                                            }
                                            ++index3;
                                        }
                                    }
                                    ++index2;
                                }
                            }
                            ++index1;
                        }
                    }
                }
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TxtType.Text = this.LightfieldData.Cubes[this.ListBox1.SelectedIndex].Type.ToString();
            this.TxtValue.Text = this.LightfieldData.Cubes[this.ListBox1.SelectedIndex].Value.ToString();
            this.numericUpDown_Index.Value = 1M;
            this.numericUpDown_Index.Value = 0M;
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.numericUpDown_ColorID.Value = 1M;
            this.numericUpDown_ColorID.Value = 0M;
        }

        private void numericUpDown_ColorID_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown_Red.Value = (Decimal)this.LightfieldData.Colors[this.ListBox2.SelectedIndex].Color[Convert.ToInt32(this.numericUpDown_ColorID.Value)].Red;
            this.numericUpDown_Green.Value = (Decimal)this.LightfieldData.Colors[this.ListBox2.SelectedIndex].Color[Convert.ToInt32(this.numericUpDown_ColorID.Value)].Green;
            this.numericUpDown_Blue.Value = (Decimal)this.LightfieldData.Colors[this.ListBox2.SelectedIndex].Color[Convert.ToInt32(this.numericUpDown_ColorID.Value)].Blue;
        }

        private void numericUpDown_Index_ValueChanged(object sender, EventArgs e)
        {
            if (this.TxtType.Text == "3")
            {
                this.numericUpDown_Index.Enabled = true;
                this.TxtIndexValue.Text = this.LightfieldData.Indexes[Convert.ToInt32((Decimal)this.LightfieldData.Cubes[this.ListBox1.SelectedIndex].Value + this.numericUpDown_Index.Value)].Value.ToString();
            }
            else
            {
                this.numericUpDown_Index.Enabled = false;
                this.TxtIndexValue.Text = "";
            }
        }
    }
}
