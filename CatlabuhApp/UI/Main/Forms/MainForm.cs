using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Main.Views;
using CatlabuhApp.UI.Support.Boxes;
using CatlabuhApp.UI.Support.Dialogs;
using CatlabuhAppSupportHelp.UI.Help;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
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

            var checkResult = DataAccess.CheckDB();

            if (checkResult.Result)
            {
                calcView = new CalculationView(DataAccess) { Dock = DockStyle.Fill };
                chartView = new ChartView(DataAccess) { Dock = DockStyle.Fill };
                settingsView = new SettingsView(DataAccess) { Parent = this, Dock = DockStyle.Fill };

                Content = new PictureBox()
                {
                    Image = (Image)new ComponentResourceManager(typeof(Properties.Resources)).GetObject("screensaver_" +
                        Properties.Settings.Default.Language.Substring(3)),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
            }
            else
            {
                MessageDialog.Show(MessageDialog.ErrorTitle, checkResult.Message, MessageDialog.Icon.Cross);
                throw new CatlabuhAppDBException();
            }
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
            calcView.Focus();
        }

        private void Charts_Click(object sender, EventArgs e)
        {
            Content = chartView;
            chartView.Focus();
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
            settingsView.Focus();
        }

        private void ViewAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void ViewHelp_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }

        private void HomePage_Click(object sender, EventArgs e)
        {
            Content = new PictureBox()
            {
                Image = (Image)new ComponentResourceManager(typeof(Properties.Resources)).GetObject("screensaver_" +
                    Properties.Settings.Default.Language.Substring(3)),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
        }

    }
}
