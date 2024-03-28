namespace GBF_Never_Buddy.Forms
{
    partial class CharacterWishlist
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
            button1 = new Button();
            panel1 = new Panel();
            checkBox7 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            splitContainer1 = new SplitContainer();
            checkedListBox1 = new CheckedListBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(613, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 32);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox7);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(checkBox6);
            panel1.Controls.Add(checkBox5);
            panel1.Controls.Add(checkBox4);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(688, 32);
            panel1.TabIndex = 2;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Dock = DockStyle.Left;
            checkBox7.Location = new Point(528, 0);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(67, 32);
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
            checkBox6.Size = new Size(82, 32);
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
            checkBox5.Size = new Size(112, 32);
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
            checkBox4.Size = new Size(74, 32);
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
            checkBox3.Size = new Size(86, 32);
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
            checkBox2.Size = new Size(58, 32);
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
            checkBox1.Size = new Size(116, 32);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Premium/Classic";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += UpdateFilters;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 32);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(checkedListBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer1.Size = new Size(688, 461);
            splitContainer1.SplitterDistance = 229;
            splitContainer1.TabIndex = 3;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Dock = DockStyle.Top;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(0, 0);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(229, 292);
            checkedListBox1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(240, 141);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 100);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // CharacterWishlist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 493);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "CharacterWishlist";
            Text = "CharacterWishlist";
            FormClosed += DeleteCachedImages;
            Load += CharacterWishlist_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private SplitContainer splitContainer1;
        private CheckedListBox checkedListBox1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}