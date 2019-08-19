using CatlabuhApp.Data.Access;
using System;
using System.Collections.Generic;

namespace CatlabuhApp.Data.Models
{
    public partial class Calculation
    {
        public IDataAccess DataAccess { get; private set; }
        public string YearOfCalculation { get; set; }

        private InputData inputData;
        private OutputData outputData;
        private GatewaySchedule gatewaySchedule;

        public bool IsEnterGatewaySchedule { get; set; }
        public bool IsExist
        {
            get
            {
                List<int> calcYears = DataAccess.GetColumnData<int>("SELECT YearName FROM YearsOfCalculations");
                return calcYears.Exists(x => x == Convert.ToInt32(YearOfCalculation));
            }
        }

        private OutputData.WaterLevel waterLevel;
        private int waterLevelPercent;

        public OutputData.WaterLevel WaterLevel { get => waterLevel; }
        public int WaterLevelPercent { get => waterLevelPercent; }

        public Calculation(IDataAccess access)
        {
            this.DataAccess = access;
        }

        public Calculation(IDataAccess access, InputData inputData) : this(access)
        {
            this.inputData = inputData;
            IsEnterGatewaySchedule = false;

            outputData = new OutputData(access, inputData) { YearOfCalculation = inputData.YearOfCalculation };
            YearOfCalculation = inputData.YearOfCalculation;
        }

        public Calculation(IDataAccess access, InputData inputData, GatewaySchedule gatewaySchedule) : this(access)
        {
            this.inputData = inputData;
            this.gatewaySchedule = gatewaySchedule;
            this.gatewaySchedule.YearOfCalculation = inputData.YearOfCalculation;
            IsEnterGatewaySchedule = true;
            this.gatewaySchedule.IsEnterGatewaySchedule = IsEnterGatewaySchedule;

            outputData = new OutputData(access, inputData, gatewaySchedule) { YearOfCalculation = inputData.YearOfCalculation };
            YearOfCalculation = inputData.YearOfCalculation;
        }

        public void Calculate()
        {
            outputData.Calculate();
            outputData.GetItemsOfCalcuation(out inputData, out gatewaySchedule, out waterLevel, out waterLevelPercent);
        }

        public void Delete()
        {
            DataAccess.Execute($"DELETE FROM InputData WHERE YearName = {YearOfCalculation};\n" +
                $"DELETE FROM GatewaySchedule WHERE YearName = {YearOfCalculation};\n" +
                $"DELETE FROM OutputData WHERE YearName = {YearOfCalculation};\n" +
                $"DELETE FROM OtherData WHERE YearName = {YearOfCalculation};\n" +
                $"DELETE FROM YearsOfCalculations WHERE YearName = {YearOfCalculation};");
        }

        public void Save(bool isOutputDataEmpty)
        {
            DataAccess.Execute($"INSERT INTO YearsOfCalculations(YearName) VALUES({YearOfCalculation});");
            inputData.Save();

            if (IsEnterGatewaySchedule)
            {
                gatewaySchedule.Save();
            }
            else
            {
                gatewaySchedule = new GatewaySchedule(DataAccess)
                {
                    YearOfCalculation = this.YearOfCalculation
                };
                gatewaySchedule.SaveEmpty();
            }

            if (!isOutputDataEmpty)
            {
                outputData.Save();
            }
            else
            {
                outputData.SaveEmpty();

                string sql = $"UPDATE OutputData SET S1 = {inputData.S1InJanury} WHERE YearName = {YearOfCalculation} AND MonthID = 1;\n" +
                    $"UPDATE OutputData SET Vg = {inputData.SumVg} WHERE YearName = {YearOfCalculation} AND MonthID = 13;";
                DataAccess.Execute(sql.Replace(",", "."));
            }
        }

        public void Update()
        {
            if (inputData == null || gatewaySchedule == null || outputData == null)
            {
                throw new ArgumentNullException("inputData or gatewaySchedule or outputData equals null");
            }
            else
            {
                inputData.Update();
                outputData.Update();

                if (IsEnterGatewaySchedule)
                {
                    gatewaySchedule.Update();
                }
            }
        }

        public override string ToString()
        {
            string output = $"Calculation:";

            output += inputData.ToString();

            if (IsEnterGatewaySchedule)
            {
                output += gatewaySchedule.ToString();
            }

            output += outputData.ToString();

            return output;
        }

    }
}
