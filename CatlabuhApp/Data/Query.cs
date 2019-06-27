using CatlabuhApp.Data.Models;
using System;

namespace CatlabuhApp.Data
{
    /// <summary>
    /// Содержит запросы к БД
    /// </summary>
    public class Query
    {
        private static readonly string[] months = { "Січ.", "Лют.", "Берез.", "Квіт.", "Трав.", "Черв.", "Лип.", "Серп.", "Вер.", "Жовт.", "Листоп.", "Груд.", "∑", "%" };
        // TODO: заменить в масиве елементы елементами из файла ресурсов
        #region Представления таблицы Calculations
        // TODO: заменить в представлениях слово 'Місяць' на елемент из файла ресурсов
        /// <summary>
        /// Формирует и возвращает представление солевого баланса убыточной части
        /// </summary>
        /// <param name="yearOfCalculation">Год расчета</param>
        /// <returns>Строка-представление</returns>
        public static string GetSaltBalanceConsumableView(string yearOfCalculation)
        {
            return $"SELECT Name_calculation AS[Місяць], VE, Vtr, Vf, Vz, VD_minus AS[VD], Voz, Sf, Sz, SD_minus AS[SD], Soz, Cf, Cz, " +
                "CD_minus AS[CD], Coz, EpCi_minus AS[∑pCi], Year_calculation, Id_calculation " +
                $"FROM Calculations WHERE Year_calculation = {yearOfCalculation}";
        }

        /// <summary>
        /// Формирует и возвращает представление солевого баланса прибыльной части
        /// </summary>
        /// <param name="yearOfCalculation">Год расчета</param>
        /// <returns>Строка-представление</returns>
        public static string GetSaltBalanceProfitView(string yearOfCalculation)
        {
            return "SELECT Name_calculation AS[Місяць], W1, W2, Vp, Vr, Vb, Vg, Vdr, VD_plus AS[VD], S1, S2, Sp, Sr, Sb, Sg, Sdr, " +
                "SD_plus AS[SD], C1, C2, Cp, Cr, Cb, Cg, Cdr, CD_plus AS[CD], EpCi_plus AS[∑pCi], Year_calculation, Id_calculation " +
                $"FROM Calculations WHERE Year_calculation = {yearOfCalculation}";
        }

        /// <summary>
        /// Формирует и возвращает представление водного баланса убыточной части
        /// </summary>
        /// <param name="yearOfCalculation">Год расчета</param>
        /// <returns>Строка-представление</returns>
        public static string GetWaterBalanceConsumableView(string yearOfCalculation)
        {
            return "SELECT Name_calculation AS[Місяць], d, lgd AS[lg(d)], lgE AS[lg(E)], E, Etr, VE, Vtr, Vf, Vz, ER AS[∑R], " +
                "VD_minus AS[VD], Voz, Year_calculation, Id_calculation " +
                $"FROM Calculations WHERE Year_calculation = {yearOfCalculation}";
        }

        /// <summary>
        /// Формирует и возвращает представление водного баланса прибыльной части
        /// </summary>
        /// <param name="yearOfCalculation">Год расчета</param>
        /// <returns>Строка-представление</returns>
        public static string GetWaterBalanceProfitView(string yearOfCalculation)
        {
            return "SELECT Name_calculation AS[Місяць], H1, H2, avr_H AS[H ср.], W1, W2, dlt_W AS[∆W], F AS[F(H ср.)], P, Vp, Vr, " +
                "Vb, Vg, Vdr, EP AS[∑P], VD_plus AS[VD], dlt_Vni AS[∆Vні], Year_calculation, Id_calculation " +
                $"FROM Calculations WHERE Year_calculation = { yearOfCalculation}";
        }

        #endregion
        #region Заросы для таблицы Calculations

        /// <summary>
        /// Формирует и возвращает запрос на добавление входных данных расчета в БД
        /// </summary>
        /// <param name="calc">Расчет</param>
        /// <returns>Строка-запрос</returns>
        public static string GetInputDataInsertQuery(Calculation calc)
        {
            if (calc == null)
            {
                throw new ArgumentNullException();
            }

            string query = "";

            for (int i = 0; i < 12; i++)
            {
                if (calc.Calculate_E)
                {
                    if (calc.Calculate_VD == false && calc.Enter_VD == true)
                    {
                        query += "INSERT INTO Calculations (Year_calculation, Name_calculation, H1, H2, P, Vz, d, VD_plus, VD_minus) ";
                    }
                    else
                    {
                        query += "INSERT INTO Calculations (Year_calculation, Name_calculation, H1, H2, P, Vz, d) ";
                    }
                }
                else
                {
                    if (calc.Calculate_VD == false && calc.Enter_VD == true)
                    {
                        query += "INSERT INTO Calculations (Year_calculation, Name_calculation, H1, H2, P, Vz, E, VD_plus, VD_minus) ";
                    }
                    else
                    {
                        query += "INSERT INTO Calculations (Year_calculation, Name_calculation, H1, H2, P, Vz, E) ";
                    }
                }

                if (calc.Calculate_VD == false && calc.Enter_VD == true)
                {// E
                    query += $"VALUES({calc.Year}, '{months[i]}', {calc.H1[i]}, {calc.H2[i]}, {calc.P[i]}, {calc.Vz[i]}, " +
                        $"{ (calc.Calculate_E == true ? calc.d[i] : calc.E[i]) }, {calc.VD_plus[i]}, {calc.VD_minus[i]}); ";
                }
                else
                {// d
                    query += $"VALUES({calc.Year}, '{months[i]}', {calc.H1[i]}, {calc.H2[i]}, {calc.P[i]}, {calc.Vz[i]}, " +
                        $" { (calc.Calculate_E == true ? calc.d[i] : calc.E[i]) }); ";
                }
            }

            query += $"INSERT INTO Calculations (Year_calculation, Name_calculation) VALUES ({calc.Year}, '{months[12]}'); ";
            query += $"INSERT INTO Calculations (Year_calculation, Name_calculation) VALUES ({calc.Year}, '{months[13]}'); ";
            query += $"UPDATE Calculations SET Vr = {calc.sum_1[2]}, Vg = {calc.sum_1[4]} WHERE Year_calculation = {calc.Year} AND Name_calculation = '{months[12]}'; ";
            query += $"UPDATE Calculations SET S1 = {calc.S1[0]} WHERE Year_calculation = {calc.Year} AND Name_calculation = '{months[0]}'; ";

            //query = query.Replace(", ,", ", NULL,");
            query = query.Replace(", )", ", NULL)");
            query = query.Replace(", ,", ", NULL,");
            query = query.Replace(" =  WHERE", " = NULL WHERE");

            query = query.Replace("= ,", "= NULL,");
            query = query.Replace(",", ".");
            query = query.Replace(". ", ", ");

            return query;
        }

        /// <summary>
        /// Формирует и возвращает запрос на обновление входных данных расчета в БД
        /// </summary>
        /// <param name="calc">Расчет</param>
        /// <returns>Строка-запрос</returns>
        public static string GetInputDataUpdateQuery(Calculation calc)
        {
            if (calc == null)
            {
                throw new ArgumentNullException();
            }

            string query = "";

            for (int i = 0; i < 12; i++)
            {
                if (calc.Calculate_E)
                {
                    if (calc.Calculate_VD == false && calc.Enter_VD == true)
                    {
                        query += $"UPDATE Calculations SET H1 = {calc.H1[i]}, H2 = {calc.H2[i]}, P = {calc.P[i]}, Vz = {calc.Vz[i]}, " +
                            $"d = {calc.d[i]} , VD_plus = {calc.VD_plus[i]}, VD_minus = {calc.VD_minus[i]} WHERE Id_calculation = {calc.Ids[i]}; ";
                    }
                    else
                    {
                        query += $"UPDATE Calculations SET H1 = {calc.H1[i]}, H2 = {calc.H2[i]}, P = {calc.P[i]}, Vz = {calc.Vz[i]}, " +
                            $"d = {calc.d[i]} WHERE Id_calculation = {calc.Ids[i]}; ";
                    }
                }
                else
                {
                    if (calc.Calculate_VD == false && calc.Enter_VD == true)
                    {
                        query += $"UPDATE Calculations SET H1 = {calc.H1[i]}, H2 = {calc.H2[i]}, P = {calc.P[i]}, Vz = {calc.Vz[i]}, " +
                            $"E = { calc.E[i] }, VD_plus = {calc.VD_plus[i]}, VD_minus = {calc.VD_minus[i]} WHERE Id_calculation = {calc.Ids[i]}; ";
                    }
                    else
                    {
                        query += $"UPDATE Calculations SET H1 = {calc.H1[i]}, H2 = {calc.H2[i]}, P = {calc.P[i]}, Vz = {calc.Vz[i]}, " +
                            $"E = {calc.E[i]} WHERE Id_calculation = {calc.Ids[i]}; ";
                    }
                }
            }

            query += $"UPDATE Calculations SET Vr = {calc.sum_1[2]}, Vg = {calc.sum_1[4]} WHERE Year_calculation = {calc.Year} AND Name_calculation = '{months[12]}'; ";
            query += $"UPDATE Calculations SET S1 = {calc.S1[0]} WHERE Year_calculation = {calc.Year} AND Name_calculation = '{months[0]}'; ";

            //query = query.Replace(" = ,", " = NULL,");
            query = query.Replace(" =  WHERE", " = NULL WHERE");

            query = query.Replace("= ,", "= NULL,");
            query = query.Replace(",", ".");
            query = query.Replace(". ", ", ");

            return query;
        }

        /// <summary>
        /// Формирует и возвращает запрос на добавление рассчитанного рачсета в БД
        /// </summary>
        /// <param name="calc">Расчет</param>
        /// <returns>Строка-запрос</returns>
        public static string GetCalculationInsertQuery(Calculation calc)
        {
            if (calc == null)
            {
                throw new ArgumentNullException();
            }

            string query = "";

            for (int i = 0; i < 12; i++)
            {
                query +=
                     "INSERT INTO Calculations(Year_calculation, Name_calculation, H1, H2, avr_H, W1, W2, dlt_W, F, P, Vp, Vr, Vb, Vg, Vdr, EP, VD_plus, dlt_Vni," +
                         " d, lgd, lgE, E, Etr, VE, Vtr, Vf, Vz, ER, VD_minus, Voz, S1, S2, Sr, Sp, Sb, Sg, Sdr, SD_plus, C1, C2, Cr, Cp, Cb, Cg, Cdr, CD_plus, EpCi_plus," +
                         " Sf, Sz, SD_minus, Soz, Cf, Cz, CD_minus, Coz, EpCi_minus) " +
                     "VALUES(" +
                         $"{calc.Year}, '{months[i]}', {calc.H1[i]}, {calc.H2[i]}, {calc.avr_H[i]}, {calc.W1[i]}, {calc.W2[i]}, " +
                         $"{calc.dlt_W[i]}, {calc.F[i]}, {calc.P[i]}, {calc.Vp[i]}, {calc.Vr[i]}, {calc.Vb[i]}, {calc.Vg[i]}, {calc.Vdr[i]}, " +
                         $"{calc.EP[i]}, {calc.VD_plus[i]}, {calc.dlt_Vni[i]}, {calc.d[i]}, {calc.lgd[i]}, {calc.lgE[i]}, {calc.E[i]}, " +
                         $"{calc.Etr[i]}, {calc.VE[i]}, {calc.Vtr[i]}, {calc.Vf[i]}, {calc.Vz[i]}, {calc.ER[i]}, {calc.VD_minus[i]}, " +
                         $"{calc.Voz[i]}, {calc.S1[i]}, {calc.S2[i]}, {calc.Sr[i]}, {calc.Sp[i]}, {calc.Sb[i]}, {calc.Sg[i]}, {calc.Sdr[i]}, " +
                         $"{calc.SD_plus[i]}, {calc.C1[i]}, {calc.C2[i]}, {calc.Cr[i]}, {calc.Cp[i]}, {calc.Cb[i]}, {calc.Cg[i]}, {calc.Cdr[i]}, " +
                         $"{calc.CD_plus[i]}, {calc.EpCi_plus[i]}, {calc.Sf[i]}, {calc.Sz[i]}, {calc.SD_minus[i]}, {calc.Soz[i]}, " +
                         $"{calc.Cf[i]}, {calc.Cz[i]}, {calc.CD_minus[i]}, {calc.Coz[i]}, {calc.EpCi_minus[i]}); ";
            }
            // Данные расчета - суммы
            query +=
                "INSERT INTO Calculations(Year_calculation, Name_calculation, P, Vp, Vr, Vb, Vg, Vdr, EP, VD_plus, E, Etr, VE, Vtr, Vf, Vz, ER, VD_minus, Voz, Cp, Cr, " +
                    "Cb, Cg, Cdr, CD_plus, EpCi_plus, Cf, Cz, CD_minus, Coz, EpCi_minus) " +
                "VALUES(" +
                    $"{calc.Year}, '{months[12]}', {calc.sum_1[0]}, {calc.sum_1[1]}, {calc.sum_1[2]}, {calc.sum_1[3]}, {calc.sum_1[4]}, " +
                    $"{calc.sum_1[5]}, {calc.sum_1[6]}, {calc.sum_1[7]}, {calc.sum_2[0]}, {calc.sum_2[1]}, {calc.sum_2[2]}, {calc.sum_2[3]}, " +
                    $"{calc.sum_2[4]}, {calc.sum_2[5]}, {calc.sum_2[6]}, {calc.sum_2[7]}, {calc.sum_2[8]}, {calc.sum_3[0]}, {calc.sum_3[1]}, " +
                    $"{calc.sum_3[2]}, {calc.sum_3[3]}, {calc.sum_3[4]}, {calc.sum_3[5]}, {calc.sum_3[6]}, {calc.sum_4[0]}, {calc.sum_4[1]}, " +
                    $"{calc.sum_4[2]}, {calc.sum_4[3]}, {calc.sum_4[4]}); ";
            // Данные расчета - проценты
            query +=
                "INSERT INTO Calculations(Year_calculation, Name_calculation, Vp, Vr, Vb, Vg, Vdr, EP, VD_plus, VE, Vtr, Vf, Vz, ER, VD_minus, Voz, Cp, Cr, " +
                    "Cb, Cg, Cdr, CD_plus, EpCi_plus, Cf, Cz, CD_minus, Coz, EpCi_minus) " +
                "VALUES(" +
                    $"{calc.Year}, '{months[13]}', {calc.procent_1[0]}, {calc.procent_1[1]}, {calc.procent_1[2]}, {calc.procent_1[3]}, {calc.procent_1[4]}, " +
                    $"{calc.procent_1[5]}, {calc.procent_1[6]}, {calc.procent_2[0]}, {calc.procent_2[1]}, {calc.procent_2[2]}, {calc.procent_2[3]}, {calc.procent_2[4]}, " +
                    $"{calc.procent_2[5]}, {calc.procent_2[6]}, {calc.procent_3[0]}, {calc.procent_3[1]}, {calc.procent_3[2]}, {calc.procent_3[3]}, {calc.procent_3[4]}, " +
                    $"{calc.procent_3[5]}, {calc.procent_3[6]}, {calc.procent_4[0]}, {calc.procent_4[1]}, {calc.procent_4[2]}, {calc.procent_4[3]}, " + calc.procent_4[4] + ")";

            query = query.Replace(",", ".");
            query = query.Replace(". ", ", ");

            return query;
        }

        /// <summary>
        /// Формирует и возвращает запрос на обновление рассчитаного рачсета в БД
        /// </summary>
        /// <param name="calc">Расчет</param>
        /// <returns>Строка-запрос</returns>
        public static string GetCalculationUpdateQuery(Calculation calc)
        {
            if (calc == null)
            {
                throw new ArgumentNullException();
            }

            string query = "";

            // Данные расчета за 12 месяцев  
            for (int i = 0; i < 12; i++)
            {
                query +=
                    $"UPDATE Calculations SET H1 = {calc.H1[i]}, H2 = {calc.H2[i]}, avr_H = {calc.avr_H[i]}, W1 = {calc.W1[i]}, W2 = {calc.W2[i]}, " +
                        $"dlt_W = {calc.dlt_W[i]}, F = {calc.F[i]}, P = {calc.P[i]}, Vp = {calc.Vp[i]}, Vr = {calc.Vr[i]}, Vb = {calc.Vb[i]}, " +
                        $"Vg = {calc.Vg[i]}, Vdr = {calc.Vdr[i]}, EP = {calc.EP[i]}, VD_plus = {calc.VD_plus[i]}, dlt_Vni = {calc.dlt_Vni[i]}, " +
                        $"d = {calc.d[i]}, lgd = {calc.lgd[i]}, lgE = {calc.lgE[i]}, E = {calc.E[i]}, Etr = {calc.Etr[i]}, VE = {calc.VE[i]}, " +
                        $"Vtr = {calc.Vtr[i]}, Vf = {calc.Vf[i]}, Vz = {calc.Vz[i]}, ER = {calc.ER[i]}, VD_minus = {calc.VD_minus[i]}, Voz = {calc.Voz[i]}, " +
                        $"S1 = {calc.S1[i]}, S2 = {calc.S2[i]}, Sr = {calc.Sr[i]}, Sp = {calc.Sp[i]}, Sb = {calc.Sb[i]}, Sg = {calc.Sg[i]}, " +
                        $"Sdr = {calc.Sdr[i]}, SD_plus = {calc.SD_plus[i]}, C1 = {calc.C1[i]}, C2 = {calc.C2[i]}, Cr = {calc.Cr[i]}, Cp = {calc.Cp[i]}, " +
                        $"Cb = {calc.Cb[i]}, Cg = {calc.Cg[i]}, Cdr = {calc.Cdr[i]}, CD_plus = {calc.CD_plus[i]}, EpCi_plus = {calc.EpCi_plus[i]}, Sf = {calc.Sf[i]}, " +
                        $"Sz = {calc.Sz[i]}, SD_minus = {calc.SD_minus[i]}, Soz = {calc.Soz[i]}, Cf = {calc.Cf[i]}, Cz = {calc.Cz[i]}, CD_minus = {calc.CD_minus[i]}, " +
                        $"Coz = {calc.Coz[i]}, EpCi_minus = {calc.EpCi_minus[i]} " +
                    $"WHERE Id_calculation = {calc.Ids[i]}; ";
            }
            // Данные расчета - суммы
            query +=
                $"UPDATE Calculations SET P = {calc.sum_1[0]}, Vp = {calc.sum_1[1]}, Vr = {calc.sum_1[2]}, Vb = {calc.sum_1[3]}, Vg = {calc.sum_1[4]}, Vdr = {calc.sum_1[5]}, " +
                    $"EP = {calc.sum_1[6]}, VD_plus = {calc.sum_1[7]}, E = {calc.sum_2[0]}, Etr = {calc.sum_2[1]}, VE = {calc.sum_2[2]}, Vtr = {calc.sum_2[3]}, " +
                    $"Vf = {calc.sum_2[4]}, Vz = {calc.sum_2[5]}, ER = {calc.sum_2[6]}, VD_minus = {calc.sum_2[7]}, Voz = {calc.sum_2[8]}, Cp = {calc.sum_3[0]}, " +
                    $"Cr = {calc.sum_3[1]}, Cb = {calc.sum_3[2]}, Cg = {calc.sum_3[3]}, Cdr = {calc.sum_3[4]}, CD_plus = {calc.sum_3[5]}, EpCi_plus = {calc.sum_3[6]}, " +
                    $"Cf = {calc.sum_4[0]}, Cz = {calc.sum_4[1]}, CD_minus = {calc.sum_4[2]}, Coz = {calc.sum_4[3]}, EpCi_minus = {calc.sum_4[4]} " +
                $"WHERE Id_calculation = {calc.Ids[12]}; ";
            // Данные расчета - проценты
            query +=
                $"UPDATE Calculations SET Vp = {calc.procent_1[0]}, Vr = {calc.procent_1[1]}, Vb = {calc.procent_1[2]}, Vg = {calc.procent_1[3]}, Vdr = {calc.procent_1[4]}, " +
                    $"EP = {calc.procent_1[5]}, VD_plus = {calc.procent_1[6]}, VE = {calc.procent_2[0]}, Vtr = {calc.procent_2[1]}, Vf = {calc.procent_2[2]}, " +
                    $"Vz = {calc.procent_2[3]}, ER = {calc.procent_2[4]}, VD_minus = {calc.procent_2[5]}, Voz = {calc.procent_2[6]}, Cp = {calc.procent_3[0]}, " +
                    $"Cr = {calc.procent_3[1]}, Cb = {calc.procent_3[2]}, Cg = {calc.procent_3[3]}, Cdr = {calc.procent_3[4]}, CD_plus = {calc.procent_3[5]}, " +
                    $"EpCi_plus = {calc.procent_3[6]}, Cf = {calc.procent_4[0]}, Cz = {calc.procent_4[1]}, CD_minus = {calc.procent_4[2]}, Coz = {calc.procent_4[3]}, " +
                    $"EpCi_minus = {calc.procent_4[4]} " +
                $"WHERE Id_calculation = {calc.Ids[13]}";

            query = query.Replace(",", ".");
            query = query.Replace(". ", ", ");

            return query;
        }

        /// <summary>
        /// Формирует и возвращает запрос на удаление расчета из БД
        /// </summary>
        /// <param name="ids">Идентификторы записей расчета в таблицу Calculations</param>
        /// <returns>Строка-запрос</returns>
        public static string GetCalculationDeleteQuery(string[] ids)
        {
            string query = "";

            foreach (string entry in ids)
            {
                query += $"DELETE FROM Calculations WHERE Id_calculation = {entry}";
            }

            return query;
        }

        /// <summary>
        /// Формирует и возвращает запрос обновления ячейки в таблице Calculations
        /// </summary>
        /// <param name="column">Название столбца</param>
        /// <param name="value">Значение ячейки</param>
        /// <param name="id">Идентификатор записи</param>
        /// <returns></returns>
        public static string GetCellCalculationUpdateQuery(string column, string value, string id)
        {
            string query = $"UPDATE Calculations SET {column} = {value} WHERE Id_calculation = {id}";
            query = query.Replace(",", ".");
            query = query.Replace(". ", ", ");

            return query;
        }

        #endregion
        #region Представление для таблицы Years

        /// <summary>
        /// Формирует и возвращает представление таблицы Years
        /// </summary>
        /// <param name="isOrderByDefault">Если истина, то сортировка по умолчанию(возрастанию), иначе - по убыванию</param>
        /// <returns>Строка-представление</returns>
        public static string GetYearsView(bool isOrderByDefault)
        {
            return $"SELECT * FROM Years ORDER BY Name_year { (isOrderByDefault ? "ASC" : "DESC") }";
        }

        /// <summary>
        ///  Формирует и возвращает список лет таблицы Years
        /// </summary>
        /// <param name="isOrderByDefault">Если истина, то сортировка по умолчанию(возрастанию), иначе - по убыванию</param>
        /// <returns>Строка-представление</returns>
        public static string GetYearsList(bool isOrderByDefault)
        {
            return $"SELECT Name_year FROM Years ORDER BY Name_year { (isOrderByDefault ? "ASC" : "DESC") }";
        }

        #endregion
        #region Запросы для таблицы Years

        /// <summary>
        /// Формирует и возвращает запрос на добавление года в БД
        /// </summary>
        /// <param name="year">Год</param>
        /// <returns>Строка-запрос</returns>
        public static string GetYearInsertQuery(string year)
        {
            return $"INSERT INTO Years (Name_year) VALUES ({year})";
        }

        /// <summary>
        /// Формирует и возвращает запрос на удаление года из БД
        /// </summary>
        /// <param name="year">Год</param>
        /// <returns>Строка-запрос</returns>
        public static string GetYearDeleteQuery(string year)
        {
            return $"DELETE FROM Years WHERE Name_year {year}";
        }

        #endregion

    }
}
