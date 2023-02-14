using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using GBF_Never_Buddy.Classes.SQLClasses;
using GBF_Never_Buddy.GachaForms;
using System.Diagnostics;

namespace GBF_Never_Buddy
{
    public partial class GachaForm : Form
    {
        GachaHandler gachaHandler = new();
        GameDataClasses.GachaTable gacha;
        GachaSQLHelper gachaHelper = new();

        public GachaForm()
        {
            InitializeComponent();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            int drawId = gachaHelper.DrawCount();
            int id = gachaHelper.Count();
            int crystals = gachaHandler.crystalsSpent;
            gacha = new GameDataClasses.GachaTable(id, id, crystals, date);
            gachaHelper.InsertData(gacha);
            gachaHandler.drawID = id;
        }

        public void ChangeTableRows()
        {
            var styles = resultsTable.RowStyles;
            int count = resultsTable.RowCount;
            int tableHeigt = resultsTable.Height;
            int sizeDistrubution = tableHeigt / count;
            float percentageHeight = 33;
            Debug.WriteLine($"Table Height: {tableHeigt}");
            foreach (RowStyle style in styles)
            {
                Debug.WriteLine($"Type: {style.SizeType}, Height: {style.Height}");
                style.Height = percentageHeight;
            }
        }

        private void TenDrawBtn_Click(object sender, EventArgs e)
        {

            gachaHandler.UpdateCrystalsUsed(costLabel, DrawType.Multi);
            gachaHandler.drawNumber++; 
            GachaResultAdder Adder = new(gachaHandler);
            Adder.ShowDialog();
        }

        private void OpenResults(object sender, EventArgs e)
        {
            ResultsForm results = new(gachaHandler);
            results.Show();
        }
    }
}
