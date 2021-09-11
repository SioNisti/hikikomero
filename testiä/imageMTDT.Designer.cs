
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
            this.imageamount = new System.Windows.Forms.NumericUpDown();
            this.currentimage = new System.Windows.Forms.NumericUpDown();
            this.MetadataBox = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TagGiver = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TagTaker = new System.Windows.Forms.TextBox();
            this.TagSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mtdtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtdtData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // prevbtn
            // 
            resources.ApplyResources(this.prevbtn, "prevbtn");
            this.prevbtn.Name = "prevbtn";
            this.prevbtn.UseVisualStyleBackColor = true;
            this.prevbtn.Click += new System.EventHandler(this.Button1_Click);
            this.prevbtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PictureBox_KeyUp);
            // 
            // nxtbtn
            // 
            resources.ApplyResources(this.nxtbtn, "nxtbtn");
            this.nxtbtn.Name = "nxtbtn";
            this.nxtbtn.UseVisualStyleBackColor = true;
            this.nxtbtn.Click += new System.EventHandler(this.Button2_Click);
            this.nxtbtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PictureBox_KeyUp);
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.PictureBox, "PictureBox");
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.TabStop = false;
            this.PictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragfolder);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DirectoryBtn});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // DirectoryBtn
            // 
            this.DirectoryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.DirectoryBtn, "DirectoryBtn");
            this.DirectoryBtn.Name = "DirectoryBtn";
            this.DirectoryBtn.Click += new System.EventHandler(this.ToolStripButton1_Click_1);
            // 
            // ChosenFolder
            // 
            this.ChosenFolder.AllowDrop = true;
            resources.ApplyResources(this.ChosenFolder, "ChosenFolder");
            this.ChosenFolder.Name = "ChosenFolder";
            this.ChosenFolder.ReadOnly = true;
            this.ChosenFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragfolder);
            // 
            // FileBox
            // 
            this.FileBox.AllowDrop = true;
            this.FileBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.FileBox.HideSelection = false;
            resources.ApplyResources(this.FileBox, "FileBox");
            this.FileBox.Name = "FileBox";
            this.FileBox.UseCompatibleStateImageBehavior = false;
            this.FileBox.View = System.Windows.Forms.View.Details;
            this.FileBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragfolder);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // CurrentFile
            // 
            resources.ApplyResources(this.CurrentFile, "CurrentFile");
            this.CurrentFile.Name = "CurrentFile";
            this.CurrentFile.ReadOnly = true;
            // 
            // imageamount
            // 
            this.imageamount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.imageamount, "imageamount");
            this.imageamount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.imageamount.Name = "imageamount";
            this.imageamount.ReadOnly = true;
            // 
            // currentimage
            // 
            this.currentimage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.currentimage, "currentimage");
            this.currentimage.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.currentimage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.currentimage.Name = "currentimage";
            this.currentimage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.currentimage_KeyUp);
            // 
            // MetadataBox
            // 
            this.MetadataBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            resources.ApplyResources(this.MetadataBox, "MetadataBox");
            this.MetadataBox.HideSelection = false;
            this.MetadataBox.Name = "MetadataBox";
            this.MetadataBox.UseCompatibleStateImageBehavior = false;
            this.MetadataBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // TagGiver
            // 
            resources.ApplyResources(this.TagGiver, "TagGiver");
            this.TagGiver.Name = "TagGiver";
            this.TagGiver.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TagGiver_KeyUp);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TagTaker
            // 
            resources.ApplyResources(this.TagTaker, "TagTaker");
            this.TagTaker.Name = "TagTaker";
            this.TagTaker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TagTaker_KeyUp);
            // 
            // TagSearch
            // 
            resources.ApplyResources(this.TagSearch, "TagSearch");
            this.TagSearch.Name = "TagSearch";
            this.TagSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TagSearch_KeyUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mtdtName,
            this.mtdtData});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PictureBox_KeyUp);
            // 
            // mtdtName
            // 
            resources.ApplyResources(this.mtdtName, "mtdtName");
            this.mtdtName.Name = "mtdtName";
            this.mtdtName.ReadOnly = true;
            // 
            // mtdtData
            // 
            this.mtdtData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.mtdtData, "mtdtData");
            this.mtdtData.Name = "mtdtData";
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2")});
            this.comboBox1.Name = "comboBox1";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // imageMTDT
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TagSearch);
            this.Controls.Add(this.TagTaker);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TagGiver);
            this.Controls.Add(this.MetadataBox);
            this.Controls.Add(this.currentimage);
            this.Controls.Add(this.imageamount);
            this.Controls.Add(this.CurrentFile);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.ChosenFolder);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.nxtbtn);
            this.Controls.Add(this.prevbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "imageMTDT";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragfolder);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PictureBox_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.NumericUpDown imageamount;
        private System.Windows.Forms.NumericUpDown currentimage;
        private System.Windows.Forms.ListView MetadataBox;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox TagGiver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TagTaker;
        private System.Windows.Forms.TextBox TagSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtdtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtdtData;
    }
}

