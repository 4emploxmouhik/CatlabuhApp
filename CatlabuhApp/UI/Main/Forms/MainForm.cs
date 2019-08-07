using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Main.Views;
using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Main.Forms
{
    public partial class MainForm : Form
    {
        private IDataAccess DataAccess { get; set; }
        private Control Content
        {
            get
            {
                return contentPanel.Controls.Count > 0 ? contentPanel.Controls[0] : null;
            }
            set
            {
                if (Content == value)
                {
                    return;
                }

                value.Dock = DockStyle.Fill;

                if (contentPanel.Controls.Count > 0)
                {
                    contentPanel.Controls.RemoveAt(0);
                }

                contentPanel.Controls.Add(value);
            }
        }

        private CalculationView calcView;
        private ChartView chartView;
        private SettingsView settingsView;

        public MainForm()
        {
            GetCultureInfo();
            InitializeComponent();
            
            DataAccess = new SQLiteDataAccess();

            calcView = new CalculationView(DataAccess) { Dock = DockStyle.Fill };
            chartView = new ChartView(DataAccess) { Dock = DockStyle.Fill };
            settingsView = new SettingsView() { Parent = this, Dock = DockStyle.Fill };
        }

        public static void GetCultureInfo()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }
        }

        private void Calculations_Click(object sender, EventArgs e)
        {
            Content = calcView;
        }

        private void Charts_Click(object sender, EventArgs e)
        {
            Content = chartView;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (!calcView.IsDataSaved)
            {
                MessageDialog md = new MessageDialog(MessageDialog.QuestionTitle, MessageDialog.QuestionText2, MessageDialog.Icon.Question);

                if (md.DialogResult == DialogResult.Yes)
                {
                    calcView.SaveData();
                }
                if (md.DialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Content = settingsView;
            settingsView.Update();
        }

        private void ViewAbout_Click(object sender, EventArgs e)
        {

        }

        private void ViewHelp_Click(object sender, EventArgs e)
        {

        }

    }
}
