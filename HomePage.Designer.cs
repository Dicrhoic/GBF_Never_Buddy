namespace GBF_Never_Buddy
{
    partial class HomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAllSSRCharacterListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromXMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSummonsDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fromXMLFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gachaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yoloLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sparkLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freebieLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eternalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recruitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transcendenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evokersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goldBrickTallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.editDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.gachaToolStripMenuItem,
            this.collectionTrackerToolStripMenuItem,
            this.goldBrickTallyToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1071, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAllSSRCharacterListToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // createAllSSRCharacterListToolStripMenuItem
            // 
            this.createAllSSRCharacterListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateDatabaseToolStripMenuItem,
            this.updateSummonsDBToolStripMenuItem,
            this.addDataToolStripMenuItem,
            this.editDataToolStripMenuItem});
            this.createAllSSRCharacterListToolStripMenuItem.Name = "createAllSSRCharacterListToolStripMenuItem";
            this.createAllSSRCharacterListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createAllSSRCharacterListToolStripMenuItem.Text = "Database";
            // 
            // updateDatabaseToolStripMenuItem
            // 
            this.updateDatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromXMLFileToolStripMenuItem,
            this.allToolStripMenuItem});
            this.updateDatabaseToolStripMenuItem.Name = "updateDatabaseToolStripMenuItem";
            this.updateDatabaseToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.updateDatabaseToolStripMenuItem.Text = "Update Character Database";
            // 
            // fromXMLFileToolStripMenuItem
            // 
            this.fromXMLFileToolStripMenuItem.Name = "fromXMLFileToolStripMenuItem";
            this.fromXMLFileToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.fromXMLFileToolStripMenuItem.Text = "From XML File";
            this.fromXMLFileToolStripMenuItem.Click += new System.EventHandler(this.AddCharData);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.RunCharactersCreator);
            // 
            // updateSummonsDBToolStripMenuItem
            // 
            this.updateSummonsDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem1,
            this.fromXMLFileToolStripMenuItem1});
            this.updateSummonsDBToolStripMenuItem.Name = "updateSummonsDBToolStripMenuItem";
            this.updateSummonsDBToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.updateSummonsDBToolStripMenuItem.Text = "Update Summons DB";
            // 
            // allToolStripMenuItem1
            // 
            this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
            this.allToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.allToolStripMenuItem1.Text = "All";
            this.allToolStripMenuItem1.Click += new System.EventHandler(this.RunSummonsCreator);
            // 
            // fromXMLFileToolStripMenuItem1
            // 
            this.fromXMLFileToolStripMenuItem1.Name = "fromXMLFileToolStripMenuItem1";
            this.fromXMLFileToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.fromXMLFileToolStripMenuItem1.Text = "From XML File";
            this.fromXMLFileToolStripMenuItem1.Click += new System.EventHandler(this.LoadXMLDataSummons);
            // 
            // addDataToolStripMenuItem
            // 
            this.addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            this.addDataToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addDataToolStripMenuItem.Text = "Add Data";
            this.addDataToolStripMenuItem.Click += new System.EventHandler(this.AddData);
            // 
            // gachaToolStripMenuItem
            // 
            this.gachaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsToolStripMenuItem,
            this.yoloLogToolStripMenuItem,
            this.sparkLogToolStripMenuItem,
            this.freebieLogToolStripMenuItem});
            this.gachaToolStripMenuItem.Name = "gachaToolStripMenuItem";
            this.gachaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.gachaToolStripMenuItem.Text = "Gacha";
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.logsToolStripMenuItem.Text = "Logs";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.OpenLogs);
            // 
            // yoloLogToolStripMenuItem
            // 
            this.yoloLogToolStripMenuItem.Name = "yoloLogToolStripMenuItem";
            this.yoloLogToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.yoloLogToolStripMenuItem.Text = "Yolo";
            this.yoloLogToolStripMenuItem.Click += new System.EventHandler(this.LoadYoloLog);
            // 
            // sparkLogToolStripMenuItem
            // 
            this.sparkLogToolStripMenuItem.Name = "sparkLogToolStripMenuItem";
            this.sparkLogToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.sparkLogToolStripMenuItem.Text = "Spark";
            this.sparkLogToolStripMenuItem.Click += new System.EventHandler(this.LoadSparkForm);
            // 
            // freebieLogToolStripMenuItem
            // 
            this.freebieLogToolStripMenuItem.Name = "freebieLogToolStripMenuItem";
            this.freebieLogToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.freebieLogToolStripMenuItem.Text = "Freebie Log";
            this.freebieLogToolStripMenuItem.Click += new System.EventHandler(this.LoadFreeLog);
            // 
            // collectionTrackerToolStripMenuItem
            // 
            this.collectionTrackerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eternalsToolStripMenuItem,
            this.evokersToolStripMenuItem});
            this.collectionTrackerToolStripMenuItem.Name = "collectionTrackerToolStripMenuItem";
            this.collectionTrackerToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.collectionTrackerToolStripMenuItem.Text = "Collection Tracker";
            // 
            // eternalsToolStripMenuItem
            // 
            this.eternalsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recruitToolStripMenuItem,
            this.uncapToolStripMenuItem,
            this.transcendenceToolStripMenuItem});
            this.eternalsToolStripMenuItem.Enabled = false;
            this.eternalsToolStripMenuItem.Name = "eternalsToolStripMenuItem";
            this.eternalsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.eternalsToolStripMenuItem.Text = "Eternals";
            // 
            // recruitToolStripMenuItem
            // 
            this.recruitToolStripMenuItem.Name = "recruitToolStripMenuItem";
            this.recruitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.recruitToolStripMenuItem.Text = "Recruit";
            // 
            // uncapToolStripMenuItem
            // 
            this.uncapToolStripMenuItem.Name = "uncapToolStripMenuItem";
            this.uncapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uncapToolStripMenuItem.Text = "Uncap";
            // 
            // transcendenceToolStripMenuItem
            // 
            this.transcendenceToolStripMenuItem.Name = "transcendenceToolStripMenuItem";
            this.transcendenceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.transcendenceToolStripMenuItem.Text = "Transcendence";
            // 
            // evokersToolStripMenuItem
            // 
            this.evokersToolStripMenuItem.Enabled = false;
            this.evokersToolStripMenuItem.Name = "evokersToolStripMenuItem";
            this.evokersToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.evokersToolStripMenuItem.Text = "Evokers";
            // 
            // goldBrickTallyToolStripMenuItem
            // 
            this.goldBrickTallyToolStripMenuItem.Name = "goldBrickTallyToolStripMenuItem";
            this.goldBrickTallyToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.goldBrickTallyToolStripMenuItem.Text = "Gold Brick Tally";
            this.goldBrickTallyToolStripMenuItem.Click += new System.EventHandler(this.LoadGBForm);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1071, 472);
            this.mainPanel.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateProgress);
            // 
            // editDataToolStripMenuItem
            // 
            this.editDataToolStripMenuItem.Name = "editDataToolStripMenuItem";
            this.editDataToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.editDataToolStripMenuItem.Text = "Edit Data";
            this.editDataToolStripMenuItem.Click += new System.EventHandler(this.OpenEditor);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 496);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.Text = "Never Crew Buddy";
            this.Load += new System.EventHandler(this.InitializeContent);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MainMenuStrip;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem createAllSSRCharacterListToolStripMenuItem;
        private ToolStripMenuItem gachaToolStripMenuItem;
        private ToolStripMenuItem yoloLogToolStripMenuItem;
        private ToolStripMenuItem sparkLogToolStripMenuItem;
        private ToolStripMenuItem freebieLogToolStripMenuItem;
        private ToolStripMenuItem collectionTrackerToolStripMenuItem;
        private ToolStripMenuItem eternalsToolStripMenuItem;
        private ToolStripMenuItem recruitToolStripMenuItem;
        private ToolStripMenuItem uncapToolStripMenuItem;
        private ToolStripMenuItem transcendenceToolStripMenuItem;
        private ToolStripMenuItem evokersToolStripMenuItem;
        private ToolStripMenuItem goldBrickTallyToolStripMenuItem;
        private Panel mainPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem updateDatabaseToolStripMenuItem;
        private ToolStripMenuItem fromXMLFileToolStripMenuItem;
        private ToolStripMenuItem allToolStripMenuItem;
        private ToolStripMenuItem updateSummonsDBToolStripMenuItem;
        private ToolStripMenuItem allToolStripMenuItem1;
        private ToolStripMenuItem fromXMLFileToolStripMenuItem1;
        private ToolStripMenuItem logsToolStripMenuItem;
        private ToolStripMenuItem addDataToolStripMenuItem;
        private ToolStripMenuItem editDataToolStripMenuItem;
    }
}