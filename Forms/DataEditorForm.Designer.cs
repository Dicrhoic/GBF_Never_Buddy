namespace GBF_Never_Buddy.Forms
{
    partial class DataEditorForm
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
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            nameBox = new TextBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            imageTB = new TextBox();
            linkTB = new TextBox();
            nameTB = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 38);
            panel1.TabIndex = 2;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Dock = DockStyle.Left;
            radioButton2.Location = new Point(76, 0);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(74, 38);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Summon";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += EditMode;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Dock = DockStyle.Left;
            radioButton1.Location = new Point(0, 0);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(76, 38);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "Character";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += EditMode;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 312);
            panel2.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nameBox);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(imageTB);
            groupBox1.Controls.Add(linkTB);
            groupBox1.Controls.Add(nameTB);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 312);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Edit Data";
            // 
            // nameBox
            // 
            nameBox.Location = new Point(32, 73);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Edit Name";
            nameBox.Size = new Size(731, 23);
            nameBox.TabIndex = 12;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "wind", "fire", "water", "earth", "light", "dark" });
            comboBox2.Location = new Point(32, 105);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(729, 23);
            comboBox2.TabIndex = 11;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Wind", "Fire", "Water", "Earth", "Light", "Dark" });
            comboBox1.Location = new Point(32, 134);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(729, 23);
            comboBox1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(273, 245);
            button1.Name = "button1";
            button1.Size = new Size(207, 42);
            button1.TabIndex = 4;
            button1.Text = "Edit Data";
            button1.UseVisualStyleBackColor = true;
            // 
            // imageTB
            // 
            imageTB.Location = new Point(32, 162);
            imageTB.Name = "imageTB";
            imageTB.PlaceholderText = "Enter Image Link";
            imageTB.Size = new Size(731, 23);
            imageTB.TabIndex = 2;
            // 
            // linkTB
            // 
            linkTB.Location = new Point(32, 191);
            linkTB.Name = "linkTB";
            linkTB.PlaceholderText = "Enter Link";
            linkTB.Size = new Size(731, 23);
            linkTB.TabIndex = 1;
            // 
            // nameTB
            // 
            nameTB.Location = new Point(32, 44);
            nameTB.Name = "nameTB";
            nameTB.PlaceholderText = "Enter Name";
            nameTB.Size = new Size(731, 23);
            nameTB.TabIndex = 0;
            nameTB.TextChanged += ValidateName;
            // 
            // DataEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 312);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "DataEditorForm";
            Text = "DataEditorForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel2;
        private GroupBox groupBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button1;
        private TextBox imageTB;
        private TextBox linkTB;
        private TextBox nameTB;
        private TextBox nameBox;
    }
}