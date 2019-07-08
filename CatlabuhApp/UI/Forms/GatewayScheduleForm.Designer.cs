namespace CatlabuhApp.UI.Forms
{
    partial class GatewayScheduleForm
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
            this.gatewaySheduleUC1 = new CatlabuhApp.UI.UC.GatewaySheduleUC();
            this.SuspendLayout();
            // 
            // gatewaySheduleUC1
            // 
            this.gatewaySheduleUC1.Location = new System.Drawing.Point(0, 0);
            this.gatewaySheduleUC1.Name = "gatewaySheduleUC1";
            this.gatewaySheduleUC1.Size = new System.Drawing.Size(429, 712);
            this.gatewaySheduleUC1.TabIndex = 0;
            // 
            // GatewayScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 717);
            this.Controls.Add(this.gatewaySheduleUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GatewayScheduleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GatewayScheduleForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GatewayScheduleForm_FormClosing);
            this.Load += new System.EventHandler(this.GatewayScheduleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC.GatewaySheduleUC gatewaySheduleUC1;
    }
}