// Decompiled with JetBrains decompiler
// Type: gens_lightfield_editor.MainForm
// Assembly: gens-lightfield-editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A9259400-83B4-4707-B039-63A018DCF32F
// Assembly location: E:\Users\SK\Documents\GitHub\Sonic-Colors-Set-Editor\gens-lightfield-editor\obj\Debug\gens-lightfield-editor.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace gens_lightfield_editor
{
  public class MainForm2 : Form
  {
    public LightfieldData LightfieldData = (LightfieldData) null;
    public string LoadedFilePath = "";
    private IContainer components = (IContainer) null;
    private Button BtnOpen;
    private Button BtnSave;
    private TextBox TxtType;
    private TextBox TxtValue;
    private Label label1;
    private Label label2;
    private ListBox ListBox1;
    private ListBox ListBox2;
    private NumericUpDown numericUpDown_ColorID;
    private NumericUpDown numericUpDown_Red;
    private NumericUpDown numericUpDown_Green;
    private NumericUpDown numericUpDown_Blue;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private NumericUpDown numericUpDown_Index;
    private Label label7;
    private TextBox TxtIndexValue;
    private TreeView treeView1;

    public MainForm2() => this.InitializeComponent();

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
      Console.WriteLine("Opening Lightfield File: {0}", (object) filePath);
      this.LoadedFilePath = filePath;
      this.LightfieldData = new LightfieldData();
      using (FileStream fileStream = File.OpenRead(filePath))
        this.LightfieldData.Load((Stream) fileStream);
      this.UpdateBlocks();
    }

    public void UpdateBlocks()
    {
      for (uint index = 0; (long) index < (long) this.LightfieldData.Cubes.Count; ++index)
        this.ListBox1.Items.Add((object) index);
      for (uint index = 0; (long) index < (long) this.LightfieldData.Colors.Count; ++index)
        this.ListBox2.Items.Add((object) index);
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
      this.numericUpDown_Red.Value = (Decimal) this.LightfieldData.Colors[this.ListBox2.SelectedIndex].Color[Convert.ToInt32(this.numericUpDown_ColorID.Value)].Red;
      this.numericUpDown_Green.Value = (Decimal) this.LightfieldData.Colors[this.ListBox2.SelectedIndex].Color[Convert.ToInt32(this.numericUpDown_ColorID.Value)].Green;
      this.numericUpDown_Blue.Value = (Decimal) this.LightfieldData.Colors[this.ListBox2.SelectedIndex].Color[Convert.ToInt32(this.numericUpDown_ColorID.Value)].Blue;
    }

    private void numericUpDown_Index_ValueChanged(object sender, EventArgs e)
    {
      if (this.TxtType.Text == "3")
      {
        this.numericUpDown_Index.Enabled = true;
        this.TxtIndexValue.Text = this.LightfieldData.Indexes[Convert.ToInt32((Decimal) this.LightfieldData.Cubes[this.ListBox1.SelectedIndex].Value + this.numericUpDown_Index.Value)].Value.ToString();
      }
      else
      {
        this.numericUpDown_Index.Enabled = false;
        this.TxtIndexValue.Text = "";
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.BtnOpen = new Button();
      this.BtnSave = new Button();
      this.TxtType = new TextBox();
      this.TxtValue = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.ListBox1 = new ListBox();
      this.ListBox2 = new ListBox();
      this.numericUpDown_ColorID = new NumericUpDown();
      this.numericUpDown_Red = new NumericUpDown();
      this.numericUpDown_Green = new NumericUpDown();
      this.numericUpDown_Blue = new NumericUpDown();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.numericUpDown_Index = new NumericUpDown();
      this.label7 = new Label();
      this.TxtIndexValue = new TextBox();
      this.treeView1 = new TreeView();
      this.numericUpDown_ColorID.BeginInit();
      this.numericUpDown_Red.BeginInit();
      this.numericUpDown_Green.BeginInit();
      this.numericUpDown_Blue.BeginInit();
      this.numericUpDown_Index.BeginInit();
      this.SuspendLayout();
      this.BtnOpen.Location = new Point(13, 13);
      this.BtnOpen.Name = "BtnOpen";
      this.BtnOpen.Size = new Size(75, 23);
      this.BtnOpen.TabIndex = 0;
      this.BtnOpen.Text = "Open .lft";
      this.BtnOpen.UseVisualStyleBackColor = true;
      this.BtnOpen.Click += new EventHandler(this.BtnOpen_Click);
      this.BtnSave.Location = new Point(95, 13);
      this.BtnSave.Name = "BtnSave";
      this.BtnSave.Size = new Size(75, 23);
      this.BtnSave.TabIndex = 1;
      this.BtnSave.Text = "Save .lft";
      this.BtnSave.UseVisualStyleBackColor = true;
      this.TxtType.Location = new Point(262, 63);
      this.TxtType.Name = "TxtType";
      this.TxtType.Size = new Size(100, 20);
      this.TxtType.TabIndex = 3;
      this.TxtValue.Location = new Point(369, 63);
      this.TxtValue.Name = "TxtValue";
      this.TxtValue.Size = new Size(100, 20);
      this.TxtValue.TabIndex = 4;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(262, 44);
      this.label1.Name = "label1";
      this.label1.Size = new Size(31, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Type";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(369, 44);
      this.label2.Name = "label2";
      this.label2.Size = new Size(34, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Value";
      this.ListBox1.FormattingEnabled = true;
      this.ListBox1.Location = new Point(180, 43);
      this.ListBox1.Name = "ListBox1";
      this.ListBox1.Size = new Size(75, 303);
      this.ListBox1.TabIndex = 7;
      this.ListBox1.SelectedIndexChanged += new EventHandler(this.ListBox1_SelectedIndexChanged);
      this.ListBox2.FormattingEnabled = true;
      this.ListBox2.Location = new Point(475, 43);
      this.ListBox2.Name = "ListBox2";
      this.ListBox2.Size = new Size(75, 303);
      this.ListBox2.TabIndex = 7;
      this.ListBox2.SelectedIndexChanged += new EventHandler(this.ListBox2_SelectedIndexChanged);
      this.numericUpDown_ColorID.Location = new Point(420, 293);
      this.numericUpDown_ColorID.Maximum = new Decimal(new int[4]
      {
        7,
        0,
        0,
        0
      });
      this.numericUpDown_ColorID.Name = "numericUpDown_ColorID";
      this.numericUpDown_ColorID.Size = new Size(49, 20);
      this.numericUpDown_ColorID.TabIndex = 8;
      this.numericUpDown_ColorID.ValueChanged += new EventHandler(this.numericUpDown_ColorID_ValueChanged);
      this.numericUpDown_Red.Location = new Point(366, 266);
      this.numericUpDown_Red.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_Red.Name = "numericUpDown_Red";
      this.numericUpDown_Red.Size = new Size(48, 20);
      this.numericUpDown_Red.TabIndex = 9;
      this.numericUpDown_Green.Location = new Point(366, 293);
      this.numericUpDown_Green.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_Green.Name = "numericUpDown_Green";
      this.numericUpDown_Green.Size = new Size(48, 20);
      this.numericUpDown_Green.TabIndex = 10;
      this.numericUpDown_Blue.Location = new Point(366, 320);
      this.numericUpDown_Blue.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_Blue.Name = "numericUpDown_Blue";
      this.numericUpDown_Blue.Size = new Size(48, 20);
      this.numericUpDown_Blue.TabIndex = 11;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(420, 274);
      this.label3.Name = "label3";
      this.label3.Size = new Size(48, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Color ID:";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(324, 268);
      this.label4.Name = "label4";
      this.label4.Size = new Size(27, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Red";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(324, 295);
      this.label5.Name = "label5";
      this.label5.Size = new Size(36, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Green";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(324, 322);
      this.label6.Name = "label6";
      this.label6.Size = new Size(28, 13);
      this.label6.TabIndex = 13;
      this.label6.Text = "Blue";
      this.numericUpDown_Index.Location = new Point(261, 105);
      this.numericUpDown_Index.Maximum = new Decimal(new int[4]
      {
        7,
        0,
        0,
        0
      });
      this.numericUpDown_Index.Name = "numericUpDown_Index";
      this.numericUpDown_Index.Size = new Size(49, 20);
      this.numericUpDown_Index.TabIndex = 8;
      this.numericUpDown_Index.ValueChanged += new EventHandler(this.numericUpDown_Index_ValueChanged);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(261, 86);
      this.label7.Name = "label7";
      this.label7.Size = new Size(50, 13);
      this.label7.TabIndex = 12;
      this.label7.Text = "Index ID:";
      this.TxtIndexValue.Location = new Point(369, 104);
      this.TxtIndexValue.Name = "TxtIndexValue";
      this.TxtIndexValue.Size = new Size(100, 20);
      this.TxtIndexValue.TabIndex = 4;
      this.treeView1.Location = new Point(13, 43);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new Size(157, 302);
      this.treeView1.TabIndex = 14;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(573, 355);
      this.Controls.Add((Control) this.treeView1);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.numericUpDown_Blue);
      this.Controls.Add((Control) this.numericUpDown_Green);
      this.Controls.Add((Control) this.numericUpDown_Red);
      this.Controls.Add((Control) this.numericUpDown_Index);
      this.Controls.Add((Control) this.numericUpDown_ColorID);
      this.Controls.Add((Control) this.ListBox2);
      this.Controls.Add((Control) this.ListBox1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.TxtIndexValue);
      this.Controls.Add((Control) this.TxtValue);
      this.Controls.Add((Control) this.TxtType);
      this.Controls.Add((Control) this.BtnSave);
      this.Controls.Add((Control) this.BtnOpen);
      this.Name = nameof (MainForm2);
      this.Text = "Generations Lightfield Editor";
      this.numericUpDown_ColorID.EndInit();
      this.numericUpDown_Red.EndInit();
      this.numericUpDown_Green.EndInit();
      this.numericUpDown_Blue.EndInit();
      this.numericUpDown_Index.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
