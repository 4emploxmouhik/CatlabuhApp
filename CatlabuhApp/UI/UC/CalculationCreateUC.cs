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


namespace CatlabuhApp.UI.UC
{
    public partial class CalculationCreateUC : UserControl, IDataViewUC
    {
        public IDataAccess DataAccess { get; set; }

        public CalculationCreateUC()
        {
            InitializeComponent();
        }

        public CalculationCreateUC(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;
            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>(Query.GetYearsList(false)).ToArray());
        }

    }
}
