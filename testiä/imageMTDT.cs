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
*"kuulemma" on aika X sana tähän.  muunmuassa nää joskus vanhassa koodissa käytetyt library:t vei 300mb tilaa turhaan
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
        int curtab = 0;

        private void imageMTDT_Load(object sender, EventArgs e)
        {
            prevbtn.Enabled = false;
            nxtbtn.Enabled = false;
            TagSearch.Enabled = false;
            currentimage.Enabled = false;
        }
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
        private void Button1_Click(object sender, EventArgs e)
        {
            if (valittukansio2 == null || valittukansio2 == "")
            {
                prevbtn.Enabled = false;
                nxtbtn.Enabled = false;
                TagSearch.Enabled = false;
                currentimage.Enabled = false;
            } else
            {
                prevbtn.Enabled = true;
                nxtbtn.Enabled = true;
                TagSearch.Enabled = true;
                currentimage.Enabled = true;

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

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (valittukansio2 == null || valittukansio2 == "")
            {
                prevbtn.Enabled = false;
                nxtbtn.Enabled = false;
                TagSearch.Enabled = false;
                currentimage.Enabled = false;
            }
            else
            {
                prevbtn.Enabled = true;
                nxtbtn.Enabled = true;
                TagSearch.Enabled = true;
                currentimage.Enabled = true;

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

        private void PictureBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (valittukansio2 == null || valittukansio2 == "")
            {
                prevbtn.Enabled = false;
                nxtbtn.Enabled = false;
                TagSearch.Enabled = false;
                currentimage.Enabled = false;
            }
            else
            {
                prevbtn.Enabled = true;
                nxtbtn.Enabled = true;
                TagSearch.Enabled = true;
                currentimage.Enabled = true;

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
            /*
            descriptionMTDT.Rows.Clear();

            var file = ImageFile.FromFile(valittukuva);
            foreach (var property in file.Properties)
            {
                descriptionMTDT.Rows.Add($"{property.Name}", $"{property.Value}");
            }*/

            //saatanan vittumainen bugi ton datagridview:in kanssa
            //se paska kaatuu jos oot muokkaamassa jotain solua ja klikkaat toiseen soluun

            //descriptionMTDT.CurrentCell = null;voi perkele
            descriptionMTDT.ClearSelection();
            descriptionMTDT.Rows.Clear();
            
            var file = ImageFile.FromFile(valittukuva);
            if (curtab == 0)
            {
                descriptionMTDT.Rows.Add("Title", file.Properties.Get(ExifTag.WindowsTitle), 140091);
                descriptionMTDT.Rows.Add("Subject", file.Properties.Get(ExifTag.WindowsSubject), 140095);
                descriptionMTDT.Rows.Add("Rating", file.Properties.Get(ExifTag.Rating), 118246);
                descriptionMTDT.Rows.Add("Tags", file.Properties.Get(ExifTag.WindowsKeywords), 140094);
                descriptionMTDT.Rows.Add("Comments", file.Properties.Get(ExifTag.WindowsComment), 140092);
            }
            if (curtab == 1)
            {
                descriptionMTDT.Rows.Add("Authors", file.Properties.Get(ExifTag.WindowsAuthor), 140093);
                descriptionMTDT.Rows.Add("Date taken", file.Properties.Get(ExifTag.DateTimeOriginal), 236867);
                descriptionMTDT.Rows.Add("Date acquired", file.Properties.Get(ExifTag.SubSecTime), 237520);
                descriptionMTDT.Rows.Add("Copyright", file.Properties.Get(ExifTag.Copyright), 133432);
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
                MessageBox.Show("No JPG images were found in the path \"" + valittukansio2 + "\"", "No JPGs");
            } else
            {
                intti = 0;
                imageamount.Value = FileBox.Items.Count;
                currentimage.Value = intti;

                prevbtn.Enabled = true;
                nxtbtn.Enabled = true;
                TagSearch.Enabled = true;
                currentimage.Enabled = true;
            }
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
            else if (text == "notag")
            {
                string[] files = Directory.GetFiles(valittukansio2);
                foreach (string file in files)
                {
                    if (file.Contains(".jpg"))
                    {
                        string fileName = Path.GetFileName(file);
                        ListViewItem item = new ListViewItem(fileName);
                        var imagetags = ImageFile.FromFile(file).Properties.Get(ExifTag.WindowsKeywords);
                        string imagetags2 = "";
                        if (imagetags != null)
                        {
                            imagetags2 = imagetags.ToString();
                        }

                        if (file.Contains(".jpg") && imagetags == null || imagetags2 == "")
                        {
                            item.Tag = file;
                            FileBox.Items.Add(item);
                            Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                            Debug.WriteLine("--------------------------------------------------------------");
                        }
                    }
                }
                intti = 1;
                imageamount.Value = FileBox.Items.Count;
            }
            else if (text != "notag" && text != "")
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
                    MessageBox.Show("No images were found with the tags \"" + text + "\"", "No found images");
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
                            if (gottenTags != null && gottenTags.ToString() != "") //huh saatana piti lisätä toi toinen ehto tohon koska muuten jos jollain oli täginä "" niin se paska kaatu
                            {
                                string gottenTags2 = gottenTags.ToString();
                                char gt2 = gottenTags2[0];

                                if (gottenTags2[0].Equals(';'))
                                {
                                    //gottenTags2 = gottenTags2; varoitukset pois
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
                MessageBox.Show("No images were found with the tags \"" + text + "\"", "No found images");
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

        private void descriptionMTDT_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*string vittu = descriptionMTDT.CurrentCell.RowIndex.ToString();
            string perkele = descriptionMTDT.Rows[descriptionMTDT.CurrentCell.RowIndex].Cells[1].Value.ToString();
            MessageBox.Show(vittu+"\n\n"+perkele);*/

            int x = 0;
            string celldata;
            var exiftype = descriptionMTDT.Rows[x].Cells[2].Value;
                Unohdakuva();
                var file = ImageFile.FromFile(valittukuva);
                foreach (DataGridViewRow row in descriptionMTDT.Rows)
                {
                    if (descriptionMTDT.Rows[x].Cells[1].Value == null)
                    {
                        celldata = "";
                        Debug.WriteLine("kivesneste");
                    }
                    else
                    {
                        celldata = descriptionMTDT.Rows[x].Cells[1].Value.ToString();
                    }
                    Debug.WriteLine(celldata);
                    exiftype = descriptionMTDT.Rows[x].Cells[2].Value;

                //VITTUUUU MITEN SAAN TÄN TOIMIMAaN ILMAAN KAHEKSAA SATAA IF LAUSETTA PERKELEEN C# KUN SE EI OLE PHP JOSSA TÄTÄ ONGELMAA EI OLISI PERKELE

                /*string stringit = "ExifTag." + exiftype;
                ExifLibrary.ExifTag stringit2 = "ExifTag." + exiftype;
                //ExifLibrary.ExifTag stringit = "ExifTag."+exiftype;

                file.Properties.Set(stringit2, celldata);*/

                //tällästä if lause sotkua tulee kun C# on tyhmä kieli. saisin tän muunmuassa nyt just valmiiksi mutten suostu täyttää mun jo paskaa koodia if lauseilla
                //noita perkeleitähän tulee yhteensä noin 26. pelkkä ajatus 26 if lauseesta miltein peräkkäin saa mut kääntymään satanismiin
                /*
                if (x == 0)
                {
                    file.Properties.Set(ExifTag.WindowsTitle, celldata);
                }
                else if (x == 1)
                {
                    file.Properties.Set(ExifTag.WindowsSubject, celldata);
                }
                else if (x == 2)
                {
                    file.Properties.Set(ExifTag.Rating, celldata);
                }
                else if (x == 3)
                {
                    file.Properties.Set(ExifTag.WindowsKeywords, celldata);
                }
                else if (x == 4)
                {
                    file.Properties.Set(ExifTag.WindowsComment, celldata);
                }*/

                //EI KIISSELISET MEISSELIT SENTÄÄN SE TOIMII! EIKÄ SIINÄ OLE KUIN YKSI IF LAUSE JEE BOING JIHUU
                //ongelman ratkaisi kun olin kirjottanut "exiftag.windows" niin siinä oli tullu se teksti-boksi jossa näky joku numero minkä oletin olevan sama juttu kuin se nimi mutta numerona (yllätys)
                //jees saatana

                //if (curtab == 0)
                //{
                    Debug.WriteLine("KIISSELI");
                    if ((bool)(descriptionMTDT.Rows[x].Cells[2].Value == exiftype))
                    {
                        file.Properties.Set((ExifTag)exiftype, celldata);
                        Debug.WriteLine("\n" + exiftype + " / " + celldata + "\nMEISSELI");
                    if ((int)exiftype == 236867)
                    {
                        DateTime myDate = DateTime.ParseExact(celldata, "yyyy.MM.dd HH.mm.ss",System.Globalization.CultureInfo.InvariantCulture);

                        file.Properties.Set((ExifTag)exiftype, myDate);
                        // x = x;  huom tän virka on olla ns "breakpoint":ina kun tuo vittuilee nytten
                        //tää on aika paskaa koodia mutta jotenkin on tarkistettava ollaanko muuttamassa tota datetimeoriginal höskää koska se celldata pitää muuttaa datetimeksi
                    }
                }
                //}


                x++;
            }
            Unohdakuva();
            file.Save(valittukansio2 + "/" + valittukuva2);
            PictureBox.Image = Image.FromFile(@valittukuva);
            Metat();
            Debug.WriteLine("------------------------------------------------------------------");
        }

        private void tab_description_Click(object sender, EventArgs e)
        {
            curtab = 0;
            Metat();
        }

        private void tab_origin_Click(object sender, EventArgs e)
        {
            curtab = 1;
            Metat();
        }

        private void descriptionMTDT_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            descriptionMTDT.ClearSelection();

        }
    }
}