namespace GBF_Never_Buddy
{
    partial class GachaForm
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.outputBtn = new System.Windows.Forms.Button();
            this.singleDrawBtn = new System.Windows.Forms.Button();
            this.costLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tenDrawBtn = new System.Windows.Forms.Button();
            this.resultsTable = new System.Windows.Forms.TableLayoutPanel();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.outputBtn);
            this.sidePanel.Controls.Add(this.singleDrawBtn);
            this.sidePanel.Controls.Add(this.costLabel);
            this.sidePanel.Controls.Add(this.pictureBox1);
            this.sidePanel.Controls.Add(this.tenDrawBtn);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(290, 597);
            this.sidePanel.TabIndex = 2;
            // 
            // outputBtn
            // 
            this.outputBtn.Location = new System.Drawing.Point(37, 512);
            this.outputBtn.Name = "outputBtn";
            this.outputBtn.Size = new System.Drawing.Size(184, 57);
            this.outputBtn.TabIndex = 5;
            this.outputBtn.Text = "Open Results Tab";
            this.outputBtn.UseVisualStyleBackColor = true;
            this.outputBtn.Click += new System.EventHandler(this.OpenResults);
            // 
            // singleDrawBtn
            // 
            this.singleDrawBtn.BackColor = System.Drawing.Color.IndianRed;
            this.singleDrawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.singleDrawBtn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.singleDrawBtn.Image = global::GBF_Never_Buddy.Properties.Resources.text_stone;
            this.singleDrawBtn.Location = new System.Drawing.Point(12, 392);
            this.singleDrawBtn.Name = "singleDrawBtn";
            this.singleDrawBtn.Size = new System.Drawing.Size(252, 89);
            this.singleDrawBtn.TabIndex = 4;
            this.singleDrawBtn.UseVisualStyleBackColor = false;
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(24, 182);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(80, 15);
            this.costLabel.TabIndex = 3;
            this.costLabel.Text = "Crystals Used:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 129);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tenDrawBtn
            // 
            this.tenDrawBtn.BackColor = System.Drawing.Color.IndianRed;
            this.tenDrawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tenDrawBtn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.tenDrawBtn.Image = global::GBF_Never_Buddy.Properties.Resources.text_stone10;
            this.tenDrawBtn.Location = new System.Drawing.Point(12, 272);
            this.tenDrawBtn.Name = "tenDrawBtn";
            this.tenDrawBtn.Size = new System.Drawing.Size(252, 89);
            this.tenDrawBtn.TabIndex = 0;
            this.tenDrawBtn.UseVisualStyleBackColor = false;
            this.tenDrawBtn.Click += new System.EventHandler(this.TenDrawBtn_Click);
            // 
            // resultsTable
            // 
            this.resultsTable.AutoScroll = true;
            this.resultsTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultsTable.ColumnCount = 1;
            this.resultsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.resultsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTable.Location = new System.Drawing.Point(290, 0);
            this.resultsTable.Name = "resultsTable";
            this.resultsTable.RowCount = 1;
            this.resultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.resultsTable.Size = new System.Drawing.Size(868, 597);
            this.resultsTable.TabIndex = 3;
            // 
            // GachaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 597);
            this.Controls.Add(this.resultsTable);
            this.Controls.Add(this.sidePanel);
            this.Name = "GachaForm";
            this.Text = "GachaForm";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel sidePanel;
        private Button outputBtn;
        private Button singleDrawBtn;
        private Label costLabel;
        private PictureBox pictureBox1;
        private Button tenDrawBtn;
        private TableLayoutPanel resultsTable;
    }
}