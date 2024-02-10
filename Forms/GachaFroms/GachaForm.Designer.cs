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
            sidePanel = new Panel();
            outputBtn = new Button();
            singleDrawBtn = new Button();
            costLabel = new Label();
            pictureBox1 = new PictureBox();
            tenDrawBtn = new Button();
            resultsTable = new TableLayoutPanel();
            sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // sidePanel
            // 
            sidePanel.Controls.Add(outputBtn);
            sidePanel.Controls.Add(singleDrawBtn);
            sidePanel.Controls.Add(costLabel);
            sidePanel.Controls.Add(pictureBox1);
            sidePanel.Controls.Add(tenDrawBtn);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(0, 0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(290, 597);
            sidePanel.TabIndex = 2;
            // 
            // outputBtn
            // 
            outputBtn.Location = new Point(37, 512);
            outputBtn.Name = "outputBtn";
            outputBtn.Size = new Size(184, 57);
            outputBtn.TabIndex = 5;
            outputBtn.Text = "Open Results Tab";
            outputBtn.UseVisualStyleBackColor = true;
            outputBtn.Click += OpenResults;
            // 
            // singleDrawBtn
            // 
            singleDrawBtn.BackColor = Color.IndianRed;
            singleDrawBtn.BackgroundImageLayout = ImageLayout.Center;
            singleDrawBtn.FlatAppearance.BorderColor = Color.Yellow;
            singleDrawBtn.Image = Properties.Resources.text_stone;
            singleDrawBtn.Location = new Point(12, 392);
            singleDrawBtn.Name = "singleDrawBtn";
            singleDrawBtn.Size = new Size(252, 89);
            singleDrawBtn.TabIndex = 4;
            singleDrawBtn.UseVisualStyleBackColor = false;
            // 
            // costLabel
            // 
            costLabel.AutoSize = true;
            costLabel.Location = new Point(24, 182);
            costLabel.Name = "costLabel";
            costLabel.Size = new Size(80, 15);
            costLabel.TabIndex = 3;
            costLabel.Text = "Crystals Used:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(252, 129);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // tenDrawBtn
            // 
            tenDrawBtn.BackColor = Color.IndianRed;
            tenDrawBtn.BackgroundImageLayout = ImageLayout.Center;
            tenDrawBtn.FlatAppearance.BorderColor = Color.Yellow;
            tenDrawBtn.Image = Properties.Resources.text_stone10;
            tenDrawBtn.Location = new Point(12, 272);
            tenDrawBtn.Name = "tenDrawBtn";
            tenDrawBtn.Size = new Size(252, 89);
            tenDrawBtn.TabIndex = 0;
            tenDrawBtn.UseVisualStyleBackColor = false;
            tenDrawBtn.Click += TenDrawBtn_Click;
            // 
            // resultsTable
            // 
            resultsTable.AutoScroll = true;
            resultsTable.BackColor = SystemColors.ControlLight;
            resultsTable.ColumnCount = 1;
            resultsTable.ColumnStyles.Add(new ColumnStyle());
            resultsTable.Dock = DockStyle.Fill;
            resultsTable.Location = new Point(290, 0);
            resultsTable.Name = "resultsTable";
            resultsTable.RowCount = 1;
            resultsTable.RowStyles.Add(new RowStyle());
            resultsTable.Size = new Size(868, 597);
            resultsTable.TabIndex = 3;
            // 
            // GachaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 597);
            Controls.Add(resultsTable);
            Controls.Add(sidePanel);
            Name = "GachaForm";
            Text = "GachaForm";
            FormClosed += GachaForm_FormClosed;
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
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