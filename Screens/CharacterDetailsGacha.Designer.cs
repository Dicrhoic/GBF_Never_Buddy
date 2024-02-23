namespace GBF_Never_Buddy.Screens
{
    partial class CharacterDetailsGacha
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            panel3 = new Panel();
            textBox2 = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(316, 331);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(316, 154);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(316, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 331);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 139);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5, 0, 0, 5);
            panel3.Size = new Size(329, 128);
            panel3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Bottom;
            textBox2.Location = new Point(5, 33);
            textBox2.MaxLength = 500;
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(324, 90);
            textBox2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(5, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 10, 0, 5);
            label4.Size = new Size(38, 30);
            label4.TabIndex = 2;
            label4.Text = "label4";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 79);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5, 0, 0, 0);
            panel2.Size = new Size(329, 60);
            panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Left;
            textBox1.Location = new Point(5, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(317, 23);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(5, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 10, 0, 5);
            label3.Size = new Size(38, 30);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(3, 49);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 10, 0, 5);
            label2.Size = new Size(43, 30);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 10, 0, 5);
            label1.Size = new Size(43, 30);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // CharacterDetailsGacha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Name = "CharacterDetailsGacha";
            Size = new Size(651, 331);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label1;
        private Panel panel2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Panel panel3;
        private TextBox textBox2;
        private Label label4;
    }
}
