using GBF_Never_Buddy.Classes.DatabaseHandlers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Diagnostics;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy.Classes.SQLClasses
{
    internal class GachaSQLHelper : SQLHandler
    {
                
        public List<GameDataClasses.GachaDetails> GachaDetails(int id)
        {
            List<GachaDetails> gachaDetails = new List<GachaDetails>();
            string query = $"SELECT * FROM DrawResults WHERE DrawID={id}";
            try
            {
                gachaDetails = GachaData(query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return gachaDetails;
        }

        public List<GameDataClasses.GachaTable> GachaList()
        {
            List<GachaTable> gachas = new();
            string queryString =
            $"SELECT * FROM DrawData;";
            try
            {
                gachas = GachaTableData(queryString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return gachas;
        }

        public List<GameDataClasses.GachaTable> FreeGachas()
        {
            List<GachaTable> gachas = new();
            string queryString =
            $"SELECT * FROM DrawInfo WHERE Type='F';";
            try
            {
                gachas = GachaTableData(queryString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return gachas;
        }


        private List<GachaTable> GachaTableData(string queryString)
        {
            List<GachaTable> data = new();

            using (SqliteConnection connection = new SqliteConnection(
               GetConnectionString()))
            {
                SqliteCommand command = new SqliteCommand(
                queryString, connection);
                connection.Open();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AddGachaDataToList((IDataRecord)reader, data);
                }
                reader.Close();
                connection.Close();
                Debug.WriteLine(data.Count);
                return data;


            }
        }

        private List<GachaDetails> GachaData(string queryString)
        {
            List<GachaDetails> data = new();
            Debug.WriteLine(queryString);
            using (SqliteConnection connection = new SqliteConnection(
               GetConnectionString()))
            {
                SqliteCommand command = new SqliteCommand(
                queryString, connection);
                connection.Open();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AddResultsToList((IDataRecord)reader, data);
                }
                reader.Close();
                connection.Close();
                Debug.WriteLine(data.Count);
                return data;


            }
        }

        private void AddGachaDataToList(IDataRecord dataRecord, List<GachaTable> data)
        {

            if (dataRecord[1] is not null && dataRecord[2] != null)
            {
          
                int drawID = (int)(long)dataRecord[0];
                string date = (string)dataRecord[1];
                GachaTable gachaTable = new(drawID, drawID, 0, date);
                data.Add(gachaTable);
            }

        }

        private void AddResultsToList(IDataRecord dataRecord, List<GachaDetails> data)
        {

            if (dataRecord[1] is not null && dataRecord[2] != null)
            {
                int id = (int)(long)dataRecord[0];
                int drawID = (int)(long)dataRecord[1];
                string characters = (string)dataRecord[2];
                string summons = (string)dataRecord[3];
                int drawNum = (int)(long)dataRecord[4];
                int crystals = (int)(long)dataRecord[5];
                GachaDetails gachaDetails = new(id, drawID, characters, summons, drawNum, crystals);
                data.Add(gachaDetails);
            }

        }

       




        public int Count()
        {
            int count = 0;
            try
            {
                
                using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                    SELECT MAX(ID) FROM DrawInfo
                    ";
                    Int64 res = (Int64)command.ExecuteScalar();
                    count = (Int32)res;

                }
                Debug.WriteLine($"Drawinfo ID:" + count);
                return count;
            }  
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return -1;
        }
    }

}
