namespace CatlabuhApp.UI.UC
{
    partial class ChartViewUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartViewUC));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.createNewChart = new System.Windows.Forms.ToolStripButton();
            this.saveAsImage = new System.Windows.Forms.ToolStripButton();
            this.exportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.chartTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.chartTitileBox = new System.Windows.Forms.ToolStripTextBox();
            this.chartType = new System.Windows.Forms.ToolStripMenuItem();
            this.chartTypesBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.axisNames = new System.Windows.Forms.ToolStripMenuItem();
            this.nameXAxisBox = new System.Windows.Forms.ToolStripTextBox();
            this.nameYAxisBox = new System.Windows.Forms.ToolStripTextBox();
            this.showGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openInSeparateWindow = new System.Windows.Forms.ToolStripButton();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewChart,
            this.saveAsImage,
            this.exportToExcel,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator3,
            this.openInSeparateWindow});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(884, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // createNewChart
            // 
            this.createNewChart.Image = ((System.Drawing.Image)(resources.GetObject("createNewChart.Image")));
            this.createNewChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createNewChart.Name = "createNewChart";
            this.createNewChart.Size = new System.Drawing.Size(112, 22);
            this.createNewChart.Text = "createNewChart";
            // 
            // saveAsImage
            // 
            this.saveAsImage.Image = ((System.Drawing.Image)(resources.GetObject("saveAsImage.Image")));
            this.saveAsImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsImage.Name = "saveAsImage";
            this.saveAsImage.Size = new System.Drawing.Size(96, 22);
            this.saveAsImage.Text = "saveAsImage";
            // 
            // exportToExcel
            // 
            this.exportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("exportToExcel.Image")));
            this.exportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportToExcel.Name = "exportToExcel";
            this.exportToExcel.Size = new System.Drawing.Size(99, 22);
            this.exportToExcel.Text = "exportToExcel";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartTitle,
            this.chartType,
            this.toolStripSeparator2,
            this.axisNames,
            this.showGrid});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(89, 22);
            this.toolStripDropDownButton1.Text = "chartSettings";
            // 
            // chartTitle
            // 
            this.chartTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartTitileBox});
            this.chartTitle.Name = "chartTitle";
            this.chartTitle.Size = new System.Drawing.Size(180, 22);
            this.chartTitle.Text = "chartTitle";
            // 
            // chartTitileBox
            // 
            this.chartTitileBox.Name = "chartTitileBox";
            this.chartTitileBox.Size = new System.Drawing.Size(150, 23);
            this.chartTitileBox.Text = "Title";
            // 
            // chartType
            // 
            this.chartType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartTypesBox});
            this.chartType.Name = "chartType";
            this.chartType.Size = new System.Drawing.Size(180, 22);
            this.chartType.Text = "chartType";
            // 
            // chartTypesBox
            // 
            this.chartTypesBox.Name = "chartTypesBox";
            this.chartTypesBox.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // axisNames
            // 
            this.axisNames.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameXAxisBox,
            this.nameYAxisBox});
            this.axisNames.Name = "axisNames";
            this.axisNames.Size = new System.Drawing.Size(180, 22);
            this.axisNames.Text = "axisNames";
            // 
            // nameXAxisBox
            // 
            this.nameXAxisBox.Name = "nameXAxisBox";
            this.nameXAxisBox.Size = new System.Drawing.Size(150, 23);
            this.nameXAxisBox.Text = "X";
            // 
            // nameYAxisBox
            // 
            this.nameYAxisBox.Name = "nameYAxisBox";
            this.nameYAxisBox.Size = new System.Drawing.Size(150, 23);
            this.nameYAxisBox.Text = "Y";
            // 
            // showGrid
            // 
            this.showGrid.Checked = true;
            this.showGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGrid.Name = "showGrid";
            this.showGrid.Size = new System.Drawing.Size(180, 22);
            this.showGrid.Text = "showGrid";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // openInSeparateWindow
            // 
            this.openInSeparateWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openInSeparateWindow.Image = ((System.Drawing.Image)(resources.GetObject("openInSeparateWindow.Image")));
            this.openInSeparateWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openInSeparateWindow.Name = "openInSeparateWindow";
            this.openInSeparateWindow.Size = new System.Drawing.Size(137, 22);
            this.openInSeparateWindow.Text = "openInSeparateWindow";
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 25);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 3;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(884, 490);
            this.chart.TabIndex = 1;
            // 
            // ChartViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart);
            this.Controls.Add(this.toolStrip);
            this.Name = "ChartViewUC";
            this.Size = new System.Drawing.Size(884, 515);
            this.Load += new System.EventHandler(this.ChartViewUC_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripButton createNewChart;
        private System.Windows.Forms.ToolStripButton saveAsImage;
        private System.Windows.Forms.ToolStripButton exportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem chartTitle;
        private System.Windows.Forms.ToolStripTextBox chartTitileBox;
        private System.Windows.Forms.ToolStripMenuItem chartType;
        private System.Windows.Forms.ToolStripComboBox chartTypesBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem axisNames;
        private System.Windows.Forms.ToolStripTextBox nameXAxisBox;
        private System.Windows.Forms.ToolStripTextBox nameYAxisBox;
        private System.Windows.Forms.ToolStripMenuItem showGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton openInSeparateWindow;
    }
}
