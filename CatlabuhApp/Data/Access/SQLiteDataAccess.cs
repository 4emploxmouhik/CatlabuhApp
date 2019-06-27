using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CatlabuhApp.Data.Access
{
    /// <summary>
    /// Содержит методы для взаиодействия с БД SQLite
    /// </summary>
    public class SQLiteDataAccess : IDataAccess
    {
        private string LoadConnectionString(string name = "Default")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Возвращает значение хранящееся в ячейке таблицы БД
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="sql">SQL-запрос</param>
        /// <returns></returns>
        public T GetCellData<T>(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<T>(sql, new DynamicParameters()).AsList()[0];
            }
        }

        /// <summary>
        /// Возвращает значения ячеек столбца таблицы БД
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="sql">SQL-запрос</param>
        /// <returns>Список значений ячеек столбца</returns>
        public List<T> GetColumnData<T>(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<T>(sql).AsList();
            }
        }

        /// <summary>
        /// Возвращает таблицу расчета за определенный год
        /// </summary>
        /// <param name="sql">SQL-запрос</param>
        /// <returns>Таблицу данных расчета</returns>
        public DataTable GetTableView(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, (SQLiteConnection)cnn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                return dataSet.Tables[0];
            }
        }

        /// <summary>
        /// Возвращает матрицу данных таблицы БД
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="table">Название таблицы</param>
        /// <param name="rowsCount">Число строк</param>
        /// <param name="columns">Названия столбцов</param>
        /// <returns>Матрица данных</returns>
        public T[,] GetTableData<T>(string table, int rowsCount, string[] columns)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (rowsCount <= 0 || columns.Length == 0)
                {
                    throw new ArgumentException("rowCount or column.Length equlas zero");
                }

                T[,] output = new T[columns.Length, rowsCount];
                List<T> row;

                for (int i = 0; i < columns.Length; i++)
                {
                    row = GetColumnData<T>($"SELECT {columns[i]} FROM {table}");

                    for (int j = 0; j < rowsCount; j++)
                    {
                        output[i, j] = row[i];
                    }
                }

                return output;
            }
        }

        /// <summary>
        /// Заполняет выпадающий список данными из БД
        /// </summary>
        /// <param name="sql">SQL-запрос</param>
        /// <param name="comboBox">ComboBox, который надо заполнить</param>
        /// <param name="displayMember">Название отображаемого значения</param>
        /// <param name="valueMember">Название фактического значения</param>
        public ComboBox FillComboBox(string sql, ComboBox comboBox, string displayMember, string valueMember)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, (SQLiteConnection)cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox.DataSource = dt;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;

                return comboBox;
            }
        }

        /// <summary>
        /// Выполняет SQL-запрос, ориентрован на выполнения Insert, Update и Delete запросов
        /// </summary>
        /// <param name="sql">SQL-запрос</param>
        public void Execute(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute(sql);
                }
                catch (SQLiteException)
                {
                    Console.WriteLine("Catch SQLiteException in SQLiteDataAccess.Execute(string sql)\nstring sql equals: \n\t{0}", sql);
                }
            }
        }

    }
}
