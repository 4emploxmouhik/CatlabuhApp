using CatlabuhApp.Data.Access;
using CatlabuhApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatlabuhApp.UI.Support.Setups
{
    public partial class InputDataSetup : Form
    {
        public IDataAccess DataAccess { get; private set; }
        private GatewayScheduleSetup gsSetup;

        public bool IsShown { get; private set; } = false;

        #region Списки текстовых полей
        private List<TextBox> H1Boxes = new List<TextBox>();
        private List<TextBox> H2Boxes = new List<TextBox>();
        private List<TextBox> VzBoxes = new List<TextBox>();
        private List<TextBox> PIsmailBoxes = new List<TextBox>();
        private List<TextBox> PBolgradBoxes = new List<TextBox>();
        private List<TextBox> DorEBoxes = new List<TextBox>();

        #endregion
        #region Хранилища входных данных расчета
        public string YearOfCalculation { get; set; }
        private bool isCalculateE;

        #endregion

        public InputDataSetup()
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
            PIsmailBoxes.AddRange(new TextBox[] { 
                pIsmailBox0, pIsmailBox1, pIsmailBox2, pIsmailBox3, pIsmailBox4, pIsmailBox5, pIsmailBox6, pIsmailBox7, pIsmailBox8, pIsmailBox9, pIsmailBox10, pIsmailBox11
            });
            PBolgradBoxes.AddRange(new TextBox[] {
                 pBolgradBox0, pBolgradBox1, pBolgradBox2, pBolgradBox3, pBolgradBox4, pBolgradBox5, pBolgradBox6, pBolgradBox7, pBolgradBox8, pBolgradBox9, pBolgradBox10, pBolgradBox11
            });
            DorEBoxes.AddRange(new TextBox[] {
                dEBox0, dEBox1, dEBox2, dEBox3, dEBox4, dEBox5, dEBox6, dEBox7, dEBox8, dEBox9, dEBox10, dEBox11
            });

            gsSetup = new GatewayScheduleSetup();
        }

        public InputDataSetup(IDataAccess dataAccess) : this()
        {
            DataAccess = dataAccess;
            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations").ToArray());
        }

        private InputData FillInputData()
        {
            InputData inputData = new InputData(DataAccess)
            {
                YearOfCalculation = YearOfCalculation,

                H1 = GetConvertArray(H1Boxes),
                H2 = GetConvertArray(H2Boxes),
                Vz = GetConvertArray(VzBoxes),
                PIsmail = GetConvertArray(PIsmailBoxes),
                PBolgrad = GetConvertArray(PBolgradBoxes),

                IsCalculateE = isCalculateE,
            };

            inputData.S1InJanury = (s1InJanuaryBox.Text.Length == 0) ? 0 : Convert.ToDouble(s1InJanuaryBox.Text);
            inputData.SumVg = (sumVgBox.Text.Length != 0) ? Convert.ToDouble(sumVgBox.Text) : 
                DataAccess.GetCellData<double>("SELECT CoefficientValue FROM Coefficients WHERE CoefficientID = 36");

            if (isCalculateE)
            {
                inputData.D = GetConvertArray(DorEBoxes);
            }
            else
            {
                inputData.E = GetConvertArray(DorEBoxes);
            }

            return inputData;
        }

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

        private void LoadInputData()
        {
            if (DataAccess == null)
            {
                throw new ArgumentNullException("InoutDataSetup.LoadInputData():\n\tDataAccess is null.\n");
            }
            if (YearOfCalculation == null)
            {
                // TODO: кинуть сообщение пользователю, что год расчета не выбран
            }
            else
            {
                List<string[]> inputDatas = new List<string[]>()
                {
                    DataAccess.GetColumnData<string>($"SELECT H1 FROM InputData WHERE {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT H2 FROM InputData WHERE {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT Vz FROM InputData WHERE {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT PIsmail FROM InputData WHERE {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT PBolgrad FROM InputData WHERE {YearOfCalculation}").ToArray(),
                    DataAccess.GetColumnData<string>($"SELECT {(isCalculateE ? "d" : "E")} FROM InputData WHERE {YearOfCalculation}").ToArray(),
                };

                for (int i = 0; i < 12; i++)
                {
                    H1Boxes[i].Text = inputDatas[0][i];
                    H2Boxes[i].Text = inputDatas[1][i];
                    VzBoxes[i].Text = inputDatas[2][i];
                    PIsmailBoxes[i].Text = inputDatas[3][i];
                    PBolgradBoxes[i].Text = inputDatas[4][i];
                    DorEBoxes[i].Text = inputDatas[5][i];
                }

                s1InJanuaryBox.Text = DataAccess.GetCellData<string>($"SELECT S1InJanuary FROM OtherData WHERE YearName = {YearOfCalculation}");
                sumVgBox.Text = DataAccess.GetCellData<string>($"SELECT CoefficientValue FROM Coefficients WHERE CoefficientID = 36");
            }
        }

        #region Методы обработчики выбора пользователя
        private void AutoFilling_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TextBox entry in H2Boxes)
            {
                entry.TabIndex = autoFilling.Checked ? entry.TabIndex *= 100 : entry.TabIndex /= 100;
            }
        }

        private void ChoiceMethod_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Name)
            {
                case "enterData":
                case "enterDataBySLEB":
                    isCalculateE = false;
                    break;
                case "enterDeficit":
                    isCalculateE = true;
                    break;
            }
        }

        private void ShowGatewaySchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (showGatewaySchedule.Checked)
            {
                gsSetup = new GatewayScheduleSetup(DataAccess)
                {
                    YearOfCalculation = this.YearOfCalculation,
                    IsGatewayScheduleEnter = true
                };
                gsSetup.LoadScheduleData();
                gsSetup.Show();
            }
            else
            {
                gsSetup.IsGatewayScheduleEnter = false;
                gsSetup.Close();
            }
        }

        #endregion
        #region Обработчики панели инструментов и её элементов
        private void ClearFields_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                H1Boxes[i].Text = "";
                H2Boxes[i].Text = "";
                VzBoxes[i].Text = "";
                PIsmailBoxes[i].Text = "";
                PBolgradBoxes[i].Text = "";
                DorEBoxes[i].Text = "";
            }

            s1InJanuaryBox.Text = "";
            sumVgBox.Text = "";
            yearsBox.Text = "";

            if (showGatewaySchedule.Checked)
            {
                gsSetup.ClearFields();
            }
        }       

        private void MinimizeBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void RunCalculate_Click(object sender, EventArgs e)
        {
            if (YearOfCalculation.Length == 0)
            {
                // TODO: Сообщить пользователя о том, что год не выбран
            }
            else
            {
                Calculation calc = !showGatewaySchedule.Checked ? new Calculation(DataAccess, FillInputData()) :
                    new Calculation(DataAccess, FillInputData(), gsSetup.FillGatewaySchedule());

                calc.Calculate();

                if (!calc.IsExist)
                {
                    calc.Save();
                }
                else
                {
                    calc.Update();
                }

                // TODO: Сообщить об успешно выполненом расчете и его сохранении
            }
        }

        private void SaveInputData_Click(object sender, EventArgs e)
        {
            if (YearOfCalculation.Length == 0)
            {
                // TODO: Сообщить пользователя о том, что год не выбран
            }
            else
            {
                Calculation calc = new Calculation(DataAccess, FillInputData());

                if (!calc.IsExist)
                {
                    calc.Save();

                    if (showGatewaySchedule.Checked)
                    {
                        gsSetup.FillGatewaySchedule().Save();
                    }
                }
                else
                {
                    FillInputData().Update();

                    if (showGatewaySchedule.Checked)
                    {
                        gsSetup.FillGatewaySchedule().Update();
                    }
                }

                // TODO: Сообщить об успешном сохранении
            }
        }

        private void YearsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInputData();

            if (showGatewaySchedule.Checked)
            {
                gsSetup.YearOfCalculation = YearOfCalculation;
                gsSetup.LoadScheduleData();
            }
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
        private void HelpButton_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO: Вызвать окно справки
        }

        private void InputDataSetup_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            // TODO: Вызвать окно справки
        }

        #endregion

        public new void Show()
        {
            IsShown = true;
            base.Show();
        }

        private void InputDataSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsShown = false;
        }
    }
}
