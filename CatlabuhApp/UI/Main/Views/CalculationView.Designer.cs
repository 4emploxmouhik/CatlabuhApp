namespace CatlabuhApp.UI.Main.Views
{
    partial class CalculationView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculationView));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.createNewCalculation = new System.Windows.Forms.ToolStripButton();
            this.exportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.yearsBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showGatewaySchedule = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recalculate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.waterBalancePage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbcGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wbpGrid = new System.Windows.Forms.DataGridView();
            this.saltBalancePage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sbcGrid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sbpGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.waterBalancePage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbcGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbpGrid)).BeginInit();
            this.saltBalancePage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbcGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbpGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewCalculation,
            this.exportToExcel,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.yearsBox,
            this.toolStripSeparator2,
            this.showGatewaySchedule});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // createNewCalculation
            // 
            this.createNewCalculation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.createNewCalculation, "createNewCalculation");
            this.createNewCalculation.Name = "createNewCalculation";
            this.createNewCalculation.Click += new System.EventHandler(this.CreateNewCalculation_Click);
            // 
            // exportToExcel
            // 
            this.exportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.exportToExcel, "exportToExcel");
            this.exportToExcel.Name = "exportToExcel";
            this.exportToExcel.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // yearsBox
            // 
            resources.ApplyResources(this.yearsBox, "yearsBox");
            this.yearsBox.Name = "yearsBox";
            this.yearsBox.SelectedIndexChanged += new System.EventHandler(this.YearsBox_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // showGatewaySchedule
            // 
            this.showGatewaySchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.showGatewaySchedule, "showGatewaySchedule");
            this.showGatewaySchedule.Name = "showGatewaySchedule";
            this.showGatewaySchedule.Click += new System.EventHandler(this.ShowGatewaySchedule_Click);
            // 
            // tabControl
            // 
            this.tabControl.ContextMenuStrip = this.contextMenuStrip;
            this.tabControl.Controls.Add(this.waterBalancePage);
            this.tabControl.Controls.Add(this.saltBalancePage);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recalculate,
            this.toolStripSeparator3,
            this.save,
            this.delete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // recalculate
            // 
            this.recalculate.Name = "recalculate";
            resources.ApplyResources(this.recalculate, "recalculate");
            this.recalculate.Click += new System.EventHandler(this.Recalculate_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // save
            // 
            this.save.Name = "save";
            resources.ApplyResources(this.save, "save");
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // delete
            // 
            this.delete.Name = "delete";
            resources.ApplyResources(this.delete, "delete");
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // waterBalancePage
            // 
            this.waterBalancePage.Controls.Add(this.groupBox2);
            this.waterBalancePage.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.waterBalancePage, "waterBalancePage");
            this.waterBalancePage.Name = "waterBalancePage";
            this.waterBalancePage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wbcGrid);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // wbcGrid
            // 
            this.wbcGrid.AllowUserToAddRows = false;
            this.wbcGrid.AllowUserToDeleteRows = false;
            this.wbcGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.wbcGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wbcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.wbcGrid, "wbcGrid");
            this.wbcGrid.Name = "wbcGrid";
            this.wbcGrid.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wbpGrid);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // wbpGrid
            // 
            this.wbpGrid.AllowUserToAddRows = false;
            this.wbpGrid.AllowUserToDeleteRows = false;
            this.wbpGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.wbpGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wbpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.wbpGrid, "wbpGrid");
            this.wbpGrid.Name = "wbpGrid";
            this.wbpGrid.TabStop = false;
            // 
            // saltBalancePage
            // 
            this.saltBalancePage.Controls.Add(this.groupBox4);
            this.saltBalancePage.Controls.Add(this.groupBox3);
            resources.ApplyResources(this.saltBalancePage, "saltBalancePage");
            this.saltBalancePage.Name = "saltBalancePage";
            this.saltBalancePage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sbcGrid);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // sbcGrid
            // 
            this.sbcGrid.AllowUserToAddRows = false;
            this.sbcGrid.AllowUserToDeleteRows = false;
            this.sbcGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sbcGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sbcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.sbcGrid, "sbcGrid");
            this.sbcGrid.Name = "sbcGrid";
            this.sbcGrid.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sbpGrid);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // sbpGrid
            // 
            this.sbpGrid.AllowUserToAddRows = false;
            this.sbpGrid.AllowUserToDeleteRows = false;
            this.sbpGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sbpGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sbpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.sbpGrid, "sbpGrid");
            this.sbpGrid.Name = "sbpGrid";
            this.sbpGrid.TabStop = false;
            // 
            // CalculationView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Name = "CalculationView";
            this.Load += new System.EventHandler(this.CalculationView_Load);
            this.SizeChanged += new System.EventHandler(this.CalculationView_SizeChanged);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.waterBalancePage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wbcGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wbpGrid)).EndInit();
            this.saltBalancePage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbcGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbpGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage waterBalancePage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView wbpGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView wbcGrid;
        private System.Windows.Forms.TabPage saltBalancePage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView sbpGrid;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView sbcGrid;
        private System.Windows.Forms.ToolStripButton createNewCalculation;
        private System.Windows.Forms.ToolStripButton exportToExcel;
        private System.Windows.Forms.ToolStripButton showGatewaySchedule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox yearsBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem recalculate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem delete;
    }
}
