namespace CatlabuhApp.UI.Main.Views
{
    partial class SettingsView
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.languageBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.callFolderBrowser4 = new System.Windows.Forms.Button();
            this.imgChartsPathBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.callFolderBrowser3 = new System.Windows.Forms.Button();
            this.xlChartsPathBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.callFolderBrowser2 = new System.Windows.Forms.Button();
            this.xlCalcPathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.apply = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.languageBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.callFolderBrowser4);
            this.groupBox1.Controls.Add(this.imgChartsPathBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.callFolderBrowser3);
            this.groupBox1.Controls.Add(this.xlChartsPathBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.callFolderBrowser2);
            this.groupBox1.Controls.Add(this.xlCalcPathBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // languageBox
            // 
            resources.ApplyResources(this.languageBox, "languageBox");
            this.languageBox.FormattingEnabled = true;
            this.languageBox.Items.AddRange(new object[] {
            resources.GetString("languageBox.Items"),
            resources.GetString("languageBox.Items1"),
            resources.GetString("languageBox.Items2")});
            this.languageBox.Name = "languageBox";
            this.languageBox.SelectedIndexChanged += new System.EventHandler(this.LanguageBox_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // callFolderBrowser4
            // 
            resources.ApplyResources(this.callFolderBrowser4, "callFolderBrowser4");
            this.callFolderBrowser4.Name = "callFolderBrowser4";
            this.callFolderBrowser4.Tag = "2";
            this.callFolderBrowser4.UseVisualStyleBackColor = true;
            this.callFolderBrowser4.Click += new System.EventHandler(this.CallFolderBrowser_Click);
            // 
            // imgChartsPathBox
            // 
            resources.ApplyResources(this.imgChartsPathBox, "imgChartsPathBox");
            this.imgChartsPathBox.Name = "imgChartsPathBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // callFolderBrowser3
            // 
            resources.ApplyResources(this.callFolderBrowser3, "callFolderBrowser3");
            this.callFolderBrowser3.Name = "callFolderBrowser3";
            this.callFolderBrowser3.Tag = "1";
            this.callFolderBrowser3.UseVisualStyleBackColor = true;
            this.callFolderBrowser3.Click += new System.EventHandler(this.CallFolderBrowser_Click);
            // 
            // xlChartsPathBox
            // 
            resources.ApplyResources(this.xlChartsPathBox, "xlChartsPathBox");
            this.xlChartsPathBox.Name = "xlChartsPathBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // callFolderBrowser2
            // 
            resources.ApplyResources(this.callFolderBrowser2, "callFolderBrowser2");
            this.callFolderBrowser2.Name = "callFolderBrowser2";
            this.callFolderBrowser2.Tag = "0";
            this.callFolderBrowser2.UseVisualStyleBackColor = true;
            this.callFolderBrowser2.Click += new System.EventHandler(this.CallFolderBrowser_Click);
            // 
            // xlCalcPathBox
            // 
            resources.ApplyResources(this.xlCalcPathBox, "xlCalcPathBox");
            this.xlCalcPathBox.Name = "xlCalcPathBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // apply
            // 
            resources.ApplyResources(this.apply, "apply");
            this.apply.Name = "apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // SettingsView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.apply);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsView";
            this.Load += new System.EventHandler(this.SettingsView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button callFolderBrowser4;
        private System.Windows.Forms.TextBox imgChartsPathBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button callFolderBrowser3;
        private System.Windows.Forms.TextBox xlChartsPathBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button callFolderBrowser2;
        private System.Windows.Forms.TextBox xlCalcPathBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ComboBox languageBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
