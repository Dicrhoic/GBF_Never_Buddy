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
        }

        private void LoadDetails(GachaCharacterDetails character)
        {
            if (character != null)
            {
                pictureBox1.Load(character.image);
                label1.Text = $"Name: {character.name}";
                label2.Text = character.element;
                label3.Text = character.series;
                groupBox1.Text = $"{character.name}'s Details";
                label4.Text = "Description";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
