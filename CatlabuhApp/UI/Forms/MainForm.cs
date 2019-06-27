using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.UC;
using System;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Forms
{
    public partial class MainForm : BaseForm
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

                Height = Height - (contentPanel.Height - value.Height);
                                             
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

        public MainForm() : base()
        {
            DataAccess = new SQLiteDataAccess();

            calculationView = new CalculationViewUC(DataAccess);
            calculationCreate = new CalculationCreateUC(DataAccess);
            calculationSettings = new CalculationSettingsUC(DataAccess);
            chartView = new ChartViewUC(DataAccess);
            settingsView = new SettingsViewUC();

            InitializeComponent();
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
                case "createNewChart":
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

    }
}
