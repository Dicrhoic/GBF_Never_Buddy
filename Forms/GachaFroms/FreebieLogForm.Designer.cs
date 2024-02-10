namespace GBF_Never_Buddy.Forms.GachaFroms
{
    partial class FreebieLogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            resultsTable = new TableLayoutPanel();
            listView1 = new ListView();
            menuStrip1 = new MenuStrip();
            newDrawToolStripMenuItem = new ToolStripMenuItem();
            rouletteToolStripMenuItem = new ToolStripMenuItem();
            dailyToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            dataToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // resultsTable
            // 
            resultsTable.AutoScroll = true;
            resultsTable.BackColor = SystemColors.ControlLight;
            resultsTable.ColumnCount = 1;
            resultsTable.ColumnStyles.Add(new ColumnStyle());
            resultsTable.Dock = DockStyle.Fill;
            resultsTable.Location = new Point(148, 24);
            resultsTable.Name = "resultsTable";
            resultsTable.RowCount = 1;
            resultsTable.RowStyles.Add(new RowStyle());
            resultsTable.Size = new Size(1212, 517);
            resultsTable.TabIndex = 6;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Left;
            listView1.Location = new Point(0, 24);
            listView1.Name = "listView1";
            listView1.Size = new Size(148, 517);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { newDrawToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1360, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // newDrawToolStripMenuItem
            // 
            newDrawToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rouletteToolStripMenuItem, dailyToolStripMenuItem });
            newDrawToolStripMenuItem.Name = "newDrawToolStripMenuItem";
            newDrawToolStripMenuItem.Size = new Size(73, 20);
            newDrawToolStripMenuItem.Text = "New Draw";
            // 
            // rouletteToolStripMenuItem
            // 
            rouletteToolStripMenuItem.Name = "rouletteToolStripMenuItem";
            rouletteToolStripMenuItem.Size = new Size(169, 22);
            rouletteToolStripMenuItem.Text = "Roulette Final Day";
            rouletteToolStripMenuItem.Click += LoadRoulette;
            // 
            // dailyToolStripMenuItem
            // 
            dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            dailyToolStripMenuItem.Size = new Size(169, 22);
            dailyToolStripMenuItem.Text = "Daily";
            dailyToolStripMenuItem.Click += LoadNewDraw;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dataToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // dataToolStripMenuItem
            // 
            dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            dataToolStripMenuItem.Size = new Size(98, 22);
            dataToolStripMenuItem.Text = "Data";
            // 
            // FreebieLogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 541);
            Controls.Add(resultsTable);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FreebieLogForm";
            Text = "FreebieLogForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel resultsTable;
        private ListView listView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem newDrawToolStripMenuItem;
        private ToolStripMenuItem rouletteToolStripMenuItem;
        private ToolStripMenuItem dailyToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem dataToolStripMenuItem;
    }
}