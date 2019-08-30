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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sbpGrid = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sbcGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wbpGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbcGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.createNewCalculation = new System.Windows.Forms.ToolStripButton();
            this.exportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.yearsBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.waterLevelBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showGatewaySchedule = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recalculate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.saltBalancePage = new System.Windows.Forms.TabPage();
            this.waterBalancePage = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbpGrid)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbpGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbcGrid)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.saltBalancePage.SuspendLayout();
            this.waterBalancePage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            this.toolTip.SetToolTip(this.splitContainer2.Panel1, resources.GetString("splitContainer2.Panel1.ToolTip"));
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.toolTip.SetToolTip(this.splitContainer2.Panel2, resources.GetString("splitContainer2.Panel2.ToolTip"));
            this.toolTip.SetToolTip(this.splitContainer2, resources.GetString("splitContainer2.ToolTip"));
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.sbpGrid);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // sbpGrid
            // 
            resources.ApplyResources(this.sbpGrid, "sbpGrid");
            this.sbpGrid.AllowUserToAddRows = false;
            this.sbpGrid.AllowUserToDeleteRows = false;
            this.sbpGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sbpGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sbpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sbpGrid.Name = "sbpGrid";
            this.sbpGrid.TabStop = false;
            this.toolTip.SetToolTip(this.sbpGrid, resources.GetString("sbpGrid.ToolTip"));
            this.sbpGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.sbcGrid);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // sbcGrid
            // 
            resources.ApplyResources(this.sbcGrid, "sbcGrid");
            this.sbcGrid.AllowUserToAddRows = false;
            this.sbcGrid.AllowUserToDeleteRows = false;
            this.sbcGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sbcGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sbcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sbcGrid.Name = "sbcGrid";
            this.sbcGrid.TabStop = false;
            this.toolTip.SetToolTip(this.sbcGrid, resources.GetString("sbcGrid.ToolTip"));
            this.sbcGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.toolTip.SetToolTip(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.toolTip.SetToolTip(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            this.toolTip.SetToolTip(this.splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.wbpGrid);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // wbpGrid
            // 
            resources.ApplyResources(this.wbpGrid, "wbpGrid");
            this.wbpGrid.AllowUserToAddRows = false;
            this.wbpGrid.AllowUserToDeleteRows = false;
            this.wbpGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.wbpGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wbpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wbpGrid.Name = "wbpGrid";
            this.wbpGrid.TabStop = false;
            this.wbpGrid.Tag = "";
            this.toolTip.SetToolTip(this.wbpGrid, resources.GetString("wbpGrid.ToolTip"));
            this.wbpGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.wbcGrid);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // wbcGrid
            // 
            resources.ApplyResources(this.wbcGrid, "wbcGrid");
            this.wbcGrid.AllowUserToAddRows = false;
            this.wbcGrid.AllowUserToDeleteRows = false;
            this.wbcGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.wbcGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wbcGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wbcGrid.Name = "wbcGrid";
            this.wbcGrid.TabStop = false;
            this.toolTip.SetToolTip(this.wbcGrid, resources.GetString("wbcGrid.ToolTip"));
            this.wbcGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewCalculation,
            this.exportToExcel,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.yearsBox,
            this.toolStripSeparator2,
            this.waterLevelBox,
            this.toolStripSeparator4,
            this.showGatewaySchedule});
            this.toolStrip.Name = "toolStrip";
            this.toolTip.SetToolTip(this.toolStrip, resources.GetString("toolStrip.ToolTip"));
            // 
            // createNewCalculation
            // 
            resources.ApplyResources(this.createNewCalculation, "createNewCalculation");
            this.createNewCalculation.Image = global::CatlabuhApp.Properties.Resources.add_16;
            this.createNewCalculation.Name = "createNewCalculation";
            this.createNewCalculation.Click += new System.EventHandler(this.CreateNewCalculation_Click);
            // 
            // exportToExcel
            // 
            resources.ApplyResources(this.exportToExcel, "exportToExcel");
            this.exportToExcel.Image = global::CatlabuhApp.Properties.Resources.microsoft_excel_16;
            this.exportToExcel.Name = "exportToExcel";
            this.exportToExcel.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripLabel1
            // 
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            this.toolStripLabel1.Name = "toolStripLabel1";
            // 
            // yearsBox
            // 
            resources.ApplyResources(this.yearsBox, "yearsBox");
            this.yearsBox.Name = "yearsBox";
            this.yearsBox.SelectedIndexChanged += new System.EventHandler(this.YearsBox_SelectedIndexChanged);
            this.yearsBox.TextChanged += new System.EventHandler(this.YearsBox_TextChanged);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // waterLevelBox
            // 
            resources.ApplyResources(this.waterLevelBox, "waterLevelBox");
            this.waterLevelBox.Name = "waterLevelBox";
            this.waterLevelBox.ReadOnly = true;
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // showGatewaySchedule
            // 
            resources.ApplyResources(this.showGatewaySchedule, "showGatewaySchedule");
            this.showGatewaySchedule.Image = global::CatlabuhApp.Properties.Resources.open_book_16;
            this.showGatewaySchedule.Name = "showGatewaySchedule";
            this.showGatewaySchedule.Click += new System.EventHandler(this.ShowGatewaySchedule_Click);
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recalculate,
            this.toolStripSeparator3,
            this.save,
            this.delete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.toolTip.SetToolTip(this.contextMenuStrip, resources.GetString("contextMenuStrip.ToolTip"));
            // 
            // recalculate
            // 
            resources.ApplyResources(this.recalculate, "recalculate");
            this.recalculate.Image = global::CatlabuhApp.Properties.Resources.calculator_16;
            this.recalculate.Name = "recalculate";
            this.recalculate.Click += new System.EventHandler(this.Recalculate_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // save
            // 
            resources.ApplyResources(this.save, "save");
            this.save.Image = global::CatlabuhApp.Properties.Resources.save_16;
            this.save.Name = "save";
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // delete
            // 
            resources.ApplyResources(this.delete, "delete");
            this.delete.Image = global::CatlabuhApp.Properties.Resources.delete_16;
            this.delete.Name = "delete";
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // saltBalancePage
            // 
            resources.ApplyResources(this.saltBalancePage, "saltBalancePage");
            this.saltBalancePage.Controls.Add(this.splitContainer2);
            this.saltBalancePage.Name = "saltBalancePage";
            this.toolTip.SetToolTip(this.saltBalancePage, resources.GetString("saltBalancePage.ToolTip"));
            this.saltBalancePage.UseVisualStyleBackColor = true;
            // 
            // waterBalancePage
            // 
            resources.ApplyResources(this.waterBalancePage, "waterBalancePage");
            this.waterBalancePage.Controls.Add(this.splitContainer1);
            this.waterBalancePage.Name = "waterBalancePage";
            this.toolTip.SetToolTip(this.waterBalancePage, resources.GetString("waterBalancePage.ToolTip"));
            this.waterBalancePage.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.ContextMenuStrip = this.contextMenuStrip;
            this.tabControl.Controls.Add(this.waterBalancePage);
            this.tabControl.Controls.Add(this.saltBalancePage);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.toolTip.SetToolTip(this.tabControl, resources.GetString("tabControl.ToolTip"));
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // CalculationView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Name = "CalculationView";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.SizeChanged += new System.EventHandler(this.CalculationView_SizeChanged);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.CalculationView_HelpRequested);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbpGrid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbcGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wbpGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wbcGrid)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.saltBalancePage.ResumeLayout(false);
            this.waterBalancePage.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
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
        private System.Windows.Forms.TabPage saltBalancePage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView sbcGrid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView sbpGrid;
        private System.Windows.Forms.TabPage waterBalancePage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView wbcGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView wbpGrid;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripTextBox waterLevelBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
