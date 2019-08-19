using CatlabuhApp.UI.Main.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static CatlabuhApp.UI.Main.UC.SeriesGridView;

namespace CatlabuhApp.UI.Support.Dialogs
{
    public partial class ChartStyleDialog : Form
    {
        private ChartView parent;
        public struct Title
        {
            public string Text { get; set; }
            public Font Font { get; set; }

            public override string ToString()
            {
                return $"Text: {Text}\nFont: {Font.ToString()} {Font.Style.ToString()}\n";
            }
        }

        #region General
        public Title ChartTitle
        {
            get
            {
                return new Title()
                {
                    Text = chartTitleBox.Text,
                    Font = new Font(Font.FontFamily, (float)textSize1.Value, GetFontStyle(regularChoice1, boldChoice1, italicChoice1, underlineChoice1))
                };
            }
        }
        public Title XAxisTitle
        {
            get
            {
                return new Title()
                {
                    Text = xAxisTitleBox.Text,
                    Font = new Font(Font.FontFamily, (float)textSize2.Value, GetFontStyle(regularChoice2, boldChoice2, italicChoice2, underlineChoice2))
                };
            }
        }
        public Title YAxisTitle
        {
            get
            {
                return new Title()
                {
                    Text = yAxisTitleBox.Text,
                    Font = new Font(Font.FontFamily, (float)textSize3.Value, GetFontStyle(regularChoice3, boldChoice3, italicChoice3, underlineChoice3))
                };
            }
        }

        #endregion
        #region Grid
        public bool IsShowGrid { get => showGrid.Checked; }

        public bool IsShowXAxisMajorGrid { get => showXAxisMajorGrid.Checked; }
        public bool IsShowXAxisMinorGrid { get => showXAxisMinorGrid.Checked; }
        public ChartDashStyle XAxisMajorGridLineDashStyle { get => GetLineStyle(xAxisMajorGridStyle); }
        public ChartDashStyle XAxisMinorGridLineDashStyle { get => GetLineStyle(xAxisMinorGridStyle); }

        public bool IsShowYAxisMajorGrid { get => showYAxisMajorGrid.Checked; }
        public bool IsShowYAxisMinorGrid { get => showYAxisMinorGrid.Checked; }
        public ChartDashStyle YAxisMajorGridLineDashStyle { get => GetLineStyle(yAxisMajorGridStyle); }
        public ChartDashStyle YAxisMinorGridLineDashStyle { get => GetLineStyle(yAxisMinorGridStyle); }

        #endregion

        public SeriesCollection Series { get; set; }
        
        public ChartStyleDialog()
        {
            Main.Forms.MainForm.GetCultureInfo();
            InitializeComponent();

            textSize1.Value = 10;
            textSize2.Value = 10;
            textSize3.Value = 10;

            xAxisMajorGridStyle.SelectedIndex = 0;
            yAxisMajorGridStyle.SelectedIndex = 0;
        }

        public ChartStyleDialog(ChartView parent)
        {
            this.parent = parent;
        }

        public void SetSeriesGridViewRows()
        {
            seriesGridView.Rows.Clear();

            foreach (var entry in Series)
            {
                seriesGridView.Rows.Add(new SeriesGridViewRow() { Name = entry.Name, Color = entry.Color });
            }
        }

        public void SetStartAxisTitles(string xAxisTitle, string yAxisTitle)
        {
            if (string.IsNullOrEmpty(xAxisTitle))
            {
                throw new ArgumentException("message", nameof(xAxisTitle));
            }
            if (string.IsNullOrEmpty(yAxisTitle))
            {
                throw new ArgumentException("message", nameof(yAxisTitle));
            }

            xAxisTitleBox.Text = xAxisTitle;
            yAxisTitleBox.Text = yAxisTitle;
        }

        private FontStyle GetFontStyle(RadioButton r, RadioButton b, RadioButton i, RadioButton u)
        {
            if (r.Checked) { return FontStyle.Regular; }
            else if (b.Checked) { return FontStyle.Bold; }
            else if (i.Checked) { return FontStyle.Italic; }
            else if (u.Checked) { return FontStyle.Underline; }
            else { return FontStyle.Regular; }
        }

        private ChartDashStyle GetLineStyle(ComboBox comboBox)
        {
            switch (comboBox.SelectedItem)
            {
                case "Dash":
                    return ChartDashStyle.Dash;
                case "Dot":
                    return ChartDashStyle.Dot;
                default:
                    return ChartDashStyle.Solid;
            }
        }

        private bool BarChartTypeCheck()
        {
            int barCount = 0;

            for (int i = 0; i < seriesGridView.Rows.Count; i++)
            {
                if (seriesGridView.Rows[i].ChartType == SeriesChartType.Bar)
                {
                    barCount++;
                }
            }

            if (seriesGridView.Rows.Count == 1)
            {
                return true;
            }
            else if (barCount == 0 || barCount == seriesGridView.Rows.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            if (!BarChartTypeCheck())
            {
                MessageDialog.Show(MessageDialog.ErrorTitle, MessageDialog.ErrorText7, MessageDialog.Icon.Cross);
            }
            else
            {
                DialogResult = DialogResult.OK;

                for (int i = 0; i < Series.Count; i++)
                {
                    Series[i].ChartType = seriesGridView.Rows[i].ChartType;
                    Series[i].Color = seriesGridView.Rows[i].Color;
                    Series[i].BorderWidth = seriesGridView.Rows[i].LineSize;
                    Series[i].MarkerStyle = seriesGridView.Rows[i].MarkerStyle;
                    Series[i].MarkerSize = seriesGridView.Rows[i].MarkerSize;
                    Series[i].MarkerColor = seriesGridView.Rows[i].MarkerColor;
                    Series[i].MarkerBorderColor = seriesGridView.Rows[i].MarkerBorderColor;
                }

                Hide();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void ShowAxisGrid_CheckedChanged(object sender, EventArgs e)
        {
            switch (((CheckBox)sender).Name)
            {
                case "showXAxisMajorGrid":
                    xAxisMajorGridStyle.Enabled = showXAxisMajorGrid.Checked;
                    xAxisMajorGridStyle.Text = showXAxisMajorGrid.Checked ? xAxisMajorGridStyle.Items[0].ToString() : "";
                    break;
                case "showXAxisMinorGrid":
                    xAxisMinorGridStyle.Enabled = showXAxisMinorGrid.Checked;
                    xAxisMinorGridStyle.Text = showXAxisMinorGrid.Checked ? xAxisMinorGridStyle.Items[0].ToString() : "";
                    break;
                case "showYAxisMajorGrid":
                    yAxisMajorGridStyle.Enabled = showYAxisMajorGrid.Checked;
                    yAxisMajorGridStyle.Text = showYAxisMajorGrid.Checked ? yAxisMajorGridStyle.Items[0].ToString() : "";
                    break;
                case "showYAxisMinorGrid":
                    yAxisMinorGridStyle.Enabled = showYAxisMinorGrid.Checked;
                    yAxisMinorGridStyle.Text = showYAxisMinorGrid.Checked ? yAxisMinorGridStyle.Items[0].ToString() : "";
                    break;
            }
        }

        private void ShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            showXAxisMajorGrid.Checked = showGrid.Checked;
            showYAxisMajorGrid.Checked = showGrid.Checked;

            if (!showGrid.Checked)
            {
                showXAxisMinorGrid.Checked = false;
                showYAxisMinorGrid.Checked = false;
            }
        }

        private void ChartStyleDialog_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
