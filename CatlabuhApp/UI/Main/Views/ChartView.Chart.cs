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

            for (int i = 0; i < itemsOfYAxis.Length; i++)
            {
                for (int j = 0; j < itemsOfXAxis.Length; j++)
                {
                    if (!isObjABool)
                    {
                        yValues[j] = DataAccess.GetCellData<double>($"SELECT {itemsOfYAxis[i]} FROM OutputData WHERE YearName = {(string)obj} AND " +
                            $"MonthID IN (SELECT MonthID FROM Months WHERE MonthName = '{itemsOfXAxis[j]}');");
                    }
                    else
                    {
                        yValues[j] = DataAccess.GetCellData<double>($"SELECT {itemsOfYAxis[i]} FROM OutputData WHERE MonthID = {((bool)obj ? "14" : "13")} " +
                            $"AND YearName = {itemsOfXAxis[j]}");
                    }
                }

                chart.Series.Add(CreateSeries(legendItemsNames[i], colorsOfYAxisItems[i], yValues));
            }

            for (double i = 0, from = 0.5, to = 1.5; i < itemsOfXAxis.Length; i++, from++, to++)
            {
                chart.ChartAreas[0].AxisX.CustomLabels.Add(from, to, itemsOfXAxis[(int)i]);
            }

            chart.Update();
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
