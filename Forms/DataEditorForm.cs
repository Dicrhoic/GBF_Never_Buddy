using GBF_Never_Buddy.Classes.SQLClasses;
using GBF_Never_Buddy.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using GBF_Never_Buddy.Classes.GachaClasses;
using System.Diagnostics;
using System.Collections;

namespace GBF_Never_Buddy.Forms
{
    public partial class DataEditorForm : Form
    {
        private System.Windows.Forms.ErrorProvider nameErrorProvider;
        private System.Windows.Forms.ErrorProvider seriesErrorProvider;
        private System.Windows.Forms.ErrorProvider elementErrorProvider;
        private ErrorProvider imageErrorProvider;
        private ErrorProvider linkErrorProvider;
        CharacterSQLClass characterSQLClass = new();
        CharacterSQLHelper characterSQLHelper = new();
        SummonSQLHelper summonSQLHelper = new();
        List<GameDataClasses.Character>? characterList;
        List<GameDataClasses.Summon>? summonsList;
        List<string> seriesS = new List<string>();
        List<string> seriesC = new List<string>();
        List<string> names = new();
        Hashtable characters;

        int mode = -1;
        public DataEditorForm()
        {
            InitializeComponent();
            nameErrorProvider = new System.Windows.Forms.ErrorProvider();
            nameErrorProvider.SetIconAlignment(nameTB, ErrorIconAlignment.MiddleRight);
            nameErrorProvider.SetIconPadding(nameTB, 2);
            nameErrorProvider.BlinkRate = 1000;
            nameErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            nameTB.Validated += new System.EventHandler(name_validated);


            seriesErrorProvider = new System.Windows.Forms.ErrorProvider();
            seriesErrorProvider.SetIconAlignment(this.comboBox2, ErrorIconAlignment.MiddleRight);
            seriesErrorProvider.SetIconPadding(this.comboBox2, 2);
            seriesErrorProvider.BlinkRate = 1000;
            seriesErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            comboBox2.Validated += new System.EventHandler(series_validated);

            elementErrorProvider = new System.Windows.Forms.ErrorProvider();
            elementErrorProvider.SetIconAlignment(this.comboBox1, ErrorIconAlignment.MiddleRight);
            elementErrorProvider.SetIconPadding(this.comboBox1, 2);
            elementErrorProvider.BlinkRate = 1000;
            elementErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            comboBox1.Validated += new System.EventHandler(element_validate);

            imageErrorProvider = new System.Windows.Forms.ErrorProvider();
            imageErrorProvider.SetIconAlignment(this.imageTB, ErrorIconAlignment.MiddleRight);
            imageErrorProvider.SetIconPadding(this.imageTB, 2);
            imageErrorProvider.BlinkRate = 1000;
            imageErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            imageTB.Validated += new System.EventHandler(image_validated);

            linkErrorProvider = new System.Windows.Forms.ErrorProvider();
            linkErrorProvider.SetIconAlignment(this.linkTB, ErrorIconAlignment.MiddleRight);
            linkErrorProvider.SetIconPadding(this.linkTB, 2);
            linkErrorProvider.BlinkRate = 1000;
            linkErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            linkTB.Validated += new System.EventHandler(link_validated);

            characters = characterSQLClass.Characters();

            characterList = characterSQLHelper.CharacterList();
            summonsList = summonSQLHelper.SummonList();

            string[] sc = {"Premium" , "Event", "Grand", "12 Generals", "Valentine",
                    "Summer/Yukata", "Halloween", "Holiday", "Collaboration"};
            string[] ss = { "Premium", "Summer/Yukata", "Halloween", "Holiday", "Collaboration",
                    "Xeno", "Collaboration"};
            seriesC.AddRange(sc);
            seriesS.AddRange(ss);

            button1.Click += AddData;
        }

        private void AddData(object? sender, EventArgs e)
        {
            if (!IsNameValid() || !LinksAreValid() || !IsElementSelected() || !IsSeriesSelected())
            {
                Debug.WriteLine("Error something is invalid");
                return;
            }
            else
            {
                var c = characters.ContainsKey(nameTB.Text);
                if (c)
                {
                    var data = (GameDataClasses.CharacterDetail)characters[nameTB.Text];
                    string name = nameBox.Text;
                    string el = comboBox1.Text;
                    string sr = comboBox2.Text;
                    string l = linkTB.Text;
                    string i = imageTB.Text;
                    int id = data.id;
                    GameDataClasses.Character character = new(name, el, sr, i, l);
                    characterSQLClass.UpadteCharacter(character, id);
                }



            }
        }

        private void name_validated(object sender, System.EventArgs e)
        {
            if (IsNameValid())
            {
                nameErrorProvider.SetError(nameTB, String.Empty);
            }
            else
            {
                nameErrorProvider.SetError(nameTB, "Name does not exist in database.");
            }
        }

        private void element_validate(object sender, System.EventArgs e)
        {
            if (!IsElementSelected())
            {
                elementErrorProvider.SetError(comboBox2, "Element is required.");
            }
            else
            {
                elementErrorProvider.SetError(comboBox2, String.Empty);
            }
        }

        private void series_validated(object sender, System.EventArgs e)
        {
            if (!IsSeriesSelected())
            {
                seriesErrorProvider.SetError(comboBox1, "Series is required.");

            }
            else
            {
                seriesErrorProvider.SetError(comboBox1, String.Empty);
            }
        }

        private void link_validated(object sender, System.EventArgs e)
        {
            string link = linkTB.Text;
            if (!LinkIsValid(link))
            {
                linkErrorProvider.SetError(linkTB, "Link is not valid check again.");
            }
            else
            {
                linkErrorProvider.SetError(linkTB, String.Empty);
            }
        }

        private void image_validated(object sender, System.EventArgs e)
        {
            string link = imageTB.Text;
            if (!LinkIsValid(link))
            {
                imageErrorProvider.SetError(imageTB, "Link is not valid check again.");
            }
            else
            {
                imageErrorProvider.SetError(imageTB, String.Empty);
            }
        }

        private bool IsNameValid()
        {
            string name = nameTB.Text;
            foreach (string s in names)
            {
                if (s == name)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsElementSelected()
        {
            if (comboBox1.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        private bool IsSeriesSelected()
        {
            if (comboBox2.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        private bool LinkIsValid(string link)
        {
            var uriName = link;
            Uri uriResult;
            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttps;
            return result;
        }

        private bool LinksAreValid()
        {
            string link1 = linkTB.Text;
            string link2 = imageTB.Text;
            Uri uriResult;
            bool result = Uri.TryCreate(link1, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttps;
            Uri uriResult2;
            bool result2 = Uri.TryCreate(link2, UriKind.Absolute, out uriResult2)
                && uriResult2.Scheme == Uri.UriSchemeHttps;
            if (result2 == false || result == false)
            {
                return false;
            }
            return true;
        }

        private void EditMode(object sender, EventArgs e)
        {
            var source = new AutoCompleteStringCollection();
            names.Clear();
            comboBox1.Items.Clear();

          

            if (radioButton1.Checked)
            {
                mode = 0;
                Debug.Write($"Hashtable size:{characters.Count} real size: {characterList.Count}\n");
                List<GameDataClasses.CharacterDetail> c = characters.Values.Cast<GameDataClasses.CharacterDetail>().ToList();
                Debug.WriteLine(c.Count);
                names.AddRange(c.Select(x => x.name));
                comboBox1.Items.AddRange(seriesC.ToArray());
                source.AddRange(c.Select(x=>x.name).ToArray());
                nameTB.AutoCompleteCustomSource = source;


            }
            if (radioButton2.Checked)
            {
                mode = 1;
                names.AddRange(summonsList.Select(x => x.name));
                comboBox1.Items.AddRange(seriesS.ToArray());
                source.AddRange(summonsList.Select(x => x.name).ToArray());
                nameTB.AutoCompleteCustomSource = source;
            }
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            nameTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            nameTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

    

        private void ValidateName(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            switch (mode)
            {
                case 0:
                    try
                    {
                        GameDataClasses.Character c = characterSQLHelper.QueriedCharacter(name);
                        LoadData(c);
                    }
                    catch(Exception ex) 
                    { 

                    }
                    break;
                case 1:
                    try
                    {
                        GameDataClasses.Summon s = summonSQLHelper.QueriedSummon(name);
                        LoadData(s);
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
            }
        }

        private void LoadData(GameDataClasses.Character c)
        {
            string series = c.series;
            int indexSeries = comboBox2.Items.IndexOf(c.series);
            int indexEl = comboBox1.Items.IndexOf(c.element);
            comboBox2.SelectedIndex = indexSeries;
            comboBox1.SelectedIndex = indexEl;
            linkTB.Text = c.link;
            imageTB.Text = c.image; 
            nameBox.Text = c.name;
        }
        private void LoadData(GameDataClasses.Summon s)
        {
            comboBox2.SelectedValue = s.series;
            comboBox1.SelectedValue = s.element;
            linkTB.Text = s.link;
            imageTB.Text = s.image;
        }
    }
}
