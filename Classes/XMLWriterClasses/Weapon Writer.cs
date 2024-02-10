using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy.Classes.XMLWriterClasses
{
    public class Weapon_Writer : XMLWriter
    {
        public async Task<bool> CreatedWeaponData(string element)
        {
            List<string> weaponLinks = new List<string>();
            List<string> weaponImages = new List<string>();
            Console.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            string htmlCode;
            Debug.WriteLine($"Using URL: {element}");
            using (WebClient c = new WebClient())
            {
                var htmlData = c.DownloadData(element);
                htmlCode = Encoding.UTF8.GetString(htmlData);

            }

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlCode);
            var sect = "//div[@class='mw-parser-output']";
            var table = sect + "/table[2]/tbody/tr/td[2]";
            var linkSec = table + "/a";
            var tableNodes = doc.DocumentNode.SelectNodes(table);
            var links = doc.DocumentNode.SelectNodes(linkSec);
            var skillTd = "//*[@id=\"mw-content-text\"]/div/table[2]/tbody/tr/td[9]";
            int index = 0;
            var img = "//*[@id=\"mw-content-text\"]/div/table[2]/tbody/tr/td[1]/a/img";
            var imgNodes = doc.DocumentNode.SelectNodes(img);
            var skillNodes = doc.DocumentNode.SelectNodes(skillTd);
            foreach (var node in skillNodes)
            {
                //Debug.WriteLine(node.InnerHtml);
                var path = node.XPath;
                var inner = path + "/span";
                var innerNodes = node.Elements("span");
                int indexNode = 0;
                if (node.InnerText is not null)
                {
                    //Debug.WriteLine(node.InnerText);
                    //FormatSkillAndClearCA(node.InnerText);
                }
                //Debug.WriteLine($"Value: {node.InnerHtml}\n Path: {path}");
                if (node.Element("img") is not null)
                {

                }

            }
            foreach (var node in imgNodes)
            {
                //Debug.WriteLine(node.Attributes["src"].Value);   
                weaponImages.Add(mainUrl + node.Attributes["src"].Value);
            }
            foreach (var node in links)
            {
                //Console.WriteLine(node.Attributes["href"].Value);   
                weaponLinks.Add(mainUrl + node.Attributes["href"].Value);
            }
            foreach (var node in tableNodes)
            {
                //Console.WriteLine(node.InnerText);
                //Console.WriteLine(weaponLinks[index]);
                string name = node.InnerText;
                string link = weaponLinks[index];
                string image = weaponImages[index];
                WeaponList weapon = new(name, link, element, image);
                var task = await WroteToWeaponDB(weapon, weaponFN, element);
                index++;
            }
            return true;

        }
        public async Task<bool> WroteToWeaponDB(WeaponList wp, string fileName, string element)
        {

            Debug.WriteLine("writing");
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {

                string path = filePath = Path.Combine(path1, @$"Database\{fileName}");

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                try { doc.Load(path); }
                catch (System.IO.FileNotFoundException)
                {

                }
                string test = doc.InnerXml;
                XmlNode root = doc.SelectSingleNode("weapons");
                using (XmlWriter xmlwriter = root.CreateNavigator().AppendChild())
                {

                    Debug.WriteLine("Appending...");
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteStartElement("weapon");
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("name", wp.weaponName);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("element", element);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("link", wp.weaponLink);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("image", wp.weaponImage);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteWhitespace("\n");
                }
                Debug.WriteLine("Supposingly appended");
                doc.Save(path);
                await Task.Delay(10);
                return true;
            }
            return false;
        }

        public async void CreateWeaponData()
        {
            await CreatedWeaponData(fireURL);
            await CreatedWeaponData(waterURL);
            await CreatedWeaponData(earthURL);
            await CreatedWeaponData(windURL);
            await CreatedWeaponData(darkURL);
            await CreatedWeaponData(lightURL);
        }

    }
}
