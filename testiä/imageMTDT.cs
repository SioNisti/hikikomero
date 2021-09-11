using ExifLibrary;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Directory = System.IO.Directory;
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
        int intti = 0;

        public void Unohdakuva()
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
                    Unohdakuva();
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
                            Unohdakuva();
                            oldtags2 = oldtags2.Replace(ota, "");
                            file.Properties.Set(ExifTag.WindowsKeywords, oldtags2);
                            file.Save(valittukansio2 + "/" + valittukuva2);
                            PictureBox.Image = Image.FromFile(@valittukuva);
                            MessageBox.Show("Successfully removed tag: " + ota, "Success");
                            Metat();
                        }
                        else
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
                if (Path.GetExtension(valittukuva2) == ".jpg")
                {

                    Unohdakuva();
                    var file2 = ImageFile.FromFile(valittukuva);

                    var oldtags = file2.Properties.Get(ExifTag.WindowsKeywords);

                    string tagstoadd = TagGiver.Text;
                    //MessageBox.Show("perkeleen saatanan vittu \"kirjasto\" library on paska helvetti ja kokoversio maksaa ja trial versiossa ei pysty tallentamaan niitä vitun tiedostoja.  mä vittu tunnin yritin miettiä miksi se heittää erroria joka loppujen lopuksi olikin \"haista vittu, köyhät kyykkyyn\" viesti boksi error lootan vaatteissa perkele");
                    var file = ImageFile.FromFile(valittukuva);

                    if (tagstoadd.EndsWith(";"))
                    {
                        file.Properties.Set(ExifTag.WindowsKeywords, oldtags + tagstoadd);
                    }
                    else
                    {
                        file.Properties.Set(ExifTag.WindowsKeywords, oldtags + tagstoadd + ";");
                    }
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
            Unohdakuva();
            intti--;

            FileBox.Items[0].Selected = true;

            imageamount.Value = FileBox.Items.Count;
            currentimage.Value = intti;

            if (intti < 1)
            {
                intti = FileBox.Items.Count;
            }

            if (FileBox.Items.Count == 1)
            {
                currentimage.Value = 1;
            } else
            {
                currentimage.Value = intti;
            }

            gsImages();
            Debug.WriteLine(intti);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // seuraava kuva
            Unohdakuva();

            intti++;

            FileBox.Items[0].Selected = true;

            if (intti == FileBox.Items.Count + 1)
            {
                intti = 1;
            }

            imageamount.Value = FileBox.Items.Count;
            currentimage.Value = intti;

            if (FileBox.Items.Count == 1)
            {
                currentimage.Value = 1;
                gsImages();
            }
            gsImages();
            Debug.WriteLine(intti);
        }

        private void PictureBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.B)
                {
                    //edellinen kuva
                    Unohdakuva();
                    intti--;

                    FileBox.Items[0].Selected = true;

                    imageamount.Value = FileBox.Items.Count;
                    currentimage.Value = intti;

                    if (intti < 1)
                    {
                        intti = FileBox.Items.Count;
                    }

                    if (FileBox.Items.Count == 1)
                    {
                        currentimage.Value = 1;
                    }
                    else
                    {
                        currentimage.Value = intti;
                    }

                    gsImages();
                    Debug.WriteLine(intti);
                }
            }
            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=net-5.0
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.N)
                {
                    // seuraava kuva
                    Unohdakuva();

                    intti++;

                    FileBox.Items[0].Selected = true;

                    if (intti == FileBox.Items.Count + 1)
                    {
                        intti = 1;
                    }

                    imageamount.Value = FileBox.Items.Count;
                    currentimage.Value = intti;

                    if (FileBox.Items.Count == 1)
                    {
                        currentimage.Value = 1;
                        gsImages();
                    }
                    gsImages();
                    Debug.WriteLine(intti);
                }
            }
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.KeyCode == Keys.D)
                {
                    Kakapylytoimi();
                }
            }
        }

        public void Metat()
        {
            //tää siis ottaa valitusta kuvasta kaikki löytyvät metadatat ja asettaa ne siihen listview:iin

            dataGridView1.Rows.Clear();

            var file = ImageFile.FromFile(valittukuva);
            foreach (var property in file.Properties)
            {
                dataGridView1.Rows.Add($"{property.Name}", $"{property.Value}");
            }
        }

        private void ToolStripButton1_Click_1(object sender, EventArgs e)
        {
            Kakapylytoimi();
        }

        private void Kakapylytoimi()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            //dialog.InitialDirectory = "C:\\Users"; tällä sais valittua alotus kansion mutta jos se ei ole määritelty niin se alottaa siitä mihin jäit
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                valittukansio2 = dialog.FileName;
                ChosenFolder.Text = dialog.FileName;

                FileBox.Items.Clear();

                string[] files = Directory.GetFiles(dialog.FileName);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    ListViewItem item = new ListViewItem(fileName);

                    if (file.Contains(".jpg"))
                    {
                        item.Tag = file;

                        FileBox.Items.Add(item);
                    }
                }

            }
            if (FileBox.Items.Count == 0)
            {
                MessageBox.Show("No images were found in the path \"" + valittukansio2 + "\"");
            } else
            {
                intti = 0;
                imageamount.Value = FileBox.Items.Count;
                currentimage.Value = intti;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            audioMTDT form = new audioMTDT();
            form.Show();
            imageMTDT form2 = new imageMTDT();
            form2.Close();
        }

        private void currentimage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int bintti = intti;
                int value2 = Convert.ToInt32(currentimage.Value);
                intti = value2;
                if (intti < 0)
                {
                    MessageBox.Show("Value must be positive");
                    intti = bintti;
                    currentimage.Value = bintti;
                }
                else
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
            //nyt pitäis jotenkin saada jokaikinen tägi tonne alempaan if lauseeseen että se kattoo onko tiedoston metadatasa nää tägit (text)
            FileBox.Items.Clear();

            //en tiä miksi fixedtext string:in pois ottaminen ja kaikki missä sitä käytettiin vaihtaminen text string:iin toimii
            if (text == "")
            {
                string[] files = Directory.GetFiles(valittukansio2);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    ListViewItem item = new ListViewItem(fileName);

                    if (file.Contains(".jpg"))
                    {
                        item.Tag = file;

                        FileBox.Items.Add(item);

                    }
                }
            }
            else
            {
            if (text[0].Equals(';'))
            {
                Debug.WriteLine(text);
                text = text.Remove(0, 1);
                Debug.WriteLine(text);
            }

            char lastchar = text.Last();

            if (lastchar.Equals(';'))
            {
                Debug.WriteLine(text);
                text = text.Remove(text.Length - 1);
                Debug.WriteLine(text);
            }

            string[] Xtags2 = text.Split(';');

            int count = Xtags2.Length - 1;
            int tloop;
            int sloop = 0;
            var b = 1;

            //MessageBox.Show("vittu haloo\n"+b);
            while (b == 1)
            {
                //MessageBox.Show($"tagsi{1}" + $"tagsi{1}");
                //ota kaikki kuvat jotka sisältää tägin1 ja lisää listalle.  kun kaikki kuvat on lisätty mene listan kuvat läpi katsoen onko niissä tägi2,3,4,5,6 jne ja poista listalta jos ei ole???
                //vittu kun aivot sulああああああああああああ
                //käy kuvat läpi yksikerrallaan,  jos kuva sisältää tägin yksi kokeile sisältääkö se tägin 1,2,3,4 jne jos joo, lisää listalle, jos ei niin ohita ja mene seuraavaan kuvaan <- jos toimii niin ehkä nopeampi

                string[] files = Directory.GetFiles(valittukansio2);
                int fcount = files.Length;
                //MessageBox.Show("mitä vittua");

                if (sloop >= fcount - 1)
                {
                    MessageBox.Show("No images were found with the tags \"" + text + "\"");
                    b--;
                    break;
                }
                else
                {
                    foreach (string file in files)
                    {
                        //MessageBox.Show("vittu pääseekö se mihinkään");
                        string fileName = Path.GetFileName(file);
                        ListViewItem item = new ListViewItem(fileName);


                        if (file.Contains(".jpg"))
                        {
                            var gottenTags = ImageFile.FromFile(file).Properties.Get(ExifTag.WindowsKeywords);
                            if (gottenTags != null)
                            {
                                string gottenTags2 = gottenTags.ToString();
                                char gt2 = gottenTags2[0];

                                if (gottenTags2[0].Equals(';'))
                                {
                                    gottenTags2 = gottenTags2;
                                } else
                                {
                                    gottenTags2 = ";"+gottenTags2;
                                }
                                //tää saatanan paska koodin pätkä toimmii mutta se ärsyttää iha vitusteen koska tämä on mahollisesti pirun hidas jos kuvia on vähänkään enemmän
                                //tää vitun paska lyhyt perkele kattoo joka kuvasta joka valitun tägin sen sijasta että se lopettaisi edes yrittämisen jos yksikään tägi ei löydy
                                //perkele kun käytin joku 10 vitullista tuntia tonne alempaan pois kommentoituun kohtaan koska se periaate oli hyvä mutta en vaan saanut toimimaan
                                //enemmällä kuin kahdella tägillä vittu perkele saatana kirosana jumalauta >>>>>>>>>>::::::::(((((((((((((((
                                //tl:dr vituttaa paska koodi

                                // JOOOOOOO Just parasta jeebou juuh eliikkääs "break;" tonne else:n sisälle korjas ongelman :DDD olo vitun tyhmä
                                tloop = 0;

                                foreach (var tagÅ in Xtags2)
                                {
                                    if (gottenTags2.Contains(";" + tagÅ + ";"))
                                    {
                                        tloop++;
                                        Debug.WriteLine(file + "\n\n" + ";" + tagÅ + ";" + "\n\n" + gottenTags2 + "\n"+ TagSearch.Text +"\n" + tloop + "/" + count);
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

                                        if (tloop == 0)
                                        {
                                            sloop++;
                                        }
                                        else
                                        {
                                            sloop = sloop + tloop;
                                        }
                                        tloop = 0;
                                        Debug.WriteLine(file + "\nXXX\n" + ";" + tagÅ + ";" + "\n\n" + gottenTags2 + "\n" + TagSearch.Text + "\n" + tloop + "/" + count + "(" + sloop + ")");
                                        break;
                                    }
                                }
                                Debug.WriteLine("--------------------------------------------------------------");
                            }
                            else
                            {
                                Debug.WriteLine(file + "\nYYYYY no tags\n(" + sloop + ")\n--------------------------------------------------------------");
                                sloop++;
                            }
                        }
                        intti = 1;
                        imageamount.Value = FileBox.Items.Count;
                    }
                }
            }
            if (FileBox.Items.Count == 0)
            {
                MessageBox.Show("No images were found with the tags \"" + text + "\"");
            }
            }

        }
        public void gsImages()
        {
            if (intti > FileBox.Items.Count)
            {
                intti = 1;
            }
            if (intti <= 0)
            {
                intti = FileBox.Items.Count;
            }
            ListViewItem item = FileBox.Items[intti - 1];
            valittukuva = valittukansio2 + "/" + item.SubItems[0].Text;
            valittukuva2 = item.SubItems[0].Text;

            CurrentFile.Text = valittukuva2;
            Metat();
            PictureBox.Image = Image.FromFile(@valittukuva);
        }

        private void dragfolder(object sender, DragEventArgs e)
        {
            //huom: ei toimi koska se ei syystä tuntemattomasta huoli sitä kansiota
            Kakapylytoimi();
        }
    }
}