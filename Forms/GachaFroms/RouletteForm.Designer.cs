namespace GBF_Never_Buddy.GachaForms
{
    partial class RouletteForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataTabs = new System.Windows.Forms.TabControl();
            this.gachapinTab = new System.Windows.Forms.TabPage();
            this.MukkuTab = new System.Windows.Forms.TabPage();
            this.topPanel = new System.Windows.Forms.Panel();
            this.resultsTableGP = new System.Windows.Forms.TableLayoutPanel();
            this.resultsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tenDrawBtn = new System.Windows.Forms.Button();
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
            this.dataTabs.Size = new System.Drawing.Size(1174, 536);
            this.dataTabs.TabIndex = 1;
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
            this.gachapinTab.Size = new System.Drawing.Size(1166, 502);
            this.gachapinTab.TabIndex = 0;
            this.gachapinTab.Text = "Gachapin";
            // 
            // MukkuTab
            // 
            this.MukkuTab.Controls.Add(this.resultsTable);
            this.MukkuTab.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MukkuTab.Location = new System.Drawing.Point(4, 30);
            this.MukkuTab.Name = "MukkuTab";
            this.MukkuTab.Padding = new System.Windows.Forms.Padding(3);
            this.MukkuTab.Size = new System.Drawing.Size(1166, 502);
            this.MukkuTab.TabIndex = 1;
            this.MukkuTab.Text = "Mukku";
            this.MukkuTab.UseVisualStyleBackColor = true;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.tenDrawBtn);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1174, 100);
            this.topPanel.TabIndex = 0;
            // 
            // resultsTableGP
            // 
            this.resultsTableGP.AutoScroll = true;
            this.resultsTableGP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultsTableGP.ColumnCount = 1;
            this.resultsTableGP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultsTableGP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTableGP.Location = new System.Drawing.Point(3, 3);
            this.resultsTableGP.Name = "resultsTableGP";
            this.resultsTableGP.RowCount = 1;
            this.resultsTableGP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultsTableGP.Size = new System.Drawing.Size(1158, 494);
            this.resultsTableGP.TabIndex = 4;
            // 
            // resultsTable
            // 
            this.resultsTable.AutoScroll = true;
            this.resultsTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultsTable.ColumnCount = 1;
            this.resultsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTable.Location = new System.Drawing.Point(3, 3);
            this.resultsTable.Name = "resultsTable";
            this.resultsTable.RowCount = 1;
            this.resultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultsTable.Size = new System.Drawing.Size(1160, 496);
            this.resultsTable.TabIndex = 4;
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
            // RouletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataTabs);
            this.Controls.Add(this.topPanel);
            this.Name = "RouletteForm";
            this.Size = new System.Drawing.Size(1174, 636);
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
        private TabPage MukkuTab;
        private Panel topPanel;
        private TableLayoutPanel resultsTableGP;
        private TableLayoutPanel resultsTable;
        private Label label1;
        private Button tenDrawBtn;
    }
}
