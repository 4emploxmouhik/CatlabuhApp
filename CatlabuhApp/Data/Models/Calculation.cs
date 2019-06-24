using CatlabuhApp.Data.Access;
using System;

namespace CatlabuhApp.Data.Models
{
    /// <summary>
    /// Представляет собой годовой расчет водного и солевого балансов озера Катлабух
    /// </summary>
    public class Calculation
    {
        private IDataAccess access;

        /// <summary>
        /// Год расчета
        /// </summary>
        public int Year { get; set; }
        
        /// <summary>
        /// Идентификаторы записей расчета в таблице БД
        /// </summary>
        public string[] Ids { get; set; }

        /// <summary>
        /// Указывает будем ли мы расчитывать E по d или будем вводить данные.
        /// true - рассчитываем, false - вводим
        /// </summary>
        public bool Calculate_E { get; set; }

        /// <summary>
        /// Указывает вводили ли данные из "Графика работы шлюзов".
        /// true - вводили, false - не вводили
        /// </summary>
        public bool Enter_VD { get; set; }

        /// <summary>
        /// Указывает будем ли мы расчитывать VD_plus и VD_minus или введем данные.
        /// true - расчитываем, false - вводим
        /// </summary>
        public bool Calculate_VD { get; set; }

        #region Переменные расчета

        /// <summary>
        /// Уровени воды в начале месяца, мБС
        /// </summary>
        public readonly double[] H1 = new double[12];
        /// <summary>
        /// Уровни воды в конце месяца, мБС
        /// </summary>
        public readonly double[] H2 = new double[12];
        /// <summary>
        /// Осадки измереные на м/ст Измаил, мм
        /// </summary>
        public readonly double[] P = new double[12];
        /// <summary>
        /// Средние уровни воды за месяц, мБС
        /// </summary>
        public readonly double[] avr_H = new double[12];
        /// <summary>
        /// Объемы воды в озере в начале месяца, млн м^3
        /// </summary>
        public readonly double[] W1 = new double[12];
        /// <summary>
        /// Объемы воды в озере в конце месяца, млн. м^3
        /// </summary>
        public readonly double[] W2 = new double[12];
        /// <summary>
        /// Изменения объемов воды в озере за месяц, млн. м^3
        /// </summary>
        public readonly double[] dlt_W = new double[12];
        /// <summary>
        /// Площади водного зеркала, км^2
        /// </summary>
        public readonly double[] F = new double[12];
        /// <summary>
        /// Объемы атмосферных осадков, млн. м^3
        /// </summary>
        public readonly double[] Vp = new double[12];
        /// <summary>
        /// Объемы речного стока, млн. м^3
        /// </summary>
        public readonly double[] Vr = new double[12];
        /// <summary>
        /// Объемы бокового притока, млн. м^3
        /// </summary>
        public readonly double[] Vb = new double[12];
        /// <summary>
        /// Объемы притока грунтовых вод, млн. м^3
        /// </summary>
        public readonly double[] Vg = new double[12];
        /// <summary>
        /// Объемы поступления дренажных вод, млн. м^3
        /// </summary>
        public readonly double[] Vdr = new double[12];
        /// <summary>
        /// Суммы приходных части водного баланса
        /// </summary>
        public readonly double[] EP = new double[12];
        /// <summary>
        /// Притоки воды из р. Дунай, млн. м^3
        /// </summary>
        public readonly double[] VD_plus = new double[12];
        /// <summary>
        /// Невязки уравнений водного баланса, млн. м^3
        /// </summary>
        public readonly double[] dlt_Vni = new double[12];
        /// <summary>
        /// Годовые значения сумм P, Vp, Vr, Vb, Vg, Vdr, EP, VD_plus
        /// </summary>
        public readonly double[] sum_1 = new double[8];
        /// <summary>
        /// Годовые значения процентов Vp, Vr, Vb, Vg, Vdr, EP, VD_plus
        /// </summary>
        public readonly double[] procent_1 = new double[7];
        /// <summary>
        /// Дефициты влажности, гПа
        /// </summary>
        /// <remarks>
        /// до 2011 года значения не было
        /// </remarks>
        public readonly double[] d = new double[12];
        /// <summary>
        /// Испарения, мм
        /// </summary>
        /// <remarks>
        /// после 2011 года является выходным значением
        /// </remarks>
        public readonly double[] E = new double[12];
        /// <summary>
        /// Сборы воды на орошение, млн. м^3
        /// </summary>
        public readonly double[] Vz = new double[12];
        /// <summary>
        /// Логарифмы дефицита влажности
        /// </summary>
        public readonly double[] lgd = new double[12];
        /// <summary>
        /// Логарифмы испарения
        /// </summary>
        public readonly double[] lgE = new double[12];
        /// <summary>
        /// Транспирациии, мм
        /// </summary>
        public readonly double[] Etr = new double[12];
        /// <summary>
        /// Объемы испарения, млн. м^3
        /// </summary>
        public readonly double[] VE = new double[12];
        /// <summary>
        /// Объемы транспирации, млн. м^3
        /// </summary>
        public readonly double[] Vtr = new double[12];
        /// <summary>
        /// Объемы фильтрации, млн. м^3
        /// </summary>
        public readonly double[] Vf = new double[12];
        /// <summary>
        /// Суммы расходной части водного баланса
        /// </summary>
        public readonly double[] ER = new double[12];
        /// <summary>
        /// Сбросы воды из озера в р. Дунай, млн. м^3
        /// </summary>
        public readonly double[] VD_minus = new double[12];
        /// <summary>
        /// Поддержка уровней воды озер Лунг-Сафьян, млн. м^3
        /// </summary>
        public readonly double[] Voz = new double[12];
        /// <summary>
        /// Годовые значения сумм E, Etr, VE, Vtr, Vf, Vz, ER, VD_minus, Voz
        /// </summary>
        public readonly double[] sum_2 = new double[9];
        /// <summary>
        /// Годовые значения процентов VE, Vtr, Vf, Vz, ER, VD_minus, Voz
        /// </summary>
        public readonly double[] procent_2 = new double[7];
        /// <summary>
        /// Среднии по озеру минерализации в начале месяца, кг/м^3
        /// </summary>
        public readonly double[] S1 = new double[12];
        /// <summary>
        /// S2 - Средняя по озеру минерализация в конце месяца, кг/м^3
        /// </summary>
        public readonly double[] S2 = new double[12];
        /// <summary>
        /// Минерализации осадков,кг/м^3
        /// </summary>
        public readonly double[] Sp = new double[12];
        /// <summary>
        /// Минерализации поверхностного стока, кг/м^3
        /// </summary>
        public readonly double[] Sr = new double[12];
        /// <summary>
        /// Минерализации бокового притока, кг/м^3
        /// </summary>
        public readonly double[] Sb = new double[12];
        /// <summary>
        /// Минерализации почвенного стока, кг/м^3
        /// </summary>
        public readonly double[] Sg = new double[12];
        /// <summary>
        /// Минерализации дренажных вод, кг/м^3
        /// </summary>
        public readonly double[] Sdr = new double[12];
        /// <summary>
        /// Минерализации Дунайской воды, кг/м^3
        /// </summary>
        public readonly double[] SD_plus = new double[12];
        /// <summary>
        /// Концентрации солей по озеру в начале месяца, 10^6 т.
        /// </summary>
        public readonly double[] C1 = new double[12];
        /// <summary>
        /// Концентрации солей по озеру в конце месяца, 10^6 т.
        /// </summary>
        public readonly double[] C2 = new double[12];
        /// <summary>
        /// Поступления солей с осадками, 10^6 т.
        /// </summary>
        public readonly double[] Cp = new double[12];
        /// <summary>
        /// Поступления солей с поверхностным стоком, 10^6 т.
        /// </summary>
        public readonly double[] Cr = new double[12];
        /// <summary>
        /// Поступления солей с боковым притоком, 10^6 т.
        /// </summary>
        public readonly double[] Cb = new double[12];
        /// <summary>
        /// Поступления солей с грунтовыми водами, 10^6 т.
        /// </summary>
        public readonly double[] Cg = new double[12];
        /// <summary>
        /// Поступления солей с дренажными водами, 10^6 т.
        /// </summary>
        public readonly double[] Cdr = new double[12];
        /// <summary>
        /// Поступления солей с Дунайской водой, 10^6 т.
        /// </summary>
        public readonly double[] CD_plus = new double[12];
        /// <summary>
        /// Суммы приходных частей солевого баланса
        /// </summary>
        public readonly double[] EpCi_plus = new double[12];
        /// <summary>
        /// Годовые значения сумм Cp, Cr, Cb, Cg, Cdr, CD_plus, EpCi_plus
        /// </summary>
        public readonly double[] sum_3 = new double[7];
        /// <summary>
        /// Годовые значения процентов Cp, Cr, Cb, Cg, Cdr, CD_plus, EpCi_plus
        /// </summary>
        public readonly double[] procent_3 = new double[7];
        /// <summary>
        /// Минерализации фильтрации, кг/м^3
        /// </summary>
        public readonly double[] Sf = new double[12];
        /// <summary>
        /// Минерализации сбора воды на орошение, кг/м^3
        /// </summary>
        public readonly double[] Sz = new double[12];
        /// <summary>
        /// Минерализации сбросов воды в р. Дунай, кг/м^3
        /// </summary>
        public readonly double[] SD_minus = new double[12];
        /// <summary>
        /// Минерализации воды в поддержку уровней воды в системе озер Лунг-Сафьян, кг/м^3
        /// </summary>
        public readonly double[] Soz = new double[12];
        /// <summary>
        /// Потери солей с фильтрацией, 10^6 т.
        /// </summary>
        public readonly double[] Cf = new double[12];
        /// <summary>
        /// Потери солей на орошении, 10^6 т.
        /// </summary>
        public readonly double[] Cz = new double[12];
        /// <summary>
        /// Сбросы воды вместе с солями в р. Дунай, 10^6 т.
        /// </summary>
        public readonly double[] CD_minus = new double[12];
        /// <summary>
        /// Соли, которые выводятся с водой в поддержку уровней воды в системе озер Лунг-Сафьян, 10^6 т.
        /// </summary>
        public readonly double[] Coz = new double[12];
        /// <summary>
        /// Суммы расходной части солевого баланса
        /// </summary>
        public readonly double[] EpCi_minus = new double[12];
        /// <summary>
        /// Годовые значения сумм Cf, Cz, CD_minus, Coz, EpCi_minus
        /// </summary>
        public readonly double[] sum_4 = new double[5];
        /// <summary>
        /// Годовые значения процентов Cf, Cz, CD_minus, Coz, EpCi_minus
        /// </summary>
        public readonly double[] procent_4 = new double[5];
        #endregion
        #region Таблицы, коэффициенты, флаги, указатели и прочая вспомогательная ерунда 
        
        private readonly byte[] VD_month = new byte[12];        // Указывает в каких месяцах шлюз был открыт для набора воды и в каких месяцах шлюз открыт для сброса воды
                                                                // 0 - закрыт, 1 - открыт для набора, 2 - открыт для сброса

        private readonly double[,] table_3_1;     // Таблица внутренегодового распределения поверхсного стока р. Тараклия
        private readonly double[,] table_3_2;     // Таблица внутренегодового распределения прилива грунтовых вод

        private readonly int[] k1 = new int[6];           // Коэффициенты для расчета Etr, от 5 до 11 месяца
        private readonly double[] k2 = new double[6];     // Коэффициенты для расчета lgE,
        private readonly double[] k3 = new double[6];     // от 4 до 10 месяца

        // Таблица зависимостей площади водного к среднему уровню воды за год
        private readonly double[,] dependence;

        // Коєффициенты для для расчета W(1/2) 1, W(1/2) 2, Vb, Vdr, Vtr, Vf, sum(Etr), Sp, Sr, Sb, Sg, Sdr, SD_plus
        private readonly double[] coefficients;
        #endregion

        /// <summary>
        /// Иниализирует новый экземпляр класса Calculation
        /// </summary>
        public Calculation()
        {
            access = new SQLiteDataAccess();

            string[] columns = { "HighWaterLevel", "AverageWaterLevel", "LowWaterLevel" };

            table_3_1 = access.GetTableData<double>("Table_3_1", 12, columns);
            table_3_2 = access.GetTableData<double>("Table_3_2", 12, columns);
            coefficients = access.GetColumnData<double>("SELECT Value FROM Coefficients").ToArray();
            dependence = access.GetTableData<double>("Dependence_avrH_to_F", 71, new string[] { "avr_H", "F" });

            for (int i = 13, j = 0; i < 19; i++, j++)
                k1[j] = (int)coefficients[i];

            for (int i = 19, j = 0; i < 25; i++, j++)
            {
                k2[j] = coefficients[i];
                k3[j] = coefficients[i + 6];
            }
        }

        /// <summary>
        /// Иниализирует новый экземпляр класса Calculation
        /// </summary>
        /// <param name="year"> Год расчета </param>
        /// <param name="sum_1_4"> Сумма Vg за год </param>
        /// <param name="S1_0"> Значение S1[0] за прошлый год </param>
        /// <param name="calculate_E"> Истина, если рассчитываем E и вводим d, иначе вводим E </param>
        /// <param name="H1"> Объемы уровней воды в начале месяца за год </param>
        /// <param name="H2"> Объемы уровней воды в конце месяца за год </param>
        /// <param name="P"> Объемы осадков за год </param>
        /// <param name="Vz"> Объемы воды на орошение за год </param>
        /// <param name="d_or_E"> Данные d или E за год, в соотвесвии флагу calculate_E </param>
        public Calculation(int year, double sum_1_4, double S1_0, bool calculate_E, double[] H1, 
            double[] H2, double[] P, double[] Vz, double[] d_or_E) : this()
        {
            Year = year;
            sum_1[4] = sum_1_4;
            S1[0] = S1_0;
            Calculate_E = calculate_E;
            this.H1 = H1;
            this.H2 = H2;
            this.P = P;
            this.Vz = Vz;
        }

        /// <summary>
        /// Иниализирует новый экземпляр класса Calculation
        /// </summary>
        /// <param name="year"> Год расчета </param>
        /// <param name="sum_1_4"> Сумма Vg за год </param>
        /// <param name="S1_0"> Значение S1[0] за прошлый год </param>
        /// <param name="calculate_E"> Истина, если рассчитываем E и вводим d, иначе вводим E </param>
        /// <param name="enter_VD"> Истина, если вводили данные из "Графика работы шлюзов" </param>
        /// <param name="calculate_VD"> Истина, если рассчитываем VD, иначе вводим </param>
        /// <param name="H1"> Объемы уровней воды в начале месяца за год </param>
        /// <param name="H2"> Объемы уровней воды в конце месяца за год </param>
        /// <param name="P"> Объемы осадков за год </param>
        /// <param name="Vz"> Объемы воды на орошение за год </param>
        /// <param name="d_or_E"> Данные d или E за год, в соотвесвии флагу calculate_E </param>
        /// <param name="VD_month"> Указывает в какие месяцы шлюз был закрыт - 0, открыт для набора - 1, открыт для сброса - 2 </param>
        public Calculation(int year, double sum_1_4, double S1_0, bool calculate_E, bool enter_VD, 
            bool calculate_VD, double[] H1, double[] H2, double[] P, double[] Vz, double[] d_or_E, byte[] VD_month) :
            this(year, sum_1_4, S1_0, calculate_E, H1, H2, P, Vz, d_or_E)
        {
            Calculate_E = calculate_E;
            Enter_VD = enter_VD;
            this.VD_month = VD_month;
        }

        /// <summary>
        /// Иниализирует новый экземпляр класса Calculation
        /// </summary>
        /// <param name = "year" > Год расчета</param>
        /// <param name="sum_1_4"> Сумма Vg за год </param>
        /// <param name="S1_0"> Значение S1[0] за прошлый год </param>
        /// <param name="calculate_E"> Истина, если рассчитываем E и вводим d, иначе вводим E </param>
        /// <param name="enter_VD"> Истина, если вводили данные из "Графика работы шлюзов" </param>
        /// <param name="calculate_VD"> Истина, если рассчитываем VD, иначе вводим </param>
        /// <param name="H1"> Объемы уровней воды в начале месяца за год </param>
        /// <param name="H2"> Объемы уровней воды в конце месяца за год </param>
        /// <param name="P"> Объемы осадков за год </param>
        /// <param name="Vz"> Объемы воды на орошение за год </param>
        /// <param name="d_or_E"> Данные d или E за год, в соотвесвии флагу calculate_E </param>
        /// <param name="VD_plus"> Объемы притока воды </param>
        /// <param name="VD_minus"> Объемы сброса воды </param>
        public Calculation(int year, double sum_1_4, double S1_0, bool calculate_E, bool enter_VD, 
            bool calculate_VD, double[] H1, double[] H2, double[] P, double[] Vz, double[] d_or_E, double[] VD_plus, double[] VD_minus) : 
            this(year, sum_1_4, S1_0, calculate_E, H1, H2, P, Vz, d_or_E)
        {
            Calculate_E = calculate_E;
            Enter_VD = enter_VD;
            this.VD_plus = VD_plus;
            this.VD_minus = VD_minus;
        }

        #region Методы расчета годового расчета озера Катлабух

        /// <summary>
        /// Этот метод проводит расчет выходных данных
        /// </summary>
        /// <returns> истинно если расчет прошел успешно, иначе ложно </returns>
        public bool Calculate()
        {
            try
            {
                int waterLvl = 0;  // водность

                // Узнаем сумму осадков, чтобы определить водность
                for (int i = 0; i < 12; i++)
                    sum_1[0] += P[i];

                // Рассчетаем суммарное Vr
                // и между делом функция помножит значения в таблицах 
                // TABLE_3_1 и TABLE_3_2 на коэффициент kp1
                sum_1[2] = CaluclateSum_Vr();

                // Узнаем водность в соотвествии с диапазоном
                if (800 > sum_1[0] && sum_1[0] > 510) waterLvl = 0;
                else if (509 > sum_1[0] && sum_1[0] > 415) waterLvl = 1;
                else if (414 > sum_1[0] && sum_1[0] > 240) waterLvl = 2;

                // Вычисляем среднне значение уровня воды за месяц и 
                // среднее заначение среднего
                double avr_avr_H = 0;
                for (int i = 0; i < 12; i++)
                {
                    avr_H[i] = (H1[i] + H2[i]) / 2;
                    avr_avr_H += avr_H[i];
                }
                avr_avr_H /= 12;

                // Определяем площадь водного зеркала для каждого месяца
                for (int i = 0; i < 12; i++)
                {
                    int k = 0;
                    while (k < 71)
                    {
                        if (avr_H[i] <= dependence[0, k])
                        {
                            F[i] = dependence[1, k];
                            break;
                        }
                        k++;
                    }
                }

                // Расчитываем значения водного баланса
                for (int i = 0; i < 12; i++)
                {
                    W1[i] = H1[i] * coefficients[0] + coefficients[1];      // W1[i] = H1[i] * 67.098f + 17.278f;
                    W2[i] = H2[i] * coefficients[0] + coefficients[1];      // W2[i] = H2[i] * 67.098f + 17.278f;
                    dlt_W[i] = W2[i] - W1[i];
                    Vp[i] = (F[i] * P[i]) / 1000;
                    Vr[i] = (sum_1[2] / 100) * table_3_1[waterLvl, i];
                    Vb[i] = Vr[i] * coefficients[2];                        // Vb[i] = Vr[i] * 0.23f;
                    Vg[i] = (sum_1[4] / 100) * table_3_2[waterLvl, i];
                    Vdr[i] = Vz[i] * coefficients[3];                       // Vdr[i] = Vz[i] * 0.2f;
                    EP[i] = Vp[i] + Vr[i] + Vb[i] + Vg[i] + Vdr[i];

                    if (Calculate_E)
                    {
                        if (d[i] != 0) lgd[i] = Math.Log10(d[i]);
                        else lgd[i] = 0;

                        if (2 < i && i < 9)
                        {
                            lgE[i] = k2[i - 3] * lgd[i] + k3[i - 3];
                            E[i] = Math.Pow(10, lgE[i]);
                        }
                    }

                    sum_2[0] += E[i];
                }

                sum_2[1] = sum_2[0] * coefficients[6] - sum_2[0];           // sum_2[1] = sum_2[0] * 1.14f - sum_2[0];    // Etr

                for (int i = 0; i < 12; i++)
                {
                    if (3 < i && i < 10) Etr[i] = (sum_2[1] / 100) * k1[i - 4];

                    VE[i] = (F[i] * E[i]) / 1000;
                    Vtr[i] = (Etr[i] * F[i] * coefficients[4]) / 1000;      // Vtr[i] = (Etr[i] * F[i] * 0.3f) / 1000;
                    Vf[i] = (avr_H[i] / avr_avr_H) * coefficients[5];       // Vf[i] = (avr_H[i] / avr_avr_H) * 0.55f;
                    ER[i] = VE[i] + Vtr[i] + Vf[i] + Vz[i];
                    Voz[i] = (EP[i] - ER[i] - dlt_W[i]) * -1;
                    dlt_Vni[i] = (EP[i] - ER[i] - dlt_W[i]) * -1;

                    if (Enter_VD && Calculate_VD)
                    {
                        if (VD_month[i] == 2) VD_minus[i] = (EP[i] - ER[i] - dlt_W[i]) * -1;
                        if (VD_month[i] == 1) VD_plus[i] = (EP[i] - ER[i] - dlt_W[i]) * -1;
                    }

                    // Подсчитываем суммы водного баланса
                    sum_1[1] += Vp[i];
                    sum_1[3] += Vb[i];
                    sum_1[5] += Vdr[i];
                    sum_1[6] += EP[i];
                    sum_1[7] += VD_plus[i];
                    sum_2[2] += VE[i];
                    sum_2[3] += Vtr[i];
                    sum_2[4] += Vf[i];
                    sum_2[5] += Vz[i];
                    sum_2[6] += ER[i];
                    sum_2[7] += VD_minus[i];
                    sum_2[8] += Voz[i];
                }

                // Подсчитываем проценты водного баланса
                procent_1[0] = (sum_1[1] / (sum_1[6] + sum_1[7])) * 100;                                    // Vp
                procent_1[1] = (sum_1[2] / (sum_1[6] + sum_1[7])) * 100;                                    // Vr
                procent_1[2] = (sum_1[3] / (sum_1[6] + sum_1[7])) * 100;                                    // Vb
                procent_1[3] = (sum_1[4] / (sum_1[6] + sum_1[7])) * 100;                                    // Vg
                procent_1[4] = (sum_1[5] / (sum_1[6] + sum_1[7])) * 100;                                    // Vdr
                procent_1[5] = procent_1[0] + procent_1[1] + procent_1[2] + procent_1[3] + procent_1[4];    // EP
                procent_1[6] = (sum_1[7] / (sum_1[6] + sum_1[7])) * 100;                                    // VD_plus
                procent_2[0] = (sum_2[2] / (sum_2[6] + sum_2[7] + sum_2[8])) * 100;                         // VE
                procent_2[1] = (sum_2[3] / (sum_2[6] + sum_2[7] + sum_2[8])) * 100;                         // Vtr
                procent_2[2] = (sum_2[4] / (sum_2[6] + sum_2[7] + sum_2[8])) * 100;                         // Vf
                procent_2[3] = (sum_2[5] / (sum_2[6] + sum_2[7] + sum_2[8])) * 100;                         // Vz
                procent_2[4] = (sum_2[6] / (sum_2[6] + sum_2[7] + sum_2[8])) * 100;                         // ER
                procent_2[5] = (sum_2[7] / (sum_2[6] + sum_2[7] + sum_2[8])) * 100;                         // VD_minus
                procent_2[6] = (sum_2[8] / (sum_2[6] + sum_2[7] + sum_2[8])) * 100;                         // Voz

                // Расчитываем значения солевого баланса
                for (int i = 0; i < 12; i++)
                {
                    Sp[i] = coefficients[7];                                // Sp[i] = 0.22f;
                    Sr[i] = coefficients[8];                                // Sr[i] = 5.16f;
                    Sb[i] = Sr[i] * coefficients[9];                        // Sb[i] = Sr[i] * 0.57f;
                    Sg[i] = coefficients[10];                               // Sg[i] = 2.6f;
                    Sdr[i] = coefficients[11];                              // Sdr[i] = 2;
                    SD_plus[i] = coefficients[12];                          // SD_plus[i] = 0.39f;

                    if (i == 0) C1[i] = W1[i] * S1[i];

                    Sf[i] = S1[i];
                    Sz[i] = S1[i];
                    SD_minus[i] = S1[i];
                    Soz[i] = S1[i];
                    Cf[i] = Vf[i] * Sf[i];
                    Cz[i] = Vz[i] * Sz[i];
                    CD_minus[i] = VD_minus[i] * SD_minus[i];
                    Coz[i] = Voz[i] * Soz[i];
                    EpCi_minus[i] = Cf[i] + Cz[i] + CD_minus[i] + Coz[i];
                    C2[i] = C1[i] + EpCi_plus[i] - EpCi_minus[i];

                    if (i < 11) C1[i + 1] = C2[i];

                    Cp[i] = Vp[i] * Sp[i];
                    Cr[i] = Vr[i] * Sr[i];
                    Cb[i] = Vb[i] * Sb[i];
                    Cg[i] = Vg[i] * Sg[i];
                    Cdr[i] = Vdr[i] * Sdr[i];
                    CD_plus[i] = VD_plus[i] * SD_plus[i];
                    EpCi_plus[i] = Cp[i] + Cr[i] + Cb[i] + Cg[i] + Cdr[i] + CD_plus[i];
                    S2[i] = C2[i] / W2[i];

                    if (i < 11) S1[i + 1] = S2[i];

                    // Подсчитываем суммы солевого баланса
                    sum_3[0] += Cp[i];
                    sum_3[1] += Cr[i];
                    sum_3[2] += Cb[i];
                    sum_3[3] += Cg[i];
                    sum_3[4] += Cdr[i];
                    sum_3[5] += CD_plus[i];
                    sum_3[6] += EpCi_plus[i];
                    sum_4[0] += Cf[i];
                    sum_4[1] += Cz[i];
                    sum_4[2] += CD_minus[i];
                    sum_4[3] += Coz[i];
                    sum_4[4] += EpCi_minus[i];
                }

                // Подсчитываем проценты солевого баланса
                procent_3[0] = (sum_3[0] / sum_3[6]) * 100;     // Cp
                procent_3[1] = (sum_3[1] / sum_3[6]) * 100;     // Cr
                procent_3[2] = (sum_3[2] / sum_3[6]) * 100;     // Cb
                procent_3[3] = (sum_3[3] / sum_3[6]) * 100;     // Cg
                procent_3[4] = (sum_3[4] / sum_3[6]) * 100;     // Cdr
                procent_3[5] = (sum_3[5] / sum_3[6]) * 100;     // CD_plus
                procent_3[6] = (sum_3[6] / sum_3[6]) * 100;     // EpCi_plus    
                procent_4[0] = (sum_4[0] / sum_4[4]) * 100;     // Cf
                procent_4[1] = (sum_4[1] / sum_4[4]) * 100;     // Cz
                procent_4[2] = (sum_4[2] / sum_4[4]) * 100;     // CD_minus
                procent_4[3] = (sum_4[3] / sum_4[4]) * 100;     // Coz
                procent_4[4] = (sum_4[4] / sum_4[4]) * 100;     // EpCi_minus

                // Округляем значения до сотых
                RoundCalculation();

                return true;
            }
            catch (DivideByZeroException)
            {
                return false;
            }
        }

        private double CaluclateSum_Vr()
        {
            double[] xp = access.GetColumnData<double>("SELECT Xp FROM Gamma_distribution").ToArray();
            int id_rec = 0;

            if (sum_1[0] > xp[0])
                id_rec = 1;
            else if (sum_1[0] < xp[xp.Length - 1])
                id_rec = xp.Length;
            else
            {
                for (int i = 0; i < xp.Length; i++)
                {
                    if (sum_1[0] > xp[i])
                    {
                        id_rec = i;
                        break;
                    }
                }
            }

            double kp1 = access.GetCellData<double>($"SELECT kp1 FROM Gamma_distribution WHERE Id_rec = {id_rec}");
            double kp2 = access.GetCellData<double>($"SELECT kp2 FROM Gamma_distribution WHERE Id_rec = {id_rec}");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    table_3_1[i, j] *= kp1;
                    table_3_2[i, j] *= kp1;
                }
            }

            return (((coefficients[31] * coefficients[32]) / 1000) * kp2 * coefficients[33] * coefficients[34]) / 1000000;
        }

        private void RoundCalculation()
        {
            for (int i = 0; i < 12; i++)
            {
                avr_H[i] = Math.Round(avr_H[i], 2);
                W1[i] = Math.Round(W1[i], 2);
                W2[i] = Math.Round(W2[i], 2);
                dlt_W[i] = Math.Round(dlt_W[i], 2);
                F[i] = Math.Round(F[i], 2);
                Vp[i] = Math.Round(Vp[i], 2);
                Vr[i] = Math.Round(Vr[i], 2);
                Vb[i] = Math.Round(Vb[i], 2);
                Vg[i] = Math.Round(Vg[i], 2);
                Vdr[i] = Math.Round(Vdr[i], 2);
                EP[i] = Math.Round(EP[i], 2);
                VD_plus[i] = Math.Round(VD_plus[i], 2);
                dlt_Vni[i] = Math.Round(dlt_Vni[i], 2);
                lgd[i] = Math.Round(lgd[i], 2);
                lgE[i] = Math.Round(lgE[i], 2);
                E[i] = Math.Round(E[i], 2);
                Etr[i] = Math.Round(Etr[i], 2);
                VE[i] = Math.Round(VE[i], 2);
                Vtr[i] = Math.Round(Vtr[i], 2);
                Vf[i] = Math.Round(Vf[i], 2);
                ER[i] = Math.Round(ER[i], 2);
                VD_minus[i] = Math.Round(VD_minus[i], 2);
                Voz[i] = Math.Round(Voz[i], 2);
                S1[i] = Math.Round(S1[i], 2);
                S2[i] = Math.Round(S2[i], 2);
                Sp[i] = Math.Round(Sp[i], 2);
                Sr[i] = Math.Round(Sr[i], 2);
                Sb[i] = Math.Round(Sb[i], 2);
                Sdr[i] = Math.Round(Sdr[i], 2);
                SD_plus[i] = Math.Round(SD_plus[i], 2);
                C1[i] = Math.Round(C1[i], 2);
                C2[i] = Math.Round(C2[i], 2);
                Cp[i] = Math.Round(Cp[i], 2);
                Cr[i] = Math.Round(Cr[i], 2);
                Cb[i] = Math.Round(Cb[i], 2);
                Cg[i] = Math.Round(Cg[i], 2);
                Cdr[i] = Math.Round(Cdr[i], 2);
                CD_plus[i] = Math.Round(CD_plus[i], 2);
                EpCi_plus[i] = Math.Round(EpCi_plus[i], 2);
                Sf[i] = Math.Round(Sf[i], 2);
                Sz[i] = Math.Round(Sz[i], 2);
                SD_minus[i] = Math.Round(SD_minus[i], 2);
                Soz[i] = Math.Round(Soz[i], 2);
                Cf[i] = Math.Round(Cf[i], 2);
                Cz[i] = Math.Round(Cz[i], 2);
                CD_minus[i] = Math.Round(CD_minus[i], 2);
                EpCi_minus[i] = Math.Round(EpCi_minus[i], 2);

                if (i < 5)
                {
                    sum_4[i] = Math.Round(sum_4[i], 2);
                    procent_4[i] = Math.Round(procent_4[i], 2);
                }

                if (i < 7)
                {
                    procent_1[i] = Math.Round(procent_1[i], 2);
                    procent_2[i] = Math.Round(procent_2[i], 2);
                    procent_3[i] = Math.Round(procent_3[i], 2);
                    sum_3[i] = Math.Round(sum_3[i], 2);
                }

                if (i < 8)
                {
                    sum_1[i] = Math.Round(sum_1[i], 2);
                }

                if (i < 9)
                {
                    sum_2[i] = Math.Round(sum_2[i], 2);
                }
            }
        }
        #endregion
    }
}
