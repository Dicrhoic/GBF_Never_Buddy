using GBF_Never_Buddy.Classes;
using GBF_Never_Buddy.Classes.SQLClasses;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GBF_Never_Buddy.Forms
{
    public partial class CharacterWishlist : Form
    {

        List<string> characterImages = new List<string>();
        List<CharacterPriority> characterPriorityList = new List<CharacterPriority>();
        public CharacterWishlist()
        {
            InitializeComponent();
            checkedListBox1.Click += LoadData;
            flowLayoutPanel1.Dock = DockStyle.Fill;
        }

        async Task DownloadAndSave(string sourceFile, string destinationFolder, string destinationFileName)
        {   
            if(!File.Exists(destinationFileName)) 
            {
                Stream fileStream = await GetFileStream(sourceFile);

                if (fileStream != Stream.Null)
                {
                    await SaveStream(fileStream, destinationFolder, destinationFileName);
                }
            }
       
        }

        async Task<Stream> GetFileStream(string fileUrl)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                Stream fileStream = await httpClient.GetStreamAsync(fileUrl);
                return fileStream;
            }
            catch (Exception ex)
            {
                return Stream.Null;
            }
        }

        async Task SaveStream(Stream fileStream, string destinationFolder, string destinationFileName)
        {
            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            string path = Path.Combine(destinationFolder, destinationFileName);

            using (FileStream outputFileStream = new FileStream(path, FileMode.CreateNew))
            {
                await fileStream.CopyToAsync(outputFileStream);
            }
        }

        private async void LoadData(object? sender, EventArgs e)
        {     
            var s = checkedListBox1.SelectedIndex;
            var character = checkedListBox1.Items[s].ToString();
            string dir = Directory.GetCurrentDirectory();
            var itemChecked = checkedListBox1.GetItemChecked(s);
            Debug.WriteLine($"Clicked on {character} index: {s} chr: {itemChecked}");

            if (character != null && ExistsInList(character) && itemChecked)
            {
                var results = flowLayoutPanel1.Controls.Find(character, true);
                if (results != null)
                {
                    PictureBox pictureBox = (PictureBox)results[0];
                    flowLayoutPanel1.Controls.Remove(pictureBox);
                    Debug.Write($"Removing {character}\n");
                    characterImages.Remove(character);
                }
            }

            if (character != null && !ExistsInList(character))
            {
                CharacterSQLClass characterSQL = new CharacterSQLClass();
                var data = characterSQL.QueriedCharacter(character);
                GameDataClasses.Character character1 = (GameDataClasses.Character)data;
                string name = character1.name + "_image.jpg";
                string fileName = dir + @"\Assets\" + name;
                if (!File.Exists(fileName))
                {
                    await DownloadAndSave(character1.image, "Assets", $"{name}");
                }
                try
                {

                    Debug.Write(fileName);
                    Bitmap bitmap = new(Bitmap.FromFile(fileName));
                    Bitmap bwimage = new(Bitmap.FromFile(fileName));
                    InvertImage(bitmap, bwimage);
                    PictureBox picture = new PictureBox();
                    picture.Image = bwimage;
                    picture.SizeMode = PictureBoxSizeMode.AutoSize;
                    picture.Dock = DockStyle.Fill;
                    PictureData pictureData = new(bitmap, bwimage, picture, checkedListBox1);
                    picture.Click+= (s, e) => { UpdateAcquriedCount(pictureData, picture); };
                    picture.Name = character1.name;
                    characterImages.Add(character1.name);
                    flowLayoutPanel1.Controls.Add(picture);
         
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                
            }
  


        }

        private bool ExistsInList(string name)
        {
            var exists = characterImages.Contains(name);
            Debug.WriteLine($"Checking for {name}, {exists}");
            if(exists)
            {
                return true;    
            }
            return false;
        }

        private void UpdateAcquriedCount(PictureData pictureData, PictureBox pictureBox)
        {
            Bitmap bitmap = pictureData.ImageEffect();
            pictureBox.Image = bitmap;
            CharacterPriority? item = characterPriorityList.Find(x=>x.name == pictureBox.Name);
           
            if(pictureData.status == 0 && item != null)
            {   
                int index = characterPriorityList.IndexOf(item);
                checkedListBox1.SetItemCheckState(index, CheckState.Checked);
            }
            else
            {
                int index = characterPriorityList.IndexOf(item);
                checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
            }
           
         
        }

        private void InvertImage(Bitmap input, Bitmap output)
        {
            for (int row = 0; row < input.Width; row++) // Indicates row number

            {

                for (int column = 0; column < input.Height; column++) // Indicate column number

                {

                    var colorValue = input.GetPixel(row, column); // Get the color pixel

                    var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white

                    output.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel

                }
            }
        }

        private List<CheckBox> CheckBoxes()
        {
            List<CheckBox> list = new List<CheckBox>();
            foreach (Control control in panel1.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    if (checkBox.Checked)
                    {
                        list.Add(checkBox);
                    }
                }
            }


            return list;
        }
        private void UpdateFilters(object sender, EventArgs e)
        {

            checkedListBox1.Items.Clear();
            characterPriorityList.Clear();
            Debug.WriteLine("Stored character indexes: " + characterPriorityList.Count);    
            List<CheckBox> filters = CheckBoxes();
            if (filters.Count == 0)
            {
                LoadAll();
            }
            else
            {   
                Debug.WriteLine($"{filters.Count} filters");    
                foreach (CheckBox cb in filters)
                {
                    CreateLists(cb.Text);
                }
            }
            Debug.WriteLine("Stored character indexes: " + characterPriorityList.Count);
        }

        private void CreateLists(string text)
        {
            switch (text)
            {
                case "Premium/Classic":
                    LoadClassicAndPremium();
                    break;
                case "Grand":
                    LoadSeries("Grand");
                    break;
                case "12 Generals":
                    LoadSeries("12 Generals");
                    break;
                case "Valentine":
                    LoadSeries("Valentine");
                    break;
                case "Halloween":
                    LoadSeries("Halloween");
                    break;
                case "Summer/Yukata":
                    LoadSeries("Summer/Yukata");
                    break;
                case "Holiday":
                    LoadSeries("Holiday");
                    break;
            }
        }

        private void LoadAll()
        {
            LoadClassicAndPremium();
            LoadSeries("Grand");
            LoadSeries("12 Generals");
            LoadSeries("Valentine");
            LoadSeries("Halloween");
            LoadSeries("Summer/Yukata");
            LoadSeries("Holiday");

        }

        private void LoadClassicAndPremium()
        {

            List<CharacterPriority> list = CharacterData("Premium");
            List<CharacterPriority> list1 = CharacterData("Classic");
            checkedListBox1.Items.AddRange(list.Select(x => x.name).ToArray());
            checkedListBox1.Items.AddRange(list1.Select(x => x.name).ToArray());
            characterPriorityList.AddRange(list);
            characterPriorityList.AddRange(list1);

        }

        private void LoadSeries(string series)
        {
            List<CharacterPriority> list = CharacterData(series);
            checkedListBox1.Items.AddRange(list.Select(x => x.name).ToArray());
            characterPriorityList.AddRange(list);
        }

        private List<CharacterPriority> CharacterData(string series)
        {
            List<CharacterPriority> list = new List<CharacterPriority>();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                       SELECT GachaCharacters.Name, WantedCharacters.Priority, GachaCharacters.Series
                       FROM GachaCharacters
                       INNER JOIN WantedCharacters ON GachaCharacters.Id=WantedCharacters.ID
                       WHERE GachaCharacters.Series=$series
                        ";
                command.Parameters.AddWithValue("$series", series);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int priority = reader.GetInt32(1);
                        string name = reader.GetString(0);
                        CharacterPriority character = new(name, priority, series);
                        list.Add(character);

                    }
                }
            }
            return list;
        }

        private void CharacterWishlist_Load(object sender, EventArgs e)
        {

        }

        private void DeleteCachedImages(object sender, FormClosedEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
     
            //Directory.SetCurrentDirectory(@"\.");

        }
    }

    class CharacterPriority
    {
        public string name;
        public int priority;
        public string series;

        public CharacterPriority(string name, int priority, string series)
        {
            this.name = name;
            this.priority = priority;
            this.series = series;
        }
    }

    class PictureData
    {
        Bitmap inverted;
        Bitmap original;
        PictureBox PictureBox;
        CheckedListBox checkedListBox;
        public int status;
        public PictureData(Bitmap original, Bitmap inverted, PictureBox pictureBox, CheckedListBox checkedListBox)
        {
            this.original = original;
            this.inverted = inverted;
            status = 1;
            PictureBox = pictureBox;
            this.checkedListBox = checkedListBox;
        }

        public Bitmap ImageEffect()
        {
           Bitmap returnImage = original;
           var item = checkedListBox.CheckedItems.Contains(PictureBox.Name);    

           switch(status)
            {
                case 1:
                    status = 0;
                    returnImage = original;
   
                    break;
                case 0:
                    status = 1;
                    returnImage = inverted;
       
                    break;
            }   
            return returnImage; 
        }
    }
}
