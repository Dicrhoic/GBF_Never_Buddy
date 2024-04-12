using GBF_Never_Buddy.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBF_Never_Buddy.Forms
{
    public partial class GuildWar : Form
    {
        public GuildWar()
        {
            InitializeComponent();
        }

        private void LoadCalculator(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            GWCalculator gWCalculator = new GWCalculator();
            panel1.Controls.Add(gWCalculator);
        }

        private void honourRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
