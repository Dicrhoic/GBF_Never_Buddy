namespace GBF_Never_Buddy.Screens
{
    partial class RaidRow
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
            label1 = new Label();
            worst = new NumericUpDown();
            best = new NumericUpDown();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            meatCost = new NumericUpDown();
            honoursYield = new NumericUpDown();
            title = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)worst).BeginInit();
            ((System.ComponentModel.ISupportInitialize)best).BeginInit();
            ((System.ComponentModel.ISupportInitialize)meatCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)honoursYield).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(worst);
            panel1.Controls.Add(best);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(meatCost);
            panel1.Controls.Add(honoursYield);
            panel1.Controls.Add(title);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 100);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 24);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 13;
            label1.Text = "Honours Yield:";
            // 
            // worst
            // 
            worst.DecimalPlaces = 1;
            worst.Font = new Font("Segoe UI", 12F);
            worst.Location = new Point(432, 59);
            worst.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            worst.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            worst.Name = "worst";
            worst.Size = new Size(120, 29);
            worst.TabIndex = 11;
            worst.Value = new decimal(new int[] { 1, 0, 0, 0 });
            worst.ValueChanged += worst_ValueChanged;
            // 
            // best
            // 
            best.DecimalPlaces = 1;
            best.Font = new Font("Segoe UI", 12F);
            best.Location = new Point(432, 17);
            best.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            best.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            best.Name = "best";
            best.Size = new Size(120, 29);
            best.TabIndex = 10;
            best.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(278, 24);
            label12.Name = "label12";
            label12.Size = new Size(139, 15);
            label12.TabIndex = 9;
            label12.Text = "Fastest Clear Time(mins):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(278, 66);
            label11.Name = "label11";
            label11.Size = new Size(143, 15);
            label11.TabIndex = 6;
            label11.Text = "Slowest Clear Time(mins):";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(24, 66);
            label10.Name = "label10";
            label10.Size = new Size(64, 15);
            label10.TabIndex = 5;
            label10.Text = "Meat Cost:";
            // 
            // meatCost
            // 
            meatCost.Font = new Font("Segoe UI", 12F);
            meatCost.Location = new Point(186, 59);
            meatCost.Maximum = new decimal(new int[] { 56, 0, 0, 0 });
            meatCost.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            meatCost.Name = "meatCost";
            meatCost.ReadOnly = true;
            meatCost.Size = new Size(56, 29);
            meatCost.TabIndex = 3;
            meatCost.Value = new decimal(new int[] { 1, 0, 0, 0 });
            meatCost.ValueChanged += numericUpDown8_ValueChanged;
            // 
            // honoursYield
            // 
            honoursYield.Font = new Font("Segoe UI", 12F);
            honoursYield.Location = new Point(122, 17);
            honoursYield.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            honoursYield.Minimum = new decimal(new int[] { 80800, 0, 0, 0 });
            honoursYield.Name = "honoursYield";
            honoursYield.ReadOnly = true;
            honoursYield.Size = new Size(120, 29);
            honoursYield.TabIndex = 2;
            honoursYield.Value = new decimal(new int[] { 80800, 0, 0, 0 });
            // 
            // title
            // 
            title.AutoSize = true;
            title.Location = new Point(3, 3);
            title.Name = "title";
            title.Size = new Size(43, 15);
            title.TabIndex = 0;
            title.Text = "EX Test";
            // 
            // RaidRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "RaidRow";
            Size = new Size(571, 104);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)worst).EndInit();
            ((System.ComponentModel.ISupportInitialize)best).EndInit();
            ((System.ComponentModel.ISupportInitialize)meatCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)honoursYield).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private NumericUpDown worst;
        private NumericUpDown best;
        private Label label12;
        private Label label11;
        private Label label10;
        private NumericUpDown meatCost;
        private NumericUpDown honoursYield;
        private Label title;
        private Label label1;
    }
}
