﻿namespace CatlabuhApp.UI.Main.Views
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.yearsBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recalculate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.saltBalancePage = new System.Windows.Forms.TabPage();
            this.waterBalancePage = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.createNewCalculation = new System.Windows.Forms.ToolStripButton();
            this.exportToExcel = new System.Windows.Forms.ToolStripButton();
            this.showGatewaySchedule = new System.Windows.Forms.ToolStripButton();
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
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.sbpGrid);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
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
            this.sbpGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.sbcGrid);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
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
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.wbpGrid);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
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
            this.wbpGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.wbcGrid);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
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
            this.showGatewaySchedule});
            this.toolStrip.Name = "toolStrip";
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
            // contextMenuStrip
            // 
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recalculate,
            this.toolStripSeparator3,
            this.save,
            this.delete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            // 
            // recalculate
            // 
            resources.ApplyResources(this.recalculate, "recalculate");
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
            this.save.Name = "save";
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // delete
            // 
            resources.ApplyResources(this.delete, "delete");
            this.delete.Name = "delete";
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // saltBalancePage
            // 
            resources.ApplyResources(this.saltBalancePage, "saltBalancePage");
            this.saltBalancePage.Controls.Add(this.splitContainer2);
            this.saltBalancePage.Name = "saltBalancePage";
            this.saltBalancePage.UseVisualStyleBackColor = true;
            // 
            // waterBalancePage
            // 
            resources.ApplyResources(this.waterBalancePage, "waterBalancePage");
            this.waterBalancePage.Controls.Add(this.splitContainer1);
            this.waterBalancePage.Name = "waterBalancePage";
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
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // createNewCalculation
            // 
            resources.ApplyResources(this.createNewCalculation, "createNewCalculation");
            this.createNewCalculation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.createNewCalculation.Name = "createNewCalculation";
            this.createNewCalculation.Click += new System.EventHandler(this.CreateNewCalculation_Click);
            // 
            // exportToExcel
            // 
            resources.ApplyResources(this.exportToExcel, "exportToExcel");
            this.exportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportToExcel.Name = "exportToExcel";
            this.exportToExcel.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // showGatewaySchedule
            // 
            resources.ApplyResources(this.showGatewaySchedule, "showGatewaySchedule");
            this.showGatewaySchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showGatewaySchedule.Name = "showGatewaySchedule";
            this.showGatewaySchedule.Click += new System.EventHandler(this.ShowGatewaySchedule_Click);
            // 
            // CalculationView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Name = "CalculationView";
            this.SizeChanged += new System.EventHandler(this.CalculationView_SizeChanged);
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
    }
}
