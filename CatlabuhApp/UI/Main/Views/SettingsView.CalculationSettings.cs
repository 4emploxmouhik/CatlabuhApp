﻿using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CatlabuhApp.UI.Main.Views
{
    partial class SettingsView
    {
        private ComponentResourceManager res = new ComponentResourceManager(typeof(Properties.Resources));
        private string Language
        {
            get
            {
                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        return "EN";
                    case "uk-UA":
                        return "UA";
                    case "ru-RU":
                        return "RU";
                }
                return "";
            }
        }

        private bool isInitialized = false;
        private bool isItemsChanged = false;
        private List<TextBox> table_3_1Boxes = new List<TextBox>();
        private List<TextBox> table_3_2Boxes = new List<TextBox>();
        private List<TextBox> coefficientsBoxes = new List<TextBox>();

        private List<Item> coefficients = new List<Item>();
        private List<Item> table_3_1 = new List<Item>();
        private List<Item> table_3_2 = new List<Item>();

        private List<Item> itemsToSaveInGrid = new List<Item>();

        private bool isFHChartPage = false;

        private class Item
        {
            public TextBox TextBox { get; set; }
            public string TableName { get; set; }
            public string ColumnName { get; set; }
            public string IDColumnName { get; set; }
            public string ID { get; set; }
            public string Value { get => value; set => this.value = value.Replace(",", "."); }
            private string value = "";
            public bool IsChanged { get; set; } = false;

            public void UpdateItem(IDataAccess dataAccess)
            {
                dataAccess.Execute($"UPDATE {TableName} SET {ColumnName} = {value} WHERE {IDColumnName} = {ID}");
            }

            public override string ToString()
            {
                return $"TableName = {TableName}, ColumnName = {ColumnName}, IDColumnName = {IDColumnName}, Value = {value}, ID = {ID}, IsChanged = {IsChanged}";
            }
        }
        
        private void InitializeCalculationSettingsComponet()
        {
            string[] tablesColumnName = { "HighWaterLevel", "AverageWaterLevel", "LowWaterLevel" };

            double[,] table_3_1 = DataAccess.GetTableData<double>("IADOfSurfaceRunoff", 12, tablesColumnName);
            double[,] table_3_2 = DataAccess.GetTableData<double>("IADOfGroundwaterInflow", 12, tablesColumnName);
            double[] coefficients = DataAccess.GetColumnData<double>("SELECT CoefficientValue FROM Coefficients").ToArray();

            SetGammaDistributionGridStyle(1, pPercentGrid, pPercentChart);
            SetGammaDistributionGridStyle(2, kpPercentGrid, kpPercentChart);

            SetFHGridStyle();
            SetToolTips();

            for (int i = 0, k = 0; i < 3; i++)
            {
                for (int j = 0; j < 12; j++, k++)
                {
                    table_3_1Boxes[k].Text = table_3_1[i, j].ToString();
                    table_3_1Boxes[k].Tag = tablesColumnName[i];
                    table_3_2Boxes[k].Text = table_3_2[i, j].ToString();
                    table_3_2Boxes[k].Tag = tablesColumnName[i];
                }
            }

            for (int i = 0, k = 0; i < coefficientsBoxes.Count; i++)
            {
                if (i == 7 || i == 34)
                {
                    k++;
                }

                coefficientsBoxes[i].Text = coefficients[i + k].ToString();

                this.coefficients.Add( new Item()
                {
                    TextBox = coefficientsBoxes[i],
                    TableName = "Coefficients",
                    ColumnName = "CoefficientValue",
                    IDColumnName = "CoefficientID",
                    ID = (i + k + 1).ToString()
                });
            }

            for (int i = 0; i < 71; i++)
            {
                FHChart.Series[0].Points.AddXY(FHGrid.Rows[i].Cells[0].Value, FHGrid.Rows[i].Cells[1].Value);
            }

            bool isFirstTable = true;

        Start:
            for (int i = 0, id = 1; i < 36; i++, id++)
            {
                if (id == 13)
                {
                    id = 1;
                }

                Item item = new Item()
                {
                    TextBox = isFirstTable ? table_3_1Boxes[i] : table_3_2Boxes[i],
                    TableName = isFirstTable ? "IADOfSurfaceRunoff" : "IADOfGroundwaterInflow",
                    ColumnName = isFirstTable ? table_3_1Boxes[i].Tag.ToString() : table_3_2Boxes[i].Tag.ToString(),
                    IDColumnName = "ValueID",
                    ID = id.ToString()
                };

                if (isFirstTable)
                {
                    this.table_3_1.Add(item);
                }
                else
                {
                    this.table_3_2.Add(item);
                }

                if (i == 35 && isFirstTable)
                {
                    isFirstTable = false;
                    goto Start;
                }
            }

            isInitialized = true;
        }

        private void SaveCalculationSettings()
        {
            if (isItemsChanged)
            {
                Cursor = Cursors.WaitCursor;

                foreach (var entry in coefficients)
                {
                    if (entry.IsChanged)
                    {
                        entry.UpdateItem(DataAccess);
                    }
                }

                for (int i = 0; i < table_3_1.Count; i++)
                {
                    if (table_3_1[i].IsChanged)
                    {
                        table_3_1[i].UpdateItem(DataAccess);
                    }
                    if (table_3_2[i].IsChanged)
                    {
                        table_3_2[i].UpdateItem(DataAccess);
                    }
                }

                foreach (var entry in itemsToSaveInGrid)
                {
                    entry.UpdateItem(DataAccess);
                }

                Cursor = Cursors.Default;
                MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText3, MessageDialog.Icon.OK);
            }
        }

        private void SetFHGridStyle()
        {
            string avrHView;

            switch (Language)
            {
                case "EN":
                    avrHView = "avr. H";
                    break;
                default:
                    avrHView = "H cp.";
                    break;
            }

            chartsTabControl.TabPages[0].Text = $"F({avrHView})";
            FHChart.Series[0].LegendText = $"F({avrHView})";
            FHChart.ChartAreas[0].AxisX.Title = "F";
            FHChart.ChartAreas[0].AxisY.Title = avrHView;

            FHGrid.DataSource = DataAccess.GetTableView($"SELECT F, avr_H AS[{avrHView}], PointID FROM DependenceOfAvrHToF");
            FHGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FHGrid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FHGrid.Columns[0].Tag = "F";
            FHGrid.Columns[0].ToolTipText = res.GetString($"FDescription_{Language}");
            FHGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            FHGrid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            FHGrid.Columns[1].Tag = "avr_H";
            FHGrid.Columns[1].ToolTipText = res.GetString($"avr_HDescription_{Language}");
            FHGrid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            FHGrid.Columns[2].Visible = false;
            FHGrid.DataError += DataGridView_DataError;
        }

        private void SetGammaDistributionGridStyle(int tabPageIndex, DataGridView gridView, Chart chart)
        {
            chartsTabControl.TabPages[tabPageIndex].Text = tabPageIndex == 1 ? "P(p%)" : "kp(p%)";
            chart.ChartAreas[0].AxisX.Title = "p%";
            chart.ChartAreas[0].AxisY.Title = tabPageIndex == 1 ? "P" : "kp";

            gridView.DataSource = DataAccess.GetTableView($"SELECT {(tabPageIndex == 1 ? "Xp AS[P]" : "kp")}, Percent AS[p%], PointID FROM GammaDistribution");
            gridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns[0].Tag = tabPageIndex == 1 ? "Xp" : "kp";
            gridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            gridView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns[1].Tag = "Percent";
            gridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            gridView.Columns[2].Visible = false;
            gridView.DataError += DataGridView_DataError;

            for (int i = 0; i < 106; i++)
            {
                chart.Series[0].Points.AddXY(gridView.Rows[i].Cells[1].Value, gridView.Rows[i].Cells[0].Value);
            }

            chart.Series[0].LegendText = tabPageIndex == 1 ? "P(p%)" : "kp(p%)";
        }

        private void SetToolTips()
        {
            toolTip.SetToolTip(label32, res.GetString($"W1Description_{Language}") + "/\n" + 
                res.GetString($"W2Description_{Language}"));
            toolTip.SetToolTip(label9, res.GetString($"H1Description_{Language}") + " /\n" + 
                res.GetString($"H2Description_{Language}"));

            toolTip.SetToolTip(label33, res.GetString($"VbDescription_{Language}"));
            toolTip.SetToolTip(label10, res.GetString($"VrDescription_{Language}"));
            toolTip.SetToolTip(label34, res.GetString($"VdrDescription_{Language}"));
            toolTip.SetToolTip(label11, res.GetString($"VzDescription_{Language}"));
            toolTip.SetToolTip(label42, res.GetString($"SpDescription_{Language}"));
            toolTip.SetToolTip(label43, res.GetString($"SrDescription_{Language}"));
            toolTip.SetToolTip(label47, res.GetString($"SbDescription_{Language}"));
            toolTip.SetToolTip(label8, res.GetString($"SrDescription_{Language}"));
            toolTip.SetToolTip(label44, res.GetString($"SgDescription_{Language}"));
            toolTip.SetToolTip(label45, res.GetString($"SdrDescription_{Language}"));
            toolTip.SetToolTip(label46, res.GetString($"SD_plusDescription_{Language}"));
            toolTip.SetToolTip(label50, res.GetString($"SfDescription_{Language}"));
            toolTip.SetToolTip(label52, res.GetString($"SzDescription_{Language}"));
            toolTip.SetToolTip(label53, res.GetString($"SD_minusDescription_{Language}"));
            toolTip.SetToolTip(label51, res.GetString($"Soz_minusDescription_{Language}"));
            toolTip.SetToolTip(label49, res.GetString($"VtrDescription_{Language}"));
            toolTip.SetToolTip(label13, res.GetString($"EtrDescription_{Language}"));
            toolTip.SetToolTip(label14, res.GetString($"FDescription_{Language}"));
            toolTip.SetToolTip(label54, res.GetString($"VfDescription_{Language}"));
            toolTip.SetToolTip(label15, res.GetString($"avr_HDescription_{Language}"));
            toolTip.SetToolTip(label57, res.GetString($"EtrDescription_{Language}"));
            toolTip.SetToolTip(label58, res.GetString($"lgEDescription_{Language}"));
            toolTip.SetToolTip(label19, res.GetString($"lgdDescription_{Language}"));
        }

        #region Фиксация изменения в элементах настройки расчёта
        private void ChartsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            isFHChartPage = chartsTabControl.SelectedIndex == 0 ? true : false;
        }

        private void CoefficientBox_TextChanged(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                TextBox someBox = (TextBox)sender;

                Item item = coefficients.Find(x => x.TextBox.Name.Equals(someBox.Name));
                item.Value = someBox.Text;
                item.IsChanged = true;
                isItemsChanged = true;
            }
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView someGridView = (DataGridView)sender;

            if (isInitialized)
            {
                Item item = new Item()
                {
                    TableName = isFHChartPage ? "DependenceOfAvrHToF" : "GammaDistribution",
                    ColumnName = someGridView.Columns[e.ColumnIndex].Tag.ToString(),
                    IDColumnName = "PointID",
                    ID = someGridView.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Value = someGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                    IsChanged = true
                };

                itemsToSaveInGrid.Add(item);
                isItemsChanged = true;
            }
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText4, MessageDialog.Icon.Alert);
            e.ThrowException = false;
        }

        private void IADTableItem_TextChanged(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                TextBox someBox = (TextBox)sender;
                Item item;

                if (someBox.Parent == table_3_1Group)
                {
                    item = table_3_1.Find(x => x.TextBox.Name.Equals(someBox.Name));
                }
                else
                {
                    item = table_3_2.Find(x => x.TextBox.Name.Equals(someBox.Name));
                }

                item.Value = someBox.Text;
                item.IsChanged = true;
                isItemsChanged = true;
            }
        }

        #endregion

        
    }
}
