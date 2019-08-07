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
                Cursor = Cursors.AppStarting;
                recalculate.Enabled = false;

                await Task.Run(() => Recalculate(rd));

                recalculate.Enabled = true;
                Cursor = Cursors.Default;
                MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText1, MessageDialog.Icon.OK);
                RefreshDGV();
            }
        }

        private void Recalculate(RecalculateDialog rd)
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
        }
    }
}
