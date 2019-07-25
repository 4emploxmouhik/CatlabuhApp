namespace CatlabuhApp.UI.Forms
{
    partial class ShowChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowChartForm));
            this.chartViewUC = new CatlabuhApp.UI.UC.ChartViewUC();
            this.SuspendLayout();
            // 
            // chartViewUC
            // 
            this.chartViewUC.BackColor = System.Drawing.SystemColors.Control;
            this.chartViewUC.DataAccess = null;
            resources.ApplyResources(this.chartViewUC, "chartViewUC");
            this.chartViewUC.Name = "chartViewUC";
            // 
            // ShowChartForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartViewUC);
            this.Name = "ShowChartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ChartViewUC chartViewUC;
    }
}