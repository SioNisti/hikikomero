using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testiä
{
    public partial class quickdata : Form
    {
        public quickdata()
        {
            InitializeComponent();
        }
        public void quickdata_Load(object sender, EventArgs e)
        {
            label1.Text = imageMTDT.quickdata_name;
            textBox1.Text = imageMTDT.quickdata_data;
            //getdata();
        }
        public void getdata()
        {
            label1.Text = imageMTDT.quickdata_name;
            textBox1.Text = imageMTDT.quickdata_data;
        }
    }
}
