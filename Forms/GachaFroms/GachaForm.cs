using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using GBF_Never_Buddy.Classes.SQLClasses;
using GBF_Never_Buddy.Forms.GachaFroms;
using GBF_Never_Buddy.GachaForms;
using GBF_Never_Buddy.Properties;
using System.Diagnostics;
using static GBF_Never_Buddy.Classes.GameDataClasses;


namespace GBF_Never_Buddy
{
    public partial class GachaForm : Form
    {
        GachaHandler gachaHandler;
        GachaSQLHelper gachaHelper = new();
        GachaInfo info;
        public GachaForm(GachaHandler gachaHandler)
        {
            InitializeComponent();
            this.gachaHandler = gachaHandler;
            int id = gachaHelper.Count();
            int crystals = gachaHandler.crystalsSpent;
            if (gachaHandler.mode == Mode.Free)
            {
                crystals = 0;
            }
            radioButton1.Checked = true;
            comboBox1.Visible = false;
            label1.Visible = false;
            string mode = nameof(GachaHandler.mode);
            info = new(id, mode, gachaHandler);
            var form = Application.OpenForms["FreebieLogForm"];
            if (form != null)
            {
                panel1.Visible = false;
                costLabel.Visible = false;
                label1.Visible = false;
            }

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
            var form = Application.OpenForms["FreebieLogForm"];
            if (form != null)
            {               
                info.NewDraw((int)DrawType.Free);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    gachaHandler.UpdateCost(costLabel, DrawType.Multi);
                    info.NewDraw((int)DrawType.Multi);
                }
                else
                {
                    gachaHandler.UpdateCost(label1, DrawType.Tickets);
                    info.NewDraw((int)DrawType.Tickets);
                }
            }
          
            GachaResultAdder Adder = new(gachaHandler);
            Adder.ShowDialog();
            gachaHandler.drawNumber++;
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

        private void UpdateCostSource(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Visible = false;
                tenDrawBtn.Image = Resources.text_stone10;
                tenDrawBtn.BackColor = Color.IndianRed;
                singleDrawBtn.BackColor = Color.IndianRed;
                singleDrawBtn.Image = Resources.text_stone;
            }
            if (radioButton2.Checked)
            {
                comboBox1.Visible = true;
                tenDrawBtn.Image = Resources.text_legendticket10;
                tenDrawBtn.BackColor = Color.SkyBlue;
                singleDrawBtn.BackColor = Color.SkyBlue;
                singleDrawBtn.Image = Resources.text_legendticket;
                label1.Visible = true;
                comboBox1.SelectedIndex = 0;
            }
        }

        private void SingleDraw(object sender, EventArgs e)
        {
            var form = Application.OpenForms["FreebieLogForm"];
            if (form != null)
            {
                info.NewDraw((int)DrawType.Free);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    gachaHandler.UpdateCost(costLabel, DrawType.Single);
                    info.NewDraw((int)DrawType.Single);
                }

                if (radioButton2.Checked)
                {
                    int tickets = comboBox1.SelectedIndex + 1;
                    gachaHandler.UpdateCost(label1, DrawType.Ticket, tickets);
                    info.NewDraw(comboBox1.SelectedIndex + 1);
                }
            }
        
           
            GachaResultAdder Adder = new(gachaHandler);
            Adder.ShowDialog();
        }
    }
}
