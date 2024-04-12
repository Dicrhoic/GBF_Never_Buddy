using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using GBF_Never_Buddy.Classes.GachaClasses;
using Microsoft.Data.Sqlite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GBF_Never_Buddy.Classes
{
    public class GameDataClasses
    {
        public class Character
        {
            public string name;
            public string series;
            public string element;
            public string image;
            public string link;

            public Character(string name, string element, string series, string image, string link)
            {
                this.name = name;
                this.element = element;
                this.series = series;
                this.image = image;
                this.link = link;
            }
        }
        public class CharacterDetail
        {
            public int id;
            public string name;
            public string series;
            public string element;
            public string image;
            public string link;

            public CharacterDetail(int id, string name, string element, string series, string image, string link)
            {
                this.id = id;
                this.name = name;
                this.element = element;
                this.series = series;
                this.image = image;
                this.link = link;
            }
        }

        public class GachaCharacterDetails
        {
            int id;
            public string name;
            public string image;
            public string link;
            public int refId;
            public string element;
            public string series;
            public string desc { get; set; }

            public GachaCharacterDetails(int id, string name, string image, string link, int rid, string element, string series)
            {
                this.id = id;
                this.name = name;
                this.image = image;
                this.link = link;
                this.refId = rid;
                this.element = element;
                this.series = series;
                desc = string.Empty;
            }


        }

        public class WeaponList
        {
            public string weaponName;

            public string weaponLink;

            public string weaponElement;

            public string weaponImage;

            public WeaponList(string weaponName, string weaponLink, string element, string weaponImage)
            {
                this.weaponName = weaponName;
                this.weaponLink = weaponLink;
                this.weaponElement = element;
                this.weaponImage = weaponImage;
            }
        }


        public class Summon
        {
            public string name;
            public string series;
            public string element;
            public string image;
            public string link;

            public Summon(string name, string series, string element, string image, string link)
            {
                this.name = name;
                this.series = series;
                this.element = element;
                this.image = image;
                this.link = link;
            }
        }

        public class SummonComparer : IEqualityComparer<Summon>
        {
            public bool Equals(Summon x, Summon y)
            {

                //Check whether the compared objects reference the same data.
                if (System.Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null.
                if (System.Object.ReferenceEquals(x, null) || System.Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the products' properties are equal.
                return x.series == y.series && x.name == y.name;
            }

            public int GetHashCode(Summon obj)
            {
                //Check whether the object is null
                if (System.Object.ReferenceEquals(obj, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = obj.name == null ? 0 : obj.name.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = obj.series.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }
        }

        public class CharacterComparer : IEqualityComparer<Character>
        {
            public bool Equals(Character x, Character y)
            {

                //Check whether the compared objects reference the same data.
                if (System.Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null.
                if (System.Object.ReferenceEquals(x, null) || System.Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the products' properties are equal.
                return x.series == y.series && x.name == y.name;
            }

            public int GetHashCode(Character obj)
            {
                //Check whether the object is null
                if (System.Object.ReferenceEquals(obj, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = obj.name == null ? 0 : obj.name.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = obj.series.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }
        }

        public class GachaInfo
        {
            public GachaHandler handler;
            int drawNumber = 1;
            public int id;
            public string type;
            public List<Character> Characters;
            public List<Summon> Summons;
            public List<GachaDetail> details;

            public GachaInfo(int id, string type, GachaHandler gachaHandler)
            {
                this.id = id;
                this.type = type;
                Characters = new();
                Summons = new();
                details = new();
                handler = gachaHandler;
                LoadData();
            }

            private void LoadData()
            {
                Characters = handler.characters;
                Summons = handler.summons;  
            }

            public void InsertResults()
            {
                int drawID = DrawIDFK();
                Debug.WriteLine("Draw ID:" + drawID);
                foreach (var c in Characters)
                {
                    InsertCharacter(drawID, c.name);
                    Debug.WriteLine($"Inserted: {c.name} to {id}");
                }
                foreach(var s in Summons)
                {
                    InsertSummon(drawID, s.name);
                    Debug.WriteLine($"Inserted: {s.name} to {id}");
                }
            }

            private int DrawIDFK()
            {
                int FK = -1;
                int idSearch = id - 1;
                Debug.WriteLine($"Searching for FK with ID: {idSearch}");
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {

                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                            SELECT ID, DrawID
                            FROM DrawCost
                            WHERE DrawID=$id
                        ";
            
                    connection.Open();
                    command.Parameters.AddWithValue("$id", idSearch);
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                      
                        FK = reader.GetInt32(0);    
                    }
                    connection.Close();
                }
                Debug.Assert(FK == -1);
                return FK;
            }

            public void NewDraw(int cost)
            {
                Debug.WriteLine($"NewDraw() ID: {id}, DrawNum: {drawNumber}, Cost: {cost}");
                AddDrawCost(cost);
                UpdateDrawCount();
                drawNumber++; 
                
            }

            private void AddDrawCost(int cost)
            {

                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                            INSERT into DrawCost
                            (DrawID, DrawNumber, Cost)
                            VALUES (@d, @n, @c)
                        ";
                    command.Parameters.AddWithValue("@d", id);
                    command.Parameters.AddWithValue("@n", drawNumber);
                    command.Parameters.AddWithValue("@c", cost);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            private void UpdateDrawCount()
            {
        
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                   
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                            UPDATE DrawInfo
                            SET DrawCount = @count
                            WHERE ID=@i
                        ";
                    command.Parameters.AddWithValue("@i", id);
                    command.Parameters.AddWithValue("@count", drawNumber);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            private void InsertCharacter(int id, string name)
            {

                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    Debug.WriteLine($"Insert drawID {id}");
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                            INSERT into DrawYield
                            (ID, Character)
                            VALUES (@id, @character)
                        ";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@character", name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }


            }

            private void InsertSummon(int id, string name)
            {

                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                 
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                            INSERT into DrawYield
                            (ID, Summon)
                            VALUES (@id, @summon)
                        ";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@summon", name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }


            }
        }

        public class GachaDetail 
        {
            int drawNumber;
            int costValue;
    
            public GachaDetail(int drawNumber, int costValue)
            {
                this.drawNumber = drawNumber;
                this.costValue = costValue;

            }
        }
        

        public class GachaTable
        {
            public int id;
            public int drawId;
            public int crystalsUsed;
            public string date;

            public GachaTable(int id, int drawId, int crystalsUsed, string date)
            {
                this.id = id;
                this.drawId = drawId;
                this.crystalsUsed = crystalsUsed;
                this.date = date;
            }
        }

        public class GachaResults
        {
            public int id;
            private List<GachaYield> gachaYields;

            public GachaResults(int id, int size)
            {
                this.id = id;
                gachaYields = new List<GachaYield>(size);
                PopulateYields();
            }

            private void PopulateYields()
            {
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {

                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                           SELECT DrawYield.Character, DrawYield.Summon, DrawCost.DrawNumber FROM DrawYield
                           INNER JOIN DrawCost ON DrawCost.ID = DrawYield.ID
                           INNER  JOIN DrawInfo ON DrawCost.DrawID=DrawInfo.ID 
                           WHERE DrawID=@i
                        ";
                    command.Parameters.AddWithValue("@i", id);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        if(reader.HasRows)
                        {
                            foreach(var row in reader)
                            {
                                var c = reader.IsDBNull(0) ? "Empty" : reader.GetString(0);
                                var s = reader.IsDBNull(1) ? "Empty" : reader.GetString(1); 
                                int number = reader.GetInt32(2);
                                Debug.WriteLine(reader.IsDBNull(1) ? null : reader.GetString(1));   
                                GachaYield yield = new(c, s, number);
                                Debug.WriteLine($"Added:{c},Summon:{s} to {number}");
                                gachaYields.Add(yield); 
                            }
                        }
                    }
                    connection.Close();
                }
            }

            public List<GachaYield> GachaYields
            {
                get { return gachaYields; }
            }
        }

        public class GachaYield
        {
            public string Character { get; }
            public string Summon { get; }
            public int DrawNumber { get; }

            public GachaYield(string character, string summon, int DrawNumber)
            {
                Character = character;
                Summon = summon;
                this.DrawNumber = DrawNumber;
            }
        }
        public class GachaYieldData
        {
            public List<string> Characters { get; }
            public List<string> Summons { get; }
            public int DrawNumber { get; }

            public char type { get; }

            public GachaYieldData(List<string> character, List<string> summon, int DrawNumber, char type)
            {
                Characters = character;
                Summons = summon;
                this.DrawNumber = DrawNumber;
                this.type = type;
            }
        }
        public class GachaLogData
        {
            public int id { get; }
            public string date { get; set; }
            public char typeChar { get; set; }

            public int drawCount { get; set; }

            public GachaLogData(int id, string date, char typeChar, int drawCount)
            {
                this.id = id;
                this.date = date;
                this.typeChar = typeChar;
                this.drawCount = drawCount;
         
            }
        }

      

        public class GachaDetails
        {
            public int id;
            public int drawId;
            public string characters;
            public string summons;
            public int drawNumber;
            public int crystalsUsed;

            public GachaDetails(int id, int drawId, string characters, string summons, int drawNumber, int crystalsUsed)
            {
                this.id = id;
                this.drawId = drawId;
                this.characters = characters;
                this.summons = summons;
                this.crystalsUsed = crystalsUsed;
                this.drawNumber = drawNumber;
            }
        }

        public class ItemComparer : IComparer
        {
            public int Column { get; set; }

            public SortOrder Order { get; set; }
            private CaseInsensitiveComparer ObjectCompare;

            public ItemComparer()
            {
                Order = SortOrder.None;
                ObjectCompare = new CaseInsensitiveComparer();
            }
            public int Compare(object x, object y)
            {
                int result;
                ListViewItem listviewX, listviewY;

                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;
                result = ObjectCompare.Compare(listviewX.SubItems[Column].Text, listviewY.SubItems[Column].Text);
                var xStr = listviewX.SubItems[Column].Text;
                var yStr = listviewY.SubItems[Column].Text;
                int xValue = 0;
                int yValue = 0;
                DateTime xTime;
                DateTime yTime;
                DateTime.TryParse(xStr, out xTime);
                DateTime.TryParse(yStr, out yTime);
                if (xTime != null && yTime != null)
                {
                    result = xTime.CompareTo(yTime);
                }
                int.TryParse(xStr, System.Globalization.NumberStyles.Currency, null, out xValue);
                int.TryParse(yStr, System.Globalization.NumberStyles.Currency, null, out yValue);
                if (yValue != 0 && xValue != 0)
                {
                    Debug.WriteLine($"Number, comparing: {xValue} to {yValue}");
                    result = xValue - yValue;
                }

                if (Order == SortOrder.Descending)
                {
                    return (-result);
                }
                else if (Order == SortOrder.Ascending)
                {
                    return result;
                }
                return 0;
            }
            public int SortColumn
            {
                set
                {
                    Column = value;
                }
                get
                {
                    return Column;
                }
            }

            public SortOrder OrderCol
            {
                set
                {
                    Order = value;
                }
                get
                {
                    return Order;
                }
            }
        }
    }
}
