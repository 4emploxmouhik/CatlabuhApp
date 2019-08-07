using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Support.Dialogs;
using System.Drawing;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Main.Views
{
    partial class CalculationView
    {
        private struct CellToChange
        {
            public string TableName { get; set; }
            public string ColumnName { get; set; }
            public string ID { get; set; }
            public string Value { get; set; }

            public int RowIndex { get; set; }

            public void UpdateValue()
            {
                DataAccess.Execute($"UPDATE {TableName} SET {ColumnName} = {Value} WHERE {TableName}ID = {ID};");
            }
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            CellToChange cell = new CellToChange()
            {
                ColumnName = dgv.Columns[e.ColumnIndex].Tag.ToString(),
                Value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                RowIndex = e.RowIndex
            };

            #region Определим к какой таблице в БД принадлежит ячейка.
            if (dgv.Name == wbpGrid.Name)
            {
                switch (e.ColumnIndex)
                {
                    case 1:
                    case 2:
                    case 8:
                        cell.TableName = "InputData";
                        break;
                    case 15:
                    case 16:
                        cell.TableName = "GatewaySchedule";
                        break;
                    default:
                        cell.TableName = "OutputData";
                        break;
                }
            }
            if (dgv.Name == wbcGrid.Name)
            {
                switch (e.ColumnIndex)
                {
                    case 1:
                    case 4:
                    case 9:
                        cell.TableName = "InputData";
                        break;
                    case 11:
                    case 12:
                        cell.TableName = "GatewaySchedule";
                        break;
                    default:
                        cell.TableName = "OutputData";
                        break;
                }
            }
            if (dgv.Name == sbpGrid.Name)
            {
                switch (e.ColumnIndex)
                {
                    case 8:
                    case 9:
                        cell.TableName = "GatewaySchedule";
                        break;
                    default:
                        cell.TableName = "OutputData";
                        break;
                }
            }
            if (dgv.Name == sbcGrid.Name)
            {
                switch (e.ColumnIndex)
                {
                    case 4:
                        cell.TableName = "InputData";
                        break;
                    case 5:
                    case 6:
                        cell.TableName = "GatewaySchedule";
                        break;
                    default:
                        cell.TableName = "OutputData";
                        break;
                }
            }

            #endregion

            int shift = 0;

            switch (cell.TableName)
            {
                case "InputData": shift = 5; break;
                case "GatewaySchedule": shift = 6; break;
                case "OutputData": shift = 7; break;
            }

            cell.ID = dgv.Rows[e.RowIndex].Cells[dgv.ColumnCount - shift].Value.ToString();

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
            MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText4, MessageDialog.Icon.Alert);
            e.ThrowException = false;
        }

        private void HighlightInputCellColor()
        {
            Color color = Color.FromArgb(255, 255, 128);

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < 12; i++)
                    {
                        wbpGrid[1, i].Style.BackColor = color;
                        wbpGrid[2, i].Style.BackColor = color;
                        wbpGrid[8, i].Style.BackColor = color;
                        wbpGrid[15, i].Style.BackColor = color;
                        wbpGrid[16, i].Style.BackColor = color;

                        wbcGrid[9, i].Style.BackColor = color;
                        wbcGrid[1, i].Style.BackColor = color;
                        wbcGrid[4, i].Style.BackColor = color;
                        wbcGrid[11, i].Style.BackColor = color;
                        wbcGrid[12, i].Style.BackColor = color;
                    }

                    wbpGrid[12, 12].Style.BackColor = color;
                    break;
                case 1:
                    for (int i = 0; i < 12; i++)
                    {
                        sbpGrid[8, i].Style.BackColor = color;
                        sbpGrid[9, i].Style.BackColor = color;
                        sbcGrid[4, i].Style.BackColor = color;
                        sbcGrid[5, i].Style.BackColor = color;
                        sbcGrid[6, i].Style.BackColor = color;
                    }

                    sbpGrid[6, 12].Style.BackColor = color;
                    sbpGrid[10, 0].Style.BackColor = color;
                    break;
            }
        }

        private void SetDGVStyle()
        {
            SetDGVStyle(wbpGrid);
            SetDGVStyle(wbcGrid);
            SetDGVStyle(sbpGrid);
            SetDGVStyle(sbcGrid);
        }

        private void SetDGVStyle(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.RowHeadersWidth = 30;
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.Columns[i].Width = (i == 0) ? 70 : (dgv.Width - dgv.Columns[0].Width - dgv.RowHeadersWidth) / (dgv.ColumnCount - 6);

                if ((dgv.Name == sbpGrid.Name) && (i == dgv.ColumnCount - 6))
                {
                    dgv.Columns[i].Width += 5;
                }

                if (i > dgv.ColumnCount - 6)
                {
                    dgv.Columns[i].Visible = false;
                }
            }
        }

        private void SetTagsAndToolTipsAtColumns(DataGridView dgv, Calculation.PartOfCalculation part)
        {
            string[] dbColumnsName = Calculation.GetDBColumnsName(part);
            string[] toolTips = null;

            switch (part)
            {
                case Calculation.PartOfCalculation.WaterBalanceProfit:
                    toolTips = new string[]
                    {
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
                    break;
                case Calculation.PartOfCalculation.WaterBalanceConsumable:
                    toolTips = new string[]
                    {
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
                    break;
                case Calculation.PartOfCalculation.SaltBalanceProfit:
                    toolTips = new string[]
                    {
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
                        res.GetString("SBPGrid.Columns[27].ToolTipText")
                    };
                    break;
                case Calculation.PartOfCalculation.SaltBalanceConsumable:
                    toolTips = new string[]
                    {
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
                        res.GetString("SBCGrid.Columns[15].ToolTipText")
                    };
                    break;
            }

            dgv.Columns[0].ToolTipText = toolTips[0];

            for (int i = 1; i < dgv.ColumnCount - 6; i++)
            {
                dgv.Columns[i].Tag = dbColumnsName[i - 1];
                dgv.Columns[i].ToolTipText = toolTips[i - 1];

                switch (part)
                {
                    case Calculation.PartOfCalculation.WaterBalanceProfit:
                        switch (i)
                        {
                            case 1:
                            case 2:
                            case 3:
                                dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure1");
                                break;
                            case 7:
                                dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure2");
                                break;
                            case 8:
                                dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure3");
                                break;
                            default:
                                dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure4");
                                break;
                        }
                        break;
                    case Calculation.PartOfCalculation.WaterBalanceConsumable:
                        switch (i)
                        {
                            case 1:
                                dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure5");
                                break;
                            case 2:
                            case 3:
                                dgv.Columns[i].HeaderCell.Tag = "";
                                break;
                            case 4:
                            case 5:
                                dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure3");
                                break;
                            default:
                                dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure4");
                                break;
                        }
                        break;
                    case Calculation.PartOfCalculation.SaltBalanceProfit:
                        if (i < 9)
                        {
                            dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure4");
                        }
                        else if (i < 17)
                        {
                            dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure6");
                        }
                        else
                        {
                            dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure7");
                        }
                        break;
                    case Calculation.PartOfCalculation.SaltBalanceConsumable:
                        if (i < 7)
                        {
                            dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure4");
                        }
                        else if (i < 11)
                        {
                            dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure6");
                        }
                        else
                        {
                            dgv.Columns[i].HeaderCell.Tag = res.GetString("measurementMeasure7");
                        }
                        break;
                }
            }
        }

        private void UpdateDataSource()
        {
            wbpGrid.DataSource = calc.WaterBalanceProfit;
            wbcGrid.DataSource = calc.WaterBalanceConsumable;
            sbpGrid.DataSource = calc.SaltBalanceProfit;
            sbcGrid.DataSource = calc.SaltBalanceConsumable;
        }

        public void RefreshDGV()
        {
            UpdateDataSource();
            SetDGVStyle();
            HighlightInputCellColor();
        }

        public void SaveData()
        {
            foreach (var entry in cellsToChange)
            {
                entry.UpdateValue();

                if ((entry.ColumnName == "S1") && (entry.RowIndex == 0))
                {
                    DataAccess.Execute($"UPDATE OtherData SET S1 = {entry.Value} WHERE YearName = {YearOfCalculation};");
                }
            }

            cellsToChange.Clear();
        }
    }
}
