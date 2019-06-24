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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.waterBalancePage = new System.Windows.Forms.TabPage();
            this.waterBalanceSplit = new System.Windows.Forms.SplitContainer();
            this.profitWBGroup = new System.Windows.Forms.GroupBox();
            this.waterBalnceProfitGrid = new System.Windows.Forms.DataGridView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recalculateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumableWBGroup = new System.Windows.Forms.GroupBox();
            this.waterBalnceConsumableGrid = new System.Windows.Forms.DataGridView();
            this.saltBalancePage = new System.Windows.Forms.TabPage();
            this.saltBalanceSplit = new System.Windows.Forms.SplitContainer();
            this.profitSBGroup = new System.Windows.Forms.GroupBox();
            this.saltBalanceProfitGrid = new System.Windows.Forms.DataGridView();
            this.consumableSBGroup = new System.Windows.Forms.GroupBox();
            this.saltBalanceConsumableGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.yearsBoxLabel = new System.Windows.Forms.ToolStripLabel();
            this.yearsBox = new System.Windows.Forms.ToolStripComboBox();
            this.tabControl.SuspendLayout();
            this.waterBalancePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterBalanceSplit)).BeginInit();
            this.waterBalanceSplit.Panel1.SuspendLayout();
            this.waterBalanceSplit.Panel2.SuspendLayout();
            this.waterBalanceSplit.SuspendLayout();
            this.profitWBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterBalnceProfitGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.consumableWBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waterBalnceConsumableGrid)).BeginInit();
            this.saltBalancePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saltBalanceSplit)).BeginInit();
            this.saltBalanceSplit.Panel1.SuspendLayout();
            this.saltBalanceSplit.Panel2.SuspendLayout();
            this.saltBalanceSplit.SuspendLayout();
            this.profitSBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saltBalanceProfitGrid)).BeginInit();
            this.consumableSBGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saltBalanceConsumableGrid)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.waterBalancePage);
            this.tabControl.Controls.Add(this.saltBalancePage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(884, 490);
            this.tabControl.TabIndex = 0;
            // 
            // waterBalancePage
            // 
            this.waterBalancePage.Controls.Add(this.waterBalanceSplit);
            this.waterBalancePage.Location = new System.Drawing.Point(4, 22);
            this.waterBalancePage.Name = "waterBalancePage";
            this.waterBalancePage.Padding = new System.Windows.Forms.Padding(3);
            this.waterBalancePage.Size = new System.Drawing.Size(876, 464);
            this.waterBalancePage.TabIndex = 0;
            this.waterBalancePage.Text = "tabPage1";
            this.waterBalancePage.UseVisualStyleBackColor = true;
            // 
            // waterBalanceSplit
            // 
            this.waterBalanceSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waterBalanceSplit.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.waterBalanceSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waterBalanceSplit.Location = new System.Drawing.Point(3, 3);
            this.waterBalanceSplit.Name = "waterBalanceSplit";
            this.waterBalanceSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // waterBalanceSplit.Panel1
            // 
            this.waterBalanceSplit.Panel1.Controls.Add(this.profitWBGroup);
            // 
            // waterBalanceSplit.Panel2
            // 
            this.waterBalanceSplit.Panel2.Controls.Add(this.consumableWBGroup);
            this.waterBalanceSplit.Size = new System.Drawing.Size(870, 458);
            this.waterBalanceSplit.SplitterDistance = 222;
            this.waterBalanceSplit.SplitterWidth = 5;
            this.waterBalanceSplit.TabIndex = 0;
            // 
            // profitWBGroup
            // 
            this.profitWBGroup.Controls.Add(this.waterBalnceProfitGrid);
            this.profitWBGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profitWBGroup.Location = new System.Drawing.Point(0, 0);
            this.profitWBGroup.Name = "profitWBGroup";
            this.profitWBGroup.Size = new System.Drawing.Size(868, 220);
            this.profitWBGroup.TabIndex = 2;
            this.profitWBGroup.TabStop = false;
            this.profitWBGroup.Text = "groupBox1";
            // 
            // waterBalnceProfitGrid
            // 
            this.waterBalnceProfitGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.waterBalnceProfitGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.waterBalnceProfitGrid.ContextMenuStrip = this.contextMenu;
            this.waterBalnceProfitGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waterBalnceProfitGrid.Location = new System.Drawing.Point(3, 16);
            this.waterBalnceProfitGrid.Name = "waterBalnceProfitGrid";
            this.waterBalnceProfitGrid.Size = new System.Drawing.Size(862, 201);
            this.waterBalnceProfitGrid.TabIndex = 1;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recalculateMenuItem,
            this.toolStripSeparator1,
            this.saveMenuItem,
            this.deleteMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(132, 76);
            // 
            // recalculateMenuItem
            // 
            this.recalculateMenuItem.Name = "recalculateMenuItem";
            this.recalculateMenuItem.Size = new System.Drawing.Size(131, 22);
            this.recalculateMenuItem.Text = "recalculate";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(131, 22);
            this.saveMenuItem.Text = "save";
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(131, 22);
            this.deleteMenuItem.Text = "delete";
            // 
            // consumableWBGroup
            // 
            this.consumableWBGroup.Controls.Add(this.waterBalnceConsumableGrid);
            this.consumableWBGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumableWBGroup.Location = new System.Drawing.Point(0, 0);
            this.consumableWBGroup.Name = "consumableWBGroup";
            this.consumableWBGroup.Size = new System.Drawing.Size(868, 229);
            this.consumableWBGroup.TabIndex = 3;
            this.consumableWBGroup.TabStop = false;
            this.consumableWBGroup.Text = "groupBox2";
            // 
            // waterBalnceConsumableGrid
            // 
            this.waterBalnceConsumableGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.waterBalnceConsumableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.waterBalnceConsumableGrid.ContextMenuStrip = this.contextMenu;
            this.waterBalnceConsumableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waterBalnceConsumableGrid.Location = new System.Drawing.Point(3, 16);
            this.waterBalnceConsumableGrid.Name = "waterBalnceConsumableGrid";
            this.waterBalnceConsumableGrid.Size = new System.Drawing.Size(862, 210);
            this.waterBalnceConsumableGrid.TabIndex = 2;
            // 
            // saltBalancePage
            // 
            this.saltBalancePage.Controls.Add(this.saltBalanceSplit);
            this.saltBalancePage.Location = new System.Drawing.Point(4, 22);
            this.saltBalancePage.Name = "saltBalancePage";
            this.saltBalancePage.Padding = new System.Windows.Forms.Padding(3);
            this.saltBalancePage.Size = new System.Drawing.Size(876, 464);
            this.saltBalancePage.TabIndex = 1;
            this.saltBalancePage.Text = "tabPage2";
            this.saltBalancePage.UseVisualStyleBackColor = true;
            // 
            // saltBalanceSplit
            // 
            this.saltBalanceSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saltBalanceSplit.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.saltBalanceSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saltBalanceSplit.Location = new System.Drawing.Point(3, 3);
            this.saltBalanceSplit.Name = "saltBalanceSplit";
            this.saltBalanceSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // saltBalanceSplit.Panel1
            // 
            this.saltBalanceSplit.Panel1.Controls.Add(this.profitSBGroup);
            // 
            // saltBalanceSplit.Panel2
            // 
            this.saltBalanceSplit.Panel2.Controls.Add(this.consumableSBGroup);
            this.saltBalanceSplit.Size = new System.Drawing.Size(870, 458);
            this.saltBalanceSplit.SplitterDistance = 218;
            this.saltBalanceSplit.SplitterWidth = 5;
            this.saltBalanceSplit.TabIndex = 1;
            // 
            // profitSBGroup
            // 
            this.profitSBGroup.Controls.Add(this.saltBalanceProfitGrid);
            this.profitSBGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profitSBGroup.Location = new System.Drawing.Point(0, 0);
            this.profitSBGroup.Name = "profitSBGroup";
            this.profitSBGroup.Size = new System.Drawing.Size(868, 216);
            this.profitSBGroup.TabIndex = 2;
            this.profitSBGroup.TabStop = false;
            this.profitSBGroup.Text = "groupBox1";
            // 
            // saltBalanceProfitGrid
            // 
            this.saltBalanceProfitGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saltBalanceProfitGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saltBalanceProfitGrid.ContextMenuStrip = this.contextMenu;
            this.saltBalanceProfitGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saltBalanceProfitGrid.Location = new System.Drawing.Point(3, 16);
            this.saltBalanceProfitGrid.Name = "saltBalanceProfitGrid";
            this.saltBalanceProfitGrid.Size = new System.Drawing.Size(862, 197);
            this.saltBalanceProfitGrid.TabIndex = 1;
            // 
            // consumableSBGroup
            // 
            this.consumableSBGroup.Controls.Add(this.saltBalanceConsumableGrid);
            this.consumableSBGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consumableSBGroup.Location = new System.Drawing.Point(0, 0);
            this.consumableSBGroup.Name = "consumableSBGroup";
            this.consumableSBGroup.Size = new System.Drawing.Size(868, 233);
            this.consumableSBGroup.TabIndex = 3;
            this.consumableSBGroup.TabStop = false;
            this.consumableSBGroup.Text = "groupBox2";
            // 
            // saltBalanceConsumableGrid
            // 
            this.saltBalanceConsumableGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saltBalanceConsumableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saltBalanceConsumableGrid.ContextMenuStrip = this.contextMenu;
            this.saltBalanceConsumableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saltBalanceConsumableGrid.Location = new System.Drawing.Point(3, 16);
            this.saltBalanceConsumableGrid.Name = "saltBalanceConsumableGrid";
            this.saltBalanceConsumableGrid.Size = new System.Drawing.Size(862, 214);
            this.saltBalanceConsumableGrid.TabIndex = 2;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yearsBoxLabel,
            this.yearsBox});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(884, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // yearsBoxLabel
            // 
            this.yearsBoxLabel.Name = "yearsBoxLabel";
            this.yearsBoxLabel.Size = new System.Drawing.Size(145, 22);
            this.yearsBoxLabel.Text = "choose year of calculation";
            // 
            // yearsBox
            // 
            this.yearsBox.Name = "yearsBox";
            this.yearsBox.Size = new System.Drawing.Size(75, 25);
            // 
            // CalculationViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Name = "CalculationViewUC";
            this.Size = new System.Drawing.Size(884, 515);
            this.tabControl.ResumeLayout(false);
            this.waterBalancePage.ResumeLayout(false);
            this.waterBalanceSplit.Panel1.ResumeLayout(false);
            this.waterBalanceSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waterBalanceSplit)).EndInit();
            this.waterBalanceSplit.ResumeLayout(false);
            this.profitWBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waterBalnceProfitGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.consumableWBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waterBalnceConsumableGrid)).EndInit();
            this.saltBalancePage.ResumeLayout(false);
            this.saltBalanceSplit.Panel1.ResumeLayout(false);
            this.saltBalanceSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saltBalanceSplit)).EndInit();
            this.saltBalanceSplit.ResumeLayout(false);
            this.profitSBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saltBalanceProfitGrid)).EndInit();
            this.consumableSBGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saltBalanceConsumableGrid)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage waterBalancePage;
        private System.Windows.Forms.SplitContainer waterBalanceSplit;
        private System.Windows.Forms.TabPage saltBalancePage;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel yearsBoxLabel;
        private System.Windows.Forms.ToolStripComboBox yearsBox;
        private System.Windows.Forms.DataGridView waterBalnceProfitGrid;
        private System.Windows.Forms.DataGridView waterBalnceConsumableGrid;
        private System.Windows.Forms.GroupBox profitWBGroup;
        private System.Windows.Forms.GroupBox consumableWBGroup;
        private System.Windows.Forms.SplitContainer saltBalanceSplit;
        private System.Windows.Forms.GroupBox profitSBGroup;
        private System.Windows.Forms.DataGridView saltBalanceProfitGrid;
        private System.Windows.Forms.GroupBox consumableSBGroup;
        private System.Windows.Forms.DataGridView saltBalanceConsumableGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recalculateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
