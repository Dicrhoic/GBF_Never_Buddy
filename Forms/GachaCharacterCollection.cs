using GBF_Never_Buddy.Screens;
using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GBF_Never_Buddy.Classes.GameDataClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GBF_Never_Buddy.Forms
{
    public partial class GachaCharacterCollection : Form
    {

        public GachaCharacterCollection()
        {
            InitializeComponent();
            panel2.AutoScroll = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.AutoSize = true;
            this.AutoScroll = true;
            LoadAll();
        

        }

        private void UpdateFilters(object sender, EventArgs e)
        {   
       
            panel2.Controls.Clear();
            List<CheckBox> filters = CheckBoxes();
            if(filters.Count == 0)
            {
                LoadAll();
            }
            else
            {
                foreach(CheckBox cb in filters)
                {
                    CreateTable(cb.Text);
                }
            }
            /*
            if (checkBox1.Checked)
            {
                LoadClassicAndPremium();
            }
            if (checkBox2.Checked)
            {
                LoadSeries("Grand");
            }
            if (checkBox3.Checked)
            {
                LoadSeries("12 Generals");
            }
            if (checkBox4.Checked)
            {
                LoadSeries("Valentine");
            }
            if (checkBox5.Checked)
            {
                LoadSeries("Halloween");
            }
            if (checkBox6.Checked)
            {
                LoadSeries("Summer/Yukata");
            }
            if (checkBox7.Checked)
            {
                LoadSeries("Holiday");
            }
            else
            {
                LoadAll();
            }
            */
        }

        private List<CheckBox> CheckBoxes()
        {   
            List<CheckBox> list = new List<CheckBox>();
            foreach (Control control in panel1.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    if (checkBox.Checked)
                    {

                        list.Add(checkBox);
                    }
                }
            }
         
    
            return list;    
        }

        private void CreateTable(string series)
        {
            switch (series)
            {
                case "Premium/Classic":
                    LoadClassicAndPremium();
                    break;
                case "Grand":
                    LoadSeries("Grand");
                    break;
                case "12 Generals":
                    LoadSeries("12 Generals");
                    break;
                case "Valentine":
                    LoadSeries("Valentine");
                    break;
                case "Halloween":
                    LoadSeries("Halloween");
                    break;
                case "Summer/Yukata":
                    LoadSeries("Summer/Yukata");
                    break;
                case "Holiday":
                    LoadSeries("Holiday");
                    break;
            }
        }

        private void LoadAll()
        {
            LoadClassicAndPremium();
            LoadSeries("Grand");
            LoadSeries("12 Generals");
            LoadSeries("Valentine");
            LoadSeries("Halloween");
            LoadSeries("Summer/Yukata");
            LoadSeries("Holiday");
            Debug.WriteLine($"tables made {panel2.Controls.Count}");
        }

        private void LoadClassicAndPremium()
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Premium & Classic";
            List<ListViewItem> list = CharacterData("Premium");
            List<ListViewItem> list1 = CharacterData("Classic");
            System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();
            listView.View = View.Details;
            listView.GridLines = true;
            listView.Items.AddRange(list.ToArray());
            listView.Items.AddRange(list1.ToArray());
            listView.Dock = DockStyle.Fill;
            listView.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Element", -2, HorizontalAlignment.Left);
            groupBox.Text = $"Premium and Classic";
            //groupBox.Controls.Add(listView);
            Panel panel = new();
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(listView);
            groupBox.Controls.Add(panel);
            groupBox.Dock = DockStyle.Top;
            panel2.Controls.Add(groupBox);



            /*
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowOnly;
            string series = "Classic";
            List<PictureBox> c = CharacterImages(series);
            AddImagesIntoTable(c, flowLayoutPanel);
            series = "Premium";
            List<PictureBox> images = CharacterImages(series);
            AddImagesIntoTable(images, flowLayoutPanel);
            flowLayoutPanel.Dock = DockStyle.Fill;
            groupBox.Controls.Add(flowLayoutPanel);
            groupBox.Dock = DockStyle.Fill;
            panel2.Controls.Add(groupBox);
            */
        }

        private void LoadSeries(string series)
        {
            List<ListViewItem> list = CharacterData(series);
            System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();
            listView.View = View.Details;
            listView.GridLines = true;
            listView.Items.AddRange(list.ToArray());

            GroupBox groupBox = new GroupBox();
            groupBox.Text = $"series";

            listView.Dock = DockStyle.Fill;
            listView.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Element", -2, HorizontalAlignment.Left);
            listView.ItemActivate += (s, e) => ListView1_ItemActivate(listView);
            groupBox.Text = $"{series}";
            
            //groupBox.Controls.Add(listView);
            groupBox.Dock = DockStyle.Top;
            Panel panel = new();
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(listView);
            groupBox.Controls.Add(panel);
            groupBox.Dock = DockStyle.Top;
            panel2.Controls.Add(groupBox);

            /*        
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowOnly;
            List<PictureBox> images = CharacterImages(series);
            AddImagesIntoTable(images, flowLayoutPanel);
            groupBox.Controls.Add(flowLayoutPanel);
            */


        }

        private void ListView1_ItemActivate(System.Windows.Forms.ListView listView)
        {
            MessageBox.Show("You are in the ListView.ItemActivate event.");
            if (listView.SelectedItems.Count > 0)
            {
                var item = listView.SelectedItems[0]; //the second time you will get the selected item here
                var pin = item;
                int id = Int32.Parse(item.SubItems[2].Text);
                Debug.WriteLine($"{item.Text} Ref id: {id}");
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                       SELECT GachaCharacters.Id, GachaCharacters.name, GachaCharacters.Image, 
                            GachaCharacters.Link, GachaCharacters.Element, ObtainedSSRCharacters.id,
                            GachaCharacters.Series
                       FROM GachaCharacters
                       INNER JOIN ObtainedSSRCharacters 
                       ON GachaCharacters.Id=ObtainedSSRCharacters.CharacterID
                       WHERE ObtainedSSRCharacters.id=$id
                        ";
                    command.Parameters.AddWithValue("$id", id);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int Cid = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string image = reader.GetString(2);
                            string link = reader.GetString(3);
                            string element = reader.GetString(4);
                            int refId = reader.GetInt32(5);
                            string series = reader.GetString(6);
                            GachaCharacterDetails details = new(Cid, name, image, link, refId, element,series);
                            CharacterDetailsGacha characterDetailsGacha = new(details);
                            panel3.Controls.Clear();
                            characterDetailsGacha.Dock = DockStyle.Fill;
                            characterDetailsGacha.AutoSize = true;
                            panel3.Dock = DockStyle.Fill;            
                            panel3.Controls.Add(characterDetailsGacha);
                        }
                    }
                    connection.Close();
               
                }

            }


        }

    
        private List<ListViewItem> CharacterData(string series)
        {
            List<ListViewItem> list = new List<ListViewItem>();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                       SELECT GachaCharacters.Id, GachaCharacters.name, GachaCharacters.Image, 
                            GachaCharacters.Link, GachaCharacters.Element, ObtainedSSRCharacters.id
                       FROM GachaCharacters
                       INNER JOIN ObtainedSSRCharacters 
                       ON GachaCharacters.Id=ObtainedSSRCharacters.CharacterID
                       WHERE GachaCharacters.Series=$series
                        ";
                command.Parameters.AddWithValue("$series", series);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string image = reader.GetString(2);
                        string link = reader.GetString(3);
                        string element = reader.GetString(4);
                        int refId = reader.GetInt32(5);    
                        Debug.WriteLine($"Creating Charcter: {name}");
                        ListViewItem listViewItem = new ListViewItem(name);
                        listViewItem.SubItems.Add(element);
                        listViewItem.SubItems.Add(refId.ToString());
                        Debug.WriteLine($"Created Charcter: {name}");
                        list.Add(listViewItem);
                    
                    }
                }
            }
            return list;
        }

        private List<PictureBox> CharacterImages(string series)
        {
            List<PictureBox> pictures = new List<PictureBox>();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                       SELECT ObtainedSSRCharacters.Id, GachaCharacters.name, GachaCharacters.Image, 
                            GachaCharacters.Link
                       FROM GachaCharacters
                       INNER JOIN ObtainedSSRCharacters 
                       ON GachaCharacters.Id=ObtainedSSRCharacters.CharacterID
                       WHERE GachaCharacters.Series=$series
                        ";
                command.Parameters.AddWithValue("$series", series);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(1);
                        string image = reader.GetString(2);
                        string link = reader.GetString(3);
                        Debug.WriteLine($"Creating Charcter: {name}");
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        //pictureBox.Load("https://cdn.iconscout.com/icon/free/png-256/free-polygon-logo-dark-5728879-4816869.png");
                        pictureBox.Load(image);
                        pictureBox.Dock = DockStyle.Fill;
                        //pictureBox.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                        pictureBox.MouseHover += (s, e) => { ImageHoverFunction(pictureBox, name); };
                        pictures.Add(pictureBox);
                        Debug.WriteLine($"Created Charcter: {name}");

                    }
                }
            }
            return pictures;
        }

        private void ImageClickFunction(PictureBox imageHolder, string link)
        {
            string url = link;
            System.Diagnostics.Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void ImageHoverFunction(PictureBox imageHolder, string name)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(imageHolder, name);

        }

        private void AddImagesIntoTable(List<PictureBox> pictures, FlowLayoutPanel panel)
        {
            foreach (PictureBox pictureBox in pictures)
            {
                panel.Controls.Add(pictureBox);
            }
        }

    
    }
}
