using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Main.Views;
using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MainForm()
        {
            InitializeComponent();

            DataAccess = new SQLiteDataAccess();

            calcView = new CalculationView(DataAccess) { Dock = DockStyle.Fill };
            chartView = new ChartView() { Dock = DockStyle.Fill };

        }

        private void Calculations_Click(object sender, EventArgs e)
        {
            Content = calcView;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // TODO: Сделать проверку, есть ли не сохраненные данные

            Application.Exit();
        }

        private void Charts_Click(object sender, EventArgs e)
        {
            Content = chartView;
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void ViewAbout_Click(object sender, EventArgs e)
        {

        }

        private void ViewHelp_Click(object sender, EventArgs e)
        {

        }






        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Size = {Size.ToString()} ContentSize = {contentPanel.Size.ToString()}");
        }
    }
}
