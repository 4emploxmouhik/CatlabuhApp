using System;

namespace CatlabuhApp.Data.Models
{
    partial class OutputData
    {
        public void GetWaterLevel(double sumP)
        {
            double[] xp = DataAccess.GetColumnData<double>("SELECT Xp FROM GammaDistribution").ToArray();
            int recordID = 0;

            if (sumP > xp[0])
            {
                recordID = 1;
            }
            else if (sumP < xp[xp.Length - 1])
            {
                recordID = xp.Length;
            }
            else
            {
                for (int i = 0; i < xp.Length; i++)
                {
                    if (sumP > xp[i])
                    {
                        recordID = i;
                        break;
                    }
                }
            }

            waterLevelPercent = DataAccess.GetCellData<int>($"SELECT Percent FROM GammaDistribution WHERE PointID = {recordID}");

            if (waterLevelPercent <= 33)
            {
                waterLevel = WaterLevel.High;
            }
            else if (33 < waterLevelPercent && waterLevelPercent <= 66)
            {
                waterLevel = WaterLevel.Average;
            }
            else
            {
                waterLevel = WaterLevel.Low;
            }
        }

        private double CalculateSumVr(double sumP)
        {
            double[] xp = DataAccess.GetColumnData<double>("SELECT Xp FROM GammaDistribution").ToArray();
            int recordID = 0;

            if (sumP > xp[0])
            {
                recordID = 1;
            }
            else if (sumP < xp[xp.Length - 1])
            {
                recordID = xp.Length;
            }
            else
            {
                for (int i = 0; i < xp.Length; i++)
                {
                    if (sumP > xp[i])
                    {
                        recordID = i;
                        break;
                    }
                }
            }

            double kp = DataAccess.GetCellData<double>($"SELECT kp FROM GammaDistribution WHERE PointID = {recordID}");

            return (((coefficients[31] * coefficients[32]) / 1000) * kp * coefficients[33] * coefficients[34]) / 1000000;
        }

        private void SetSquareOfWaterMirror()
        {
            double[,] dependence = DataAccess.GetTableData<double>("DependenceOfAvrHToF", 71, new string[] { "avr_H", "F" });

            for (int i = 0; i < 12; i++)
            {
                int k = 0;
                while (k < 71)
                {
                    if (avrH[i] <= dependence[0, k])
                    {
                        f[i] = dependence[1, k];
                        break;
                    }
                    k++;
                }
            }
        }

        private void DistributeValuesInGatewaySchedule()
        {
            for (int i = 0; i < 12; i++)
            {
                if (gs.IsCalculateGS)
                {
                    switch (gs.MonthsOfWorkGatewayVD[i])
                    {
                        case 1:
                            gs.VD_plus[i] = Math.Abs(dltVni[i]);
                            break;
                        case 2:
                            gs.VD_minus[i] = Math.Abs(dltVni[i]);
                            break;
                        default:
                            gs.VD_plus[i] = 0;
                            gs.VD_minus[i] = 0;
                            break;
                    }

                    switch (gs.MonthsOfWorkGatewayVoz[i])
                    {
                        case 1:
                            if (gs.MonthsOfWorkGatewayVoz[i] != gs.MonthsOfWorkGatewayVD[i])
                            {
                                gs.Voz_plus[i] = Math.Abs(dltVni[i]);
                            }
                            else
                            {
                                gs.Voz_plus[i] = 0;
                                gs.VD_plus[i] = Math.Abs(dltVni[i]);
                            }

                            break;
                        case 2:
                            if (gs.MonthsOfWorkGatewayVoz[i] != gs.MonthsOfWorkGatewayVD[i])
                            {
                                gs.Voz_minus[i] = Math.Abs(dltVni[i]);
                            }
                            else
                            {
                                gs.Voz_minus[i] = 0;
                                gs.VD_minus[i] = Math.Abs(dltVni[i]);
                            }

                            break;
                        default:
                            gs.Voz_plus[i] = 0;
                            gs.Voz_minus[i] = 0;
                            break;
                    }

                    if (gs.MonthsOfWorkGatewayVD[i] != 0 || gs.MonthsOfWorkGatewayVoz[i] != 0)
                    {
                        dltVni[i] = 0;
                    }
                }

                sumsOfWBP[7] += gs.VD_plus[i];      // VD_plus
                sumsOfWBP[8] += gs.Voz_plus[i];     // Voz_plus 

                sumsOfWBC[7] += gs.VD_minus[i];     // VD_minus
                sumsOfWBC[8] += gs.Voz_minus[i];    // Voz_minus
            }
        }

        private void CalculateWaterBalancePart()
        {
            double[,] IADOfSurfaceRunoff = DataAccess.GetTableData<double>("IADOfSurfaceRunoff", 12, new string[] { "HighWaterLevel", "AverageWaterLevel", "LowWaterLevel" });
            double[,] IADOfGroundwaterInflow = DataAccess.GetTableData<double>("IADOfGroundwaterInflow", 12, new string[] { "HighWaterLevel", "AverageWaterLevel", "LowWaterLevel" });

            int waterLvl = -1;

            switch (waterLevel)
            {
                case WaterLevel.High: waterLvl = 0; break;
                case WaterLevel.Average: waterLvl = 1; break;
                case WaterLevel.Low: waterLvl = 2; break;
            }

            double averageOfAvrH = 0;

            for (int i = 0; i < 12; i++)
            {
                w1[i] = inputData.H1[i] * coefficients[0] + coefficients[1];
                w2[i] = inputData.H2[i] * coefficients[0] + coefficients[1];
                dltW[i] = w2[i] - w1[i];
                vp[i] = (f[i] * inputData.PIsmail[i]) / 1000;
                vr[i] = (sumsOfWBP[2] / 100) * IADOfSurfaceRunoff[waterLvl, i];
                vb[i] = vr[i] * coefficients[2];
                vg[i] = (sumsOfWBP[4] / 100) * IADOfGroundwaterInflow[waterLvl, i];
                vdr[i] = inputData.Vz[i] * coefficients[3];
                ep[i] = vp[i] + vr[i] + vb[i] + vg[i] + vdr[i];

                if (inputData.IsCalculateE)
                {
                    if (inputData.D[i] != 0)
                    {
                        lgD[i] = Math.Log10(inputData.D[i]);
                    }
                    else
                    {
                        lgD[i] = 0;
                    }

                    if (2 < i && i < 9)
                    {
                        lgE[i] = k2[i - 3] * lgD[i] + k3[i - 3];
                        inputData.E[i] = Math.Pow(10, lgE[i]);
                    }
                }

                sumsOfWBC[0] += inputData.E[i];
                averageOfAvrH += avrH[i];
            }

            sumsOfWBC[1] = sumsOfWBC[0] * coefficients[6] - sumsOfWBC[0];   // Etr
            averageOfAvrH /= 12;

            for (int i = 0; i < 12; i++)
            {
                if (3 < i && i < 10)
                {
                    etr[i] = (sumsOfWBC[1] / 100) * k1[i - 4];
                }

                ve[i] = (f[i] * inputData.E[i]) / 1000;
                vtr[i] = (etr[i] * f[i] * coefficients[4]) / 1000;
                vf[i] = (avrH[i] / averageOfAvrH) * coefficients[5];
                er[i] = ve[i] + vtr[i] + vf[i] + inputData.Vz[i];

                // Подсчитываем суммы водного баланса
                // приходная часть
                sumsOfWBP[1] += vp[i];      // Vp
                sumsOfWBP[3] += vb[i];      // Vb
                sumsOfWBP[5] += vdr[i];     // Vdr
                sumsOfWBP[6] += ep[i];      // EP
                // расходная часть
                sumsOfWBC[2] += ve[i];              // VE   
                sumsOfWBC[3] += vtr[i];             // Vtr
                sumsOfWBC[4] += vf[i];              // Vf
                sumsOfWBC[5] += inputData.Vz[i];    // Vz
                sumsOfWBC[6] += er[i];              // ER   

                dltVni[i] = -((ep[i] += gs.IsCalculateGS ? gs.VD_plus[i] + gs.Voz_plus[i] : 0) -
                    (er[i] += gs.IsCalculateGS ? gs.VD_minus[i] + gs.Voz_minus[i] : 0) - dltW[i]);

                sumsOfWBP[9] += dltVni[i];  // dlt_Vni
            }

            if (gs.IsEnterGatewaySchedule)
            {
                DistributeValuesInGatewaySchedule();
            }

            // Подсчитываем проценты водного баланса: percent(%) = (summaOfValueInWB / (summa_EP + summa_VD + summa_Voz)) * 100
            percentsOfWBP[0] = (sumsOfWBP[1] / (sumsOfWBP[6] + sumsOfWBP[7] + sumsOfWBP[8])) * 100;                             // Vp
            percentsOfWBP[1] = (sumsOfWBP[2] / (sumsOfWBP[6] + sumsOfWBP[7] + sumsOfWBP[8])) * 100;                             // Vr
            percentsOfWBP[2] = (sumsOfWBP[3] / (sumsOfWBP[6] + sumsOfWBP[7] + sumsOfWBP[8])) * 100;                             // Vb
            percentsOfWBP[3] = (sumsOfWBP[4] / (sumsOfWBP[6] + sumsOfWBP[7] + sumsOfWBP[8])) * 100;                             // Vg
            percentsOfWBP[4] = (sumsOfWBP[5] / (sumsOfWBP[6] + sumsOfWBP[7] + sumsOfWBP[8])) * 100;                             // Vdr
            percentsOfWBP[5] = percentsOfWBP[0] + percentsOfWBP[1] + percentsOfWBP[2] + percentsOfWBP[3] + percentsOfWBP[4];    // EP
            percentsOfWBP[6] = (sumsOfWBP[7] / (sumsOfWBP[6] + sumsOfWBP[7] + sumsOfWBP[8])) * 100;                             // VD_plus
            percentsOfWBP[7] = (sumsOfWBP[8] / (sumsOfWBP[6] + sumsOfWBP[7] + sumsOfWBP[8])) * 100;                             // Voz_plus
            percentsOfWBP[8] = (sumsOfWBP[9] / (sumsOfWBP[6] + sumsOfWBP[7] + sumsOfWBP[8])) * 100;                             // dlt_Vni

            percentsOfWBC[0] = (sumsOfWBC[2] / (sumsOfWBC[6] + sumsOfWBC[7] + sumsOfWBC[8])) * 100;                             // VE
            percentsOfWBC[1] = (sumsOfWBC[3] / (sumsOfWBC[6] + sumsOfWBC[7] + sumsOfWBC[8])) * 100;                             // Vtr
            percentsOfWBC[2] = (sumsOfWBC[4] / (sumsOfWBC[6] + sumsOfWBC[7] + sumsOfWBC[8])) * 100;                             // Vf
            percentsOfWBC[3] = (sumsOfWBC[5] / (sumsOfWBC[6] + sumsOfWBC[7] + sumsOfWBC[8])) * 100;                             // Vz
            percentsOfWBC[4] = (sumsOfWBC[6] / (sumsOfWBC[6] + sumsOfWBC[7] + sumsOfWBC[8])) * 100;                             // ER
            percentsOfWBC[5] = (sumsOfWBC[7] / (sumsOfWBC[6] + sumsOfWBC[7] + sumsOfWBC[8])) * 100;                             // VD_minus
            percentsOfWBC[6] = (sumsOfWBC[8] / (sumsOfWBC[6] + sumsOfWBC[7] + sumsOfWBC[8])) * 100;                             // Voz_minus
        }

        private void CalculateSaltBalancePart(bool isRecalculte)
        {
            for (int i = 0; i < 12; i++)
            {
                if (!isRecalculte)
                {
                    s1[i] = (i == 0) ? inputData.S1InJanury : s2[i - 1];
                }

                c1[i] = (i == 0) ? w1[0] * s1[0] : c2[i - 1];

                sp[i] = coefficients[7];
                sr[i] = coefficients[8];
                sb[i] = sr[i] * coefficients[9];
                sg[i] = coefficients[10];
                sdr[i] = coefficients[11];
                sdPlus[i] = coefficients[12];
                sozPlus[i] = 0;

                cp[i] = vp[i] * sp[i];
                cr[i] = vr[i] * sr[i];
                cb[i] = vb[i] * sb[i];
                cg[i] = vg[i] * sg[i];
                cdr[i] = vdr[i] * sdr[i];
                cdPlus[i] = gs.VD_plus[i] * sdPlus[i];
                cozPlus[i] = gs.Voz_plus[i] * sozPlus[i];

                epciPlus[i] = cp[i] + cr[i] + cb[i] + cg[i] + cdr[i] + cdPlus[i] + cozPlus[i];

                sf[i] = s1[i];
                sz[i] = s1[i];
                sdMinus[i] = s1[i];
                sozMinus[i] = s1[i];

                cf[i] = vf[i] * sf[i];
                cz[i] = inputData.Vz[i] * sz[i];
                cdMinus[i] = gs.VD_minus[i] * sdMinus[i];
                cozMinus[i] = gs.Voz_minus[i] * sozMinus[i];

                epciMinus[i] = cf[i] + cz[i] + cdMinus[i] + cozMinus[i];

                c2[i] = c1[i] + epciPlus[i] - epciMinus[i];

                if (!isRecalculte)
                {
                    s2[i] = c2[i] / w2[i];
                }

                // Подсчитываем суммы солевого баланса
                sumsOfSBP[0] += cp[i];          // Cp
                sumsOfSBP[1] += cr[i];          // Cr
                sumsOfSBP[2] += cb[i];          // Cb
                sumsOfSBP[3] += cg[i];          // Cg
                sumsOfSBP[4] += cdr[i];         // Cdr
                sumsOfSBP[5] += cdPlus[i];      // CD_plus
                sumsOfSBP[6] += cozPlus[i];     // Coz_plus

                sumsOfSBC[0] += cf[i];          // Cf
                sumsOfSBC[1] += cz[i];          // Cz
                sumsOfSBC[2] += cdMinus[i];     // CD_minus
                sumsOfSBC[3] += cozMinus[i];    // Coz_minus
            }

            sumsOfSBP[7] = sumsOfSBP[0] + sumsOfSBP[1] + sumsOfSBP[2] + sumsOfSBP[3] + sumsOfSBP[4] + sumsOfSBP[5] + sumsOfSBP[6];
            sumsOfSBC[4] = sumsOfSBC[0] + sumsOfSBC[1] + sumsOfSBC[2] + sumsOfSBC[3];

            // Подсчитываем проценты солевого баланса
            percentsOfSBP[0] = (sumsOfSBP[0] / sumsOfSBP[7]) * 100;     // Cp
            percentsOfSBP[1] = (sumsOfSBP[1] / sumsOfSBP[7]) * 100;     // Cr
            percentsOfSBP[2] = (sumsOfSBP[2] / sumsOfSBP[7]) * 100;     // Cb
            percentsOfSBP[3] = (sumsOfSBP[3] / sumsOfSBP[7]) * 100;     // Cg
            percentsOfSBP[4] = (sumsOfSBP[4] / sumsOfSBP[7]) * 100;     // Cdr
            percentsOfSBP[5] = (sumsOfSBP[5] / sumsOfSBP[7]) * 100;     // CD_plus
            percentsOfSBP[6] = (sumsOfSBP[6] / sumsOfSBP[7]) * 100;     // Coz_plus
            percentsOfSBP[7] = (sumsOfSBP[7] / sumsOfSBP[7]) * 100;     // EpCi_plus    

            percentsOfSBC[0] = (sumsOfSBC[0] / sumsOfSBC[4]) * 100;     // Cf
            percentsOfSBC[1] = (sumsOfSBC[1] / sumsOfSBC[4]) * 100;     // Cz
            percentsOfSBC[2] = (sumsOfSBC[2] / sumsOfSBC[4]) * 100;     // CD_minus
            percentsOfSBC[3] = (sumsOfSBC[3] / sumsOfSBC[4]) * 100;     // Coz_minus
            percentsOfSBC[4] = (sumsOfSBC[4] / sumsOfSBC[4]) * 100;     // EpCi_minus
        }

        public void RecalculateSaltBalancePart(string yearOfCalculation)
        {
            if (DataAccess == null)
            {
                throw new ArgumentNullException("DataAccess is null.");
            }
            // get input data => S1, S2 and other
            s1 = DataAccess.GetColumnData<double>($"SELECT S1 FROM OutputData WHERE YearName = {yearOfCalculation} LIMIT 12").ToArray();
            s2 = DataAccess.GetColumnData<double>($"SELECT S2 FROM OutputData WHERE YearName = {yearOfCalculation} LIMIT 12").ToArray();

            vp = DataAccess.GetColumnData<double>($"SELECT Vp FROM OutputData WHERE YearName = {yearOfCalculation} LIMIT 12").ToArray();
            vr = DataAccess.GetColumnData<double>($"SELECT Vr FROM OutputData WHERE YearName = {yearOfCalculation} LIMIT 12").ToArray();
            vb = DataAccess.GetColumnData<double>($"SELECT Vb FROM OutputData WHERE YearName = {yearOfCalculation} LIMIT 12").ToArray();
            vg = DataAccess.GetColumnData<double>($"SELECT Vg FROM OutputData WHERE YearName = {yearOfCalculation} LIMIT 12").ToArray();
            vdr = DataAccess.GetColumnData<double>($"SELECT Vdr FROM OutputData WHERE YearName = {yearOfCalculation} LIMIT 12").ToArray();

            gs = new GatewaySchedule(DataAccess, yearOfCalculation);

            inputData = new InputData()
            {
                Vz = DataAccess.GetColumnData<double>($"SELECT Vz FROM InputData WHERE YearName = {yearOfCalculation} LIMIT 12").ToArray()
            };

            // calculate
            CalculateSaltBalancePart(true);
            RoundOutputData();

            // save changes
            string sql = "";

            for (int i = 0; i < 14; i++)
            {
                if (i < 12)
                {
                    sql += "UPDATE OutputData SET " +
                        $"Sp = {sp[i]}, Sr = {sr[i]}, Sb = {sb[i]}, Sg = {sg[i]}, Sdr = {sdr[i]}, SD_plus = {sdPlus[i]}, Soz_plus = {sozPlus[i]}, " +
                        $"C1 = {c1[i]}, C2 = {c2[i]}, Cp = {cp[i]}, Cr = {cr[i]}, Cb = {cb[i]}, Cg = {cg[i]}, Cdr = {cdr[i]}, " +
                        $"CD_plus = {cdPlus[i]}, Coz_plus = {cozPlus[i]}, EpCi_plus = {epciPlus[i]}, Sf = {sf[i]}, Sz = {sz[i]}, " +
                        $"SD_minus = {sdMinus[i]}, Soz_minus = {sozMinus[i]}, Cf = {cf[i]}, Cz = {cz[i]}, CD_minus = {cdMinus[i]}, " +
                        $"Coz_minus = {cozMinus[i]}, EpCi_minus = {epciMinus[i]} WHERE MonthID = {i + 1} AND YearName = {yearOfCalculation};\n";
                }
                else if (i == 12)
                {
                    sql += "UPDATE OutputData SET " +
                        $"Cp = {sumsOfSBP[0]}, Cr = {sumsOfSBP[1]}, Cb = {sumsOfSBP[2]}, Cg = {sumsOfSBP[3]}, Cdr = {sumsOfSBP[4]}, CD_plus = {sumsOfSBP[5]}, " +
                        $"Coz_plus = {sumsOfSBP[6]}, EpCi_plus = {sumsOfSBP[7]}, Cf = {sumsOfSBC[0]}, Cz = {sumsOfSBC[1]}, CD_minus = {sumsOfSBC[2]}, " +
                        $"Coz_minus = {sumsOfSBC[3]}, EpCi_minus = {sumsOfSBC[4]} WHERE MonthID = {i + 1} AND YearName = {yearOfCalculation};\n";
                }
                else
                {
                    sql += "UPDATE OutputData SET " +
                        $"Cp = {percentsOfSBP[0]}, Cr = {percentsOfSBP[1]}, Cb = {percentsOfSBP[2]}, Cg = {percentsOfSBP[3]}, Cdr = {percentsOfSBP[4]}, CD_plus = {percentsOfSBP[5]}, " +
                        $"Coz_plus = {percentsOfSBP[6]}, EpCi_plus = {percentsOfSBP[7]}, Cf = {percentsOfSBC[0]}, Cz = {percentsOfSBC[1]}, CD_minus = {percentsOfSBC[2]}, " +
                        $"Coz_minus = {percentsOfSBC[3]}, EpCi_minus = {percentsOfSBC[4]} WHERE MonthID = {i + 1} AND YearName = {yearOfCalculation};";
                }
            }

            sql = sql.Replace(",", ".");
            sql = sql.Replace(". ", ", ");

            DataAccess.Execute(sql);
        }

        private void RoundOutputData()
        {
            for (int i = 0; i < 12; i++)
            {
                avrH[i] = Math.Round(avrH[i], 2);
                w1[i] = Math.Round(w1[i], 2);
                w2[i] = Math.Round(w2[i], 2);
                dltW[i] = Math.Round(dltW[i], 2);
                f[i] = Math.Round(f[i], 2);
                vp[i] = Math.Round(vp[i], 2);
                vr[i] = Math.Round(vr[i], 2);
                vb[i] = Math.Round(vb[i], 2);
                vg[i] = Math.Round(vg[i], 2);
                vdr[i] = Math.Round(vdr[i], 2);
                ep[i] = Math.Round(ep[i], 2);

                dltVni[i] = Math.Round(dltVni[i], 2);
                lgD[i] = Math.Round(lgD[i], 2);
                lgE[i] = Math.Round(lgE[i], 2);

                etr[i] = Math.Round(etr[i], 2);
                ve[i] = Math.Round(ve[i], 2);
                vtr[i] = Math.Round(vtr[i], 2);
                vf[i] = Math.Round(vf[i], 2);
                er[i] = Math.Round(er[i], 2);
                s1[i] = Math.Round(s1[i], 2);
                s2[i] = Math.Round(s2[i], 2);
                sp[i] = Math.Round(sp[i], 2);
                sr[i] = Math.Round(sr[i], 2);
                sb[i] = Math.Round(sb[i], 2);
                sdr[i] = Math.Round(sdr[i], 2);
                sdPlus[i] = Math.Round(sdPlus[i], 2);
                c1[i] = Math.Round(c1[i], 2);
                c2[i] = Math.Round(c2[i], 2);
                cp[i] = Math.Round(cp[i], 2);
                cr[i] = Math.Round(cr[i], 2);
                cb[i] = Math.Round(cb[i], 2);
                cg[i] = Math.Round(cg[i], 2);
                cdr[i] = Math.Round(cdr[i], 2);
                cdPlus[i] = Math.Round(cdPlus[i], 2);
                epciPlus[i] = Math.Round(epciPlus[i], 2);
                sf[i] = Math.Round(sf[i], 2);
                sz[i] = Math.Round(sz[i], 2);
                sdMinus[i] = Math.Round(sdMinus[i], 2);
                sozMinus[i] = Math.Round(sozMinus[i], 2);
                cf[i] = Math.Round(cf[i], 2);
                cz[i] = Math.Round(cz[i], 2);
                cdMinus[i] = Math.Round(cdMinus[i], 2);
                epciMinus[i] = Math.Round(epciMinus[i], 2);

                if (i < 5)
                {
                    sumsOfSBC[i] = Math.Round(sumsOfSBC[i], 2);
                    percentsOfSBC[i] = Math.Round(percentsOfSBC[i], 2);
                }

                if (i < 7)
                {
                    percentsOfWBC[i] = Math.Round(percentsOfWBC[i], 2);
                }

                if (i < 8)
                {
                    percentsOfSBP[i] = Math.Round(percentsOfSBP[i], 2);
                    sumsOfSBP[i] = Math.Round(sumsOfSBP[i], 2);
                }

                if (i < 9)
                {
                    percentsOfWBP[i] = Math.Round(percentsOfWBP[i], 2);
                    
                    sumsOfWBC[i] = Math.Round(sumsOfWBC[i], 2);
                }

                if (i < 10)
                {
                    sumsOfWBP[i] = Math.Round(sumsOfWBP[i], 2);
                }

                gs.VD_plus[i] = Math.Round(gs.VD_plus[i], 2);
                gs.VD_minus[i] = Math.Round(gs.VD_minus[i], 2);
                gs.Voz_plus[i] = Math.Round(gs.Voz_plus[i], 2);
                gs.Voz_minus[i] = Math.Round(gs.Voz_minus[i], 2);

                if (inputData.IsCalculateE)
                {
                    inputData.E[i] = Math.Round(inputData.E[i], 2);
                }
            }
        }

        public void Calculate()
        {
            // Запишем в массив сумм суммарнное Vg
            sumsOfWBP[4] = inputData.SumVg;

            // Запишем в массив минирализации на начало месяца переданное значение 
            s1[0] = inputData.S1InJanury;

            double sumPBolgrad = 0;

            // Узнаем сумму осадков, чтобы определить водность
            for (int i = 0; i < 12; i++)
            {
                sumsOfWBP[0] += inputData.PIsmail[i];  // PIsmail
                sumPBolgrad += inputData.PBolgrad[i];  // PBolgrad
            }

            // Определим водность года
            GetWaterLevel(sumPBolgrad);

            // Рассчетаем суммарное Vr
            sumsOfWBP[2] = CalculateSumVr(sumPBolgrad);    // Vr

            // Вычисляем среднее значение уровня воды за месяц
            for (int i = 0; i < 12; i++)
            {
                avrH[i] = (inputData.H1[i] + inputData.H2[i]) / 2;
            }

            // Определяем площадь водного зеркала для каждого месяца
            SetSquareOfWaterMirror();

            // Расчитываем значения водного баланса
            CalculateWaterBalancePart();

            // Расчитываем значения солевого баланса
            CalculateSaltBalancePart(false);

            // Округлим значения до двух знаков после запятой
            RoundOutputData();
        }
    }
}
