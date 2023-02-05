namespace HedgeAnimEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnOpenXML = new System.Windows.Forms.Button();
            this.BtnSaveXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(86, 77);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(75, 23);
            this.BtnOpen.TabIndex = 0;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(189, 77);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnOpenXML
            // 
            this.BtnOpenXML.Location = new System.Drawing.Point(86, 134);
            this.BtnOpenXML.Name = "BtnOpenXML";
            this.BtnOpenXML.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenXML.TabIndex = 2;
            this.BtnOpenXML.Text = "Open XML";
            this.BtnOpenXML.UseVisualStyleBackColor = true;
            this.BtnOpenXML.Click += new System.EventHandler(this.BtnOpenXML_Click);
            // 
            // BtnSaveXML
            // 
            this.BtnSaveXML.Location = new System.Drawing.Point(189, 134);
            this.BtnSaveXML.Name = "BtnSaveXML";
            this.BtnSaveXML.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveXML.TabIndex = 3;
            this.BtnSaveXML.Text = "Save XML";
            this.BtnSaveXML.UseVisualStyleBackColor = true;
            this.BtnSaveXML.Click += new System.EventHandler(this.BtnSaveXML_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnSaveXML);
            this.Controls.Add(this.BtnOpenXML);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnOpen);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnOpenXML;
        private System.Windows.Forms.Button BtnSaveXML;
    }
}
