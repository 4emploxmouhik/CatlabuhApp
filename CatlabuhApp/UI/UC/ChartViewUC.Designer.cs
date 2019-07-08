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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(8D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(14D, 54D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(21D, 4D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(31D, 18D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(37D, 70D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gridToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.axisToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.xAxisNameBox = new System.Windows.Forms.ToolStripTextBox();
            this.yAxisNameBox = new System.Windows.Forms.ToolStripTextBox();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.createNewChart = new System.Windows.Forms.ToolStripButton();
            this.exportToExcel = new System.Windows.Forms.ToolStripButton();
            this.saveAsImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openInSeparateWindow = new System.Windows.Forms.ToolStripButton();
            this.chartToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.chartTypeBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.gridToolStrip.SuspendLayout();
            this.axisToolStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.chartToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            resources.ApplyResources(this.toolStripContainer, "toolStripContainer");
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer.BottomToolStripPanel, "toolStripContainer.BottomToolStripPanel");
            this.toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer.ContentPanel, "toolStripContainer.ContentPanel");
            this.toolStripContainer.ContentPanel.Controls.Add(this.chart);
            // 
            // toolStripContainer.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer.LeftToolStripPanel, "toolStripContainer.LeftToolStripPanel");
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Name = "toolStripContainer";
            // 
            // toolStripContainer.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer.RightToolStripPanel, "toolStripContainer.RightToolStripPanel");
            this.toolStripContainer.RightToolStripPanelVisible = false;
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer.TopToolStripPanel, "toolStripContainer.TopToolStripPanel");
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.mainToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.axisToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.chartToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.gridToolStrip);
            // 
            // chart
            // 
            resources.ApplyResources(this.chart, "chart");
            chartArea1.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend";
            this.chart.Legends.Add(legend1);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend";
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            this.chart.Series.Add(series1);
            title1.Name = "Title";
            this.chart.Titles.Add(title1);
            // 
            // gridToolStrip
            // 
            resources.ApplyResources(this.gridToolStrip, "gridToolStrip");
            this.gridToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.gridToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.gridToolStrip.Name = "gridToolStrip";
            // 
            // toolStripSplitButton1
            // 
            resources.ApplyResources(this.toolStripSplitButton1, "toolStripSplitButton1");
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.showGrid});
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // showGrid
            // 
            resources.ApplyResources(this.showGrid, "showGrid");
            this.showGrid.Checked = true;
            this.showGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGrid.Name = "showGrid";
            // 
            // axisToolStrip
            // 
            resources.ApplyResources(this.axisToolStrip, "axisToolStrip");
            this.axisToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.axisToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton2});
            this.axisToolStrip.Name = "axisToolStrip";
            // 
            // toolStripSplitButton2
            // 
            resources.ApplyResources(this.toolStripSplitButton2, "toolStripSplitButton2");
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xAxisNameBox,
            this.yAxisNameBox});
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            // 
            // xAxisNameBox
            // 
            resources.ApplyResources(this.xAxisNameBox, "xAxisNameBox");
            this.xAxisNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xAxisNameBox.Name = "xAxisNameBox";
            // 
            // yAxisNameBox
            // 
            resources.ApplyResources(this.yAxisNameBox, "yAxisNameBox");
            this.yAxisNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yAxisNameBox.Name = "yAxisNameBox";
            // 
            // mainToolStrip
            // 
            resources.ApplyResources(this.mainToolStrip, "mainToolStrip");
            this.mainToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewChart,
            this.exportToExcel,
            this.saveAsImage,
            this.toolStripSeparator1,
            this.openInSeparateWindow});
            this.mainToolStrip.Name = "mainToolStrip";
            // 
            // createNewChart
            // 
            resources.ApplyResources(this.createNewChart, "createNewChart");
            this.createNewChart.Image = global::CatlabuhApp.Properties.Resources.create_chart_16x16;
            this.createNewChart.Name = "createNewChart";
            this.createNewChart.Click += new System.EventHandler(this.MainToolItem_Click);
            // 
            // exportToExcel
            // 
            resources.ApplyResources(this.exportToExcel, "exportToExcel");
            this.exportToExcel.Image = global::CatlabuhApp.Properties.Resources.export_to_excel_16x16;
            this.exportToExcel.Name = "exportToExcel";
            this.exportToExcel.Click += new System.EventHandler(this.MainToolItem_Click);
            // 
            // saveAsImage
            // 
            resources.ApplyResources(this.saveAsImage, "saveAsImage");
            this.saveAsImage.Image = global::CatlabuhApp.Properties.Resources.save_as_image_16x16;
            this.saveAsImage.Name = "saveAsImage";
            this.saveAsImage.Click += new System.EventHandler(this.MainToolItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // openInSeparateWindow
            // 
            resources.ApplyResources(this.openInSeparateWindow, "openInSeparateWindow");
            this.openInSeparateWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openInSeparateWindow.Name = "openInSeparateWindow";
            this.openInSeparateWindow.Click += new System.EventHandler(this.MainToolItem_Click);
            // 
            // chartToolStrip
            // 
            resources.ApplyResources(this.chartToolStrip, "chartToolStrip");
            this.chartToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.chartToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton3,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.chartTypeBox,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.toolStripComboBox2});
            this.chartToolStrip.Name = "chartToolStrip";
            // 
            // toolStripSplitButton3
            // 
            resources.ApplyResources(this.toolStripSplitButton3, "toolStripSplitButton3");
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            // 
            // toolStripTextBox1
            // 
            resources.ApplyResources(this.toolStripTextBox1, "toolStripTextBox1");
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // toolStripLabel2
            // 
            resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
            this.toolStripLabel2.Name = "toolStripLabel2";
            // 
            // chartTypeBox
            // 
            resources.ApplyResources(this.chartTypeBox, "chartTypeBox");
            this.chartTypeBox.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("chartTypeBox.AutoCompleteCustomSource"),
            resources.GetString("chartTypeBox.AutoCompleteCustomSource1"),
            resources.GetString("chartTypeBox.AutoCompleteCustomSource2"),
            resources.GetString("chartTypeBox.AutoCompleteCustomSource3"),
            resources.GetString("chartTypeBox.AutoCompleteCustomSource4"),
            resources.GetString("chartTypeBox.AutoCompleteCustomSource5"),
            resources.GetString("chartTypeBox.AutoCompleteCustomSource6"),
            resources.GetString("chartTypeBox.AutoCompleteCustomSource7")});
            this.chartTypeBox.Name = "chartTypeBox";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripLabel4
            // 
            resources.ApplyResources(this.toolStripLabel4, "toolStripLabel4");
            this.toolStripLabel4.Name = "toolStripLabel4";
            // 
            // toolStripComboBox2
            // 
            resources.ApplyResources(this.toolStripComboBox2, "toolStripComboBox2");
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            // 
            // ChartViewUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.toolStripContainer);
            this.Name = "ChartViewUC";
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.gridToolStrip.ResumeLayout(false);
            this.gridToolStrip.PerformLayout();
            this.axisToolStrip.ResumeLayout(false);
            this.axisToolStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.chartToolStrip.ResumeLayout(false);
            this.chartToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton createNewChart;
        private System.Windows.Forms.ToolStripButton saveAsImage;
        private System.Windows.Forms.ToolStripButton exportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton openInSeparateWindow;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip chartToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox chartTypeBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStrip axisToolStrip;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripTextBox xAxisNameBox;
        private System.Windows.Forms.ToolStripTextBox yAxisNameBox;
        private System.Windows.Forms.ToolStrip gridToolStrip;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showGrid;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
    }
}
