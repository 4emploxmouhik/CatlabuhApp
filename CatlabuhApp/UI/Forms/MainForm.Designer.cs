namespace CatlabuhApp.UI.Forms
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.calculationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCalculationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcuationSetupSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewCalculationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelCurrentCalculationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculationsMenuItem,
            this.chartsMenuItem,
            this.settingsMenuItem,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // calculationsMenuItem
            // 
            this.calculationsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCalculationMenuItem,
            this.toolStripSeparator2,
            this.viewCalculationsMenuItem,
            this.exportToExcelCurrentCalculationMenuItem});
            this.calculationsMenuItem.Name = "calculationsMenuItem";
            this.calculationsMenuItem.Size = new System.Drawing.Size(77, 20);
            this.calculationsMenuItem.Text = "calculation";
            // 
            // createCalculationMenuItem
            // 
            this.createCalculationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcuationSetupSettings});
            this.createCalculationMenuItem.Name = "createCalculationMenuItem";
            this.createCalculationMenuItem.Size = new System.Drawing.Size(246, 22);
            this.createCalculationMenuItem.Text = "createCalculation";
            // 
            // calcuationSetupSettings
            // 
            this.calcuationSetupSettings.Name = "calcuationSetupSettings";
            this.calcuationSetupSettings.Size = new System.Drawing.Size(201, 22);
            this.calcuationSetupSettings.Text = "calcuationSetupSettings";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // viewCalculationsMenuItem
            // 
            this.viewCalculationsMenuItem.Name = "viewCalculationsMenuItem";
            this.viewCalculationsMenuItem.Size = new System.Drawing.Size(246, 22);
            this.viewCalculationsMenuItem.Text = "viewCalculations";
            // 
            // exportToExcelCurrentCalculationMenuItem
            // 
            this.exportToExcelCurrentCalculationMenuItem.Name = "exportToExcelCurrentCalculationMenuItem";
            this.exportToExcelCurrentCalculationMenuItem.Size = new System.Drawing.Size(246, 22);
            this.exportToExcelCurrentCalculationMenuItem.Text = "exportToExcelCurrentCalculation";
            // 
            // chartsMenuItem
            // 
            this.chartsMenuItem.Name = "chartsMenuItem";
            this.chartsMenuItem.Size = new System.Drawing.Size(51, 20);
            this.chartsMenuItem.Text = "charts";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(60, 20);
            this.settingsMenuItem.Text = "settings";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpMenuItem,
            this.toolStripSeparator1,
            this.viewAboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(42, 20);
            this.helpMenuItem.Text = "help";
            // 
            // viewHelpMenuItem
            // 
            this.viewHelpMenuItem.Name = "viewHelpMenuItem";
            this.viewHelpMenuItem.Size = new System.Drawing.Size(131, 22);
            this.viewHelpMenuItem.Text = "viewHelp";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
            // 
            // viewAboutMenuItem
            // 
            this.viewAboutMenuItem.Name = "viewAboutMenuItem";
            this.viewAboutMenuItem.Size = new System.Drawing.Size(131, 22);
            this.viewAboutMenuItem.Text = "viewAbout";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(66, 17);
            this.statusLabel.Text = "statusLabel";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 16);
            this.progressBar.Visible = false;
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 24);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(884, 515);
            this.contentPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainFrom";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem chartsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.ToolStripMenuItem calculationsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCalculationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCalculationsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelCurrentCalculationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAboutMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem calcuationSetupSettings;
    }
}