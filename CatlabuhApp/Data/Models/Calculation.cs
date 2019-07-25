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
        //private OtherData otherData;
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
            DataAccess.Execute($"DELETE FROM InputData WHERE YearName = {YearOfCalculation}" +
                $"DELETE FROM GatewaySchedule WHERE YearName = {YearOfCalculation}" +
                $"DELETE FROM OutputData WHERE YearName = {YearOfCalculation}" +
                $"DELETE FROM YearsOfCalculartions WHERE YearName = {YearOfCalculation}");
        }

        public void Save()
        {
            DataAccess.Execute($"INSERT INTO YearsOfCaculations(YearName) VALUES({YearOfCalculation})");
            inputData.Save();

            if (IsEnterGatewaySchedule)
            {
                gatewaySchedule.Save();
            }

            outputData.Save();
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
