using CatlabuhApp.Data.Access;
using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Support.Dialogs;
using CatlabuhApp.UI.Support.Setups;
using CatlabuhAppSupportHelp.UI.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Main.Views
{
    public partial class CalculationView : UserControl
    {
        private ComponentResourceManager res = new ComponentResourceManager(typeof(Properties.Resources));
        public static IDataAccess DataAccess { get; private set; }

        private GatewayScheduleSetup gsSetup;
        private InputDataSetup inputSetup;
        private Calculation calc;

        private List<CellToChange> cellsToChange = new List<CellToChange>();
        public bool IsDataSaved
        {
            get
            {
                if (cellsToChange.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public CalculationView()
        {
            Forms.MainForm.GetCultureInfo();
            InitializeComponent();

            wbpGrid.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            wbcGrid.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            sbpGrid.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
            sbcGrid.DataError += new DataGridViewDataErrorEventHandler(DataGridView_DataError);
        }

        public CalculationView(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;
            
            gsSetup = new GatewayScheduleSetup(DataAccess);
            inputSetup = new InputDataSetup();
            calc = new Calculation(DataAccess);

            UpdateYearsBoxItems();
            UpdateDataSource();
            SetDGVStyle();
            HighlightInputCellColor();

            SetTagsAndToolTipsAtColumns(wbpGrid, Calculation.PartOfCalculation.WaterBalanceProfit);
            SetTagsAndToolTipsAtColumns(wbcGrid, Calculation.PartOfCalculation.WaterBalanceConsumable);
            SetTagsAndToolTipsAtColumns(sbpGrid, Calculation.PartOfCalculation.SaltBalanceProfit);
            SetTagsAndToolTipsAtColumns(sbcGrid, Calculation.PartOfCalculation.SaltBalanceConsumable);
        }

        private void CalculationView_SizeChanged(object sender, EventArgs e)
        {
            SetDGVStyle();
            HighlightInputCellColor();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDGVStyle();
            HighlightInputCellColor();
        }

        #region Обработчики кнопок панели инструментов
        private void CreateNewCalculation_Click(object sender, EventArgs e)
        {
            if (!inputSetup.IsShown)
            {
                inputSetup = new InputDataSetup(DataAccess, this);
                inputSetup.Show();
            }
        }

        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            new TablesToExportDialog(new DataGridView[] { wbpGrid, wbcGrid, sbpGrid, sbcGrid }, YearOfCalculation)
                .ShowDialog();
        }

        private void ShowGatewaySchedule_Click(object sender, EventArgs e)
        {
            showGatewaySchedule.Checked = !gsSetup.IsShown;

            if (showGatewaySchedule.Checked)
            {
                gsSetup = new GatewayScheduleSetup(DataAccess, this)
                {
                    YearOfCalculation = YearOfCalculation
                };
                gsSetup.LoadScheduleData();
                gsSetup.Show();
            }
            else
            {
                gsSetup.Close();
            }
        }

        #endregion
        #region Обработчики кнопок контексного меню

        private void Delete_Click(object sender, EventArgs e)
        {
            MessageDialog md = new MessageDialog(MessageDialog.QuestionTitle, MessageDialog.QuestionText1, MessageDialog.Icon.Question);

            if (md.DialogResult == DialogResult.Yes)
            {
                calc.YearOfCalculation = YearOfCalculation;
                calc.Delete();

                UpdateYearsBoxItems();
                UpdateDataSource();
                HighlightInputCellColor();
            }
        }

        private void Recalculate_Click(object sender, EventArgs e)
        {
            MessageDialog md;

            md = new MessageDialog(MessageDialog.QuestionTitle, MessageDialog.QuestionText3, MessageDialog.Icon.Question);

            if (md.DialogResult == DialogResult.Yes)
            {
                if (YearOfCalculation == null || YearOfCalculation.Length == 0)
                {
                    MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText1, MessageDialog.Icon.Alert);
                    goto Exit;
                }
                else if (cellsToChange.Count > 0)
                {
                    md = new MessageDialog(MessageDialog.QuestionTitle, MessageDialog.QuestionText2, MessageDialog.Icon.Question);

                    switch (md.DialogResult)
                    {
                        case DialogResult.Yes:
                            SaveData();
                            MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText3, MessageDialog.Icon.OK);
                            goto case DialogResult.No;
                        case DialogResult.No:
                            goto Recalculate;
                        case DialogResult.Cancel:
                            goto Exit;
                    }
                }
            Recalculate:
                RecalculateAsync();
            }
        Exit:;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText3, MessageDialog.Icon.OK);
        }

        #endregion

        private void CalculationView_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            new HelpForm("viewCalcText", "createCalcText", "recalculateText", "saveChangesText", "deleteCalcText", "exportCalcText").Show();
        }
    }
}
