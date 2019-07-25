using CatlabuhApp.Data;
using CatlabuhApp.Data.Access;
using System;
using System.Windows.Forms;
using CatlabuhApp.UI.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using CatlabuhApp.Data.Models_v_2_0;
using System.Data.SQLite;

namespace CatlabuhApp.UI.UC
{
    public partial class CalculationViewUC : UserControl, IDataViewUC
    {
        private ComponentResourceManager res = new ComponentResourceManager(typeof(CalculationViewUC));
        private GatewayScheduleForm gatewayScheduleForm = new GatewayScheduleForm();
        
        public IDataAccess DataAccess { get; set; }

        #region Конструкторы
        public CalculationViewUC()
        {
            InitializeComponent();

            this.Load += CalculationViewUC_Load;
        }

        public CalculationViewUC(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;

            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations ORDER BY YearName DESC").ToArray());
            yearsBox.SelectedItem = yearsBox.Items[0];

            WaterBalanceProfitGrid_Load();
            WaterBalnceConsumableGrid_Load();
            SaltBalanceProfitGrid_Load();
            SaltBalanceConsumableGrid_Load();
            HighlightInputData();
        }

        #endregion

        private void CalculationViewUC_Load(object sender, EventArgs e)
        {
            HighlightInputData();
        }

        private void YearsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WBPGrid.DataSource = Calculation.GetView(DataAccess, Calculation.PartOfCalculation.WaterBalanceProfit, yearsBox.Text);
            WBCGrid.DataSource = Calculation.GetView(DataAccess, Calculation.PartOfCalculation.WaterBalanceConsumable, yearsBox.Text);
            SBPGrid.DataSource = Calculation.GetView(DataAccess, Calculation.PartOfCalculation.SaltBalanceProfit, yearsBox.Text);
            SBCGrid.DataSource = Calculation.GetView(DataAccess, Calculation.PartOfCalculation.SaltBalanceConsumable, yearsBox.Text);

            HighlightInputData();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            HighlightInputData();
        }

        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            new TablesToExportDialog().ShowDialog();
        }

        #region Настройка отображения таблиц расчета
        private void HighlightInputData()
        {
            Color inputDataColor = Color.FromArgb(255, 255, 128);

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < 12; i++)
                    {
                        WBPGrid[1, i].Style.BackColor = inputDataColor;
                        WBPGrid[2, i].Style.BackColor = inputDataColor;
                        WBPGrid[8, i].Style.BackColor = inputDataColor;
                        WBPGrid[15, i].Style.BackColor = inputDataColor;

                        WBCGrid[9, i].Style.BackColor = inputDataColor;
                        WBCGrid[1, i].Style.BackColor = inputDataColor;
                        WBCGrid[4, i].Style.BackColor = inputDataColor;
                        WBCGrid[11, i].Style.BackColor = inputDataColor;
                    }

                    WBPGrid[10, 12].Style.BackColor = inputDataColor;
                    WBPGrid[12, 12].Style.BackColor = inputDataColor;

                    break;
                case 1:
                    SBPGrid[4, 12].Style.BackColor = inputDataColor;
                    SBPGrid[6, 12].Style.BackColor = inputDataColor;
                    SBPGrid[9, 0].Style.BackColor = inputDataColor;

                    for (int i = 0; i < 12; i++)
                    {
                        SBPGrid[8, i].Style.BackColor = inputDataColor;
                        SBCGrid[4, i].Style.BackColor = inputDataColor;
                        SBCGrid[5, i].Style.BackColor = inputDataColor;
                    }

                    break;
            }
        }
        
        private void WaterBalanceProfitGrid_Load()
        {
            WBPGrid.DataSource = Calculation.GetView(DataAccess, Calculation.PartOfCalculation.WaterBalanceProfit, yearsBox.Text);

            for (int i = 1; i <= 5; i++)
            {
                WBPGrid.Columns[WBPGrid.Columns.Count - i].Visible = false;
            }

            string[] columnsName = {
                "H1", "H2", "avr_H", "W1", "W2", "dlt_W", "F", "P", "Vp", "Vr", "Vb", "Vg", "Vdr", "EP", "VD_plus", "Voz_plus", "dlt_Vni"
            };
            string[] toolTipTexts = {
                res.GetString("WBPGrid.Columns[1].ToolTipText"),
                res.GetString("WBPGrid.Columns[2].ToolTipText"),
                res.GetString("WBPGrid.Columns[3].ToolTipText"),
                res.GetString("WBPGrid.Columns[4].ToolTipText"),
                res.GetString("WBPGrid.Columns[5].ToolTipText"),
                res.GetString("WBPGrid.Columns[6].ToolTipText"),
                res.GetString("WBPGrid.Columns[7].ToolTipText"),
                res.GetString("WBPGrid.Columns[8].ToolTipText"),
                res.GetString("WBPGrid.Columns[9].ToolTipText"),
                res.GetString("WBPGrid.Columns[10].ToolTipText"),
                res.GetString("WBPGrid.Columns[11].ToolTipText"),
                res.GetString("WBPGrid.Columns[12].ToolTipText"),
                res.GetString("WBPGrid.Columns[13].ToolTipText"),
                res.GetString("WBPGrid.Columns[14].ToolTipText"),
                res.GetString("WBPGrid.Columns[15].ToolTipText"),
                res.GetString("WBPGrid.Columns[16].ToolTipText"),
                res.GetString("WBPGrid.Columns[17].ToolTipText")
            };

            WBPGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (int i = 1; i <= columnsName.Length; i++)
            {
                WBPGrid.Columns[i].Tag = columnsName[i - 1];
                WBPGrid.Columns[i].ToolTipText = toolTipTexts[i - 1];
                WBPGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                switch (i)
                {
                    case 1:
                    case 2:
                    case 3:
                        WBPGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure1");
                        break;
                    case 7:
                        WBPGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure2");
                        break;
                    case 8:
                        WBPGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure3");
                        break;
                    default:
                        WBPGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure4");
                        break;
                }
            }

        }

        private void WaterBalnceConsumableGrid_Load()
        {
            WBCGrid.DataSource = Calculation.GetView(DataAccess, Calculation.PartOfCalculation.WaterBalanceConsumable, yearsBox.Text);

            for (int i = 1; i <= 5; i++)
            {
                WBCGrid.Columns[WBCGrid.Columns.Count - i].Visible = false;
            }

            string[] columnsName = {
                "d", "lgd", "lgE", "E", "Etr", "VE", "Vtr", "Vf", "Vz", "ER", "VD_minus", "Voz_minus"
            };
            string[] toolTipTexts = {
                res.GetString("WBCGrid.Columns[1].ToolTipText"),
                res.GetString("WBCGrid.Columns[2].ToolTipText"),
                res.GetString("WBCGrid.Columns[3].ToolTipText"),
                res.GetString("WBCGrid.Columns[4].ToolTipText"),
                res.GetString("WBCGrid.Columns[5].ToolTipText"),
                res.GetString("WBCGrid.Columns[6].ToolTipText"),
                res.GetString("WBCGrid.Columns[7].ToolTipText"),
                res.GetString("WBCGrid.Columns[8].ToolTipText"),
                res.GetString("WBCGrid.Columns[9].ToolTipText"),
                res.GetString("WBCGrid.Columns[10].ToolTipText"),
                res.GetString("WBCGrid.Columns[11].ToolTipText"),
                res.GetString("WBCGrid.Columns[12].ToolTipText")
            };

            WBCGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (int i = 1; i <= columnsName.Length; i++)
            {
                WBCGrid.Columns[i].Tag = columnsName[i - 1];
                WBCGrid.Columns[i].ToolTipText = toolTipTexts[i - 1];
                WBCGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                switch (i)
                {
                    case 1:
                        WBCGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure5");
                        break;
                    case 2:
                    case 3:
                        WBCGrid.Columns[i].HeaderCell.Tag = "";
                        break;
                    case 4:
                    case 5:
                        WBCGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure3");
                        break;
                    default:
                        WBCGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure4");
                        break;
                }
            }
        }

        private void SaltBalanceProfitGrid_Load()
        {
            SBPGrid.DataSource = Calculation.GetView(DataAccess, Calculation.PartOfCalculation.SaltBalanceProfit, yearsBox.Text);

            for (int i = 1; i <= 5; i++)
            {
                SBPGrid.Columns[SBPGrid.Columns.Count - i].Visible = false;
            }

            string[] columnsName = {
                "W1", "W2", "Vp", "Vr", "Vb", "Vg", "Vdr", "VD_plus", "Voz_plus", "S1", "S2", "Sp", "Sr", "Sb",
                "Sg", "Sdr", "SD_plus", "Soz_plus", "C1", "C2", "Cp", "Cr", "Cb", "Cg", "Cdr", "CD_plus", "Coz_plus", "EpCi_plus"
            };
            string[] toolTipTexts = {
                res.GetString("WBPGrid.Columns[4].ToolTipText"),
                res.GetString("WBPGrid.Columns[5].ToolTipText"),
                res.GetString("WBPGrid.Columns[9].ToolTipText"),
                res.GetString("WBPGrid.Columns[10].ToolTipText"),
                res.GetString("WBPGrid.Columns[11].ToolTipText"),
                res.GetString("WBPGrid.Columns[12].ToolTipText"),
                res.GetString("WBPGrid.Columns[13].ToolTipText"),
                res.GetString("WBPGrid.Columns[15].ToolTipText"),
                res.GetString("WBPGrid.Columns[16].ToolTipText"),
                res.GetString("SBPGrid.Columns[9].ToolTipText"),
                res.GetString("SBPGrid.Columns[10].ToolTipText"),
                res.GetString("SBPGrid.Columns[11].ToolTipText"),
                res.GetString("SBPGrid.Columns[12].ToolTipText"),
                res.GetString("SBPGrid.Columns[13].ToolTipText"),
                res.GetString("SBPGrid.Columns[14].ToolTipText"),
                res.GetString("SBPGrid.Columns[15].ToolTipText"),
                res.GetString("SBPGrid.Columns[16].ToolTipText"),
                res.GetString("SBPGrid.Columns[17].ToolTipText"),
                res.GetString("SBPGrid.Columns[18].ToolTipText"),
                res.GetString("SBPGrid.Columns[19].ToolTipText"),
                res.GetString("SBPGrid.Columns[20].ToolTipText"),
                res.GetString("SBPGrid.Columns[21].ToolTipText"),
                res.GetString("SBPGrid.Columns[22].ToolTipText"),
                res.GetString("SBPGrid.Columns[23].ToolTipText"),
                res.GetString("SBPGrid.Columns[24].ToolTipText"),
                res.GetString("SBPGrid.Columns[25].ToolTipText"),
                res.GetString("SBPGrid.Columns[26].ToolTipText"),
                res.GetString("SBPGrid.Columns[27].ToolTipText"),
            };

            SBPGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (int i = 1; i <= columnsName.Length; i++)
            {
                SBPGrid.Columns[i].Tag = columnsName[i - 1];
                SBPGrid.Columns[i].ToolTipText = toolTipTexts[i - 1];
                SBPGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (i < 9)
                {
                    SBPGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure4");
                }
                else if (i < 17)
                {
                    SBPGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure6");
                }
                else
                {
                    SBPGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure7");
                }
            }
        }

        private void SaltBalanceConsumableGrid_Load()
        {
            SBCGrid.DataSource = Calculation.GetView(DataAccess, Calculation.PartOfCalculation.SaltBalanceConsumable, yearsBox.Text);

            for (int i = 1; i <= 5; i++)
            {
                SBCGrid.Columns[SBCGrid.Columns.Count - i].Visible = false;
            }

            string[] columnsName = {
                "VE", "Vtr", "Vf", "Vz", "VD_minus", "Voz_minus", "Sf", "Sz", "SD_minus", "Soz_minus", "Cf", "Cz", "CD_minus", "Coz_minus", "EpCi_minus"
            };
            string[] toolTipTexts = {
                res.GetString("WBCGrid.Columns[6].ToolTipText"),
                res.GetString("WBCGrid.Columns[7].ToolTipText"),
                res.GetString("WBCGrid.Columns[8].ToolTipText"),
                res.GetString("WBCGrid.Columns[9].ToolTipText"),
                res.GetString("WBCGrid.Columns[11].ToolTipText"),
                res.GetString("WBCGrid.Columns[12].ToolTipText"),
                res.GetString("SBCGrid.Columns[7].ToolTipText"),
                res.GetString("SBCGrid.Columns[8].ToolTipText"),
                res.GetString("SBCGrid.Columns[9].ToolTipText"),
                res.GetString("SBCGrid.Columns[10].ToolTipText"),
                res.GetString("SBCGrid.Columns[11].ToolTipText"),
                res.GetString("SBCGrid.Columns[12].ToolTipText"),
                res.GetString("SBCGrid.Columns[13].ToolTipText"),
                res.GetString("SBCGrid.Columns[14].ToolTipText"),
                res.GetString("SBCGrid.Columns[15].ToolTipText"),
            };

            SBCGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            for (int i = 1; i <= columnsName.Length; i++)
            {
                SBCGrid.Columns[i].Tag = columnsName[i - 1];
                SBCGrid.Columns[i].ToolTipText = toolTipTexts[i - 1];
                SBCGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (i < 7)
                {
                    SBCGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure4");
                }
                else if (i < 11)
                {
                    SBCGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure6");
                }
                else
                {
                    SBCGrid.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure7");
                }
            }
        }

        #endregion
        #region Контекстное меню и действия с данными таблиц расчета
        struct CellToChange
        {
            public string Column { get; set; }  // Название столбца в БД
            public string Value { get; set; }   // Новое значение
            public string ID { get; set; }      // ИД записи в БД
        }

        private List<CellToChange> cellsToChange = new List<CellToChange>();

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {   
            DataGridView dataGridView = (DataGridView)sender;

            CellToChange cell = new CellToChange()
            {
                Column = dataGridView.Columns[e.ColumnIndex].Tag.ToString(),
                Value =  dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                ID =     dataGridView[dataGridView.ColumnCount - 1, e.RowIndex].Value.ToString()
            };

            if (cellsToChange.Exists(x => x.ID.Equals(cell.ID)))
            {
                cellsToChange[cellsToChange.FindIndex(ind => ind.ID.Equals(cell.ID))] = cell;
            }
            else
            {
                cellsToChange.Add(cell);
            }
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            new MessageDialog("", "", MessageDialog.MessageIcon.Cross);
            e.ThrowException = false;
        }

        private void RecalculateMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void ShowGatewayShedule_Click(object sender, EventArgs e)
        {
            if (!gatewayScheduleForm.IsShown)
            {
                gatewayScheduleForm = new GatewayScheduleForm
                {
                    MainForm = Application.OpenForms[0]
                };
                gatewayScheduleForm.Show();
            }
        }

    }
}
