using CatlabuhApp.Data.Access;

namespace CatlabuhApp.Data.Models
{
    public class InputData : Calculation.IComponent
    {
        public IDataAccess DataAccess { get; private set; }
        public int[] IDs { get; set; }
        public string YearOfCalculation { get; set; }

        public double[] H1 { get; set; } = new double[12];
        public double[] H2 { get; set; } = new double[12];

        public double[] PIsmail  { get; set; } = new double[12];
        public double[] PBolgrad { get; set; } = new double[12];

        public double[] Vz { get; set; } = new double[12];
        public double[] D  { get; set; } = new double[12];
        public double[] E  { get; set; } = new double[12];

        public bool IsCalculateE { get; set; }
        public double S1InJanury { get; set; }
        public double SumVg { get; set; }

        public InputData() { }

        public InputData(IDataAccess dataAccess)
        {
            DataAccess = dataAccess ?? throw new System.ArgumentNullException(nameof(dataAccess));
        }

        public InputData(IDataAccess dataAccess, string yearOfCalculation) : this(dataAccess)
        {
            YearOfCalculation = yearOfCalculation ?? throw new System.ArgumentNullException(nameof(yearOfCalculation));

            H1 = GetColumnData(H1, "H1");
            H2 = GetColumnData(H2, "H2");

            PIsmail  = GetColumnData(PIsmail, "PIsmail");
            PBolgrad = GetColumnData(PBolgrad, "PBolgrad");

            Vz = GetColumnData(Vz, "Vz");
            D  = GetColumnData(D, "D");
            E  = GetColumnData(E, "E");

            S1InJanury = DataAccess.GetCellData<double>($"SELECT S1 FROM OtherData WHERE YearName = {YearOfCalculation}");
            SumVg = DataAccess.GetCellData<double>($"SELECT CoefficientValue FROM Coefficients WHERE CoefficientID = 36");

            IDs = DataAccess.GetColumnData<int>($"SELECT InputDataID FROM InputData WHERE YearName = {YearOfCalculation}").ToArray();
        }

        private double[] GetColumnData(double[] someArray, string columnName)
        {
            try
            {
                someArray = DataAccess.GetColumnData<double>($"SELECT {columnName} FROM InputData WHERE YearName = {YearOfCalculation}").ToArray();
            }
            catch (System.NullReferenceException ex)
            {
                for (int i = 0; i < 12; i++)
                {
                    someArray[i] = 0;
                }
            }

            return someArray;
        }

        public override string ToString()
        {
            string output = "\nInputData:";

            for (int i = 0; i < 12; i++)
            {
                output += $"\n\tH1[{i}] = {H1[i]}; H2[{i}] = {H2[i]}; PIsmail[{i}] = {PIsmail[i]}; PBolgrad[{i}] = {PBolgrad[i]}; Vz[{i}] = {Vz[i]}; " +
                    (IsCalculateE ? $"D[{i}] = {D[i]}" : $"E[{i}] = {E[i]}");
            }

            output += $"\n\tIsCalculateE = {IsCalculateE}; S1InJanury = {S1InJanury}; SumVg = {SumVg}";

            return output + "\n";
        }

        public void Delete()
        {
            DataAccess.Execute($"DELETE FROM InputData WHERE YearName = {YearOfCalculation}");
        }

        public int[] Save()
        {
            string sql = "";

            for (int i = 0; i < 14; i++)
            {
                if (i < 12)
                {
                    sql += $"INSERT INTO InputData(H1, H2, PIsmail, PBolgrad Vz, {(IsCalculateE ? "d" : "E")}, MonthID, YearName) " +
                        $"VALUES({H1[i]}, {H2[i]}, {PIsmail[i]}, {PBolgrad[i]}, {Vz[i]}, {(IsCalculateE ? D[i] : E[i])}, {i + 1}, {YearOfCalculation});\n";
                }
                else
                {
                    sql += $"INSERT INTO InputData(MonthID, YearName) VALUES({i + 1}, {YearOfCalculation});\n";
                }
            }

            sql += $"INSERT INTO OtherData(S1InJanuary, YearName) VALUES({S1InJanury}, {YearOfCalculation})";

            sql = sql.Replace(",", ".");
            sql = sql.Replace(". ", ", ");

            DataAccess.Execute(sql);
            return IDs = DataAccess.GetColumnData<int>($"SELECT InputDataID FROM InputData WHERE YearName = {YearOfCalculation}").ToArray();
        }

        public void Update()
        {
            string sql = "";

            for (int i = 0; i < 12; i++)
            {
                sql += $"UPDATE InputData SET H1 = {H1[i]}, H2 = {H2[i]}, PIsmail = {PIsmail[i]}, PBolgrad[{i}] = {PBolgrad[i]}, Vz = {Vz[i]}, " +
                    $"d = {D[i]}, E = {E[i]} WHERE YearName = {YearOfCalculation} AND MonthID = {i + 1};\n";
            }

            sql = sql.Replace(",", ".");
            sql = sql.Replace(". ", ", ");

            DataAccess.Execute(sql);
        }
    }
}
