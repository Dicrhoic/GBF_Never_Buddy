namespace GBF_Never_Buddy.Forms
{
    partial class GachaCharacterCollection
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
            checkBox7 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox7);
            panel1.Controls.Add(checkBox6);
            panel1.Controls.Add(checkBox5);
            panel1.Controls.Add(checkBox4);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 30);
            panel1.TabIndex = 0;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Dock = DockStyle.Left;
            checkBox7.Location = new Point(528, 0);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(67, 30);
            checkBox7.TabIndex = 6;
            checkBox7.Text = "Holiday";
            checkBox7.UseVisualStyleBackColor = true;
            checkBox7.CheckedChanged += UpdateFilters;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Dock = DockStyle.Left;
            checkBox6.Location = new Point(446, 0);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(82, 30);
            checkBox6.TabIndex = 5;
            checkBox6.Text = "Halloween";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += UpdateFilters;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Dock = DockStyle.Left;
            checkBox5.Location = new Point(334, 0);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(112, 30);
            checkBox5.TabIndex = 4;
            checkBox5.Text = "Summer/Yukata";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += UpdateFilters;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Dock = DockStyle.Left;
            checkBox4.Location = new Point(260, 0);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(74, 30);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "Valentine";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += UpdateFilters;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Dock = DockStyle.Left;
            checkBox3.Location = new Point(174, 0);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(86, 30);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "12 Generals";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += UpdateFilters;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Dock = DockStyle.Left;
            checkBox2.Location = new Point(116, 0);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(58, 30);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Grand";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += UpdateFilters;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Dock = DockStyle.Left;
            checkBox1.Location = new Point(0, 0);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(116, 30);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Premium/Classic";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += UpdateFilters;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 100);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 130);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 100);
            panel3.TabIndex = 3;
            // 
            // GachaCharacterCollection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimizeBox = false;
            Name = "GachaCharacterCollection";
            Text = "GachaCharacterCollection";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Panel panel2;
        private Panel panel3;
    }
}