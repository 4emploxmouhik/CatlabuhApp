namespace CatlabuhApp.UI.Main.Views
{
    partial class ChartView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartView));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.createNewChart = new System.Windows.Forms.ToolStripDropDownButton();
            this.lineOrBarChart = new System.Windows.Forms.ToolStripMenuItem();
            this.pieChart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.chartStyle = new System.Windows.Forms.ToolStripButton();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewChart,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.chartStyle});
            this.toolStrip.Name = "toolStrip";
            // 
            // createNewChart
            // 
            resources.ApplyResources(this.createNewChart, "createNewChart");
            this.createNewChart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineOrBarChart,
            this.pieChart});
            this.createNewChart.Image = global::CatlabuhApp.Properties.Resources.add_16;
            this.createNewChart.Name = "createNewChart";
            // 
            // lineOrBarChart
            // 
            resources.ApplyResources(this.lineOrBarChart, "lineOrBarChart");
            this.lineOrBarChart.Name = "lineOrBarChart";
            this.lineOrBarChart.Click += new System.EventHandler(this.CreateNewChart_Click);
            // 
            // pieChart
            // 
            resources.ApplyResources(this.pieChart, "pieChart");
            this.pieChart.Name = "pieChart";
            this.pieChart.Click += new System.EventHandler(this.CreateNewPieChart_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripDropDownButton1
            // 
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcel,
            this.saveAsImage});
            this.toolStripDropDownButton1.Image = global::CatlabuhApp.Properties.Resources.toolbox_16;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // exportToExcel
            // 
            resources.ApplyResources(this.exportToExcel, "exportToExcel");
            this.exportToExcel.Image = global::CatlabuhApp.Properties.Resources.microsoft_excel_16;
            this.exportToExcel.Name = "exportToExcel";
            this.exportToExcel.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // saveAsImage
            // 
            resources.ApplyResources(this.saveAsImage, "saveAsImage");
            this.saveAsImage.Image = global::CatlabuhApp.Properties.Resources.picture_16;
            this.saveAsImage.Name = "saveAsImage";
            this.saveAsImage.Click += new System.EventHandler(this.SaveAsImage_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // chartStyle
            // 
            resources.ApplyResources(this.chartStyle, "chartStyle");
            this.chartStyle.Image = global::CatlabuhApp.Properties.Resources.bucket_of_paint_16;
            this.chartStyle.Name = "chartStyle";
            this.chartStyle.Click += new System.EventHandler(this.ChartStyle_Click);
            // 
            // chart
            // 
            resources.ApplyResources(this.chart, "chart");
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend";
            this.chart.Legends.Add(legend1);
            this.chart.Name = "chart";
            title1.Name = "Title";
            this.chart.Titles.Add(title1);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.progressBar});
            this.statusStrip.Name = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // ChartView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.toolStrip);
            this.Name = "ChartView";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ChartView_HelpRequested);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem exportToExcel;
        private System.Windows.Forms.ToolStripMenuItem saveAsImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton chartStyle;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripDropDownButton createNewChart;
        private System.Windows.Forms.ToolStripMenuItem pieChart;
        private System.Windows.Forms.ToolStripMenuItem lineOrBarChart;
    }
}
