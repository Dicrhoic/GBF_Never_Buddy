namespace GBF_Never_Buddy
{
    partial class ProgressBar
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.caption = new System.Windows.Forms.Label();
            this.progressPercentageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(74, 84);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1159, 42);
            this.progressBar1.TabIndex = 3;
            // 
            // caption
            // 
            this.caption.AutoSize = true;
            this.caption.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.caption.Location = new System.Drawing.Point(74, 35);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(66, 30);
            this.caption.TabIndex = 4;
            this.caption.Text = "lorem";
            // 
            // progressPercentageLabel
            // 
            this.progressPercentageLabel.AutoSize = true;
            this.progressPercentageLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progressPercentageLabel.Location = new System.Drawing.Point(1267, 86);
            this.progressPercentageLabel.Name = "progressPercentageLabel";
            this.progressPercentageLabel.Size = new System.Drawing.Size(77, 40);
            this.progressPercentageLabel.TabIndex = 5;
            this.progressPercentageLabel.Text = "---%";
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 183);
            this.ControlBox = false;
            this.Controls.Add(this.progressPercentageLabel);
            this.Controls.Add(this.caption);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private Label caption;
        public Label progressPercentageLabel;
    }
}