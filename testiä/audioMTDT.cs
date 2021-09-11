using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testiä
{
    public partial class audioMTDT : Form
    {
        public audioMTDT()
        {
            InitializeComponent();
        }
        public string valittukansio2;
        public string valittukuva;
        public string valittukuva2;
        int intti = -1;

        private void audioMTDT_Load(object sender, EventArgs e)
        {

        }

        private void audioMTDT_Load_1(object sender, EventArgs e)
        {

        }

        private void MetadataBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DirectoryBtn_Click(object sender, EventArgs e)
        {
            Kakapylytoimi();
        }
        private void Kakapylytoimi()
        {
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

                    if (file.Contains(".mp3") || file.Contains(".wav"))
                    {
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
    }
}
