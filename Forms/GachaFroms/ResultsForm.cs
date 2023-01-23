using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.GachaClasses;
using System.Diagnostics;

namespace GBF_Never_Buddy.GachaForms
{
    public partial class ResultsForm : Form
    {
        GachaHandler handler;
        string? date = null;

        public ResultsForm(GachaHandler handler)
        {
            InitializeComponent();
            newCharacterPanel.AllowDrop = true;
            this.handler = handler;
            DateTime thisDay = DateTime.Now;
            date = thisDay.ToString("F");
            dateLabel.Text = date;
            crystalsLabel.Text = $"Crsytals Spent: {handler.crystalsSpent}";

        }

        private void NewCharacterCheckImage(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drop recieved");
            if (sender != null)
            {
                if (handler.currentCharacterImage != null)
                {
                    PictureBox picture = handler.currentCharacterImage;
                    Debug.WriteLine("We have the current image");
                    newCharacterPanel.Controls.Add(picture);
                }

                Debug.WriteLine($"Sender is {sender}, event:{e}");
            }
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void GoldMoonCheckImage(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drop recieved");
            if (sender != null)
            {
                if (handler.currentCharacterImage != null)
                {
                    PictureBox picture = handler.currentCharacterImage;
                    Debug.WriteLine("We have the current image");
                    gmCharacterPanel.Controls.Add(picture);
                }
                Debug.WriteLine($"Sender is {sender}, event:{e}");
            }
        }

        private void SummonCheckImage(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drop recieved");
            if (sender != null)
            {
                if (handler.currentCharacterImage != null)
                {
                    PictureBox picture = handler.currentCharacterImage;
                    Debug.WriteLine("We have the current image");
                    summonPanel.Controls.Add(picture);
                }
                Debug.WriteLine($"Sender is {sender}, event:{e}");
            }
        }


        private void ScreenshotForm()
        {
            ScreenShotClass shotClass = new();
            shotClass.ScreenshotForm(mainPanel);
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            ScreenshotForm();
        }



        private void UpdateValues(object sender, ControlEventArgs e)
        {
            int newChar = newCharacterPanel.Controls.Count;
            int gm = gmCharacterPanel.Controls.Count;
            int summons = summonPanel.Controls.Count;
            int sum = newChar + gm + summons;
            int crystals = handler.crystalsSpent;
            decimal rate = crystals / sum;
            rate = Math.Round(rate, 2);
            rateLabel.Text = $"Crystals for SSR: {rate}";
            charLabel.Text = $"New Characters: {newChar}";
            gmLabel.Text = $"Gold moons: {gm}";
            summonLabel.Text = $"Summons: {summons}";
        }
    }
}
