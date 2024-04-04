using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBF_Never_Buddy.Forms.GachaFroms
{
    public partial class CharacterRow : UserControl
    {
        public CharacterRow(string text)
        {
            InitializeComponent();
            textBox1.Text = text;   
        }

        public string TextBox()
        {
            return textBox1.Text;   
        }

        public TextBox box()
        {
            return textBox1 as TextBox;
        }
    }
}
