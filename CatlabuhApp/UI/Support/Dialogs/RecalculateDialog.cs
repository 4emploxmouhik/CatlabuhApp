using System;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Dialogs
{
    public partial class RecalculateDialog : Form
    {
        public bool IsCalculateGS { get => gsByDates.Checked; } 
        public bool IsEnterGatewaySchedule { get => enterGS.Checked; }
        public bool IsCalculateE { get => byDeficit.Checked; }

        public RecalculateDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void RunCalculate_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void EnterGS_CheckedChanged(object sender, EventArgs e)
        {
            choiceGSCalculation.Enabled = enterGS.Checked ? true : false;
        }

        private void RecalculateDialog_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            // TODO: Вызвать окно справки.
        }

    }
}
