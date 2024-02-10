using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using GBF_Never_Buddy.Classes.SQLClasses;
using GBF_Never_Buddy.Forms.GachaFroms;
using GBF_Never_Buddy.GachaForms;
using System.Diagnostics;
using static GBF_Never_Buddy.Classes.RaidClasses;

namespace GBF_Never_Buddy
{
    public partial class GachaForm : Form
    {
        GachaHandler gachaHandler;
        GameDataClasses.GachaTable gacha;
        GachaSQLHelper gachaHelper = new();

        public GachaForm(GachaHandler gachaHandler)
        {
            InitializeComponent();
            this.gachaHandler = gachaHandler;
            int drawId = gachaHelper.DrawCount();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            int id = gachaHelper.Count();
            int crystals = gachaHandler.crystalsSpent;
            if (gachaHandler.mode == Mode.Free)
            {
                crystals = 0;
            }
            gacha = new GameDataClasses.GachaTable(id, id, crystals, date);
            switch (gachaHandler.mode)
            {
                case Mode.Free:
                    gachaHelper.InsertDataFree(gacha);
                    break;
                case Mode.Normal:
                    gachaHelper.InsertData(gacha);
                    break;
            }



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

        private void GachaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var origin = Application.OpenForms["FreebieLogForm"];
            if (origin != null)
            {
                FreebieLogForm parent = (FreebieLogForm)origin;
                parent.Refresh();
                //parent.LoadList();
            }
        }
    }
}
