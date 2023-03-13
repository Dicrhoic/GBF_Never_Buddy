using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GBF_Never_Buddy.Classes.RaidDetails;

namespace GBF_Never_Buddy.Classes
{
    internal class RaidDetails : RaidClasses
    {
        public class RaidData
        {
            public string name;
            public int hostChestContents;
            public int mvpChestContents;
            public int blueChestContents;
            public int attempts;
            public int hGB;
            public int gbB;
            public int blueChest;


            public void UpdateBlueChest(int increment)
            {
                blueChest += increment;
            }

            public void UpdatehGB(int increment)
            {
                hGB += increment;
            }

            public void UpdategbB(int increment)
            {
                gbB += increment;
            }


            public void UpdateAttempts(int increment)
            {
                int output = attempts + increment;
                if (output >= 0)
                {
                    attempts += increment;
                }

            }
        }

        public class BahaHL : RaidData
        {
            public List<Tuple<ChestContents, int>> hostChests;
            public List<Tuple<ChestContents, int>> mvpChests;
            public List<Tuple<ChestContents, int>> shareChests;
            public List<Tuple<Label, Label>> dataTagsHost = new();
            public List<Tuple<Label, Label>> dataTagsMvp = new();
            public List<Tuple<Label, Label>> dataTagsChest = new();
            TableLayoutPanel host = new TableLayoutPanel();
            TableLayoutPanel mvp = new TableLayoutPanel();
            TableLayoutPanel blue = new TableLayoutPanel();
            RaidClasses raidHelper;
            RaidClasses.RaidDropData RaidDropData; 
            public BahaHL(RaidClasses raidClasses, int id)
            {
                raidHelper = raidClasses;
                hostChestContents = 3;
                mvpChestContents = 2;
                blueChestContents = 4;
                name = "Wings of Terror (Impossible)";
                hostChests = new List<Tuple<ChestContents, int>>();
                mvpChests = new List<Tuple<ChestContents, int>>();
                shareChests = new List<Tuple<ChestContents, int>>();
                AddDataForChest();
                LoadTableFormat();
                RaidDropData = new(name, id);
                attempts = raidHelper.AttemptsDB(id);
                Debug.WriteLine($"Class Called attempts: {attempts}");
                
            }

            private void LoadTableFormat()
            {
                host.Height = 195;
                host.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                host.AutoScroll = true;
                host.ColumnCount = 1;
                host.RowCount = 1;
                TableLayoutColumnStyleCollection hostStyles =
                  host.ColumnStyles;
                foreach (ColumnStyle style in hostStyles)
                {
                    style.SizeType = SizeType.AutoSize;
                }
                mvp.Height = 195;
                mvp.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                mvp.AutoScroll = true;
                mvp.ColumnCount = 1;
                mvp.RowCount = 1;
                TableLayoutColumnStyleCollection mvpStyles =
                  mvp.ColumnStyles;
                foreach (ColumnStyle style in mvpStyles)
                {
                    style.SizeType = SizeType.AutoSize;
                }
                blue.Height = 195;
                blue.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                blue.AutoScroll = true;
                blue.ColumnCount = 1;
                blue.RowCount = 1;
                TableLayoutColumnStyleCollection bStyles =
                  mvp.ColumnStyles;
                foreach (ColumnStyle style in bStyles)
                {
                    style.SizeType = SizeType.AutoSize;
                }
            }

            private void AddDataForChest()
            {
                CreateHostChestContents();
                CreateMVPChestContents();
                CreateShareChestContents();
            }

         

            public void SetAttempts(int count)
            {
                this.attempts = count;
            }

            public void LoadChestData(Panel panel1)
            {
                host.Width = panel1.Width;
                mvp.Width = panel1.Width;
                blue.Width = panel1.Width;
                int count = 0;        
                foreach (var item in hostChests)
                {
                    FlowLayoutPanel panel = new();
                    panel.Name = $"HostChestItem_{count}";
                    panel.FlowDirection = FlowDirection.TopDown;
                    var itemData = item.Item1;
                    Button button = new();
                    button.Image = itemData.image;
                    button.Size = new Size(130, 121);
                    string name = $"{itemData.name}_{itemData.amount}";
                    Label label = new Label();
                    label.Name = $"{itemData.name}_label";
                    label.Text = "0";
                    Label label2 = new Label();
                    label2.Text = "---%";
                    label2.Name = $"{itemData.name}_Ratelabel";
                    button.Name = name;
                    Tuple<Label, Label> tuple = new Tuple<Label, Label>(label, label2);
                    Tuple<ChestContents, Tuple<Label, Label>> linkedData = new Tuple<ChestContents, Tuple<Label, Label>>(itemData, tuple);                    
                    button.Click += (s, e) => { ItemClickedOnFunction(linkedData, raidHelper); };
                    panel.Controls.Add(button);
                    panel.Height = 195;
                    panel.AutoSize = true;
                    panel.Controls.Add(label);
                    panel.Controls.Add(label2);
                    host.Controls.Add(panel);
                    dataTagsHost.Add(tuple);
                    LoadRaidData(linkedData);
                    count++;
                }
                
                foreach (var item in shareChests)
                {
                    FlowLayoutPanel panel = new();
                    panel.Name = "ThirdChestPanel";
                    panel.FlowDirection = FlowDirection.TopDown;
                    var itemData = item.Item1;
                    Button button = new();
                    button.Image = itemData.image;
                    button.Size = new Size(130, 121);
                    string name = $"{itemData.name}_{itemData.amount}";
                    Label label = new Label();
                    label.Name = $"{itemData.name}_label";
                    label.Text = "0";
                    Label label2 = new Label();
                    label2.Text = "---%";
                    label2.Name = $"{itemData.name}_Ratelabel";
                    button.Name = name;
                    Tuple<Label, Label> tuple = new Tuple<Label, Label>(label, label2);
                    Tuple<ChestContents, Tuple<Label, Label>> linkedData = new Tuple<ChestContents, Tuple<Label, Label>>(itemData, tuple);
                    button.Click += (s, e) => { ItemClickedOnFunction(linkedData, raidHelper); };
                    panel.Controls.Add(button);
                    int height = panel1.Height;
                    panel.Height = height;
                    panel.AutoSize = true;
                    panel.Controls.Add(label);
                    panel.Controls.Add(label2);
                    blue.Controls.Add(panel);
                    dataTagsChest.Add(tuple);
                    LoadRaidData(linkedData);
                    Debug.WriteLine("Added item");
                }
                host.Dock = DockStyle.Top;
                blue.Dock = DockStyle.Bottom;
                panel1.Controls.Add(host);
                panel1.Controls.Add(blue);
            }

            private void CreateHostChestContents()
            {
                Image image1 = Properties.Resources.Primeval_Horn_square;
                ChestContents chess = new("Primeval Horn", 1, image1, name, "hostchest", 0);
                Tuple<ChestContents, int> hc1 = new Tuple<ChestContents, int>(chess, 1);
                Image image2 = Properties.Resources.Primeval_Horn_square;
                ChestContents chess2 = new("Primeval Horn", 2, image2, name, "hostchest", 2);
                Tuple<ChestContents, int> hc2 = new Tuple<ChestContents, int>(chess2, 2);
                Image image3 = Properties.Resources.Gold_Brick;
                ChestContents chess3 = new("Gold Brick", 1, image3, name, "hostchest", 4);
                Tuple<ChestContents, int> hc3 = new Tuple<ChestContents, int>(chess3, 1);
                hostChests.Add(hc1);
                hostChests.Add(hc2);
                hostChests.Add(hc3);
            }

            private void CreateMVPChestContents()
            {
                Image image1 = Properties.Resources.Primeval_Horn_square;
                ChestContents chess = new("Primeval Horn", 1, image1, name, "mvpchest", -1);
                Tuple<ChestContents, int> hc1 = new Tuple<ChestContents, int>(chess, 1);
                Image image2 = Properties.Resources.Soul_Balm;
                ChestContents chess2 = new("Soul Balm", 1, image2, name, "mvpchest", 4);
                Tuple<ChestContents, int> hc2 = new Tuple<ChestContents, int>(chess2, -2);
                mvpChests.Add(hc1);
                mvpChests.Add(hc2);
            }
            private void CreateShareChestContents()
            {
                Image icon = Properties.Resources._40px_Icon_Blue_Chest;
                ChestContents iconData = new("Blue Chest", 1, icon, name, "sharechest", 20);
                Tuple<ChestContents, int>c0 = new(iconData, 1);
                Image image1 = Properties.Resources.Coronation_Ring_square;
                ChestContents chess = new("Coronation Ring", 1, image1, name, "sharechest", 6);
                Tuple<ChestContents, int> c1 = new Tuple<ChestContents, int>(chess, 1);
                Image image2 = Properties.Resources.Lineage_Ring_square;
                ChestContents chess2 = new("Lineage Ring", 2, image2, name, "sharechest", 8);
                Tuple<ChestContents, int> c2 = new Tuple<ChestContents, int>(chess2, 2);
                Image image3 = Properties.Resources.Intricacy_Ring_square;
                ChestContents chess3 = new("Intricacy Ring", 1, image3, name, "sharechest", 10);
                Tuple<ChestContents, int> c3 = new Tuple<ChestContents, int>(chess3, 1);
                Image image4 = Properties.Resources.Gold_Brick;
                ChestContents chess4 = new("Gold Brick", 1, image4, name, "sharechest", 12
                    );
                Tuple<ChestContents, int> c4 = new Tuple<ChestContents, int>(chess4, 1);
                shareChests.Add(c0);
                shareChests.Add(c1);
                shareChests.Add(c2);
                shareChests.Add(c3);
                shareChests.Add(c4);
            }

            public void ItemClickedOnFunction(Tuple<ChestContents, Tuple<Label, Label>> linkedData, RaidClasses helper)
            {
                ChestContents chest = linkedData.Item1;
                int index = linkedData.Item1.index;
                string dataStr = RaidDropData.DropString(RaidDropData.id);
                string rateStr = RaidDropData.RateString(RaidDropData.id);

                helper.id = RaidDropData.id;
                helper.Attempts = attempts;
                helper.CurrentChest(chest);
                helper.UpdateValue(linkedData, index, dataStr, rateStr, RaidDropData);
            }

            private void LoadRaidData(Tuple<ChestContents, Tuple<Label, Label>> linkedData)
            {

                    ChestContents chest1 = linkedData.Item1;
                    int index = linkedData.Item1.index;
                    string dataStr = RaidDropData.DropString(RaidDropData.id);
                    string rateStr = RaidDropData.RateString(RaidDropData.id);
                    raidHelper.DisplayData(linkedData, index, dataStr, rateStr);
                
            }

        }



        public class XenoIfritMilitis : RaidData
        {
            public List<Tuple<ChestContents, int>> hostChests;
            public List<Tuple<Label, Label>> dataTagsHost = new();
            TableLayoutPanel host = new TableLayoutPanel();
            RaidClasses raidHelper;
            RaidClasses.RaidDropData RaidDropData;

            public XenoIfritMilitis(RaidClasses raidClasses, int id)
            {
                raidHelper = raidClasses;
                hostChestContents = 3;
                mvpChestContents = 2;
                blueChestContents = 4;
                name = "Wings of Terror (Impossible)";
                hostChests = new List<Tuple<ChestContents, int>>();
                //LoadTableFormat();
                RaidDropData = new(name, id);
                attempts = raidHelper.AttemptsDB(id);
                Debug.WriteLine($"Class Called attempts: {attempts}");

            }

        }
    }
}
