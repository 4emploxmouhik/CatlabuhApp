using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CatlabuhApp.UI.Main.Views
{
    partial class ChartView
    {
        private int progress = 0;

        private async Task ExportToExcelAsync()
        {
            statusStrip.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = ((chart.Series.Count * 4) + (chart.Series[0].Points.Count * 4  * chart.Series.Count)) + 14;
            progressBar.Value = 0;

            timer.Start();

            await Task.Run(() => ExportToExcel());

            statusStrip.Visible = false;
        }

        private void ExportToExcel()
        {
            progress = 0;

            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 1; i <= this.chart.Series.Count; i++)
            {
                worksheet.Cells[i, 1] = this.chart.Series[i - 1].Name;
                worksheet.Cells[i, 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                worksheet.Cells[i, 1].Borders.Color = Color.Black;
                worksheet.Cells[i, 1].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                progress += 4;

                for (int j = 1; j <= this.chart.Series[i - 1].Points.Count; j++)
                {
                    worksheet.Cells[i, j + 1] = this.chart.Series[i - 1].Points[j - 1].YValues[0].ToString().Replace(",", ".");
                    worksheet.Cells[i, j + 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    worksheet.Cells[i, j + 1].Borders.Color = Color.Black;
                    worksheet.Cells[i, j + 1].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    progress += 4;
                }
            }

            Excel.Chart chart = workbook.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            chart.Activate();
            chart.Select(Type.Missing);
            progress += 3;

            chart.ChartType = Excel.XlChartType.xlLine;

            chart.HasTitle = false;
            progress += 2;

            chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasTitle = true;
            chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).AxisTitle
                .Text = this.chart.ChartAreas[0].AxisX.Title;
            progress += 2;

            chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasTitle = true;
            chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).AxisTitle
                .Text = this.chart.ChartAreas[0].AxisY.Title;
            progress += 2;

            chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasMajorGridlines = true;
            progress++;
            chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary).HasMinorGridlines = false;
            progress++;
            chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasMajorGridlines = true;
            progress++;
            chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary).HasMinorGridlines = false;
            progress++;
            chart.HasLegend = true;
            progress++;
            
            if (this.chart.Titles[0].Text == null || this.chart.Titles[0].Text.Length == 0)
            {
                workbook.SaveAs(Properties.Settings.Default.ChartsExcelFilesDirectoryPath +
                    $"Chart for { DateTime.Now.ToString().Replace(":", "-").Replace("/", ".")}.xlsx");
            }
            else
            {
                if (File.Exists(Properties.Settings.Default.ChartsExcelFilesDirectoryPath + $"{this.chart.Titles[0].Text}.xlsx"))
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
                workbook.SaveAs(Properties.Settings.Default.ChartsExcelFilesDirectoryPath + $"{this.chart.Titles[0].Text}.xlsx");
            }
        
        Exit:
            app.AlertBeforeOverwriting = false;
            app.Visible = true;
        }
    }
}
