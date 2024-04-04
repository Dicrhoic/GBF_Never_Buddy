namespace GBF_Never_Buddy.Forms.GachaFroms
{
    partial class GachaDataDisplay
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            numericUpDown1 = new NumericUpDown();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.1623487F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.8376541F));
            tableLayoutPanel1.Controls.Add(panel3, 1, 2);
            tableLayoutPanel1.Controls.Add(panel2, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 44.2622948F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 55.7377052F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(579, 167);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(numericUpDown1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(85, 83);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 4, 0, 0);
            panel3.Size = new Size(491, 40);
            panel3.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Left;
            numericUpDown1.Location = new Point(0, 4);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(263, 23);
            numericUpDown1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(85, 38);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 4, 0, 0);
            panel2.Size = new Size(491, 39);
            panel2.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Left;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(0, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(263, 23);
            comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Location = new Point(45, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 10, 0, 0);
            label1.Size = new Size(34, 35);
            label1.TabIndex = 0;
            label1.Text = "Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Right;
            label2.Location = new Point(15, 35);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 15, 0, 0);
            label2.Size = new Size(64, 45);
            label2.TabIndex = 1;
            label2.Text = "Draw Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Right;
            label3.Location = new Point(9, 80);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 15, 0, 0);
            label3.Size = new Size(70, 46);
            label3.TabIndex = 2;
            label3.Text = "Total Draws:";
            // 
            // panel1
            // 
            panel1.Controls.Add(dateTimePicker1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(85, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 4, 0, 0);
            panel1.Size = new Size(491, 29);
            panel1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Dock = DockStyle.Left;
            dateTimePicker1.Location = new Point(0, 4);
            dateTimePicker1.MaxDate = new DateTime(2040, 12, 31, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2016, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(263, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // GachaDataDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "GachaDataDisplay";
            Size = new Size(579, 167);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
    }
}
