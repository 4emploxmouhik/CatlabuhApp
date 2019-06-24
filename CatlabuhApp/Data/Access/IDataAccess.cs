using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CatlabuhApp.Data.Access
{
    interface IDataAccess
    {
        T GetCellData<T>(string sql);
        List<T> GetColumnData<T>(string sql);
        DataTable GetTableView(string sql);
        T[,] GetTableData<T>(string table, int rowsCount, string[] columns);
        void FillComboBox(string sql, out ComboBox comboBox, string displayMember, string valueMemeber);
        void Execute(string sql);
    }
}
