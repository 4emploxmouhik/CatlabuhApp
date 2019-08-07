namespace CatlabuhApp.UI.Support.Dialogs
{
    partial class MessageDialog
    {
        public static string AlertTitle1
        {
            get
            {
                string title = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        title = "Inaccurate data";
                        break;
                    case "uk-UA":
                        title = "Некоректні дані";
                        break;
                }

                return title;
            }
        }
        public static string AlertTitle2
        {
            get
            {
                string title = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        title = "Not enough data to build a chart.";
                        break;
                    case "uk-UA":
                        title = "Недостатньо даних для побудови діаграми.";
                        break;
                }

                return title;
            }
        }
        
        public static string SuccessTitle
        {
            get
            {
                string title = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        title = "The operation is successful";
                        break;
                    case "uk-UA":
                        title = "Операція виконана успішно";
                        break;
                }

                return title;
            }
        }
        public static string ErrorTitle
        {
            get
            {
                string title = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        title = "Error";
                        break;
                    case "uk-UA":
                        title = "Помилка";
                        break;
                }

                return title;
            }
        }
        public static string QuestionTitle
        {
            get
            {
                string title = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        title = "Confirm the action";
                        break;
                    case "uk-UA":
                        title = "Підтвердьте дію";
                        break;
                }

                return title;
            }
        }

        public static string AlertText1
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Specify the year of calculation.";
                        break;
                    case "uk-UA":
                        text = "Вкажіть рік розрахунку.";
                        break;
                }

                return text;
            }
        }
        public static string AlertText2
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Provide all necessary data for the calculation.";
                        break;
                    case "uk-UA":
                        text = "Надайте всі необхідні дані для проведення розрахунку.";
                        break;
                }

                return text;
            }
        }
        public static string AlertText3
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Specify at least one table for export.";
                        break;
                    case "uk-UA":
                        text = "Вкажіть принаймні одну таблицю для експорту.";
                        break;
                }

                return text;
            }
        }
        public static string AlertText4
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Correctly specify the value of the cell of the table.";
                        break;
                    case "uk-UA":
                        text = "Вірно вкажіть значення осередку таблиці.";
                        break;
                }

                return text;
            }
        }
        public static string AlertText5
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The process cannot access the file. Close the file and click OK to try saving again.";// Click Cancel to open the file, the file will not be saved.";
                        break;
                    case "uk-UA":
                        text = "Процес не може отримати доступ до файлу. Закрийте файл і натисніть кнопку ОК, щоб спробувати зберегти знову.";// Натисніть Скасувати, щоб відкрити файл, файл не буде збережено.";
                        break;
                }
                
                return text;
            }
        }
        public static string AlertText6
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Verify that at least one value for the Y axis and two values for the X axis are added.";
                        break;
                    case "uk-UA":
                        text = "Перевірте, чи додано принаймні одне значення для осі Y та два значення для осі X.";
                        break;
                }

                return text;
            }
        }
        public static string AlertText7
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Select all file locations.";
                        break;
                    case "uk-UA":
                        text = "Оберіть всі місця розташування файлів.";
                        break;
                    case "ru-RU":
                        text = "Выберите все местоположения файлов.";
                        break;
                }

                return text;
            }
        }

        public static string SuccessText1
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The calculation is done and saved.";
                        break;
                    case "uk-UA":
                        text = "Розрахунок проведено і збережено.";
                        break;
                }

                return text;
            }
        }
        public static string SuccessText2
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Input data of the calculation saved.";
                        break;
                    case "uk-UA":
                        text = "Вихідні дані розрахунку збережено.";
                        break;
                }

                return text;
            }
        }
        public static string SuccessText3
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The changes saved.";
                        break;
                    case "uk-UA":
                        text = "Внесені зміни збережено.";
                        break;
                }

                return text;
            }
        }
        public static string SuccessText4
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The calculation has been deleted.";
                        break;
                    case "uk-UA":
                        text = "Розрахунок видалено.";
                        break;
                }

                return text;
            }
        }
        public static string SuccessText5
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The calculation table(s) exported.";
                        break;
                    case "uk-UA":
                        text = "Таблиця(і) розрахунку експортовано.";
                        break;
                }

                return text;
            }
        }
        public static string SuccessText6
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The data of the dispatching schedule of the work of the gateways saved.";
                        break;
                    case "uk-UA":
                        text = "Дані диспетчерського графіку роботи шлюзів збережено.";
                        break;
                }

                return text;
            }
        }

        public static string ErrorText1
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Data has not been saved.";
                        break;
                    case "uk-UA":
                        text = "Дані не було збережено.";
                        break;
                }

                return text;
            }
        }
        public static string ErrorText2
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The calculation has not been deleted.";
                        break;
                    case "uk-UA":
                        text = "Розрахунок не було видалено.";
                        break;
                }

                return text;
            }
        }
        public static string ErrorText3
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Error while calculating.";
                        break;
                    case "uk-UA":
                        text = "Помилка при проведенні розрахунку.";
                        break;
                }

                return text;
            }
        }
        public static string ErrorText4
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The database file does not exist(specified).";
                        break;
                    case "uk-UA":
                        text = "Файлу бази даних не існує(вказано).";
                        break;
                }

                return text;
            }
        }
        public static string ErrorText5
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "The database file is corrupt or invalid.";
                        break;
                    case "uk-UA":
                        text = "Файл бази данних пошкодженно чи некоректний.";
                        break;
                }

                return text;
            }
        }

        public static string QuestionText1
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = $"Are you sure you want to delete the calculation?";
                        break;
                    case "uk-UA":
                        text = $"Ви впевнені, що хочете видалити розрахунок?";
                        break;
                }

                return text;
            }
        }
        public static string QuestionText2
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Save changed data?";
                        break;
                    case "uk-UA":
                        text = "Зберегти змінені дані?";
                        break;
                }

                return text;
            }
        }
        public static string QuestionText3
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = $"Are you sure you want to recalculate the calculation?";
                        break;
                    case "uk-UA":
                        text = $"Ви впевнені, що хочете виконати перерахунок розрахунку?";
                        break;
                }

                return text;
            }
        }
        public static string QuestionText4
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "This file already exists. Replace it?";
                        break;
                    case "uk-UA":
                        text = "Цей файл вже існує. Замінити його?";
                        break;
                }

                return text;
            }
        }
    }
}
