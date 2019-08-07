using CatlabuhApp.UI.Support.Dialogs;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Setups
{
    partial class GatewayScheduleSetup
    {
        private async Task SaveScheduleAsync()
        {
            await Task.Run(() => SaveSchedule());

            if (parent != null)
            {
                if (parent.YearOfCalculation == YearOfCalculation)
                {
                    parent.RefreshDGV();
                }
            }

            Cursor = Cursors.Default;
            MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText6, MessageDialog.Icon.OK);
        }

        private void SaveSchedule()
        {
            FillGatewaySchedule().Update();
        }

    }

}
