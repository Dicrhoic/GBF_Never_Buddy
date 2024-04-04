using GBF_Never_Buddy.Classes.SQLClasses;
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

namespace GBF_Never_Buddy.Forms.GachaFroms
{
    public partial class UpdateGachaLog : Form
    {
        List<GachaLogData> gachas = new();
        List<SummonRow> summonRows = new();
        List<CharacterRow> characterRows = new();
        bool editPanelOn = false;

        public UpdateGachaLog()
        {
            InitializeComponent();
            gachas = Gachas();
            comboBox1.Items.AddRange(gachas.Select(x => x.id as object).ToArray());
            comboBox1.SelectedIndex = 0;
            editPanel.Visible = false;
            tableLayoutPanel1.Enabled = false;
            resultsPanel.Visible = false;

        }

        List<GachaLogData> Gachas()
        {
            List<GachaLogData> list = new List<GachaLogData>();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT ID, Date, Type, DrawCount 
                     FROM DrawInfo 
                     WHERE DrawCount IS NOT NULL";
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    int i;
                    string d;
                    char t;
                    int c;
                    while (result.Read())
                    {
                        i = result.GetInt32(0);
                        d = result.GetString(1);
                        t = result.GetString(2)[0];
                        c = result.GetInt32(3);
                        GachaLogData info = new(i, d, t, c);
                        list.Add(info);
                    }


                }
                connection.Close();
            }
            return list;
        }

        private void LoadData(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            var result = gachas[comboBox1.SelectedIndex];
            GachaDataDisplay dataDisplay = new GachaDataDisplay(result, this);
            panel2.Controls.Add(dataDisplay);
        }

        bool ExistsInDataBase(int id, int drawNumber)
        {
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT * FROM DrawCost 
                     INNER JOIN DrawYield ON DrawCost.ID=DrawYield.ID
                     WHERE DrawCost.DrawNumber = $i AND DrawID = $num";
                command.Parameters.AddWithValue("$i", id);
                command.Parameters.AddWithValue("$num", drawNumber);
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    Debug.WriteLine($"hasrows {result.HasRows}");
                    if (!result.HasRows)
                    {
                        return false;
                    }
                }

                connection.Close();
            }
            return true;
        }

        private void FindData(object sender, EventArgs e)
        {
            summonRows.Clear();
            characterRows.Clear();
            editPanel.Visible = false;
            resultsPanel.Visible = false;
            resultsPanel.Enabled = false;
            tableLayoutPanel1.Controls.Clear();
            int id = gachas[comboBox1.SelectedIndex].id;
            int drawNumber = drawNumCB.SelectedIndex + 1;
            bool exists = ExistsInDataBase(id, drawNumber);
            Debug.WriteLine($"{id}, {drawNumber}: {exists}");


            List<GachaYieldData> yields = ObtainedCharacters(id, drawNumber);
            if (yields.Count > 0)
            {

                button1.Text = "Edit Record";
                DrawDetail drawDetail = new(yields[0]);
                tableLayoutPanel1.Controls.Add(drawDetail);
                BalanceTable();
                var clist = drawDetail.CRows();
                var slist = drawDetail.SRows();
                characterRows.AddRange(clist);
                summonRows.AddRange(slist);
            }

            if (yields[0].Characters.Count == 0 && yields[0].Summons.Count == 0)
            {
                button1.Text = "Create Record";
                resultsPanel.Visible = true;

            }




        }

        void BalanceTable()
        {

            foreach (RowStyle s in tableLayoutPanel1.RowStyles)
            {
                s.SizeType = SizeType.AutoSize;
            }
        }

        List<GachaYieldData> Yields(int id, int drawNum)
        {
            List<GachaYieldData> gachaYields = new();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                      SELECT Character, Summon,Type FROM DrawCost 
                      INNER JOIN DrawYield ON DrawCost.ID=DrawYield.ID
                      WHERE DrawID=@i AND DrawCost.DrawNumber=@drawNum
                ";
                command.Parameters.AddWithValue("@i", id);
                command.Parameters.AddWithValue("@drawNum", drawNum);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        var c = reader.IsDBNull(0) ? "Empty" : reader.GetString(0);
                        var s = reader.IsDBNull(1) ? "Empty" : reader.GetString(1);
                        var t = reader.GetChar(2);
                        Debug.WriteLine(reader.IsDBNull(1) ? null : reader.GetString(1));
                        //GachaYieldData yield = new(c, s, drawNum, t);
                        Debug.WriteLine($"Added:{c},Summon:{s} to {drawNum}");
                        //gachaYields.Add(yield);

                    }
                }
                connection.Close();
            }
            return gachaYields;
        }

        List<GachaYieldData> ObtainedCharacters(int id, int drawNum)
        {
            List<GachaYieldData> gachaYields = new();
            List<string> list = new();
            List<string> list2 = new();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {

                var command = connection.CreateCommand();
                char t = 'M';
                command.CommandText =
                @"
                      SELECT DrawCost.ID, CharacterYield.Name, DrawCost.Type, DrawCost.DrawNumber
                      FROM DrawCost 
                      INNER JOIN CharacterYield ON CharacterYield.ID == DrawCost.ID 
                      WHERE DrawID=@i AND DrawCost.DrawNumber=@drawNum
                ";
                command.Parameters.AddWithValue("@i", id);
                command.Parameters.AddWithValue("@drawNum", drawNum);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        var c = reader.IsDBNull(1) ? "Empty" : reader.GetString(1);
                        t = reader.GetChar(2);
                        Debug.WriteLine(reader.IsDBNull(1) ? null : reader.GetString(1));
                        list.Add(c);

                    }
                }
                var command1 = connection.CreateCommand();
                command1.CommandText =
                @"
                      SELECT DrawCost.ID, SummonYield.Name, DrawCost.Type, DrawCost.DrawNumber
                      FROM DrawCost 
                      INNER JOIN SummonYield ON SummonYield.ID == DrawCost.ID 
                      WHERE DrawID=@i AND DrawCost.DrawNumber=@drawNum
                ";
                command1.Parameters.AddWithValue("@i", id);
                command1.Parameters.AddWithValue("@drawNum", drawNum);
                reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        var c = reader.IsDBNull(1) ? "Empty" : reader.GetString(1);
                        Debug.WriteLine(reader.IsDBNull(1) ? null : reader.GetString(1));
                        list2.Add(c);

                    }
                }
                Debug.WriteLine($"C:{list.Count}, S:{list2.Count}");
                GachaYieldData yield = new(list, list2, drawNum, t);
                gachaYields.Add(yield);
                connection.Close();
            }

            return gachaYields;
        }

        private void EditData(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = true;
            resultsPanel.Enabled = true;
            switch (editPanelOn)
            {
                case true:
                    editPanelOn = false;
                    editPanel.Visible = false;
                    break;
                case false:
                    editPanelOn = true;
                    editPanel.Visible = true;
                    break;
            }
        }

        private void RemoveRow(object sender, EventArgs e)
        {

        }

        private void ValidateText(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (e.KeyChar == (char)Keys.Enter)
            {
                string s = tb.Text;
                if (s.Length > 0)
                {   
                    if (s.Contains(','))
                    {
                        PopulateCheckList(SplitStrings(s));
                    }
                    else
                    {
                        PopulateCheckList(s);
                    }
                }
            
            }
        }

        void PopulateCheckList(string s)
        {
            checkedListBox1.Items.Add(s);
        }
        void PopulateCheckList(List<string> s)
        {

            foreach (string str in s)
            {
                Debug.WriteLine(str);
                checkedListBox1.Items.Add(str);
            }
        }


        List<string> SplitStrings(string s)
        {
            List<string> strings = new List<string>();
            string[] splits = s.Split(',');
            strings.AddRange(splits);
            return strings;
        }

        private void ValidateText(object sender, KeyEventArgs e)
        {

            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>
            {
                { "character", SortedList<string, Character> },
                { "summon", SortedList<string, Summon>  }
            };
            TextBox tb = (TextBox)sender ;
            string type = tb.Tag.ToString();
            if(tb.Text.Length > 0 && e.KeyCode == Keys.Enter)
            {   
                CharacterSQLClass characterSQLClass = new CharacterSQLClass();  
                SummonSQLClass summonSQLClass = new SummonSQLClass();
                string s = tb.Text;
                if (s.Contains(','))
                {
                    PopulateCheckList(SplitStrings(s));
                }
                else
                {
                    PopulateCheckList(s);
                }
            }
        }
    }



}
