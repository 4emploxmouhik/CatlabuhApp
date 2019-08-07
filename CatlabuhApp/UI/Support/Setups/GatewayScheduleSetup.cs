using CatlabuhApp.Data.Access;
using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Main.Views;
using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Setups
{
    public partial class GatewayScheduleSetup : Form
    {
        public IDataAccess DataAccess { get; private set; }
        public bool IsShown { get; private set; } = false;
        private CalculationView parent = null;

        #region Списки текстовых полей
        // Объемов
        private List<TextBox> VD_plusBoxes = new List<TextBox>();
        private List<TextBox> VD_minusBoxes = new List<TextBox>();
        private List<TextBox> Voz_plusBoxes = new List<TextBox>();
        private List<TextBox> Voz_minusBoxes = new List<TextBox>();
       
        // Дат работы шлюзов
        private List<TextBox> VDGDPlusBoxes = new List<TextBox>();
        private List<TextBox> VDGDMinusBoxes = new List<TextBox>();
        private List<TextBox> VozGDPlusBoxes = new List<TextBox>();
        private List<TextBox> VozGDMinusBoxes = new List<TextBox>();

        #endregion
        #region Хранилища данных графика работы шлюзов
        public string YearOfCalculation { get; set; }

        public byte[] VD_months
        {
            get
            {
                return GetScheduleOfWorkGateway(GetMonthsOfTimeOfWorkAGateway(VDGDPlusBoxes), GetMonthsOfTimeOfWorkAGateway(VDGDMinusBoxes));
            }
        }
        public byte[] Voz_months
        {
            get
            {
                return GetScheduleOfWorkGateway(GetMonthsOfTimeOfWorkAGateway(VozGDPlusBoxes), GetMonthsOfTimeOfWorkAGateway(VozGDMinusBoxes));
            }
        }

        public double[] VD_plus
        {
            get
            {
                return GetConvertArray(VD_plusBoxes);
            }
        }
        public double[] VD_minus
        {
            get
            {
                return GetConvertArray(VD_minusBoxes);
            }
        }
        public double[] Voz_plus
        {
            get
            {
                return GetConvertArray(Voz_plusBoxes);
            }
        }
        public double[] Voz_minus
        {
            get
            {
                return GetConvertArray(Voz_minusBoxes);
            }
        }

        public string[] GatewayOpenVD_plus
        {
            get
            {
                return GetGatewayWorkDates(VDGDPlusBoxes, true);
            }
        }
        public string[] GatewayCloseVD_plus
        {
            get
            {
                return GetGatewayWorkDates(VDGDPlusBoxes, false);
            }
        }
        public string[] GatewayOpenVD_minus
        {
            get
            {
                return GetGatewayWorkDates(VDGDMinusBoxes, true);
            }
        }
        public string[] GatewayCloseVD_minus
        {
            get
            {
                return GetGatewayWorkDates(VDGDMinusBoxes, false);
            }
        }

        public string[] GatewayOpenVoz_plus
        {
            get
            {
                return GetGatewayWorkDates(VozGDPlusBoxes, true);
            }
        }
        public string[] GatewayCloseVoz_plus
        {
            get
            {
                return GetGatewayWorkDates(VozGDPlusBoxes, false);
            }
        }
        public string[] GatewayOpenVoz_minus
        {
            get
            {
                return GetGatewayWorkDates(VozGDMinusBoxes, true);
            }
        }
        public string[] GatewayCloseVoz_minus
        {
            get
            {
                return GetGatewayWorkDates(VozGDMinusBoxes, false);
            }
        }

        public bool IsCalculateGS => byDates.Checked;
        public bool IsGatewayScheduleEnter { get; set; } = false;
        #endregion

        public GatewayScheduleSetup()
        {
            Main.Forms.MainForm.GetCultureInfo();
            InitializeComponent();

            VDGDPlusBoxes.AddRange(new TextBox[] {
                VDGODP_Box0, VDGCDP_Box0, VDGODP_Box1, VDGCDP_Box1, VDGODP_Box2, VDGCDP_Box2, VDGODP_Box3, VDGCDP_Box3, VDGODP_Box4, VDGCDP_Box4,
                VDGODP_Box5, VDGCDP_Box5, VDGODP_Box6, VDGCDP_Box6, VDGODP_Box7, VDGCDP_Box7, VDGODP_Box8, VDGCDP_Box8, VDGODP_Box9, VDGCDP_Box9,
                VDGODP_Box10, VDGCDP_Box10, VDGODP_Box11, VDGCDP_Box11
            });
            VDGDMinusBoxes.AddRange(new TextBox[] {
                VDGODM_Box0, VDGCDM_Box0, VDGODM_Box1, VDGCDM_Box1, VDGODM_Box2, VDGCDM_Box2, VDGODM_Box3, VDGCDM_Box3, VDGODM_Box4, VDGCDM_Box4,
                VDGODM_Box5, VDGCDM_Box5, VDGODM_Box6, VDGCDM_Box6, VDGODM_Box7, VDGCDM_Box7, VDGODM_Box8, VDGCDM_Box8, VDGODM_Box9, VDGCDM_Box9,
                VDGODM_Box10, VDGCDM_Box10, VDGODM_Box11, VDGCDM_Box11
            });
            VozGDPlusBoxes.AddRange(new TextBox[] {
                VozGODP_Box0, VozGCDP_Box0, VozGODP_Box1, VozGCDP_Box1, VozGODP_Box2, VozGCDP_Box2, VozGODP_Box3, VozGCDP_Box3, VozGODP_Box4, VozGCDP_Box4,
                VozGODP_Box5, VozGCDP_Box5, VozGODP_Box6, VozGCDP_Box6, VozGODP_Box7, VozGCDP_Box7, VozGODP_Box8, VozGCDP_Box8, VozGODP_Box9, VozGCDP_Box9,
                VozGODP_Box10, VozGCDP_Box10, VozGODP_Box11, VozGCDP_Box11
            });
            VozGDMinusBoxes.AddRange(new TextBox[] {
                VozGODM_Box0, VozGCDM_Box0, VozGODM_Box1, VozGCDM_Box1, VozGODM_Box2, VozGCDM_Box2, VozGODM_Box3, VozGCDM_Box3, VozGODM_Box4, VozGCDM_Box4,
                VozGODM_Box5, VozGCDM_Box5, VozGODM_Box6, VozGCDM_Box6, VozGODM_Box7, VozGCDM_Box7, VozGODM_Box8, VozGCDM_Box8, VozGODM_Box9, VozGCDM_Box9,
                VozGODM_Box10, VozGCDM_Box10, VozGODM_Box11, VozGCDM_Box11
            });

            VD_plusBoxes.AddRange(new TextBox[] {
                VDP_Box0, VDP_Box1, VDP_Box2, VDP_Box3, VDP_Box4, VDP_Box5, VDP_Box6, VDP_Box7, VDP_Box8, VDP_Box9, VDP_Box10, VDP_Box11
            });
            VD_minusBoxes.AddRange(new TextBox[] {
                VDM_Box0, VDM_Box1, VDM_Box2, VDM_Box3, VDM_Box4, VDM_Box5, VDM_Box6, VDM_Box7, VDM_Box8, VDM_Box9, VDM_Box10, VDM_Box11
            });
            Voz_plusBoxes.AddRange(new TextBox[] {
                VozP_Box0, VozP_Box1, VozP_Box2, VozP_Box3, VozP_Box4, VozP_Box5, VozP_Box6, VozP_Box7, VozP_Box8, VozP_Box9, VozP_Box10, VozP_Box11
            });
            Voz_minusBoxes.AddRange(new TextBox[] {
                VozM_Box0, VozM_Box1, VozM_Box2, VozM_Box3, VozM_Box4, VozM_Box5, VozM_Box6, VozM_Box7, VozM_Box8, VozM_Box9, VozM_Box10, VozM_Box11
            });
        }

        public GatewayScheduleSetup(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;
            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations ORDER BY YearName DESC").ToArray());
            yearsBox.Text = yearsBox.Items[0].ToString();
        }

        public GatewayScheduleSetup(IDataAccess dataAccess, CalculationView parent) : this(dataAccess)
        {
            this.parent = parent;
        }

        public void ClearFields()
        {
            for (int i = 0; i < 24; i++)
            {
                if (i < 12)
                {
                    VD_plusBoxes[i].Text = "";
                    VD_minusBoxes[i].Text = "";
                    Voz_plusBoxes[i].Text = "";
                    Voz_minusBoxes[i].Text = "";
                }

                VDGDPlusBoxes[i].Text = "";
                VDGDMinusBoxes[i].Text = "";
                VozGDPlusBoxes[i].Text = "";
                VozGDMinusBoxes[i].Text = "";
            }

            yearsBox.Text = "";
        }

        public GatewaySchedule FillGatewaySchedule()
        {
            GatewaySchedule gs = new GatewaySchedule(DataAccess)
            {
                YearOfCalculation = YearOfCalculation,

                VD_plus = this.VD_plus,
                VD_minus = this.VD_minus,
                Voz_plus = this.Voz_plus,
                Voz_minus = this.Voz_minus,

                MonthsOfWorkGatewayVD = VD_months,
                MonthsOfWorkGatewayVoz = Voz_months,

                GatewayOpenVD_plus = this.GatewayOpenVD_plus,
                GatewayCloseVD_plus = this.GatewayCloseVD_plus,
                GatewayOpenVD_minus = this.GatewayOpenVD_minus,
                GatewayCloseVD_minus = this.GatewayCloseVD_minus,

                GatewayOpenVoz_plus = this.GatewayOpenVoz_plus,
                GatewayCloseVoz_plus = this.GatewayCloseVoz_plus,
                GatewayOpenVoz_minus = this.GatewayOpenVoz_minus,
                GatewayCloseVoz_minus = this.GatewayCloseVoz_minus,

                IsCalculateGS = this.IsCalculateGS,
                ItemsToUpdate = GatewaySchedule.ChoiceItems.All
            };

            return gs;
        }

        #region Методы загрузки данных из БД в текстовые поля 
        private void FillingDatesBoxes(List<TextBox> boxesList, string[] fillingDates, string[] dischargeDates)
        {
            int pointer_1 = 0, pointer_2 = 0;

            for (int i = 0; i < boxesList.Count; i++)
            {
                if (boxesList[i].Tag.Equals("open"))
                {
                    boxesList[i].Text = fillingDates[pointer_1];
                    pointer_1++;
                }
                else
                {
                    boxesList[i].Text = dischargeDates[pointer_2];
                    pointer_2++;
                }
            }
        }

        public void LoadScheduleData()
        {
            if (YearOfCalculation == null || YearOfCalculation.Length == 0)
            {
                throw new ArgumentNullException();
            }
            else if (DataAccess.GetCellData<int>($"SELECT count(YearName) FROM GatewaySchedule WHERE YearName = {YearOfCalculation}") != 0)
            {
                List<string[]> volumes = new List<string[]>()
                {
                    DataAccess.GetColumnData<string>($"SELECT VD_plus   FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT VD_minus  FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT Voz_plus  FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT Voz_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray()
                };
                List<string[]> dates = new List<string[]>()
                {
                    DataAccess.GetColumnData<string>($"SELECT GatewayOpenVD_plus    FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT GatewayCloseVD_plus   FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT GatewayOpenVD_minus   FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT GatewayCloseVD_minus  FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT GatewayOpenVoz_plus   FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT GatewayCloseVoz_plus  FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT GatewayOpenVoz_minus  FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT GatewayCloseVoz_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray()
                };

                for (int i = 0; i < 12; i++)
                {
                    VD_plusBoxes[i].Text = volumes[0][i];
                    VD_minusBoxes[i].Text = volumes[1][i];
                    Voz_plusBoxes[i].Text = volumes[2][i];
                    Voz_minusBoxes[i].Text = volumes[3][i];
                }

                FillingDatesBoxes(VDGDPlusBoxes, dates[0], dates[1]);
                FillingDatesBoxes(VDGDMinusBoxes, dates[2], dates[3]);
                FillingDatesBoxes(VozGDPlusBoxes, dates[4], dates[5]);
                FillingDatesBoxes(VozGDMinusBoxes, dates[6], dates[7]);
            }
        }

        #endregion
        #region Методы для свойств
        private double[] GetConvertArray(List<TextBox> someTextBoxes)
        {
            double[] output = new double[12];

            for (int i = 0; i < output.Length; i++)
            {
                if (someTextBoxes[i].Text.Length != 0)
                {
                    output[i] = Convert.ToDouble(someTextBoxes[i].Text);
                }
                else
                {
                    output[i] = 0;
                }
            }

            return output;
        }

        private string[] GetGatewayWorkDates(List<TextBox> someBoxes, bool isPlusGroup)
        {
            string[] output = new string[someBoxes.Count / 2];

            for (int i = 0, pointer = 0; i < someBoxes.Count; i++)
            {
                if (isPlusGroup)
                {
                    if (i % 2 == 0)
                    {
                        output[pointer] = someBoxes[i].Text;
                        pointer++;
                    }
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        output[pointer] = someBoxes[i].Text;
                        pointer++;
                    }
                }
            }

            return output;
        }

        private byte[] GetMonthsOfTimeOfWorkAGateway(List<TextBox> datesWorkingBoxes)
        {
            byte[] monthsOfWork = new byte[12];
            bool isGatewayOpen = false;

            for (int i = 0, pointer = 0; i < datesWorkingBoxes.Count; i++)
            {
                if (datesWorkingBoxes[i].Text.Length > 0)
                {
                    if (datesWorkingBoxes[i].Tag.Equals("open"))
                    {
                        isGatewayOpen = true;
                    }
                    else if (datesWorkingBoxes[i].Tag.Equals("close"))
                    {
                        isGatewayOpen = false;
                    }
                }

                if (isGatewayOpen)
                {
                    monthsOfWork[pointer] = 1;
                }

                if (i % 2 != 0)
                {
                    pointer++;
                }
            }

            return monthsOfWork;
        }

        private byte[] GetScheduleOfWorkGateway(byte[] workToFilling, byte[] workToDisharge)
        {
            byte[] shedule = new byte[12];

            for (int i = 0; i < shedule.Length; i++)
            {
                if (workToFilling[i] == 1)
                {
                    shedule[i] = 1;
                }
                else if (workToDisharge[i] == 1)
                {
                    shedule[i] = 2;
                }
                else
                {
                    shedule[i] = 0;
                }
            }

            return shedule;
        }

        #endregion
        #region Обработчики панели инструментов и её элементов
        private void ChoiceMethod_Click(object sender, EventArgs e)
        {
            byData.Checked = !byData.Checked;
            byDates.Checked = !byDates.Checked;
        }

        private void ClearFields_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void MinimizeBoxBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void SaveScheduleData_Click(object sender, EventArgs e)
        {
            if (YearOfCalculation == null || YearOfCalculation.Length == 0)
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText1, MessageDialog.Icon.Alert);
            }
            else
            {
                Cursor = Cursors.AppStarting;
                SaveScheduleAsync();
            }
        }

        private void YearsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadScheduleData();
        }

        private void YearsBox_TextChanged(object sender, EventArgs e)
        {
            YearOfCalculation = yearsBox.Text;
        }

        #endregion
        #region Общие обработичик для текстовых полей
        private void TextBox_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if ((e.KeyChar == '-') || (e.KeyChar == ','))
            {
                return;
            }
            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        #endregion
        #region Вызов справки
        private void GatewayScheduleSetup_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            // TODO: Вызвать окно справки
        }

        private void HelpButton_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO: Вызвать окно справки
        }

        #endregion

        private void GatewayScheduleSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsShown = false;

            if (IsGatewayScheduleEnter)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        public new void Show()
        {
            IsShown = true;
            base.Show();
        }

    }
}
