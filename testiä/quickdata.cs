using System;
using System.Drawing;
using System.Windows.Forms;

namespace testiä
{
    public partial class quickdata : Form
    {
        public quickdata()
        {
            InitializeComponent();
        }

        public imageMTDT f1;
        public object PictureBox { get; private set; }

        public static string qdedited;
        public static string qdkuva;
        public static string qdkansio;
        public static string qdkuva2;

        public void quickdata_Load(object sender, EventArgs e)
        {
            //label1.Text = imageMTDT.quickdata_name;
            //textBox1.Text = imageMTDT.quickdata_data;
            getdata();
        }
        public void getdata()
        {
            label1.Text = imageMTDT.quickdata_name;
            textBox1.Text = imageMTDT.quickdata_data;
            qdkuva = imageMTDT.valittukuva;
            qdkansio = imageMTDT.valittukansio2;
            qdkuva2 = imageMTDT.valittukuva2;
        }

        private void qdclosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                qdedited = textBox1.Text;
                imageMTDT i = new imageMTDT();
                i.Unohdakuva();
                i.updatemtdt();
            }
        }
        public void alzheimer()
        {
            //tää koodin pätkä ottaa sen käytössä olevan kuvan pois pictureboxista jotta sen voi tiedoston päälle voi tallentaa
            /*var bit = new Bitmap(this.Width, this.Height);
            var g = Graphics.FromImage(bit);

            var oldImage = f1.PictureBox.Image;
            f1.PictureBox.Image = bit;
            oldImage?.Dispose();

            g.Dispose();*/
        }
    }
}
