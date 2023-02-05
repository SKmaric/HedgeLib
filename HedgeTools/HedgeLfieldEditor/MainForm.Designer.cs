namespace gens_lightfield_editor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.ListBox2 = new System.Windows.Forms.ListBox();
            this.TxtIndexValue = new System.Windows.Forms.TextBox();
            this.TxtType = new System.Windows.Forms.TextBox();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_Index = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Red = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Green = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Blue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_ColorID = new System.Windows.Forms.NumericUpDown();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Index)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ColorID)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(13, 13);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(75, 23);
            this.BtnOpen.TabIndex = 0;
            this.BtnOpen.Text = "Open .lft";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(95, 13);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Save .lft";
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // ListBox1
            // 
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(180, 43);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(75, 303);
            this.ListBox1.TabIndex = 7;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // ListBox2
            // 
            this.ListBox2.FormattingEnabled = true;
            this.ListBox2.Location = new System.Drawing.Point(475, 43);
            this.ListBox2.Name = "ListBox2";
            this.ListBox2.Size = new System.Drawing.Size(75, 303);
            this.ListBox2.TabIndex = 7;
            this.ListBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2_SelectedIndexChanged);
            // 
            // TxtIndexValue
            // 
            this.TxtIndexValue.Location = new System.Drawing.Point(369, 104);
            this.TxtIndexValue.Name = "TxtIndexValue";
            this.TxtIndexValue.Size = new System.Drawing.Size(100, 20);
            this.TxtIndexValue.TabIndex = 4;
            // 
            // TxtType
            // 
            this.TxtType.Location = new System.Drawing.Point(262, 63);
            this.TxtType.Name = "TxtType";
            this.TxtType.Size = new System.Drawing.Size(100, 20);
            this.TxtType.TabIndex = 3;
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(369, 63);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(100, 20);
            this.TxtValue.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Color ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Red";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Green";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Blue";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Index ID:";
            // 
            // numericUpDown_Index
            // 
            this.numericUpDown_Index.Location = new System.Drawing.Point(261, 105);
            this.numericUpDown_Index.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown_Index.Name = "numericUpDown_Index";
            this.numericUpDown_Index.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown_Index.TabIndex = 8;
            this.numericUpDown_Index.ValueChanged += new System.EventHandler(this.numericUpDown_Index_ValueChanged);
            // 
            // numericUpDown_Red
            // 
            this.numericUpDown_Red.Location = new System.Drawing.Point(366, 266);
            this.numericUpDown_Red.Maximum = new decimal(new int[] {
            (int) byte.MaxValue,
            0,
            0,
            0});
            this.numericUpDown_Red.Name = "numericUpDown_Red";
            this.numericUpDown_Red.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown_Red.TabIndex = 9;
            // 
            // numericUpDown_Green
            // 
            this.numericUpDown_Green.Location = new System.Drawing.Point(366, 293);
            this.numericUpDown_Green.Maximum = new decimal(new int[] {
            (int) byte.MaxValue,
            0,
            0,
            0});
            this.numericUpDown_Green.Name = "numericUpDown_Green";
            this.numericUpDown_Green.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown_Green.TabIndex = 10;
            // 
            // numericUpDown_Blue
            // 
            this.numericUpDown_Blue.Location = new System.Drawing.Point(366, 320);
            this.numericUpDown_Blue.Maximum = new decimal(new int[] {
            (int) byte.MaxValue,
            0,
            0,
            0});
            this.numericUpDown_Blue.Name = "numericUpDown_Blue";
            this.numericUpDown_Blue.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown_Blue.TabIndex = 11;
            // 
            // numericUpDown_ColorID
            // 
            this.numericUpDown_ColorID.Location = new System.Drawing.Point(420, 293);
            this.numericUpDown_ColorID.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown_ColorID.Name = "numericUpDown_ColorID";
            this.numericUpDown_ColorID.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_ColorID.TabIndex = 8;
            this.numericUpDown_ColorID.ValueChanged += new System.EventHandler(this.numericUpDown_ColorID_ValueChanged);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 43);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(157, 302);
            this.treeView1.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 355);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.numericUpDown_ColorID);
            this.Controls.Add(this.numericUpDown_Blue);
            this.Controls.Add(this.numericUpDown_Green);
            this.Controls.Add(this.numericUpDown_Red);
            this.Controls.Add(this.numericUpDown_Index);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.TxtType);
            this.Controls.Add(this.TxtIndexValue);
            this.Controls.Add(this.ListBox2);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnOpen);
            this.Name = "MainForm";
            this.Text = "Generations Lightfield Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Index)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ColorID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.ListBox ListBox2;
        private System.Windows.Forms.TextBox TxtIndexValue;
        private System.Windows.Forms.TextBox TxtType;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_Index;
        private System.Windows.Forms.NumericUpDown numericUpDown_Red;
        private System.Windows.Forms.NumericUpDown numericUpDown_Green;
        private System.Windows.Forms.NumericUpDown numericUpDown_Blue;
        private System.Windows.Forms.NumericUpDown numericUpDown_ColorID;
        private System.Windows.Forms.TreeView treeView1;
    }
}