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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caluclations = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCalculations = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewCalculation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewCalculationSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.charts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.settings = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.settings,
            this.helpMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // fileMenuItem
            // 
            resources.ApplyResources(this.fileMenuItem, "fileMenuItem");
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caluclations,
            this.charts,
            this.toolStripSeparator3,
            this.exit});
            this.fileMenuItem.Name = "fileMenuItem";
            // 
            // caluclations
            // 
            resources.ApplyResources(this.caluclations, "caluclations");
            this.caluclations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCalculations,
            this.createNewCalculation,
            this.toolStripSeparator2,
            this.viewCalculationSettings});
            this.caluclations.Name = "caluclations";
            // 
            // viewCalculations
            // 
            resources.ApplyResources(this.viewCalculations, "viewCalculations");
            this.viewCalculations.Name = "viewCalculations";
            this.viewCalculations.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // createNewCalculation
            // 
            resources.ApplyResources(this.createNewCalculation, "createNewCalculation");
            this.createNewCalculation.Name = "createNewCalculation";
            this.createNewCalculation.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // viewCalculationSettings
            // 
            resources.ApplyResources(this.viewCalculationSettings, "viewCalculationSettings");
            this.viewCalculationSettings.Name = "viewCalculationSettings";
            this.viewCalculationSettings.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // charts
            // 
            resources.ApplyResources(this.charts, "charts");
            this.charts.Name = "charts";
            this.charts.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // exit
            // 
            resources.ApplyResources(this.exit, "exit");
            this.exit.Name = "exit";
            this.exit.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // settings
            // 
            resources.ApplyResources(this.settings, "settings");
            this.settings.Name = "settings";
            this.settings.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // helpMenuItem
            // 
            resources.ApplyResources(this.helpMenuItem, "helpMenuItem");
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelp,
            this.toolStripSeparator1,
            this.viewAbout});
            this.helpMenuItem.Name = "helpMenuItem";
            // 
            // viewHelp
            // 
            resources.ApplyResources(this.viewHelp, "viewHelp");
            this.viewHelp.Name = "viewHelp";
            this.viewHelp.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // viewAbout
            // 
            resources.ApplyResources(this.viewAbout, "viewAbout");
            this.viewAbout.Name = "viewAbout";
            this.viewAbout.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // contentPanel
            // 
            resources.ApplyResources(this.contentPanel, "contentPanel");
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.Name = "contentPanel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settings;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.ToolStripMenuItem viewHelp;
        private System.Windows.Forms.ToolStripMenuItem viewAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caluclations;
        private System.Windows.Forms.ToolStripMenuItem createNewCalculation;
        private System.Windows.Forms.ToolStripMenuItem viewCalculations;
        private System.Windows.Forms.ToolStripMenuItem charts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem viewCalculationSettings;
    }
}