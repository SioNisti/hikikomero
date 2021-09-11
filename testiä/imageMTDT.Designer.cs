
namespace testiä
{
    partial class imageMTDT
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(imageMTDT));
            this.prevbtn = new System.Windows.Forms.Button();
            this.nxtbtn = new System.Windows.Forms.Button();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DirectoryBtn = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ChosenFolder = new System.Windows.Forms.TextBox();
            this.FileBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrentFile = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.MetadataBox = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TagGiver = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TagAdder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // prevbtn
            // 
            this.prevbtn.Location = new System.Drawing.Point(12, 630);
            this.prevbtn.Name = "prevbtn";
            this.prevbtn.Size = new System.Drawing.Size(486, 39);
            this.prevbtn.TabIndex = 0;
            this.prevbtn.Text = "Previous";
            this.prevbtn.UseVisualStyleBackColor = true;
            this.prevbtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // nxtbtn
            // 
            this.nxtbtn.Location = new System.Drawing.Point(502, 630);
            this.nxtbtn.Name = "nxtbtn";
            this.nxtbtn.Size = new System.Drawing.Size(486, 39);
            this.nxtbtn.TabIndex = 1;
            this.nxtbtn.Text = "Next";
            this.nxtbtn.UseVisualStyleBackColor = true;
            this.nxtbtn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox.Location = new System.Drawing.Point(12, 28);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(979, 596);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 2;
            this.PictureBox.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DirectoryBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DirectoryBtn
            // 
            this.DirectoryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DirectoryBtn.Image = ((System.Drawing.Image)(resources.GetObject("DirectoryBtn.Image")));
            this.DirectoryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DirectoryBtn.Name = "DirectoryBtn";
            this.DirectoryBtn.Size = new System.Drawing.Size(59, 22);
            this.DirectoryBtn.Text = "Directory";
            this.DirectoryBtn.Click += new System.EventHandler(this.ToolStripButton1_Click_1);
            // 
            // ChosenFolder
            // 
            this.ChosenFolder.Location = new System.Drawing.Point(997, 28);
            this.ChosenFolder.Name = "ChosenFolder";
            this.ChosenFolder.ReadOnly = true;
            this.ChosenFolder.Size = new System.Drawing.Size(255, 20);
            this.ChosenFolder.TabIndex = 7;
            this.ChosenFolder.Text = "Folder path";
            // 
            // FileBox
            // 
            this.FileBox.AllowDrop = true;
            this.FileBox.CheckBoxes = true;
            this.FileBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.FileBox.HideSelection = false;
            this.FileBox.Location = new System.Drawing.Point(997, 79);
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(255, 213);
            this.FileBox.TabIndex = 8;
            this.FileBox.UseCompatibleStateImageBehavior = false;
            this.FileBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File name";
            this.columnHeader1.Width = 230;
            // 
            // CurrentFile
            // 
            this.CurrentFile.Location = new System.Drawing.Point(997, 54);
            this.CurrentFile.Name = "CurrentFile";
            this.CurrentFile.ReadOnly = true;
            this.CurrentFile.Size = new System.Drawing.Size(255, 20);
            this.CurrentFile.TabIndex = 9;
            this.CurrentFile.Text = "File Name";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Location = new System.Drawing.Point(1132, 5);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(120, 16);
            this.numericUpDown1.TabIndex = 10;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown2.Location = new System.Drawing.Point(997, 5);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.ReadOnly = true;
            this.numericUpDown2.Size = new System.Drawing.Size(120, 16);
            this.numericUpDown2.TabIndex = 11;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MetadataBox
            // 
            this.MetadataBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.MetadataBox.HideSelection = false;
            this.MetadataBox.Location = new System.Drawing.Point(997, 325);
            this.MetadataBox.Name = "MetadataBox";
            this.MetadataBox.Size = new System.Drawing.Size(256, 344);
            this.MetadataBox.TabIndex = 13;
            this.MetadataBox.UseCompatibleStateImageBehavior = false;
            this.MetadataBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data";
            this.columnHeader3.Width = 120;
            // 
            // TagGiver
            // 
            this.TagGiver.Location = new System.Drawing.Point(997, 299);
            this.TagGiver.Name = "TagGiver";
            this.TagGiver.Size = new System.Drawing.Size(174, 20);
            this.TagGiver.TabIndex = 14;
            this.TagGiver.Text = "Separate tags with ; (semicolon)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // TagAdder
            // 
            this.TagAdder.Location = new System.Drawing.Point(1177, 299);
            this.TagAdder.Name = "TagAdder";
            this.TagAdder.Size = new System.Drawing.Size(75, 20);
            this.TagAdder.TabIndex = 16;
            this.TagAdder.Text = "Add Tags";
            this.TagAdder.UseVisualStyleBackColor = true;
            this.TagAdder.Click += new System.EventHandler(this.TagAdder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // imageMTDT
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TagAdder);
            this.Controls.Add(this.TagGiver);
            this.Controls.Add(this.MetadataBox);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.CurrentFile);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.ChosenFolder);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.nxtbtn);
            this.Controls.Add(this.prevbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "imageMTDT";
            this.Text = "Image Metadata";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button prevbtn;
        private System.Windows.Forms.Button nxtbtn;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton DirectoryBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox ChosenFolder;
        private System.Windows.Forms.ListView FileBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox CurrentFile;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.ListView MetadataBox;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox TagGiver;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button TagAdder;
        private System.Windows.Forms.Button button1;
    }
}

