﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using static GBF_Never_Buddy.Classes.GameDataClasses;
using System.Data.SqlClient;
using System.Data;

namespace GBF_Never_Buddy.Classes.SQLClasses
{
    public class CharacterSQLClass : SQLClass
    {
            
        public void UpdateDBFromXML()
        {

            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string? filePath = null;
            if (path != null)
            {
                Debug.WriteLine(path);
                filePath = Path.Combine(path, @"Database\SSRCharacters.xml");
                Debug.WriteLine(filePath);
                if (File.Exists(filePath))
                {
                    UpdateListFromXML(filePath);
                }
                if (!File.Exists(filePath))
                {
                    MBHelper mB = new MBHelper();
                    string caption = $"Error Adding to DB";
                    string msg = $"File doesn't exists at {Directory.GetCurrentDirectory()}";
                    mB.ErrorMB(msg, caption);

                }
            }

        }

        private List<Character> CharacterList()
        {
            List<Character> list = new List<Character>();
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM GachaCharacters
                ";
                var reader = command.ExecuteReader();    
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = "";
                        string element = "";
                        string link = "";
                        string series = "";
                        string image = "";
                        name = reader.GetString(1); 
                        element = reader.GetString(2);
                        link = reader.GetString(3);
                        series = reader.GetString(4);
                        image = reader.GetString(5);
                        Character character = new(name,element,series,image,link);
                        list.Add(character);
                    }
                    
                }

            }
            return list;
        }

        private int CharsCount()
        {
            int count = 0;
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT COUNT(*) FROM GachaCharacters
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
            XmlNode? root = doc.SelectSingleNode("characters");
            List<Character> characters = CharacterList();
            List<string> names = characters.Select(x => x.name).ToList();
            if (root != null)
            {
                LockParent();
                XmlNodeList docCharacters = doc.GetElementsByTagName("name");
                List<string> xmlChars = new();
                foreach (XmlNode node in docCharacters)
                {
                    xmlChars.Add(node.InnerText);
                }
                List<string> newChars = xmlChars.Except(names).ToList();
          
                XmlNodeList? xnList = root.SelectNodes("character");
                var document = XDocument.Load(path);
                XElement? xmlTree = document.Root;

                document.Descendants().Where(t => string.IsNullOrEmpty(t.Value)).Remove();
                doc.Save(path);
                int index = 1;
                int newIndex = CharsCount();
                int count = 0;

                if (xmlTree != null && xnList != null)
                {

                    foreach (XmlNode xn in xnList)
                    {

                        string series = xn.Attributes["series"].Value;
                        string name = xn["name"].InnerText;
                        string element = xn["element"].InnerText;
                        string img = xn["image"].InnerText;
                        string link = xn["link"].InnerText;
                        var exists = newChars.Contains(name);
                        if (!exists)
                        {
                            Debug.WriteLine($"Skipping {name}");
                        }
                        if (exists)
                        {

                            newIndex++;
                            string nameCleaned = FormatSqlString(name);
                            GameDataClasses.Character character = new(nameCleaned, element, series, img, link);
                            await Task.Delay(10);
                            AddCharacter(character);
                            addCount++;
                            Debug.WriteLine($"Added character #{newIndex} {nameCleaned}, {element}, {img}");
                        }
                        index++;
                    }

                    UnlockParent();
                }
                timer.Stop();
                TimeSpan timespan = timer.Elapsed;

                string time = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
                Debug.WriteLine($"Elapsed time for function loadXMLData(): {time}");
                string msg = $"Added {addCount} characters in {time}";
                string cap2 = $"Finished adding {addCount} characters into Gacha Character Database";
                if (addCount > 0)
                {
                    helper.SuccessMB(msg, cap2);

                }
            }
        }

        public void AddCharacter(Character character)
        {
            int count = CharsCount();
            count++;
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT into GachaCharacters
                    (Id, Name, Series, Element, Image, Link)
                    VALUES ($Id, $name, $element, $series, $image, $link)
                ";
                command.Parameters.AddWithValue("Id", count);
                command.Parameters.AddWithValue("$name", character.name);
                command.Parameters.AddWithValue("series", character.series);
                command.Parameters.AddWithValue("element", character.element);
                command.Parameters.AddWithValue("image", character.image);
                command.Parameters.AddWithValue("link", character.link) ;
             
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Character QueriedCharacter(string name)
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
                    SELECT * FROM GachaCharacters
                    WHERE Name=$name 
                ";
                command.Parameters.AddWithValue("$name", name);
                var result = command.ExecuteReader();            
                if (result.HasRows)
                {
  
                    while(result.Read())
                    {
                         n = result.GetString(1);
                         e = result.GetString(2);
                         s = result.GetString(3); 
                         l = result.GetString(4);
                         i = result.GetString(5);
                    }
                    res = result;

                }
                connection.Close();

            } 
            Character character = new(n,e,s,l,i);
            
            return character;

        }

        public void RemoveCharacter(Character character) 
        {
            
        }

        public void UpadteCharacter(Character character)
        {

        }
    }
}