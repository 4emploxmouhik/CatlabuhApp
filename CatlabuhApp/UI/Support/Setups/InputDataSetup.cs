﻿using CatlabuhApp.Data.Access;
using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Main.Views;
using CatlabuhApp.UI.Support.Dialogs;
using CatlabuhAppSupportHelp.UI.Help;
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

        private CalculationView parent;

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
            Main.Forms.MainForm.GetCultureInfo();
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

        public InputDataSetup(CalculationView parent) : this()
        {
            this.parent = parent;
        }

        public InputDataSetup(IDataAccess dataAccess, CalculationView parent) : this(parent)
        {
            DataAccess = dataAccess;
            yearsBox.Items.AddRange(DataAccess.GetColumnData<string>("SELECT YearName FROM YearsOfCalculations ORDER BY YearName DESC").ToArray());
        }

        private bool CheckInputData()
        {
            bool checkResult = true;

            for (int i = 0; i < 12; i++)
            {
                if (string.IsNullOrEmpty(H1Boxes[i].Text) || string.IsNullOrEmpty(H2Boxes[i].Text) || string.IsNullOrEmpty(VzBoxes[i].Text) || 
                    string.IsNullOrEmpty(PIsmailBoxes[i].Text) || string.IsNullOrEmpty(PBolgradBoxes[i].Text) || string.IsNullOrEmpty(DorEBoxes[i].Text))
                {
                    checkResult = false;
                    break;
                }
            }

            if (string.IsNullOrEmpty(sumVgBox.Text) || string.IsNullOrEmpty(s1InJanuaryBox.Text))
            {
                checkResult = false;
            }

            return checkResult;
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
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText1, MessageDialog.Icon.Alert);
            }
            else
            {
                List<string[]> inputDatas = new List<string[]>(6);
                string[] columns = { "H1", "H2", "Vz", "PIsmail", "PBolgrad", (isCalculateE ? "d" : "E") };

                for (int i = 0; i < 6; i++)
                {
                    try
                    {
                        inputDatas.Add(DataAccess.GetColumnData<string>($"SELECT {columns[i]} FROM InputData WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray());
                    }
                    catch (NullReferenceException)
                    {
                        inputDatas[i] = new string[12];
                    }
                }

                FillBoxes(H1Boxes, inputDatas[0]);
                FillBoxes(H2Boxes, inputDatas[1]);
                FillBoxes(VzBoxes, inputDatas[2]);
                FillBoxes(PIsmailBoxes, inputDatas[3]);
                FillBoxes(PBolgradBoxes, inputDatas[4]);
                FillBoxes(DorEBoxes, inputDatas[5]);

                s1InJanuaryBox.Text = DataAccess.GetCellData<double>($"SELECT S1InJanuary FROM OtherData WHERE YearName = {YearOfCalculation}").ToString();
                sumVgBox.Text = DataAccess.GetCellData<double>($"SELECT CoefficientValue FROM Coefficients WHERE CoefficientID = 36").ToString();
            }
        }

        private void FillBoxes(List<TextBox> boxes, string[] data)
        {
            for (int i = 0; i < 12; i++)
            {
                try
                {
                    boxes[i].Text = data[i].Replace(".", ",");
                }
                catch (NullReferenceException)
                {
                    boxes[i].Text = "";
                }
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

            try
            {
                if (Calculation.Exists(DataAccess, YearOfCalculation))
                {
                    int i = 0;

                    foreach (var entry in DataAccess.GetColumnData<string>($"SELECT {(isCalculateE ? "d" : "E")} FROM InputData WHERE YearName = {YearOfCalculation}"))
                    {
                        DorEBoxes[i].Text = entry;
                        i++;
                    }
                }
            }
            catch (Exception) { }
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

                try
                {
                    Calculation calc = new Calculation(DataAccess) { YearOfCalculation = this.YearOfCalculation };

                    if (calc.IsExist)
                    {
                        gsSetup.LoadScheduleData();
                    }
                    else
                    {
                        gsSetup.ClearFields();
                    }

                    gsSetup.Show(); 
                }
                catch (ArgumentNullException)
                {
                    gsSetup.IsGatewayScheduleEnter = false;
                    showGatewaySchedule.Checked = false;

                    MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText1, MessageDialog.Icon.Alert);
                }
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
            if (YearOfCalculation == null || YearOfCalculation.Length == 0)
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText1, MessageDialog.Icon.Alert); 
            }
            else if (!CheckInputData())
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText2, MessageDialog.Icon.Alert);
            }
            else
            {
                RunCalculateAsync();
            }
        }

        private void SaveInputData_Click(object sender, EventArgs e)
        {
            if (YearOfCalculation == null || YearOfCalculation.Length == 0)
            {
                MessageDialog.Show(MessageDialog.AlertTitle1, MessageDialog.AlertText1, MessageDialog.Icon.Alert);
            }
            else
            {
                SaveInputDataAsync();
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

            if (showGatewaySchedule.Checked)
            {
                gsSetup.YearOfCalculation = YearOfCalculation;
            }
        }

        #endregion
        #region Обработичики текстовых полей
        private void HBoxes_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int i = 0;

            while (autoFilling.Checked)
            {
                if (textBox.Name == H1Boxes[i].Name)
                {
                    H2Boxes[i - 1].Text = textBox.Text;
                    break;
                }
                if (textBox.Name == H2Boxes[i].Name)
                {
                    H1Boxes[i + 1].Text = textBox.Text;
                    break;
                }

                i++;
            }
        }

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
            TextBox textBox = (TextBox)sender;

            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (((e.KeyChar == '-') && !textBox.Text.Contains("-"))  || ((e.KeyChar == ',') && !textBox.Text.Contains(",")))
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
            new HelpForm("createCalcText", "calculateText", "saveInputDataText", "autoFillingText", "clearFieldsText").Show();
        }

        private void InputDataSetup_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            new HelpForm("createCalcText", "calculateText", "saveInputDataText", "autoFillingText", "clearFieldsText").Show();
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
