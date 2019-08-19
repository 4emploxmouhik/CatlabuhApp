namespace CatlabuhApp.UI.Support.Dialogs
{
    partial class TablesToExportDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablesToExportDialog));
            this.wbpCheck = new System.Windows.Forms.CheckBox();
            this.wbcCheck = new System.Windows.Forms.CheckBox();
            this.export = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.wbGroup = new System.Windows.Forms.GroupBox();
            this.sbGroup = new System.Windows.Forms.GroupBox();
            this.sbpCheck = new System.Windows.Forms.CheckBox();
            this.sbcCheck = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.wbGroup.SuspendLayout();
            this.sbGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbpCheck
            // 
            resources.ApplyResources(this.wbpCheck, "wbpCheck");
            this.wbpCheck.Name = "wbpCheck";
            this.wbpCheck.UseVisualStyleBackColor = true;
            this.wbpCheck.CheckedChanged += new System.EventHandler(this.ChoiceTable_CheckedChanged);
            this.wbpCheck.CheckStateChanged += new System.EventHandler(this.ChoiceTable_CheckStateChanged);
            // 
            // wbcCheck
            // 
            resources.ApplyResources(this.wbcCheck, "wbcCheck");
            this.wbcCheck.Name = "wbcCheck";
            this.wbcCheck.UseVisualStyleBackColor = true;
            this.wbcCheck.CheckedChanged += new System.EventHandler(this.ChoiceTable_CheckedChanged);
            this.wbcCheck.CheckStateChanged += new System.EventHandler(this.ChoiceTable_CheckStateChanged);
            // 
            // export
            // 
            resources.ApplyResources(this.export, "export");
            this.export.Name = "export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.Export_Click);
            // 
            // back
            // 
            resources.ApplyResources(this.back, "back");
            this.back.Name = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.Back_Click);
            // 
            // wbGroup
            // 
            this.wbGroup.Controls.Add(this.wbpCheck);
            this.wbGroup.Controls.Add(this.wbcCheck);
            resources.ApplyResources(this.wbGroup, "wbGroup");
            this.wbGroup.Name = "wbGroup";
            this.wbGroup.TabStop = false;
            // 
            // sbGroup
            // 
            this.sbGroup.Controls.Add(this.sbpCheck);
            this.sbGroup.Controls.Add(this.sbcCheck);
            resources.ApplyResources(this.sbGroup, "sbGroup");
            this.sbGroup.Name = "sbGroup";
            this.sbGroup.TabStop = false;
            // 
            // sbpCheck
            // 
            resources.ApplyResources(this.sbpCheck, "sbpCheck");
            this.sbpCheck.Name = "sbpCheck";
            this.sbpCheck.UseVisualStyleBackColor = true;
            this.sbpCheck.CheckedChanged += new System.EventHandler(this.ChoiceTable_CheckedChanged);
            this.sbpCheck.CheckStateChanged += new System.EventHandler(this.ChoiceTable_CheckStateChanged);
            // 
            // sbcCheck
            // 
            resources.ApplyResources(this.sbcCheck, "sbcCheck");
            this.sbcCheck.Name = "sbcCheck";
            this.sbcCheck.UseVisualStyleBackColor = true;
            this.sbcCheck.CheckedChanged += new System.EventHandler(this.ChoiceTable_CheckedChanged);
            this.sbcCheck.CheckStateChanged += new System.EventHandler(this.ChoiceTable_CheckStateChanged);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // TablesToExportDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.sbGroup);
            this.Controls.Add(this.wbGroup);
            this.Controls.Add(this.back);
            this.Controls.Add(this.export);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TablesToExportDialog";
            this.ShowInTaskbar = false;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.TablesToExportDialog_HelpRequested);
            this.wbGroup.ResumeLayout(false);
            this.wbGroup.PerformLayout();
            this.sbGroup.ResumeLayout(false);
            this.sbGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox wbpCheck;
        private System.Windows.Forms.CheckBox wbcCheck;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.GroupBox wbGroup;
        private System.Windows.Forms.GroupBox sbGroup;
        private System.Windows.Forms.CheckBox sbpCheck;
        private System.Windows.Forms.CheckBox sbcCheck;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
    }
}