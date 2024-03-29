﻿using CatlabuhApp.Data.Access;
using System.Collections.Generic;

namespace CatlabuhApp.Data.Models
{
    public class GatewaySchedule : Calculation.IComponent
    {
        public IDataAccess DataAccess { get; private set; }
        public int[] IDs { get; set; }
        public string YearOfCalculation { get; set; }
        
        #region Здесть храняться данные
        public double[] VD_plus   { get; set; } = new double[12];
        public double[] VD_minus  { get; set; } = new double[12];
        public double[] Voz_plus  { get; set; } = new double[12];
        public double[] Voz_minus { get; set; } = new double[12];

        public double[] SumsOfVolume     { get; set; } = new double[4];
        public double[] ProcentsOfVolume { get; set; } = new double[4];
#endregion
        public string[] GatewayOpenVD_plus   { get; set; } = new string[12];
        public string[] GatewayCloseVD_plus  { get; set; } = new string[12];
        public string[] GatewayOpenVD_minus  { get; set; } = new string[12];
        public string[] GatewayCloseVD_minus { get; set; } = new string[12];

        public string[] GatewayOpenVoz_plus   { get; set; } = new string[12];
        public string[] GatewayCloseVoz_plus  { get; set; } = new string[12];
        public string[] GatewayOpenVoz_minus  { get; set; } = new string[12];
        public string[] GatewayCloseVoz_minus { get; set; } = new string[12];

        public byte[] MonthsOfWorkGatewayVD  { get; set; } = new byte[12];
        public byte[] MonthsOfWorkGatewayVoz { get; set; } = new byte[12];

        public bool IsCalculateGS { get; set; } = false;
        public bool IsEnterGatewaySchedule { get; set; } = false;

        

        public enum ChoiceItems
        {
            Volumes,
            Dates,
            All
        }
        public ChoiceItems ItemsToUpdate { get; set; }

        public GatewaySchedule() { }

        public GatewaySchedule(IDataAccess dataAccess)
        {
            DataAccess = dataAccess ?? throw new System.ArgumentNullException(nameof(dataAccess));
        }

        public GatewaySchedule(IDataAccess dataAccess, string yearOfCalculation) : this(dataAccess)
        {
            YearOfCalculation = yearOfCalculation ?? throw new System.ArgumentNullException(nameof(yearOfCalculation));

            VD_plus   = GetColumnData(VD_plus, "VD_plus");
            VD_minus  = GetColumnData(VD_minus, "VD_minus");
            Voz_plus  = GetColumnData(Voz_plus, "Voz_plus");
            Voz_minus = GetColumnData(Voz_minus, "Voz_minus");

            GatewayOpenVD_plus   = DataAccess.GetColumnData<string>($"SELECT GatewayOpenVD_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();
            GatewayCloseVD_plus  = DataAccess.GetColumnData<string>($"SELECT GatewayCloseVD_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();
            GatewayOpenVD_minus  = DataAccess.GetColumnData<string>($"SELECT GatewayOpenVD_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();
            GatewayCloseVD_minus = DataAccess.GetColumnData<string>($"SELECT GatewayCloseVD_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();

            GatewayOpenVoz_plus   = DataAccess.GetColumnData<string>($"SELECT GatewayOpenVoz_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();
            GatewayCloseVoz_plus  = DataAccess.GetColumnData<string>($"SELECT GatewayCloseVoz_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();
            GatewayOpenVoz_minus  = DataAccess.GetColumnData<string>($"SELECT GatewayOpenVoz_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();
            GatewayCloseVoz_minus = DataAccess.GetColumnData<string>($"SELECT GatewayCloseVoz_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();

            IDs = DataAccess.GetColumnData<int>($"SELECT GatewayScheduleID FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
        }

        private double[] GetColumnData(double[] someArray, string columnName)
        {
            return someArray = DataAccess.GetColumnData<double>($"SELECT {columnName} FROM GatewaySchedule WHERE YearName = {YearOfCalculation} LIMIT 12").ToArray();
            
        }

        public override string ToString()
        {
            string output = "\nGatewaySchedule:";

            for (int i = 0; i < 12; i++)
            {
                output += $"\n\tVD_plus[{i}] = {VD_plus[i]}; VD_minus[{i}] = {VD_minus[i]}; Voz_plus[{i}] = {Voz_plus[i]}; Voz_minus[{i}] = {Voz_minus[i]}; " +
                    $"GataewayOpenVD_plus[{i}] = {GatewayOpenVD_plus[i]}; GataewayCloseVD_plus[{i}] = {GatewayCloseVD_plus[i]}; " +
                    $"GataewayOpenVD_minus[{i}] = {GatewayOpenVD_minus[i]}; GataewayCloseVD_minus[{i}] = {GatewayCloseVD_minus[i]}; " +
                    $"GataewayOpenVoz_plus[{i}] = {GatewayOpenVoz_plus[i]}; GataewayCloseVoz_plus[{i}] = {GatewayCloseVoz_plus[i]}; " +
                    $"GataewayOpenVoz_minus[{i}] = {GatewayOpenVoz_minus[i]}; GataewayCloseVoz_minus[{i}] = {GatewayCloseVoz_minus[i]}; " +
                    $"MonthOfWorkGatewayVD[{i}] = {MonthsOfWorkGatewayVD[i]}; MonthOfWorkGatewayVoz[{i}] = {MonthsOfWorkGatewayVoz[i]}";
            }

            output += $"\n\tIsCalculateGatewaySchedule = {IsCalculateGS}";

            return output + "\n";
        }

        public void Delete()
        {
            DataAccess.Execute($"DELETE FROM GatewaySchedule WHERE YearName = {YearOfCalculation}");
        }

        public int[] Save()
        {
            string sql = "";

            for (int i = 0; i < 14; i++)
            {
                if (i < 12)
                {
                    sql += "INSERT INTO GatewaySchedule(VD_plus, VD_minus, Voz_plus, Voz_minus, GatewayOpenVD_plus, GatewayCloseVD_plus, GatewayOpenVD_minus, GatewayCloseVD_minus, " +
                        "GatewayOpenVoz_plus, GatewayCloseVoz_plus, GatewayOpenVoz_minus, GatewayCloseVoz_minus, MonthID, YearName) " +
                        $"VALUES({VD_plus[i]}, {VD_minus[i]}, {Voz_plus[i]}, {Voz_minus[i]}, {GatewayOpenVD_plus[i]}, {GatewayCloseVD_plus[i]}, " +
                        $"{GatewayOpenVD_minus[i]}, {GatewayCloseVD_minus[i]}, {GatewayOpenVoz_plus[i]}, {GatewayCloseVoz_plus[i]}, {GatewayOpenVoz_minus[i]}, " +
                        $"{GatewayCloseVoz_minus[i]}, {i + 1}, {YearOfCalculation});\n";
                }
                else
                {
                    sql += $"INSERT INTO GatewaySchedule(MonthID, YearName) VALUES({i + 1}, {YearOfCalculation});\n";
                }
            }

            sql = sql.Replace(",", ".");
            sql = sql.Replace(". ", ", ");
            sql = sql.Replace(" ,", " NULL,");

            DataAccess.Execute(sql);
            return IDs = DataAccess.GetColumnData<int>($"SELECT GatewayScheduleID FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
        }

        public void SaveEmpty()
        {
            string sql = "";

            for (int i = 1; i <= 14; i++)
            {
                sql += $"INSERT INTO GatewaySchedule(MonthID, YearName) VALUES ({i}, {YearOfCalculation});\n";
            }

            DataAccess.Execute(sql);
        }

        public void Update()
        {
            string sql = "";

            for (int i = 0; i < 12; i++)
            {
                switch (ItemsToUpdate)
                {
                    case ChoiceItems.Volumes: goto Volume;
                    case ChoiceItems.Dates:   goto Date;
                    default:
                    Volume:
                        sql += $"UPDATE GatewaySchedule SET VD_plus = {VD_plus[i]}, VD_minus = {VD_minus[i]}, Voz_plus = {Voz_plus[i]}, " +
                            $"Voz_minus = {Voz_minus[i]} WHERE YearName = {YearOfCalculation} AND MonthID = {i + 1};\n";

                        if (ItemsToUpdate != ChoiceItems.All)
                        {
                            break;
                        }

                    Date:
                        sql += $"UPDATE GatewaySchedule SET GatewayOpenVD_plus = {GatewayOpenVD_plus[i]}, GatewayCloseVD_plus = {GatewayCloseVD_plus[i]}, " +
                            $"GatewayOpenVD_minus = { GatewayOpenVD_minus[i]}, GatewayCloseVD_minus = { GatewayCloseVD_minus[i]}, " +
                            $"GatewayOpenVoz_plus = {GatewayOpenVoz_plus[i]}, GatewayCloseVoz_plus = {GatewayCloseVoz_plus[i]}, " +
                            $"GatewayOpenVoz_minus = {GatewayOpenVoz_minus[i]}, GatewayCloseVoz_minus = {GatewayCloseVoz_minus[i]} " +
                            $"WHERE YearName = {YearOfCalculation} " +
                            $"AND MonthID = {i + 1};\n";
                        break;
                }
            }

            sql = sql.Replace(",", ".");
            sql = sql.Replace(". ", ", ");
            sql = sql.Replace(" ,", " NULL,");
            sql = sql.Replace("  WHERE", "NULL WHERE");

            DataAccess.Execute(sql);
        }

        public void SetMonthOfWorkGateway()
        {
            List<string> VDGPlus = new List<string>();
            List<string> VDGMinus = new List<string>();
            List<string> VozGPlus = new List<string>();
            List<string> VozGMinus = new List<string>();

            for (int i = 0, j = 0; i < 24; i++)
            {
                if (i % 2 == 0)
                {
                    VDGPlus.Add(GatewayOpenVD_plus[j]);
                    VDGMinus.Add(GatewayOpenVD_minus[j]);
                    VozGPlus.Add(GatewayOpenVoz_plus[j]);
                    VozGMinus.Add(GatewayOpenVoz_minus[j]);
                }
                else
                {
                    VDGPlus.Add(GatewayCloseVD_plus[j]);
                    VDGMinus.Add(GatewayCloseVD_minus[j]);
                    VozGPlus.Add(GatewayCloseVoz_plus[j]);
                    VozGMinus.Add(GatewayCloseVoz_minus[j]);

                    j++;
                }
            }

            MonthsOfWorkGatewayVD = GetScheduleOfWorkGateway(GetMonthsOfTimeOfWorkAGateway(VDGPlus), GetMonthsOfTimeOfWorkAGateway(VDGMinus));
            MonthsOfWorkGatewayVoz = GetScheduleOfWorkGateway(GetMonthsOfTimeOfWorkAGateway(VozGPlus), GetMonthsOfTimeOfWorkAGateway(VozGMinus));
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

        private byte[] GetMonthsOfTimeOfWorkAGateway(List<string> datesWorking)
        {
            byte[] monthsOfWork = new byte[12];
            bool isGatewayOpen = false;

            for (int i = 0, pointer = 0; i < datesWorking.Count; i++)
            {
                if (datesWorking[i] != null && datesWorking[i].Length > 0)
                {
                    if (i % 2 == 0)
                    {
                        isGatewayOpen = true;
                    }
                    else if (i % 2 != 0)
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

    }
}
