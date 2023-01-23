using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using GBF_Never_Buddy.Classes.SQLClasses;

namespace GBF_Never_Buddy.GachaForms
{
    public partial class SparkForm : Form
    {
        GachaHandler gachaHandler = new();
        GameDataClasses.GachaTable gacha;
        GachaSQLHelper gachaHelper = new();

        public SparkForm()
        {
            InitializeComponent();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            int id = gachaHelper.Count();
            int crystals = gachaHandler.crystalsSpent;
            gacha = new GameDataClasses.GachaTable(id, id, crystals, date);
            gachaHelper.InsertDataSpark(gacha);
            gachaHandler.drawID = id;
        }

        private void LoadSparkAdder(object sender, EventArgs e)
        {
            SparkAdder Adder = new(gachaHandler);
            Adder.ShowDialog();
        }

        private void LoadSparkTarget(object sender, EventArgs e)
        {

            SparkAdder Adder = new(gachaHandler);
            Adder.ShowDialog();
        }

        private void OpenResults(object sender, EventArgs e)
        {
            ResultsForm results = new(gachaHandler);
            results.Show();
        }

        private void LoadDrawForm(object sender, EventArgs e)
        {
            GachaResultAdder Adder = new(gachaHandler);
            Adder.ShowDialog();
        }
    }
}
