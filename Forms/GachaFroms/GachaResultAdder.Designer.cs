namespace GBF_Never_Buddy
{
    partial class GachaResultAdder
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
            mainPanel = new Panel();
            summonRB = new RadioButton();
            charRB = new RadioButton();
            resultsPanel = new FlowLayoutPanel();
            doneBtn = new Button();
            searchTB = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(summonRB);
            mainPanel.Controls.Add(charRB);
            mainPanel.Controls.Add(resultsPanel);
            mainPanel.Controls.Add(doneBtn);
            mainPanel.Controls.Add(searchTB);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 1;
            // 
            // summonRB
            // 
            summonRB.AutoSize = true;
            summonRB.Location = new Point(126, 21);
            summonRB.Name = "summonRB";
            summonRB.Size = new Size(74, 19);
            summonRB.TabIndex = 7;
            summonRB.TabStop = true;
            summonRB.Text = "Summon";
            summonRB.UseVisualStyleBackColor = true;
            summonRB.CheckedChanged += ChangeDataSource;
            // 
            // charRB
            // 
            charRB.AutoSize = true;
            charRB.Checked = true;
            charRB.Location = new Point(44, 21);
            charRB.Name = "charRB";
            charRB.Size = new Size(76, 19);
            charRB.TabIndex = 6;
            charRB.TabStop = true;
            charRB.Text = "Character";
            charRB.UseVisualStyleBackColor = true;
            // 
            // resultsPanel
            // 
            resultsPanel.Location = new Point(44, 118);
            resultsPanel.Name = "resultsPanel";
            resultsPanel.Size = new Size(700, 271);
            resultsPanel.TabIndex = 5;
            // 
            // doneBtn
            // 
            doneBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            doneBtn.Location = new Point(305, 412);
            doneBtn.Name = "doneBtn";
            doneBtn.Size = new Size(178, 26);
            doneBtn.TabIndex = 4;
            doneBtn.Text = "Add to results";
            doneBtn.UseVisualStyleBackColor = true;
            doneBtn.Click += AddResults;
            // 
            // searchTB
            // 
            searchTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchTB.Location = new Point(44, 56);
            searchTB.Name = "searchTB";
            searchTB.PlaceholderText = "Enter a character Name here";
            searchTB.Size = new Size(700, 33);
            searchTB.TabIndex = 0;
            searchTB.KeyDown += SearchForDataItem;
            // 
            // GachaResultAdder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPanel);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GachaResultAdder";
            Text = "GachaResultAdder";
            FormClosing += ValidateCount;
            FormClosed += ReturnCount;
            Load += AuthenticateData;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private RadioButton summonRB;
        private RadioButton charRB;
        private FlowLayoutPanel resultsPanel;
        private Button doneBtn;
        private TextBox searchTB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}