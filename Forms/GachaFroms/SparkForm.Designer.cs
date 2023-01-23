namespace GBF_Never_Buddy.GachaForms
{
    partial class SparkForm
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.outputBtn = new System.Windows.Forms.Button();
            this.costLabel = new System.Windows.Forms.Label();
            this.sparkImage = new System.Windows.Forms.PictureBox();
            this.tenDrawBtn = new System.Windows.Forms.Button();
            this.sparkTargetTable = new System.Windows.Forms.TableLayoutPanel();
            this.sparkPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.sparkLabel = new System.Windows.Forms.Label();
            this.resultsTable = new System.Windows.Forms.TableLayoutPanel();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sparkImage)).BeginInit();
            this.sparkTargetTable.SuspendLayout();
            this.sparkPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.Controls.Add(this.label1);
            this.sidePanel.Controls.Add(this.outputBtn);
            this.sidePanel.Controls.Add(this.costLabel);
            this.sidePanel.Controls.Add(this.sparkImage);
            this.sidePanel.Controls.Add(this.tenDrawBtn);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(290, 597);
            this.sidePanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Spark Character:";
            // 
            // outputBtn
            // 
            this.outputBtn.Location = new System.Drawing.Point(12, 517);
            this.outputBtn.Name = "outputBtn";
            this.outputBtn.Size = new System.Drawing.Size(252, 68);
            this.outputBtn.TabIndex = 5;
            this.outputBtn.Text = "Open Results Tab";
            this.outputBtn.UseVisualStyleBackColor = true;
            this.outputBtn.Click += new System.EventHandler(this.OpenResults);
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(3, 170);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(80, 15);
            this.costLabel.TabIndex = 3;
            this.costLabel.Text = "Crystals Used:";
            // 
            // sparkImage
            // 
            this.sparkImage.BackColor = System.Drawing.Color.LightGray;
            this.sparkImage.Location = new System.Drawing.Point(12, 24);
            this.sparkImage.Name = "sparkImage";
            this.sparkImage.Size = new System.Drawing.Size(252, 129);
            this.sparkImage.TabIndex = 2;
            this.sparkImage.TabStop = false;
            this.sparkImage.Click += new System.EventHandler(this.LoadSparkTarget);
            // 
            // tenDrawBtn
            // 
            this.tenDrawBtn.BackColor = System.Drawing.Color.IndianRed;
            this.tenDrawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tenDrawBtn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.tenDrawBtn.Image = global::GBF_Never_Buddy.Properties.Resources.text_stone10;
            this.tenDrawBtn.Location = new System.Drawing.Point(12, 272);
            this.tenDrawBtn.Name = "tenDrawBtn";
            this.tenDrawBtn.Size = new System.Drawing.Size(252, 89);
            this.tenDrawBtn.TabIndex = 0;
            this.tenDrawBtn.UseVisualStyleBackColor = false;
            this.tenDrawBtn.Click += new System.EventHandler(this.LoadDrawForm);
            // 
            // sparkTargetTable
            // 
            this.sparkTargetTable.AutoScroll = true;
            this.sparkTargetTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sparkTargetTable.ColumnCount = 1;
            this.sparkTargetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sparkTargetTable.Controls.Add(this.sparkPanel, 0, 0);
            this.sparkTargetTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.sparkTargetTable.Location = new System.Drawing.Point(290, 0);
            this.sparkTargetTable.Name = "sparkTargetTable";
            this.sparkTargetTable.RowCount = 2;
            this.sparkTargetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sparkTargetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.sparkTargetTable.Size = new System.Drawing.Size(868, 140);
            this.sparkTargetTable.TabIndex = 6;
            // 
            // sparkPanel
            // 
            this.sparkPanel.Controls.Add(this.button1);
            this.sparkPanel.Controls.Add(this.sparkLabel);
            this.sparkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sparkPanel.Location = new System.Drawing.Point(3, 3);
            this.sparkPanel.Name = "sparkPanel";
            this.sparkPanel.Size = new System.Drawing.Size(862, 29);
            this.sparkPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Targets";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.LoadSparkAdder);
            // 
            // sparkLabel
            // 
            this.sparkLabel.AutoSize = true;
            this.sparkLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sparkLabel.Location = new System.Drawing.Point(121, 2);
            this.sparkLabel.Name = "sparkLabel";
            this.sparkLabel.Size = new System.Drawing.Size(77, 21);
            this.sparkLabel.TabIndex = 0;
            this.sparkLabel.Text = "Target(s):";
            // 
            // resultsTable
            // 
            this.resultsTable.AutoScroll = true;
            this.resultsTable.BackColor = System.Drawing.Color.Gainsboro;
            this.resultsTable.ColumnCount = 1;
            this.resultsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTable.Location = new System.Drawing.Point(290, 140);
            this.resultsTable.Name = "resultsTable";
            this.resultsTable.RowCount = 1;
            this.resultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultsTable.Size = new System.Drawing.Size(868, 457);
            this.resultsTable.TabIndex = 7;
            // 
            // SparkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 597);
            this.Controls.Add(this.resultsTable);
            this.Controls.Add(this.sparkTargetTable);
            this.Controls.Add(this.sidePanel);
            this.Name = "SparkForm";
            this.Text = "SparkForm";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sparkImage)).EndInit();
            this.sparkTargetTable.ResumeLayout(false);
            this.sparkPanel.ResumeLayout(false);
            this.sparkPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel sidePanel;
        private Button outputBtn;
        private Label costLabel;
        private PictureBox sparkImage;
        private Button tenDrawBtn;
        private TableLayoutPanel sparkTargetTable;
        private Panel sparkPanel;
        private Label sparkLabel;
        private Button button1;
        private TableLayoutPanel resultsTable;
        private Label label1;
    }
}