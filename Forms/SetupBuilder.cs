using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GBF_Never_Buddy.Forms
{
    public partial class SetupBuilder : Form
    {
        string image = "";
        public SetupBuilder()
        {
            InitializeComponent();
        }

        private void Upload(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Choose Image(*.jpg;*.png;*.jpeg;) | *.jpg;*.png;*.jpeg;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //pb_photo.Image = Image.FromFile(dialog.FileName);
                image = dialog.FileName;
            }
            else
            {
                //pb_photo.Image = null;
                image = "";
            }
        }
    }
}
