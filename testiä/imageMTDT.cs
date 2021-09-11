using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Directory = System.IO.Directory;
using Microsoft.WindowsAPICodePack.Dialogs;
using ExifLibrary;
/*
*nää on kuulemma turhia t:vs
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using ExifLib;
using MetadataExtractor.Formats.Exif;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using GroupDocs.Metadata.Common;
using System.Runtime.InteropServices;
using MetadataExtractor;
using System.Linq;
*/

namespace testiä
{
    public partial class imageMTDT : Form
    {
        public imageMTDT()
        {
            InitializeComponent();
        }

        public string valittukansio2;
        public string valittukuva;
        public string valittukuva2;
        int intti = -1;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TagAdder_Click(object sender, EventArgs e)
        {

            /*Tiedostot jotka tukee tagejä: 
             * jpg, 
             * mp4, m4v, wmv, mkv
             * 
             * äänitiedostot ei tue tagejä mutta niille voi antaa esim: artistin, genren, titlen ja sun muuta
             */


            if (Path.GetExtension(valittukuva2) == ".jpg")
            {

                var file2 = ImageFile.FromFile(valittukuva);

                var oldtags = file2.Properties.Get(ExifTag.WindowsKeywords);

                var bit = new Bitmap(this.Width, this.Height);
                var g = Graphics.FromImage(bit);

                var oldImage = PictureBox.Image;
                PictureBox.Image = bit;
                oldImage?.Dispose();

                g.Dispose();

                string tagstoadd = TagGiver.Text;
                //MessageBox.Show("perkeleen saatanan vittu \"kirjasto\" library on paska helvetti ja kokoversio maksaa ja trial versiossa ei pysty tallentamaan niitä vitun tiedostoja.  mä vittu tunnin yritin miettiä miksi se heittää erroria joka loppujen lopuksi olikin \"haista vittu, köyhät kyykkyyn\" viesti boksi error lootan vaatteissa perkele");

                var file = ImageFile.FromFile(valittukuva);

                //MessageBox.Show(oldtags + tagstoadd);

                file.Properties.Set(ExifTag.WindowsKeywords, oldtags + tagstoadd);
                file.Save(valittukansio2 + "/" + valittukuva2);
                PictureBox.Image = Image.FromFile(@valittukuva);
                Metat();
            }
            else
            {
                MessageBox.Show("Not a JPG file.", "Error");
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {

            var bit = new Bitmap(this.Width, this.Height);
            var g = Graphics.FromImage(bit);
            
            var oldImage = PictureBox.Image;
            PictureBox.Image = bit;
            oldImage?.Dispose();

            g.Dispose();

            if (intti == -1) {
                intti = 0;
            }
            FileBox.Items[0].Selected = true;
            intti--;

            if (intti < 0)
            {
                intti = FileBox.Items.Count - 1;
            }

            if (FileBox.SelectedItems.Count == 0)
                return;

            //MessageBox.Show("a: "+i);
            ListViewItem item = FileBox.Items[intti];
            valittukuva = valittukansio2 + "/" + item.SubItems[0].Text;
            valittukuva2 = item.SubItems[0].Text;
            //MessageBox.Show(valittukuva + "\nkuva: " + intti + "\ntiedostoa kansiossa: " + listView1.Items.Count);
            numericUpDown2.Value = intti;
            numericUpDown1.Value = FileBox.Items.Count;
            CurrentFile.Text = valittukuva2;
            Metat();
            PictureBox.Image = Image.FromFile(@valittukuva);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            var bit = new Bitmap(this.Width, this.Height);
            var g = Graphics.FromImage(bit);

            var oldImage = PictureBox.Image;
            PictureBox.Image = bit;
            oldImage?.Dispose();

            g.Dispose();

            if (intti == -1)
            {
                intti = FileBox.Items.Count - 1;
            }
            FileBox.Items[0].Selected = true;
            intti++;
            //var indeks = 0;

            //getrandomfile2(folderBrowserDialog1.SelectedPath);
            //yourListView_SelectedIndexChanged();

            if (intti == FileBox.Items.Count)
            {
                intti = 0;
            }

            if (intti < 0)
            {   
                intti = 0;
            }

            if (FileBox.SelectedItems.Count == 0)
                return;

            ListViewItem item = FileBox.Items[intti];
            valittukuva = valittukansio2 + "/" + item.SubItems[0].Text;
            valittukuva2 = item.SubItems[0].Text;
            //MessageBox.Show(valittukuva + "\nkuva: " + intti + "\ntiedostoa kansiossa: " + listView1.Items.Count);
            numericUpDown2.Value = intti;
            numericUpDown1.Value = FileBox.Items.Count;
            CurrentFile.Text = valittukuva2;
            Metat();
            PictureBox.Image = Image.FromFile(@valittukuva);
        }

        public void Metat()
        {
            //MessageBox.Show(valittukuva2);
            MetadataBox.Items.Clear();

            var file = ImageFile.FromFile(valittukuva);
            foreach (var property in file.Properties)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ($"{property.Name}");
                item.SubItems.Add(($"{ property.Value}"));

                MetadataBox.Items.Add(item);
            }

            /* tää pois kommentoitu koodi näyttää metadatat käyttäen metadata-extractor:ia
            var directories = ImageMetadataReader.ReadMetadata(valittukuva);

            // print out all metadata

            foreach (var directory in directories)
                foreach (var tag in directory.Tags) { 
                    //listView2.Items.Add($"{tag.Name}");
                    //listView2.Items.Add($"{tag.Description}"); 

                    ListViewItem item = new ListViewItem();
                    item.Text = ($"{tag.Name}");
                    item.SubItems.Add(($"{ tag.Description}"));

                    MetadataBox.Items.Add(item);
                }

            //MessageBox.Show($"{directory.Name} - {tag.Name} = {tag.Description}");

            // access the date time $"{element} "*/
        }

        public void Metat2()
        {/*
            MetadataBox.Items.Clear();
            using (Metadata metadata = new Metadata(valittukuva))
            {
                if (metadata.FileFormat != FileFormat.Unknown)
                {

                    var properties = metadata.FindProperties(p => p.Tags.Any(t => t.Category == Tags.Content));
                    foreach (var property in properties)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = ($"{property.Name}");
                        item.SubItems.Add(($"{ property.Value}"));

                        MetadataBox.Items.Add(item);
                    }

                    IDocumentInfo info = metadata.GetDocumentInfo();
                    MessageBox.Show("File format: " + info.FileType.FileFormat);
                    MessageBox.Show("File extension: " + info.FileType.Extension);
                    MessageBox.Show("MIME Type: " + info.FileType.MimeType);
                    MessageBox.Show("Number of pages: " + info.PageCount);
                    MessageBox.Show("Document size: " + info.Size);
                    MessageBox.Show("Is document encrypted: " + info.IsEncrypted);
                }
            }
         */
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            /*CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected: " + dialog.FileName);
            }*/
            //MessageBox.Show("XXXX\nYYYY\nZZZZ");
        }

        private void ToolStripButton1_Click_1(object sender, EventArgs e)
        {
            Kakapylytoimi();
        }
        //FolderBrowserDialog folderPicker = new FolderBrowserDialog();

        private void Kakapylytoimi() {
        CommonOpenFileDialog dialog = new CommonOpenFileDialog();
        //dialog.InitialDirectory = "C:\\Users";
        dialog.IsFolderPicker = true;
        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
        intti = -1;
        valittukansio2 = dialog.FileName;
        ChosenFolder.Text = dialog.FileName;

        FileBox.Items.Clear();

        string[] files = Directory.GetFiles(dialog.FileName);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            ListViewItem item = new ListViewItem(fileName);

            if (file.Contains(".jpg") || file.Contains(".png") || file.Contains(".gif")) { 
            item.Tag = file;

            FileBox.Items.Add(item);  
            }
        }

            }
            if (FileBox.SelectedItems.Count > 0)
            {

                ListViewItem selected = FileBox.SelectedItems[0];
                string selectedFilePath = selected.Tag.ToString();

                //PlayYourFile(selectedFilePath);

            }
            else
            {
                // Show a message
            }

            numericUpDown1.Value = FileBox.Items.Count;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            audioMTDT form = new audioMTDT();
            form.Show();
            imageMTDT form2 = new imageMTDT();
            form2.Close();
        }
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            MessageBox.Show("aa");
            //more processing
        }
    }
}