using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using static CatlabuhApp.Data.Models.Calculation;

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

            Font defaultFont = new Font("Times New Roman", 14);

            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(new ChartArea());
            chart.Titles[0].Text = "";
            chart.Legends[0].Title = "";
            chart.Legends[0].Enabled = true;
            chart.Legends[1].Enabled = false;
            chart.Legends[0].Font = new Font("Times New Roman", 10);
            chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = itemsOfXAxis.Length - 1;
            chart.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart.ChartAreas[0].AxisX.LabelStyle.Font = defaultFont;
            chart.ChartAreas[0].AxisY.LabelStyle.Font = defaultFont;
            chart.ChartAreas[0].AxisX.TitleFont = defaultFont;
            chart.ChartAreas[0].AxisY.TitleFont = defaultFont;
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

                    chart.Series.Add(CreateSeries(legendItemsNames[i], colorsOfYAxisItems[i], yValues, itemsOfYAxis[i]));
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

        private void FillPieChart(string yearOfCalculation, PartOfCalculation[] parts, string[] partsNames, Color[][] itemsColors, string[] legendItems, bool isPercentItems)
        {
            string[] itemsOfPieChart = null, prefics = new string[2];
            string language = "";
            int prefIndx = 0;

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    language = "EN";
                    prefics[0] = "million m^3";
                    prefics[1] = "10^6 t.";
                    break;
                case "uk-UA":
                    language = "UA";
                    prefics[0] = "млн м^3";
                    prefics[1] = "10^6 т.";
                    break;
                case "ru-RU":
                    language = "RU";
                    prefics[0] = "млн м^3";
                    prefics[1] = "10^6 т.";
                    break;
            }

            Font font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Bold);
            Color labelColor = Color.Black;
            string legendPartName = "";

            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Titles[0].Text = "";
            chart.Legends[0].Enabled = false;
            chart.Legends[1].Enabled = true;
            chart.Legends[1].Title = "";
            chart.Legends[1].TitleFont = new Font("Times New Roman", 10, FontStyle.Bold);
            chart.Legends[1].CustomItems.Clear();
            chart.Legends[1].Font = new Font("Times New Roman", 10);

            try
            {
                for (int i = 0, legendIndex = 0; i < parts.Length; i++)
                {
                    chart.ChartAreas.Add(new ChartArea());

                    switch (parts[i])
                    {
                        case PartOfCalculation.WaterBalanceProfit:
                            itemsOfPieChart = new string[] { "Vp", "Vr", "Vb", "Vg", "Vdr", "VD_plus", "Voz_plus" };
                            legendIndex = 0;
                            legendPartName = partsNames[0];
                            prefIndx = 0;
                            break;
                        case PartOfCalculation.WaterBalanceConsumable:
                            itemsOfPieChart = new string[] { "VE", "Vtr", "Vf", "Vz", "VD_minus", "Voz_minus" };
                            legendIndex = 7;
                            legendPartName = partsNames[1];
                            prefIndx = 0;
                            break;
                        case PartOfCalculation.SaltBalanceProfit:
                            itemsOfPieChart = new string[] { "Cp", "Cr", "Cb", "Cg", "Cdr", "CD_plus", "Coz_plus" };
                            legendIndex = 13;
                            legendPartName = partsNames[2];
                            prefIndx = 1;
                            break;
                        case PartOfCalculation.SaltBalanceConsumable:
                            itemsOfPieChart = new string[] { "Cf", "Cz", "CD_minus", "Coz_minus" };
                            legendIndex = 20;
                            legendPartName = partsNames[3];
                            prefIndx = 1;
                            break;
                    }

                    Series series = new Series() { ChartType = SeriesChartType.Pie };
                    string tableName = "";
                    double value = 0;

                    chart.Legends[1].CustomItems.Add(new LegendItem() { BorderWidth = 0 });
                    chart.Legends[1].CustomItems.Add(new LegendItem() {
                        Name = legendPartName + (isPercentItems ? "" : ", " + prefics[prefIndx]),
                        BorderWidth = 0,
                        SeparatorType = LegendSeparatorStyle.Line
                    });

                    for (int j = 0; j < itemsOfPieChart.Length; j++, legendIndex++)
                    {
                        if (itemsOfPieChart[j].StartsWith("V") && (itemsOfPieChart[j].Contains("_plus") || itemsOfPieChart[j].Contains("_minus")))
                        {
                            tableName = "GatewaySchedule";
                        }
                        else if (itemsOfPieChart[j].Equals("Vz"))
                        {
                            tableName = "InputData";
                        }
                        else
                        {
                            tableName = "OutputData";
                        }

                        value = DataAccess.GetCellData<double>($"SELECT {itemsOfPieChart[j]} FROM {tableName} WHERE MonthID = {(isPercentItems ? "14" : "13")} AND YearName = {yearOfCalculation}");

                        series.Points.AddY(value);
                        series.Points[j].Label = value.ToString();
                        series.Points[j].LabelForeColor = labelColor;
                        series.Points[j].Font = font;
                        series.Points[j].Color = itemsColors[i][j];

                        LegendItem legendItem = new LegendItem() {
                            Name = legendItems[legendIndex],
                            BorderWidth = 0,
                            Color = series.Points[j].Color,
                            ToolTip = res.GetString($"{itemsOfPieChart[j]}Description_{language}")
                        };
                        chart.Legends[1].CustomItems.Add(legendItem);
                    }

                    series.ChartArea = chart.ChartAreas[i].Name;
                    chart.Series.Add(series);
                }

                chart.Legends[1].Title = GetLegendTitleForPieChart(isPercentItems);
                chart.Update();
            }
            catch (NullReferenceException)
            {
                MessageDialog.Show(MessageDialog.AlertTitle2, MessageDialog.ErrorText6, MessageDialog.Icon.Alert);
            }
        }

        private string GetLegendTitleForPieChart(bool isPercentItems)
        {
            string title = "";

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    title = isPercentItems ? "Percents, %" : "Indicators for the year";
                    break;
                case "uk-UA":
                    title = isPercentItems ? "Відсотки, %" : "Показники за рік";
                    break;
                case "ru-RU":
                    title = isPercentItems ? "Проценты, %" : "Показатели за год";
                    break;
            }

            return title;
        }

        private void SetXAxisCustomLabels(bool isObjABool, string[] itemsOfXAxis)
        {
            string xLabel = "";

            for (double i = 0, from = -0.5, to = 0.5; i < itemsOfXAxis.Length; i++, from++, to++)
            {
                xLabel = isObjABool ? itemsOfXAxis[(int)i] : DataAccess.GetCellData<string>($"SELECT MonthName_{GetCurrentLanguage()} FROM Months WHERE MonthID = {itemsOfXAxis[(int)i]}");
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

            if (!isObjABool)
            {
                chart.ChartAreas[0].AxisX.Title = xAxisTitle1 + (string)obj;
                chart.ChartAreas[0].AxisY.Title = yAxisTitle;
            }
            else
            {
                chart.ChartAreas[0].AxisX.Title = xAxisTitle2;
                chart.ChartAreas[0].AxisY.Title = ((bool)obj ? "%" : yAxisTitle);
            }

            csd.SetStartAxisTitles(chart.ChartAreas[0].AxisX.Title, chart.ChartAreas[0].AxisY.Title);
        }

        private Series CreateSeries(string name, Color color, double[] yValues, string nameInDB)
        {
            Series series = new Series()
            {
                Name = name,
                Color = color,
                BorderWidth = LineSize,
                ChartType = this.ChartType,
                LegendToolTip = res.GetString($"{nameInDB}Description_{GetCurrentLanguage()}")
            };

            for (int i = 0; i < yValues.Length; i++)
            {
                series.Points.AddXY(i, yValues[i]);
            }

            return series;
        }

        private string GetCurrentLanguage()
        {
            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    return "EN";
                case "uk-UA":
                    return "UA";
                case "ru-RU":
                    return "RU";
                default:
                    return null;
            }
        }
    }
}
