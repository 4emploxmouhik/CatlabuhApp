using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Support.Dialogs;
using System;
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
                Value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace(",", "."),
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
                    case 9:
                        cell.TableName = "InputData";
                        break;
                    case 16:
                    case 17:
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
                case "GatewaySchedule": shift = 4; break;
                case "OutputData": shift = 3; break;
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
                        wbpGrid[9, i].Style.BackColor = color;
                        wbpGrid[16, i].Style.BackColor = color;
                        wbpGrid[17, i].Style.BackColor = color;

                        wbcGrid[9, i].Style.BackColor = color;
                        wbcGrid[1, i].Style.BackColor = color;
                        wbcGrid[4, i].Style.BackColor = color;
                        wbcGrid[11, i].Style.BackColor = color;
                        wbcGrid[12, i].Style.BackColor = color;
                    }

                    wbpGrid[13, 12].Style.BackColor = color;
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
            string language = "";

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    language = "EN";
                    break;
                case "uk-UA":
                    language = "UA";
                    break;
                case "ru-RU":
                    language = "RU";
                    break;
            }

            for (int i = 1; i < dgv.ColumnCount - 5; i++)
            {
                dgv.Columns[i].Tag = dbColumnsName[i - 1];

                string resText = res.GetString($"{dgv.Columns[i].Tag}Description_{language}");

                dgv.Columns[i].ToolTipText = resText;

                if (dgv.Columns[i].Tag.Equals("lgd") || dgv.Columns[i].Tag.Equals("lgE"))
                {
                    continue;
                }
                else
                {
                    dgv.Columns[i].HeaderCell.Tag = resText.Substring(resText.IndexOf(',') + 2);
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
            Cursor = Cursors.WaitCursor;

            foreach (var entry in cellsToChange)
            {
                entry.UpdateValue();

                if ((entry.ColumnName == "S1") && (entry.RowIndex == 0))
                {
                    DataAccess.Execute($"UPDATE OtherData SET S1InJanuary = {entry.Value} WHERE YearName = {YearOfCalculation};" +
                        $"UPDATE OutputData SET S1 = {entry.Value} WHERE YearName = {YearOfCalculation} AND MonthID = 1;");
                }
            }

            cellsToChange.Clear();
            Cursor = Cursors.Default;
        }

        private void UpdateWaterLevel()
        {
            try
            {
                double sumPBolgrad = DataAccess.GetCellData<double>($"SELECT PBolgrad FROM InputData WHERE MonthID = 13 AND YearName = {YearOfCalculation}");

                OutputData outputData = new OutputData(DataAccess);
                outputData.GetWaterLevel(sumPBolgrad);
                outputData.GetWaterLevel(out OutputData.WaterLevel waterLevel, out int waterLevelPercent);

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        switch (waterLevel)
                        {
                            case OutputData.WaterLevel.High:
                                waterLevelBox.Text = $"Year of high water level, {waterLevelPercent}%";
                                break;
                            case OutputData.WaterLevel.Average:
                                waterLevelBox.Text = $"Year of average water level, {waterLevelPercent}%";
                                break;
                            case OutputData.WaterLevel.Low:
                                waterLevelBox.Text = $"Year of low water level, {waterLevelPercent}%";
                                break;
                        }
                        break;
                    case "uk-UA":
                        switch (waterLevel)
                        {
                            case OutputData.WaterLevel.High:
                                waterLevelBox.Text = $"Багатоводний рік, {waterLevelPercent}%";
                                break;
                            case OutputData.WaterLevel.Average:
                                waterLevelBox.Text = $"Середньоводний рік, {waterLevelPercent}%";
                                break;
                            case OutputData.WaterLevel.Low:
                                waterLevelBox.Text = $"Маловодний рік, {waterLevelPercent}%";
                                break;
                        }
                        break;
                    case "ru-RU":
                        switch (waterLevel)
                        {
                            case OutputData.WaterLevel.High:
                                waterLevelBox.Text = $"Многоводный год, {waterLevelPercent}%";
                                break;
                            case OutputData.WaterLevel.Average:
                                waterLevelBox.Text = $"Средневодный год, {waterLevelPercent}%";
                                break;
                            case OutputData.WaterLevel.Low:
                                waterLevelBox.Text = $"Маловодный год, {waterLevelPercent}%";
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                MessageDialog.Show(MessageDialog.ErrorTitle, MessageDialog.ErrorText6, MessageDialog.Icon.Cross);
            }
        }

    }
}
