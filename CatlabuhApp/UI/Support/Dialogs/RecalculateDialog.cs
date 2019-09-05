using CatlabuhAppSupportHelp.UI.Help;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Dialogs
{
    public partial class RecalculateDialog : Form
    {
        public bool IsCalculateGS { get => gsByDates.Checked; } 
        public bool IsEnterGatewaySchedule { get => enterGS.Checked; }
        public bool IsCalculateE { get => byDeficit.Checked; }
        public bool IsSaltBalanceRecalculate { get; private set; }

        public RecalculateDialog()
        {
            Main.Forms.MainForm.GetCultureInfo();
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
            new HelpForm("recalculateText").Show();
        }

        private void RecalculateDialog_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.LightGray), 12, 280, 227, 40);
        }

        private void CalculateOnlySB_CheckedChanged(object sender, EventArgs e)
        {
            IsSaltBalanceRecalculate = calculateOnlySB.Checked;

            groupBox6.Enabled = !IsSaltBalanceRecalculate;
            gsGroupBox.Enabled = !IsSaltBalanceRecalculate;
        }
    }
}
