﻿using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using System.Diagnostics;

namespace GBF_Never_Buddy.GachaForms
{
    public partial class RouletteLog : Form
    {
        RouletteCounter counter;
        GachaHandler gachaHandler;
        public RouletteLog(GachaHandler handler)
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;
            gachaHandler = handler;
            label1.Text = dateTime.ToString("d/M/yyyy");
            counter = new RouletteCounter();
        }

      

        public void ChangeTableRows()
        {
            var styles = resultsTable.RowStyles;
            int count = resultsTable.RowCount;
            int tableHeigt = resultsTable.Height;
            int sizeDistrubution = tableHeigt / count;
            float percentageHeight = 33;
            Debug.WriteLine($"Table Height: {tableHeigt}");
            foreach (RowStyle style in styles)
            {
                Debug.WriteLine($"Type: {style.SizeType}, Height: {style.Height}");
                style.Height = percentageHeight;
            }
        }

        private void TenDrawBtn_Click(object sender, EventArgs e)
        {
            GachaResultAdder Adder = new(gachaHandler, this, counter);
            if (dataTabs.SelectedIndex == 0)
            {
                if (counter.ValidGachaGP())
                {
                    Adder.ShowDialog();
                }
                if (!counter.ValidGachaGP())
                {
                    Debug.WriteLine("Mukku mode");
                    dataTabs.SelectedIndex = 1;
                }
            }
            if (dataTabs.SelectedIndex == 1)
            {

                var table = resultsTable;
                if (table != null)
                {
                    Debug.WriteLine("Mukku");
                    Debug.WriteLine(table.Controls.Count);

                    if (table.Controls.Count == 0)
                    {
                        Adder.ShowDialog();
                    }
                    foreach (Control c in table.Controls)
                    {
                        Debug.WriteLine(c.Controls.Count);
                        int count = c.Controls.Count;
                        if (counter.ValidGacha(count))
                        {
                            Adder.ShowDialog();
                        }

                    }

                }
            }

        }

        private void ScreenShotForm(object sender, EventArgs e)
        {
            ScreenShotClass shotClass = new();
            var origin = Application.OpenForms["RouletteLog"];
            RouletteLog log = (RouletteLog)origin;
            shotClass.ScreenshotForm(log);

        }

        private void outputBtn_Click(object sender, EventArgs e)
        {
            ResultsForm results = new(gachaHandler);
            results.Show();
        }
    }

    public class RouletteCounter
    {
        private int maxGP = 20;
        private int increment = 1;
        public int currentCount = 1;
        private int mukkuSRRCap = 5;
        public int mukkuSSRCount = 0;
    

        public bool ValidGachaGP()
        {
         
            if (currentCount > maxGP)
            {
                return false;
            }

            return true;
        }

        public void IncreaseStep()
        { currentCount += increment; }

        public bool ValidGacha(int count)
        {
            mukkuSSRCount = count;
            Debug.WriteLine($"{mukkuSSRCount} = {mukkuSRRCap}");
            if (mukkuSSRCount < mukkuSRRCap)
            {
                return true;
            }
            return false;
        }

    }
}
