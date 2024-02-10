using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy.Classes.XMLWriterClasses
{
    public class XMLWriter
    {   
      
        
        static readonly HttpClient client = new();
        public string url = "https://gbf.wiki/SSR_Characters_List";
        public string mainUrl = "https://gbf.wiki/";
        public string htmlData = "";
        public string filePath = "";
        public string fileName = "SSRCharacters.xml";
        public string weaponFN = "SSRWeapons.xml";
        public string summonsLink = "https://gbf.wiki/SSR_Summons_List";
        public string summonsFN = "SSRSummons.xml";
        public string jobLink = "https://gbf.wiki/Classes";
        public string classesFN = "MC_Classes.xml";
        public string allCharsFileName = "AllSSRCharacters.xml";
        public string fireURL = "https://gbf.wiki/Weapon_Lists/SSR/Fire";
        public string waterURL = "https://gbf.wiki/Weapon_Lists/SSR/Water";
        public string earthURL = "https://gbf.wiki/Weapon_Lists/SSR/Earth";
        public string windURL = "https://gbf.wiki/Weapon_Lists/SSR/Wind";
        public string darkURL = "https://gbf.wiki/Weapon_Lists/SSR/Dark";
        public string lightURL = "https://gbf.wiki/Weapon_Lists/SSR/Light";

        public void ValidateXMLFile()
        {
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                string filePath = Path.Combine(path1, @$"Database\{fileName}");
                var exists = File.Exists(filePath);
                Debug.WriteLine(File.Exists(filePath) ? "File exists." : "File does not exist.");
                if (exists == false)
                {
                   Debug.WriteLine("Creating Characters db");
                    string dir = Directory.GetCurrentDirectory();
                    string location = System.IO.Path.Combine(dir, "Database");
                    //CreateXMLFile(location, fileName, "characters");
                }

            }
        }

        public void ValidateSummonFile()
        {
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                string filePath = Path.Combine(path1, @$"Database\{summonsFN}");
                var exists = File.Exists(filePath);
                Debug.WriteLine(File.Exists(filePath) ? "File exists." : "File does not exist.");
                if (exists == false)
                {
                    Debug.WriteLine("Creating Characters db");
                    string dir = Directory.GetCurrentDirectory();
                    string location = System.IO.Path.Combine(dir, "Database");
                    CreateXMLFile(location, summonsFN, "summons");
                }

            }
        }

        public bool DBExists(string filePath, string fileName)
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine("That path exists already.");
                return true;
            }
            if (!File.Exists(filePath))
            {
                string errmsg = $"Error: {fileName} could not be found.\nCreating {fileName}";
                const string caption = "Database Error Occured";
                var result = MessageBox.Show(errmsg, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Question);
            }
            return false;
        }

        public void CreateXMLFile(string location, string fileName, string rootElement)
        {

            string pathString = location;
            System.IO.Directory.CreateDirectory(pathString);
            Directory.SetCurrentDirectory(pathString);
            using XmlWriter writer = XmlWriter.Create(fileName);
            writer.WriteStartDocument();
            Debug.WriteLine("writing head");
            writer.WriteWhitespace("\n");
            writer.WriteStartElement(rootElement);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close(); 
            Debug.WriteLine("Done writing");
        }

        public async Task<bool> WebPageIsValid(string passedURL)
        {
            Debug.WriteLine($"Task is running attempting to get response from {passedURL}");
            bool responseRecieved = Uri.TryCreate(passedURL, UriKind.Absolute, out Uri myUri);
            if (responseRecieved)
            {
                try
                {
                    string responseBody = await client.GetStringAsync(passedURL);
                    Debug.WriteLine($"Link {passedURL} is valid");
                    htmlData = responseBody;
                    return true;
                }
                catch (HttpRequestException e)
                {
                    Debug.WriteLine($"Exception caught\nMessage :{e.Message} Link: {e.InnerException} \n {e.Source}");
                    string caption = "Failed to load data from URL";
                    string message = $"Error occured when reading {passedURL}'s data\n {e.Message}";
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
                    return false;
                }
            }

            return false;
        }


     

        public void LoadSummonDataFromXML()
        {
            Stopwatch timer = Stopwatch.StartNew();
            XmlDocument doc = new XmlDocument();
            string pathEnd = @"Database\SSRSummonsF.xml";
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), pathEnd);
            var directory = Directory.GetCurrentDirectory();
            string truePath = Path.Combine(directory, pathEnd);
            doc.PreserveWhitespace = true;
            try { doc.Load(truePath); }
            catch (System.IO.FileNotFoundException)
            {

            }
            XmlNode root = doc.SelectSingleNode("summons");
            try
            {

                XmlNodeList xnList = root.SelectNodes("summon");
                var document = XDocument.Load(path);
                XElement xmlTree = document.Root;
                //Console.Write(document.ToString());
                document.Descendants().Where(t => string.IsNullOrEmpty(t.Value)).Remove();
                doc.Save(path);
                int index = 1;
                foreach (XmlNode xn in xnList)
                {
                    string name = xn["name"].InnerText;
                    string element = xn["element"].InnerText;
                    string link = xn["link"].InnerText;
                    string image = xn["image"].InnerText;
                    //Summon summon = new(name, element, link, image);
                    //summonDB.Add(summon);
                    Debug.WriteLine($"Added summon {name}, {element}, {link}");
                    index++;
                }

            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("XPath could not find an item", e);
            }
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;

            string time = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
            Debug.WriteLine($"Elapsed time for function loadXMLData(): {time}");

        }


    }


}
