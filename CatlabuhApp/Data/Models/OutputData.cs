using CatlabuhApp.Data.Access;

namespace CatlabuhApp.Data.Models
{
    public partial class OutputData : Calculation.IComponent
    {
        public IDataAccess DataAccess { get; private set; }
        public int[] IDs { get; set; }
        public string YearOfCalculation { get; set; }

        #region Водный баланс приходная часть
        private double[] avrH = new double[12];
        private double[] w1 = new double[12];
        private double[] w2 = new double[12];
        private double[] dltW = new double[12];
        private double[] f = new double[12];
        private double[] vp = new double[12];
        private double[] vr = new double[12];
        private double[] vb = new double[12];
        private double[] vg = new double[12];
        private double[] vdr = new double[12];
        private double[] ep = new double[12];
        private double[] dltVni = new double[12];

        private double[] sumsOfWBP = new double[10];        // |  P | Vp | Vr | Vb |  Vg | Vdr |      EP |  VD_plus | Voz_plus | dlt_Vni |
        private double[] percentsOfWBP = new double[9];     // | Vp | Vr | Vb | Vg | Vdr |  EP | VD_plus | Voz_plus |  dlt_Vni |         |
                                                            // |  0 |  1 |  2 |  3 |  4  |  5  |     6   |    7     |     8    |    9    |           
        #endregion
        #region Водный баланс расходная часть
        private double[] lgD = new double[12];
        private double[] lgE = new double[12];
        private double[] etr = new double[12];
        private double[] ve = new double[12];
        private double[] vtr = new double[12];
        private double[] vf = new double[12];
        private double[] er = new double[12];

        private double[] sumsOfWBC = new double[9];         // |  E | Etr | VE | Vtr | Vf |       Vz |        ER | VD_minus | Voz_minus |
        private double[] percentsOfWBC = new double[7];     // | VE | Vtr | Vf |  Vz | ER | VD_minus | Voz_minus |          |           |
                                                            // |  0 |  1  |  2 |  3  |  4 |     5    |     6     |     7    |     8     |        
        #endregion
        #region Солевой баланс приходная часть
        private double[] s1 = new double[12];
        private double[] s2 = new double[12];
        private double[] sp = new double[12];
        private double[] sr = new double[12];
        private double[] sb = new double[12];
        private double[] sg = new double[12];
        private double[] sdr = new double[12];
        private double[] sdPlus = new double[12];
        private double[] sozPlus = new double[12];
        private double[] c1 = new double[12];
        private double[] c2 = new double[12];
        private double[] cp = new double[12];
        private double[] cr = new double[12];
        private double[] cb = new double[12];
        private double[] cg = new double[12];
        private double[] cdr = new double[12];
        private double[] cdPlus = new double[12];
        private double[] cozPlus = new double[12];
        private double[] epciPlus = new double[12];

        private double[] sumsOfSBP = new double[8];         // | Cp | Cr | Cb | Cg | Cdr | CD_plus | Coz_plus | EpCi_plus |
        private double[] percentsOfSBP = new double[8];     // | Cp | Cr | Cb | Cg | Cdr | CD_plus | Coz_plus | EpCi_plus |
                                                            // |  0 |  1 |  2 |  3 |  4  |    5    |    6     |     7     |
        #endregion
        #region Солевой баланс приходная часть
        private double[] sf = new double[12];
        private double[] sz = new double[12];
        private double[] sdMinus = new double[12];
        private double[] sozMinus = new double[12];
        private double[] cf = new double[12];
        private double[] cz = new double[12];
        private double[] cdMinus = new double[12];
        private double[] cozMinus = new double[12];
        private double[] epciMinus = new double[12];

        private double[] sumsOfSBC = new double[5];         // | Cf | Cz | CD_minus | Coz_minus | EpCi_minus |
        private double[] percentsOfSBC = new double[5];     // | Cf | Cz | CD_minus | Coz_minus | EpCi_minus |
                                                            // |  0 |  1 |     2    |      3    |     4      |
        #endregion

        public enum WaterLevel
        {
            High, Average, Low
        }
        private WaterLevel waterLevel;
        private int waterLevelPercent;

        private InputData inputData = new InputData();          // Входные данные.
        private GatewaySchedule gs = new GatewaySchedule();     // График работы шлюзов.

        private readonly double[] coefficients;         // Коэффициенты необходимые для расчета(храняться в БД).
        private readonly double[] k1 = new double[6];   // Коэффициенты для расчета Etr, от 5 до 11 месяца.
        private readonly double[] k2 = new double[6];   // Коэффициенты для расчета lgE,
        private readonly double[] k3 = new double[6];   // от 4 до 10 месяца.

        public OutputData(IDataAccess dataAccess)
        {
            DataAccess = dataAccess ?? throw new System.ArgumentNullException(nameof(dataAccess));
        }

        public OutputData(IDataAccess dataAccess, InputData inputData) : this(dataAccess)
        {
            coefficients = DataAccess.GetColumnData<double>($"SELECT CoefficientValue FROM Coefficients").ToArray();

            for (int i = 13, j = 0, k = 0; i < 25; i++)
            {
                if (i < 19)
                {
                    k1[j] = coefficients[i];
                    j++;
                }
                else
                {
                    k2[k] = coefficients[i];
                    k3[k] = coefficients[i + 6];
                    k++;
                }
            }

            this.inputData = inputData ?? throw new System.ArgumentNullException(nameof(inputData));
        }

        public OutputData(IDataAccess dataAccess, InputData inputData, GatewaySchedule gs) : this(dataAccess, inputData)
        {
            this.gs = gs ?? throw new System.ArgumentNullException(nameof(gs));
        }

        public void GetItemsOfCalcuation(out InputData inputData, out GatewaySchedule gs, out WaterLevel waterLevel, out int waterLevelPercent)
        {
            inputData = this.inputData;
            gs = this.gs;
            waterLevel = this.waterLevel;
            waterLevelPercent = this.waterLevelPercent;
        }

        public void GetWaterLevel(out WaterLevel waterLevel, out int waterLevelPercent)
        {
            waterLevel = this.waterLevel;
            waterLevelPercent = this.waterLevelPercent;
        }
        
        public override string ToString()
        {
            string output = "\nOutputData:";

            for (int i = 0; i < 12; i++)
            {
                output += $"\n\tavrH[{i}] = {avrH[i]}; w1[{i}] = {w1[i]}; w2[{i}] = {w2[i]}; dltW[{i}] = {dltW[i]}; f[{i}] = {f[i]}; vp[{i}] = {vp[i]}; " +
                    $"vr[{i}] = {vr[i]}; vb[{i}] = {vb[i]}; vg[{i}] = {vg[i]}; vdr[{i}] = {vdr[i]}; ep[{i}] = {ep[i]}; dltVni[{i}] = {dltVni[i]}";
            }

            output += "\n";

            for (int i = 0; i < 9; i++)
            {
                output += $"\n\tsumsOfWBP[{i}] = {sumsOfWBP[i]}" + (i < 8 ? $"; procentsOfWBP[{i}] = {percentsOfWBP[i]}" : "");
            }

            output += "\n\n\tWater Balance Consumable:";

            for (int i = 0; i < 12; i++)
            {
                output += $"\n\tlgD[{i}] = {lgD[i]}; lgE[{i}] = {lgE[i]}; etr[{i}] = {etr[i]}; ve[{i}] = {ve[i]}; vtr[{i}] = {vtr[i]}; " +
                    $"vf[{i}] = {vf[i]}; er[{i}] = {er[i]}";
            }

            output += "\n";

            for (int i = 0; i < 9; i++)
            {
                output += $"\n\tsumsOfWBC[{i}] = {sumsOfWBC[i]}" + (i < 7 ? $"; procentsOfWBC[{i}] = {percentsOfWBC[i]}" : "");
            }

            output += "\n\n\tSalt Balance Profit:";

            for (int i = 0; i < 12; i++)
            {
                output += $"\n\ts1[{i}] = {s1[i]}; s2[{i}] = {s2[i]}; sp[{i}] = {sp[i]}; sr[{i}] = {sr[i]}; sb[{i}] = {sb[i]}; " +
                    $"sg[{i}] = {sg[i]}; sdr[{i}] = {sdr[i]}; sdPlus[{i}] = {sdPlus[i]}; sozPlus[{i}] = {sozPlus[i]}; " +
                    $"c1[{i}] = {c1[i]}; c2[{i}] = {c2[i]}; cp[{i}] = {cp[i]}; cr[{i}] = {cr[i]}; cb[{i}] = {cb[i]}; " +
                    $"cg[{i}] = {cg[i]}; cdr[{i}] = {cdr[i]}; cdPlus[{i}] = {cdPlus[i]}; cozPlus[{i}] = {cozPlus[i]}; " +
                    $"epciPlus[{i}] = {epciPlus[i]}";
            }

            output += "\n";

            for (int i = 0; i < 8; i++)
            {
                output += $"\n\tsumsOfSBP[{i}] = {sumsOfSBP[i]}; procentsOfSBP[{i}] = {percentsOfSBP[i]}";
            }

            output += "\n\n\tSalt Balance Consumable:";

            for (int i = 0; i < 12; i++)
            {
                output += $"\n\tsf[{i}] = {sf[i]}; sz[{i}] = {sz[i]}; sdMinus[{i}] = {sdMinus[i]}; sozMinus[{i}] = {sozMinus[i]}; " +
                    $"cf[{i}] = {cf[i]}; cz[{i}] = {cz[i]}; cdMinus[{i}] = {cdMinus[i]}; cozMinus[{i}] = {cozMinus[i]}; " +
                    $"epciMinus[{i}] = {epciMinus[i]}";
            }

            output += "\n";

            for (int i = 0; i < 5; i++)
            {
                output += $"\n\tsumsOfSBC[{i}] = {sumsOfSBC[i]}; procentsOfSBC[{i}] = {sumsOfSBC[i]}";
            }

            return output + "\n";
        }

        public void Delete()
        {
            DataAccess.Execute($"DELETE FROM OutputData WHERE YearName = {YearOfCalculation}");
        }

        public int[] Save()
        {
            string sql = "";

            for (int i = 0; i < 14; i++)
            {
                if (i < 12)
                {
                    sql += "INSERT INTO OutputData(avr_H, W1, W2, dlt_W, F, Vp, Vr, Vb, Vg, Vdr, EP, dlt_Vni, lgd, lgE, Etr, VE, Vtr, Vf, " +
                        "ER, S1, S2, Sp, Sr, Sb, Sg, Sdr, SD_plus, Soz_plus, C1, C2, Cp, Cr, Cb, Cg, Cdr, CD_plus, Coz_plus, EpCi_plus, Sf, " +
                        "Sz, SD_minus, Soz_minus, Cf, Cz, CD_minus, Coz_minus, EpCi_minus, MonthID, YearName) " +
                        $"VALUES ({avrH[i]}, {w1[i]}, {w2[i]}, {dltW[i]}, {f[i]}, {vp[i]}, {vr[i]}, {vb[i]}, {vg[i]}, {vdr[i]}, {ep[i]}, {dltVni[i]}, " +
                        $"{lgD[i]}, {lgE[i]}, {etr[i]}, {ve[i]}, {vtr[i]}, {vf[i]}, {er[i]}, {s1[i]}, {s2[i]}, {sp[i]}, {sr[i]}, {sb[i]}, {sg[i]}, " +
                        $"{sdr[i]}, {sdPlus[i]}, {sozPlus[i]}, {c1[i]}, {c2[i]}, {cp[i]}, {cr[i]}, {cb[i]}, {cg[i]}, {cdr[i]}, {cdPlus[i]}, {cozPlus[i]}, " +
                        $"{epciPlus[i]}, {sf[i]}, {sz[i]}, {sdMinus[i]}, {sozMinus[i]}, {cf[i]}, {cz[i]}, {cdMinus[i]}, {cozMinus[i]}, {epciMinus[i]}, " +
                        $"{i + 1}, {YearOfCalculation});\n";

                    if (inputData != null && inputData.IsCalculateE)
                    {
                        sql += $"UPDATE InputData SET E = {inputData.E[i]} WHERE MonthID = {i + 1}, YearName = {YearOfCalculation};\t";
                    }
                    if (gs != null && gs.IsCalculateGS)
                    {
                        sql += $"UPDATE GatewaySchedule SET VD_plus = {gs.VD_plus[i]}, VD_minus = {gs.Voz_minus[i]}, Voz_plus = {gs.Voz_plus[i]}, " +
                            $"Voz_minus = {gs.Voz_minus[i]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\t";
                    }
                }
                else if (i == 12)
                {
                    sql += "INSERT INTO OutputData(Vp, Vr, Vb, Vg, Vdr, EP, dlt_Vni, Etr, VE, Vtr, Vf, ER, Cp, Cr, Cb, Cg, Cdr, CD_plus, Coz_plus, " +
                        "EpCi_plus, Cf, Cz, CD_minus, Coz_minus, EpCi_minus, MonthID, YearName) " +
                        $"VALUES({sumsOfWBP[1]}, {sumsOfWBP[2]}, {sumsOfWBP[3]}, {sumsOfWBP[4]}, {sumsOfWBP[5]}, {sumsOfWBP[6]}, {sumsOfWBP[9]}, " +
                        $"{sumsOfWBC[1]}, {sumsOfWBC[2]}, {sumsOfWBC[3]}, {sumsOfWBC[4]}, {sumsOfWBC[6]}, " +
                        $"{sumsOfSBP[0]}, {sumsOfSBP[1]}, {sumsOfSBP[2]}, {sumsOfSBP[3]}, {sumsOfSBP[4]}, {sumsOfSBP[5]}, {sumsOfSBP[6]}, {sumsOfSBP[7]}, " +
                        $"{sumsOfSBC[0]}, {sumsOfSBC[1]}, {sumsOfSBC[2]}, {sumsOfSBC[3]}, {sumsOfSBC[4]}, {i + 1}, {YearOfCalculation});\n";

                    if (inputData != null)
                    {
                        sql += $"UPDATE InputData SET PIsmail = {sumsOfWBP[0]}, E = {sumsOfWBC[0]}, Vz = {sumsOfWBC[5]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\n";
                    }
                    if (gs != null)
                    {
                        sql += $"UPDATE GatewaySchedule SET VD_plus = {sumsOfWBP[7]}, VD_minus = {sumsOfWBC[7]}, Voz_plus = {sumsOfWBP[8]}, " +
                            $"Voz_minus = {sumsOfWBC[8]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\n";
                    }
                }
                else
                {
                    sql += "INSERT INTO OutputData(Vp, Vr, Vb, Vg, Vdr, EP, dlt_Vni, VE, Vtr, Vf, ER, Cp, Cr, Cb, Cb, Cg, Cdr, CD_plus, Coz_plus, EpCi_plus, " +
                        "Cf, Cz, CD_minus, Coz_minus, EpCi_minus, MonthID, YearName) " +
                        $"VALUES({percentsOfWBP[0]}, {percentsOfWBP[1]}, {percentsOfWBP[2]}, {percentsOfWBP[3]}, {percentsOfWBP[4]}, {percentsOfWBP[5]}, {percentsOfWBP[8]}, " +
                        $"{percentsOfWBC[0]}, {percentsOfWBC[1]}, {percentsOfWBC[2]}, {percentsOfWBC[3]}, {percentsOfWBC[4]}, {percentsOfSBP[0]}, " +
                        $"{percentsOfSBP[1]}, {percentsOfSBP[2]}, {percentsOfSBP[3]}, {percentsOfSBP[4]}, {percentsOfSBP[5]}, {percentsOfSBP[6]}, " +
                        $"{percentsOfSBP[7]}, {percentsOfSBC[0]}, {percentsOfSBC[1]}, {percentsOfSBC[2]}, {percentsOfSBC[3]}, {percentsOfSBC[4]}, " +
                        $"{i + 1}, {YearOfCalculation});\n";

                    if (inputData != null)
                    {
                        sql += $"UPDATE InputData SET Vz = {percentsOfWBC[3]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\n";
                    }
                    if (gs != null)
                    {
                        sql += $"UPDATE GatewaySchedule SET VD_plus = {percentsOfWBP[6]}, VD_minus = {percentsOfWBC[5]}, Voz_plus = {percentsOfWBP[7]}, " +
                            $"Voz_minus = {percentsOfWBC[6]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};";
                    }
                }
            }

            sql = sql.Replace(",", ".");
            sql = sql.Replace(". ", ", ");

            DataAccess.Execute(sql);
            return IDs = DataAccess.GetColumnData<int>($"SELECT OutputDataID FROM OutputData WHERE YearName = {YearOfCalculation}").ToArray();
        }

        public void SaveEmpty()
        {
            string sql = "";

            for (int i = 1; i <= 14; i++)
            {
                sql += $"INSERT INTO OutputData(MonthID, YearName) VALUES({i}, {YearOfCalculation});\n";
            }

            DataAccess.Execute(sql);
        }

        public void Update()
        {
            string sql = "";

            for (int i = 0; i < 14; i++)
            {
                if (i < 12)
                {
                    sql += $"UPDATE OutputData SET avr_H = {avrH[i]}, W1 = {w1[i]}, W2 = {w2[i]}, dlt_W = {dltW[i]}, F = {f[i]}, Vp = {vp[i]}, " +
                        $"Vr = {vr[i]}, Vb = {vb[i]}, Vg = {vg[i]}, Vdr = {vdr[i]}, EP = {ep[i]}, dlt_Vni = {dltVni[i]}, lgd = {lgD[i]}, lgE = {lgE[i]}, " +
                        $"Etr = {etr[i]}, VE = {ve[i]}, Vtr = {vtr[i]}, Vf = {vf[i]}, ER = {er[i]}, S1 = {s1[i]}, S2 = {s2[i]}, Sp = {sp[i]}, Sr = {sr[i]}, " +
                        $"Sb = {sb[i]}, Sg = {sg[i]}, Sdr = {sdr[i]}, SD_plus = {sdPlus[i]}, Soz_plus = {sozPlus[i]}, C1 = {c1[i]}, C2 = {c2[i]}, Cp = {cp[i]}, " +
                        $"Cr = {cr[i]}, Cb = {cb[i]}, Cg = {cg[i]}, Cdr = {cdr[i]}, CD_plus = {cdPlus[i]}, Coz_plus = {cozPlus[i]}, EpCi_plus = {epciPlus[i]}, " +
                        $"Sf = {sf[i]}, Sz = {sz[i]}, SD_minus = {sdMinus[i]}, Soz_minus = {sozMinus[i]}, Cf = {cf[i]}, Cz = {cz[i]}, CD_minus = {cdMinus[i]}, " +
                        $"Coz_minus = {cozMinus[i]}, EpCi_minus = {epciMinus[i]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\n";

                    if (inputData != null && inputData.IsCalculateE)
                    {
                        sql += $"UPDATE InputData SET E = {inputData.E[i]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\t";
                    }
                    if (gs != null && gs.IsCalculateGS)
                    {
                        sql += $"UPDATE GatewaySchedule SET VD_plus = {gs.VD_plus[i]}, VD_minus = {gs.Voz_minus[i]}, Voz_plus = {gs.Voz_plus[i]}, " +
                            $"Voz_minus = {gs.Voz_minus[i]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\t";
                    }
                }
                else if (i == 12)
                {
                    sql += $"UPDATE OutputData SET Vp = {sumsOfWBP[1]}, Vr = {sumsOfWBP[2]}, Vb = {sumsOfWBP[3]}, Vg = {sumsOfWBP[4]}, Vdr = {sumsOfWBP[5]}, " +
                        $"EP = {sumsOfWBP[6]}, dlt_Vni = {sumsOfWBP[9]}, Etr = {sumsOfWBC[1]}, VE = {sumsOfWBC[2]}, Vtr = {sumsOfWBC[3]}, Vf = {sumsOfWBC[4]}, ER = {sumsOfWBC[6]}, " +
                        $"Cp = {sumsOfSBP[0]}, Cr = {sumsOfSBP[1]}, Cb = {sumsOfSBP[2]}, Cg = {sumsOfSBP[3]}, Cdr = {sumsOfSBP[4]}, CD_plus = {sumsOfSBP[5]}, " +
                        $"Coz_plus = {sumsOfSBP[6]}, EpCi_plus = {sumsOfSBP[7]}, Cf = {sumsOfSBC[0]}, Cz = {sumsOfSBC[1]}, CD_minus = {sumsOfSBC[2]}, " +
                        $"Coz_minus = {sumsOfSBC[3]}, EpCi_minus = {sumsOfSBC[4]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\n";

                    if (inputData != null)
                    {
                        sql += $"UPDATE InputData SET PIsmail = {sumsOfWBP[0]}, E = {sumsOfWBC[0]}, Vz = {sumsOfWBC[5]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\n";
                    }
                    if (gs != null)
                    {
                        sql += $"UPDATE GatewaySchedule SET VD_plus = {sumsOfWBP[7]}, VD_minus = {sumsOfWBC[7]}, Voz_plus = {sumsOfWBP[8]}, " +
                            $"Voz_minus = {sumsOfWBC[8]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\n";
                    }
                }
                else
                {
                    sql += $"UPDATE OutputData SET Vp = {percentsOfWBP[0]}, Vr = {percentsOfWBP[1]}, Vb = {percentsOfWBP[2]}, Vg = {percentsOfWBP[3]}, Vdr = {percentsOfWBP[4]}, " +
                        $"EP = {percentsOfWBP[5]}, dlt_Vni = {percentsOfWBP[8]}, VE = {percentsOfWBC[0]}, Vtr = {percentsOfWBC[1]}, Vf = {percentsOfWBC[2]}, ER = {percentsOfWBC[4]}, Cp = {percentsOfSBP[0]}, " +
                        $"Cr = {percentsOfSBP[1]}, Cb = {percentsOfSBP[2]}, Cg = {percentsOfSBP[3]}, Cdr = {percentsOfSBP[4]}, CD_plus = {percentsOfSBP[5]}, Coz_plus = {percentsOfSBP[6]}, " +
                        $"EpCi_plus = {percentsOfSBP[7]}, Cf = {percentsOfSBC[0]}, Cz = {percentsOfSBC[1]}, CD_minus = {percentsOfSBC[2]}, Coz_minus = {percentsOfSBC[3]}, " +
                        $"EpCi_minus = {percentsOfSBC[4]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};";

                    if (inputData != null)
                    {
                        sql += $"UPDATE InputData SET Vz = {percentsOfWBC[3]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};\n";
                    }
                    if (gs != null)
                    {
                        sql += $"UPDATE GatewaySchedule SET VD_plus = {percentsOfWBP[6]}, VD_minus = {percentsOfWBC[5]}, Voz_plus = {percentsOfWBP[7]}, " +
                            $"Voz_minus = {percentsOfWBC[6]} WHERE MonthID = {i + 1} AND YearName = {YearOfCalculation};";
                    }
                }
            }

            sql = sql.Replace(",", ".");
            sql = sql.Replace(". ", ", ");

            DataAccess.Execute(sql);
        }
    }
}
