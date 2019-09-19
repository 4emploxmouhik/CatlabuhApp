using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Support.Dialogs;
using CatlabuhAppSupportHelp.UI.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static CatlabuhApp.Data.Models.Calculation;

namespace CatlabuhApp.UI.Support.Setups
{
    public partial class PieChartSetup : Form
    {
        private ComponentResourceManager res = new ComponentResourceManager(typeof(Properties.Resources));
        public IDataAccess DataAccess { get; private set; }

        private Panel[] wbppColorPanels;
        private Panel[] wbcpColorPanels;
        private Panel[] sbppColorPanels;
        private Panel[] sbcpColorPanels;
        private List<Panel[]> colorPanels = new List<Panel[]>();
        private List<string> parts = new List<string>();
        private string currentLanguage = "";
        
        public List<PartOfCalculation> ChosenParts { get; private set; } = new List<PartOfCalculation>();
        public List<Color[]> ChosenColors { get; private set; } = new List<Color[]>();
        public List<string> LegendItems { get; private set; } = new List<string>();
        public string YearOfCalculation { get; private set; }
        public bool IsPercentItems { get => percentRadio.Checked; }
        public string[] PartsNames => new string[] { tabControl.TabPages[0].Text, tabControl.TabPages[1].Text, tabControl.TabPages[2].Text, tabControl.TabPages[3].Text, };

        public PieChartSetup()
        {
            Main.Forms.MainForm.GetCultureInfo();

            InitializeComponent();

            wbppColorPanels = new Panel[]
            {
                colorPanel1, colorPanel2, colorPanel3, colorPanel4, colorPanel5, /*colorPanel6,*/ colorPanel7, colorPanel8
            };
            wbcpColorPanels = new Panel[]
            {
                colorPanel9, colorPanel10, colorPanel11, colorPanel12, colorPanel13, colorPanel14
            };
            sbppColorPanels = new Panel[]
            {
                colorPanel15, colorPanel16, colorPanel17, colorPanel18, colorPanel19, colorPanel20, colorPanel21
            };
            sbcpColorPanels = new Panel[]
            {
                colorPanel22, colorPanel23, colorPanel24, colorPanel25
            };

            colorPanels.AddRange(new[] { wbppColorPanels, wbcpColorPanels, sbppColorPanels, sbcpColorPanels });

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    currentLanguage = "EN";
                    break;
                case "uk-UA":
                    currentLanguage = "UA";
                    break;
                case "ru-RU":
                    currentLanguage = "RU";
                    break;
            }

            List<CheckBox> checkBoxes = new List<CheckBox>();
            checkBoxes.AddRange(new[] {
                vpBox, vrBox, vbBox, vgBox, vdrBox, /*dltVniBox,*/ vdPlusBox, vozPlusBox, 
                veBox, vtrBox, vfBox, vzBox, vdMinusBox, vozMinusBox,
                cpBox, crBox, cbBox, cgBox, cdrBox, cdPlusBox, cozPlusBox,
                cfBox, czBox, cdMinusBox, cozMinusBox
            });

            foreach (var entry in checkBoxes)
            {
                toolTip.SetToolTip(entry, res.GetString($"{entry.Tag}Description_{currentLanguage}"));
                LegendItems.Add(entry.Text);
            }
        }

        public PieChartSetup(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));

            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations ORDER BY YearName DESC").ToArray());
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            ((CheckBox)sender).Checked = true;
        }

        private void ColorPanel_DoubleClick(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            ((Panel)sender).BackColor = colorDialog.Color;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Build_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(YearOfCalculation))
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText1, MessageDialog.Icon.Alert);
            }
            else if (parts.Count == 0)
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText9, MessageDialog.Icon.Alert);
            }
            else
            {
                ChosenParts.Clear();
                
                for (int i = 0; i < parts.Count; i++)
                {
                    switch (parts[i])
                    {
                        case "wbpp":
                            ChosenParts.Add(PartOfCalculation.WaterBalanceProfit);
                            AddChosenColors(wbppColorPanels);
                            break;
                        case "wbcp":
                            ChosenParts.Add(PartOfCalculation.WaterBalanceConsumable);
                            AddChosenColors(wbcpColorPanels);
                            break;
                        case "sbpp":
                            ChosenParts.Add(PartOfCalculation.SaltBalanceProfit);
                            AddChosenColors(sbppColorPanels);
                            break;
                        case "sbcp":
                            ChosenParts.Add(PartOfCalculation.SaltBalanceConsumable);
                            AddChosenColors(sbcpColorPanels);
                            break;
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void AddChosenColors(Panel[] colorPanels)
        {
            Color[] colors = new Color[colorPanels.Length];

            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = colorPanels[i].BackColor;
            }

            ChosenColors.Add(colors);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            bool isPartExist = false;
           
            foreach (var entry in partsListBox.Items)
            {
                if (entry.Equals(tabControl.SelectedTab.Text))
                {
                    isPartExist = true;
                }
            }

            if (!isPartExist)
            {
                partsListBox.Items.Add(tabControl.SelectedTab.Text);
                parts.Add(tabControl.SelectedTab.Tag.ToString());
            }
            else
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText8, MessageDialog.Icon.Alert);
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (partsListBox.SelectedIndex != -1)
            {
                for (int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    if (tabControl.TabPages[i].Text.Equals(partsListBox.SelectedItem))
                    {
                        parts.Remove(tabControl.TabPages[i].Tag.ToString());
                        break;
                    }
                }

                partsListBox.Items.RemoveAt(partsListBox.SelectedIndex);
            }
        }

        private void YearsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            YearOfCalculation = yearsBox.SelectedItem.ToString();
        }

        private void PieChartSetup_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.LightGray), 11, 242, 322, 242);
        }

        private void PieChartSetup_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            new HelpForm("pieChartSetupText").Show();
        }

    }
}
