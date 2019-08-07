using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Main.Views
{
    public partial class SettingsView : UserControl
    {
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
        int descriptionShift = 0;

        string oldLanguage = Properties.Settings.Default.Language;
        bool IsLanguageChanged = false;
        string msg;

        public SettingsView()
        {
            Forms.MainForm.GetCultureInfo();
            InitializeComponent();
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

        private void LanguageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (languageBox.SelectedItem)
            {
                case "English":
                    Properties.Settings.Default.Language = "en-US";
                    break;
                case "Українська":
                    Properties.Settings.Default.Language = "uk-UA";
                    break;
                case "Русский":
                    Properties.Settings.Default.Language = "ru-RU";
                    break;
            }

            if (oldLanguage != Properties.Settings.Default.Language)
            {
                IsLanguageChanged = true;
            }
            else
            {
                IsLanguageChanged = false;
            }
        }

        private void Apply_Click(object sender, EventArgs e)
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

                if (IsLanguageChanged)
                {
                    MessageDialog md = new MessageDialog(MessageDialog.QuestionTitle, msg, MessageDialog.Icon.Alert);

                    if (md.DialogResult == DialogResult.OK)
                    {
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

       
    }
}
