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
            label1 = new Label();
            comboBox1 = new ComboBox();
            panel1 = new Panel();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            outputBtn = new Button();
            singleDrawBtn = new Button();
            costLabel = new Label();
            pictureBox1 = new PictureBox();
            tenDrawBtn = new Button();
            resultsTable = new TableLayoutPanel();
            sidePanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // sidePanel
            // 
            sidePanel.Controls.Add(label1);
            sidePanel.Controls.Add(comboBox1);
            sidePanel.Controls.Add(panel1);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 229);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 8;
            label1.Text = "Ticketss Used:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBox1.Location = new Point(12, 390);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(252, 23);
            comboBox1.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 36);
            panel1.TabIndex = 6;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Dock = DockStyle.Left;
            radioButton2.Location = new Point(76, 0);
            radioButton2.Name = "radioButton2";
            radioButton2.Padding = new Padding(10, 0, 5, 0);
            radioButton2.Size = new Size(71, 36);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "Ticket";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += UpdateCostSource;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Dock = DockStyle.Left;
            radioButton1.Location = new Point(0, 0);
            radioButton1.Name = "radioButton1";
            radioButton1.Padding = new Padding(10, 0, 5, 0);
            radioButton1.Size = new Size(76, 36);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Crystal";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += UpdateCostSource;
            // 
            // outputBtn
            // 
            outputBtn.Location = new Point(40, 528);
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
            singleDrawBtn.Location = new Point(12, 419);
            singleDrawBtn.Name = "singleDrawBtn";
            singleDrawBtn.Size = new Size(252, 89);
            singleDrawBtn.TabIndex = 4;
            singleDrawBtn.UseVisualStyleBackColor = false;
            singleDrawBtn.Click += SingleDraw;
            // 
            // costLabel
            // 
            costLabel.AutoSize = true;
            costLabel.Location = new Point(12, 197);
            costLabel.Name = "costLabel";
            costLabel.Size = new Size(80, 15);
            costLabel.TabIndex = 3;
            costLabel.Text = "Crystals Used:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 54);
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
            tenDrawBtn.Location = new Point(12, 271);
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Panel panel1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ComboBox comboBox1;
        private Label label1;
    }
}