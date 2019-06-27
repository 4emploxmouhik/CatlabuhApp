using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatlabuhApp.Data.Access;
using System.Windows.Forms.DataVisualization.Charting;
using CatlabuhApp.UI.Forms;

namespace CatlabuhApp.UI.UC
{
    public partial class ChartViewUC : UserControl, IDataViewUC
    {
        public IDataAccess DataAccess { get; set; }
        public bool SeparateMode {
            set
            {
                createNewChart.Visible = !value;
                openInSeparateWindow.Visible = !value;
                toolStripSeparator1.Visible = !value;
            }
        }
        public Chart Chart {
            get
            {
                return chart;
            }
            set
            {
                chart = value;
            }
        }

        public ChartViewUC()
        {
            Dock = DockStyle.Fill;

            InitializeComponent();
        }

        public ChartViewUC(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;
        }

        private void openInSeparateWindow_Click(object sender, EventArgs e)
        {
            ShowChartForm separteWindow = new ShowChartForm() { Text = chart.Titles[0].Text, Chart = chart };
            separteWindow.Show();
        }
    }
}
