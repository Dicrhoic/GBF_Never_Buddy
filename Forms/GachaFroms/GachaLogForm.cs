using GBF_Never_Buddy.Classes.SQLClasses;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using static GBF_Never_Buddy.Classes.GameDataClasses;
using static GBF_Never_Buddy.Classes.RaidClasses;

namespace GBF_Never_Buddy.GachaForms
{
    public partial class GachaLogForm : Form
    {
        ItemComparer comparer;
        GachaSQLHelper gachaSQL = new GachaSQLHelper();
        List<GachaTable> gachaTables;
        int drawID = -1;
        bool dataLoaded = false;
        public GachaLogForm()
        {
            InitializeComponent();
            comparer = new ItemComparer();
            listView1.ListViewItemSorter = comparer;
            gachaTables = gachaSQL.GachaList();
            listView1.ListViewItemSorter = comparer;
            listView1.ColumnClick += SortListView;
            InitialiseListView();
            listView1.ItemSelectionChanged += LoadDetailsSide;
            listView1.SelectedIndexChanged += LoadGachaData;
            resultsTable.Visible = false;
        }

        private async void LoadGachaData(object? sender, EventArgs e)
        {
            DisplayPanel();
        }

        private void DisplayPanel()
        {   
            
            Debug.WriteLine("Function called");
            resultsTable.Controls.Clear();
            resultsTable.Visible = true;
            resultsTable.AutoScroll = true;
            List<GachaDetails> gachaDetails = gachaSQL.GachaDetails(drawID);
            Debug.WriteLine(gachaDetails.Count);
            foreach (GachaDetails details in gachaDetails)
            {
                RichTextBox textBox = new RichTextBox();
                string text = $"Draw Number: {details.drawNumber}\nCrystals Used: {details.crystalsUsed}";
                textBox.Text = text;
                textBox.Dock = DockStyle.Top;
                textBox.Height = 40;
                textBox.ReadOnly = true;
                resultsTable.Controls.Add(textBox);
                if (details.characters != "")
                {
                    CharacterSQLHelper characterSQL = new();
                    string[] chars = details.characters.Split(",");
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.AutoScroll = true;
                    panel.Dock = DockStyle.Fill;
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    foreach (string c in chars)
                    {
                        Debug.WriteLine($"{c}");
                        Character character = characterSQL.QueriedCharacter(c);
                        string link = character.link;
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        pictureBox.Load(character.image);
                        pictureBox.Dock = DockStyle.Fill;
                        pictureBox.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                        panel.Controls.Add(pictureBox);

                    }
                    resultsTable.Controls.Add(panel);
                }
                if (details.summons != "")
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.AutoScroll = true;
                    panel.Dock = DockStyle.Fill;
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    SummonSQLHelper summonSQL = new();
                    string[] s = details.summons.Split(",");
                    foreach (string c in s)
                    {
                        Debug.WriteLine($"{c}");
                        Summon summon = summonSQL.QueriedSummon(c);
                        string link = summon.link;
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        pictureBox.Load(summon.image);
                        pictureBox.Dock = DockStyle.Fill;
                        pictureBox.MouseClick += (s, e) => { ImageClickFunction(pictureBox, link); };
                        panel.Controls.Add(pictureBox);
                    }
                    resultsTable.Controls.Add(panel);
                }


                Debug.WriteLine($"id: {details.id} draw id: {details.drawId}, " +
                    $" Characters: {details.characters} Sum: {details.summons}" +
                    $" Crystals: {details.crystalsUsed} Draw Num: {details.drawNumber}");
            }



        }

        private void LoadDetailsSide(object? sender, ListViewItemSelectionChangedEventArgs e)
        {   
            if(sender == null)
            {
                return;
            }
            ListView parent = (ListView)sender;
            int index = e.ItemIndex;
            drawID = Int32.Parse(parent.Items[index].SubItems[3].Text);
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
            string[] crystlas = CrystalCount(gachaTables);
            List<ListViewItem> name = new List<ListViewItem>();
            for (int i = 0; i < arry1.Length; i++)
            {
                ListViewItem item = new ListViewItem(arry1[i], i);
                item.SubItems.Add(crystlas[i]);
                item.SubItems.Add(idArry[i]);
                item.SubItems.Add(arry2[i]);
                name.Add(item);
            }
            listView1.Columns.Add("Date", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Crystals Used", -2, HorizontalAlignment.Left);
            listView1.Items.AddRange(name.ToArray());
        }

        private void SortListView(object? sender, ColumnClickEventArgs e)
        {   
            if(sender == null)
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
    }
}
