using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Support.Dialogs;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Setups
{
    partial class InputDataSetup
    {
        private async Task RunCalculateAsync()
        {
            Cursor = Cursors.WaitCursor;
            runCalculate.Enabled = false;

            await Task.Run(() => RunCalculate());

            parent.RefreshDGV();
            
            runCalculate.Enabled = true;
            Cursor = Cursors.Default;
            MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText1, MessageDialog.Icon.OK);
        }

        private void RunCalculate()
        {
            Calculation calc = !showGatewaySchedule.Checked ? new Calculation(DataAccess, FillInputData()) :
                new Calculation(DataAccess, FillInputData(), gsSetup.FillGatewaySchedule());

            calc.Calculate();

            if (!calc.IsExist)
            {
                calc.Save(false);
            }
            else
            {
                calc.Update();
            }
        }

        private async Task SaveInputDataAsync()
        {
            Cursor = Cursors.WaitCursor;
            saveInputData.Enabled = false;

            await Task.Run(() => SaveInputData());

            parent.RefreshDGV();
            parent.UpdateYearsBoxItems();

            yearsBox.Items.Clear();
            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations ORDER BY YearName DESC").ToArray());

            saveInputData.Enabled = true;
            Cursor = Cursors.Default;
            MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText2, MessageDialog.Icon.OK);
        }

        private void SaveInputData()
        {
            Calculation calc = new Calculation(DataAccess, FillInputData());

            if (!calc.IsExist)
            {
                calc.Save(true);

                if (showGatewaySchedule.Checked)
                {
                    gsSetup.FillGatewaySchedule().Save();
                }
            }
            else
            {
                FillInputData().Update();

                if (showGatewaySchedule.Checked)
                {
                    gsSetup.FillGatewaySchedule().Update();
                }
            }
        }
    }
}
