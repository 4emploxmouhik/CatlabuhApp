using CatlabuhApp.Data;
using CatlabuhApp.Data.Access;
using System;
using System.Windows.Forms;
using CatlabuhApp.UI.Forms;

namespace CatlabuhApp.UI.UC
{
    public partial class CalculationViewUC : UserControl, IDataViewUC
    {
        public IDataAccess DataAccess { get; set; }

        public CalculationViewUC()
        {
            InitializeComponent();
        }

        public CalculationViewUC(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;

            InitializeGridViews();
            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>(Query.GetYearsList(false)).ToArray());
        }

        private void InitializeGridViews()
        {
            #region Водный баланс прибыльная часть

            waterBalanceProfitGrid.DataSource = DataAccess.GetTableView(Query.GetWaterBalanceProfitView("1980"));
            waterBalanceProfitGrid.Columns[waterBalanceProfitGrid.Columns.Count - 1].Visible = false;
            waterBalanceProfitGrid.Columns[waterBalanceProfitGrid.Columns.Count - 2].Visible = false;

            #endregion
            #region Водный баланс убыточная часть

            waterBalnceConsumableGrid.DataSource = DataAccess.GetTableView(Query.GetWaterBalanceConsumableView("1980"));
            waterBalnceConsumableGrid.Columns[waterBalnceConsumableGrid.Columns.Count - 1].Visible = false;
            waterBalnceConsumableGrid.Columns[waterBalnceConsumableGrid.Columns.Count - 2].Visible = false;

            #endregion
            #region Солевой баланс прибыльная часть

            saltBalanceProfitGrid.DataSource = DataAccess.GetTableView(Query.GetSaltBalanceProfitView("1980"));
            saltBalanceProfitGrid.Columns[saltBalanceProfitGrid.Columns.Count - 1].Visible = false;
            saltBalanceProfitGrid.Columns[saltBalanceProfitGrid.Columns.Count - 2].Visible = false;

            #endregion
            #region Солевой баланс убыточная часть

            saltBalanceConsumableGrid.DataSource = DataAccess.GetTableView(Query.GetSaltBalanceConsumableView("1980"));
            saltBalanceConsumableGrid.Columns[saltBalanceConsumableGrid.Columns.Count - 1].Visible = false;
            saltBalanceConsumableGrid.Columns[saltBalanceConsumableGrid.Columns.Count - 2].Visible = false;

            #endregion
        }

        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            new ChooseTablesToExportForm().ShowDialog();
        }
    }
}
