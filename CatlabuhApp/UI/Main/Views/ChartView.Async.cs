using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace CatlabuhApp.UI.Main.Views
{
    // Ошибка на сервере. (Исключение из HRESULT: 0x80010105 (RPC_E_SERVERFAULT))   строка 73, 96
    // Сбой при удаленном вызове процедуры. (Исключение из HRESULT: 0x800706BE)     строка 109

    partial class ChartView
    {
        private int progress = 0;

        private async Task ExportToExcelAsync()
        {
            Cursor = Cursors.WaitCursor;
            statusStrip.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = ((chart.Series.Count * 4) + (chart.Series[0].Points.Count * 4 * chart.Series.Count)) + 13 + chart.Series.Count;
            progressBar.Value = 0;

            timer.Start();

            await Task.Run(() => ExportToExcel());

            MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText8, MessageDialog.Icon.OK);
            Cursor = Cursors.Default;
            statusStrip.Visible = false;
        }

        private void ExportToExcel()
        {
            progress = 0;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.ActiveSheet;

            for (int i = 1; i <= chart.Series.Count; i++)
            {
                xlWorksheet.Cells[i, 1] = chart.Series[i - 1].Name;
                xlWorksheet.Cells[i, 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Cells[i, 1].Borders.Color = Color.Black;
                xlWorksheet.Cells[i, 1].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                progress += 4;

                for (int j = 1; j <= chart.Series[i - 1].Points.Count; j++)
                {
                    xlWorksheet.Cells[i, j + 1] = chart.Series[i - 1].Points[j - 1].YValues[0].ToString().Replace(",", ".");
                    xlWorksheet.Cells[i, j + 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorksheet.Cells[i, j + 1].Borders.Color = Color.Black;
                    xlWorksheet.Cells[i, j + 1].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    progress += 4;
                }
            }

            Excel.Chart xlChart = xlWorkbook.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlChart.Activate();
            xlChart.Select(Type.Missing);
            progress += 3;

            xlChart = SetStyleXlsChart(xlChart);

            try
            {
                if (chart.Titles[0].Text == null || chart.Titles[0].Text.Length == 0)
                {
                    xlWorkbook.SaveAs(Properties.Settings.Default.ChartsExcelFilesDirectoryPath + $"Chart for { DateTime.Now.ToString().Replace(":", "-").Replace("/", ".")}.xlsx");
                }
                else
                {
                    if (File.Exists(Properties.Settings.Default.ChartsExcelFilesDirectoryPath + $"{chart.Titles[0].Text}.xlsx"))
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
                    xlWorkbook.SaveAs(Properties.Settings.Default.ChartsExcelFilesDirectoryPath + $"{chart.Titles[0].Text}.xlsx");

                }
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                MessageDialog.Show(MessageDialog.ErrorTitle, e.Message, MessageDialog.Icon.Cross);
            }

        Exit:
            try
            {
                xlApp.AlertBeforeOverwriting = false;
                xlApp.Visible = true;
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                MessageDialog.Show(MessageDialog.ErrorTitle, e.Message, MessageDialog.Icon.Cross);
                xlApp.Quit();
            }
        }

        private Excel.Chart SetStyleXlsChart(Excel.Chart xlChart)
        {
            Excel.SeriesCollection sc = xlChart.SeriesCollection();
            Excel.Series xlSeries;

            for (int i = 0; i < sc.Count; i++)
            {
                xlSeries = sc.Item(i + 1);
                xlSeries.ChartType = GetSeriesChartType(chart.Series[i]);

                if (chart.Series[i].ChartType == SeriesChartType.Bar || chart.Series[i].ChartType == SeriesChartType.Column)
                {
                    for (int j = 1; j <= chart.Series[i].Points.Count; j++)
                    {
                        xlSeries.Points(j).Interior.Color = ColorTranslator.ToOle(chart.Series[i].Color);
                    }
                }
                else
                {
                    xlSeries.Border.Color = chart.Series[i].Color;
                }

                xlSeries.Border.LineStyle = GetLineDashStyle(chart.Series[i]);
                xlSeries.Border.Weight = chart.Series[i].BorderWidth;
                xlSeries.MarkerStyle = GetSeriesMarkerStyle(chart.Series[i]);
                xlSeries.Name = chart.Series[i].Name;

                progress++;
            }

            if (!string.IsNullOrWhiteSpace(chart.Titles[0].Text))
            {
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = chart.Titles[0].Text;
            }
            else
            {
                xlChart.HasTitle = false;
            }

            progress++;

            xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasTitle = true;
            xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).AxisTitle.Text = chart.ChartAreas[0].AxisX.Title;
            xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasMajorGridlines = chart.ChartAreas[0].AxisX.MajorGrid.Enabled;
            xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasMinorGridlines = chart.ChartAreas[0].AxisX.MinorGrid.Enabled;

            if (xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasMajorGridlines)
            {
                xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).MajorGridlines.Border.LineStyle = GetLineDashStyle(chart.ChartAreas[0].AxisX.MajorGrid);
            }
            if (xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasMinorGridlines)
            {
                xlChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).MinorGridlines.Border.LineStyle = GetLineDashStyle(chart.ChartAreas[0].AxisX.MinorGrid);
            }

            progress += 4;

            xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasTitle = true;
            xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).AxisTitle.Text = chart.ChartAreas[0].AxisY.Title;
            xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasMajorGridlines = chart.ChartAreas[0].AxisY.MajorGrid.Enabled;
            xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasMinorGridlines = chart.ChartAreas[0].AxisY.MinorGrid.Enabled;

            if (xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasMajorGridlines)
            {
                xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).MajorGridlines.Border.LineStyle = GetLineDashStyle(chart.ChartAreas[0].AxisY.MajorGrid);
            }
            if (xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasMinorGridlines)
            {
                xlChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).MinorGridlines.Border.LineStyle = GetLineDashStyle(chart.ChartAreas[0].AxisY.MinorGrid);
            }

            progress += 4;

            xlChart.HasLegend = true;

            progress++;

            return xlChart;
        }

        private Excel.XlLineStyle GetLineDashStyle(object obj)
        {
            switch ((obj is Series) ? ((Series)obj).BorderDashStyle : ((Grid)obj).LineDashStyle)
            {
                case ChartDashStyle.Dash:
                    return Excel.XlLineStyle.xlDash;
                case ChartDashStyle.Dot:
                    return Excel.XlLineStyle.xlDot;
                case ChartDashStyle.DashDot:
                    return Excel.XlLineStyle.xlDashDot;
                case ChartDashStyle.DashDotDot:
                    return Excel.XlLineStyle.xlDashDotDot;
                default:
                    return Excel.XlLineStyle.xlContinuous;
            }
        }

        private Excel.XlMarkerStyle GetSeriesMarkerStyle(Series series)
        {
            switch (series.MarkerStyle)
            {
                case MarkerStyle.Circle:
                    return Excel.XlMarkerStyle.xlMarkerStyleCircle;
                case MarkerStyle.Diamond:
                    return Excel.XlMarkerStyle.xlMarkerStyleDiamond;
                case MarkerStyle.Square:
                    return Excel.XlMarkerStyle.xlMarkerStyleSquare;
                case MarkerStyle.Triangle:
                    return Excel.XlMarkerStyle.xlMarkerStyleTriangle;
                default:
                    return Excel.XlMarkerStyle.xlMarkerStyleNone;
            }
        }

        private Excel.XlChartType GetSeriesChartType(Series series)
        {
            switch (series.ChartType)
            {
                case SeriesChartType.Column:
                    return Excel.XlChartType.xlColumnClustered;
                case SeriesChartType.Bar:
                    return Excel.XlChartType.xlBarClustered;
                default:
                    return Excel.XlChartType.xlLine;
            }
        }
    }
}
