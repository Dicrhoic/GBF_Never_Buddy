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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GBF_Never_Buddy.Forms.GachaFroms
{
    public partial class DrawDetail : UserControl
    {
        Dictionary<char, string> keyValuePairs = new Dictionary<char, string>();
        List<CharacterRow> characterRows = new List<CharacterRow>();  
        List<SummonRow> summonRows = new List<SummonRow>(); 
        public DrawDetail(GachaYieldData yield)
        {
            InitializeComponent();
            keyValuePairs.Add('M', "10 Draw");
            keyValuePairs.Add('S', "Single Draw");
            string type = keyValuePairs[yield.type];
            if(yield.Characters.Count < 1)
            {
                groupBox1.Hide();   
            }
            if (yield.Summons.Count < 1)
            {
                groupBox2.Hide();
            }
            groupBox1.Text = $"Characters";
            groupBox2.Text = $"Summons";
            LoadCharacterTB(yield.Characters);
            LoadSummonTB(yield.Summons);   
            
        }

        void LoadCharacterTB(List<string> list)
        {
            CharacterSQLClass characterSQLClass = new CharacterSQLClass();
            List<Character> characters = characterSQLClass.CharacterList();
            var charSource = new AutoCompleteStringCollection();
            charSource.AddRange(characters.Select(x => x.name).ToArray());
            charSource.Add("Empty");

            foreach (string c in list)
            {
                CharacterRow characterRow = new(c);
        
                TextBox tb = characterRow.box();
                tb.AutoCompleteCustomSource = charSource;
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                characterRow.Dock = DockStyle.Top;
                characterRows.Add(characterRow);
                groupBox1.Controls.Add(characterRow);
            }
        }

        public List<CharacterRow> CRows()
        {
            return characterRows;
        }
        public List<SummonRow> SRows()
        {
            return summonRows;
        }
        void LoadSummonTB(List<string> list)
        {
            SummonSQLClass summonSQLClass = new SummonSQLClass();
            List<Summon> summons = summonSQLClass.GachaList();

            var sumSource = new AutoCompleteStringCollection();

            sumSource.AddRange(summons.Select(x => x.name).ToArray());
            sumSource.Add("Empty");
            foreach (string c in list)
            {
                SummonRow summonRow = new(c);
                var charSource = new AutoCompleteStringCollection();
                TextBox tb = summonRow.box();
                tb.AutoCompleteCustomSource = charSource;
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                summonRow.Dock = DockStyle.Top;
                summonRows.Add(summonRow);
                groupBox2.Controls.Add(summonRow);
            }
        }

        public List<CharacterRow> CTBs()
        {
            return characterRows;
        }

        public DrawDetail()
        {
            InitializeComponent();
            keyValuePairs.Add('M', "10 Draw");
            keyValuePairs.Add('S', "Single Draw");

            CharacterSQLClass characterSQLClass = new CharacterSQLClass();
            List<Character> characters = characterSQLClass.CharacterList();
            SummonSQLClass summonSQLClass = new SummonSQLClass();
            List<Summon> summons = summonSQLClass.GachaList();
            
            var charSource = new AutoCompleteStringCollection();
            var sumSource = new AutoCompleteStringCollection();
            charSource.AddRange(characters.Select(x => x.name).ToArray());
            charSource.Add("Empty");
            sumSource.AddRange(summons.Select(x => x.name).ToArray());
            sumSource.Add("Empty");
            /*
            textBox1.AutoCompleteCustomSource = charSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteCustomSource = sumSource;
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            */

        }




    }
}
