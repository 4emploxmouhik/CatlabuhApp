using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatlabuhApp.Data.Models;
using CatlabuhApp.Data.Access;
using CatlabuhApp.UI.Support.Setups;
using CatlabuhApp.UI.Support.Dialogs;

namespace CatlabuhApp.UI.Main.Views
{
    public partial class CalculationView : UserControl
    {
        public IDataAccess DataAccess { get; private set; }

        private GatewayScheduleSetup gsSetup;
        private InputDataSetup inputSetup;

        private string YearOfCalculation { get => yearsBox.Text; }
        private Calculation calc;

        public CalculationView()
        {
            InitializeComponent();
        }

        public CalculationView(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;

            gsSetup = new GatewayScheduleSetup(DataAccess);
            inputSetup = new InputDataSetup();

            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations").ToArray());
            yearsBox.SelectedText = yearsBox.Items[0].ToString();

            calc = new Calculation(DataAccess)
            {
                YearOfCalculation = (string)yearsBox.Items[0]
            };

            wbpGrid.DataSource = calc.WaterBalanceProfit;
            wbcGrid.DataSource = calc.WaterBalanceConsumable;
            sbpGrid.DataSource = calc.SaltBalanceProfit;
            sbcGrid.DataSource = calc.SaltBalanceConsumable;

            DataGridViewStyling(wbpGrid);
            DataGridViewStyling(wbcGrid);
            DataGridViewStyling(sbpGrid);
            DataGridViewStyling(sbcGrid);
        }


        private void CalculationView_Load(object sender, EventArgs e)
        {
            HighlightInputData();
        }

        private void CalculationView_SizeChanged(object sender, EventArgs e)
        {
            DataGridViewStyling(wbpGrid);
            DataGridViewStyling(wbcGrid);
            DataGridViewStyling(sbpGrid);
            DataGridViewStyling(sbcGrid);

            HighlightInputData();
        }

        #region Таблицы расчета(данные и стиль)
        private void DataGridViewStyling(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.RowHeadersWidth = 30;
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.Columns[i].Width = (i == 0) ? 75 : (dgv.Width - dgv.Columns[0].Width - dgv.RowHeadersWidth) / (dgv.ColumnCount - 6);

                if (dgv.Name == sbpGrid.Name && i == dgv.ColumnCount - 6)
                {
                    dgv.Columns[i].Width += 5;
                }

                if (i > dgv.ColumnCount - 6)
                {
                    dgv.Columns[i].Visible = false;
                }
            }
        }

        private void HighlightInputData()
        {
            Color inputDataColor = Color.FromArgb(255, 255, 128);

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < 12; i++)
                    {
                        wbpGrid[1, i].Style.BackColor = inputDataColor;
                        wbpGrid[2, i].Style.BackColor = inputDataColor;
                        wbpGrid[8, i].Style.BackColor = inputDataColor;
                        wbpGrid[15, i].Style.BackColor = inputDataColor;
                        wbpGrid[16, i].Style.BackColor = inputDataColor;

                        wbcGrid[9, i].Style.BackColor = inputDataColor;
                        wbcGrid[1, i].Style.BackColor = inputDataColor;
                        wbcGrid[4, i].Style.BackColor = inputDataColor;
                        wbcGrid[11, i].Style.BackColor = inputDataColor;
                        wbcGrid[12, i].Style.BackColor = inputDataColor;
                    }

                    //wbpGrid[10, 12].Style.BackColor = inputDataColor;
                    wbpGrid[12, 12].Style.BackColor = inputDataColor;

                    break;
                case 1:
                    //sbpGrid[4, 12].Style.BackColor = inputDataColor;
                    sbpGrid[6, 12].Style.BackColor = inputDataColor;
                    sbpGrid[10, 0].Style.BackColor = inputDataColor;

                    for (int i = 0; i < 12; i++)
                    {
                        sbpGrid[8, i].Style.BackColor = inputDataColor;
                        sbpGrid[9, i].Style.BackColor = inputDataColor;
                        sbcGrid[4, i].Style.BackColor = inputDataColor;
                        sbcGrid[5, i].Style.BackColor = inputDataColor;
                        sbcGrid[6, i].Style.BackColor = inputDataColor;
                    }

                    break;
            }
        }

        #endregion

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.TabIndex == 0)
            {
                DataGridViewStyling(wbpGrid);
                DataGridViewStyling(wbcGrid);
            }
            else
            {
                DataGridViewStyling(sbpGrid);
                DataGridViewStyling(sbcGrid);
            }

            HighlightInputData();
        }
        
        #region Обработчики панели инструментов и её компонентов
        private void CreateNewCalculation_Click(object sender, EventArgs e)
        {
            if (!inputSetup.IsShown)
            {
                inputSetup = new InputDataSetup(DataAccess);
                inputSetup.Show();
            }
        }

        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            new TablesToExportDialog().ShowDialog();
        }

        private void ShowGatewaySchedule_Click(object sender, EventArgs e)
        {
            showGatewaySchedule.Checked = !gsSetup.IsShown;

            if (showGatewaySchedule.Checked)
            {
                gsSetup = new GatewayScheduleSetup(DataAccess)
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

        private void YearsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calc.YearOfCalculation = yearsBox.Text;

            wbpGrid.DataSource = calc.WaterBalanceProfit;
            wbcGrid.DataSource = calc.WaterBalanceConsumable;
            sbpGrid.DataSource = calc.SaltBalanceProfit;
            sbcGrid.DataSource = calc.SaltBalanceConsumable;

            HighlightInputData();
        }

        #endregion
        #region Обработчики контексного меню

        private void Delete_Click(object sender, EventArgs e)
        {
            calc.YearOfCalculation = YearOfCalculation;
            calc.Delete();
        }

        private void Recalculate_Click(object sender, EventArgs e)
        {
            if (YearOfCalculation.Length == 0)
            {
                // TODO: Сообщить пользователя о том, что год не выбран
            }
            else
            {
                RecalculateDialog rd = new RecalculateDialog();
                rd.ShowDialog();

                if (rd.DialogResult == DialogResult.OK)
                {
                    Calculation calc = null;
                    InputData inputData = new InputData(DataAccess, YearOfCalculation) {
                        IsCalculateE = rd.IsCalculateE
                    };
                    
                    if (!rd.IsEnterGatewaySchedule)
                    {
                        calc = new Calculation(DataAccess, inputData);
                    }
                    else
                    {
                        GatewaySchedule gs = new GatewaySchedule(DataAccess, YearOfCalculation) {
                            IsEnterGatewaySchedule = rd.IsEnterGatewaySchedule,
                            IsCalculateGS = rd.IsCalculateGS
                        };
                        calc = new Calculation(DataAccess, inputData, gs);
                    }

                    calc.Calculate();
                    calc.Update();

                    // TODO: Сообщить об успешно выполненом расчете и его сохранении
                }
            }
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            if (YearOfCalculation.Length == 0)
            {
                // TODO: Сообщить пользователя о том, что год не выбран
            }
            else
            {
                Calculation calc = null;



                calc.Update();
            }
        }

        #endregion


    }
}
