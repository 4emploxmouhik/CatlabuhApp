using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Support.Dialogs;
using CatlabuhAppSupportHelp.UI.Help;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Main.Views
{
    public partial class SettingsView : UserControl
    {
        public IDataAccess DataAccess { get; private set; }

        #region Поля для общих настроеек
        private string[] descriptions =
        {
            "Select the folder where you want to save the Excel calculation files.",
            "Select the folder where you want to save the Excel chart files.",
            "Select the folder where you want to save the chart image files.",

            "Виберіть папку, в яку потрібно зберегти файли розрахунків Excel.",
            "Виберіть папку, в яку потрібно зберегти файли діаграм Excel.",
            "Виберіть папку, в яку потрібно зберегти файли зображень діаграми.",

            "Выберите папку, в которую вы хотите сохранить файлы расчётов Excel.",
            "Выберите папку, в которую вы хотите сохранить файлы диаграмм Excel.",
            "Выберите папку, в которую вы хотите сохранить файлы изображений диаграммы."
        };
        private int descriptionShift = 0;
        private string oldLanguage = Properties.Settings.Default.Language;
        private string newLanguage = "";
        private bool IsLanguageChanged = false;
        private string msg;
        private string oldDBPath;

        #endregion

        public SettingsView()
        {
            Forms.MainForm.GetCultureInfo();
            InitializeComponent();

            apply.Click += Apply_Click;

            table_3_1Boxes.AddRange(new TextBox[] {
                table_3_1ItemBox0, table_3_1ItemBox1, table_3_1ItemBox2, table_3_1ItemBox3, table_3_1ItemBox4, table_3_1ItemBox5, table_3_1ItemBox6, table_3_1ItemBox7,
                table_3_1ItemBox8, table_3_1ItemBox9, table_3_1ItemBox10, table_3_1ItemBox11, table_3_1ItemBox12, table_3_1ItemBox13, table_3_1ItemBox14, table_3_1ItemBox15,
                table_3_1ItemBox16, table_3_1ItemBox17, table_3_1ItemBox18, table_3_1ItemBox19, table_3_1ItemBox20, table_3_1ItemBox21, table_3_1ItemBox22, table_3_1ItemBox23,
                table_3_1ItemBox24, table_3_1ItemBox25, table_3_1ItemBox26, table_3_1ItemBox27, table_3_1ItemBox28, table_3_1ItemBox29, table_3_1ItemBox30, table_3_1ItemBox31,
                table_3_1ItemBox32, table_3_1ItemBox33, table_3_1ItemBox34, table_3_1ItemBox35
            });
            table_3_2Boxes.AddRange(new TextBox[] {
                table_3_2ItemBox0, table_3_2ItemBox1, table_3_2ItemBox2, table_3_2ItemBox3, table_3_2ItemBox4, table_3_2ItemBox5, table_3_2ItemBox6, table_3_2ItemBox7,
                table_3_2ItemBox8, table_3_2ItemBox9, table_3_2ItemBox10, table_3_2ItemBox11, table_3_2ItemBox12, table_3_2ItemBox13, table_3_2ItemBox14, table_3_2ItemBox15,
                table_3_2ItemBox16, table_3_2ItemBox17, table_3_2ItemBox18, table_3_2ItemBox19, table_3_2ItemBox20, table_3_2ItemBox21, table_3_2ItemBox22, table_3_2ItemBox23,
                table_3_2ItemBox24, table_3_2ItemBox25, table_3_2ItemBox26, table_3_2ItemBox27, table_3_2ItemBox28, table_3_2ItemBox29, table_3_2ItemBox30, table_3_2ItemBox31,
                table_3_2ItemBox32, table_3_2ItemBox33, table_3_2ItemBox34, table_3_2ItemBox35
            });
            coefficientsBoxes.AddRange(new TextBox[] {
                coefficientBox0, coefficientBox1, coefficientBox2, coefficientBox3, coefficientBox4, coefficientBox5, coefficientBox6, coefficientBox7, coefficientBox8,
                coefficientBox9, coefficientBox10, coefficientBox11, coefficientBox12, coefficientBox13, coefficientBox14, coefficientBox15, coefficientBox16, coefficientBox17,
                coefficientBox18, coefficientBox19, coefficientBox20, coefficientBox21, coefficientBox22, coefficientBox23, coefficientBox24, coefficientBox25, coefficientBox26,
                coefficientBox27, coefficientBox28, coefficientBox29, coefficientBox30, coefficientBox31, coefficientBox32, coefficientBox33, coefficientBox34
            });
        }

        public SettingsView(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
            InitializeCalculationSettingsComponet();
        }

        public new void Update()
        {
            base.Update();
            SettingsViewLoad();
        }

        private void SettingsViewLoad()
        {
            xlCalcPathBox.Text = Properties.Settings.Default.CalculationsDirectoryPath;
            xlChartsPathBox.Text = Properties.Settings.Default.ChartsExcelFilesDirectoryPath;
            imgChartsPathBox.Text = Properties.Settings.Default.ChartsImagesDirectoryPath;
            dbPathBox.Text = oldDBPath = Properties.Settings.Default.DBPath;

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    languageBox.SelectedItem = languageBox.Items[0];
                    msg = "To save and apply the settings, the application will be restarted.";
                    break;
                case "uk-UA":
                    languageBox.SelectedItem = languageBox.Items[1];
                    msg = "Щоб зберегти та застосувати налаштування, програма буде перезапущена.";
                    descriptionShift = 3;
                    break;
                case "ru-RU":
                    languageBox.SelectedItem = languageBox.Items[2];
                    msg = "Чтобы сохранить и применить настройки, приложение будет перезапущено.";
                    descriptionShift = 6;
                    break;
            }
        }

        private void SettingsView_Load(object sender, EventArgs e)
        {
            SettingsViewLoad();   
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    SaveGeneralSettings();
                    break;
                case 1:
                    SaveCalculationSettings();
                    break;
            }
        }

        private void SaveGeneralSettings()
        {
            if (xlCalcPathBox.Text.Length == 0 || xlChartsPathBox.Text.Length == 0 || imgChartsPathBox.Text.Length == 0)
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText7, MessageDialog.Icon.Cross);
            }
            else
            {
                Properties.Settings.Default.CalculationsDirectoryPath = xlCalcPathBox.Text + (xlCalcPathBox.Text.EndsWith("\\") ? "" : "\\");
                Properties.Settings.Default.ChartsExcelFilesDirectoryPath = xlChartsPathBox.Text + (xlChartsPathBox.Text.EndsWith("\\") ? "" : "\\");
                Properties.Settings.Default.ChartsImagesDirectoryPath = imgChartsPathBox.Text + (imgChartsPathBox.Text.EndsWith("\\") ? "" : "\\");

                CallAppCofnigChanger();

                if (IsLanguageChanged)
                {
                    MessageDialog md = new MessageDialog(MessageDialog.QuestionTitle, msg, MessageDialog.Icon.Alert);

                    if (md.DialogResult == DialogResult.OK)
                    {
                        Properties.Settings.Default.Language = newLanguage;
                        Properties.Settings.Default.Save();
                        Application.Restart();
                    }
                }
                else
                {
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void CallAppCofnigChanger()
        {
            if (!dbPathBox.Text.Equals(oldDBPath))
            {
                MessageDialog md = new MessageDialog(MessageDialog.QuestionTitle, msg, MessageDialog.Icon.Alert);

                if (md.DialogResult == DialogResult.OK)
                {
                    Properties.Settings.Default.DBPath = dbPathBox.Text;

                    try
                    {
                        using (Process appConfigChanger = new Process())
                        {
                            appConfigChanger.StartInfo.UseShellExecute = false;
                            appConfigChanger.StartInfo.CreateNoWindow = false;
                            appConfigChanger.StartInfo.FileName = $@"{Directory.GetCurrentDirectory()}\AppConfigurationChanger.exe";
                            appConfigChanger.StartInfo.Arguments =
                                $"{ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath} " +
                                $@"{Properties.Settings.Default.DBPath}";
                            appConfigChanger.Start();
                        }
                        Application.Exit();
                    }
                    catch (Exception) { }
                }
            }
        }

        private void CalculationPage_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.LightGray);

            g.DrawLine(pen, 6, 302, 787, 302);
            g.DrawLine(pen, 787, 176, 787, 616);
        }

        private void CallFolderBrowser_Click(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(((Button)sender).Tag);

            folderBrowserDialog.Description = descriptions[tag + descriptionShift];
            folderBrowserDialog.ShowDialog();

            switch (tag)
            {
                case 0:
                    xlCalcPathBox.Text = folderBrowserDialog.SelectedPath;
                    break;
                case 1:
                    xlChartsPathBox.Text = folderBrowserDialog.SelectedPath;
                    break;
                case 2:
                    imgChartsPathBox.Text = folderBrowserDialog.SelectedPath;
                    break;
            }
        }

        private void CallOpenFileDialog_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            dbPathBox.Text = (openFileDialog.FileName == "openFileDialog") ? oldDBPath : openFileDialog.FileName;
        }

        private void LanguageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (languageBox.SelectedItem)
            {
                case "English":
                    newLanguage = "en-US";
                    break;
                case "Українська":
                    newLanguage = "uk-UA";
                    break;
                case "Русский":
                    newLanguage = "ru-RU";
                    break;
            }

            if (oldLanguage != newLanguage)
            {
                IsLanguageChanged = true;
            }
            else
            {
                IsLanguageChanged = false;
            }
        }

        #region Обработчики текстовых полей
        private void TextBox_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (((e.KeyChar == '-') && !textBox.Text.Contains("-")) || ((e.KeyChar == ',') && !textBox.Text.Contains(",")))
            {
                return;
            }
            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        #endregion

        private void SettingsView_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            new HelpForm("settingsText").Show();
        }

    }
}
