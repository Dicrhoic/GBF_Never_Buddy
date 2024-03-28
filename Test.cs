using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.SQLClasses;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GBF_Never_Buddy
{
    public partial class Test : Form
    {
        string originalText;
        List<GameDataClasses.Character> _characterList;
        public Test()
        {
     
            InitializeComponent();
            originalText = "";
            label1.Text = originalText;
            _characterList = new List<GameDataClasses.Character>();
            FillTreeNode();

        }

        private void FillTreeNode()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Suppress repainting the TreeView until all the objects have been created.
            treeView1.BeginUpdate();
            // Clear the TreeView each time the method is called.
            treeView1.Nodes.Clear();
            LoadClassicAndPremium();
            LoadSeries("Grand");
            LoadSeries("12 Generals");
            LoadSeries("Valentine");
            LoadSeries("Halloween");
            LoadSeries("Summer/Yukata");
            LoadSeries("Holiday");
            // Reset the cursor to the default for all controls.
            Cursor.Current = Cursors.Default;

            // Begin repainting the TreeView.
            treeView1.EndUpdate();
            label1.Text = $"{Count()} characters obtained";
            originalText = label1.Text; 
        }

        private int Count()
        {
            int count = 0;  
            foreach(TreeNode node in treeView1.Nodes)
            {
                foreach(var n in node.Nodes)
                {
                    count++;
                }
            }
            return count;
        }

        private void LoadClassicAndPremium()
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Premium & Classic";
            treeView1.Nodes.Add("Premium");
            List<GameDataClasses.Character> list = CharacterData("Premium");
            List<GameDataClasses.Character> list1 = CharacterData("Classic");
            foreach (var character in list)
            {
                treeView1.Nodes[0].Nodes.Add(new TreeNode(character.name));

            }
            treeView1.Nodes.Add("Classic");
            foreach (var character in list1)
            {
                treeView1.Nodes[1].Nodes.Add(new TreeNode(character.name));

            }
        }


        private void LoadSeries(string series)
        {
            List<GameDataClasses.Character> list = CharacterData(series);
            System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();
            listView.View = View.Details;
            listView.GridLines = true;
            TreeNode node = new TreeNode();
            node.Text = series;
            node.Name = series;
            treeView1.Nodes.Add((TreeNode)node);
            foreach (var n in treeView1.Nodes)
            {
                Debug.WriteLine(n.ToString());
            }
            foreach (var character in list)
            {
                var result = treeView1.Nodes.OfType<TreeNode>()
                            .FirstOrDefault(node => node.Name.Equals(series));
                Debug.WriteLine(result);
                if (result != null)
                {
                    result.Nodes.Add(new TreeNode(character.name));
                }


            }

        }

        private void LoadListData(string series)
        {

            List<ListViewItem> list = CharacterDataList(series);
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Items.AddRange(list.ToArray());


            listView1.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Element", -2, HorizontalAlignment.Left);
            listView1.ItemActivate += (s, e) => ListView1_ItemActivate(listView1);


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
                            GachaCharacterDetails details = new(Cid, name, image, link, refId, element, series);
                            CharacterDetailsGacha characterDetailsGacha = new(details);
                            panel1.Controls.Clear();
                            characterDetailsGacha.Dock = DockStyle.Fill;
                            characterDetailsGacha.AutoSize = true;
                            panel1.Dock = DockStyle.Fill;
                            panel1.Controls.Add(characterDetailsGacha);
                        }
                    }
                    connection.Close();

                }

            }


        }



        private List<ListViewItem> CharacterDataList(string series)
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

        private List<GameDataClasses.Character> CharacterData(string series)
        {
            List<GameDataClasses.Character> list = new List<GameDataClasses.Character>();
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
                        GameDataClasses.Character character = new(name, element, series, image, link);
                        list.Add(character);

                    }
                }
            }
            return list;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            Debug.WriteLine("After select");
            Debug.WriteLine($"{treeView1.SelectedNode.Text}");
            string series = treeView1.SelectedNode.Text;
            LoadListData(series);
            CharacterSQLClass characterSQLClass = new CharacterSQLClass();
            int totalCharacters = characterSQLClass.TotalCharacterNumber(series);
            string count = $"{treeView1.SelectedNode.Nodes.Count}/{totalCharacters} {treeView1.SelectedNode.Text} characters obtained";
            label1.Text = $"{originalText}\n{count}";
            
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}
