using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CatlabuhApp.UI.Main.UC
{
    public partial class SeriesGridView : UserControl
    {
        public SeriesGridViewRows Rows { get; set; }
        private TextBox[] headerBoxes = new TextBox[9];

        public SeriesGridView()
        {
            Forms.MainForm.GetCultureInfo();
            InitializeComponent();
            Rows = new SeriesGridViewRows(ref contentTLP);
            Rows.Clear();
        }

        public void SetHeaderBoxes()
        {
            string[,] headerText =
            {
                { "Name", "Назва", "Имя" },
                { "Type", "Тип", "Тип" },
                { "Color", " Колір", "Цвет" },
                { "Line type", "Тип лінії", "Тип линии" },
                { "Line size", "Товщ. лінії", "Шир. линии" },
                { "Marker", "Маркер", "Маркер" },
                { "Marker size", "Розмір марк.", "Размер марк." },
                { "Marker color", "Колір марк.", "Цвет марк." },
                { "Marker border color", "Колір межі марк.", "Цвет гран. марк." }
            };
            int languageIndex = -1;

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    languageIndex = 0;
                    break;
                case "uk-UA":
                    languageIndex = 1;
                    break;
                case "ru-RU":
                    languageIndex = 2;
                    break;
            }

            for (int i = 0; i < headerBoxes.Length; i++)
            {
                headerBoxes[i] = new TextBox
                {
                    Text = headerText[i, languageIndex],
                    TextAlign = HorizontalAlignment.Center,
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 0, 0, 0),
                    Size = new Size(1, 40),
                    ReadOnly = true,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.LightGray
                };
            }

            contentTLP.Controls.AddRange(headerBoxes);
        }


        public class SeriesGridViewRow
        {
            public int Index { get; set; }

            public string Name { get => nameTextBox.Text; set => nameTextBox.Text = value; }
            public SeriesChartType ChartType { get => (SeriesChartType)seriesTypesBox.SelectedItem; }
            public MarkerStyle MarkerStyle { get => (MarkerStyle)markerStylesBox.SelectedItem; }
            public ChartDashStyle LineDashStyle { get => (ChartDashStyle)lineDashStyleBox.SelectedItem; }
            public int LineSize { get => (int)lineSizeUpDown.Value; private set => lineSizeUpDown.Value = value; }
            public int MarkerSize { get => (int)markerSizeUpDown.Value; private set => markerSizeUpDown.Value = value; }
            public Color Color { get => seriesColorPanel.BackColor; set => seriesColorPanel.BackColor = value; }
            public Color MarkerColor { get => markerColorPanel.BackColor; }
            public Color MarkerBorderColor { get => markerColorPanel.BackColor; }

            public List<Control> Controls { get => controls; }
            private List<Control> controls = new List<Control>();

            #region Controls
            private TextBox nameTextBox;

            private ComboBox seriesTypesBox;
            private ComboBox markerStylesBox;
            private ComboBox lineDashStyleBox;

            private NumericUpDown lineSizeUpDown;
            private NumericUpDown markerSizeUpDown;

            private Panel seriesColorPanel;
            private Panel markerBorderColorPanel;
            private Panel markerColorPanel;

            #endregion

            public SeriesGridViewRow()
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                nameTextBox = new TextBox()
                {
                    Size = new Size(67, 24),
                    ReadOnly = true,
                    TextAlign = HorizontalAlignment.Center
                };
                seriesTypesBox = new ComboBox()
                {
                    Enabled = true,
                    Items = { SeriesChartType.Line, SeriesChartType.Spline, SeriesChartType.StepLine,
                        SeriesChartType.Bar, SeriesChartType.Column
                    },
                    Size = new Size(70, 24)
                };
                lineDashStyleBox = new ComboBox()
                {
                    Enabled = true,
                    Items = { ChartDashStyle.Solid, ChartDashStyle.Dash, ChartDashStyle.Dot,
                        ChartDashStyle.DashDot, ChartDashStyle.DashDotDot
                    },
                    Size = new Size(70, 24)
                };
                markerStylesBox = new ComboBox()
                {
                    Enabled = true,
                    Items = { MarkerStyle.Circle, MarkerStyle.Square, MarkerStyle.Diamond,
                        MarkerStyle.Triangle, MarkerStyle.None
                    },
                    Size = new Size(79, 24)
                };
                lineSizeUpDown = new NumericUpDown()
                {
                    Value = 2,
                    Size = new Size(43, 22)
                };
                markerSizeUpDown = new NumericUpDown()
                {
                    Increment = 5,
                    Value = 0,
                    Size = new Size(60, 22)
                };
                seriesColorPanel = new Panel()
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Size = new Size(43, 24)
                };
                markerColorPanel = new Panel()
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Size = new Size(74, 24)
                };
                markerBorderColorPanel = new Panel()
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Size = new Size(87, 24)
                };

                seriesTypesBox.SelectedItem = seriesTypesBox.Items[0];
                markerStylesBox.SelectedItem = markerStylesBox.Items[4];
                lineDashStyleBox.SelectedItem = lineDashStyleBox.Items[0];

                seriesColorPanel.DoubleClick += ColorPanel_DoubleClick;
                markerColorPanel.DoubleClick += ColorPanel_DoubleClick;
                markerBorderColorPanel.DoubleClick += ColorPanel_DoubleClick;

                controls.AddRange(new Control[] {
                    nameTextBox, seriesTypesBox, seriesColorPanel, lineDashStyleBox, lineSizeUpDown, markerStylesBox,
                    markerSizeUpDown, markerColorPanel, markerBorderColorPanel
                });

                foreach (var entry in controls)
                {
                    entry.Dock = DockStyle.Fill;
                }
            }

            private void ColorPanel_DoubleClick(object sender, EventArgs e)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.ShowDialog();

                ((Panel)sender).BackColor = colorDialog.Color;
            }

            public override string ToString()
            {
                return $"Row [Name = {Name}, ChartType = {ChartType}, SeriesColor = {Color}, LineDashStyle = {LineDashStyle}" +
                    $"LineSize = {LineSize}, MarkerStyle = {MarkerStyle}, MarkerSize = {MarkerSize}, " +
                    $"MarkerColor = {MarkerColor}, MarkerBorederColor = {MarkerBorderColor}]";
            }
        }

        public class SeriesGridViewRows : IEnumerable
        {
            private readonly IList<SeriesGridViewRow> list = new List<SeriesGridViewRow>();
            private TableLayoutPanel tlp;

            public int Count => list.Count;

            public SeriesGridViewRows(ref TableLayoutPanel tlp)
            {
                this.tlp = tlp;
            }

            public SeriesGridViewRow this[int index]
            {
                get { return list[index]; }
                set { list[index] = value; }
            }

            public void Add(SeriesGridViewRow value)
            {
                list.Add(value);
                tlp.Controls.AddRange(value.Controls.ToArray());
            }

            public void Clear()
            {
                tlp.Controls.Clear();
                list.Clear();
            }

            public bool Remove(SeriesGridViewRow value)
            {
                foreach (var entry in value.Controls)
                {
                    tlp.Controls.Remove(entry);
                }

                return list.Remove(value);
            }

            public IEnumerator GetEnumerator()
            {
                return list.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
