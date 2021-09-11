using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Directory = System.IO.Directory;
using Microsoft.WindowsAPICodePack.Dialogs;
using ExifLibrary;
using System.ComponentModel;
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
        int intti = -3;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void unohdakuva()
        {
            //tää koodin pätkä ottaa sen käytössä olevan kuvan pois pictureboxista jotta sen voi tiedoston päälle voi tallentaa
            var bit = new Bitmap(this.Width, this.Height);
            var g = Graphics.FromImage(bit);

            var oldImage = PictureBox.Image;
            PictureBox.Image = bit;
            oldImage?.Dispose();

            g.Dispose();
        }

        private void TagTaker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                /*Tiedostot jotka tukee tagejä: 
                 * jpg, 
                 * mp4, m4v, wmv, mkv
                 * 
                 * äänitiedostot ei tue tagejä mutta niille voi antaa esim: artistin, genren, titlen ja sun muuta
                 */


                if (Path.GetExtension(valittukuva2) == ".jpg")
                {
                    unohdakuva();
                    var file2 = ImageFile.FromFile(valittukuva);

                    var oldtags = file2.Properties.Get(ExifTag.WindowsKeywords);
                    string oldtags2 = Convert.ToString(oldtags);

                    string tagstotake = TagTaker.Text;

                    var file = ImageFile.FromFile(valittukuva);

                    string[] Xtags = tagstotake.Split(';');
                    foreach (var Xtag in Xtags)
                    {
                        //tää niinkut ottaa sen tekstin siitä boksista ja ottaa tekstit ";" merkkien välistä
                        var ota = $"{Xtag};";

                        if (ota == ";")
                        {
                            PictureBox.Image = Image.FromFile(@valittukuva);
                            MessageBox.Show("Error", "Error");
                            return;
                        }
                        if (oldtags2.Contains(ota))
                        {
                            unohdakuva();
                            oldtags2 = oldtags2.Replace(ota, "");
                            //MessageBox.Show(oldtags2);
                            file.Properties.Set(ExifTag.WindowsKeywords, oldtags2);
                            file.Save(valittukansio2 + "/" + valittukuva2);
                            PictureBox.Image = Image.FromFile(@valittukuva);
                            MessageBox.Show("Successfully removed tag: " + ota, "Success");
                            Metat();
                        } else
                        {
                            PictureBox.Image = Image.FromFile(@valittukuva);
                            MessageBox.Show("Tag \"" + ota + "\" not found", "Error");
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Not a JPG file.", "Error");
                }

            }
        }
        private void TagGiver_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                /*Tiedostot jotka tukee tagejä: 
                 * jpg, 
                 * mp4, m4v, wmv, mkv
                 * 
                 * äänitiedostot ei tue tagejä mutta niille voi antaa esim: artistin, genren, titlen ja sun muuta
                 */


                if (Path.GetExtension(valittukuva2) == ".jpg")
                {

                    unohdakuva();
                    var file2 = ImageFile.FromFile(valittukuva);

                    var oldtags = file2.Properties.Get(ExifTag.WindowsKeywords);

                    string tagstoadd = TagGiver.Text;
                    //MessageBox.Show("perkeleen saatanan vittu \"kirjasto\" library on paska helvetti ja kokoversio maksaa ja trial versiossa ei pysty tallentamaan niitä vitun tiedostoja.  mä vittu tunnin yritin miettiä miksi se heittää erroria joka loppujen lopuksi olikin \"haista vittu, köyhät kyykkyyn\" viesti boksi error lootan vaatteissa perkele");

                    var file = ImageFile.FromFile(valittukuva);

                    if (tagstoadd.EndsWith(";"))
                    {
                        file.Properties.Set(ExifTag.WindowsKeywords, oldtags + tagstoadd);
                    } else
                    {
                        file.Properties.Set(ExifTag.WindowsKeywords, oldtags + tagstoadd + ";");
                    }

                    unohdakuva();
                    file.Save(valittukansio2 + "/" + valittukuva2);
                    PictureBox.Image = Image.FromFile(@valittukuva);
                    Metat();
                }
                else
                {
                    MessageBox.Show("Not a JPG file.", "Error");
                }

            }
        }

        private void TagAdder_Click(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //edellinen kuva
            unohdakuva();

            intti--;

            if (intti == -4) {
                intti = -1;
            }
            FileBox.Items[0].Selected = true;

            if (intti < 0)
            {
                intti = FileBox.Items.Count - 1;
            }

            /*if (FileBox.SelectedItems.Count == 0)
                return;*/
            numericUpDown2.Value = intti;
            numericUpDown1.Value = FileBox.Items.Count - 1;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // seuraava kuva
            unohdakuva();

            intti++;

            if (intti == -2)
            {
                intti = 0;
            }
            FileBox.Items[0].Selected = true;

            if (intti == FileBox.Items.Count)
            {
                intti = 0;
            }

            if (intti < 0)
            {
                intti = 0;
            }

            /*if (FileBox.SelectedItems.Count == 0)
                return;*/
            numericUpDown2.Value = intti;
            numericUpDown1.Value = FileBox.Items.Count - 1;
        }

        public void Metat()
        {
            //tää siis ottaa valitusta kuvasta kaikki löytyvät metadatat ja asettaa ne siihen listview:iin
            MetadataBox.Items.Clear();

            var file = ImageFile.FromFile(valittukuva);
            foreach (var property in file.Properties)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ($"{property.Name}");
                item.SubItems.Add(($"{ property.Value}"));

                MetadataBox.Items.Add(item);
            }
        }

        private void ToolStripButton1_Click_1(object sender, EventArgs e)
        {
            Kakapylytoimi();
        }

        private void Kakapylytoimi() {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            //dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //intti = -1;
                valittukansio2 = dialog.FileName;
                ChosenFolder.Text = dialog.FileName;

                FileBox.Items.Clear();

                string[] files = Directory.GetFiles(dialog.FileName);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    ListViewItem item = new ListViewItem(fileName);

                    if (file.Contains(".jpg")) { // || file.Contains(".png") || file.Contains(".gif")
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

            numericUpDown1.Value = FileBox.Items.Count - 1;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            audioMTDT form = new audioMTDT();
            form.Show();
            imageMTDT form2 = new imageMTDT();
            form2.Close();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (intti < 0)
            {
                intti = 0;
            }
            gsImages();
        }

        private void numericUpDown2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int bintti = intti;
                int value2 = Convert.ToInt32(numericUpDown2.Value);
                intti = value2;
                if (intti < 0)
                {
                    MessageBox.Show("Value must be positive");
                    intti = bintti;
                    numericUpDown2.Value = bintti;
                } else
                {
                    gsImages();
                }
            }
        }

        private void TagSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchwithtag(TagSearch.Text);
            }
        }
        public void searchwithtag(string text)
        {
            //MessageBox.Show(text);
            /*string[] Xtags = text.Split(';');
            foreach (var Xtag in Xtags)
            {
                //tää niinkut ottaa sen tekstin siitä boksista ja ottaa tekstit ";" merkkien välistä
                var ota = $"{Xtag};";

                if (ota == ";")
                {
                    PictureBox.Image = Image.FromFile(@valittukuva);
                    MessageBox.Show("Error", "Error");
                    return;
                }
                    unohdakuva();
            }*/

            //nyt pitäis jotenkin saada jokaikinen tägi tonne alempaan if lauseeseen että se kattoo onko tiedoston metadatasa nää tägit (text)

            FileBox.Items.Clear(); 

            string[] files = Directory.GetFiles(valittukansio2);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                ListViewItem item = new ListViewItem(fileName);

                if (file.Contains(".jpg"))
                {

                    var file5 = ImageFile.FromFile(file);
                    var gottenTags = file5.Properties.Get(ExifTag.WindowsKeywords);
                    
                    if (gottenTags != null) { 
                    string gottenTags2 = gottenTags.ToString();

                    string[] Xtags = gottenTags2.Split(';');

                    foreach (var Xtag in Xtags)
                    {
                        var ota = $"{Xtag};";
                            
                        //MessageBox.Show(ota + "\n=?\n" + text);
                    if (text == ota)
                    {
                        item.Tag = file;

                        if (!FileBox.Items.Contains(item))
                        {
                        FileBox.Items.Add(item);
                        }
                    }
                    }
                    }

                }
            }
            intti = -3;
            numericUpDown1.Value = FileBox.Items.Count;
        }
        public void gsImages()
        {
            ListViewItem item = FileBox.Items[intti];
            //MessageBox.Show(valittukuva);
            valittukuva = valittukansio2 + "/" + item.SubItems[0].Text;
            valittukuva2 = item.SubItems[0].Text;

            CurrentFile.Text = valittukuva2;
            Metat();
            //MessageBox.Show(valittukuva);
            PictureBox.Image = Image.FromFile(@valittukuva);
        }
    }
}