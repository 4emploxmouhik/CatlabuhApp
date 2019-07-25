using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Setups
{
    /// <summary>
    /// Форма первоначальной настройки параметров графика
    /// </summary>
    public partial class ChartSetup : Form
    {
        private List<CheckBox> yItemsCheckBoxes = new List<CheckBox>();
        private List<Panel> colorPanels = new List<Panel>();
        private List<YAxisItem> YAxisItems = new List<YAxisItem>();

        private List<CheckBox> monthsBoxes = new List<CheckBox>();
        private ISet<string> XAxisItems = new HashSet<string>();

        private bool isProcentItems = false;

        /// <summary>
        /// Инициализирует объект класса SetupGraphForm
        /// </summary>
        public ChartSetup()
        {
            InitializeComponent();

            yItemsCheckBoxes.AddRange(new CheckBox[]
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19,
                checkBox20, checkBox21, checkBox22, checkBox23, checkBox24, checkBox25, checkBox26, checkBox27, checkBox28,
                checkBox29, checkBox30, checkBox31, checkBox32, checkBox33, checkBox34, checkBox35, checkBox36, checkBox37,
                checkBox38, checkBox39, checkBox40, checkBox41, checkBox42, checkBox43, checkBox44, checkBox45, checkBox46
            });
            colorPanels.AddRange(new Panel[]
            {
                panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9, panel10,
                panel11, panel12, panel13, panel14, panel15, panel16, panel17, panel18, panel19,
                panel20, panel21, panel22, panel23, panel24, panel25, panel26, panel27, panel28, 
                panel29, panel30, panel31, panel32, panel33, panel34, panel35, panel36, panel37,  
                panel38, panel39, panel40, panel41, panel42, panel43, panel44, panel45, panel46
            });
            monthsBoxes.AddRange(new CheckBox[] {
                january, february, march, april, may, june, july, august, september, october, november, december
            });
        }
        
        private void SetupGraphForm_Load(object sender, EventArgs e)
        {
            //yearsComboBox_1 = SQLiteDataAccess.ViewYears(yearsComboBox_1, "DESC");
            //yearsComboBox_2 = SQLiteDataAccess.ViewYears(yearsComboBox_2, "DESC");
            //yearFromComboBox = SQLiteDataAccess.ViewYears(yearFromComboBox, "ASC");
            //yearToCombBox = SQLiteDataAccess.ViewYears(yearToCombBox, "DESC");

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
            for (int i = 11; i < 14; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
            for (int i = 20; i < 30; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
            for (int i = 37; i < 41; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
        }

        private void ComboBox_Enter(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            switch (comboBox.Name)
            {
                case "yearsComboBox_1":
                    //yearsComboBox_1 = SQLiteDataAccess.ViewYears(yearsComboBox_1, "DESC");
                    break;
                case "yearsComboBox_2":
                    //yearsComboBox_2 = SQLiteDataAccess.ViewYears(yearsComboBox_2, "DESC");
                    break;
                case "yearFromComboBox":
                    //yearFromComboBox = SQLiteDataAccess.ViewYears(yearFromComboBox, "ASC");
                    break;
                case "yearToCombBox":
                    //yearToCombBox = SQLiteDataAccess.ViewYears(yearToCombBox, "DESC");
                    break;
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

                    for (int i = 0; i < 5; i++)   { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
                    for (int i = 11; i < 14; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
                    for (int i = 20; i < 30; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }
                    for (int i = 37; i < 41; i++) { yItemsCheckBoxes[i].Enabled = false; yItemsCheckBoxes[i].Checked = false; }

                    YAxisItemsBox.Clear();

                    foreach (YAxisItem entry in YAxisItems)
                        YAxisItemsBox.Text += entry.Name + " ";

                    XAxisItems.Clear();
                    XAxisItems = new SortedSet<string>();
                    XAxisItemsBox.Width = YAxisItemsBox.Width;
                    XAxisItemsBox.Clear();
                    getAll.Checked = false;
                    break;
                case "months":
                    yearsPanel.Visible = false;
                    yearTextBox.Visible = true;
                    monthPanel.Visible = true;
                    sumRadio.Enabled = false;
                    procRadio.Enabled = false;
                    sumRadio.Checked = false;
                    procRadio.Checked = false;
                    checkBox15.Enabled = true;

                    for (int i = 0; i < 5; i++)   yItemsCheckBoxes[i].Enabled = true;
                    for (int i = 11; i < 14; i++) yItemsCheckBoxes[i].Enabled = true;
                    for (int i = 20; i < 30; i++) yItemsCheckBoxes[i].Enabled = true;
                    for (int i = 37; i < 41; i++) yItemsCheckBoxes[i].Enabled = true;

                    XAxisItems.Clear();
                    XAxisItems = new HashSet<string>();
                    XAxisItemsBox.Width = YAxisItemsBox.Width - yearTextBox.Width - (yearTextBox.Margin.Left * 2);
                    getAll.Checked = true;
                    break;
                case "∑":
                    checkBox15.Enabled = true;
                    isProcentItems = false;
                    break;
                case "%":
                    checkBox15.Enabled = false;
                    checkBox15.Checked = false;

                    foreach (YAxisItem entry in YAxisItems)
                    {
                        if (entry.Tag.Equals(checkBox15.Tag))
                        {
                            YAxisItems.Remove(entry);
                            break;
                        }
                    }

                    YAxisItemsBox.Clear();

                    foreach (YAxisItem entry in YAxisItems)
                        YAxisItemsBox.Text += entry.Name + " ";

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

                    foreach (CheckBox entry in monthsBoxes)
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

                    foreach (CheckBox entry in monthsBoxes)
                        entry.CheckState = CheckState.Unchecked;

                    isGetAll = true;
                }
            }
            else
            {
                if (checkBox.Checked)
                    XAxisItems.Add(checkBox.Tag.ToString());
                else
                    XAxisItems.Remove(checkBox.Tag.ToString());
            }

            XAxisItemsBox.Clear();

            foreach (string entry in XAxisItems)
                XAxisItemsBox.Text += entry + " ";
        }

        private SortedSet<string> AddRangeYears(List<int> rangeYears)
        {
            SortedSet<string> yearsSet = new SortedSet<string>();

            foreach (int entry in rangeYears)
                yearsSet.Add(entry.ToString());

            return yearsSet;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabControl2.SelectedTab.Tag)
                {
                    case "chooseYear":
                        if (!yearsList.Items.Contains("Рік: " + yearsComboBox_2.SelectedItem))
                        {
                            yearsList.Items.Add("Рік: " + yearsComboBox_2.SelectedItem);
                            XAxisItems.Add(yearsComboBox_2.SelectedItem.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Рік розрахунку [" + yearsComboBox_2.SelectedItem + "] вже додано до списку.\n" +
                            "Оберіть інший рік розрахунку.", "Невірне значення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "chooseRange":
                        yearsList.Items.Clear();
                        yearsList.Items.Add("Роки від: " + yearFromComboBox.SelectedItem + " до: " + yearToCombBox.SelectedItem);

                        string yearFrom = yearFromComboBox.SelectedItem.ToString();
                        string yearTo = yearToCombBox.SelectedItem.ToString();

                        //XAxisItems = AddRangeYears(SQLiteDataAccess.GetYears(yearFrom, yearTo));
                        break;
                }

                XAxisItemsBox.Clear();

                foreach (string entry in XAxisItems)
                    XAxisItemsBox.Text += entry + " ";
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("Вкажіть рік/роки розрахунку.", "Невірне значення", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            XAxisItemsBox.Text += entry + " ";
                        break;
                    case "chooseRange":
                        XAxisItems.Clear();
                        yearsList.Items.Clear();
                        XAxisItemsBox.Clear();

                        foreach (string entry in XAxisItems)
                            XAxisItemsBox.Text += entry + " ";
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //MessageBox.Show("Оберіть рік, який треба видалити.", "Невірне значення", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            foreach (Panel entry in colorPanels)
            {
                if (checkBox.Tag.Equals(entry.Tag))
                {
                    colorPanel = entry;
                    break;
                }
            }

            if (checkBox.Checked)
            {
                YAxisItems.Add(new YAxisItem() { Name = checkBox.Text, Tag = checkBox.Tag.ToString(), ColorPanel = colorPanel });
            }
            else
            {
                colorPanel.BackColor = BackColor;

                foreach (YAxisItem entry in YAxisItems)
                {
                    if (entry.Tag.Equals(checkBox.Tag))
                    {
                        YAxisItems.Remove(entry);
                        break;
                    }
                }
            }

            YAxisItemsBox.Clear();

            foreach (YAxisItem entry in YAxisItems)
                YAxisItemsBox.Text += entry.Name + " ";
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
            Close();
        }

        private void BuildAGraph_Click(object sender, EventArgs e)
        {
            if (XAxisItems.Count > 1 && YAxisItems.Count > 0)
            {
                try
                {
                    string[] itemsOfXAxis = new string[XAxisItems.Count];
                    string[] itemsOfYAxis = new string[YAxisItems.Count];
                    string[] legendItemsNames = new string[YAxisItems.Count];
                    Color[] colorsOfYAxis = new Color[YAxisItems.Count];

                    int i = 0;

                    foreach (string entry in XAxisItems)
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
                            colorsOfYAxis[i] = YAxisItems[i].ColorPanel.BackColor;
                        else
                            colorsOfYAxis[i] = Color.Black;
                    }

                    //if (monthRadio.Checked)
                    //    new ShowGraphForm(itemsOfXAxis, itemsOfYAxis, legendItemsNames, colorsOfYAxis, yearTextBox.Text).Show();

                    //if (yearsRadio.Checked)
                    //    new ShowGraphForm(itemsOfXAxis, itemsOfYAxis, colorsOfYAxis, isProcentItems).Show();
                }
                catch (NullReferenceException)
                {
                    //MessageBox.Show(
                    //"Бракує даних для побудови графіку.",
                    //"Немає даних",
                    //MessageBoxButtons.OK,
                    //MessageBoxIcon.Error);
                }
                catch (ObjectDisposedException) { }
            }
            else
            {
                //MessageBox.Show(
                //   "Недостатньо даних для побудови графіку.\nПеревірте, чи додано хоча б одне значення для осі Y і два значення для осі Х.",
                //   "Невірні данні",
                //   MessageBoxButtons.OK,
                //   MessageBoxIcon.Error);
            }
        }

        private void SetupGraphForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

    }
}
