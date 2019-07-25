using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CatlabuhApp.UI.Forms
{
    public partial class ShowChartForm : Form, IBaseView
    {
        public Chart Chart
        {
            set
            {
                chartViewUC.Chart = value;
            }
        }

        public ShowChartForm()
        {
            GetCultureInfo();
            InitializeComponent();
            chartViewUC.SeparateMode = true;
        }

        public void GetCultureInfo()
        {
            new BaseView().GetCultureInfo();
        }
    }
}
