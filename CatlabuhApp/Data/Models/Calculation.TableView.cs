using System.Data;

namespace CatlabuhApp.Data.Models
{
    partial class Calculation
    {
        public DataTable WaterBalanceProfit
        {
            get
            {
                return GetView(PartOfCalculation.WaterBalanceProfit);
            }
        }
        public DataTable WaterBalanceConsumable
        {
            get
            {
                return GetView(PartOfCalculation.WaterBalanceConsumable);
            }
        }
        public DataTable SaltBalanceProfit
        {
            get
            {
                return GetView(PartOfCalculation.SaltBalanceProfit);
            }
        }
        public DataTable SaltBalanceConsumable
        {
            get
            {
                return GetView(PartOfCalculation.SaltBalanceConsumable);
            }
        }

        public enum PartOfCalculation
        {
            WaterBalanceProfit, WaterBalanceConsumable, SaltBalanceProfit, SaltBalanceConsumable
        }

        private DataTable GetView(PartOfCalculation part)
        {
            string sql = "SELECT\n\t";

            string monthView = "", avrHView = "", pIsmailView = "", pBolgradView = "";

            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    monthView = "m.MonthName_EN AS[Month]";
                    avrHView = "avr. H";
                    pIsmailView = "i.PIsmail AS[P Ism.]";
                    pBolgradView = "i.PBolgrad AS[P Bolg.]";
                    break;
                case "uk-UA":
                    monthView = "m.MonthName_UA AS[Місяць]";
                    avrHView = "H ср.";
                    pIsmailView = "i.PIsmail AS[P Ізм.]";
                    pBolgradView = "i.PBolgrad AS[P Болг.]";
                    break;
                case "ru-RU":
                    monthView = "m.MonthName_RU AS[Месяц]";
                    avrHView = "H ср.";
                    pIsmailView = "i.PIsmail AS[P Изм.]";
                    pBolgradView = "i.PBolgrad AS[P Болг.]";
                    break;
            }

            switch (part)
            {
                case PartOfCalculation.WaterBalanceProfit:
                    sql += $"{monthView}, i.H1, i.H2, o.avr_H AS[{avrHView}], o.W1, o.W2, o.dlt_W AS[∆W], o.F AS[F({avrHView})], " +
                        $"{pIsmailView}, {pBolgradView}, o.Vp, o.Vr, o.Vb, o.Vg, o.Vdr, o.EP AS[∑P], gs.VD_plus AS[VD+], gs.Voz_plus AS[Voz+], o.dlt_Vni AS[∆Vні], ";
                    break;
                case PartOfCalculation.WaterBalanceConsumable:
                    sql += $"{monthView}, i.d, o.lgd AS[lg(d)], o.lgE AS[lg(E)], i.E, o.Etr, o.VE, o.Vtr, o.Vf, i.Vz, " +
                        "o.ER AS[∑R], gs.VD_minus AS[VD-], gs.Voz_minus AS[Voz-], ";
                    break;
                case PartOfCalculation.SaltBalanceProfit:
                    sql += $"{monthView}, o.W1, o.W2, o.Vp, o.Vr, o.Vb, o.Vg, o.Vdr, gs.VD_plus AS[VD+], gs.Voz_plus AS[Voz+], " +
                        "o.S1, o.S2, o.Sp, o.Sr, o.Sb, o.Sg, o.Sdr, o.SD_plus AS[SD+], o.Soz_plus AS[Soz+], o.C1, o.C2, o.Cp, o.Cr, o.Cb, " +
                        "o.Cg, o.Cdr, o.CD_plus AS[CD+], o.Coz_plus AS[Coz+], o.EpCi_plus AS[∑pCi+], ";
                    break;
                case PartOfCalculation.SaltBalanceConsumable:
                    sql += $"{monthView}, o.VE, o.Vtr, o.Vf, i.Vz, gs.VD_minus AS[VD], gs.Voz_minus AS[Voz-], o.Sf, o.Sz, " +
                        "o.SD_minus AS[SD-], o.Soz_minus AS[Soz-], o.Cf, o.Cz, o.CD_minus AS[CD-], o.Coz_minus AS[Coz-], o.EpCi_minus AS[∑pCi-], ";
                    break;
            }

            sql += "\ti.inputDataID, gs.GatewayScheduleID, o.OutputDataID, o.MonthID, o.YearName\n";
            sql += "FROM OutputData o JOIN InputData i JOIN GatewaySchedule gs JOIN Months m\n" +
                "WHERE i.MonthID = gs.MonthID AND gs.MonthID = o.MonthID AND o.MonthID = m.MonthID AND " +
                    $"i.YearName = gs.YearName AND gs.YearName = o.YearName AND o.YearName = {YearOfCalculation}";

            return DataAccess.GetTableView(sql);
        }

        public static string[] GetDBColumnsName(PartOfCalculation part)
        {
            string[] columnsDBNames = null;
            
            switch (part)
            {
                case PartOfCalculation.WaterBalanceProfit:
                    columnsDBNames = new string[]
                    {
                        "H1", "H2", "avr_H", "W1", "W2", "dlt_W", "F", "PIsmail", "PBolgrad", "Vp", "Vr", "Vb", "Vg", "Vdr", "EP", "VD_plus", "Voz_plus", "dlt_Vni"
                    };
                    break;
                case PartOfCalculation.WaterBalanceConsumable:
                    columnsDBNames = new string[]
                    {
                        "d", "lgd", "lgE", "E", "Etr", "VE", "Vtr", "Vf", "Vz", "ER", "VD_minus", "Voz_minus"
                    };
                    break;
                case PartOfCalculation.SaltBalanceProfit:
                    columnsDBNames = new string[]
                    {
                        "W1", "W2", "Vp", "Vr", "Vb", "Vg", "Vdr", "VD_plus", "Voz_plus", "S1", "S2", "Sp", "Sr", "Sb",
                        "Sg", "Sdr", "SD_plus", "Soz_plus", "C1", "C2", "Cp", "Cr", "Cb", "Cg", "Cdr", "CD_plus", "Coz_plus", "EpCi_plus"
                    };
                    break;
                case PartOfCalculation.SaltBalanceConsumable:
                    columnsDBNames = new string[]
                    {
                        "VE", "Vtr", "Vf", "Vz", "VD_minus", "Voz_minus", "Sf", "Sz", "SD_minus", "Soz_minus", "Cf", "Cz", "CD_minus", "Coz_minus", "EpCi_minus"
                    };
                    break;
            }

            return columnsDBNames;
        }
    }
}
