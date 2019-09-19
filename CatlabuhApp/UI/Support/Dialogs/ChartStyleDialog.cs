using CatlabuhApp.UI.Main.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static CatlabuhApp.UI.Main.UC.SeriesGridView;

namespace CatlabuhApp.UI.Support.Dialogs
{
    public partial class ChartStyleDialog : Form
    {
        public struct Title
        {
            public string Text { get; set; }
            public Font Font { get; set; }
            public Docking Docking { get; set; }

            public override string ToString()
            {
                return $"Text: {Text}\nFont: {Font.ToString()} {Font.Style.ToString()}\nDocking: {Docking}\n";
            }
        }
        public bool IsPieChart { get; set; } = false;

        #region General
        public FontFamily FontFamilyOnChart => new FontFamily(fontFamiliesBox.SelectedItem.ToString());

        public int TextSizeOfInscriptions => (int)textSize4.Value;

        public bool IsApplyFontToAll => applyFontToAll.Checked;

        public bool IsPieLabelOutside => pieLabelOutsideCheck.Checked;
        
        #endregion
        #region Titles
        public Title ChartTitle => new Title()
        {
            Text = chartTitleBox.Text,
            Font = new Font(
                FontFamilyOnChart, 
                (float)(!IsApplyFontToAll ? textSize1.Value : TextSizeOfInscriptions), 
                GetFontStyle(regularChoice1, boldChoice1, italicChoice1, underlineChoice1)),
            Docking = chartTitleOnTop.Checked ? Docking.Top : Docking.Bottom
        };

        public Title XAxisTitle => new Title()
        {
            Text = xAxisTitleBox.Text,
            Font = new Font(
                FontFamilyOnChart,
                (float)(!IsApplyFontToAll ? textSize2.Value : TextSizeOfInscriptions), 
                GetFontStyle(regularChoice2, boldChoice2, italicChoice2, underlineChoice2))
        };

        public Title YAxisTitle => new Title()
        {
            Text = yAxisTitleBox.Text,
            Font = new Font(
                FontFamilyOnChart,
                (float)(!IsApplyFontToAll ? textSize3.Value : TextSizeOfInscriptions), 
                GetFontStyle(regularChoice3, boldChoice3, italicChoice3, underlineChoice3))
        };

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
        #region Legend
        public bool IsLegendEnable => showLegend.Checked;

        public int LegendTextSize => !IsApplyFontToAll ? (int)textSize5.Value : TextSizeOfInscriptions;

        #endregion

        public SeriesCollection Series { get; set; }
        
        public ChartStyleDialog()
        {
            Main.Forms.MainForm.GetCultureInfo();
            InitializeComponent();

            SetFontFamilyItems();
            SetPropertiesToDefault();
        }

        public void SetSeriesGridViewRows()
        {
            seriesGridView.Rows.Clear();
            seriesGridView.SetHeaderBoxes();

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
            if (!IsPieChart)
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
                        Series[i].BorderDashStyle = seriesGridView.Rows[i].LineDashStyle;
                        Series[i].BorderWidth = seriesGridView.Rows[i].LineSize;
                        Series[i].MarkerStyle = seriesGridView.Rows[i].MarkerStyle;
                        Series[i].MarkerSize = seriesGridView.Rows[i].MarkerSize;
                        Series[i].MarkerColor = seriesGridView.Rows[i].MarkerColor;
                        Series[i].MarkerBorderColor = seriesGridView.Rows[i].MarkerBorderColor;
                    }

                    Hide();
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
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

        public void HideControlsForPieChart(bool HideControls)
        {
            IsPieChart = HideControls;

            if (HideControls)
            {
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                //seriesGridView.Visible = false;
                showGrid.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                //seriesGridView.Visible = true;
                showGrid.Enabled = true;
            }
        }

        private void SetFontFamilyItems()
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFontCollection.Families;
            List<string> fontFamilesNames = new List<string>();

            foreach (var entry in fontFamilies)
            {
                fontFamilesNames.Add(entry.Name);
            }

            fontFamiliesBox.Items.AddRange(fontFamilesNames.ToArray());
            fontFamiliesBox.SelectedItem = fontFamiliesBox.Items[107];
        }

        public void SetPropertiesToDefault()
        {
            textSize1.Value = 16;
            textSize2.Value = 14;
            textSize3.Value = 14;
            textSize4.Value = 14;
            textSize5.Value = 10;

            xAxisMajorGridStyle.SelectedIndex = 0;
            yAxisMajorGridStyle.SelectedIndex = 0;

            fontFamiliesBox.SelectedItem = fontFamiliesBox.Items[107];

            applyFontToAll.Checked = false;

            showLegend.Checked = true;
            
            showGrid.Checked = true;
            showXAxisMajorGrid.Checked = true;
            showYAxisMajorGrid.Checked = true;
            showXAxisMinorGrid.Checked = false;
            showYAxisMinorGrid.Checked = false;

            regularChoice1.Checked = true;
            regularChoice2.Checked = true;
            regularChoice3.Checked = true;

            chartTitleOnTop.Checked = true;

            pieLabelOutsideCheck.Checked = false;

            chartTitleBox.Clear();
        }
    }
}
