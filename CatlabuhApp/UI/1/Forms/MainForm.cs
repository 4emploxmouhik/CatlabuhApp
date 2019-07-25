using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.UC;
using System;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Forms
{
    public partial class MainForm : Form, IBaseView
    {
        public Control Content
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

                //Height = Height - (contentPanel.Height - value.Height);
                value.Dock = DockStyle.Fill;

                if (contentPanel.Controls.Count > 0)
                {
                    contentPanel.Controls.RemoveAt(0);
                }

                contentPanel.Controls.Add(value);
            }
        }
        private IDataAccess DataAccess { get; set; }

        private CalculationViewUC calculationView;
        private CalculationCreateUC calculationCreate;
        private CalculationSettingsUC calculationSettings;
        private ChartViewUC chartView;
        private SettingsViewUC settingsView;

        public MainForm()
        {
            GetCultureInfo();
            InitializeComponent();
            contentPanel.Dock = DockStyle.Fill;

            DataAccess = new SQLiteDataAccess();

            calculationView = new CalculationViewUC(DataAccess);
            calculationCreate = new CalculationCreateUC(DataAccess);
            //calculationSettings = new CalculationSettingsUC(DataAccess);
            //chartView = new ChartViewUC(DataAccess);
            settingsView = new SettingsViewUC();

            Content = calculationView;
        }
        
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            switch (menuItem.Name)
            {
                case "createNewCalculation":
                    Content = calculationCreate;
                    break;
                case "viewCalculations":
                    Content = calculationView;
                    break;
                case "viewCalculationSettings":
                    Content = calculationSettings;
                    break;
                case "charts":
                    Content = chartView;
                    break;
                case "settings":
                    Content = settingsView;
                    break;
                case "viewHelp":
                    new HelpForm().Show();
                    break;
                case "viewAbout":
                    new AboutForm().ShowDialog();
                    break;
                case "exit":
                    // TODO: добавить проверку не сохраненных изменений
                    Application.Exit();
                    break;
            }

            contentPanel.BackColor = BackColor;
        }

        public void GetCultureInfo()
        {
            new BaseView().GetCultureInfo();
        }
    }
}
