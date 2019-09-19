using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Support.Dialogs;
using CatlabuhAppSupportHelp.UI.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Setups
{
    public partial class ChartSetup : Form
    {
        private ComponentResourceManager res = new ComponentResourceManager(typeof(Properties.Resources));
        public IDataAccess DataAccess { get; private set; }

        public string[] ItemsOfXAxis { get; private set; }
        public string[] ItemsOfYAxis { get; private set; }
        public string[] LegendItemsNames { get; private set; }
        public Color[] ColorsOfYAxisItems { get; private set; }
        public string YearOfCalculation { get => yearTextBox.Text; }
        public bool IsProcentItems { get => isProcentItems; }
        public bool IsChartForMonths { get => monthRadio.Checked; }
        private bool isProcentItems = false;

        private List<CheckBox> yItemsCheckBoxes = new List<CheckBox>();
        private List<Panel> colorPanels = new List<Panel>();
        private List<YAxisItem> YAxisItems = new List<YAxisItem>();

        private List<CheckBox> monthsBoxes = new List<CheckBox>();
        private ISet<string> XAxisItems = new HashSet<string>();

        private string[] text;
        private string currentLanguage;

        public ChartSetup()
        {
            Main.Forms.MainForm.GetCultureInfo();
            InitializeComponent();

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    text = new string[] { "Year: ", "Years from: ", " to: " };
                    currentLanguage = "EN";
                    break;
                case "uk-UA":
                    text = new string[] { "Рік: ", "Роки від: ", " до: " };
                    currentLanguage = "UA";
                    break;
                case "ru-RU":
                    text = new string[] { "Год: ", "Года от: ", " до: " };
                    currentLanguage = "RU";
                    break;
            }

            yItemsCheckBoxes.AddRange(new CheckBox[]
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19,
                checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28, checkBox47,
                checkBox29, checkBox30, checkBox31, checkBox32, checkBox33, checkBox34, checkBox35, checkBox36, checkBox48,
                checkBox37, checkBox38, checkBox39, checkBox40, checkBox41, checkBox42, checkBox43, checkBox44, checkBox45,
                checkBox46
            });
            colorPanels.AddRange(new Panel[]
            {
                panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10,
                panel11, panel12, panel13, panel14, panel15, panel16, panel17, panel18, panel19,
                panel21, panel22, panel23, panel24, panel25, panel26, panel27, panel28, panel47,
                panel29, panel30, panel31, panel32, panel33, panel34, panel35, panel36, panel48,
                panel37, panel38, panel39, panel40, panel41, panel42, panel43, panel44, panel45,
                panel46
            });
            monthsBoxes.AddRange(new CheckBox[] {
                january, february, march, april, may, june, july, august, september, october, november, december
            });

            DialogResult = DialogResult.None;
        }
        
        public ChartSetup(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;
        }

        private void SetupGraphForm_Load(object sender, EventArgs e)
        {
            List<string> years = DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations ORDER BY YearName DESC");

            yearsComboBox_1.Items.AddRange(years.ToArray());
            yearsComboBox_2.Items.AddRange(years.ToArray());
            yearToCombBox.Items.AddRange(years.ToArray());

            years.Reverse();

            yearFromComboBox.Items.AddRange(years.ToArray());

            try
            {
                yearsComboBox_1.SelectedItem = yearsComboBox_1.Items[0];
                yearsComboBox_2.SelectedItem = yearsComboBox_2.Items[0];
                yearFromComboBox.SelectedItem = yearFromComboBox.Items[0];
                yearToCombBox.SelectedItem = yearToCombBox.Items[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            for (int i = 0; i < 5; i++)   { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
            for (int i = 12; i < 14; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
            for (int i = 19; i < 30; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
            for (int i = 38; i < 42; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }

            foreach (var entry in yItemsCheckBoxes)
            {
                toolTip.SetToolTip(entry, res.GetString($"{entry.Tag}Description_{currentLanguage}"));
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            switch (radioButton.Tag)
            {
                case "years":
                    yearsPanel.Visible = true;
                    monthPanel.Visible = false;
                    sumRadio.Enabled = true;
                    procRadio.Enabled = true;
                    procRadio.Checked = true;
                    yearLabel.Visible = false;
                    yearTextBox.Visible = false;

                    for (int i = 0; i < 5; i++)   { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
                    for (int i = 12; i < 14; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
                    for (int i = 19; i < 30; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
                    for (int i = 38; i < 42; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }

                    YAxisItemsBox.Clear();

                    foreach (var entry in YAxisItems)
                    {
                        YAxisItemsBox.Text += entry.Name + " ";
                    }

                    XAxisItems.Clear();
                    XAxisItems = new SortedSet<string>();
                    XAxisItemsBox.Width = YAxisItemsBox.Width;
                    XAxisItemsBox.Clear();
                    getAll.Checked = false;
                    break;
                case "months":
                    yearsPanel.Visible = false;
                    monthPanel.Visible = true;
                    sumRadio.Enabled = false;
                    procRadio.Enabled = false;
                    sumRadio.Checked = false;
                    procRadio.Checked = false;
                    checkBox15.Enabled = true;
                    yearLabel.Visible = true;
                    yearTextBox.Visible = true;

                    for (int i = 0; i < 5; i++)   yItemsCheckBoxes[i].Enabled = true;
                    for (int i = 12; i < 14; i++) yItemsCheckBoxes[i].Enabled = true;
                    for (int i = 19; i < 30; i++) yItemsCheckBoxes[i].Enabled = true;
                    for (int i = 38; i < 42; i++) yItemsCheckBoxes[i].Enabled = true;

                    XAxisItems.Clear();
                    XAxisItems = new HashSet<string>();
                    XAxisItemsBox.Width = YAxisItemsBox.Width - yearLabel.Width - yearTextBox.Width - (yearTextBox.Margin.Left * 2);
                    getAll.Checked = true;
                    break;
                case "∑":
                    checkBox15.Enabled = true;
                    isProcentItems = false;
                    break;
                case "%":
                    checkBox15.Enabled = false;
                    checkBox15.Checked = false;

                    foreach (var entry in YAxisItems)
                    {
                        if (entry.Tag.Equals(checkBox15.Tag))
                        {
                            YAxisItems.Remove(entry);
                            break;
                        }
                    }

                    YAxisItemsBox.Clear();

                    foreach (var entry in YAxisItems)
                    {
                        YAxisItemsBox.Text += entry.Name + " ";
                    }

                    isProcentItems = true;
                    break;
            }
        }

        #region XItems

        private bool isGetAll = true;

        private void XItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox == getAll)
            {
                if (isGetAll)
                {
                    getAll.CheckState = CheckState.Indeterminate;

                    foreach (var entry in monthsBoxes)
                    {
                        XAxisItems.Add(entry.Tag.ToString());
                        entry.CheckState = CheckState.Checked;
                    }

                    isGetAll = false;
                }
                else
                {
                    XAxisItems.Clear();
                    getAll.CheckState = CheckState.Unchecked;

                    foreach (var entry in monthsBoxes)
                    {
                        entry.CheckState = CheckState.Unchecked;
                    }
                    isGetAll = true;
                }
            }
            else
            {
                if (checkBox.Checked)
                {
                    XAxisItems.Add(checkBox.Tag.ToString());
                }
                else
                {
                    XAxisItems.Remove(checkBox.Tag.ToString());
                }
            }

            XAxisItemsBox.Clear();

            foreach (var entry in XAxisItems)
            {
                for (int i = 0; i < monthsBoxes.Count; i++)
                {
                    if (monthsBoxes[i].Tag.Equals(entry))
                    {
                        XAxisItemsBox.Text += monthsBoxes[i].Text + " ";
                    }
                }
            }
        }

        private SortedSet<string> AddRangeYears(List<int> rangeYears)
        {
            SortedSet<string> yearsSet = new SortedSet<string>();

            foreach (var entry in rangeYears)
            {
                yearsSet.Add(entry.ToString());
            }

            return yearsSet;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabControl2.SelectedTab.Tag)
                {
                    case "chooseYear":
                        if (!yearsList.Items.Contains(text[0] + yearsComboBox_2.SelectedItem))
                        {
                            yearsList.Items.Add(text[0] + yearsComboBox_2.SelectedItem);
                            XAxisItems.Add(yearsComboBox_2.SelectedItem.ToString());
                        }
                        else
                        {
                            string msg = "";

                            switch (Properties.Settings.Default.Language)
                            {
                                case "en-US":
                                    msg = $"Year [{yearsComboBox_2.SelectedItem}] has already been added to the list. Choose another year."; ;
                                    break;
                                case "uk-UA":
                                    msg = $"Рік [{yearsComboBox_2.SelectedItem}] вже додано до списку. Оберіть інший рік.";
                                    break;
                                case "ru-RU":
                                    msg = $"Год [{yearsComboBox_2.SelectedItem}] уже добавлен в список. Выберите другой год.";
                                    break;
                            }

                            MessageDialog.Show(MessageDialog.AlertTitle1, msg, MessageDialog.Icon.Alert);
                        }
                        break;
                    case "chooseRange":
                        
                        yearsList.Items.Clear();
                        yearsList.Items.Add(text[1] + yearFromComboBox.SelectedItem + text[2] + yearToCombBox.SelectedItem);

                        string yearFrom = yearFromComboBox.SelectedItem.ToString();
                        string yearTo = yearToCombBox.SelectedItem.ToString();

                        XAxisItems = AddRangeYears(DataAccess.GetColumnData<int>($"SELECT YearName FROM YearsOfCalculations " +
                            $"WHERE {yearFrom} <= YearName AND YearName <= {yearTo} ORDER BY YearName ASC"));
                        break;
                }

                XAxisItemsBox.Clear();

                foreach (var entry in XAxisItems)
                {
                    XAxisItemsBox.Text += entry + " ";
                }
            }
            catch (NullReferenceException)
            {
                MessageDialog.Show(MessageDialog.AlertTitle2, MessageDialog.AlertText1, MessageDialog.Icon.Alert);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabControl2.SelectedTab.Tag)
                {
                    case "chooseYear":
                        XAxisItems.Remove(yearsList.GetItemText(yearsList.SelectedItem).Remove(0, 5));
                        yearsList.Items.Remove(yearsList.SelectedItem);
                        XAxisItemsBox.Clear();

                        foreach (string entry in XAxisItems)
                        {
                            XAxisItemsBox.Text += entry + " ";
                        }
                        break;
                    case "chooseRange":
                        XAxisItems.Clear();
                        yearsList.Items.Clear();
                        XAxisItemsBox.Clear();

                        foreach (string entry in XAxisItems)
                        {
                            XAxisItemsBox.Text += entry + " ";
                        }
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText1, MessageDialog.Icon.Alert);
            }
        }
       
        #endregion
        #region YItems

        private void ColorPanel_DoubleClick(object sender, EventArgs e)
        {
            Panel colorPanel = (Panel)sender;

            foreach (CheckBox entry in yItemsCheckBoxes)
            {
                if (entry.Tag.Equals(colorPanel.Tag) && entry.Checked)
                {
                    colorDialog.ShowDialog();
                    colorPanel.BackColor = colorDialog.Color;
                    break;
                }
            }
        }

        private void YItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Panel colorPanel = null;

            foreach (var entry in colorPanels)
            {
                if (checkBox.Tag.Equals(entry.Tag))
                {
                    colorPanel = entry;
                    break;
                }
            }

            if (checkBox.Checked)
            {
                YAxisItems.Add(new YAxisItem() {
                    Name = checkBox.Text,
                    Tag = checkBox.Tag.ToString(),
                    ColorPanel = colorPanel
                });
            }
            else
            {
                colorPanel.BackColor = BackColor;

                foreach (var entry in YAxisItems)
                {
                    if (entry.Tag.Equals(checkBox.Tag))
                    {
                        YAxisItems.Remove(entry);
                        break;
                    }
                }
            }

            YAxisItemsBox.Clear();

            foreach (var entry in YAxisItems)
            {
                YAxisItemsBox.Text += entry.Name + " ";
            }
        }

        private class YAxisItem
        {
            public string Name;
            public string Tag;
            public Panel ColorPanel;

            public override string ToString()
            {
                return "[Name = " + Name + ", Tag = " + Tag + ", Color = " + ColorPanel.BackColor + "]";
            }
        }

        private void ComboBox_SelectedIndexChange(object sender, EventArgs e)
        {
            yearTextBox.Text = yearsComboBox_1.SelectedItem.ToString();
        }
       
        #endregion

        private void Clear_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Tag)
            {
                case "XAxis":
                    foreach (CheckBox checkBox in monthsBoxes)
                        checkBox.Checked = false;

                    getAll.Checked = false;
                    yearsList.Items.Clear();
                    XAxisItemsBox.Clear();
                    XAxisItems.Clear();
                    break;
                case "YAxis":
                    foreach (CheckBox checkBox in yItemsCheckBoxes)
                        checkBox.Checked = false;

                    YAxisItemsBox.Clear();
                    YAxisItems.Clear();
                    break;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BuildAGraph_Click(object sender, EventArgs e)
        {
            if (XAxisItems.Count > 1 && YAxisItems.Count > 0)
            {
                string[] itemsOfXAxis = new string[XAxisItems.Count];
                string[] itemsOfYAxis = new string[YAxisItems.Count];
                string[] legendItemsNames = new string[YAxisItems.Count];
                Color[] colorsOfYAxisItems = new Color[YAxisItems.Count];

                int i = 0;

                foreach (var entry in XAxisItems)
                {
                    itemsOfXAxis[i] = entry;
                    i++;

                    if (i == XAxisItems.Count) break;
                }

                for (i = 0; i < itemsOfYAxis.Length; i++)
                {
                    itemsOfYAxis[i] = YAxisItems[i].Tag;
                    legendItemsNames[i] = YAxisItems[i].Name;

                    if (YAxisItems[i].ColorPanel.BackColor != BackColor)
                    {
                        colorsOfYAxisItems[i] = YAxisItems[i].ColorPanel.BackColor;
                    }
                    else
                    {
                        colorsOfYAxisItems[i] = Color.Black;
                    }
                }

                ItemsOfXAxis = itemsOfXAxis;
                ItemsOfYAxis = itemsOfYAxis;
                LegendItemsNames = legendItemsNames;
                ColorsOfYAxisItems = colorsOfYAxisItems;

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageDialog.Show(MessageDialog.AlertTitle2, MessageDialog.AlertText6, MessageDialog.Icon.Alert);
            }
        }

        private void SetupGraphForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new HelpForm("chartSetupText").Show();
        }

    }
}
