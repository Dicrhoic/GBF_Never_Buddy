using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GBF_Never_Buddy.Classes;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy.Screens
{
    public partial class CharacterDetailsGacha : UserControl
    {
        public CharacterDetailsGacha(GachaCharacterDetails character)
        {
            InitializeComponent();
            LoadDetails(character);
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void ValidateDate(object? sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(textBox1.Text, out temp))
            {

            }
            else
            {
                textBox1.Text = String.Empty;
            }
        }

        private void LoadDetails(GachaCharacterDetails character)
        {
            if (character != null)
            {
                pictureBox1.Load(character.image);
                label1.Text = $"Name: {character.name}";
                label2.Text = $"Element: {character.element}\t Series: {character.series}";
                label3.Text = $"Date Acquired: ";
                groupBox1.Text = $"{character.name}'s Details";
                label4.Text = "Description";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UpdateCharacter(object sender, EventArgs e)
        {
            DateTime temp;
            if (DateTime.TryParse(textBox1.Text, out temp))
            {

            }
            else
            {
                textBox1.Text = String.Empty;
            }
        }
    }
}
