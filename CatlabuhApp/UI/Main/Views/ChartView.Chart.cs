using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace CatlabuhApp.UI.Main.Views
{
    partial class ChartView
    {
        private void FillChart(string[] itemsOfXAxis, string[] itemsOfYAxis, string[] legendItemsNames, Color[] colorsOfYAxisItems, object obj)
        {
            bool isObjABool = false;

            if (obj is bool)
            {
                isObjABool = true;
            }

            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.Maximum = itemsOfXAxis.Length + 1;
            chart.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart.Series.Clear();

            double[] yValues = new double[itemsOfXAxis.Length];
            
            try
            {
                for (int i = 0; i < itemsOfYAxis.Length; i++)
                {
                    for (int j = 0; j < itemsOfXAxis.Length; j++)
                    {
                        if (!isObjABool)
                        {
                            yValues[j] = DataAccess.GetCellData<double>($"SELECT {itemsOfYAxis[i]} FROM OutputData WHERE YearName = {(string)obj} AND " +
                                $"MonthID IN (SELECT MonthID FROM Months WHERE MonthID = '{itemsOfXAxis[j]}');");
                        }
                        else
                        {
                            yValues[j] = DataAccess.GetCellData<double>($"SELECT {itemsOfYAxis[i]} FROM OutputData WHERE MonthID = {((bool)obj ? "14" : "13")} " +
                                $"AND YearName = {itemsOfXAxis[j]}");
                        }
                    }

                    chart.Series.Add(CreateSeries(legendItemsNames[i], colorsOfYAxisItems[i], yValues));
                }

                SetXAxisCustomLabels(isObjABool, itemsOfXAxis);
                SetStartAxisTitleText(obj, isObjABool);
                chart.Update();
            }
            catch (NullReferenceException)
            {
                MessageDialog.Show(MessageDialog.AlertTitle2, MessageDialog.ErrorText6, MessageDialog.Icon.Alert);
            }
        }

        private void SetXAxisCustomLabels(bool isObjABool, string[] itemsOfXAxis)
        {
            string xLabel = "", language = "";

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    language = "EN";
                    break;
                case "uk-UA":
                    language = "UA";
                    break;
                case "ru-RU":
                    language = "RU";
                    break;
            }

            for (double i = 0, from = 0.5, to = 1.5; i < itemsOfXAxis.Length; i++, from++, to++)
            {
                xLabel = isObjABool ? itemsOfXAxis[(int)i] : DataAccess.GetCellData<string>($"SELECT MonthName_{language} FROM Months WHERE MonthID = {itemsOfXAxis[(int)i]}");
                chart.ChartAreas[0].AxisX.CustomLabels.Add(from, to, xLabel);
            }
        }

        private void SetStartAxisTitleText(object obj, bool isObjABool)
        {
            string xAxisTitle1 = "", xAxisTitle2 = "", yAxisTitle = "";

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    xAxisTitle2 = "Years";
                    yAxisTitle = "Million m^3";
                    xAxisTitle1 = "Months of ";
                    break;
                case "uk-UA":
                    xAxisTitle2 = "Роки";
                    yAxisTitle = "Млн. м^3";
                    xAxisTitle1 = "Місяці року ";
                    break;
                case "ru-RU":
                    xAxisTitle2 = "Года";
                    yAxisTitle = "Млн. м^3";
                    xAxisTitle1 = "Месяцы года ";
                    break;
            }

            if (!isObjABool) // months
            {
                chart.ChartAreas[0].AxisX.Title = xAxisTitle1 + (string)obj;
                chart.ChartAreas[0].AxisY.Title = yAxisTitle;
            }
            else // years
            {
                chart.ChartAreas[0].AxisX.Title = xAxisTitle2;
                chart.ChartAreas[0].AxisY.Title = ((bool)obj ? "%" : yAxisTitle);
            }

            csd.SetStartAxisTitles(chart.ChartAreas[0].AxisX.Title, chart.ChartAreas[0].AxisY.Title);
        }

        private Series CreateSeries(string name, Color color, double[] yValues)
        {
            Series series = new Series()
            {
                Name = name,
                Color = color,
                BorderWidth = LineSize,
                ChartType = this.ChartType
            };

            for (int i = 0; i < yValues.Length; i++)
            {
                series.Points.AddXY(i + 1, yValues[i]);
            }

            return series;
        }

    }
}
