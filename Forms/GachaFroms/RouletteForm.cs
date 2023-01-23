using GBF_Never_Buddy.Classes.GachaClasses;
using System.Diagnostics;

namespace GBF_Never_Buddy.GachaForms
{
    public partial class RouletteForm : UserControl
    {
        GachaHandler gachaHandler = new();

        public RouletteForm()
        {
            InitializeComponent();
        }

        private void ChangeTableRows()
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
            GachaResultAdder Adder = new(gachaHandler);
            Adder.ShowDialog();
        }
    }
}
