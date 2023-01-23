using GBF_Never_Buddy.Classes.DatabaseHandlers;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Diagnostics;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy.Classes.SQLClasses
{
    internal class GachaSQLHelper : SQLHandler
    {

        private string InsertStringDrawData(GameDataClasses.GachaTable table)
        {
            string query = $"INSERT INTO [DrawData] ([Id], [DrawID], [Date]) VALUES" +
                $" ({table.id}, '{table.drawId}', '{table.date}')";
            return query;
        }

        private string InsertStringDrawDataSpark(GameDataClasses.GachaTable table)
        {
            string query = $"INSERT INTO [DrawData] ([Id], [DrawID], [Date], [Spark]) VALUES" +
                $" ({table.id}, '{table.drawId}', '{table.date}', 'Y')";
            return query;
        }

        private string InsertStringResultData(GameDataClasses.GachaDetails details)
        {
            string query = $"INSERT INTO [DrawResults] ([DrawID], [CharacterString], [SummonString], [DrawNumber], [CrystalsUsed]) VALUES" +
                $" ( '{details.drawId}', '{details.characters}', '{details.summons}', '{details.drawNumber}', '{details.crystalsUsed}')";
            return query;
        }

        public void InsertResults(GameDataClasses.GachaDetails details)
        {
            string query = InsertStringResultData(details);
            RunSQLQuery(query);
        }

        public void InsertData(GameDataClasses.GachaTable table)
        {
            string query = InsertStringDrawData(table);
            RunSQLQuery(query);
        }

        public void InsertDataSpark(GameDataClasses.GachaTable table)
        {
            string query = InsertStringDrawDataSpark(table);
            RunSQLQuery(query);
        }

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
                int id = (int)(long)dataRecord[0];
                int drawID = (int)(long)dataRecord[1];
                string date = (string)dataRecord[2];
                GachaTable gachaTable = new(id, drawID, 0, date);
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

        public int DrawCount()
        {
            int count = 0;
            string queryString =
            "SELECT * FROM DrawResults";
            try
            {
                using (SqliteConnection connection = new SqliteConnection(
                        GetConnectionString()))
                {

                    Debug.WriteLine(connection.Database);
                    Debug.WriteLine(queryString);
                    SqliteCommand command = new SqliteCommand(
                    queryString, connection);
                    connection.Open();
                    SqliteDataReader reader;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                    connection.Close();
                    return count;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return -1;
        }




        public int Count()
        {
            int count = 0;
            string queryString =
            "SELECT * FROM DrawData";
            try
            {
                using (SqliteConnection connection = new SqliteConnection(
                        GetConnectionString()))
                {

                    Debug.WriteLine(connection.Database);
                    Debug.WriteLine(queryString);
                    SqliteCommand command = new SqliteCommand(
                    queryString, connection);
                    connection.Open();
                    SqliteDataReader reader;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                    connection.Close();
                    return count;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

            }
            return -1;
        }
    }

    public class GachaLogData
    {

    }
}
