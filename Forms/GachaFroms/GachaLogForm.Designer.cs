namespace GBF_Never_Buddy.GachaForms
{
    partial class GachaLogForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.resultsTable = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(646, 541);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // resultsTable
            // 
            this.resultsTable.AutoScroll = true;
            this.resultsTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.resultsTable.ColumnCount = 1;
            this.resultsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.resultsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsTable.Location = new System.Drawing.Point(646, 0);
            this.resultsTable.Name = "resultsTable";
            this.resultsTable.RowCount = 1;
            this.resultsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.resultsTable.Size = new System.Drawing.Size(714, 541);
            this.resultsTable.TabIndex = 4;
            // 
            // GachaLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 541);
            this.Controls.Add(this.resultsTable);
            this.Controls.Add(this.listView1);
            this.Name = "GachaLogForm";
            this.Text = "GachaLogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private TableLayoutPanel resultsTable;
    }
}