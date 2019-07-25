using CatlabuhApp.Data.Access;
using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Main.Forms;
using CatlabuhApp.UI.Support.Setups;
using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Windows.Forms;

namespace CatlabuhApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            #region 
            //InputData inputData = new InputData(new SQLiteDataAccess())
            //{
            //    Year = 2019,

            //    H1 = new double[] { 1.42, 1.55, 1.65, 1.8, 1.77, 1.64, 1.52, 1.35, 1.17, 1.05, 1.11, 1.16 },
            //    H2 = new double[] { 1.55, 1.65, 1.8, 1.77, 1.64, 1.52, 1.35, 1.17, 1.05, 1.11, 1.16, 1.16 },
            //    P = new double[] { 15.8, 46.2, 60.6, 43.5, 14.1, 39.9, 43.9, 18.3, 21.2, 105.5, 81.1, 0 },
            //    Vz = new double[] { 0, 0, 0.09, 0.25, 1.56, 2, 2, 1, 0.2, 0.087, 0, 0, },
            //    D = new double[] { 0.7, 1.2, 2.4, 6.2, 8.9, 11.9, 15, 18.3, 9.8, 3.4, 3.5, 1.6 },

            //    IsCalculateE = true,
            //    S1InJanury = 1,
            //    SumVg = 4.13
            //};

            //GatewaySchedule gs = new GatewaySchedule(new SQLiteDataAccess())
            //{
            //    IDs = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
            //    Year = 2019,

            //    VD_plus = new double[] { 1.42, 1.55, 1.65, 1.81, 1.77, 1.64, 1.52, 1.35, 1.17, 1.05, 1.11, 1.16 },
            //    VD_minus = new double[] { 1.55, 1.65, 1.81, 1.77, 1.64, 1.52, 1.35, 1.17, 1.05, 1.11, 1.16, 1.16 },
            //    Voz_plus = new double[] { 1.42, 1.55, 1.65, 1.81, 1.77, 1.64, 1.52, 1.35, 1.17, 1.05, 1.11, 1.16 },
            //    Voz_minus = new double[] { 1.55, 1.65, 1.81, 1.77, 1.64, 1.52, 1.35, 1.17, 1.05, 1.11, 1.16, 1.16 },

            //    IsCalculateGS = true,
            //    ItemsToUpdate = GatewaySchedule.ChoiceItems.All
            //};

            //OutputData outputData = new OutputData(new SQLiteDataAccess(), inputData, gs) { Year = 2019 };


            //Calculation_mkII.InputDataOfCalculation inputData = new Calculation_mkII.InputDataOfCalculation()
            //{ 
            //    H1 = new double[] { 1.42, 1.55, 1.65, 1.8, 1.77, 1.64, 1.52, 1.35, 1.17, 1.05, 1.11, 1.16 },
            //    H2 = new double[] { 1.55, 1.65, 1.8, 1.77, 1.64, 1.52, 1.35, 1.17, 1.05, 1.11, 1.16, 1.16 },
            //    P = new double[] { 15.8, 46.2, 60.6, 43.5, 14.1, 39.9, 43.9, 18.3, 21.2, 105.5, 81.1, 0 },
            //    Vz = new double[] { 0, 0, 0.09, 0.25, 1.56, 2, 2, 1, 0.2, 0.087, 0, 0, },
            //    D = new double[] { 0.7, 1.2, 2.4, 6.2, 8.9, 11.9, 15, 18.3, 9.8, 3.4, 3.5, 1.6 },

            //    IsCalculateE = true,
            //    S1InJanury = 1,
            //    SumVg = 4.13
            //};

            //Calculation_mkII.GatewayScheduleOfCalculation gatewaySchedule = new Calculation_mkII.GatewayScheduleOfCalculation()
            //{
            //    MonthsOfWorkGatewayVD = new byte[]  { 1, 1, 1, 0, 0, 2, 2, 1, 0, 0, 0, 0 },
            //    MonthsOfWorkGatewayVoz = new byte[] { 0, 0, 0, 1, 1, 1, 2, 1, 0, 0, 0, 0 }, 

            //    IsCalculateGatewaySchedule = true
            //};

            //Calculation_mkII calculation = new Calculation_mkII(new SQLiteDataAccess(), inputData, gatewaySchedule)
            //{
            //    IsEnterGatewaySchedule = true
            //};

            //calculation.Calculate();

            ////Console.Write(calculation.InputData.ToString());
            //Console.Write(calculation.GatewaySchedule.ToString());
            //Console.Write(calculation.ToString());
            #endregion
        }
    }
}


