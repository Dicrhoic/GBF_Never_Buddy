﻿using GBF_Never_Buddy.Classes;
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
using static GBF_Never_Buddy.Classes.RaidDetails;
using static System.Windows.Forms.LinkLabel;

namespace GBF_Never_Buddy.Forms
{
    
    public partial class GBLog : Form
    {
        RaidClasses raid = new RaidClasses();
        List<RaidClasses.Raid> raids;
        private char option = '+';
        private string? raidLink;
        RaidClasses.Data? currentRaid;
        RaidClasses.RaidDropData? raidData;
        int id = -1;

        public GBLog()
        {
            InitializeComponent();
            raids = raid.Raids();
            comboBox1.DataSource = raids.Select(x=>x.name).ToArray();
            comboBox1.SelectedIndexChanged += LoadRaidData;
            subRB.CheckedChanged += UpdateOption;
            addRB.Checked = true;
            label1.Text = "";
        }

        private void LoadRaidData(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            RaidClasses.Raid raid = raids[index];
            raidLink = raid.link;
            raidImage.Load(raid.image);
            raidImage.MouseClick += UpdateRaidAttempts;
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add("Open wiki link");
            menuStrip.Items[0].Click += LoadRaidPage;
            raidImage.ContextMenuStrip = menuStrip;
            id = index + 1;
            SetRaidClass(raid.name);

        }

        private void UpdateRaidAttempts(object? sender, EventArgs e)
        {
            switch (option)
            {
                case '+':
                    currentRaid.UpdateAttempts(1);
                    break;
                case '-':
                    currentRaid.UpdateAttempts(-1);
                    break;
            }
            label1.Text = $"Attempts: {currentRaid.attempts}";
        }

        private void SetRaidClass(string name)
        {
            panel4.Controls.Clear();
            List<RaidClasses.Data> raids = raid.RaidData(name);
            currentRaid = raids[0];
            label1.Text = $"Attempts: {currentRaid.attempts}";
            switch (name) 
            {
                case "Wings of Terror (Impossible)":
                    RaidDetails.BahaHL baha = new(raid, id);                   
                    baha.LoadChestData(panel4);
                    baha.SetAttempts(currentRaid.attempts);
                 
                    break;
            }
           

        }
        private void LoadRaidPage(object? sender, EventArgs e)
        {   
            if(raidLink!= null)
            {
                string url = raidLink;
                System.Diagnostics.Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateOption(object sender, EventArgs e)
        {
            if(addRB.Checked)
            {
                option = '+';
            }
            if(subRB.Checked)
            {
                option = '-';
            }
        }
    }
}
