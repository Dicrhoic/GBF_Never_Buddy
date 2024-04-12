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
        List<Summon> summonInputs = new();
        List<Character> characterInput = new();
        List<Summon> summonOutputs = new();
        List<Character> characterOutputs = new();
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
            characterInput.Clear();
            summonInputs.Clear();
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
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

        void PopulateCheckList(string s, List<Character> list)
        {
            var res = ValidatedResult(list, s);
            checkedListBox1.Items.AddRange(res.Select(x => x.name).ToArray());
        }

        void PopulateCheckList(string s, List<Summon> list)
        {
            var res = ValidatedResult(list, s);
            checkedListBox1.Items.AddRange(res.Select(x => x.name).ToArray());
        }
        void PopulateCheckList(List<string> s)
        {

            foreach (string str in s)
            {
                Debug.WriteLine(str);
                checkedListBox1.Items.Add(str);
            }
        }

        void PopulateCheckList(List<string> s, List<Character> list)
        {

            List<Character> results = ValidatedResullts(list, s);
            Debug.WriteLine($"\n");

            Debug.WriteLine($"List Count: {characterInput.Count}");
            if (characterInput.Count > 0)
            {
                var newAdditions = characterInput.Except(characterInput).ToList();
                checkedListBox1.Items.AddRange(newAdditions.Select(x => x.name).ToArray());
            }
            else
            {
                characterInput.AddRange(results);
                Debug.WriteLine($"List Count: {characterInput.Count}");
                characterInput = characterInput.Distinct(new CharacterComparer()).ToList();
                checkedListBox1.Items.AddRange(characterInput.Select(x => x.name).ToArray());
            }
            resultsBox.Text = "";
        }

        void PopulateCheckList(List<string> s, List<Summon> list)
        {
            PrintList(s);
            List<Summon> results = ValidatedResullts(list, s);

            if (summonInputs.Count > 0)
            {
                var newAdditions = summonInputs.Except(summonInputs).ToList();
                checkedListBox2.Items.AddRange(newAdditions.Select(x => x.name).ToArray());
            }
            else
            {
                summonInputs.AddRange(results);
                summonInputs = summonInputs.Distinct(new SummonComparer()).ToList();
                checkedListBox2.Items.AddRange(summonInputs.Select(x => x.name).ToArray());
            }
            summonRes.Text = "";
        }


        void PrintList(List<string> list)
        {
            foreach (string s in list)
            {
                Debug.WriteLine($"{s}");
            }
        }


        List<Character> ValidatedResult(List<Character> list, string query)
        {
            List<Character> results = new List<Character>();

            var index = list.Where(x => x.name == query);

            if (index.Count() > 0)
            {
                Character c = index.First();
                results.Add(c);
            }

            return results;
        }

        List<Summon> ValidatedResult(List<Summon> list, string query)
        {
            List<Summon> results = new List<Summon>();

            var index = list.Where(x => x.name == query);

            if (index.Count() > 0)
            {
                Summon c = index.First();
                results.Add(c);
            }

            return results;
        }

        List<Character> ValidatedResullts(List<Character> list, List<string> queries)
        {
            List<Character> results = new List<Character>();

            foreach (string str in queries)
            {
                var index = list.Where(x => x.name == str);

                if (index.Count() > 0)
                {
                    Character c = index.First();
                    results.Add(c);
                }
            }
            return results;
        }
        List<Summon> ValidatedResullts(List<Summon> list, List<string> queries)
        {
            List<Summon> results = new List<Summon>();
            foreach (string str in queries)
            {
                var index = list.Where(x => x.name == str);

                Debug.Write($"Index of {str}: {index}");
                if (index.Count() > 0)
                {
                    Summon c = index.First();
                    results.Add(c);
                }
            }
            return results;
        }


        //Change binary search to SortedList<>;
        int index(List<Summon> list, string str)
        {
            int min = 0;
            int max = list.Count - 1;
            while (min <= max)
            {
                int mid = (max + min) / 2;
                Debug.WriteLine(list[mid].name);
                if (list[mid].name != str)
                {
                    min = mid + 1;
                }
                else
                    max = mid - 1;
                if (list[mid].name == str)
                {
                    return mid;
                }
            }

            return -1;
        }

        int index(List<Character> list, string str)
        {
            int min = 0;
            int max = list.Count - 1;
            Debug.WriteLine(list.Count);
            while (min <= max)
            {
                int mid = (max + min) / 2;
                Debug.WriteLine(list[mid].name);
                if (list[mid].name == str)
                {
                    Debug.WriteLine($"Found {str} at {mid}");
                    return mid;
                }
                else if (list[mid].name != str)
                {
                    min = mid + 1;
                }
                else
                    max = mid - 1;

            }

            return -1;
        }

        List<string> SplitStrings(string s)
        {
            List<string> strings = new List<string>();
            string[] splits = s.Split(',');
            foreach (string str in splits)
            {
                string str1 = str;
                str1 = str.Trim();
                strings.Add(str1);
            }
            return strings;
        }

        private void ValidateText(object sender, KeyEventArgs e)
        {
            CharacterSQLClass characterSQLClass = new CharacterSQLClass();
            SummonSQLClass summonSQLClass = new SummonSQLClass();
            List<Character> characters = characterSQLClass.CharacterList();
            List<Summon> summons = summonSQLClass.GachaList();

            TextBox tb = (TextBox)sender;
            string type = tb.Tag.ToString();
            if (tb.Text.Length > 0 && e.KeyCode == Keys.Enter)
            {

                string s = tb.Text;
                if (s.Contains(','))
                {
                    var l = SplitStrings(s);

                    switch (type)
                    {
                        case "character":
                            PopulateCheckList(l, characters);
                            break;
                        case "summon":
                            PopulateCheckList(l, summons);
                            break;
                    }
                }
                else
                {
                    switch (type)
                    {
                        case "character":
                            PopulateCheckList(s, characters);
                            break;
                        case "summon":
                            PopulateCheckList(s, summons);
                            break;
                    }
                }
            }

        }



        private void resultsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RemoveInput(object sender, KeyEventArgs e)
        {
            CheckedListBox listBox = (CheckedListBox)sender;
            if (e.KeyCode == Keys.Delete && listBox.Items.Count > 0)
            {
                var selectedItem = listBox.SelectedIndex;
                if (selectedItem != -1)
                {
                    listBox.Items.Remove(selectedItem);
                }
            }
        }

        private void UpdateCheckedList(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox listBox = (CheckedListBox)sender;
            if(listBox.Tag != null)
            {
                string type = listBox.Tag.ToString();
                switch (type)
                {
                    case "character":
                        characterOutputs.Clear();
                        List<Character> characters = listBox.CheckedItems.OfType<Character>().ToList();
                        characterOutputs = characters;
                        break;
                    case "summon":
                        summonOutputs.Clear();
                        List<Summon> summons = listBox.CheckedItems.OfType<Summon>().ToList();
                        summonOutputs = summons;    
                        break;
                }
            }
        }

      
    }



}
