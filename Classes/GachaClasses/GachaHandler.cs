using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Xml.Linq;
using static GBF_Never_Buddy.Classes.GameDataClasses;

namespace GBF_Never_Buddy.Classes.GachaClasses
{
    public enum DrawType
    {
        Single = 300,
        Multi = 3000,
        Ticket = 1,
        Tickets = 10,
        Free = 0,
    }

    public enum Mode
    {
        Normal,
        Spark,
        Free,
        Roulette
    }

    public class GachaHandler
    {

        public int crystalsSpent = 0;
        public int ticketsSpent = 0;
        public string preText = " used: ";
        public PictureBox? currentCharacterImage = null;
        public List<GameDataClasses.Character> characters = new();
        public List<GameDataClasses.Summon> summons = new();
        public int drawNumber = 1;
        public string date = DateTime.Now.ToString("yyyy-MM-dd");

        public Mode mode { get; set; }

        public int drawID()
        {
            int count = 0;
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
        
        public void CreateData()
        {

            Debug.WriteLine($"Constructor\n DrawID:{drawID()}\n{date}");
            char m = 'D';
            switch (mode)
            {
                case Mode.Free:
                    m = 'F';
                    break;
                case Mode.Normal:
                    m = 'N';
                    break;
                case Mode.Spark:
                    m = 'S';
                    break;
                case Mode.Roulette:
                    m = 'R';
                    break;
            }
            using (var connection = new SqliteConnection("Data Source=\"Database\\\\localDB.db\""))
            {
                
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                            INSERT into DrawInfo
                            (Date, Type)
                            VALUES (@d, @t)
                        ";
                command.Parameters.AddWithValue("@d", date);
                command.Parameters.AddWithValue("@t", m);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        

        public void UpdateCharacter(PictureBox picture)
        {
            currentCharacterImage = picture;
        }

        public void UpdateCost(Label textHolder, DrawType drawType)
        {
            int cost = (int)drawType;
            if(mode == Mode.Normal || mode == Mode.Spark) 
            {
                if (drawType == DrawType.Tickets)
                {
                    preText = "Tickets Used:";
                    ticketsSpent = ticketsSpent + cost;
                    string text = preText + $" {ticketsSpent}";
                    textHolder.Text = text;

                }
                if (drawType == DrawType.Multi)
                {
                    preText = "Crystals Used:";
                    crystalsSpent = crystalsSpent + cost;
                    string text = preText + $" {crystalsSpent}";
                    textHolder.Text = text;
                }
            }
       
        }

        public void UpdateCost(Label textHolder, DrawType drawType, int tickets)
        {
            preText = "Ticket Used:";
            if (ticketsSpent >= 1)
            {
                preText = "Tickets Used:";
            }
            ticketsSpent = ticketsSpent + tickets;
            string text = preText + $" {ticketsSpent}";
            textHolder.Text = text;
      
        }

        public void UpdateLists(List<GameDataClasses.Summon> sumList, List<GameDataClasses.Character> charList)
        {
            characters = charList;
            summons = sumList;
        }

    }
}
