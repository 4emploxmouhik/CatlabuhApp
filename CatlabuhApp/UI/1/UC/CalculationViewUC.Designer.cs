namespace CatlabuhApp.UI.UC
{
    partial class CalculationViewUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculationViewUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.waterBalancePage = new System.Windows.Forms.TabPage();
            this.consumableWBGroup = new System.Windows.Forms.GroupBox();
            this.WBCGrid = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recalculateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profitWBGroup = new System.Windows.Forms.GroupBox();
            this.WBPGrid = new System.Windows.Forms.DataGridView();
            this.saltBalancePage = new System.Windows.Forms.TabPage();
            this.consumableSBGroup = new System.Windows.Forms.GroupBox();
            this.SBCGrid = new System.Windows.Forms.DataGridView();
            this.profitSBGroup = new System.Windows.Forms.GroupBox();
            this.SBPGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.yearsBoxLabel = new System.Windows.Forms.ToolStripLabel();
            this.yearsBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showGatewayShedule = new System.Windows.Forms.ToolStripButton();
            this.exportToExcel = new System.Windows.Forms.ToolStripButton();
            this.tabControl.SuspendLayout();
            this.waterBalancePage.SuspendLayout();
            this.consumableWBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WBCGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.profitWBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WBPGrid)).BeginInit();
            this.saltBalancePage.SuspendLayout();
            this.consumableSBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SBCGrid)).BeginInit();
            this.profitSBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SBPGrid)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.waterBalancePage);
            this.tabControl.Controls.Add(this.saltBalancePage);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // waterBalancePage
            // 
            resources.ApplyResources(this.waterBalancePage, "waterBalancePage");
            this.waterBalancePage.Controls.Add(this.consumableWBGroup);
            this.waterBalancePage.Controls.Add(this.profitWBGroup);
            this.waterBalancePage.Name = "waterBalancePage";
            this.waterBalancePage.UseVisualStyleBackColor = true;
            // 
            // consumableWBGroup
            // 
            resources.ApplyResources(this.consumableWBGroup, "consumableWBGroup");
            this.consumableWBGroup.Controls.Add(this.WBCGrid);
            this.consumableWBGroup.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.consumableWBGroup.Name = "consumableWBGroup";
            this.consumableWBGroup.TabStop = false;
            // 
            // WBCGrid
            // 
            resources.ApplyResources(this.WBCGrid, "WBCGrid");
            this.WBCGrid.AllowUserToAddRows = false;
            this.WBCGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WBCGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.WBCGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WBCGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.WBCGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WBCGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.WBCGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WBCGrid.ContextMenuStrip = this.contextMenu;
            this.WBCGrid.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WBCGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.WBCGrid.Name = "WBCGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WBCGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WBCGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            // 
            // contextMenu
            // 
            resources.ApplyResources(this.contextMenu, "contextMenu");
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recalculateMenuItem,
            this.toolStripSeparator1,
            this.saveMenuItem,
            this.deleteMenuItem});
            this.contextMenu.Name = "contextMenu";
            // 
            // recalculateMenuItem
            // 
            resources.ApplyResources(this.recalculateMenuItem, "recalculateMenuItem");
            this.recalculateMenuItem.Image = global::CatlabuhApp.Properties.Resources.recalculate_16x16;
            this.recalculateMenuItem.Name = "recalculateMenuItem";
            this.recalculateMenuItem.Click += new System.EventHandler(this.RecalculateMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // saveMenuItem
            // 
            resources.ApplyResources(this.saveMenuItem, "saveMenuItem");
            this.saveMenuItem.Image = global::CatlabuhApp.Properties.Resources.save_16x16;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            resources.ApplyResources(this.deleteMenuItem, "deleteMenuItem");
            this.deleteMenuItem.Image = global::CatlabuhApp.Properties.Resources.delete_16x16;
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // profitWBGroup
            // 
            resources.ApplyResources(this.profitWBGroup, "profitWBGroup");
            this.profitWBGroup.Controls.Add(this.WBPGrid);
            this.profitWBGroup.Name = "profitWBGroup";
            this.profitWBGroup.TabStop = false;
            // 
            // WBPGrid
            // 
            resources.ApplyResources(this.WBPGrid, "WBPGrid");
            this.WBPGrid.AllowUserToAddRows = false;
            this.WBPGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WBPGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.WBPGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WBPGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.WBPGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WBPGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.WBPGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WBPGrid.ContextMenuStrip = this.contextMenu;
            this.WBPGrid.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WBPGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.WBPGrid.Name = "WBPGrid";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WBPGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.WBPGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WBPGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            // 
            // saltBalancePage
            // 
            resources.ApplyResources(this.saltBalancePage, "saltBalancePage");
            this.saltBalancePage.Controls.Add(this.consumableSBGroup);
            this.saltBalancePage.Controls.Add(this.profitSBGroup);
            this.saltBalancePage.Name = "saltBalancePage";
            this.saltBalancePage.UseVisualStyleBackColor = true;
            // 
            // consumableSBGroup
            // 
            resources.ApplyResources(this.consumableSBGroup, "consumableSBGroup");
            this.consumableSBGroup.Controls.Add(this.SBCGrid);
            this.consumableSBGroup.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.consumableSBGroup.Name = "consumableSBGroup";
            this.consumableSBGroup.TabStop = false;
            // 
            // SBCGrid
            // 
            resources.ApplyResources(this.SBCGrid, "SBCGrid");
            this.SBCGrid.AllowUserToAddRows = false;
            this.SBCGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SBCGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.SBCGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SBCGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.SBCGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SBCGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.SBCGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SBCGrid.ContextMenuStrip = this.contextMenu;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SBCGrid.DefaultCellStyle = dataGridViewCellStyle13;
            this.SBCGrid.Name = "SBCGrid";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SBCGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SBCGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            // 
            // profitSBGroup
            // 
            resources.ApplyResources(this.profitSBGroup, "profitSBGroup");
            this.profitSBGroup.Controls.Add(this.SBPGrid);
            this.profitSBGroup.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.profitSBGroup.Name = "profitSBGroup";
            this.profitSBGroup.TabStop = false;
            // 
            // SBPGrid
            // 
            resources.ApplyResources(this.SBPGrid, "SBPGrid");
            this.SBPGrid.AllowUserToAddRows = false;
            this.SBPGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SBPGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.SBPGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SBPGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.SBPGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SBPGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.SBPGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SBPGrid.ContextMenuStrip = this.contextMenu;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SBPGrid.DefaultCellStyle = dataGridViewCellStyle18;
            this.SBPGrid.Name = "SBPGrid";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SBPGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SBPGrid.RowsDefaultCellStyle = dataGridViewCellStyle20;
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yearsBoxLabel,
            this.yearsBox,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripLabel2,
            this.toolStripTextBox2,
            this.toolStripLabel3,
            this.toolStripSeparator2,
            this.showGatewayShedule,
            this.exportToExcel});
            this.toolStrip.Name = "toolStrip";
            // 
            // yearsBoxLabel
            // 
            resources.ApplyResources(this.yearsBoxLabel, "yearsBoxLabel");
            this.yearsBoxLabel.Name = "yearsBoxLabel";
            // 
            // yearsBox
            // 
            resources.ApplyResources(this.yearsBox, "yearsBox");
            this.yearsBox.Name = "yearsBox";
            this.yearsBox.SelectedIndexChanged += new System.EventHandler(this.YearsBox_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // toolStripLabel1
            // 
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            this.toolStripLabel1.Name = "toolStripLabel1";
            // 
            // toolStripTextBox1
            // 
            resources.ApplyResources(this.toolStripTextBox1, "toolStripTextBox1");
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            // 
            // toolStripLabel2
            // 
            resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
            this.toolStripLabel2.Name = "toolStripLabel2";
            // 
            // toolStripTextBox2
            // 
            resources.ApplyResources(this.toolStripTextBox2, "toolStripTextBox2");
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.ReadOnly = true;
            // 
            // toolStripLabel3
            // 
            resources.ApplyResources(this.toolStripLabel3, "toolStripLabel3");
            this.toolStripLabel3.Name = "toolStripLabel3";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // showGatewayShedule
            // 
            resources.ApplyResources(this.showGatewayShedule, "showGatewayShedule");
            this.showGatewayShedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showGatewayShedule.Name = "showGatewayShedule";
            this.showGatewayShedule.Click += new System.EventHandler(this.ShowGatewayShedule_Click);
            // 
            // exportToExcel
            // 
            resources.ApplyResources(this.exportToExcel, "exportToExcel");
            this.exportToExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportToExcel.Image = global::CatlabuhApp.Properties.Resources.export_to_excel_32x32;
            this.exportToExcel.Name = "exportToExcel";
            this.exportToExcel.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // CalculationViewUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Name = "CalculationViewUC";
            this.tabControl.ResumeLayout(false);
            this.waterBalancePage.ResumeLayout(false);
            this.consumableWBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WBCGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.profitWBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WBPGrid)).EndInit();
            this.saltBalancePage.ResumeLayout(false);
            this.consumableSBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SBCGrid)).EndInit();
            this.profitSBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SBPGrid)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage waterBalancePage;
        private System.Windows.Forms.TabPage saltBalancePage;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel yearsBoxLabel;
        private System.Windows.Forms.ToolStripComboBox yearsBox;
        private System.Windows.Forms.DataGridView WBPGrid;
        private System.Windows.Forms.GroupBox profitWBGroup;
        private System.Windows.Forms.GroupBox consumableWBGroup;
        private System.Windows.Forms.GroupBox profitSBGroup;
        private System.Windows.Forms.DataGridView SBPGrid;
        private System.Windows.Forms.GroupBox consumableSBGroup;
        private System.Windows.Forms.DataGridView SBCGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recalculateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton exportToExcel;
        private System.Windows.Forms.DataGridView WBCGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton showGatewayShedule;
    }
}
