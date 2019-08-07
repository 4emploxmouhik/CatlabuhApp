using System;

namespace CatlabuhApp.UI.Main.Views
{
    partial class CalculationView
    {
        public string YearOfCalculation { get; private set; }

        public void UpdateYearsBoxItems()
        {
            yearsBox.Items.Clear();
            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations ORDER BY YearName DESC").ToArray());
            yearsBox.Text = yearsBox.Items[0].ToString();
        }

        private void YearsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calc.YearOfCalculation = YearOfCalculation;
            UpdateDataSource();
            HighlightInputCellColor();
        }

        private void YearsBox_TextChanged(object sender, EventArgs e)
        {
            YearOfCalculation = yearsBox.Text;
        }
    }
}
