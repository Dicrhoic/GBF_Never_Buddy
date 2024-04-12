using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBF_Never_Buddy.Screens
{
    public partial class RaidRow : UserControl
    {
        public object r;
        public RaidRow(NM90 raid)
        {
            r = raid;
            InitializeComponent();
            title.Text = raid.name;

            honoursYield.Value = raid.honours;
        }

        public RaidRow(NM95 raid)
        {
            InitializeComponent();
            r = raid;
            title.Text = raid.name;

            honoursYield.Value = raid.honours;
        }

        public RaidRow(NM100 raid)
        {
            InitializeComponent();
            r = raid;
            title.Text = raid.name;

            honoursYield.Value = raid.honours;
        }

        public RaidRow(NM150 raid)
        {
            InitializeComponent();
            r = raid;
            title.Text = raid.name;

            honoursYield.Value = raid.honours;
        }

        public RaidRow(NM200 raid)
        {
            InitializeComponent();
            r = raid;
            title.Text = raid.name;
            meatCost.Value = raid.cost;
            honoursYield.Value = raid.honours;
        }

        public List<double> getTimes()
        {
            double wt = Decimal.ToDouble(worst.Value);
            double bt = Decimal.ToDouble(best.Value);
            return new List<double>() { wt, bt };
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {

        }

        private void worst_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
