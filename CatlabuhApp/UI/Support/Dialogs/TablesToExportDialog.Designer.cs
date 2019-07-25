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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wbGroup = new System.Windows.Forms.GroupBox();
            this.sbGroup = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.sbpCheck = new System.Windows.Forms.CheckBox();
            this.sbcCheck = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.wbGroup.SuspendLayout();
            this.sbGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CatlabuhApp.Properties.Resources.grid_140x90;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CatlabuhApp.Properties.Resources.grid_140x90;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // wbGroup
            // 
            this.wbGroup.Controls.Add(this.pictureBox2);
            this.wbGroup.Controls.Add(this.wbpCheck);
            this.wbGroup.Controls.Add(this.wbcCheck);
            this.wbGroup.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.wbGroup, "wbGroup");
            this.wbGroup.Name = "wbGroup";
            this.wbGroup.TabStop = false;
            // 
            // sbGroup
            // 
            this.sbGroup.Controls.Add(this.pictureBox3);
            this.sbGroup.Controls.Add(this.sbpCheck);
            this.sbGroup.Controls.Add(this.sbcCheck);
            this.sbGroup.Controls.Add(this.pictureBox4);
            resources.ApplyResources(this.sbGroup, "sbGroup");
            this.sbGroup.Name = "sbGroup";
            this.sbGroup.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CatlabuhApp.Properties.Resources.grid_140x90;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
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
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CatlabuhApp.Properties.Resources.grid_140x90;
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
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
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.TablesToExportDialog_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.wbGroup.ResumeLayout(false);
            this.wbGroup.PerformLayout();
            this.sbGroup.ResumeLayout(false);
            this.sbGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox wbpCheck;
        private System.Windows.Forms.CheckBox wbcCheck;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.GroupBox wbGroup;
        private System.Windows.Forms.GroupBox sbGroup;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox sbpCheck;
        private System.Windows.Forms.CheckBox sbcCheck;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer;
    }
}