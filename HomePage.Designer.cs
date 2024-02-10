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
            MainMenuStrip = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            createAllSSRCharacterListToolStripMenuItem = new ToolStripMenuItem();
            updateDatabaseToolStripMenuItem = new ToolStripMenuItem();
            addDataToolStripMenuItem = new ToolStripMenuItem();
            editDataToolStripMenuItem = new ToolStripMenuItem();
            gachaToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            yoloLogToolStripMenuItem = new ToolStripMenuItem();
            sparkLogToolStripMenuItem = new ToolStripMenuItem();
            freebieLogToolStripMenuItem = new ToolStripMenuItem();
            collectionTrackerToolStripMenuItem = new ToolStripMenuItem();
            eternalsToolStripMenuItem = new ToolStripMenuItem();
            recruitToolStripMenuItem = new ToolStripMenuItem();
            uncapToolStripMenuItem = new ToolStripMenuItem();
            transcendenceToolStripMenuItem = new ToolStripMenuItem();
            evokersToolStripMenuItem = new ToolStripMenuItem();
            goldBrickTallyToolStripMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            MainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem, gachaToolStripMenuItem, collectionTrackerToolStripMenuItem, goldBrickTallyToolStripMenuItem });
            MainMenuStrip.Location = new Point(0, 0);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Size = new Size(1071, 24);
            MainMenuStrip.TabIndex = 1;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createAllSSRCharacterListToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // createAllSSRCharacterListToolStripMenuItem
            // 
            createAllSSRCharacterListToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { updateDatabaseToolStripMenuItem, addDataToolStripMenuItem, editDataToolStripMenuItem });
            createAllSSRCharacterListToolStripMenuItem.Name = "createAllSSRCharacterListToolStripMenuItem";
            createAllSSRCharacterListToolStripMenuItem.Size = new Size(180, 22);
            createAllSSRCharacterListToolStripMenuItem.Text = "Database";
            // 
            // updateDatabaseToolStripMenuItem
            // 
            updateDatabaseToolStripMenuItem.Name = "updateDatabaseToolStripMenuItem";
            updateDatabaseToolStripMenuItem.Size = new Size(180, 22);
            updateDatabaseToolStripMenuItem.Text = "Update Database";
            updateDatabaseToolStripMenuItem.Click += LoadUpdateOptions;
            // 
            // addDataToolStripMenuItem
            // 
            addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            addDataToolStripMenuItem.Size = new Size(180, 22);
            addDataToolStripMenuItem.Text = "Add Data";
            addDataToolStripMenuItem.Click += AddData;
            // 
            // editDataToolStripMenuItem
            // 
            editDataToolStripMenuItem.Name = "editDataToolStripMenuItem";
            editDataToolStripMenuItem.Size = new Size(180, 22);
            editDataToolStripMenuItem.Text = "Edit Data";
            editDataToolStripMenuItem.Click += OpenEditor;
            // 
            // gachaToolStripMenuItem
            // 
            gachaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logsToolStripMenuItem, yoloLogToolStripMenuItem, sparkLogToolStripMenuItem, freebieLogToolStripMenuItem });
            gachaToolStripMenuItem.Name = "gachaToolStripMenuItem";
            gachaToolStripMenuItem.Size = new Size(52, 20);
            gachaToolStripMenuItem.Text = "Gacha";
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(135, 22);
            logsToolStripMenuItem.Text = "Logs";
            logsToolStripMenuItem.Click += OpenLogs;
            // 
            // yoloLogToolStripMenuItem
            // 
            yoloLogToolStripMenuItem.Name = "yoloLogToolStripMenuItem";
            yoloLogToolStripMenuItem.Size = new Size(135, 22);
            yoloLogToolStripMenuItem.Text = "Yolo";
            yoloLogToolStripMenuItem.Click += LoadYoloLog;
            // 
            // sparkLogToolStripMenuItem
            // 
            sparkLogToolStripMenuItem.Name = "sparkLogToolStripMenuItem";
            sparkLogToolStripMenuItem.Size = new Size(135, 22);
            sparkLogToolStripMenuItem.Text = "Spark";
            sparkLogToolStripMenuItem.Click += LoadSparkForm;
            // 
            // freebieLogToolStripMenuItem
            // 
            freebieLogToolStripMenuItem.Name = "freebieLogToolStripMenuItem";
            freebieLogToolStripMenuItem.Size = new Size(135, 22);
            freebieLogToolStripMenuItem.Text = "Freebie Log";
            freebieLogToolStripMenuItem.Click += LoadFreeLog;
            // 
            // collectionTrackerToolStripMenuItem
            // 
            collectionTrackerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { eternalsToolStripMenuItem, evokersToolStripMenuItem });
            collectionTrackerToolStripMenuItem.Name = "collectionTrackerToolStripMenuItem";
            collectionTrackerToolStripMenuItem.Size = new Size(113, 20);
            collectionTrackerToolStripMenuItem.Text = "Collection Tracker";
            // 
            // eternalsToolStripMenuItem
            // 
            eternalsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recruitToolStripMenuItem, uncapToolStripMenuItem, transcendenceToolStripMenuItem });
            eternalsToolStripMenuItem.Enabled = false;
            eternalsToolStripMenuItem.Name = "eternalsToolStripMenuItem";
            eternalsToolStripMenuItem.Size = new Size(115, 22);
            eternalsToolStripMenuItem.Text = "Eternals";
            // 
            // recruitToolStripMenuItem
            // 
            recruitToolStripMenuItem.Name = "recruitToolStripMenuItem";
            recruitToolStripMenuItem.Size = new Size(152, 22);
            recruitToolStripMenuItem.Text = "Recruit";
            // 
            // uncapToolStripMenuItem
            // 
            uncapToolStripMenuItem.Name = "uncapToolStripMenuItem";
            uncapToolStripMenuItem.Size = new Size(152, 22);
            uncapToolStripMenuItem.Text = "Uncap";
            // 
            // transcendenceToolStripMenuItem
            // 
            transcendenceToolStripMenuItem.Name = "transcendenceToolStripMenuItem";
            transcendenceToolStripMenuItem.Size = new Size(152, 22);
            transcendenceToolStripMenuItem.Text = "Transcendence";
            // 
            // evokersToolStripMenuItem
            // 
            evokersToolStripMenuItem.Enabled = false;
            evokersToolStripMenuItem.Name = "evokersToolStripMenuItem";
            evokersToolStripMenuItem.Size = new Size(115, 22);
            evokersToolStripMenuItem.Text = "Evokers";
            // 
            // goldBrickTallyToolStripMenuItem
            // 
            goldBrickTallyToolStripMenuItem.Name = "goldBrickTallyToolStripMenuItem";
            goldBrickTallyToolStripMenuItem.Size = new Size(99, 20);
            goldBrickTallyToolStripMenuItem.Text = "Gold Brick Tally";
            goldBrickTallyToolStripMenuItem.Click += LoadGBForm;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 24);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1071, 472);
            mainPanel.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.ProgressChanged += UpdateProgress;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 496);
            Controls.Add(mainPanel);
            Controls.Add(MainMenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HomePage";
            Text = "Never Crew Buddy";
            Load += InitializeContent;
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem logsToolStripMenuItem;
        private ToolStripMenuItem addDataToolStripMenuItem;
        private ToolStripMenuItem editDataToolStripMenuItem;
    }
}