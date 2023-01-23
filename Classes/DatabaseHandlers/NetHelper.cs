using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy.Classes.DatabaseHandlers
{
    internal class NetHelper : DatabaseHandler
    {
        private static readonly HttpClient client = new();
        string url = "https://gbf.wiki/SSR_Characters_List";
        string mainUrl = "https://gbf.wiki/";
        string baseUrl = "https://gbf.wiki";
        private string htmlData = "";
        private string filePath = "";
        private string allFN = "AllSSRCharacters.xml";
        private string fileName = "SSRCharacters.xml";
        string summonsLink = "https://gbf.wiki/SSR_Summons_List";
        string summonsFN = "SSRSummons.xml";
        public bool DBValidated = false;

        public async void AuthenticateDB()
        {
            string filePath = "";
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                filePath = Path.Combine(path1, @"Database\SSRCharacters.xml");
                Debug.WriteLine(filePath);
            }
            Debug.WriteLine("Authenticating db");
            var validDb = DBExists(filePath, fileName);
            if (validDb)
            {
                Debug.WriteLine("Valid db");
                DBValidated = true;
                return;
            }
            if (!validDb)
            {
                Debug.WriteLine("Creating Characters db");
                string dir = Directory.GetCurrentDirectory();
                string location = Path.Combine(dir, "Database");
                CreateXMLFile(location, fileName, "characters");
                var task1 = await CreatedList();
            }
        }

        public async void CreateAllCharFile()
        {
            string filePath = "";
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                filePath = Path.Combine(path1, @"Database\SSRCharacters.xml");
                Debug.WriteLine(filePath);
            }
            string dir = Directory.GetCurrentDirectory();
            string location = Path.Combine(dir, "Database");
            CreateXMLFile(location, allFN, "characters");
            var task1 = await CreatedAllList();
        }

        public async Task<bool> OverwroteCharDB()
        {

            string filePath = "";
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                filePath = Path.Combine(path1, @"Database\SSRCharacters.xml");
                Debug.WriteLine(filePath);
            }
            Debug.WriteLine("Authenticating db");
            var task1 = await CreatedCharList();
            if (task1)
            {
                return true;
            }
            return false;
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
            Directory.CreateDirectory(pathString);
            Directory.SetCurrentDirectory(pathString);
            using XmlWriter writer = XmlWriter.Create(fileName);
            writer.WriteStartDocument();
            Debug.WriteLine("writing head");
            writer.WriteWhitespace("\n");
            writer.WriteStartElement(rootElement);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            Debug.WriteLine("Done writing");
        }

        private async Task<bool> CreatedXMLFile(string location, string fileName, string rootElement)
        {

            string pathString = location;
            Directory.CreateDirectory(pathString);
            Directory.SetCurrentDirectory(pathString);
            using XmlWriter writer = XmlWriter.Create(fileName);
            writer.WriteStartDocument();
            Debug.WriteLine("writing head");
            writer.WriteWhitespace("\n");
            writer.WriteStartElement(rootElement);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            Debug.WriteLine("Done writing");
            await Task.Delay(1);
            return true;
        }


        private async Task<bool> WebPageIsValid(string passedURL)
        {
            Debug.WriteLine("Task is running");
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
                    Debug.WriteLine($"Exception caught\nMessage :{e.Message} ");
                    string caption = "Failed to load data from URL";
                    string message = $"Error occured when reading {passedURL}'s data\n {e.Message}";
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> CreatedCharList()
        {
            var parent = Application.OpenForms["HomePage"];
            if (parent != null)
            {
                Debug.WriteLine($"{parent.Name}");
                HomePage home = (HomePage)parent;
                MenuStrip menuStrip = (MenuStrip)home.Controls["MainMenuStrip"];
                Panel mainPanel = (Panel)home.Controls["mainPanel"];
                menuStrip.Enabled = false;
                mainPanel.Enabled = false;
            }

            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            Debug.WriteLine($"Retrieving data from {url}");
            var task = await WebPageIsValid(url);
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
                var endTask = await CreatedXmasList(doc, body, bodyContent, contentFrame, parserFrame, fileName);

                if (endTask && parent != null)
                {
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> CreatedList()
        {
            var parent = Application.OpenForms["HomePage"];
            if (parent != null)
            {
                Debug.WriteLine($"{parent.Name}");
                HomePage home = (HomePage)parent;
                MenuStrip menuStrip = (MenuStrip)home.Controls["MainMenuStrip"];
                Panel mainPanel = (Panel)home.Controls["mainPanel"];
                menuStrip.Enabled = false;
                mainPanel.Enabled = false;
            }

            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            Debug.WriteLine($"Retrieving data from {url}");
            var task = await WebPageIsValid(url);
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
                var endTask = await CreatedXmasList(doc, body, bodyContent, contentFrame, parserFrame, fileName);

                if (endTask && parent != null)
                {
                    DBValidated = true;
                    HomePage home = (HomePage)parent;
                    MenuStrip menuStrip = (MenuStrip)home.Controls["MainMenuStrip"];
                    Panel mainPanel = (Panel)home.Controls["mainPanel"];
                    menuStrip.Enabled = true;
                    mainPanel.Enabled = true;
                }
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedAllList()
        {
            var parent = Application.OpenForms["HomePage"];
            if (parent != null)
            {
                Debug.WriteLine($"{parent.Name}");
                HomePage home = (HomePage)parent;
                MenuStrip menuStrip = (MenuStrip)home.Controls["MainMenuStrip"];
                Panel mainPanel = (Panel)home.Controls["mainPanel"];
                menuStrip.Enabled = false;
                mainPanel.Enabled = false;
            }

            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            Debug.WriteLine($"Retrieving data from {url}");
            var task = await WebPageIsValid(url);
            if (task)
            {
                Debug.WriteLine("Writing data");
                string htmlCode = htmlData;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var body = "content";
                var bodyContent = "bodyContent";
                var contentFrame = "mw-content-text";
                var parserFrame = "mw-parser-output";
                await CreatedPremiumList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedClassicList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedGrandList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedZodiacList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedVDayList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedHWList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedSummerList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedResortList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedWorldBeyondList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedSideStoriesList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedPromoList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                await CreatedEternalsList(doc, body, bodyContent, contentFrame, parserFrame, allFN);
                var endTask = await CreatedEvokersList(doc, body, bodyContent, contentFrame, parserFrame, allFN);

                if (endTask && parent != null)
                {
                    DBValidated = true;
                    HomePage home = (HomePage)parent;
                    MenuStrip menuStrip = (MenuStrip)home.Controls["MainMenuStrip"];
                    Panel mainPanel = (Panel)home.Controls["mainPanel"];
                    menuStrip.Enabled = true;
                    mainPanel.Enabled = true;
                }
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedPremiumList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            Debug.WriteLine("Premimum");
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[1]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[1]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[1]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[1]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Premium", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedClassicList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[2]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[2]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[2]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[2]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Classic", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedGrandList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[4]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[4]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[4]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[4    ]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Grand", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedZodiacList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[5]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[5]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[5]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[5]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "12 Generals", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedVDayList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[6]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[6]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[6]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[6]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Valentine", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedSummerList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[7]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[7]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[7]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[7]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Summer/Yukata", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedHWList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[8]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[8]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[8]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[8]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Halloween", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedXmasList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[9]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[9]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[9]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[9]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Holiday", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedResortList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[10]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[10]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[10]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[10]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Resort", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedWorldBeyondList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[11]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[11]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[11]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[11]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Arcarum: The World Beyond", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedSideStoriesList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[12]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[12]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[12]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[12]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Side Stories", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedCollabList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[13]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[13]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[13]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[13]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Collaboration", file);
            if (task)
            {
                return true;
            }
            return false;
        }
        private async Task<bool> CreatedPromoList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                         string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[14]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[14]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[14]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[14]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Promotion", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedEternalsList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                           string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[15]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[15]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[15]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[15]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Eternals", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedEvokersList(HtmlAgilityPack.HtmlDocument doc, string body, string bodyContent,
                          string contentFrame, string parserFrame, string file)
        {
            var tab1 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[16]/tbody/tr/td[2]";
            var tab2 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[16]/tbody/tr[@data-type='c']";
            var tab3 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                            $"/div[@class='{parserFrame}']/table[16]/tbody/tr/td[1]/a/img";
            var tab4 = $"//body/div[@id='{body}']/div[@id='{bodyContent}']/div[@id='{contentFrame}']" +
                          $"/div[@class='{parserFrame}']/table[16]/tbody/tr/td[2]/a";
            var name = doc.DocumentNode.SelectNodes(tab1);
            var element = doc.DocumentNode.SelectNodes(tab2);
            var img = doc.DocumentNode.SelectNodes(tab3);
            var link = doc.DocumentNode.SelectNodes(tab4);
            var task = await CreatedCharacterDetails(name, element, img, link, "Evokers", file);
            if (task)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedCharacterDetails(HtmlAgilityPack.HtmlNodeCollection name,
           HtmlAgilityPack.HtmlNodeCollection element, HtmlAgilityPack.HtmlNodeCollection img, HtmlAgilityPack.HtmlNodeCollection urlNode, string series, string fileName)
        {

            if (name != null)
            {
                //Debug.WriteLine("passed");
                if (name.Count == element.Count)
                {
                    for (int i = 0; i < name.Count; i++)
                    {
                        HtmlAgilityPack.HtmlNode node = name[i];
                        HtmlAgilityPack.HtmlNode node1 = element[i];
                        HtmlAgilityPack.HtmlNode node2 = img[i];
                        HtmlAgilityPack.HtmlNode node3 = urlNode[i];
                        string title = node.InnerText;
                        string charUrl = baseUrl + node3.Attributes["href"].Value;
                        string el = node1.Attributes["data-filter-element"].Value;
                        string link = baseUrl + node2.Attributes["src"].Value.ToString();
                        //Debug.WriteLine($"Base {baseUrl}, second part {node2.Attributes["src"].Value}");
                        //Debug.WriteLine($"Character {title}, el:{el}, link:{link}, series{series}, url:{charUrl}");
                        Character newChr = new Character(title, el, series, link, charUrl);
                        var task = await WroteToCharDB(newChr, fileName);
                        if (task)
                        {
                            //Debug.WriteLine($"Wrote {newChr.name}");
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

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                try { doc.Load(path); }
                catch (FileNotFoundException)
                {

                }
                //Debug.WriteLine($"Character details: {chr.name}, {chr.series}");
                string test = doc.InnerXml;
                XmlNode root = doc.SelectSingleNode("characters");
                using (XmlWriter xmlwriter = root.CreateNavigator().AppendChild())
                {

                    //Debug.WriteLine("Appending...");
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
                //Debug.WriteLine("Appended");
                doc.Save(path);
                await Task.Delay(10);
                return true;
            }
            return false;
        }

        private async Task<bool> CreatedSummonsList()
        {
            Debug.WriteLine("Running");
            Encoding utf8 = new UTF8Encoding(true);
            Debug.WriteLine($"Retrieving data from {summonsLink}");
            var task = await WebPageIsValid(summonsLink);
            if (task)
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
                var final = await CreateSummonDetailList(doc, body, bodyContent, contentFrame, parserFrame, summonsFN, "19", "Arcarum: The World Beyond");
                if (final)
                {
                    MBHelper mBHelper = new();
                    string msg = $"Finished created {summonsFN}";
                    string cap = $"Created xml file";
                    mBHelper.SuccessMB(msg, cap);
                    return true;
                }
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


        public async Task<bool> WroteToSummonDB(Summon chr, string fileName)
        {

            //Debug.WriteLine("writing");
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {

                string path = filePath = Path.Combine(path1, @$"Database\{fileName}");

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                try { doc.Load(path); }
                catch (FileNotFoundException)
                {

                }
                string test = doc.InnerXml;
                XmlNode root = doc.SelectSingleNode("summons");
                using (XmlWriter xmlwriter = root.CreateNavigator().AppendChild())
                {

                    //Debug.WriteLine("Appending...");
                    xmlwriter.WriteStartElement("summon");
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
                //Debug.WriteLine("Supposingly appended");
                doc.Save(path);
                await Task.Delay(10);
                return true;
            }
            return false;
        }

        public async Task<bool> CreatedSummonDetails(HtmlAgilityPack.HtmlNodeCollection name, HtmlAgilityPack.HtmlNodeCollection link,
           HtmlAgilityPack.HtmlNodeCollection element, HtmlAgilityPack.HtmlNodeCollection img, string series, string fileName)
        {

            if (name != null)
            {
                //Debug.WriteLine("passed");
                if (name.Count == element.Count)
                {
                    for (int i = 0; i < name.Count; i++)
                    {
                        HtmlAgilityPack.HtmlNode node = name[i];
                        HtmlAgilityPack.HtmlNode node1 = element[i];
                        HtmlAgilityPack.HtmlNode node2 = link[i];
                        HtmlAgilityPack.HtmlNode node3 = img[i];
                        string title = node.InnerText;
                        Debug.WriteLine(node1.InnerHtml);
                        var imgNodePath = "//*[@id=\"mw-content-text\"]/div/table[1]/tbody/tr[1]/td[3]/img";
                        var elementNode = node1.SelectSingleNode("//img");
                        string el = node1.Attributes["srcset"].Value;
                        string formatEl = FormatSummmonElement(el);
                        string image = mainUrl + node3.Attributes["src"].Value.ToString();
                        string url = mainUrl + node2.Attributes["href"].Value.ToString();

                        //Debug.WriteLine($"Character {title}, el:{formatEl}, link:{image}, series{series}, url:{url}");
                        Summon summon = new(title, series, formatEl, image, url);
                        //Debug.WriteLine($"Summon {summon.name}, el:{summon.element}, image:{summon.image}, series{summon.series}, url:{summon.link}");
                        var task = await WroteToSummonDB(summon, fileName);
                        if (task)
                        {
                            //Debug.WriteLine("Wrote");
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

        public async Task<bool> ValidatedCharacterFile()
        {
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                string filePath = Path.Combine(path1, @$"Database\{fileName}");
                Debug.WriteLine(filePath);
                if (!File.Exists(fileName))
                {
                    Debug.WriteLine("Creating Character db");
                    string dir = Directory.GetCurrentDirectory();
                    string location = Path.Combine(dir, "Database");
                    var task = await CreatedXMLFile(location, fileName, "characters");
                    if (task)
                    {
                        var task1 = await CreatedList();
                        if (task)
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
        }

        public async Task<bool> ValidatedSummonFile()
        {
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                string filePath = Path.Combine(path1, @$"Database\{summonsFN}");
                Debug.WriteLine(filePath);
                if (!File.Exists(fileName))
                {
                    Debug.WriteLine("Creating Summons db");
                    string dir = Directory.GetCurrentDirectory();
                    string location = Path.Combine(dir, "Database");
                    var task = await CreatedXMLFile(location, summonsFN, "summons");
                    if (task)
                    {
                        await CreatedSummonsList();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
