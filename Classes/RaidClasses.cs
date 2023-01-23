using GBF_Never_Buddy.Classes.DatabaseHandlers;
using Microsoft.Data.Sqlite;
using System.Data;

namespace GBF_Never_Buddy.Classes
{
    internal class RaidClasses : SQLHandler
    {


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
                char blueChest = (char)dataRecord[4];
                Raid raid = new(name, link, image, blueChest);
                data.Add(raid);
            }

        }


        public class Raid
        {
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

            public void RaidDetails()
            {

            }

        }


    }
}
