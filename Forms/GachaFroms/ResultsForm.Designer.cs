namespace GBF_Never_Buddy.GachaForms
{
    partial class ResultsForm
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
            this.inDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBtn = new System.Windows.Forms.Button();
            this.crystalsLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newCharacterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.summonLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gmLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.charLabel = new System.Windows.Forms.Label();
            this.summonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.gmCharacterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rateLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // inDBToolStripMenuItem
            // 
            this.inDBToolStripMenuItem.Name = "inDBToolStripMenuItem";
            this.inDBToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.inDBToolStripMenuItem.Text = "In DB";
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asPNGToolStripMenuItem,
            this.inDBToolStripMenuItem});
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            // 
            // asPNGToolStripMenuItem
            // 
            this.asPNGToolStripMenuItem.Name = "asPNGToolStripMenuItem";
            this.asPNGToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.asPNGToolStripMenuItem.Text = "As PNG";
            this.asPNGToolStripMenuItem.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(762, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(137, 30);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save Log";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // crystalsLabel
            // 
            this.crystalsLabel.AutoSize = true;
            this.crystalsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crystalsLabel.Location = new System.Drawing.Point(609, 30);
            this.crystalsLabel.Name = "crystalsLabel";
            this.crystalsLabel.Size = new System.Drawing.Size(65, 21);
            this.crystalsLabel.TabIndex = 1;
            this.crystalsLabel.Text = "crystals";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateLabel.Location = new System.Drawing.Point(3, 30);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(44, 21);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "date";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(911, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newCharacterPanel
            // 
            this.newCharacterPanel.AllowDrop = true;
            this.newCharacterPanel.AutoScroll = true;
            this.newCharacterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newCharacterPanel.Location = new System.Drawing.Point(3, 159);
            this.newCharacterPanel.Name = "newCharacterPanel";
            this.newCharacterPanel.Size = new System.Drawing.Size(297, 499);
            this.newCharacterPanel.TabIndex = 3;
            this.newCharacterPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.UpdateValues);
            this.newCharacterPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.NewCharacterCheckImage);
            this.newCharacterPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GBF_Never_Buddy.Properties.Resources.Sunlight_Stone;
            this.pictureBox3.Location = new System.Drawing.Point(89, 17);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(130, 130);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // summonLabel
            // 
            this.summonLabel.AutoSize = true;
            this.summonLabel.Location = new System.Drawing.Point(3, 2);
            this.summonLabel.Name = "summonLabel";
            this.summonLabel.Size = new System.Drawing.Size(64, 15);
            this.summonLabel.TabIndex = 6;
            this.summonLabel.Text = "Summons:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.summonLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(609, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(299, 150);
            this.panel4.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GBF_Never_Buddy.Properties.Resources.Gold_Moon;
            this.pictureBox2.Location = new System.Drawing.Point(81, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // gmLabel
            // 
            this.gmLabel.AutoSize = true;
            this.gmLabel.Location = new System.Drawing.Point(3, 2);
            this.gmLabel.Name = "gmLabel";
            this.gmLabel.Size = new System.Drawing.Size(75, 15);
            this.gmLabel.TabIndex = 5;
            this.gmLabel.Text = "Gold Moons:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.gmLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(306, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 150);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GBF_Never_Buddy.Properties.Resources.Crystal;
            this.pictureBox1.Location = new System.Drawing.Point(75, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // charLabel
            // 
            this.charLabel.AutoSize = true;
            this.charLabel.Location = new System.Drawing.Point(3, 2);
            this.charLabel.Name = "charLabel";
            this.charLabel.Size = new System.Drawing.Size(93, 15);
            this.charLabel.TabIndex = 4;
            this.charLabel.Text = "New Characters:";
            // 
            // summonPanel
            // 
            this.summonPanel.AllowDrop = true;
            this.summonPanel.AutoScroll = true;
            this.summonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summonPanel.Location = new System.Drawing.Point(609, 159);
            this.summonPanel.Name = "summonPanel";
            this.summonPanel.Size = new System.Drawing.Size(299, 499);
            this.summonPanel.TabIndex = 5;
            this.summonPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.UpdateValues);
            this.summonPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.SummonCheckImage);
            this.summonPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // gmCharacterPanel
            // 
            this.gmCharacterPanel.AllowDrop = true;
            this.gmCharacterPanel.AutoScroll = true;
            this.gmCharacterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmCharacterPanel.Location = new System.Drawing.Point(306, 159);
            this.gmCharacterPanel.Name = "gmCharacterPanel";
            this.gmCharacterPanel.Size = new System.Drawing.Size(297, 499);
            this.gmCharacterPanel.TabIndex = 4;
            this.gmCharacterPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.UpdateValues);
            this.gmCharacterPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.GoldMoonCheckImage);
            this.gmCharacterPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.charLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 150);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.summonPanel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.gmCharacterPanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.newCharacterPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.75189F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.24811F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(911, 661);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // rateLabel
            // 
            this.rateLabel.AutoSize = true;
            this.rateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rateLabel.Location = new System.Drawing.Point(0, 66);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(44, 21);
            this.rateLabel.TabIndex = 7;
            this.rateLabel.Text = "Rate:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 661);
            this.panel1.TabIndex = 3;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.rateLabel);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.saveBtn);
            this.mainPanel.Controls.Add(this.crystalsLabel);
            this.mainPanel.Controls.Add(this.dateLabel);
            this.mainPanel.Controls.Add(this.menuStrip1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(911, 751);
            this.mainPanel.TabIndex = 1;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(911, 751);
            this.Controls.Add(this.mainPanel);
            this.Name = "ResultsForm";
            this.Text = "ResultsForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripMenuItem inDBToolStripMenuItem;
        private ToolStripMenuItem saveLogToolStripMenuItem;
        private ToolStripMenuItem asPNGToolStripMenuItem;
        private Button saveBtn;
        private Label crystalsLabel;
        private Label dateLabel;
        private MenuStrip menuStrip1;
        private FlowLayoutPanel newCharacterPanel;
        private PictureBox pictureBox3;
        private Label summonLabel;
        private Panel panel4;
        private PictureBox pictureBox2;
        private Label gmLabel;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label charLabel;
        private FlowLayoutPanel summonPanel;
        private FlowLayoutPanel gmCharacterPanel;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label rateLabel;
        private Panel panel1;
        private Panel mainPanel;
    }
}