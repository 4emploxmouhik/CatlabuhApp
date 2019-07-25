using CatlabuhApp.UI.UC;
using CatlabuhApp.Data;
using CatlabuhApp.Data.Access;
//using CatlabuhApp.Data.Models_v_2_0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatlabuhApp.UI.Forms;

namespace CatlabuhApp.UI.UC
{
    public partial class CalculationCreateUC : UserControl, IDataViewUC
    {
        public IDataAccess DataAccess { get; set; }

        private List<TextBox> H1Boxes = new List<TextBox>();
        private List<TextBox> H2Boxes = new List<TextBox>();
        private List<TextBox> VzBoxes = new List<TextBox>();
        private List<TextBox> PBoxesIsmail = new List<TextBox>();
        private List<TextBox> PBoxesBolgrad = new List<TextBox>();
        private List<TextBox> DorEBoxes = new List<TextBox>();

        //private InputData inputData = null;
        //private GatewaySchedule gs = null;

        private List<TextBox> AllBoxes = new List<TextBox>();

        #region Конструкторы
        public CalculationCreateUC()
        {
            InitializeComponent();

            H1Boxes.AddRange(new TextBox[] {
                h1Box0, h1Box1, h1Box2, h1Box3, h1Box4, h1Box5, h1Box6, h1Box7, h1Box8, h1Box9, h1Box10, h1Box11
            });
            H2Boxes.AddRange(new TextBox[] {
                h2Box0, h2Box1, h2Box2, h2Box3, h2Box4, h2Box5, h2Box6, h2Box7, h2Box8, h2Box9, h2Box10, h2Box11
            });
            VzBoxes.AddRange(new TextBox[] {
                vzBox0, vzBox1, vzBox2, vzBox3, vzBox4, vzBox5, vzBox6, vzBox7, vzBox8, vzBox9, vzBox10, vzBox11
            });
            PBoxesIsmail.AddRange(new TextBox[] {
                pBox0, pBox1, pBox2, pBox3, pBox4, pBox5, pBox6, pBox7, pBox8, pBox9, pBox10, pBox11
            });
            PBoxesBolgrad.AddRange(new TextBox[] {
                pBox12, pBox13, pBox14, pBox15, pBox16, pBox17, pBox18, pBox19, pBox20, pBox21, pBox22, pBox23
            });
            DorEBoxes.AddRange(new TextBox[] {
                dorEBox0, dorEBox1, dorEBox2, dorEBox3, dorEBox4, dorEBox5, dorEBox6, dorEBox7, dorEBox8, dorEBox9, dorEBox10, dorEBox11
            });

            AllBoxes.AddRange(H1Boxes);
            AllBoxes.AddRange(H2Boxes);
            AllBoxes.AddRange(VzBoxes);
            AllBoxes.AddRange(PBoxesIsmail);
            AllBoxes.AddRange(DorEBoxes);

            gatewaySheduleUC.Enabled = enterGS.Checked = false;
            enterGS.Image = imageList.Images[1];
            gatewaySheduleUC.Enabled = enterGS.Checked;
        }

        public CalculationCreateUC(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;

            //inputData = new InputData(DataAccess);
            //gs = new GatewaySchedule(DataAccess);
            gatewaySheduleUC.DataAccess = DataAccess;

            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations").ToArray());
        }

        #endregion

        private double[] GetConvertArray(List<TextBox> someTextBoxes)
        {
            double[] output = new double[12];

            for (int i = 0; i < output.Length; i++)
            {
                try
                {
                    output[i] = Convert.ToDouble(someTextBoxes[i].Text);
                }
                catch (FormatException)
                {
                    output[i] = 0;
                }
            }

            return output;
        }

        private double GetSumFromPBoxes(List<TextBox> somePBoxes)
        {
            double sum = 0;

            foreach (TextBox entry in somePBoxes)
            {
                try
                {
                    sum += Convert.ToDouble(entry.Text);
                }
                catch (FormatException)
                {
                    sum += 0;
                }
            }

            /*  Ремарка:
             *      FormatException используеться потому, что 
             *      при проверки длины текста entry.Text > 0, нет грарантий, 
             *      что не получим исключение.
             */

            return sum;
        }

        #region Текстовые поля
        private void HBoxes_TextChanged(object sender, EventArgs e)
        {
            if (autoFilingBox.Checked)
            {
                TextBox someHBox = (TextBox)sender;

                for (int i = 0; i < 12; i++)
                {
                    if (someHBox.Tag == H1Boxes[i].Tag)
                    {
                        H1Boxes[i].Text = someHBox.Text;
                    }
                    
                    if (someHBox.Tag == H2Boxes[i].Tag)
                    {
                        H2Boxes[i].Text = someHBox.Text;
                    }
                }
            }
        }

        private void PBoxes_TextChanged(object sender, EventArgs e)
        {
            sumPBox0.Text = GetSumFromPBoxes(PBoxesIsmail).ToString();
            sumPBox1.Text = GetSumFromPBoxes(PBoxesBolgrad).ToString();
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

        private void YearsBox_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
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

        private void YearsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string[] h1 = DataAccess.GetColumnData<string>($"SELECT H1 FROM InputData WHERE YearName = {yearsBox.Text}").ToArray();
            //string[] h2 = DataAccess.GetColumnData<string>($"SELECT H2 FROM InputData WHERE YearName = {yearsBox.Text}").ToArray();
            //string[] vz = DataAccess.GetColumnData<string>($"SELECT Vz FROM InputData WHERE YearName = {yearsBox.Text}").ToArray();
            //string[] p = DataAccess.GetColumnData<string>($"SELECT P FROM InputData WHERE YearName = {yearsBox.Text}").ToArray();
            //string[] d_or_E = inputData.IsCalculateE ? DataAccess.GetColumnData<string>($"SELECT d FROM InputData WHERE YearName = {yearsBox.Text}").ToArray() :
            //    DataAccess.GetColumnData<string>($"SELECT E FROM InputData WHERE YearName = {yearsBox.Text}").ToArray();

            //for (int i = 0; i < 12; i++)
            //{
            //    H1Boxes[i].Text = h1[i];
            //    H2Boxes[i].Text = h2[i];
            //    VzBoxes[i].Text = vz[i];
            //    PBoxesIsmail[i].Text = p[i];
            //    DorEBoxes[i].Text = d_or_E[i];
            //}
            
            ////s1Box.Text = DataAccess.GetCellData<string>("");
            //sumVgBox.Text = DataAccess.GetCellData<string>("SELECT CoefficientValue FROM Coefficients WHERE CoefficientID = 36");

            //if (enterGS.Checked)
            //{
            //    gatewaySheduleUC.YearOfCalculation = yearsBox.Text;
            //    gatewaySheduleUC.LoadShedule();
            //}
        }

        #endregion
        #region Контролы выбора пользователя
        private void ChooseDeterminationOfE(object sender, EventArgs e)
        {
            //switch (((RadioButton)sender).Tag)
            //{
            //    case "d":
            //        inputData.IsCalculateE = true;
            //        break;
            //    case "sleb":
            //    case "e":
            //        inputData.IsCalculateE = false;
            //        break;
            //}
        }

        #endregion
        #region Кнопки на панели инструметов
        private void ClearFields_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                H1Boxes[i].Clear();
                H2Boxes[i].Clear();
                VzBoxes[i].Clear();
                PBoxesIsmail[i].Clear();
                PBoxesBolgrad[i].Clear();
                DorEBoxes[i].Clear();
            }

            s1Box.Clear();
            sumVgBox.Clear();
            yearsBox.Text = "";

            gatewaySheduleUC.ClearFields();
        }

        private void EnterGS_Click(object sender, EventArgs e)
        {
            enterGS.Checked = !enterGS.Checked;
            enterGS.Image = enterGS.Checked ? imageList.Images[0] : imageList.Images[1];

            gatewaySheduleUC.Enabled = enterGS.Checked;

            //gs.IsEnterGatewaySchedule = enterGS.Checked;

            if (enterGS.Checked)
            {
                gatewaySheduleUC.YearOfCalculation = yearsBox.Text;
                gatewaySheduleUC.LoadShedule();
            }
        }

        private void ToCalculate_Click(object sender, EventArgs e)
        {
            int year = -1;

            if (yearsBox.Text.Length > 0)
            {
                year = Convert.ToInt32(yearsBox.Text);
            }
            else
            {
                // TODO: Call MessageForm
            }

            //#region InputData
            //inputData.Year = year;
            //inputData.H1 = GetConvertArray(H1Boxes);
            //inputData.H2 = GetConvertArray(H2Boxes);
            //inputData.Vz = GetConvertArray(VzBoxes);

            //inputData.P = GetConvertArray(PBoxesIsmail);

            //if (inputData.IsCalculateE)
            //{
            //    inputData.D = GetConvertArray(DorEBoxes);
            //}
            //else
            //{
            //    inputData.E = GetConvertArray(DorEBoxes);
            //}

            //inputData.S1InJanury = Convert.ToDouble(s1Box.Text);
            //inputData.SumVg = Convert.ToDouble(sumVgBox.Text);

            //#endregion
            //#region GatewaySchedule
            //if (gs.IsEnterGatewaySchedule)
            //{
            //    gs.Year = year;
            //    gs.IsCalculateGS = gatewaySheduleUC.IsCalculateGS;
                
            //    if (gs.IsCalculateGS)
            //    {
            //        gs.MonthsOfWorkGatewayVD = gatewaySheduleUC.VD_months;
            //        gs.MonthsOfWorkGatewayVoz = gatewaySheduleUC.Voz_months;
            //    }
            //    else
            //    {
            //        gs.VD_plus = gatewaySheduleUC.VD_plus;
            //        gs.VD_minus = gatewaySheduleUC.VD_minus;
            //        gs.Voz_plus = gatewaySheduleUC.Voz_plus;
            //        gs.Voz_minus = gatewaySheduleUC.Voz_minus;
            //    }

            //    gs.GataewayOpenVD = gatewaySheduleUC.GatewayOpenVD;
            //    gs.GataewayCloseVD = gatewaySheduleUC.GatewayCloseVD;
            //    gs.GataewayOpenVoz = gatewaySheduleUC.GatewayOpenVoz;
            //    gs.GataewayCloseVoz = gatewaySheduleUC.GatewayCloseVoz;
            //}

            //#endregion

            //Calculation calc = gs.IsCalculateGS ? new Calculation(DataAccess, inputData, gs) : new Calculation(DataAccess, inputData);
            //calc.Calculate();

            //Console.WriteLine(calc.ToString());

            //calc.Save();
        }

        private void SaveInputData_Click(object sender, EventArgs e)
        {

        }

        #endregion
        #region Выделение текста в поле при получении фокуса
        private void TextBox_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
        }

        #endregion

        
    }
}
