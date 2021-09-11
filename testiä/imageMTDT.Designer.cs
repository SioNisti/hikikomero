
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
            this.TagSearch = new System.Windows.Forms.TextBox();
            this.descriptionMTDT = new System.Windows.Forms.DataGridView();
            this.mtdtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtdtData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_description = new System.Windows.Forms.Button();
            this.tab_origin = new System.Windows.Forms.Button();
            this.tab_camera = new System.Windows.Forms.Button();
            this.tab_ap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageamount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionMTDT)).BeginInit();
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
            // TagSearch
            // 
            resources.ApplyResources(this.TagSearch, "TagSearch");
            this.TagSearch.Name = "TagSearch";
            this.TagSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TagSearch_KeyUp);
            // 
            // descriptionMTDT
            // 
            this.descriptionMTDT.AllowUserToAddRows = false;
            this.descriptionMTDT.AllowUserToDeleteRows = false;
            this.descriptionMTDT.BackgroundColor = System.Drawing.Color.White;
            this.descriptionMTDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.descriptionMTDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mtdtName,
            this.mtdtData,
            this.exif});
            this.descriptionMTDT.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.descriptionMTDT, "descriptionMTDT");
            this.descriptionMTDT.Name = "descriptionMTDT";
            this.descriptionMTDT.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.descriptionMTDT_CellEndEdit);
            this.descriptionMTDT.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.descriptionMTDT_CellLeave);
            this.descriptionMTDT.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PictureBox_KeyUp);
            // 
            // mtdtName
            // 
            this.mtdtName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.mtdtName, "mtdtName");
            this.mtdtName.Name = "mtdtName";
            this.mtdtName.ReadOnly = true;
            this.mtdtName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mtdtData
            // 
            this.mtdtData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.mtdtData, "mtdtData");
            this.mtdtData.Name = "mtdtData";
            this.mtdtData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // exif
            // 
            resources.ApplyResources(this.exif, "exif");
            this.exif.Name = "exif";
            this.exif.ReadOnly = true;
            // 
            // tab_description
            // 
            resources.ApplyResources(this.tab_description, "tab_description");
            this.tab_description.Name = "tab_description";
            this.tab_description.UseVisualStyleBackColor = true;
            this.tab_description.Click += new System.EventHandler(this.tab_description_Click);
            // 
            // tab_origin
            // 
            resources.ApplyResources(this.tab_origin, "tab_origin");
            this.tab_origin.Name = "tab_origin";
            this.tab_origin.UseVisualStyleBackColor = true;
            this.tab_origin.Click += new System.EventHandler(this.tab_origin_Click);
            // 
            // tab_camera
            // 
            resources.ApplyResources(this.tab_camera, "tab_camera");
            this.tab_camera.Name = "tab_camera";
            this.tab_camera.UseVisualStyleBackColor = true;
            // 
            // tab_ap
            // 
            resources.ApplyResources(this.tab_ap, "tab_ap");
            this.tab_ap.Name = "tab_ap";
            this.tab_ap.UseVisualStyleBackColor = true;
            // 
            // imageMTDT
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tab_ap);
            this.Controls.Add(this.tab_camera);
            this.Controls.Add(this.tab_origin);
            this.Controls.Add(this.tab_description);
            this.Controls.Add(this.descriptionMTDT);
            this.Controls.Add(this.TagSearch);
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
            this.Load += new System.EventHandler(this.imageMTDT_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragfolder);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PictureBox_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageamount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionMTDT)).EndInit();
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
        private System.Windows.Forms.TextBox TagSearch;
        private System.Windows.Forms.DataGridView descriptionMTDT;
        private System.Windows.Forms.Button tab_description;
        private System.Windows.Forms.Button tab_origin;
        private System.Windows.Forms.Button tab_camera;
        private System.Windows.Forms.Button tab_ap;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtdtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mtdtData;
        private System.Windows.Forms.DataGridViewTextBoxColumn exif;
    }
}

