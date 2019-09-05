namespace CatlabuhApp.UI.Support.Dialogs
{
    partial class RecalculateDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecalculateDialog));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.byDeficit = new System.Windows.Forms.RadioButton();
            this.byData = new System.Windows.Forms.RadioButton();
            this.gsGroupBox = new System.Windows.Forms.GroupBox();
            this.choiceGSCalculation = new System.Windows.Forms.GroupBox();
            this.gsByDates = new System.Windows.Forms.RadioButton();
            this.gsByData = new System.Windows.Forms.RadioButton();
            this.enterGS = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.runCalculate = new System.Windows.Forms.Button();
            this.calculateOnlySB = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.gsGroupBox.SuspendLayout();
            this.choiceGSCalculation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Controls.Add(this.byDeficit);
            this.groupBox6.Controls.Add(this.byData);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // byDeficit
            // 
            resources.ApplyResources(this.byDeficit, "byDeficit");
            this.byDeficit.Name = "byDeficit";
            this.byDeficit.UseVisualStyleBackColor = true;
            // 
            // byData
            // 
            resources.ApplyResources(this.byData, "byData");
            this.byData.Checked = true;
            this.byData.Name = "byData";
            this.byData.TabStop = true;
            this.byData.UseVisualStyleBackColor = true;
            // 
            // gsGroupBox
            // 
            resources.ApplyResources(this.gsGroupBox, "gsGroupBox");
            this.gsGroupBox.Controls.Add(this.choiceGSCalculation);
            this.gsGroupBox.Controls.Add(this.enterGS);
            this.gsGroupBox.Name = "gsGroupBox";
            this.gsGroupBox.TabStop = false;
            // 
            // choiceGSCalculation
            // 
            resources.ApplyResources(this.choiceGSCalculation, "choiceGSCalculation");
            this.choiceGSCalculation.Controls.Add(this.gsByDates);
            this.choiceGSCalculation.Controls.Add(this.gsByData);
            this.choiceGSCalculation.Name = "choiceGSCalculation";
            this.choiceGSCalculation.TabStop = false;
            // 
            // gsByDates
            // 
            resources.ApplyResources(this.gsByDates, "gsByDates");
            this.gsByDates.Name = "gsByDates";
            this.gsByDates.UseVisualStyleBackColor = true;
            // 
            // gsByData
            // 
            resources.ApplyResources(this.gsByData, "gsByData");
            this.gsByData.Checked = true;
            this.gsByData.Name = "gsByData";
            this.gsByData.TabStop = true;
            this.gsByData.UseVisualStyleBackColor = true;
            // 
            // enterGS
            // 
            resources.ApplyResources(this.enterGS, "enterGS");
            this.enterGS.Name = "enterGS";
            this.enterGS.UseVisualStyleBackColor = true;
            this.enterGS.CheckedChanged += new System.EventHandler(this.EnterGS_CheckedChanged);
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // runCalculate
            // 
            resources.ApplyResources(this.runCalculate, "runCalculate");
            this.runCalculate.Name = "runCalculate";
            this.runCalculate.UseVisualStyleBackColor = true;
            this.runCalculate.Click += new System.EventHandler(this.RunCalculate_Click);
            // 
            // calculateOnlySB
            // 
            resources.ApplyResources(this.calculateOnlySB, "calculateOnlySB");
            this.calculateOnlySB.Name = "calculateOnlySB";
            this.calculateOnlySB.UseVisualStyleBackColor = true;
            this.calculateOnlySB.CheckedChanged += new System.EventHandler(this.CalculateOnlySB_CheckedChanged);
            // 
            // RecalculateDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calculateOnlySB);
            this.Controls.Add(this.runCalculate);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.gsGroupBox);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecalculateDialog";
            this.ShowInTaskbar = false;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.RecalculateDialog_HelpRequested);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RecalculateDialog_Paint);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gsGroupBox.ResumeLayout(false);
            this.gsGroupBox.PerformLayout();
            this.choiceGSCalculation.ResumeLayout(false);
            this.choiceGSCalculation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton byDeficit;
        private System.Windows.Forms.RadioButton byData;
        private System.Windows.Forms.GroupBox gsGroupBox;
        private System.Windows.Forms.GroupBox choiceGSCalculation;
        private System.Windows.Forms.RadioButton gsByDates;
        private System.Windows.Forms.RadioButton gsByData;
        private System.Windows.Forms.CheckBox enterGS;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button runCalculate;
        private System.Windows.Forms.CheckBox calculateOnlySB;
    }
}