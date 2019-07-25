using CatlabuhApp.Data.Access;

namespace CatlabuhApp.Data.Models
{
    public class GatewaySchedule : Calculation.IComponent
    {
        public IDataAccess DataAccess { get; private set; }
        public int[] IDs { get; set; }
        public string YearOfCalculation { get; set; }

        public double[] VD_plus   { get; set; } = new double[12];
        public double[] VD_minus  { get; set; } = new double[12];
        public double[] Voz_plus  { get; set; } = new double[12];
        public double[] Voz_minus { get; set; } = new double[12];

        public double[] SumsOfVolume     { get; set; } = new double[4];
        public double[] ProcentsOfVolume { get; set; } = new double[4];

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

            VD_plus   = DataAccess.GetColumnData<double>($"SELECT VD_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            VD_minus  = DataAccess.GetColumnData<double>($"SELECT VD_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            Voz_plus  = DataAccess.GetColumnData<double>($"SELECT Voz_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            Voz_minus = DataAccess.GetColumnData<double>($"SELECT Voz_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();

            GatewayOpenVD_plus   = DataAccess.GetColumnData<string>($"SELECT GatewayOpenVD_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            GatewayCloseVD_plus  = DataAccess.GetColumnData<string>($"SELECT GatewayCloseVD_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            GatewayOpenVD_minus  = DataAccess.GetColumnData<string>($"SELECT GatewayOpenVD_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            GatewayCloseVD_minus = DataAccess.GetColumnData<string>($"SELECT GatewayCloseVD_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();

            GatewayOpenVoz_plus   = DataAccess.GetColumnData<string>($"SELECT GatewayOpenVoz_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            GatewayCloseVoz_plus  = DataAccess.GetColumnData<string>($"SELECT GatewayCloseVoz_plus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            GatewayOpenVoz_minus  = DataAccess.GetColumnData<string>($"SELECT GatewayOpenVoz_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
            GatewayCloseVoz_minus = DataAccess.GetColumnData<string>($"SELECT GatewayCloseVoz_minus FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();

            IDs = DataAccess.GetColumnData<int>($"SELECT GatewayScheduleID FROM GatewaySchedule WHERE YearName = {YearOfCalculation}").ToArray();
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
                    sql += "INSERT INTO GatewaySchedule(VD_plus, VD_minus, Voz_plus, Voz_minus, GatewayOpenVD, GatewayCloseVD, GatewayOpenVoz, " +
                        $"GatewayCloseVoz, MonthID, YearName) VALUES({VD_plus[i]}, {VD_minus[i]}, {Voz_plus[i]}, {Voz_minus[i]}, " +
                        $"{GatewayOpenVD_plus[i]}, {GatewayCloseVD_plus[i]}, {GatewayOpenVD_minus[i]}, {GatewayCloseVD_minus[i]}," +
                        $" {GatewayOpenVoz_plus[i]}, {GatewayCloseVoz_plus[i]}, {GatewayOpenVoz_minus[i]}, {GatewayCloseVoz_minus[i]}, " +
                        $"{i + 1}, {YearOfCalculation});\n";
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
                        sql += $"UPDATE GatewaySchedule SET VD_plus = {VD_plus[i]}, VD_minus = {Voz_minus}, Voz_plus = {Voz_plus[i]}, " +
                            $"Voz_minus = {Voz_minus[i]} WHERE YearName = {YearOfCalculation} AND MonthID = {i + 1};\n";

                        if (ItemsToUpdate != ChoiceItems.All)
                        {
                            break;
                        }

                    Date:
                        sql += $"UPDATE GatewaySchedule SET GatewayOpenVD_plus = {GatewayOpenVD_plus[i]}, GatewayCloseVD_plus = {GatewayCloseVD_plus[i]}, " +
                            $"GatewayOpenVD_minus = { GatewayOpenVD_minus[i]}, GatewayCloseVD_minus = { GatewayCloseVD_minus[i]}, " +
                            $"GatewayOpenVoz_plus = {GatewayOpenVoz_plus[i]}, GatewayCloseVoz_plus = {GatewayCloseVoz_plus[i]} " +
                            $"GatewayOpenVoz_minus = {GatewayOpenVoz_minus[i]}, GatewayCloseVoz_minus = {GatewayCloseVoz_minus[i]} " +
                            $"WHERE YearName = {YearOfCalculation} " +
                            $"AND MonthID = {i + 1};\n";
                        break;
                }
            }

            sql = sql.Replace(",", ".");
            sql = sql.Replace(". ", ", ");
            sql = sql.Replace(" ,", " NULL,");
            sql = sql.Replace(" WHERE", "NULL WHERE");

            DataAccess.Execute(sql);
        }
    }
}
