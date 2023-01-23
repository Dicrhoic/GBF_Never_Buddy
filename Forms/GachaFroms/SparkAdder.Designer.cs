namespace GBF_Never_Buddy.GachaForms
{
    partial class SparkAdder
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.summonRB = new System.Windows.Forms.RadioButton();
            this.charRB = new System.Windows.Forms.RadioButton();
            this.resultsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.doneBtn = new System.Windows.Forms.Button();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.button1);
            this.mainPanel.Controls.Add(this.summonRB);
            this.mainPanel.Controls.Add(this.charRB);
            this.mainPanel.Controls.Add(this.resultsPanel);
            this.mainPanel.Controls.Add(this.doneBtn);
            this.mainPanel.Controls.Add(this.searchTB);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 2;
            // 
            // summonRB
            // 
            this.summonRB.AutoSize = true;
            this.summonRB.Location = new System.Drawing.Point(126, 21);
            this.summonRB.Name = "summonRB";
            this.summonRB.Size = new System.Drawing.Size(74, 19);
            this.summonRB.TabIndex = 7;
            this.summonRB.TabStop = true;
            this.summonRB.Text = "Summon";
            this.summonRB.UseVisualStyleBackColor = true;
            // 
            // charRB
            // 
            this.charRB.AutoSize = true;
            this.charRB.Checked = true;
            this.charRB.Location = new System.Drawing.Point(44, 21);
            this.charRB.Name = "charRB";
            this.charRB.Size = new System.Drawing.Size(76, 19);
            this.charRB.TabIndex = 6;
            this.charRB.TabStop = true;
            this.charRB.Text = "Character";
            this.charRB.UseVisualStyleBackColor = true;
            this.charRB.CheckedChanged += new System.EventHandler(this.ChangeDataSource);
            // 
            // resultsPanel
            // 
            this.resultsPanel.Location = new System.Drawing.Point(44, 118);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(700, 271);
            this.resultsPanel.TabIndex = 5;
            // 
            // doneBtn
            // 
            this.doneBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.doneBtn.Location = new System.Drawing.Point(126, 395);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(178, 43);
            this.doneBtn.TabIndex = 4;
            this.doneBtn.Text = "Add to Target List";
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.AddResults);
            // 
            // searchTB
            // 
            this.searchTB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchTB.Location = new System.Drawing.Point(44, 56);
            this.searchTB.Name = "searchTB";
            this.searchTB.PlaceholderText = "Enter a character Name here";
            this.searchTB.Size = new System.Drawing.Size(700, 33);
            this.searchTB.TabIndex = 0;
            this.searchTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchForDataItem);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(457, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "Select Spark Character";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SparkBtn);
            // 
            // SparkAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "SparkAdder";
            this.Text = "SparkAdder";
            this.Load += new System.EventHandler(this.AuthenticateData);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel mainPanel;
        private RadioButton summonRB;
        private RadioButton charRB;
        private FlowLayoutPanel resultsPanel;
        private Button doneBtn;
        private TextBox searchTB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button1;
    }
}