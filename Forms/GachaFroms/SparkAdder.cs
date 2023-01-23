using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using GBF_Never_Buddy.Classes.SQLClasses;
using System.Data;
using System.Diagnostics;

namespace GBF_Never_Buddy.GachaForms
{
    public partial class SparkAdder : Form
    {
        CharacterSQLHelper characterSQLHelper = new();
        SummonSQLHelper summonSQLHelper = new();
        GachaHandler? gachaHandler = null;
        List<GameDataClasses.Character>? characterList;
        List<GameDataClasses.Summon>? summonsList;

        public SparkAdder(GachaHandler handler)
        {
            InitializeComponent();
            gachaHandler = handler;
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
            summonsList = summonSQLHelper.FilteredList();
            Debug.WriteLine($"Adding db {characterList.Count} contents");
            Debug.WriteLine($"Adding db {summonsList.Count} contents");
            LoadDataSource();
        }

        private void LoadDataSource()
        {

            if (characterList == null && summonsList != null)
            {
                Debug.WriteLine("Something went wrong db is null");
            }
            if (characterList != null && charRB.Checked)
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
                resultsPanel.Controls.Add(pictureBox);
            }
            if (e.KeyCode == Keys.Enter && summonRB.Checked)
            {
                GameDataClasses.Summon summon = summonSQLHelper.QueriedSummon(searchTB.Text);
                PictureBox pictureBox = ObtainedItem(summon);
                resultsPanel.Controls.Add(pictureBox);

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
            Form form = Application.OpenForms["SparkAdder"];
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
                Form form = Application.OpenForms["SparkAdder"];
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

        }

        private void AddResults(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["SparkForm"];
            if (form != null)
            {
                SparkForm parent = (SparkForm)form;
                Panel panel = resultsPanel;
                //Debug.WriteLine($"Panel Width: {panel.Width}");
                var table = form.Controls["sparkTargetTable"];
                int width = table.Width;
                //Debug.WriteLine($"Table Width: {width}");
                panel.Width = width;
                panel.AutoSize = true;
                //Debug.WriteLine($"Panel Width: {panel.Width}");
                table.Controls.Add(panel);
                this.Close();

            }
        }

        private void SparkBtn(object sender, EventArgs e)
        {
            if (charRB.Checked)
            {
                GameDataClasses.Character character = characterSQLHelper.QueriedCharacter(searchTB.Text);
                PictureBox pictureBox = ObtainedItem(character);
            }

            Form form = Application.OpenForms["SparkForm"];
            if (form != null)
            {
                SparkForm parent = (SparkForm)form;


                this.Close();

            }
        }
    }
}
