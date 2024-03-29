﻿using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using GBF_Never_Buddy.Classes.SQLClasses;
using GBF_Never_Buddy.GachaForms;
using GBF_Never_Buddy.Screens;
using Microsoft.Data.Sqlite;
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
using static GBF_Never_Buddy.Classes.GameDataClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GBF_Never_Buddy.Forms.GachaFroms
{
    public partial class FreebieLogForm : Form
    {
        ItemComparer comparer;
        GachaHandler gachaHandler = new();
        GachaSQLHelper gachaSQL = new GachaSQLHelper();
        List<GachaTable> gachaTables;
        int drawID = -1;
        List<string> exceptionSummonsStrings = new List<string>();
     
        public FreebieLogForm()
        {   
            InitializeComponent();
            comparer = new ItemComparer();
            listView1.ListViewItemSorter = comparer;
            gachaTables = gachaSQL.FreeGachas();
            LoadList();
            exceptionSummonsStrings.Add("Poseidon, the Tide Father");
        }

        public void LoadList()
        {
          
            InitialiseListView();
            listView1.ItemSelectionChanged += LoadDetailsSide;
            listView1.SelectedIndexChanged += LoadGachaData;
            resultsTable.Visible = false;
        }

        private void LoadGachaData(object? sender, EventArgs e)
        {
            //DisplayPanel();
            DisplayDetails();   
        }

        private void DisplayDetails()
        {
            resultsTable.Controls.Clear();
            resultsTable.Visible = true;
            resultsTable.AutoScroll = true;
            int size = DrawCount(drawID);
            GameDataClasses.GachaResults results = new(drawID,size);
            List<GachaYield> yields = results.GachaYields;
            Debug.WriteLine($"Gacha count: {yields.Count + 1}, DrawID: {drawID}");
            PopulateData(yields, size);
        }

        void PrintYields(List<GachaYield> yields)
        {
            foreach (GachaYield yield in yields)
            {
                Debug.WriteLine($"{yield.DrawNumber}, {yield.Summon}, {yield.Character}");
            }
        }


        private void PopulateData(List<GachaYield> yields, int size)
        {

            for (int i = 0; i < size; i++)
            {
                int index = i + 1;
                string text = $"Draw Number: {index}\n";
                GachaData gachaData = new();
                var collection = yields.Where(x => x.DrawNumber == index);
                gachaData.UpdateCaption(text);
                foreach (var item in collection)
                {
                    Debug.WriteLine($"{index}. {item.Summon}, {item.Character}");
                    
                }
            }         
        }

        private void LoadSummonData(string summon)
        {

        }

        private void GenerateDrawNumberYield(IEnumerable<GachaYield> collection, GachaData gachaData)
        {
            foreach (var item in collection)
            {
                GachaYield yield = (GachaYield)item;
                Debug.WriteLine($"S: {yield.Summon} C: {yield.Character}");
                if (string.IsNullOrEmpty(yield.Character) && !string.IsNullOrEmpty(yield.Summon))
                {
                    string caption = $"No SSR obtained from draw #{yield.DrawNumber}";
                    RichTextBox tb = new RichTextBox();
                    tb.Text = caption;
                    tb.Dock = DockStyle.Top;
                    tb.Height = 40;
                    tb.ReadOnly = true;
                    resultsTable.Controls.Add(tb);

                }
                else
                {

                    if (!string.IsNullOrEmpty(yield.Character))
                    {
                        CharacterSQLClass characterSQL = new();

                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.AutoScroll = true;
                        panel.Dock = DockStyle.Fill;
                        panel.FlowDirection = FlowDirection.LeftToRight;
                        Character character = characterSQL.QueriedCharacter(yield.Character);
                        string link = character.link;
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        pictureBox.Load(character.image);
                        pictureBox.Dock = DockStyle.Fill;
                        pictureBox.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                        pictureBox.MouseHover += (s, e) => { ImageHoverFunction(pictureBox, character.name); };
                        gachaData.InsertImage(pictureBox);

                    }
                    if (!string.IsNullOrEmpty(yield.Summon))
                    {
                        bool load = true;
                        string sum = yield.Summon;
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.AutoScroll = true;
                        panel.Dock = DockStyle.Fill;
                        panel.FlowDirection = FlowDirection.LeftToRight;
                        SummonSQLClass summonSQL = new();
                        Summon summon = summonSQL.QueriedData(sum);
                        string link = summon.link;
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        try
                        {
                            pictureBox.Load(summon.image);

                            pictureBox.Dock = DockStyle.Fill;
                            pictureBox.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                            pictureBox.MouseHover += (s, e) => { ImageHoverFunction(pictureBox, summon.name); };
                            panel.Controls.Add(pictureBox);
                            gachaData.InsertImage(pictureBox);
                        }
                        catch (Exception ex)
                        {
                            load = false;
                            Debug.WriteLine($"{load} :{ex.Message}");

                        }
                        if (!load)
                        {
                            Label label = new Label();
                            label.Text = summon.name;
                            label.Dock = DockStyle.Bottom;
                            label.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                            label.MouseHover += (s, e) => { ImageHoverFunction(pictureBox, summon.name); };
                            Debug.WriteLine("Added label");
                            resultsTable.Controls.Add(label);
                        }

                    }
                    resultsTable.Controls.Add(gachaData);
                }
            }
        }

        private int DrawCount(int id)
        {
            int count = 0;
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {

                var command = connection.CreateCommand();
                command.CommandText =
                    @"  
                        SELECT DrawCount
                        FROM DrawInfo
                        WHERE DrawInfo.ID = $id
                    ";
                command.Parameters.AddWithValue("$id", id);
                connection.Open();  
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                connection.Close();
             }
            return count; 

        }

        private void DisplayPanel()
        {
            resultsTable.Controls.Clear();
            resultsTable.Visible = true;
            resultsTable.AutoScroll = true;
            List<GachaDetails> gachaDetails = gachaSQL.GachaDetails(drawID);
            Debug.WriteLine($"Gacha count: {gachaDetails.Count}, DrawID: {drawID}");
            foreach (GachaDetails details in gachaDetails)
            {
               
                string text = $"Draw Number: {details.drawNumber}\n";
                GachaData gachaData = new();
                gachaData.UpdateCaption(text);
               
                if (details.summons == "" && details.characters == "")
                {
                    string caption = $"No SSR obtained from draw #{details.drawNumber}";
                    RichTextBox tb = new RichTextBox();
                    tb.Text = caption;
                    tb.Dock = DockStyle.Top;
                    tb.Height = 40;
                    tb.ReadOnly = true;
                    resultsTable.Controls.Add(tb);
          
                }
                else
                {
  
                    if (details.characters != "" && !string.IsNullOrEmpty(details.characters))
                    {
                        CharacterSQLClass characterSQL = new();
                        string[] chars = details.characters.Split(",");
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.AutoScroll = true;
                        panel.Dock = DockStyle.Fill;
                        panel.FlowDirection = FlowDirection.LeftToRight;
                        foreach (string c in chars)
                        {
                            Debug.WriteLine($"Char: {c}");
                            Character character = characterSQL.QueriedCharacter(c);
                            string link = character.link;
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                            pictureBox.Load(character.image);
                            pictureBox.Dock = DockStyle.Fill;
                            pictureBox.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                            pictureBox.MouseHover += (s, e) => { ImageHoverFunction(pictureBox, character.name); };
                            gachaData.InsertImage(pictureBox);
                        }
                        resultsTable.Controls.Add(gachaData);
                    }
                    if (details.summons != "")
                    {   
                        string sum = details.summons;   
                        FlowLayoutPanel panel = new FlowLayoutPanel();
                        panel.AutoScroll = true;
                        panel.Dock = DockStyle.Fill;
                        panel.FlowDirection = FlowDirection.LeftToRight;
                        SummonSQLHelper summonSQL = new();
                        foreach(string su in exceptionSummonsStrings)
                        {
                            Debug.WriteLine($"su:{su}, sum:{sum}");
                            if(sum.Contains(su))
                            {
                                string target = su;
                                sum = sum.Replace(su, "");
                                Debug.WriteLine($"su:{su}, target:{target}");
                                Summon summon = summonSQL.QueriedSummon(target);
                                string link = summon.link;
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

                                pictureBox.Load(summon.image);
                                pictureBox.Dock = DockStyle.Fill;
                                pictureBox.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                                pictureBox.MouseHover += (s, e) => { ImageHoverFunction(pictureBox, summon.name); };
                                panel.Controls.Add(pictureBox);

                            }
                        }
                        if(!string.IsNullOrEmpty(sum))
                        {
                            string[] s = sum.Split(",");
                            foreach (string c in s)
                            {
                                Debug.WriteLine($"Summon: {c}");
                                Summon summon = summonSQL.QueriedSummon(c);
                                string link = summon.link;
                                PictureBox pictureBox = new PictureBox();
                                pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

                                pictureBox.Load(summon.image);
                                pictureBox.Dock = DockStyle.Fill;
                                pictureBox.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                                pictureBox.MouseHover += (s, e) => { ImageHoverFunction(pictureBox, summon.name); };
                                gachaData.InsertImage(pictureBox);
                            }
                        }

                
                        resultsTable.Controls.Add(gachaData);
          
                    }
                }
            
            

                Debug.WriteLine($"id: {details.id} draw id: {details.drawId}, " +
                    $" Characters: {details.characters} Sum: {details.summons}" +
                    $" Crystals: {details.crystalsUsed} Draw Num: {details.drawNumber}");
            }
        }

        private void LoadDetailsSide(object? sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            ListView parent = (ListView)sender;
            int index = e.ItemIndex;
            drawID = Int32.Parse(parent.Items[index].SubItems[2].Text);
        }

        private string[] CrystalCount(List<GachaTable> details)
        {
            string[] strings = new string[details.Count];
            int index = 0;
            foreach (GachaTable table in details)
            {
                int drawID = table.drawId;
                int amount = 0;
                List<GachaDetails> gachaDetails = gachaSQL.GachaDetails(drawID);
                foreach (GachaDetails gacha in gachaDetails)
                {
                    amount = gacha.crystalsUsed;
                    strings[index] = amount.ToString();
                }
                index++;

            }
            return strings;
        }

        private void InitialiseListView()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;

            string[] idArry = gachaTables.Select(x => x.id.ToString()).ToArray();
            string[] arry2 = gachaTables.Select(x => x.drawId.ToString()).ToArray();
            string[] arry1 = gachaTables.Select(x => x.date).ToArray();
            List<ListViewItem> name = new List<ListViewItem>();
            for (int i = 0; i < arry1.Length; i++)
            {
                ListViewItem item = new ListViewItem(arry1[i], i);
                item.SubItems.Add(idArry[i]);
                item.SubItems.Add(arry2[i]);
                name.Add(item);
            }
            listView1.Columns.Add("Date", -2, HorizontalAlignment.Left);
            listView1.Items.AddRange(name.ToArray());
        }

        private void SortListView(object? sender, ColumnClickEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            Debug.WriteLine($"{e.Column} clicked");
            int columnIndex = e.Column;
            if (e.Column == comparer.SortColumn)
            {

                if (comparer.SortColumn == columnIndex)
                {

                }
                // Reverse the current sort direction for this column.
                if (comparer.Order == SortOrder.Ascending)
                {
                    comparer.Order = SortOrder.Descending;
                }
                else
                {
                    comparer.Order = SortOrder.Ascending;
                }
            }
            else
            {
                comparer.SortColumn = e.Column;
                comparer.Order = SortOrder.Ascending;
            }
            ListView parent = (ListView)sender;
            parent.Sort();
        }
        private void ImageClickFunction(PictureBox imageHolder, string link)
        {
            Debug.WriteLine("Click");
            string url = link;
            System.Diagnostics.Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void ImageHoverFunction(PictureBox imageHolder, string name)
        {
            Debug.WriteLine("Hover");
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(imageHolder, name);

        }

        private void LoadNewDraw(object sender, EventArgs e)
        {
            gachaHandler.mode = Mode.Free;
            gachaHandler.CreateData();
            Debug.WriteLine($"Mode: {gachaHandler.mode}");
            GachaForm gachaForm = new(gachaHandler);
            gachaForm.ShowDialog();

        }

        private void LoadRoulette(object sender, EventArgs e)
        {
            gachaHandler.mode = Mode.Roulette;
            gachaHandler.CreateData();
            RouletteLog rouletteForm = new RouletteLog(gachaHandler);
            rouletteForm.Show();
        }

    }
}
