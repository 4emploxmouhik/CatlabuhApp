﻿using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Support.Dialogs;
using CatlabuhApp.UI.Support.Setups;
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CatlabuhApp.UI.Main.Views
{
    public partial class ChartView : UserControl
    {
        public IDataAccess DataAccess { get; private set; }

        private SeriesChartType ChartType { get; set; } = SeriesChartType.Line;
        private int LineSize { get; set; } = 2;
        private ChartStyleDialog csd;

        public ChartView()
        {
            Forms.MainForm.GetCultureInfo();
            InitializeComponent();
            csd = new ChartStyleDialog();
        }

        public ChartView(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;
        }

        private void CreateNewChart_Click(object sender, EventArgs e)
        {
            ChartSetup cs = new ChartSetup(DataAccess);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                if (cs.IsChartForMonths)
                {
                    FillChart(cs.ItemsOfXAxis, cs.ItemsOfYAxis, cs.LegendItemsNames, cs.ColorsOfYAxisItems, cs.YearOfCalculation);
                }
                else
                {
                    FillChart(cs.ItemsOfXAxis, cs.ItemsOfYAxis, cs.LegendItemsNames, cs.ColorsOfYAxisItems, cs.IsProcentItems);
                }

                csd.Series = chart.Series;
                csd.SetSeriesGridViewRows();
            }
        }

        private void ChartStyle_Click(object sender, EventArgs e)
        {
            csd.ShowDialog();

            if (csd.DialogResult == DialogResult.OK)
            {
                chart.Titles[0].Text = csd.ChartTitle.Text;
                chart.Titles[0].Font = csd.ChartTitle.Font;
                chart.ChartAreas[0].AxisX.Title = csd.XAxisTitle.Text;
                chart.ChartAreas[0].AxisX.TitleFont = csd.XAxisTitle.Font;
                chart.ChartAreas[0].AxisY.Title = csd.YAxisTitle.Text;
                chart.ChartAreas[0].AxisY.TitleFont = csd.YAxisTitle.Font;

                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = csd.IsShowXAxisMajorGrid;
                chart.ChartAreas[0].AxisX.MinorGrid.Enabled = csd.IsShowXAxisMinorGrid;
                chart.ChartAreas[0].AxisY.MajorGrid.Enabled = csd.IsShowYAxisMajorGrid;
                chart.ChartAreas[0].AxisY.MinorGrid.Enabled = csd.IsShowYAxisMinorGrid;
                chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = csd.XAxisMajorGridLineDashStyle;
                chart.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = csd.XAxisMinorGridLineDashStyle;
                chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = csd.YAxisMajorGridLineDashStyle;
                chart.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = csd.YAxisMinorGridLineDashStyle;

                for (int i = 0; i < chart.Series.Count; i++)
                {
                    chart.Series[i] = csd.Series[i];
                }
            }
        }

        private void SaveAsImage_Click(object sender, EventArgs e)
        {
            if (chart.Titles[0].Text == null || chart.Titles[0].Text.Length == 0)
            {
                chart.SaveImage(Properties.Settings.Default.ChartsImagesDirectoryPath + 
                    $"Chart for {DateTime.Now.ToString().Replace(":", "-")}.png", ChartImageFormat.Png);
            }
            else
            {
                if (File.Exists(Properties.Settings.Default.ChartsImagesDirectoryPath + $"{chart.Titles[0].Text}.png"))
                {
                    MessageDialog md = new MessageDialog(MessageDialog.QuestionTitle, MessageDialog.QuestionText4, MessageDialog.Icon.Question);

                    if (md.DialogResult == DialogResult.Yes)
                    {
                        goto Save;
                    }
                    else
                    {
                        goto Exit;
                    }
                }
                else
                {
                    goto Save;
                }

            Save:
                chart.SaveImage(Properties.Settings.Default.ChartsImagesDirectoryPath + $"{chart.Titles[0].Text}.png", ChartImageFormat.Png);
            Exit:;
            }
        }

        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelAsync();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value != progressBar.Maximum)
            {
                progressBar.Value = progress;
                //progressBar.Update();
            }
            else
            {
                timer.Stop();

                progress = 0;
                progressBar.Value = progress;
                //progressBar.Update();
            }

        }
    }
}