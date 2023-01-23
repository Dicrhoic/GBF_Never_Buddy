namespace GBF_Never_Buddy.GachaForms
{
    partial class RouletteLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouletteLog));
            this.dataTabs = new System.Windows.Forms.TabControl();
            this.gachapinTab = new System.Windows.Forms.TabPage();
            this.resultsTableGP = new System.Windows.Forms.TableLayoutPanel();
            this.MukkuTab = new System.Windows.Forms.TabPage();
            this.resultsTable = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.outputBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tenDrawBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataTabs.SuspendLayout();
            this.gachapinTab.SuspendLayout();
            this.MukkuTab.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTabs
            // 
            this.dataTabs.Controls.Add(this.gachapinTab);
            this.dataTabs.Controls.Add(this.MukkuTab);
            this.dataTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTabs.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dataTabs.Location = new System.Drawing.Point(0, 100);
            this.dataTabs.Name = "dataTabs";
            this.dataTabs.SelectedIndex = 0;
            this.dataTabs.Size = new System.Drawing.Size(1172, 497);
            this.dataTabs.TabIndex = 3;
            // 
            // gachapinTab
            // 
            this.gachapinTab.AutoScroll = true;
            this.gachapinTab.BackColor = System.Drawing.Color.White;
            this.gachapinTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gachapinTab.Controls.Add(this.resultsTableGP);
            this.gachapinTab.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gachapinTab.Location = new System.Drawing.Point(4, 30);
            this.gachapinTab.Name = "gachapinTab";
            this.gachapinTab.Padding = new System.Windows.Forms.Padding(3);
            this.gachapinTab.Size = new System.Drawing.Size(1164, 463);
            this.gachapinTab.TabIndex = 0;
            this.gachapinTab.Text = "Gachapin";
            // 
            // resultsTableGP
            // 
            this.resultsTableGP.AutoScroll = true;
            this.resultsTableGP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultsTableGP.ColumnCount = 1;
            this.resultsTableGP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultsTableGP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTableGP.Location = new System.Drawing.Point(3, 3);
            this.resultsTableGP.Name = "resultsTableGP";
            this.resultsTableGP.RowCount = 1;
            this.resultsTableGP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.resultsTableGP.Size = new System.Drawing.Size(1156, 455);
            this.resultsTableGP.TabIndex = 4;
            // 
            // MukkuTab
            // 
            this.MukkuTab.Controls.Add(this.resultsTable);
            this.MukkuTab.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MukkuTab.Location = new System.Drawing.Point(4, 30);
            this.MukkuTab.Name = "MukkuTab";
            this.MukkuTab.Padding = new System.Windows.Forms.Padding(3);
            this.MukkuTab.Size = new System.Drawing.Size(1164, 463);
            this.MukkuTab.TabIndex = 1;
            this.MukkuTab.Text = "Mukku";
            this.MukkuTab.UseVisualStyleBackColor = true;
            // 
            // resultsTable
            // 
            this.resultsTable.AutoScroll = true;
            this.resultsTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultsTable.ColumnCount = 1;
            this.resultsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTable.Location = new System.Drawing.Point(3, 3);
            this.resultsTable.Name = "resultsTable";
            this.resultsTable.RowCount = 1;
            this.resultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.resultsTable.Size = new System.Drawing.Size(1158, 457);
            this.resultsTable.TabIndex = 4;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.outputBtn);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Controls.Add(this.tenDrawBtn);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1172, 100);
            this.topPanel.TabIndex = 2;
            // 
            // outputBtn
            // 
            this.outputBtn.Location = new System.Drawing.Point(121, 71);
            this.outputBtn.Name = "outputBtn";
            this.outputBtn.Size = new System.Drawing.Size(114, 23);
            this.outputBtn.TabIndex = 6;
            this.outputBtn.Text = "Open Results Tab";
            this.outputBtn.UseVisualStyleBackColor = true;
            this.outputBtn.Click += new System.EventHandler(this.outputBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ScreenShotForm);
            // 
            // tenDrawBtn
            // 
            this.tenDrawBtn.BackColor = System.Drawing.Color.IndianRed;
            this.tenDrawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tenDrawBtn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.tenDrawBtn.Image = global::GBF_Never_Buddy.Properties.Resources.text_stone10;
            this.tenDrawBtn.Location = new System.Drawing.Point(914, 5);
            this.tenDrawBtn.Name = "tenDrawBtn";
            this.tenDrawBtn.Size = new System.Drawing.Size(252, 89);
            this.tenDrawBtn.TabIndex = 1;
            this.tenDrawBtn.UseVisualStyleBackColor = false;
            this.tenDrawBtn.Click += new System.EventHandler(this.TenDrawBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // RouletteLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 597);
            this.Controls.Add(this.dataTabs);
            this.Controls.Add(this.topPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RouletteLog";
            this.Text = "RouletteLog";
            this.dataTabs.ResumeLayout(false);
            this.gachapinTab.ResumeLayout(false);
            this.MukkuTab.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl dataTabs;
        private TabPage gachapinTab;
        private TableLayoutPanel resultsTableGP;
        private TabPage MukkuTab;
        private TableLayoutPanel resultsTable;
        private Panel topPanel;
        private Button tenDrawBtn;
        private Label label1;
        private Button button1;
        private Button outputBtn;
    }
}