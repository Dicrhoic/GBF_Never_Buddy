using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GBF_Never_Buddy.Classes.GameDataClasses;
using System.Xml.Linq;
using System.Xml;

namespace GBF_Never_Buddy.Classes.SQLClasses
{
    public class SummonSQLClass : SQLClass  
    {
        public void UpdateDBFromXML()
        {

            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string? filePath;
            if (path != null)
            {
                Debug.WriteLine(path);
                filePath = Path.Combine(path, @"Database\SSRSummons.xml");
                var exists = File.Exists(filePath);
                Debug.WriteLine(File.Exists(filePath) ? "File exists." : "File does not exist.");
                if (exists == false)
                {
                    MBHelper mB = new MBHelper();
                    string caption = $"Error Adding to DB";
                    string msg = $"File doesn't exists at {Directory.GetCurrentDirectory()}";
                    mB.ErrorMB(msg, caption);
                }
                if (exists == true)
                {
                    UpdateListFromXML(filePath);
                }
              
            }

        }

        public List<Summon> GachaList()
        {
            List<Summon> list = new List<Summon>();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM SSRSummons
                    WHERE Series='Premium' OR Series='Classic' OR Series='Summer/Yukata' OR Series='Holiday'
                ";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = "";
                        string element = "";
                        string link = "";
                        string series = "";
                        string image = "";
                        name = reader.GetString(1);
                        element = reader.GetString(3);
                        link = reader.GetString(5);
                        series = reader.GetString(2);
                        image = reader.GetString(4);
                        Summon summon = new(name, series, element, image, link);
                        list.Add(summon);
                    }

                }

            }
            return list;
        }

        public SortedList<string, Summon> LookupList()
        {
            SortedList<string, Summon> list = new();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM SSRSummons
                    WHERE Series='Premium' OR Series='Classic' OR Series='Summer/Yukata' OR Series='Holiday'
                ";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = "";
                        string element = "";
                        string link = "";
                        string series = "";
                        string image = "";
                        name = reader.GetString(1);
                        element = reader.GetString(3);
                        link = reader.GetString(5);
                        series = reader.GetString(2);
                        image = reader.GetString(4);
                        Summon summon = new(name, series, element, image, link);
                        list.Add(name, summon);
                    }

                }

            }
            return list;
        }

        public List<Summon> List()
        {
            List<Summon> list = new List<Summon>();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM SSRSummons
                ";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = "";
                        string element = "";
                        string link = "";
                        string series = "";
                        string image = "";
                        name = reader.GetString(1);
                        element = reader.GetString(3);
                        link = reader.GetString(5);
                        series = reader.GetString(2);
                        image = reader.GetString(4);
                        Summon summon = new(name, series, element, image, link);
                        list.Add(summon);
                    }

                }

            }
            return list;
        }

        private int Count()
        {
            int count = 0;
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT COUNT(*) FROM SSRSummons
                ";
                Int64 res = (Int64)command.ExecuteScalar();
                count = (Int32)res;

            }
            return count;
        }

        public string FormatSqlString(string data)
        {
            int index = -1;
            index = data.IndexOf('\'');
            if (index != -1)
            {
                string subStr = data.Substring(0, index);
                int length = data.Length;
                int newIndex = index + 1;
                string subStr1 = data.Substring(newIndex, length - newIndex);
                Debug.WriteLine($"First half: {subStr}");
                Debug.WriteLine($"Second half: {subStr1}");
                string merge = $"{subStr}''{subStr1}";
                Debug.WriteLine(merge);

                return merge;
            }
            return data;
        }

        private async void UpdateListFromXML(string path)
        {
            MBHelper helper = new MBHelper();
            Stopwatch timer = Stopwatch.StartNew();
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            int addCount = 0;
            try { doc.Load(path); }
            catch (System.IO.FileNotFoundException)
            {

            }
            XmlNode? root = doc.SelectSingleNode("summons");
            List<Summon> summons = List();
            List<string> names = summons.Select(x => x.name).ToList();
            if (root != null)
            {
                LockParent();
                XmlNodeList docCharacters = doc.GetElementsByTagName("name");
                List<string> xmlChars = new();
                foreach (XmlNode node in docCharacters)
                {
                    xmlChars.Add(node.InnerText);
                }
                List<string> newChars = xmlChars.Except(names).Distinct().ToList();
            
                XmlNodeList? xnList = root.SelectNodes("summon");
                var document = XDocument.Load(path);
                XElement? xmlTree = document.Root;

                document.Descendants().Where(t => string.IsNullOrEmpty(t.Value)).Remove();
                doc.Save(path);
                int index = 1;
                int newIndex = Count();
    
                if (xmlTree != null && xnList != null)
                {

                    foreach (XmlNode xn in xnList)
                    {

                        string series = xn.Attributes["series"].Value;
                        string name = xn["name"].InnerText;
                        string element = xn["element"].InnerText;
                        string img = xn["image"].InnerText;
                        string link = xn["link"].InnerText;
                        //string nameCleaned = FormatSqlString(name);
                        var exists = newChars.Contains(name);
                        if (!exists)
                        {
                            //Debug.WriteLine($"Skipping {name}");
                        }
                        if (exists)
                        {

                            newIndex++;
                            string decoded = System.Web.HttpUtility.HtmlDecode(name);
                            Summon summon = new(decoded, series, element, img, link);
                            await Task.Delay(10);
                            AddSummon(summon);
                            addCount++;
                            Debug.WriteLine($"Added summon #{newIndex} N:{summon.name}, " +
                                $"S:{summon.series}, E:{summon.element}, L:{summon.link}, I:{summon.image}");
                        }
                        index++;
                    }

                    UnlockParent();
                }
                timer.Stop();
                TimeSpan timespan = timer.Elapsed;

                string time = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
                Debug.WriteLine($"Elapsed time for function loadXMLData(): {time}");
                string msg = $"Added {addCount} summons in {time}";
                string cap2 = $"Finished adding {addCount} summons into Database";
                if (addCount > 0)
                {
                    helper.SuccessMB(msg, cap2);

                }
            }
        }

        public void AddSummon(Summon summon)
        {
            int count = Count();
            count++;
            Debug.WriteLine(count);
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT into SSRSummons
                    (Id, Name, Series, Element, Image, Link)
                    VALUES ($Id, $name, $series, $element, $image, $link)
                ";
                command.Parameters.AddWithValue("Id", count);
                command.Parameters.AddWithValue("$name", summon.name);
                command.Parameters.AddWithValue("$series", summon.series);
                command.Parameters.AddWithValue("$element", summon.element);
                command.Parameters.AddWithValue("$image", summon.image);
                command.Parameters.AddWithValue("$link", summon.link);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Summon QueriedData(string name)
        {
            object res = new();
            string n, e, s, l, i;
            n = e = s = l = i = string.Empty;
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM SSRSummons
                    WHERE Name=$name 
                ";
                command.Parameters.AddWithValue("$name", name);
                var result = command.ExecuteReader();
                if (result.HasRows)
                {

                    while (result.Read())
                    {
                        n = result.GetString(1);
                        e = result.GetString(3);
                        s = result.GetString(2);
                        l = result.GetString(5);
                        i = result.GetString(4);
                    }
                    res = result;

                }
                connection.Close();

            }
            Summon summon = new(n, e, s, l, i);

            return summon;

        }

    }
}
