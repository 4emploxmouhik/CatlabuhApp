namespace CatlabuhApp.UI.Main.Forms
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
            this.homePage = new System.Windows.Forms.ToolStripMenuItem();
            this.calculations = new System.Windows.Forms.ToolStripMenuItem();
            this.charts = new System.Windows.Forms.ToolStripMenuItem();
            this.settings = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homePage,
            this.calculations,
            this.charts,
            this.settings,
            this.helpToolStripMenuItem,
            this.exit});
            this.menuStrip.Name = "menuStrip";
            // 
            // homePage
            // 
            resources.ApplyResources(this.homePage, "homePage");
            this.homePage.Image = global::CatlabuhApp.Properties.Resources.home_16;
            this.homePage.Name = "homePage";
            this.homePage.Click += new System.EventHandler(this.HomePage_Click);
            // 
            // calculations
            // 
            resources.ApplyResources(this.calculations, "calculations");
            this.calculations.Image = global::CatlabuhApp.Properties.Resources.grid_16;
            this.calculations.Name = "calculations";
            this.calculations.Click += new System.EventHandler(this.Calculations_Click);
            // 
            // charts
            // 
            resources.ApplyResources(this.charts, "charts");
            this.charts.Image = global::CatlabuhApp.Properties.Resources.chart_16;
            this.charts.Name = "charts";
            this.charts.Click += new System.EventHandler(this.Charts_Click);
            // 
            // settings
            // 
            resources.ApplyResources(this.settings, "settings");
            this.settings.Image = global::CatlabuhApp.Properties.Resources.settings_16;
            this.settings.Name = "settings";
            this.settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelp,
            this.toolStripSeparator1,
            this.viewAbout});
            this.helpToolStripMenuItem.Image = global::CatlabuhApp.Properties.Resources.books_16;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // viewHelp
            // 
            resources.ApplyResources(this.viewHelp, "viewHelp");
            this.viewHelp.Image = global::CatlabuhApp.Properties.Resources.help_16;
            this.viewHelp.Name = "viewHelp";
            this.viewHelp.Click += new System.EventHandler(this.ViewHelp_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // viewAbout
            // 
            resources.ApplyResources(this.viewAbout, "viewAbout");
            this.viewAbout.Image = global::CatlabuhApp.Properties.Resources.info_16;
            this.viewAbout.Name = "viewAbout";
            this.viewAbout.Click += new System.EventHandler(this.ViewAbout_Click);
            // 
            // exit
            // 
            resources.ApplyResources(this.exit, "exit");
            this.exit.Image = global::CatlabuhApp.Properties.Resources.exit_16;
            this.exit.Name = "exit";
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // contentPanel
            // 
            resources.ApplyResources(this.contentPanel, "contentPanel");
            this.contentPanel.Name = "contentPanel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem homePage;
        private System.Windows.Forms.ToolStripMenuItem settings;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelp;
        private System.Windows.Forms.ToolStripMenuItem viewAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.ToolStripMenuItem calculations;
        private System.Windows.Forms.ToolStripMenuItem charts;
        private System.Windows.Forms.ToolStripMenuItem exit;
    }
}