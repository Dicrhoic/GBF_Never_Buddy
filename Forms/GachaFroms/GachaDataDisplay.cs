using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy.Forms.GachaFroms
{
    public partial class GachaDataDisplay : UserControl
    {

        Dictionary<char,string> keyValuePairs = new Dictionary<char,string>();

        public GachaDataDisplay(GachaLogData data, UpdateGachaLog parent)
        {
            InitializeComponent();
            keyValuePairs.Add('F', "Free");
            keyValuePairs.Add('N', "Normal");
            keyValuePairs.Add('S', "Spark");
            comboBox1.Items.Add("Free");
            comboBox1.Items.Add("Normal");
          
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Parse(data.date);
            string type = keyValuePairs[data.typeChar];
            Debug.WriteLine(type);
            comboBox1.SelectedIndex = comboBox1.FindString(type);  
            numericUpDown1.Value = data.drawCount;
            UpdateGachaLog origin = parent;
            var c = origin.Controls.Find("drawNumCB", true);
            ComboBox combo = (ComboBox)c[0];
            combo.Items.Clear();    
            for (int i = 1; i <= data.drawCount; i++)
            {
                combo.Items.Add(i);
            }
            combo.SelectedIndex = 0;
        }
    }
}
