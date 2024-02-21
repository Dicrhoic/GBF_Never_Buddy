namespace GBF_Never_Buddy.Forms
{
    partial class ItemDropLog
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
            panel5 = new Panel();
            label1 = new Label();
            subRB = new RadioButton();
            addRB = new RadioButton();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            raidImage = new PictureBox();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)raidImage).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(comboBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(760, 55);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(label1);
            panel5.Controls.Add(subRB);
            panel5.Controls.Add(addRB);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(760, 26);
            panel5.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Location = new Point(722, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // subRB
            // 
            subRB.AutoSize = true;
            subRB.Dock = DockStyle.Left;
            subRB.Location = new Point(33, 0);
            subRB.Name = "subRB";
            subRB.Size = new Size(30, 26);
            subRB.TabIndex = 1;
            subRB.TabStop = true;
            subRB.Text = "-";
            subRB.UseVisualStyleBackColor = true;
            // 
            // addRB
            // 
            addRB.AutoSize = true;
            addRB.Checked = true;
            addRB.Dock = DockStyle.Left;
            addRB.Location = new Point(0, 0);
            addRB.Name = "addRB";
            addRB.Size = new Size(33, 26);
            addRB.TabIndex = 0;
            addRB.TabStop = true;
            addRB.Text = "+";
            addRB.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Bottom;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(0, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(760, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += UpdateOption;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(760, 395);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 137);
            panel4.Name = "panel4";
            panel4.Size = new Size(760, 258);
            panel4.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(raidImage);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(760, 137);
            panel3.TabIndex = 0;
            // 
            // raidImage
            // 
            raidImage.Dock = DockStyle.Fill;
            raidImage.Location = new Point(0, 0);
            raidImage.Name = "raidImage";
            raidImage.Size = new Size(760, 137);
            raidImage.SizeMode = PictureBoxSizeMode.CenterImage;
            raidImage.TabIndex = 0;
            raidImage.TabStop = false;
            // 
            // ItemDropLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ItemDropLog";
            Text = "Raid Log";
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)raidImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox raidImage;
        private Panel panel4;
        private Panel panel5;
        private RadioButton addRB;
        private RadioButton subRB;
        private Label label1;
    }
}