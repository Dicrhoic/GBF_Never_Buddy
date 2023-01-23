using System.Diagnostics;
using System.Reflection;
using System.Xml;

namespace GBF_Never_Buddy.Classes.DatabaseHandlers
{
    internal class SparkHelper
    {

        private string fileName = "SparkLog.xml";

        public async void AuthenticateDB()
        {
            string filePath = "";
            string? path1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path1 != null)
            {
                filePath = Path.Combine(path1, @"Database\SparkLog.xml");
                Debug.WriteLine(filePath);
            }
            Debug.WriteLine("Authenticating db");
            var validDb = DBExists(filePath, fileName);
            if (validDb)
            {
                Debug.WriteLine("Valid db");
                return;
            }
            if (!validDb)
            {
                Debug.WriteLine("Creating Characters db");
                string dir = Directory.GetCurrentDirectory();
                string location = Path.Combine(dir, "Database");
                CreateXMLFile(location, fileName, "sparks");
                await Task.Delay(1);
            }
        }

        private bool DBExists(string filePath, string fileName)
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

        private void CreateXMLFile(string location, string fileName, string rootElement)
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

    }
}
