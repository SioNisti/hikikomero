using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Directory = System.IO.Directory;
using Microsoft.WindowsAPICodePack.Dialogs;
using ExifLibrary;
using System.ComponentModel;
using System.Diagnostics;
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
                            System.Threading.Thread.Sleep(1000);
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

                    System.Threading.Thread.Sleep(100);
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
            string[] Xtags2 = text.Split(';');

            int count = Xtags2.Length - 1;
            int tloop = 0;
            var b = 1;

            //MessageBox.Show("vittu haloo\n"+b);
            while (b == 1)
            {
                if (count > 1)
                {
                    var tagi = Xtags2[1];
                    var tagi2 = tagi + ";";
                    if (tagi2 == ";")
                    {
                        return;
                    }
                }
                //MessageBox.Show(tagi2+"\n"+count+"\n"+tloop);


                //MessageBox.Show($"tagsi{1}" + $"tagsi{1}");
                //ota kaikki kuvat jotka sisältää tägin1 ja lisää listalle.  kun kaikki kuvat on lisätty mene listan kuvat läpi katsoen onko niissä tägi2,3,4,5,6 jne ja poista listalta jos ei ole???
                //vittu kun aivot sulああああああああああああ
                //käy kuvat läpi yksikerrallaan,  jos kuva sisältää tägin yksi kokeile sisältääkö se tägin 1,2,3,4 jne jos joo, lisää listalle, jos ei niin ohita ja mene seuraavaan kuvaan <- jos toimii niin ehkä nopeampi

                string[] files = Directory.GetFiles(valittukansio2);

                //MessageBox.Show("mitä vittua");

                foreach (string file in files)
                {
                    //MessageBox.Show("vittu pääseekö se mihinkään");
                    string fileName = Path.GetFileName(file);
                    ListViewItem item = new ListViewItem(fileName);


                    if (file.Contains(".jpg"))
                    {
                    var gottenTags = ImageFile.FromFile(file).Properties.Get(ExifTag.WindowsKeywords);
                    if (gottenTags != null) {  
                    string gottenTags2 = gottenTags.ToString();

                        //var file5 = ImageFile.FromFile(file); 

                        //MessageBox.Show(gottenTags2);
                        if (gottenTags != null)
                        {
//tää saatanan paska koodin pätkä toimmii mutta se ärsyttää iha vitusteen koska tämä on mahollisesti pirun hidas jos kuvia on vähänkään enemmän
//tää vitun paska lyhyt perkele kattoo joka kuvasta joka valitun tägin sen sijasta että se lopettaisi edes yrittämisen jos yksikään tägi ei löydy
//perkele kun käytin joku 10 vitullista tuntia tonne alempaan pois kommentoituun kohtaan koska se periaate oli hyvä mutta en vaan saanut toimimaan
//enemmällä kuin kahdella tägillä vittu perkele saatana kirosana jumalauta >>>>>>>>>>::::::::(((((((((((((((
//tl:dr vituttaa paska koodi

// JOOOOOOO Just parasta jeebou juuh eliikkääs "break;" tonne else:n sisälle korjas ongelman :DDD olo vitun tyhmä
                            tloop = 0;

                            foreach (var tagÅ in Xtags2)
                                {
                                    if (gottenTags2.Contains(tagÅ))
                                    {
                                        tloop++;
                                        Debug.WriteLine(file + "\n\n" + tagÅ + "\n\n" + gottenTags2 + "\n\n" + tloop + "/" + count);
                                        if (tloop > count)
                                        {
                                        tloop = 0;
                                        item.Tag = file;
                                        FileBox.Items.Add(item);
                                        Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                                        }
                                        b--;//tää estää sen ettei se jää loputtomaan looppiin jumihin
                                    }
                                    else
                                    {
                                        tloop = 0;
                                        Debug.WriteLine(file + "\nXXX\n" + tagÅ + "\n\n" + gottenTags2 + "\n\n" + tloop + "/" + count);
                                        break;
                                    }
                                }
                                Debug.WriteLine("--------------------------------------------------------------");


                                /*
                                //MessageBox.Show(ota + "\n=?\n" + text);
                                //MessageBox.Show($"{Xtags2[0]}");
                                if (gottenTags2.Contains($"{Xtags2[tloop]}"))
                                {
                                    Debug.WriteLine(file + "\n" + gottenTags2 + "\n\n\n\n" + $"{Xtags2[tloop]}" + "{Xtags2[0]}\n\n\n\nTAG" + tloop + " OLI");
                                    tloop++;
                                    //MessageBox.Show("vittu");
                                    //MessageBox.Show(file + "\n" + gottenTags2 + "\n\ncontains\n\n" + tagi2 + "\n\n" + tloop);
                                        if (count > 1)
                                        {
                                        //MessageBox.Show("saatana");
                                        if (tloop <= count)
                                        {
                                            //MessageBox.Show($"{Xtags2[tloop]}");
                                            if (gottenTags2.Contains($"{Xtags2[tloop]}"))
                                            {
                                                Debug.WriteLine(file + "\n" + gottenTags2 + "\n\n\n\n" + $"{Xtags2[tloop]}" + "{Xtags2[tloop]}\n\n\n\nTAG" + tloop + " OLI"+count);
                                                //MessageBox.Show(file + "\n" + gottenTags2 + "\n\ncontains\n\n" + $"{Xtags2[tloop]}" + "\n\n"+tloop);
                                                //
                                                if(tloop == count)
                                                    {
                                                        if (!FileBox.Items.Contains(item))
                                                        {
                                                            item.Tag = file;
                                                            FileBox.Items.Add(item);
                                                            Debug.WriteLine(file + "\nAdded");
                                                            tloop = 0;
                                                            b--;
                                                            Debug.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                                                        }
                                                        if (tloop == count - 1)
                                                        {
                                                        }
                                                        else
                                                        {
                                                            tloop++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        tloop++;
                                                    }
                                            }
                                            else
                                                {
                                                    Debug.WriteLine(file + "\n" + gottenTags2 + "\n\n\n\n" + $"{Xtags2[tloop]}" + "{Xtags2[tloop]}\n\n\n\nTAG" + tloop + " EI OLLUT"); 
                                                    tloop = 0;
                                                    //b--;
                                                    Debug.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                                                }
                                        }
                                        else
                                        {
                                            Debug.WriteLine(tloop + "<=" + count);
                                            item.Tag = file;

                                            if (!FileBox.Items.Contains(item))
                                            {
                                                FileBox.Items.Add(item);
                                                b--;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.WriteLine("tägejä on yksi");
                                        item.Tag = file;
                                        //MessageBox.Show("perkele");
                                        if (!FileBox.Items.Contains(item))
                                        {
                                            FileBox.Items.Add(item);
                                            b--;
                                        }
                                    }
                                }

                            */
                            }
                    }
                }
                intti = -3;
                numericUpDown1.Value = FileBox.Items.Count;
                }
            }

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