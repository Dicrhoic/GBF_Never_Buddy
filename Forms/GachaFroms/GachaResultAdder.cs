using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using GBF_Never_Buddy.Classes.SQLClasses;
using GBF_Never_Buddy.GachaForms;
using System.Data;
using System.Diagnostics;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy
{
    public partial class GachaResultAdder : Form
    {
        CharacterSQLHelper characterSQLHelper = new();
        SummonSQLHelper summonSQLHelper = new();
        GachaHandler? gachaHandler = null;
        GachaSQLHelper gacha = new();
        List<GameDataClasses.Character>? characterList;
        List<GameDataClasses.Summon>? summonsList;
        List<Tuple<int, GameDataClasses.Character>> obtainedCharList = new();
        List<Tuple<int, GameDataClasses.Summon>> obtainedSummonsList = new();
        int charIndex = 0;
        int summonIndex = 0;
        int id;
        int drawNumber;
        int crystalsUsed;

        public GachaResultAdder(GachaHandler handler)
        {
            InitializeComponent();
            gachaHandler = handler;
            id = gachaHandler.drawID;
            drawNumber = gachaHandler.drawNumber;
            crystalsUsed = gachaHandler.crystalsSpent;
            Debug.WriteLine($"ID: {id}");
            Debug.WriteLine($"Crystals Spent: {gachaHandler.crystalsSpent}. Draw Number {gachaHandler.drawNumber}");
        }

        private void LoadFormData()
        {
            Cursor = Cursors.WaitCursor;
            characterSQLHelper.ValidateDB();
            Cursor = Cursors.Default;
        }

        private void AuthenticateData(object sender, EventArgs e)
        {
            LoadFormData();

            characterList = characterSQLHelper.CharacterList();
            summonsList = summonSQLHelper.SummonList();
            Debug.WriteLine($"Adding db {characterList.Count} contents");
            //Debug.WriteLine($"Adding db {summonsList.Count} contents");
            LoadDataSource();
        }

        private void LoadDataSource()
        {   
            if (characterList == null && summonsList == null)
            {
                return;
            }
            if (characterList.Count == 0 && summonsList.Count == 0)
            {
                Debug.WriteLine("Something went wrong db is null");
            }
            if (characterList.Count != 0 && charRB.Checked)
            {
                searchTB.PlaceholderText = "Enter character name";
                Debug.WriteLine($"Adding db {characterList.Count} contents");
                var source = new AutoCompleteStringCollection();

                source.AddRange(characterList.Select(d => d.name).ToArray());
                searchTB.AutoCompleteCustomSource = source;
                searchTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                searchTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            if (summonsList != null && summonRB.Checked)
            {
                searchTB.PlaceholderText = "Enter summon name";
                Debug.WriteLine($"Adding db {summonsList.Count} contents");
                var source = new AutoCompleteStringCollection();

                source.AddRange(summonsList.Select(d => d.name).ToArray());
                searchTB.AutoCompleteCustomSource = source;
                searchTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                searchTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void ChangeDataSource(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void SearchForDataItem(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && charRB.Checked)
            {
                GameDataClasses.Character character = characterSQLHelper.QueriedCharacter(searchTB.Text);
                PictureBox pictureBox = ObtainedItem(character);
                pictureBox.Name = $"character{charIndex}";
                Tuple<int, GameDataClasses.Character> tuple = new Tuple<int, GameDataClasses.Character>(charIndex, character);
                resultsPanel.Controls.Add(pictureBox);
                obtainedCharList.Add(tuple);
                charIndex++;

            }
            if (e.KeyCode == Keys.Enter && summonRB.Checked)
            {
                GameDataClasses.Summon summon = summonSQLHelper.QueriedSummon(searchTB.Text);
                PictureBox pictureBox = ObtainedItem(summon);
                pictureBox.Name = $"summon{summonIndex}";
                Tuple<int, GameDataClasses.Summon> tuple = new Tuple<int, GameDataClasses.Summon>(summonIndex, summon);
                resultsPanel.Controls.Add(pictureBox);
                obtainedSummonsList.Add(tuple);
                summonIndex++;

            }
        }



        private PictureBox ObtainedItem(GameDataClasses.Character character)
        {

            PictureBox obtainedChar = new PictureBox();
            obtainedChar.Size = new Size(168, 99);
            obtainedChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            string image = character.image;
            string name = character.name;
            string link = character.link;
            //Debug.WriteLine(image);
            obtainedChar.Name = name;
            obtainedChar.Load(image);
            obtainedChar.MouseClick += (s, e) => { ImageClickFunction(obtainedChar, link); };
            obtainedChar.AllowDrop = true;
            obtainedChar.DragEnter += (s, e) => { ImageDragEnter(e); };
            obtainedChar.MouseDown += (a, b) => { ImageDragAndDrop(obtainedChar, b, link); };
            obtainedChar.DragDrop += (s, e) => { };
            return obtainedChar;
        }

        private PictureBox ObtainedItem(GameDataClasses.Summon summon)
        {

            PictureBox obtainedChar = new PictureBox();
            obtainedChar.Size = new Size(168, 99);
            obtainedChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            string image = summon.image;
            string name = summon.name;
            string link = summon.link;
            //Debug.WriteLine(image);
            obtainedChar.Name = name;
            obtainedChar.Load(image);
            obtainedChar.MouseClick += (s, e) => { ImageClickFunction(obtainedChar, link); };
            obtainedChar.AllowDrop = true;
            obtainedChar.DragEnter += (s, e) => { ImageDragEnter(e); };
            obtainedChar.MouseDown += (a, b) => { ImageDragAndDrop(obtainedChar, b, link); };
            obtainedChar.DragDrop += (s, e) => { };
            return obtainedChar;
        }

        private void ImageClickFunction(PictureBox imageHolder, string link)
        {
            Debug.WriteLine("Click");
            string url = link;
            Form form = Application.OpenForms["GachaResultAdder"];
            if (form != null)
            {
                Debug.WriteLine("Deleting image");
                if (resultsPanel.Controls.Contains(imageHolder))
                {
                    resultsPanel.Controls.Remove(imageHolder);
                }
            }
            if (form == null)
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }

        private void ImageDragEnter(DragEventArgs e)
        {
            Debug.WriteLine("Dragging image");
            e.Effect = DragDropEffects.Copy;
        }
        private void ImageDragAndDrop(PictureBox imageHolder, MouseEventArgs e, string link)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                Debug.WriteLine("Left mouse down");
                if (gachaHandler != null)
                {
                    gachaHandler.UpdateCharacter(imageHolder);
                }
                imageHolder.DoDragDrop(imageHolder.Image, DragDropEffects.Copy);
            }
            if (e.Button == MouseButtons.Left && e.Clicks > 1)
            {
                Debug.WriteLine("Click");
                string url = link;
                Form form = Application.OpenForms["GachaResultAdder"];
                if (form != null)
                {
                    Debug.WriteLine("Deleting image");
                    if (resultsPanel.Controls.Contains(imageHolder))
                    {
                        Debug.WriteLine(SummonPB(imageHolder.Name));
                        string idStr = PBName(imageHolder.Name);
                        Debug.WriteLine($"{idStr}");
                        resultsPanel.Controls.Remove(imageHolder);
                        UpdateList(SummonPB(imageHolder.Name), idStr);
                    }
                }
                if (form == null)
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
            }

        }

        private void UpdateList()
        {
            List<GameDataClasses.Character> characters = obtainedCharList.Select(x => x.Item2).ToList();
            List<GameDataClasses.Summon> summons = obtainedSummonsList.Select(x => x.Item2).ToList();
            if (gachaHandler != null)
            {
                gachaHandler.UpdateLists(summons, characters);
            }


        }

        private void UpdateList(bool summon, string id)
        {
            int idNum = int.Parse(id);
            if (summon)
            {
                foreach (var summons in obtainedSummonsList)
                {
                    if (summons.Item1 == idNum)
                    {
                        obtainedSummonsList.Remove(summons);
                    }
                }
            }
            if (!summon)
            {
                foreach (var characters in obtainedCharList)
                {
                    if (characters.Item1 == idNum)
                    {
                        obtainedCharList.Remove(characters);
                    }
                }
            }
        }

        private bool SummonPB(string name)
        {
            if (name.Contains("s"))
            {
                return true;
            }
            return false;
        }

        private string PBName(string name)
        {
            string strip = "";
            if (name.Contains("s"))
            {
                strip = name.Replace("summon", "");
            }
            if (name.Contains("c"))
            {
                strip = name.Replace("character", "");
            }
            return strip;
        }

        private void AllocateData()
        {
            switch(gachaHandler.mode)
            {
                case Mode.Spark:
                    break;
                case Mode.Normal: 

                    break;
                case Mode.Free: 

                    break;  
            }
        }

        private void AddSparkResults()
        {

        }


        private void AddResults(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["GachaForm"];
            if (form != null)
            {
                GachaForm parent = (GachaForm)form;
                Panel panel = resultsPanel;
                //Debug.WriteLine($"Panel Width: {panel.Width}");
                var table = form.Controls["resultsTable"];
                int width = table.Width;
                //Debug.WriteLine($"Table Width: {width}");
                panel.Width = width;
                panel.AutoSize = true;
                //Debug.WriteLine($"Panel Width: {panel.Width}");
                table.Controls.Add(panel);
                parent.ChangeTableRows();
                UpdateList();
                string chars = "";
                for (int i = 0; i < obtainedCharList.Count; i++)
                {
                    Debug.WriteLine($"{obtainedCharList[i].Item2.name}");
                    if (i == obtainedCharList.Count - 1)
                    {
                        chars += $"{obtainedCharList[i].Item2.name}";
                    }
                    if (i < obtainedCharList.Count - 1)
                    {
                        chars += $"{obtainedCharList[i].Item2.name},";
                    }
                }
                string sums = "";
                for (int i = 0; i < obtainedSummonsList.Count; i++)
                {
                    Debug.WriteLine($"{obtainedSummonsList[i].Item2.name}");
                    if (i == obtainedSummonsList.Count - 1)
                    {
                        sums += $"{obtainedSummonsList[i].Item2.name}";
                    }
                    if (i < obtainedSummonsList.Count - 1)
                    {
                        sums += $"{obtainedSummonsList[i].Item2.name}, ";
                    }
                }
                id++;
                GachaDetails results = new GachaDetails(id, id, chars, sums, drawNumber, crystalsUsed);
                try
                {
                    gacha.InsertResults(results);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                Debug.WriteLine(chars);
                this.Close();

            }
            form = Application.OpenForms["RouletteLog"];
            if (form != null)
            {
                RouletteLog parent = (RouletteLog)form;
                var tabControl = form.Controls["dataTabs"];
                TabControl tab = (TabControl)tabControl;
                Panel panel = resultsPanel;
                int width = 0;
                if (tab.SelectedIndex == 0)
                {
                    var table = tab.Controls["gachapinTab"].Controls["resultsTableGP"];
                    width = table.Width;
                    panel.Width = width;
                    panel.AutoSize = true;
                    //Debug.WriteLine($"Panel Width: {panel.Width}");
                    table.Controls.Add(panel);
                }
                if (tab.SelectedIndex == 1)
                {
                    var table = tab.Controls["MukkuTab"].Controls["resultsTable"];
                    width = table.Width;
                    panel.Width = width;
                    panel.AutoSize = true;
                    //Debug.WriteLine($"Panel Width: {panel.Width}");
                    table.Controls.Add(panel);
                }

                parent.ChangeTableRows();
                UpdateList();
                this.Close();
            }
        }

    }
}
