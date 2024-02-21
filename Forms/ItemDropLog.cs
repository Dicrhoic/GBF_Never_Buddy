using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.RaidClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static GBF_Never_Buddy.Classes.RaidClass.RaidHelper;

namespace GBF_Never_Buddy.Forms
{

    public partial class ItemDropLog : Form
    {
        
        RaidSQL raidInfo = new RaidSQL();
        List<RaidInfo> raids;
        private char option = '+';
        RaidInfo? currentRaid;
       
  

        public ItemDropLog()
        {
            InitializeComponent();
            raids = raidInfo.RaidList();
            comboBox1.DataSource = raids.Select(x => x.name).ToArray();
            comboBox1.SelectedIndexChanged += LoadRaidData;
            subRB.CheckedChanged += UpdateOption;
            addRB.Checked = true;
            label1.Text = "";
        }

        private void LoadRaidData(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            RaidInfo raid = raids[index];
            //raidImage.Load(raid.image);
            //raidImage.MouseClick += UpdateRaidAttempts;
             
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add("Open wiki link");
            menuStrip.Items[0].Click += LoadRaidPage;
            raidImage.ContextMenuStrip = menuStrip;
            SetRaid(raid);

        }

        private void SetRaid(RaidInfo raid)
        {
            Debug.WriteLine(raid.name);
            currentRaid = raid; 
            panel4.Controls.Clear();    
            raid.DisplayData(panel4);
            label1.Text = $"Attempts: {raid.attempts}";
            raid.LoadRaidImage();

        }
       

        private void LoadRaidPage(object? sender, EventArgs e)
        {
            if (currentRaid != null)
            {
                string url = currentRaid.link;
                System.Diagnostics.Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateOption(object sender, EventArgs e)
        {
            if (addRB.Checked)
            {
                option = '+';
            }
            if (subRB.Checked)
            { 
                option = '-';
            }
        }
    }
}
