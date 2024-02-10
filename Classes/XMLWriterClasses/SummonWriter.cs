using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GBF_Never_Buddy.Classes.GameDataClasses;
using System.Xml;

namespace GBF_Never_Buddy.Classes.XMLWriterClasses
{
    public class SummonWriter : XMLWriter
    {   
        List<string> names = new List<string>();    
        public async void CreateSummonsList()
        {
            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            Debug.WriteLine($"Retrieving data from {summonsLink}");
            var task = await (WebPageIsValid(summonsLink));
            if (task)
            {
                var nameList = await GetNames();
                if(nameList)
                {
                    string htmlCode = htmlData;
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlCode);
                    var body = "content";
                    var bodyContent = "bodyContent";
                    var contentFrame = "mw-content-text";
                    var parserFrame = "mw-parser-output";

                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "1", "Premium");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "2", "Premium");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "3", "Classic");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "4", "Summer/Yukata");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "5", "Holiday");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "6", "Omega");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "7", "Normal Showdown");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "8", "Xeno");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "9", "Jewel Resort Casino");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "10", "Free Quest");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "11", "Side Story");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "12", "Rise of the Beasts");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "13", "Unite and Fight");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "14", "Showdown Event");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "15", "Collaboration");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "16", "Story Event");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "17", "Defense Order");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "18", "Promotion");
                    await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "19", "Arcarum: The World Beyond");
                }
            }
        }

        public async Task<bool> GetNames()
        {
            names.Clear();
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                string path = filePath = Path.Combine(path1, @$"Database\{summonsFN}");
                Console.WriteLine(filePath);
                //FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                try { doc.Load(path); }
                catch (System.IO.FileNotFoundException)
                {

                }
                var nodeList = doc.GetElementsByTagName("name");
                if (nodeList != null)
                {
                    if (nodeList.Count > 0)
                    {
                        foreach (XmlNode node in nodeList)
                        {
                            var n = node;
                            names.Add(n.InnerText);
                        }
                    }
                    await Task.Delay(1);
                }
                return true;
            }
            return false;

        }

        public async Task<bool> CreateSummonDetailList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file, string tbNum, string series)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[{tbNum}]/tbody/tr/td[2]";
            var tabTest = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
              $"/div[@class='{parserFrame}']/table[{tbNum}]/tbody/tr/td[3]/img";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[{tbNum}]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[{tbNum}]/tbody/tr/td[1]/a/img";
            var test = $"//*[@id=\"mw-content-text\"]/div/table[{tbNum}]/tbody/tr[1]/td[3]";
            var linkTab = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
              $"/div[@class='{parserFrame}']/table[{tbNum}]/tbody/tr/td[2]/a";
            //*[@id="mw-content-text"]/div/table[1]/tbody/tr[1]/td[3]/img
            var name = doc.DocumentNode.SelectNodes(tab1);
            var link = doc.DocumentNode.SelectNodes(linkTab);
            var element = doc.DocumentNode.SelectNodes(tabTest);
            var img = doc.DocumentNode.SelectNodes(tab3);

            Debug.WriteLine($"Name nodes: {name.Count},{element.Count}  img: {img.Count}");
            var task = await CreatedSummonDetails(name, link, element, img, series, file);
            if (task)
            {
                return true;
            }
            return false;
        }


        public async Task<bool> WroteToSummonDB(Summon s, string fileName)
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
                XmlNode root = doc.SelectSingleNode("summons");
                using (XmlWriter xmlwriter = root.CreateNavigator().AppendChild())
                {

                    Debug.WriteLine("Appending...");
                    xmlwriter.WriteStartElement("summon");
                    xmlwriter.WriteAttributeString("series", s.series);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("name", s.name);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("element", s.element);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("image", s.image);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("link", s.link);
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

        public async Task<bool> CreatedSummonDetails(HtmlAgilityPack.HtmlNodeCollection name, HtmlAgilityPack.HtmlNodeCollection link,
           HtmlAgilityPack.HtmlNodeCollection element, HtmlAgilityPack.HtmlNodeCollection img, string series, string fileName)
        {
            Encoding ascii = Encoding.ASCII;

            if (name != null)
            {
                Debug.WriteLine("passed");
                if (name.Count == element.Count)
                {
                    for (int i = 0; i < name.Count; i++)
                    {
                        HtmlAgilityPack.HtmlNode node = name[i];
                        HtmlAgilityPack.HtmlNode node1 = element[i];
                        HtmlAgilityPack.HtmlNode node2 = link[i];
                        HtmlAgilityPack.HtmlNode node3 = img[i];
                        string title = node.InnerText;
                        title = title.TrimEnd(' ');
                        var imgNodePath = "//*[@id=\"mw-content-text\"]/div/table[1]/tbody/tr[1]/td[3]/img";
                        var elementNode = node1.SelectSingleNode("//img");
                        string el = node1.Attributes["srcset"].Value;
                        string formatEl = FormatSummmonElement(el);
                        string image = mainUrl + node3.Attributes["src"].Value.ToString();
                        string url = mainUrl + node2.Attributes["href"].Value.ToString();

                        var exists = names.Contains(title);
                        if(!exists)
                        {
                            string decoded = System.Web.HttpUtility.HtmlDecode(title);
                            Summon summon = new Summon(decoded, series, formatEl, image, url);
                            Debug.WriteLine($"Summon {summon.name}, el:{summon.element}, link:{summon.image}, series{summon.series}, url:{summon.link}");
                            var task = await WroteToSummonDB(summon, fileName);
                            if (task)
                            {
                                Debug.WriteLine("Wrote");
                            }
                        }
                    }
                    return true;
                }
            }
            Debug.WriteLine("failed");
            return false;
        }

        private string FormatSummmonElement(string input)
        {
            string str = input;
            string strRt = input.Replace("/images/b/b7/Label_Element_", "");
            strRt = strRt.Replace("/images/a/a7/Label_Element_", "");
            strRt = strRt.Replace("/images/0/0c/Label_Element_", "");
            strRt = strRt.Replace("/images/e/ee/Label_Element_", "");
            strRt = strRt.Replace("/images/3/3b/Label_Element_", "");
            strRt = strRt.Replace("/images/1/10/Label_Element_", "");
            strRt = strRt.Replace(".png", "");
            strRt = strRt.Replace(" 1.5x", "");
            return strRt;
        }

     

    }
}
