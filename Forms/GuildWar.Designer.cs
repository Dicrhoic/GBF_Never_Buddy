namespace GBF_Never_Buddy.Forms
{
    partial class GuildWar
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
            menuStrip1 = new MenuStrip();
            menuStrip2 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            recordsToolStripMenuItem = new ToolStripMenuItem();
            pastSetupsToolStripMenuItem = new ToolStripMenuItem();
            gWResultsToolStripMenuItem = new ToolStripMenuItem();
            calculatorToolStripMenuItem = new ToolStripMenuItem();
            targetCalculatorToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 24);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1014, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, recordsToolStripMenuItem, calculatorToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1014, 24);
            menuStrip2.TabIndex = 1;
            menuStrip2.Text = "menuStrip2";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(52, 20);
            homeToolStripMenuItem.Text = "Home";
            // 
            // recordsToolStripMenuItem
            // 
            recordsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pastSetupsToolStripMenuItem, gWResultsToolStripMenuItem });
            recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            recordsToolStripMenuItem.Size = new Size(61, 20);
            recordsToolStripMenuItem.Text = "Records";
            // 
            // pastSetupsToolStripMenuItem
            // 
            pastSetupsToolStripMenuItem.Name = "pastSetupsToolStripMenuItem";
            pastSetupsToolStripMenuItem.Size = new Size(180, 22);
            pastSetupsToolStripMenuItem.Text = "Past Setups";
            // 
            // gWResultsToolStripMenuItem
            // 
            gWResultsToolStripMenuItem.Name = "gWResultsToolStripMenuItem";
            gWResultsToolStripMenuItem.Size = new Size(180, 22);
            gWResultsToolStripMenuItem.Text = "GW Results";
            // 
            // calculatorToolStripMenuItem
            // 
            calculatorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { targetCalculatorToolStripMenuItem });
            calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            calculatorToolStripMenuItem.Size = new Size(73, 20);
            calculatorToolStripMenuItem.Text = "Calculator";
            // 
            // targetCalculatorToolStripMenuItem
            // 
            targetCalculatorToolStripMenuItem.Name = "targetCalculatorToolStripMenuItem";
            targetCalculatorToolStripMenuItem.Size = new Size(180, 22);
            targetCalculatorToolStripMenuItem.Text = "Target Calculator";
            // 
            // GuildWar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 504);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip1;
            Name = "GuildWar";
            Text = "GuildWar";
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem recordsToolStripMenuItem;
        private ToolStripMenuItem pastSetupsToolStripMenuItem;
        private ToolStripMenuItem gWResultsToolStripMenuItem;
        private ToolStripMenuItem calculatorToolStripMenuItem;
        private ToolStripMenuItem targetCalculatorToolStripMenuItem;
    }
}