using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Support.Dialogs;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Main.Views
{
    partial class CalculationView
    {
        private async Task RecalculateAsync()
        {
            RecalculateDialog rd = new RecalculateDialog();
            rd.ShowDialog();

            if (rd.DialogResult == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                recalculate.Enabled = false;

                if (await Task.Run(() => Recalculate(rd)))
                {
                    MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText1, MessageDialog.Icon.OK);
                    RefreshDGV();
                }

                recalculate.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private bool Recalculate(RecalculateDialog rd)
        {
            try
            {
                Calculation calc = null;
                InputData inputData = new InputData(DataAccess, YearOfCalculation)
                {
                    IsCalculateE = rd.IsCalculateE
                };

                if (!rd.IsEnterGatewaySchedule)
                {
                    calc = new Calculation(DataAccess, inputData);
                }
                else
                {
                    GatewaySchedule gs = new GatewaySchedule(DataAccess, YearOfCalculation)
                    {
                        IsEnterGatewaySchedule = rd.IsEnterGatewaySchedule,
                        IsCalculateGS = rd.IsCalculateGS
                    };
                    calc = new Calculation(DataAccess, inputData, gs);
                }

                calc.Calculate();
                calc.Update();

                return true;
            }
            catch (System.NullReferenceException)
            {
                MessageDialog.Show(MessageDialog.ErrorTitle, MessageDialog.ErrorText6, MessageDialog.Icon.Cross);
                return false;
            }
            catch (System.Data.SQLite.SQLiteException)
            {
                MessageDialog.Show(MessageDialog.ErrorTitle, MessageDialog.ErrorText6, MessageDialog.Icon.Cross);
                return false;
            }
        }
    }
}
