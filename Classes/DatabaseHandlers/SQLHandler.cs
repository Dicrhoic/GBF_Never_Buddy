﻿using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Reflection;

namespace GBF_Never_Buddy.Classes.DatabaseHandlers
{
    public class SQLHandler : DatabaseHandler
    {
        string? exPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string? dbPath = null;
        string fileName = "localDB.db";
        HomePage? homePage;
        static public string GetConnectionString()
        {

            string path = Application.StartupPath + "Database\\localDB.db";
            //Debug.WriteLine($"path is {path}");
            return $"Data Source={path};";
            //return $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={path};Integrated Security=True";
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

        public bool ValidateDB()
        {
            MBHelper mB = new MBHelper();
            try
            {
                using (SqliteConnection connection = new SqliteConnection(
                                 GetConnectionString()))
                {

                    Debug.WriteLine(connection.Database);
                    connection.Close();
                    string msg = $"Connected to Database file {fileName}.";
                    string cap = "Database connection successful";
                    //mB.SuccessMB(msg, cap); 
                    return true;

                }
            }
            catch (Exception ex)
            {

                string msg = $"Error connecting to Database file {fileName}. {ex.Message}";
                string cap = "Database connection error";
                mB.ErrorMB(msg, cap);
                return false;
            }

        }

        public void RunSQLQuery(string queryString)
        {
            Debug.WriteLine($"SQL query: {queryString}");
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
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                MBHelper mB = new MBHelper();
                string caption = $"Error Adding to DB";
                mB.ErrorMB(ex.Message, caption);
            }
        }
        public void LockParent()
        {
            var parent = Application.OpenForms["HomePage"];
            if (parent != null)
            {
                homePage = (HomePage)parent;
                homePage.Enabled = false;
            }
        }

        public void UnlockParent()
        {
            var parent = Application.OpenForms["HomePage"];
            if (parent != null)
            {
                homePage = (HomePage)parent;
                homePage.Enabled = true;
            }
        }
    }
}
