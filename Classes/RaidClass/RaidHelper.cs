using GBF_Never_Buddy.Forms;
using GBF_Never_Buddy.Properties;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GBF_Never_Buddy.Classes.RaidClass

{
    internal class RaidHelper
    {
   

        static Bitmap ItemResourceName (string item)
        {
            Dictionary<string, Bitmap> assets = new Dictionary<string, Bitmap>
            {
                {"Coronation Ring",  Resources.Coronation_Ring_square},
                {"Lineage Ring", Resources.Lineage_Ring_square },
                {"Intricacy Ring", Resources.Intricacy_Ring_square},
                {"Gold Brick", Resources.Gold_Brick},
                {"Primeval Horn", Resources.Primeval_Horn_square},
                {"Huanlong Omega Anima", Resources.Huanglong_Omega_Anima_square},
                {"Qilin Omega Anima", Resources.Qilin_Omega_Anima_square},
                {"Huanglong", Resources.Huanglong_summon},
                {"Qilin", Resources.Qilin_Summmon},
                {"Hollow Key", Resources.Hollow_Key_square},
                {"Champion Merit", Resources.Champion_Merit_square},
                {"Supreme Merit", Resources.GoldCert},
                {"Legendary Merit", Resources.Legendary_Merit},
                {"Silver Centrum", Resources.Silver_Centrum},
                {"Weapon Plus Mark", Resources.Icon_Gold_Chest},
                {"Verdant Azurite", Resources.Verdant_Azurite_square},
                {"Ultima Unit", Resources.Ultima_Unit_square },
                {"Extinction Vestige", Resources.Extinction_Vestige_square},
                {"Extinction Blade", Resources.ExtiB},
                {"Mortality Bow", Resources.MortalB},
                {"Eternity Sand", Resources.Eternity_Sand_square},
                {"Automagod Plating", Resources.Automagod_Plating_square},
                {"Schrodinger", Resources.Schro},
                {"Lagrange", Resources.Lagra},
                {"Dragonslayer's Edge", Resources.Dragonslayer_s_Edge_square},
                {"Fang of the Dragonslayer", Resources.Fang},
                {"Claw of the Dragonslayer", Resources.Claw},
                {"Remnants of the Star-Sea's Edge", Resources.Remnants_of_the_Star_Sea_s_Edge_square},
                {"Sette di Spade", Resources.Sette},
                {"Spada di Vento", Resources.Spada},
                {"Arbitration Cloth", Resources.Arbitration_Cloth_square},
                {"Symmetria", Resources.Symmetria},
                {"Concordia", Resources.Concordia},
                {"Abominable Reminder", Resources.Abominable_Reminder_square},
                {"Forbidden Agastia", Resources.F_Agastia},
                {"Forsaken Agastia", Resources.Fo_Agastia},
                {"Urn", Resources.Icon_Gold_Chest},
                {"Blue Sky Crystal", Resources.Blue_Sky_Crystal_square},
              
            };
            return assets[item];
        }

        public enum ChestType
        {
            Host = 1,
            MVP = 2,
            Share = 3,
            Numbered = 0
        }
        public class RaidSQL
        {
           
            public List<RaidInfo> RaidList()
            {
                List<RaidInfo> Raids = new List<RaidInfo>();
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT * FROM Raids
                        ";
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        foreach (var row in reader)
                        {   
                            string name = reader.GetString(1);
                            string link = reader.GetString(2);
                            string image = reader.GetString(3);
                            int id = reader.GetInt32(0);
                            RaidInfo raid = new(id, name, link, image);
                            Raids.Add(raid);
                                        
                        }
                    }

                }

                return Raids;
            }


       


        }

        public class RaidInfo
        {
            public int Id { get; }
            public string name  { get;}
            public string link { get; }
            public string image { get; }
            public int attempts { get; set; }

            public List<ChestData> chest { get; }

            private RaidPanel panels;

            public RaidInfo(int id, string name, string link, string image)
            {
                Id = id;
                this.name = name;
                this.link = link;
                this.image = image;
                chest = ChestContents();
                LoadAttempts(id);
                panels = new RaidPanel(id, chest, this);
        
            }

            public void LoadRaidImage()
            {
                var Parent = Application.OpenForms["ItemDropLog"];
                if (Parent != null)
                {
                    ItemDropLog origin = (ItemDropLog)Parent;
                    var imageHolder = origin.Controls.Find("raidImage", true);
                    PictureBox pictureBox = (PictureBox)imageHolder[0];
                    pictureBox.Load(image);
                    pictureBox.Click += UpdateRaidAttempts;
                }
            }

            private void UpdateRaidAttempts(object? sender, EventArgs e)
            {
                var parent = Application.OpenForms["ItemDropLog"];
                if (parent != null)
                {
                    ItemDropLog origin = (ItemDropLog)parent;
                    var rb = origin.Controls.Find("addRB", true);
                    if (rb != null)
                    {
                        var rbC = (RadioButton)rb[0];
                        int increment = 1;
                        if (!rbC.Checked)
                        {
                            increment = -1;
                        }
                        int runs = attempts;
                        runs += increment;
                        attempts = runs;

                        using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                        {
                            connection.Open();
                            var command = connection.CreateCommand();
                            command.CommandText =
                                @"
                                    UPDATE RaidData 
                                    SET attempts=$value
                                    WHERE raidID=$id
                              ";
                            command.Parameters.AddWithValue("$value", attempts);
                            command.Parameters.AddWithValue("$id", Id);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    var l = origin.Controls.Find("label1", true);
                    var label = l[0];
                    label.Text = $"Attempts: {attempts}";
             
                }
            }

            private RateData ItemRate(int id)
            {

                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {

                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT * FROM 
                            ItemDropRates 
                            WHERE ItemID=$id
                        ";
                    command.Parameters.AddWithValue("$id", id);
                    var reader = command.ExecuteReader();
                    Debug.WriteLine($"item: {id} {reader.HasRows}");
                    if(reader.HasRows)
                    {
                        foreach (var item in reader)
                        {
                         
                            int rateId = reader.GetInt32(0);
                            int raid = reader.GetInt32(1);
                            int itemId = reader.GetInt32(2);
                            int quantity = reader.GetInt32(3);
                            string rate = reader.GetString(4);

                            decimal d = Decimal.Parse(rate);
                            Debug.WriteLine($"Closing connection rate for {rateId} {itemId} {rate}");
                            connection.Close();
                            RateData rateData = new(rateId, raid, itemId, quantity, d);
                            return rateData;

                        }
                    }
              
                    

                    return null;


                }
            }



            private void LoadAttempts(int raidId)
            {
             
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT * FROM RaidData 
                            WHERE raidID=$id
                        ";
                    command.Parameters.AddWithValue("$id", raidId);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        foreach(var item in reader)
                        {
                            int runs = reader.GetInt32(1);
                            attempts = runs;
                        }
                     

                    }
                }
            }
            private List<ChestData> ChestContents()
            {   
                List<ChestData> list = new();
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT * FROM DropItem 
                            WHERE RaidID=$id
                        ";
                    command.Parameters.AddWithValue("$id", Id);
                    Debug.WriteLine(Id);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        foreach (var row in reader)
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(3);
                            int type = reader.GetInt32(2);
                            int quantity = reader.GetInt32(4);
                           
                          
                            RateData rate = ItemRate(id);
                            ChestData data = new(id,name, type, quantity, rate, Id);
                            Debug.WriteLine($"{name} {rate} {rate.rate}");
                            list.Add(data);
                       
                        }
                    }
             
                    connection.Close(); 

                }
                return list;
            }

            public void DisplayData(Panel panel)
            {
                 
                panels.LoadChestData(panel);
            }


        }

        /*
         * A Raid Contains its ChestData, DropData, RateData
         * 
         * 
            Defined whether the chest is a host, MVP, or Share(Blue)
            Issues to address, same name conflict
            e.g Primeval Horn x1 vs Primeval Horn x2
            How would we know which one to use?
            We use item ID, name as dictionary values
         
         */
        public class ChestData
        {
            int ID;
            string name;
            int chestType;
            int quantity;
            int raidID;

            RateData rate;


            public ChestData(int ID, string name, int chestType, int quantity, RateData rate, int rId)
            {
                this.ID = ID;   
                this.name = name;
                this.chestType = chestType;
                this.quantity = quantity;
                this.rate = rate;
                raidID = rId;


            }

            public int RaidID()
            {
                return raidID;  
            }

            public RateData rateData()
            {   
                return rate;
            }
            

            public int ItemID()
            {
                return ID;
            }


     

            public string Name() 
            {
                return name;    
            }

            public int Chest() 
            {
                return chestType;
            }

            public int Quantity()
            {
                return quantity;
            }

        }

        public class ItemData
        {
            public int ID;
            public int RaidID;
            public int ChestID;
        }

        public class RateData
        {
            public int ID;
            public int raidID;
            public int itemID;
            public int have;
            public decimal rate;

            public RateData(int iD, int raidID, int itemID, int have, decimal rate)
            {
                ID = iD;
                this.raidID = raidID;
                this.itemID = itemID;
                this.have = have;
                this.rate = rate;
            }

            public void ConvertRate(int attempts)
            {
                decimal conversion = Decimal.Divide(have, attempts);
                conversion = Math.Round(conversion, 2);
                rate = conversion;
            }

        }

        public class RaidPanel
        {
            int ID { get; set; }
            public int RaidID;
            List<ChestData> chestDatas;
            RaidInfo parent;
            public List<Tuple<Label, Label>> dataTagsHost = new();
            public List<Tuple<Label, Label>> dataTagsMvp = new();
            public List<Tuple<Label, Label>> dataTagsShare = new();
            public List<Tuple<Label, Label>> dataTagsChest = new();
            public List<Label> HostRateTag = new();
            public List<Label> MvpRateTag = new();
            public List<Label> ShareRateTag = new();
            public List<Label> NumberedRateTag = new();
            int height = 195;
            TableLayoutPanel host = new TableLayoutPanel();
            TableLayoutPanel mvp = new TableLayoutPanel();
            TableLayoutPanel blue = new TableLayoutPanel();
            TableLayoutPanel extra = new TableLayoutPanel();

            public RaidPanel(int raidID, List<ChestData> chests, RaidInfo raid)
            {
                RaidID = raidID;
                chestDatas = chests;
                Debug.WriteLine($"Added {chestDatas.Count} chests for ID: {raidID}");
                CreateRows();
                parent = raid;
            }


            private string ItemDropRate(int id)
            {
                string rate = $"---%";
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT * FROM ItemDropRates 
                            WHERE ItemID=$id
                        ";
                    command.Parameters.AddWithValue("$id", id);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        foreach (var item in reader)
                        {
                            string currentRate = reader.GetString(4);
                            decimal r = Decimal.Parse(currentRate);
                           
                            decimal round = Math.Round(r, 4);
                            rate = $"{round}%";
                            if(round == 1)
                            {
                                rate = "100%";
                            }
                            Debug.WriteLine($"Rate for {id} = {round}%");
                        }
                    }
                    connection.Close();
                    return rate;
                }
            }

            private void UpdateRate(ChestData data)
            {
                Debug.WriteLine($"RaidID: {data.RaidID()} chest: {data.Chest()} attempts: {parent.attempts}");
                List<string> ratesStrings = new();
                List<int> ids = new();
                List<int> values = new List<int>();   
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT DropItem.Id, DropItem.ChestType, ItemDropRates.Acquired, 
                                    ItemDropRates.ItemID
                            FROM DropItem
                            INNER JOIN ItemDropRates 
                            ON DropItem.Id=ItemDropRates.ItemID
                            WHERE DropItem.RaidID=$id AND DropItem.ChestType=$type
                        ";
                    command.Parameters.AddWithValue("$id", data.RaidID());
                    command.Parameters.AddWithValue($"type", data.Chest());
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                       while (reader.Read()) 
                        {
                            Debug.WriteLine($"Chest Type: {reader.GetInt32(1)} " +
                                $"ItemID: {reader.GetInt32(3)} Have: {reader.GetInt32(2)}");
                            int i = reader.GetInt32(2);
                            //Debug.WriteLine($"ItemID: {i} adding");
                            values.Add(i);  
                            int id = reader.GetInt32(3);
                            ids.Add(id);    
                        }
                    }
                    foreach(var item in values)
                    {
                      
                        Decimal r = Decimal.Divide(item, parent.attempts);
                        Debug.WriteLine($"Rate for item {item} is {r}");
                        string rs = $"{Math.Round(r, 4)}%";
                        ratesStrings.Add(rs);   
                    }
                    //Debug.WriteLine($"{count} items for {data.RaidID()}");
                }
                switch(data.Chest())
                {
                    case 0:
                        UpdateNumRateLabels(ratesStrings, ids);
                        break;
                    case 1:
                        UpdateHostRateLabels(ratesStrings, ids);
                        break;
                    case 2:
                        UpdateMVPRateLabels(ratesStrings, ids);
                        break;
                    case 3:
                        UpdateShareRateLabels(ratesStrings, ids);
                        break;
                }
          
            }
            
            private void UpdateRateValue(string r, int id)
            {
                string rate = r.Replace("%", "");
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            UPDATE ItemDropRates 
                            SET rate=$r
                            WHERE ItemID=$id
                        ";
                    command.Parameters.AddWithValue("$id", id);
                    command.Parameters.AddWithValue("$r", rate);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            private void UpdateHostRateLabels(List<string> rates, List<int> ids)
            {
                if(rates.Count == HostRateTag.Count) 
                {
                    for(int i = 0; i < rates.Count; i++)
                    {
                        HostRateTag[i].Text = rates[i];
                        UpdateRateValue(rates[i], ids[i]);
                    }
                }
            }  
            private void UpdateMVPRateLabels(List<string> rates, List<int> ids)
            {
                if (rates.Count == MvpRateTag.Count)
                {
                    for (int i = 0; i < rates.Count; i++)
                    {
                        MvpRateTag[i].Text = rates[i];
                        UpdateRateValue(rates[i], ids[i]);
                    }
                }
            }
            private void UpdateShareRateLabels(List<string> rates, List<int> ids)
            {
                if (rates.Count == ShareRateTag.Count)
                {
                    for (int i = 0; i < rates.Count; i++)
                    {
                        ShareRateTag[i].Text = rates[i];
                        UpdateRateValue(rates[i], ids[i]);
                    }
                }
            }
            private void UpdateNumRateLabels(List<string> rates, List<int> ids)
            {
                if (rates.Count == NumberedRateTag.Count)
                {
                    for (int i = 0; i < rates.Count; i++)
                    {
                        NumberedRateTag[i].Text = rates[i];
                        UpdateRateValue(rates[i], ids[i]);
                    }
                }
            }


            private string ItemStoredCount(int id)
            {   

                string value = $"0";
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT * FROM ItemDropRates 
                            WHERE ItemID=$id
                        ";
                    command.Parameters.AddWithValue("$id", id);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        foreach (var item in reader)
                        {
                            int have = reader.GetInt32(3);
                            string inv = $"{have}";
                            value = inv;
                        }
                    }
                    connection.Close();
                    return value;
                }
            }

            private int ItemCount(int id)
            {

                int value = 0 ;
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT * FROM ItemDropRates 
                            WHERE ItemID=$id
                        ";
                    command.Parameters.AddWithValue("$id", id);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        foreach (var item in reader)
                        {
                            value = reader.GetInt32(3);
                            
                        }
                    }
                    connection.Close();
                    return value;
                }
            }

            public void UpdateAcquriedCount(ChestData chest, Tuple<Label,Label> tag)
            {
                var parent = Application.OpenForms["ItemDropLog"];
                
                if ( parent != null )
                {
               
                    var increment = ((ItemDropLog)parent).Controls.Find("addRB", true);
                   
                    if ( increment != null )
                    {
                        RateData rate = chest.rateData();
                        int have = ItemCount(chest.ItemID());
                        RadioButton incrementSetting = (RadioButton)increment[0];
                        bool increase = incrementSetting.Checked;
                        Debug.WriteLine($"Increase: {increase} current in inventory {have}");
                        int qunatity = chest.Quantity();
                        if(!increase)
                        {
                            qunatity = qunatity * -1;
                            Debug.WriteLine($"New value = {qunatity}");
                        }
                        int updated = have + qunatity;
                        bool valid = ValidRate(updated, chest);
                        if(updated >= 0 && valid)
                        {
                            Debug.WriteLine($"Current {chest.Name()} in inventory: {updated}");
                            
                            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                            {
                                connection.Open();
                                var command = connection.CreateCommand();
                                command.CommandText =
                                    @"
                                    UPDATE ItemDropRates 
                                    SET Acquired=$value
                                    WHERE ItemID=$id
                                ";
                                command.Parameters.AddWithValue("$value", updated);
                                command.Parameters.AddWithValue("$id", chest.ItemID());
                                command.ExecuteNonQuery();
                                connection.Close();
                                tag.Item1.Text = $"{updated}";
                                Debug.WriteLine($"Incremented itemID {chest.ItemID()} value {updated}");
                            }
                            UpdateRate(chest);
                           
                        }
                    
                    }
                   
                }
            
            }
            private bool ValidRate(int have,ChestData data)
            {
                List<Decimal> rates = new();
                List<int> ids = new();
                List<int> values = new List<int>();
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT DropItem.Id, DropItem.ChestType, ItemDropRates.Acquired, 
                                    ItemDropRates.ItemID
                            FROM DropItem
                            INNER JOIN ItemDropRates 
                            ON DropItem.Id=ItemDropRates.ItemID
                            WHERE DropItem.RaidID=$id AND DropItem.ChestType=$type
                        ";
                    command.Parameters.AddWithValue("$id", data.RaidID());
                    command.Parameters.AddWithValue($"type", data.Chest());
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Debug.WriteLine($"Chest Type: {reader.GetInt32(1)} " +
                                $"ItemID: {reader.GetInt32(3)} Have: {reader.GetInt32(2)}");
                            int i = reader.GetInt32(2);
                            if(i == data.ItemID())
                            {
                                i = have;
                            }
                            //Debug.WriteLine($"ItemID: {i} adding");
                            values.Add(i);
                            int id = reader.GetInt32(3);
                            ids.Add(id);
                        }
                    }
                    foreach (var item in values)
                    {

                        Decimal r = Decimal.Divide(item, parent.attempts);                      
                        rates.Add(r);
                        if(rates.Sum() > 1)
                        {
                            return false;
                        }
                    }
      
                }
                return true;

            }

       

            public void CreateHostRow()
            {
                host.Height = height;
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
            }

            public void CreateMVPRow()
            {
                mvp.Height = height;
                mvp.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                mvp.AutoScroll = true;
                mvp.ColumnCount = 1;
                host.RowCount = 1;
                TableLayoutColumnStyleCollection mvpStyles =
                  mvp.ColumnStyles;
                foreach (ColumnStyle style in mvpStyles)
                {
                    style.SizeType = SizeType.AutoSize;
                }
            }

            public void CreateExtraRow()
            {
                extra.Height = height;
                extra.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                extra.AutoScroll = true;
                extra.ColumnCount = 1;
                extra.RowCount = 1;
                TableLayoutColumnStyleCollection extraStyles = extra.ColumnStyles;
                foreach (ColumnStyle style in extraStyles)
                {
                    style.SizeType = SizeType.AutoSize;
                }
            }

            public void CreateBlueRow()
            {
                blue.Height = height;
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

            public void CreateRows()
            {   
                CreateHostRow();
                CreateExtraRow();
                CreateMVPRow();
                CreateBlueRow();
            }

            public void LoadChestData(Panel panel1)
            {
                host.Controls.Clear();
                mvp.Controls.Clear();
                blue.Controls.Clear();
                extra.Controls.Clear();
                var b = chestDatas.Any(x => x.Chest() == 3);
                var h = chestDatas.Any(x => x.Chest() == 1);
                var m = chestDatas.Any(x => x.Chest() == 2);
                var n = chestDatas.Any(x=> x.Chest() == 0);
                foreach (var c in chestDatas)
                {
                    Debug.WriteLine($"{c.Name()}");
                }
                Debug.WriteLine($"LoadChestData() count: {chestDatas.Count} b:{b}, h:{h}, m:{m}, n:{n}");
                /*
                 We can probably slim the data more
                 */
                if (h)
                {
             
                    host.Width = panel1.Width;
                    host.AutoSize = true;
                    host.AutoSizeMode = AutoSizeMode.GrowOnly;
                    CreateHostPanel();
                    panel1.Controls.Add(host);  
                }

                if (n)
                {   
                
                    extra.Width = panel1.Width; 
                    CreateNumPanel();
                    panel1.Controls.Add(extra);
                }

                if (m)
                {   
        
                    mvp.Width = panel1.Width;
                    CreateMVPPanel();
                    panel1.Controls.Add(mvp);
                }
                if (b)
                {
                    Debug.Write("Adding bluye");
                    blue.Width = panel1.Width;
                    blue.AutoSize = true;
                    blue.AutoSizeMode = AutoSizeMode.GrowOnly;
                    CreateBluePanel();
                    panel1.Controls.Add(blue);  
                }
                if(h && n)
                {
                    host.Dock = DockStyle.Top;
                    extra.Dock = DockStyle.Fill;
                }
                if (h && b)
                {
                    Debug.WriteLine("Host and Blue");
                    host.Dock = DockStyle.Top;
                    blue.Dock = DockStyle.Bottom;
                }
                Debug.WriteLine(panel1.Controls.Count);
            }

            public void CreateHostPanel()
            {
                int count = 0;
                List<ChestData> hostChests = chestDatas.Where(x => x.Chest() == 1).ToList();
                Label label1 = new Label();
                label1.Text = "Host Chest";
                host.Controls.Add(label1);
                foreach (var item in hostChests)
                {
          
                    FlowLayoutPanel panel = new();
                    panel.Name = $"HostChestItem_{count}";
                    panel.FlowDirection = FlowDirection.TopDown;
                    var itemData = item;
                    Button button = new();

                    button.Size = new Size(130, 121);
                    string itemName = itemData.Name();
                    string name = $"{itemName}_{itemData.Quantity()}";
                    var image = ItemResourceName(itemName);
                    button.Image = image;
                    Label label = new Label();
                    label.Name = $"{itemData.Name}_label";
                    label.Text = ItemStoredCount(item.ItemID());
                    Label label2 = new Label();
                    string rateLabel = ItemDropRate(item.ItemID());
                    label2.Text = rateLabel;
                    label2.Name = $"{itemData.Name}_Ratelabel";
                    button.Name = name;
                    Tuple<Label, Label> tuple = Tuple.Create(label, label2);
                    dataTagsHost.Add(tuple);
                    HostRateTag.Add(label2);
                    button.Click += (s, e) => { UpdateAcquriedCount(itemData, tuple); };
                    button.MouseHover += (s, e) => { Button_MouseHover(button, itemData); };
                
                    panel.Controls.Add(button);
                    panel.Height = 195;
                    panel.AutoSize = true;
                    panel.Controls.Add(label);
                    panel.Controls.Add(label2);
                    host.Controls.Add(panel);
                  
                    count++;
                }
            }

            private void Button_MouseHover(Button button, ChestData item)
            {
                Debug.Write("Hover");
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                string caption = $"Drops {item.Quantity()} of {item.Name()}";
                ToolTip1.SetToolTip(button, caption);
            }

            public void CreateMVPPanel()
            {
                int count = 0;
                List<ChestData> chests = chestDatas.Where(x => x.Chest() == 2).ToList();
                Label label1 = new Label();
                label1.Text = "MVP Chest";
                mvp.Controls.Add(label1);
                foreach (var item in chests)
                {

                    FlowLayoutPanel panel = new();
                    panel.Name = $"MVPChestItem_{count}";
                    panel.FlowDirection = FlowDirection.TopDown;
                    var itemData = item;
                    Button button = new();
               
                    button.Size = new Size(130, 121);
                    string itemName = itemData.Name();
                    string name = $"{itemName}_{itemData.Quantity}";
                    var image = ItemResourceName(itemName);
                    button.Image = image;
                    Label label = new Label();
                    label.Name = $"{itemData.Name}_label";
                    label.Text = ItemStoredCount(item.ItemID());
                    Label label2 = new Label();
                    string rateLabel = ItemDropRate(item.ItemID());
                    label2.Text = rateLabel;
                    label2.Name = $"{itemData.Name}_Ratelabel";
                    button.Name = name;
                    Tuple<Label, Label> tuple = Tuple.Create(label, label2);
                    dataTagsMvp.Add(tuple);
                    MvpRateTag.Add(label2);
                    button.MouseHover += (s, e) => { Button_MouseHover(button, itemData); };
                    button.Click += (s, e) => { UpdateAcquriedCount(itemData, tuple); };
                    panel.Controls.Add(button);
                    panel.Height = 195;
                    panel.AutoSize = true;
                    panel.Controls.Add(label);
                    panel.Controls.Add(label2);
                    mvp.Controls.Add(panel);

                    count++;
                }
            }

            public void CreateBluePanel()
            {
                int count = 0;

                List<ChestData> chests = chestDatas.Where(x => x.Chest() == 3).ToList();
         
                Label label1 = new Label();
                label1.Text = "Share Chest";
                blue.Controls.Add(label1);
                foreach (var item in chests)
                {

                    FlowLayoutPanel panel = new();
                    panel.Name = $"BlueChestItem_{count}";
                    panel.FlowDirection = FlowDirection.TopDown;
                    var itemData = item;
                    Button button = new();

                    button.Size = new Size(130, 121);
                    string itemName = itemData.Name();
                    string name = $"{itemName}_{itemData.Quantity}";
                    var image = ItemResourceName(itemName);
                    button.Image = image;
                    Label label = new Label();
                    label.Name = $"{itemData.Name}_label";
                    label.Text = ItemStoredCount(item.ItemID());
                    Label label2 = new Label();
                    string rateLabel = ItemDropRate(item.ItemID());
                    label2.Text = rateLabel;
                    label2.Name = $"{itemData.Name}_Ratelabel";
                    button.Name = name;
                    Tuple<Label, Label> tuple = Tuple.Create(label, label2);
                    dataTagsShare.Add(tuple);
                    ShareRateTag.Add(label2);
                    button.MouseHover += (s, e) => { Button_MouseHover(button, itemData); };
                    button.Click += (s, e) => { UpdateAcquriedCount(itemData, tuple ); };
                    panel.Controls.Add(button);
                    panel.Height = 195;
                    panel.AutoSize = true;
                    panel.Controls.Add(label);
                    panel.Controls.Add(label2);
                    blue.Controls.Add(panel);

                    count++;
                }
            }

            public void CreateNumPanel()
            {
                int count = 0;
                List<ChestData> chests = chestDatas.Where(x => x.Chest() == 0).ToList();
                Label label1 = new Label();
                label1.Text = "Numnbered Chest";
                extra.Controls.Add(label1);
                foreach (var item in chests)
                {

                    FlowLayoutPanel panel = new();
                    panel.Name = $"NumChestItem_{count}";
                    panel.FlowDirection = FlowDirection.TopDown;
                    var itemData = item;
                    Button button = new();

                    button.Size = new Size(130, 121);
                    string itemName = itemData.Name();
                    string name = $"{itemName}_{itemData.Quantity}";
                    var image = ItemResourceName(itemName);
                    button.Image = image;
                    Label label = new Label();
                    label.Name = $"{itemData.Name}_label";
                    label.Text = ItemStoredCount(item.ItemID());
                    Label label2 = new Label();
                    string rateLabel = ItemDropRate(item.ItemID());
                    label2.Text = rateLabel;
                    label2.Name = $"{itemData.Name}_Ratelabel";
                    button.Name = name;
                    Tuple<Label, Label> tuple = Tuple.Create(label, label2);
                    dataTagsChest.Add(tuple);
                    NumberedRateTag.Add(label2);
                    button.MouseHover += (s, e) => { Button_MouseHover(button, itemData); };
                    button.Click += (s, e) => { UpdateAcquriedCount(itemData, tuple); };
                    panel.Controls.Add(button);
                    panel.Height = 195;
                    panel.AutoSize = true;
                    panel.Controls.Add(label);
                    panel.Controls.Add(label2);
                    extra.Controls.Add(panel);

                    count++;
                }

                
            }

          
        }



        
    }
}
