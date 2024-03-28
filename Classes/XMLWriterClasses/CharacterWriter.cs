using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static GBF_Never_Buddy.Classes.GameDataClasses;
using System.Xml;
using System.Net;
using System.Xml.XPath;
using System.IO;

namespace GBF_Never_Buddy.Classes.XMLWriterClasses
{
    public class CharacterWriter : XMLWriter
    {
        List<string> characters = new List<string>();   
         public async void UpdateCharacterData(HomePage homePage)
        {
           
            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            Debug.WriteLine($"Retrieving data from {url}");
            homePage.Enabled = false;
            var task = await (WebPageIsValid(url));
          
            if (task)
            {
                string htmlCode = htmlData;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var body = "content";
                var bodyContent = "bodyContent";
                var contentFrame = "mw-content-text";
                var parserFrame = "mw-parser-output";
                await CreatedPremiumList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                await CreatedClassicList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                await CreatedGrandList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                await CreatedZodiacList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                await CreatedVDayList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                await CreatedHWList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                await CreatedSummerList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                await CreatedXmasList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
            }
         
     
            homePage.Enabled = true;    
        }

        public async Task<bool> CreateCharacterList()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            Debug.WriteLine($"Retrieving data from {url}");
            var task = await (WebPageIsValid("https://gbf.wiki/SSR_Characters_List"));
            if(task)
            {
                var nameList = await GetCharacterNames();
                if (nameList)
                {
                    string htmlCode = htmlData;
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlCode);
                    var body = "content";
                    var bodyContent = "bodyContent";
                    var contentFrame = "mw-content-text";
                    var parserFrame = "mw-parser-output";
                    await CreatedPremiumList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                    await CreatedClassicList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                    await CreatedGrandList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                    await CreatedZodiacList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                    await CreatedVDayList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                    await CreatedHWList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                    await CreatedSummerList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                    await CreatedXmasList(doc, body, bodyContent, contentFrame, parserFrame, fileName);
                }
            }
          

            return true;
        }

        public async Task<bool> GetCharacterNames()
        {   
            characters.Clear(); 
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if(path1 != null)
            {
                string path = filePath = Path.Combine(path1, @$"Database\{fileName}");
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
                            characters.Add(n.InnerText);
                        }
                    }
                    await Task.Delay(1);
                }
                return true;
            }
            return false;

        }


        public async void CreateAllCList()
        {

            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            Debug.WriteLine($"Retrieving data from {url}");
            var task = await (WebPageIsValid(url));
            if (task)
            {
                string htmlCode = htmlData;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var body = "content";
                var bodyContent = "bodyContent";
                var contentFrame = "mw-content-text";
                var parserFrame = "mw-parser-output";
                await CreatedPremiumList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedClassicList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedGrandList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedZodiacList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedVDayList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedHWList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedSummerList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedXmasList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedResortList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedWorldBeyondList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedSideStoriesList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedCollabList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedPromoList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedEternalsList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
                await CreatedEvokersList(doc, body, bodyContent, contentFrame, parserFrame, allCharsFileName);
            }
        }


        public async Task<bool> CreatedPremiumList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                            string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[1]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[1]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[1]/tbody/tr/td[1]/a[1]/img";

            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            Debug.WriteLine(img);
            
            var task = await CreatedCharacterDetails(name, element, img, "Premium", file);
            if (task)
            {
                return true;
            }
            
            return false;
        }

        public async Task<bool> CreatedClassicList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[2]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[2]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[2]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Classic", file);
            if (task)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CreatedGrandList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[4]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[4]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[4]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Grand", file);
            if (task)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CreatedZodiacList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[5]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[5]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[5]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "12 Generals", file);
            if (task)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CreatedVDayList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[6]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[6]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[6]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Valentine", file);
            if (task)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CreatedHWList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[8]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[8]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[8]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Halloween", file);
            if (task)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CreatedSummerList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[7]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[7]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[7]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Summer/Yukata", file);
            if (task)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> CreatedXmasList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[9]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[9]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[9]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Holiday", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedResortList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[10]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[10]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[10]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Jewel Resort Casino", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedWorldBeyondList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[11]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[11]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[11]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Arcarum: The World Beyond", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedSideStoriesList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[12]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[12]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[12]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Side Stories", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedCollabList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[13]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[13]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[13]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Collaboration", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedPromoList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[14]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[14]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[14]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Promo", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedEternalsList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[15]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[15]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[15]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "The Eternals", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedEvokersList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[16]/tbody/tr/td[2]"; ;
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[16]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[16]/tbody/tr/td[1]/a/img";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var task = await CreatedCharacterDetails(name, element, img, "Arcarum Evokers", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedCharacterDetails(HtmlAgilityPack.HtmlNodeCollection name,
            HtmlAgilityPack.HtmlNodeCollection element, HtmlAgilityPack.HtmlNodeCollection img, string series, string fileName)
        {
            //Unable to retrieve proper images
            if (name != null)
            {
                for (int i = 0; i < name.Count; i++)
                {
                    Debug.WriteLine($"{name[i].InnerText}");
                }
                //Debug.WriteLine("passed");
                if (name.Count == element.Count)
                {
                    for (int i = 0; i < name.Count; i++)
                    {
                       // Debug.WriteLine($"it:{i} of {name.Count()} img: {img.Count}");
                        HtmlAgilityPack.HtmlNode node = name[i];
                        //Debug.WriteLine(node.ChildNodes.Count);
                        HtmlAgilityPack.HtmlNode node1 = element[i];
                        HtmlAgilityPack.HtmlNode node2 = img[i];
                        var att = node2.Attributes.ToList();
                        /*
                        foreach(var a in att)
                        {
                            Debug.WriteLine(a.Name);
                        }
                        */
                        string title = node.InnerText;
                        string nameLink = node.SelectSingleNode("a").Attributes["href"].Value.ToString();
                        string mainLink = mainUrl.Substring(0, mainUrl.Length - 1);
                        //Debug.WriteLine($"{mainLink}{nameLink}");
                        string link = $"{mainLink}{nameLink}";
                        string el = node1.Attributes["data-filter-element"].Value;
                        var imgsrc1 = node2.Attributes["src"];
                        var imgsrc2 = node2.Attributes["srcset"];
                        string imgLink = "";
                        if(imgsrc1 == null && imgsrc2 != null)
                        {
                            imgLink = mainUrl + node2.Attributes["srcset"].Value.ToString();
                        }
                        if (imgsrc1 != null && imgsrc2 == null)
                        {
                            imgLink = mainUrl + node2.Attributes["src"].Value.ToString();
                        }
                        Debug.WriteLine($"Character {title}, el:{el}, link:{imgLink}, series: {series}, link: {link}");
                        var existsInList = characters.Contains(title);
                        if (existsInList)
                        {
                            //Debug.WriteLine($"Skipping {title}");
                        }
                        if(!existsInList)
                        {
                            Character newChr = new Character(title, el, series, imgLink, link);

                            var task = await WroteToCharDB(newChr, fileName);
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

        public async Task<bool> WroteToCharDB(Character chr, string fileName)
        {


            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {

                string path = filePath = Path.Combine(path1, @$"Database\{fileName}");
             
                //FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                try { doc.Load(path); }
                catch (System.IO.FileNotFoundException)
                {

                }
                string test = doc.InnerXml;
                XmlNode root = doc.SelectSingleNode("characters");
                XPathNavigator navigator = root.CreateNavigator();
                using (XmlWriter xmlwriter = navigator.AppendChild())
                {
                    xmlwriter.WriteStartElement("character");
                    xmlwriter.WriteAttributeString("series", chr.series);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("name", chr.name);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("element", chr.element);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("image", chr.image);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteElementString("link", chr.link);
                    xmlwriter.WriteWhitespace("\n\t");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteWhitespace("\n");
                }

                doc.Save(path);
                await Task.Delay(10);
    
                return true;
                
            }
            return false;
        }
    }
}
