﻿namespace GBF_Never_Buddy.Forms.GachaFroms
{
    partial class UpdateGachaLog
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
            panel1 = new Panel();
            label1 = new Label();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            panel3 = new Panel();
            editPanel = new Panel();
            button3 = new Button();
            button2 = new Button();
            panel4 = new Panel();
            label2 = new Label();
            drawNumCB = new ComboBox();
            button1 = new Button();
            resultsPanel = new Panel();
            panel6 = new Panel();
            summonRes = new TextBox();
            label4 = new Label();
            panel7 = new Panel();
            resultsBox = new TextBox();
            label3 = new Label();
            panel5 = new Panel();
            checkedListBox1 = new CheckedListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            editPanel.SuspendLayout();
            panel4.SuspendLayout();
            resultsPanel.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(999, 43);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 1;
            label1.Text = "ID:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(39, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += LoadData;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(999, 119);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(editPanel);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 162);
            panel3.Name = "panel3";
            panel3.Size = new Size(999, 85);
            panel3.TabIndex = 2;
            // 
            // editPanel
            // 
            editPanel.Controls.Add(button3);
            editPanel.Controls.Add(button2);
            editPanel.Dock = DockStyle.Left;
            editPanel.Location = new Point(444, 0);
            editPanel.Name = "editPanel";
            editPanel.Size = new Size(321, 85);
            editPanel.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(159, 31);
            button3.Name = "button3";
            button3.Size = new Size(103, 23);
            button3.TabIndex = 6;
            button3.Text = "Remove Row";
            button3.UseVisualStyleBackColor = true;
            button3.Click += RemoveRow;
            // 
            // button2
            // 
            button2.Location = new Point(43, 31);
            button2.Name = "button2";
            button2.Size = new Size(103, 23);
            button2.TabIndex = 5;
            button2.Text = "Add Row";
            button2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Controls.Add(drawNumCB);
            panel4.Controls.Add(button1);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(444, 85);
            panel4.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 34);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 3;
            label2.Text = "Draw Number:";
            // 
            // drawNumCB
            // 
            drawNumCB.DropDownStyle = ComboBoxStyle.DropDownList;
            drawNumCB.FormattingEnabled = true;
            drawNumCB.Location = new Point(93, 31);
            drawNumCB.Name = "drawNumCB";
            drawNumCB.Size = new Size(182, 23);
            drawNumCB.TabIndex = 2;
            drawNumCB.SelectedIndexChanged += FindData;
            // 
            // button1
            // 
            button1.Location = new Point(303, 31);
            button1.Name = "button1";
            button1.Size = new Size(103, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += EditData;
            // 
            // resultsPanel
            // 
            resultsPanel.Controls.Add(panel6);
            resultsPanel.Controls.Add(panel5);
            resultsPanel.Dock = DockStyle.Top;
            resultsPanel.Location = new Point(0, 247);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Padding = new Padding(0, 5, 0, 0);
            resultsPanel.Size = new Size(999, 43);
            resultsPanel.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.Controls.Add(summonRes);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(resultsBox);
            panel6.Controls.Add(label3);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 5);
            panel6.Name = "panel6";
            panel6.Size = new Size(999, 31);
            panel6.TabIndex = 3;
            // 
            // summonRes
            // 
            summonRes.Dock = DockStyle.Left;
            summonRes.Location = new Point(554, 0);
            summonRes.Name = "summonRes";
            summonRes.Size = new Size(268, 23);
            summonRes.TabIndex = 6;
            summonRes.Tag = "summon";
            summonRes.KeyDown += ValidateText;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Location = new Point(444, 0);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 5;
            label4.Text = "Acquired Summon:";
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(380, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(64, 31);
            panel7.TabIndex = 4;
            // 
            // resultsBox
            // 
            resultsBox.Dock = DockStyle.Left;
            resultsBox.Location = new Point(112, 0);
            resultsBox.Name = "resultsBox";
            resultsBox.Size = new Size(268, 23);
            resultsBox.TabIndex = 3;
            resultsBox.Tag = "character";
            resultsBox.KeyDown += ValidateText;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 2;
            label3.Text = "Acquired Character:";
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            panel5.Controls.Add(checkedListBox1);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 38);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(0, 5, 0, 0);
            panel5.Size = new Size(999, 5);
            panel5.TabIndex = 2;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Dock = DockStyle.Left;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(0, 5);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(268, 0);
            checkedListBox1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 290);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(999, 20);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // UpdateGachaLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(999, 442);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(resultsPanel);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UpdateGachaLog";
            Text = "UpdateGachaLog";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            editPanel.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            resultsPanel.ResumeLayout(false);
            resultsPanel.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Button button1;
        private Panel panel4;
        private Label label2;
        private ComboBox drawNumCB;
        private Panel editPanel;
        private Button button3;
        private Button button2;
        private Panel resultsPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel5;
        private CheckedListBox checkedListBox1;
        private Panel panel6;
        private TextBox summonRes;
        private Label label4;
        private Panel panel7;
        private TextBox resultsBox;
        private Label label3;
    }
}