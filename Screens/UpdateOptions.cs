using GBF_Never_Buddy.Classes.XMLWriterClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBF_Never_Buddy.Screens
{
    public partial class UpdateOptions : UserControl
    {   
        private HomePage page;
        public UpdateOptions(HomePage parent)
        {
            InitializeComponent();
            page = parent;
            CharacterWriter characterWriter = new CharacterWriter();
            SummonWriter summonWriter = new SummonWriter(); 
        }

        private async void UpdateDB(object sender, EventArgs e)
        {

   
        }
    }
}
