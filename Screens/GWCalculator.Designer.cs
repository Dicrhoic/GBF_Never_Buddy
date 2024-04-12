namespace GBF_Never_Buddy.Screens
{
    partial class GWCalculator
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
            optionsPanel = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label5 = new Label();
            numericUpDown4 = new NumericUpDown();
            label6 = new Label();
            numericUpDown5 = new NumericUpDown();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            meatNumeric = new NumericUpDown();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            numericUpDown3 = new NumericUpDown();
            raidChoicePanel = new Panel();
            revivePanel = new Panel();
            reviveTimePanel = new Panel();
            label8 = new Label();
            numericUpDown6 = new NumericUpDown();
            reviveNRB = new RadioButton();
            reviveYRB = new RadioButton();
            label7 = new Label();
            levelSelectPanel = new FlowLayoutPanel();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            level5CB = new CheckBox();
            meatFarmPanel = new Panel();
            panel1 = new Panel();
            exPOtpnRB = new RadioButton();
            exOtpnRB = new RadioButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            optionsPanel.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)meatNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            raidChoicePanel.SuspendLayout();
            revivePanel.SuspendLayout();
            reviveTimePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            levelSelectPanel.SuspendLayout();
            meatFarmPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // optionsPanel
            // 
            optionsPanel.Controls.Add(flowLayoutPanel2);
            optionsPanel.Controls.Add(flowLayoutPanel1);
            optionsPanel.Dock = DockStyle.Top;
            optionsPanel.Location = new Point(0, 0);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new Size(1007, 64);
            optionsPanel.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Controls.Add(numericUpDown4);
            flowLayoutPanel2.Controls.Add(label6);
            flowLayoutPanel2.Controls.Add(numericUpDown5);
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Dock = DockStyle.Left;
            flowLayoutPanel2.Location = new Point(0, 32);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(759, 32);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(92, 21);
            label5.TabIndex = 8;
            label5.Text = "Target Box:";
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(101, 3);
            numericUpDown4.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDown4.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(139, 23);
            numericUpDown4.TabIndex = 9;
            numericUpDown4.Value = new decimal(new int[] { 43, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(246, 0);
            label6.Name = "label6";
            label6.Size = new Size(134, 21);
            label6.TabIndex = 10;
            label6.Text = "Target honour(s):";
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(386, 3);
            numericUpDown5.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 50000, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(131, 23);
            numericUpDown5.TabIndex = 11;
            numericUpDown5.ThousandsSeparator = true;
            numericUpDown5.Value = new decimal(new int[] { 1000000000, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(523, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Calculate;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(meatNumeric);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(numericUpDown1);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(numericUpDown2);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(numericUpDown3);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1007, 32);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 0;
            label1.Text = "Current Meat:";
            // 
            // meatNumeric
            // 
            meatNumeric.Location = new Point(120, 3);
            meatNumeric.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            meatNumeric.Name = "meatNumeric";
            meatNumeric.Size = new Size(120, 23);
            meatNumeric.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(246, 0);
            label2.Name = "label2";
            label2.Size = new Size(123, 21);
            label2.TabIndex = 2;
            label2.Text = "Current Tokens:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(375, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(501, 0);
            label3.Name = "label3";
            label3.Size = new Size(101, 21);
            label3.TabIndex = 4;
            label3.Text = "Current Box:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(608, 3);
            numericUpDown2.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 5;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(734, 0);
            label4.Name = "label4";
            label4.Size = new Size(143, 21);
            label4.TabIndex = 6;
            label4.Text = "Current honour(s):";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(883, 3);
            numericUpDown3.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 7;
            numericUpDown3.ThousandsSeparator = true;
            // 
            // raidChoicePanel
            // 
            raidChoicePanel.Controls.Add(revivePanel);
            raidChoicePanel.Controls.Add(levelSelectPanel);
            raidChoicePanel.Controls.Add(meatFarmPanel);
            raidChoicePanel.Dock = DockStyle.Top;
            raidChoicePanel.Location = new Point(0, 64);
            raidChoicePanel.Name = "raidChoicePanel";
            raidChoicePanel.Size = new Size(1007, 55);
            raidChoicePanel.TabIndex = 2;
            // 
            // revivePanel
            // 
            revivePanel.BorderStyle = BorderStyle.FixedSingle;
            revivePanel.Controls.Add(reviveTimePanel);
            revivePanel.Controls.Add(reviveNRB);
            revivePanel.Controls.Add(reviveYRB);
            revivePanel.Controls.Add(label7);
            revivePanel.Dock = DockStyle.Left;
            revivePanel.Location = new Point(586, 0);
            revivePanel.Name = "revivePanel";
            revivePanel.Size = new Size(416, 55);
            revivePanel.TabIndex = 3;
            // 
            // reviveTimePanel
            // 
            reviveTimePanel.Controls.Add(label8);
            reviveTimePanel.Controls.Add(numericUpDown6);
            reviveTimePanel.Dock = DockStyle.Bottom;
            reviveTimePanel.Location = new Point(142, 3);
            reviveTimePanel.Name = "reviveTimePanel";
            reviveTimePanel.Size = new Size(272, 50);
            reviveTimePanel.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(0, 3);
            label8.Name = "label8";
            label8.Size = new Size(101, 21);
            label8.TabIndex = 6;
            label8.Text = "Revive Times";
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(123, 3);
            numericUpDown6.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(120, 23);
            numericUpDown6.TabIndex = 7;
            // 
            // reviveNRB
            // 
            reviveNRB.AutoSize = true;
            reviveNRB.Dock = DockStyle.Left;
            reviveNRB.Location = new Point(101, 0);
            reviveNRB.Name = "reviveNRB";
            reviveNRB.Size = new Size(41, 53);
            reviveNRB.TabIndex = 2;
            reviveNRB.TabStop = true;
            reviveNRB.Text = "No";
            reviveNRB.UseVisualStyleBackColor = true;
            // 
            // reviveYRB
            // 
            reviveYRB.AutoSize = true;
            reviveYRB.Dock = DockStyle.Left;
            reviveYRB.Location = new Point(59, 0);
            reviveYRB.Name = "reviveYRB";
            reviveYRB.Size = new Size(42, 53);
            reviveYRB.TabIndex = 1;
            reviveYRB.TabStop = true;
            reviveYRB.Text = "Yes";
            reviveYRB.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(59, 21);
            label7.TabIndex = 0;
            label7.Text = "Revive:";
            // 
            // levelSelectPanel
            // 
            levelSelectPanel.Controls.Add(checkBox1);
            levelSelectPanel.Controls.Add(checkBox2);
            levelSelectPanel.Controls.Add(checkBox3);
            levelSelectPanel.Controls.Add(checkBox4);
            levelSelectPanel.Controls.Add(level5CB);
            levelSelectPanel.Dock = DockStyle.Left;
            levelSelectPanel.Location = new Point(223, 0);
            levelSelectPanel.Name = "levelSelectPanel";
            levelSelectPanel.Size = new Size(363, 55);
            levelSelectPanel.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(61, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Tag = "NM90";
            checkBox1.Text = "NM 90";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += LoadPanels;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(70, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(61, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Tag = "NM95";
            checkBox2.Text = "NM 95";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += LoadPanels;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(137, 3);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(67, 19);
            checkBox3.TabIndex = 2;
            checkBox3.Tag = "NM100";
            checkBox3.Text = "NM 100";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += LoadPanels;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(210, 3);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(67, 19);
            checkBox4.TabIndex = 3;
            checkBox4.Tag = "NM150";
            checkBox4.Text = "NM 150";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += LoadPanels;
            // 
            // level5CB
            // 
            level5CB.AutoSize = true;
            level5CB.Location = new Point(283, 3);
            level5CB.Name = "level5CB";
            level5CB.Size = new Size(67, 19);
            level5CB.TabIndex = 4;
            level5CB.Tag = "NM200";
            level5CB.Text = "NM 200";
            level5CB.UseVisualStyleBackColor = true;
            level5CB.CheckedChanged += LoadPanels;
            // 
            // meatFarmPanel
            // 
            meatFarmPanel.Controls.Add(panel1);
            meatFarmPanel.Dock = DockStyle.Left;
            meatFarmPanel.Location = new Point(0, 0);
            meatFarmPanel.Name = "meatFarmPanel";
            meatFarmPanel.Size = new Size(223, 55);
            meatFarmPanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(exPOtpnRB);
            panel1.Controls.Add(exOtpnRB);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(67, 55);
            panel1.TabIndex = 0;
            // 
            // exPOtpnRB
            // 
            exPOtpnRB.AutoSize = true;
            exPOtpnRB.Checked = true;
            exPOtpnRB.Dock = DockStyle.Top;
            exPOtpnRB.Location = new Point(0, 19);
            exPOtpnRB.Name = "exPOtpnRB";
            exPOtpnRB.Size = new Size(67, 19);
            exPOtpnRB.TabIndex = 3;
            exPOtpnRB.TabStop = true;
            exPOtpnRB.Text = "EX+";
            exPOtpnRB.UseVisualStyleBackColor = true;
            exPOtpnRB.CheckedChanged += exPOtpnRB_CheckedChanged;
            // 
            // exOtpnRB
            // 
            exOtpnRB.AutoSize = true;
            exOtpnRB.Dock = DockStyle.Top;
            exOtpnRB.Location = new Point(0, 0);
            exOtpnRB.Name = "exOtpnRB";
            exOtpnRB.Size = new Size(67, 19);
            exOtpnRB.TabIndex = 2;
            exOtpnRB.Text = "EX";
            exOtpnRB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 119);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1007, 0);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // GWCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(raidChoicePanel);
            Controls.Add(optionsPanel);
            Name = "GWCalculator";
            Size = new Size(1007, 539);
            optionsPanel.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)meatNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            raidChoicePanel.ResumeLayout(false);
            revivePanel.ResumeLayout(false);
            revivePanel.PerformLayout();
            reviveTimePanel.ResumeLayout(false);
            reviveTimePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            levelSelectPanel.ResumeLayout(false);
            levelSelectPanel.PerformLayout();
            meatFarmPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel optionsPanel;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label5;
        private NumericUpDown numericUpDown4;
        private Label label6;
        private NumericUpDown numericUpDown5;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private NumericUpDown meatNumeric;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private NumericUpDown numericUpDown2;
        private Label label4;
        private NumericUpDown numericUpDown3;
        private Panel raidChoicePanel;
        private Panel revivePanel;
        private Panel reviveTimePanel;
        private Label label8;
        private NumericUpDown numericUpDown6;
        private RadioButton reviveNRB;
        private RadioButton reviveYRB;
        private Label label7;
        private FlowLayoutPanel levelSelectPanel;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox level5CB;
        private Panel meatFarmPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private RadioButton exPOtpnRB;
        private RadioButton exOtpnRB;
    }
}
