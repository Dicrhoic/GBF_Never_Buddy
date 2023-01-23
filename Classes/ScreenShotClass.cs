using GBF_Never_Buddy.GachaForms;
using System.Diagnostics;
using System.Reflection;

namespace GBF_Never_Buddy.Classes
{
    internal class ScreenShotClass
    {
        string originPath;
        string filePath;
        public ScreenShotClass()
        {

            originPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            filePath = ValidatedPath();
            Directory.SetCurrentDirectory(filePath);
        }
        public void ScreenshotForm(Panel mainPanel)
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mainPanel.ClientRectangle.Width, mainPanel.ClientRectangle.Height);
            mainPanel.DrawToBitmap(bmp, mainPanel.ClientRectangle);
            DateTime thisDay = DateTime.Today;
            string dateF = thisDay.ToString(@"yyyy-MM--dd");
            string fileName = $"{dateF}_gachaResults";
            bmp.Save(@$"{fileName}.jpg");

        }

        public string ImageName(string str, string fileName, string fileExt)
        {
            string sourceDirectory = Path.Combine(originPath, @"GachaLog");
            string name = str;
            if (File.Exists(str))
            {
                Debug.WriteLine("File Exists");
                int increment = 1;

                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.jpg");
                foreach (string currentFile in txtFiles)
                {
                    string curName = currentFile.Substring(0, currentFile.Length - 4);
                    curName = curName.Replace(filePath + "\\", "");
                    Debug.WriteLine($"Comapring Cur:{curName} to FN: {fileName}");
                    if (curName == fileName)
                    {
                        increment++;
                        Debug.WriteLine($"{currentFile} increment: {increment}");

                    }
                }
                string testName = $"{fileName}_{increment}{fileExt}";
                name = testName;
            }
            return name;
        }

        public void ScreenshotForm(RouletteLog log)
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(log.ClientRectangle.Width, log.ClientRectangle.Height);
            log.DrawToBitmap(bmp, log.ClientRectangle);
            DateTime thisDay = DateTime.Today;
            string dateF = thisDay.ToString(@"yyyy-MM--dd");
            string fileName = $"{dateF}_Final_Roulette";
            string fileExt = $".jpg";
            string fileSearch = fileName + fileExt;
            string file = ImageName(fileSearch, fileName, fileExt);

            try
            {
                if (bmp != null)
                {
                    bmp.Save(@$"{file}");
                    Debug.WriteLine($"Saved image at {Directory.GetCurrentDirectory()}\n path is {Directory.GetCurrentDirectory()}\n");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem saving the file." +
                    "Check the file permissions.");
            }
            //Directory.SetCurrentDirectory(originPath);
            Debug.WriteLine($"path is {Directory.GetCurrentDirectory()}");
        }

        public string ValidatedPath()
        {
            string filePath;
            string path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!Directory.Exists("GachaLog"))
            {

                filePath = Path.Combine(path1, @"GachaLog");
                Directory.CreateDirectory("GachaLog");
                //Debug.WriteLine(filePath);
                return filePath;
            }
            filePath = Path.Combine(path1, @"GachaLog");
            return filePath;
        }

    }
}
