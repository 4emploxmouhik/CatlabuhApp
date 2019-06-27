using System.Windows.Forms.DataVisualization.Charting;

namespace CatlabuhApp.UI.Forms
{
    public partial class ShowChartForm : BaseForm
    {
        public Chart Chart
        {
            set
            {
                chartViewUC.Chart = value;
            }
        }

        public ShowChartForm() : base()
        {
            InitializeComponent();
            chartViewUC.SeparateMode = true;
        }
    }
}
