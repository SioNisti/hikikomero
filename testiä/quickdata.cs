using System;
using System.Windows.Forms;

namespace testiä
{
    public partial class quickdata : Form
    {
        public quickdata()
        {
            InitializeComponent();
        }

        public static bool qdon = true;

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
        }

        private void qdclosing(object sender, FormClosingEventArgs e)
        {
            qdon = false;
        }
    }
}
