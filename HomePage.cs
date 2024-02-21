using GBF_Never_Buddy.Classes.DatabaseHandlers;
using GBF_Never_Buddy.Classes.GachaClasses;
using GBF_Never_Buddy.Classes.SQLClasses;
using GBF_Never_Buddy.Classes.XMLWriterClasses;
using GBF_Never_Buddy.Forms;
using GBF_Never_Buddy.Forms.GachaFroms;
using GBF_Never_Buddy.GachaForms;
using GBF_Never_Buddy.Screens;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace GBF_Never_Buddy
{
    public partial class HomePage : Form
    {
        NetHelper netHelper;
        public HomePage()
        {
            InitializeComponent();
            netHelper = new();
        }

        private void InitializeContent(object sender, EventArgs e)
        {
            netHelper.AuthenticateDB();
            Debug.WriteLine(Application.OpenForms.Count);

        }

        private void AddCharData(object sender, EventArgs e)
        {
            CharacterSQLHelper characterSQL = new CharacterSQLHelper();
            characterSQL.SetBackgroundWorker(backgroundWorker1);
            characterSQL.UpdateCharDBFromXML();
        }

        private void UpdateProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Debug.WriteLine($"Progress changed: {e.ProgressPercentage}");
            var progressPercentage = e.ProgressPercentage;
            Form bar = Application.OpenForms["ProgressBar"];
            if (bar is not null)
            {
                var barForm = (ProgressBar)bar;
                barForm.UpdateBarProgress(e.ProgressPercentage);

            }
        }


        private void LoadYoloLog(object sender, EventArgs e)
        {
            GachaHandler gachaHandler = new();
            gachaHandler.mode = Mode.Normal;
            GachaForm gachaForm = new GachaForm(gachaHandler);
            gachaForm.Show();
        }

        private async void RunCharactersCreator(object sender, EventArgs e)
        {
            var task1 = await netHelper.ValidatedCharacterFile();
            if (task1)
            {
                CharacterSQLHelper characterSQL = new CharacterSQLHelper();
                characterSQL.SetBackgroundWorker(backgroundWorker1);
                characterSQL.UpdateCharDBFromXML();
            }
        }

        private async void RunSummonsCreator(object sender, EventArgs e)
        {
            var task1 = await netHelper.ValidatedSummonFile();
            if (task1)
            {
                SummonSQLHelper summonSQLHelper = new SummonSQLHelper();
                summonSQLHelper.SetBackgroundWorker(backgroundWorker1);
                summonSQLHelper.UpdateDBFromXML();
            }
        }

        private void LoadXMLDataSummons(object sender, EventArgs e)
        {
            SummonSQLHelper summonSQLHelper = new SummonSQLHelper();
            summonSQLHelper.SetBackgroundWorker(backgroundWorker1);
            summonSQLHelper.UpdateDBFromXML();
        }

        private void LoadSparkForm(object sender, EventArgs e)
        {
            SparkForm sparkForm = new SparkForm();
            sparkForm.Show();
        }

        private void LoadRouletteDay(object sender, EventArgs e)
        {

        }

        private void OpenLogs(object sender, EventArgs e)
        {
            GachaLogForm logData = new();
            logData.ShowDialog();
        }

        private void LoadGBForm(object sender, EventArgs e)
        {
            var openForm = Application.OpenForms["GBLog"];
            if (openForm == null)
            {
                ItemDropLog gB = new();
                gB.Show();
            }


        }

        private void LoadFreeLog(object sender, EventArgs e)
        {
            var openForm = Application.OpenForms["FreebieLogForm"];
            if (openForm == null)
            {
                FreebieLogForm form = new();
                form.Show();
            }
        }

        private void AddData(object sender, EventArgs e)
        {
            var openForm = Application.OpenForms["DataAdderForm"];
            if (openForm == null)
            {
                DataAdderForm form = new();
                form.Show();
            }
        }

        private void OpenEditor(object sender, EventArgs e)
        {
            var openForm = Application.OpenForms["DataEditorForm"];
            if (openForm == null)
            {
                DataEditorForm form = new();
                form.Show();
            }
        }

        private async void LoadUpdateOptions(object sender, EventArgs e)
        {
            /*
            CharacterWriter characterWriter = new CharacterWriter();
            characterWriter.ValidateXMLFile();
            CharacterSQLClass characterSQLClass = new CharacterSQLClass();
            characterSQLClass.UpdateDBFromXML();
            */

            /*
            SummonWriter summonWriter = new SummonWriter();
            summonWriter.ValidateSummonFile();
            summonWriter.CreateSummonsList();
            */

            SummonSQLClass summonSQLClass = new SummonSQLClass();
            summonSQLClass.UpdateDBFromXML();
            //UpdateOptions updateOptions = new UpdateOptions(this);
            //mainPanel.Controls.Clear(); 
            //mainPanel.Controls.Add(updateOptions); 
        }
    }
}