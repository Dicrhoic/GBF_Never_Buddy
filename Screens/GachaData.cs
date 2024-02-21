using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBF_Never_Buddy.Screens
{
    public partial class GachaData : UserControl
    {
        public GachaData()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void UpdateCaption(string caption)
        {
            label1.Text = caption;  
        }

        public void InsertImage(PictureBox pb)
        {
            flowLayoutPanel1.Controls.Add(pb);
            Debug.WriteLine("Added pb");
        }
        
        private void GachaData_Load(object sender, EventArgs e)
        {

        }
    }
}
