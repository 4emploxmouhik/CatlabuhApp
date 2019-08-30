using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

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

            SetPPercentPageStyle();
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
            for (int i = 0; i < coefficientsBoxes.Count; i++)
            {
                coefficientsBoxes[i].Text = coefficients[i].ToString();
            }
            for (int i = 0; i < 71; i++)
            {
                FHChart.Series[0].Points.AddXY(FHGrid.Rows[i].Cells[0].Value, FHGrid.Rows[i].Cells[1].Value);
            }

            for (int i = 0; i < coefficientsBoxes.Count; i++)
            {
                this.coefficients.Add(
                    new Item()
                    {
                        TextBox = coefficientsBoxes[i],
                        TableName = "Coefficients",
                        ColumnName = "CoefficientValue",
                        IDColumnName = "CoefficientID",
                        ID = (i + 1).ToString()
                    }
                );
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

        private void SetPPercentPageStyle()
        {
            chartsTabControl.TabPages[0].Text = "P(p%)";

            pPercentGrid.DataSource = DataAccess.GetTableView("SELECT Xp AS[P], Percent AS[p%], PointID FROM GammaDistribution");
            pPercentGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pPercentGrid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pPercentGrid.Columns[0].Tag = "Xp";
            pPercentGrid.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            pPercentGrid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pPercentGrid.Columns[1].Tag = "Percent";
            pPercentGrid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            pPercentGrid.Columns[2].Visible = false;
            pPercentGrid.DataError += DataGridView_DataError;

            for (int i = 0; i < 106; i++)
            {
                pPercentChart.Series[0].Points.AddXY(pPercentGrid.Rows[i].Cells[1].Value, pPercentGrid.Rows[i].Cells[0].Value);
            }

            pPercentChart.Series[0].LegendText = "P(p%)";
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

            FHChart.Series[0].LegendText = $"F({avrHView})";
            chartsTabControl.TabPages[1].Text = $"F({avrHView})";

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
            isFHChartPage = !isFHChartPage;
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
            if (isInitialized)
            {
                Item item = new Item()
                {
                    TableName = isFHChartPage ? "DependenceOfAvrHToF" : "GammaDistribution",
                    ColumnName = (isFHChartPage ? FHGrid.Columns[e.ColumnIndex].Tag : pPercentGrid.Columns[e.ColumnIndex].Tag).ToString(),
                    IDColumnName = "PointID",
                    ID = (isFHChartPage ? FHGrid.Rows[e.RowIndex].Cells[2].Value : pPercentGrid.Rows[e.RowIndex].Cells[2].Value).ToString(),
                    Value = (isFHChartPage ? FHGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value : pPercentGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).ToString(),
                    IsChanged = true
                };

                itemsToSaveInGrid.Add(item); Console.WriteLine(item.ToString());
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
