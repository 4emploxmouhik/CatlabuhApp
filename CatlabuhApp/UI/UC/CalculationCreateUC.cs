using CatlabuhApp.Data.Access;
using CatlabuhApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatlabuhApp.UI.Forms;

namespace CatlabuhApp.UI.UC
{
    public partial class CalculationCreateUC : UserControl, IDataViewUC
    {
        public IDataAccess DataAccess { get; set; }


        public CalculationCreateUC()
        {
            InitializeComponent();

            gatewaySheduleUC1.Enabled = toolStripButton1.Checked = false;

            toolStripButton1.Image = imageList.Images[1];
            gatewaySheduleUC1.Enabled = toolStripButton1.Checked;
        }

        public CalculationCreateUC(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;
            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>(Query.GetYearsList(false)).ToArray());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new GatewayScheduleForm().Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            toolStripButton1.Checked = !toolStripButton1.Checked;
            toolStripButton1.Image = toolStripButton1.Checked ? imageList.Images[0] : imageList.Images[1];
            gatewaySheduleUC1.Enabled = toolStripButton1.Checked;
        }
    }
}
