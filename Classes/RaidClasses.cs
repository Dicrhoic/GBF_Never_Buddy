using GBF_Never_Buddy.Classes.DatabaseHandlers;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Diagnostics;

namespace GBF_Never_Buddy.Classes
{
    internal class RaidClasses : SQLHandler
    {
        ChestContents? chest;
        public RaidClasses() { }

        public int id { get; set; } 

        public int Attempts { get; set; }

        public void CurrentChest(ChestContents chest)
        {
            this.chest = chest; 
        }
        private int IntExtract(IDataRecord dataRecord)
        {
            int data = 0;
            if (dataRecord[1] != null)
            {
                Debug.WriteLine(dataRecord[1]);
                data = (int)(long)dataRecord[1];
                return data;

            }
            return data;
        }
        public int AttemptsDB(int id)
        {
            string queryString = $"SELECT * FROM RaidData WHERE raidID={id}";
            using (SqliteConnection connection = new SqliteConnection(
                  GetConnectionString()))
            {

                int data = 0;
                SqliteCommand command = new SqliteCommand(
                queryString, connection);
                connection.Open();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data = IntExtract(reader);
                }
                reader.Close();
                connection.Close();
                return data;
            }
        }

        public void DisplayData(Tuple<ChestContents, Tuple<Label, Label>> data, int index, string dataStr, string rateStr)
        {
            if (index != 20)
            {
                char dataC = dataStr.ElementAt(index);
                int count = (int)Char.GetNumericValue(dataC);
                char rt = rateStr.ElementAt(index);
                int endString = rateStr.Length;
                //Debug.WriteLine($"String length: {endString}, Index: {index}");
                string rate = rateStr.Substring(index, endString-index);
                //Debug.WriteLine(rate);
                int end = rate.IndexOf(',');
                //string finalRate = rate.Substring(0, end);
                data.Item2.Item1.Text = count.ToString();
                //data.Item2.Item2.Text = $"{finalRate}%";
            }
        }

        public void UpdateValue(Tuple<ChestContents, Tuple<Label, Label>> data, int index, string dataStr, string rateStr, RaidDropData raidSql)
        {   
            if(index != 20)
            {
                char dataC = dataStr.ElementAt(index);
                int count = (int)Char.GetNumericValue(dataC);
                Debug.WriteLine(count);
                count++;
                string newData = UpdatedDataString(dataStr, index, count, raidSql);  
                Debug.WriteLine($"Item {data.Item1.name}, Before string: {dataStr}\nAfter {newData}");
                string rate = CalculatedRate(Attempts, count);
                Debug.WriteLine(rate);
                //string newRate = UpdatedRateString(rateStr, index, rate, raidSql);
                //Debug.WriteLine($"Item {data.Item1.name}, Before rate: {rateStr}\nAfter {newRate}");
                data.Item2.Item1.Text = count.ToString();
                //data.Item2.Item2.Text = rate;                 
            }

        }

        private string UpdatedRateString(string oldStr, int index, string updateValue, RaidDropData sql)
        {
            Debug.WriteLine(updateValue);
            string str = updateValue.Replace("%", "");
            Debug.WriteLine(str);
            string newStr = oldStr;
            newStr = newStr.Remove(index, 1);
            newStr = newStr.Insert(index, str);
            sql.UpdateRate(newStr, sql.id);
            return newStr;
        }

        private string UpdatedDataString(string oldStr, int index, int updateValue, RaidDropData sql)
        {
            string newCount = updateValue.ToString();
            string newStr = oldStr;
            newStr = newStr.Remove(index, 1);
            newStr = newStr.Insert(index, newCount);
            sql.UpdateData(newStr, sql.id);
            return newStr;  
        }

        public string CalculatedRate(int total, int have)
        {
            decimal rate = Decimal.Divide(have, total);       
            string conv = Math.Round(rate, 2).ToString();
            if (rate == 1)
            {
                conv = "100";
            }
            conv += "%";   
            return conv;
        }

        public List<Raid> Raids()
        {
            List<Raid> Raids = new List<Raid>();
            string queryString = "SELECT * FROM Raids";
            using (SqliteConnection connection = new SqliteConnection(
               GetConnectionString()))
            {
                SqliteCommand command = new SqliteCommand(
                queryString, connection);
                connection.Open();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AddDataToList((IDataRecord)reader, Raids);
                }
                reader.Close();
                connection.Close();
                return Raids;
            }
        }

        private void AddDataToList(IDataRecord dataRecord, List<Raid> data)
        {

            if (dataRecord[1] is not null && dataRecord[2] != null)
            {
                string name = (string)dataRecord[1];
                string link = (string)dataRecord[2];
                string image = (string)dataRecord[3];
                string blueChest = (string)dataRecord[4];
                char c = (char)blueChest[0];
                Raid raid = new(name, link, image, c);
                data.Add(raid);
            }

        }

        private void AddDataToList(IDataRecord dataRecord, List<Data> data)
        {

            if (dataRecord[1] is not null && dataRecord[2] != null)
            {
                int id = (int)(long)dataRecord[0];
                string name = (string)dataRecord[1];
                int attemtps = (int)(long)dataRecord[2];
                int gbH = (int)(long)dataRecord[3];
                int gbB = (int)(long)dataRecord[4];
                int bc = (int)(long)dataRecord[5];
                Data data1 = new(name, attemtps, gbH, gbB, bc, id);
                data.Add(data1);
            }

        }

        private string AddStrToList(IDataRecord dataRecord, string str)
        {
            string name = "null";
            if (dataRecord[4] != null)
            {
                
                name = (string)dataRecord[4];
                return name;
                
            }
            return name;
        }

        public List<Data> RaidData(string name)
        {
            List<Data> Raids = new List<Data>();
            string queryString = $"SELECT * FROM GBLog WHERE Name='{name}'";
            using (SqliteConnection connection = new SqliteConnection(
               GetConnectionString()))
            {
                SqliteCommand command = new SqliteCommand(
                queryString, connection);
                connection.Open();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AddDataToList((IDataRecord)reader, Raids);
                }
                reader.Close();
                connection.Close();
                return Raids;
            }
        }   

        public class Data
        {
            string name;
            public int attempts;
            public int hGB;
            public int gbB;
            public int blueChest;
            public int id;
            public Data(string name, int attempts, int hGB, int gbB, 
                int blueChest, int id)
            {
                this.name = name;
                this.attempts = attempts;
                this.hGB = hGB;
                this.gbB = gbB;
                this.blueChest = blueChest;
                this.id = id;
            }

            public void UpdateBlueChest(int increment)
            {
                blueChest += increment;
            }

            public void UpdatehGB(int increment)
            {
                hGB += increment;
            }

            public void UpdategbB(int increment)
            {
                gbB += increment;
            }
            

            public void UpdateAttempts(int increment)
            {
                int output = attempts + increment;   
                if( output >= 0)
                {
                    attempts += increment;
                }
                                            
            }


        }

        public class Raid
        {
            public int hostChestContents;
            public int mvpChestContents;
            public int blueChestContents;
            public int attempts;
            public string name = string.Empty;
            public string link = string.Empty;
            public string image = string.Empty;
            public char blueChest;

            public Raid(string name, string link, string image, char blueChest)
            {
                this.name = name;
                this.link = link;
                this.image = image;
                this.blueChest = blueChest;
            }

            

        }


        public class ChestContents
        {
            public string name;
            public int amount;
            public Image image;
            public string raid;
            public string type;
            public int index;

            public ChestContents(string name, int amount, Image image, string raid, string type, int index)
            {
                this.name = name;
                this.amount = amount;
                this.image = image;
                this.raid = raid;
                this.type = type;
                this.index = index;
            }
        }

        public class RaidDropData
        {
            public string name;
            public int id;

            public int attempts { get; set; }
            Tuple<ChestContents, Tuple<Label, Label>>? dataInfo { get; set; }

            public RaidDropData(string name, int id)
            {
                this.name = name;
                this.id = id;
            }

            public string DropString(int id)
            {
              
                string queryString = $"SELECT * FROM RaidData WHERE raidID={id}";
                using (SqliteConnection connection = new SqliteConnection(
                   GetConnectionString()))
                {   
                    RaidClasses raidClasses = new RaidClasses();
                    string data = "";
                    SqliteCommand command = new SqliteCommand(
                    queryString, connection);
                    connection.Open();
                    SqliteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        data = raidClasses.AddStrToList((IDataReader)reader, data);
                    }
                    reader.Close();
                    connection.Close();
                    return data;
                }
            }

            public void UpdateRates(int id)
            {
                string rateString = RateString(id);
                string dataString = DropString(id);





            }

            public string RateString(int id)
            {
                string queryString = $"SELECT * FROM ChestData WHERE RaidID={id}";
                using (SqliteConnection connection = new SqliteConnection(
                   GetConnectionString()))
                {
                    RaidClasses raidClasses = new RaidClasses();
                    string data = "";
                    SqliteCommand command = new SqliteCommand(
                    queryString, connection);
                    connection.Open();
                    SqliteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        data = RateDataToStr((IDataReader)reader, data);
                    }
                    reader.Close();
                    connection.Close();
                    return data;
                }
            }

            private string RateDataToStr(IDataRecord dataRecord, string str)
            {
                string name = "null";
                if (dataRecord[2] != null)
                {

                    name = (string)dataRecord[2];
                    return name;

                }
                return name;
            }

            public void UpdateAttempts(int id, int attempts)
            {
                using (SqliteConnection connection = new SqliteConnection(
                  GetConnectionString()))
                {
                    string query = "UPDATE RaidData SET attempts = @data WHERE id = @id";
                    SqliteCommand command = new SqliteCommand(
                        query, connection);
                    command.Parameters.Add("@id", SqliteType.Integer);
                    command.Parameters.Add("@data", SqliteType.Integer);
                    command.Parameters["@id"].Value = id;
                    command.Parameters["@data"].Value = attempts;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            public void UpdateRate(string rateStr, int id)
            {
                using (SqliteConnection connection = new SqliteConnection(
                  GetConnectionString()))
                {
                    string data = rateStr;
                    string query = "UPDATE ChestData SET RateString = @rate WHERE id = @id";
                    SqliteCommand command = new SqliteCommand(
                        query, connection);
                    command.Parameters.Add("@rate", SqliteType.Text);
                    command.Parameters.Add("@id", SqliteType.Integer);
                    command.Parameters["@productString"].Value = data;
                    command.Parameters["@id"].Value = id;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            public void UpdateData(string dataStr, int id)
            {
                using (SqliteConnection connection = new SqliteConnection(
                  GetConnectionString()))
                {
                    string data = dataStr;
                    string query = "UPDATE RaidData SET raidString = @data WHERE id = @id";
                    SqliteCommand command = new SqliteCommand(
                        query, connection);
                    command.Parameters.Add("@data", SqliteType.Text);
                    command.Parameters.Add("@id", SqliteType.Integer);
                    command.Parameters["@data"].Value = data;
                    command.Parameters["@id"].Value = id;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
