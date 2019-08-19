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
                    case "ru-RU":
                        title = "Некоректные данныe";
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
                    case "ru-RU":
                        title = "Недостаточно данных для построения диаграммы";
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
                    case "ru-RU":
                        title = "Операция выполнена успешно";
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
                    case "ru-RU":
                        title = "Ошибка";
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
                    case "ru-RU":
                        title = "Дотвердите действие";
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
                    case "ru-RU":
                        text = "Укажите год расчета.";
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
                    case "ru-RU":
                        text = "Предоставте все необходимые данные для проведения расчёта.";
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
                    case "ru-RU":
                        text = "Укажите хотя бы одну таблицу для экспорта.";
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
                    case "ru-RU":
                        text = "Верно укажите значение ячейки таблицы.";
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
                        text = "The process cannot access the file. Close the file and click OK to try saving again.";
                        break;
                    case "uk-UA":
                        text = "Процес не може отримати доступ до файлу. Закрийте файл і натисніть кнопку ОК, щоб спробувати зберегти знову.";
                        break;
                    case "ru-RU":
                        text = "Процесс не может получить доступ к файлу. Закройте файл и нажмите кнопку ОК, чтобы поробывать сохранить снова.";
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
                        text = "Перевірте, чи додано принаймні одне значення для вісі Y та два значення для вісі X.";
                        break;
                    case "ru-RU":
                        text = "Проверте, добавлено ли хотя бы одно значение для оси Y и два значення для оси X.";
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
                    case "ru-RU":
                        text = "Расчёт проведен и сохранен.";
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
                    case "ru-RU":
                        text = "Исходные данные расчёта сохранены.";
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
                    case "ru-RU":
                        text = "Внесенные измения сохранены.";
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
                    case "ru-RU":
                        text = "Расчёт удален.";
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
                    case "ru-RU":
                        text = "Таблица(ы) расчёта экспортировано.";
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
                    case "ru-RU":
                        text = "Данные диспетчерского графика работы шлюзов сохранены.";
                        break;
                }

                return text;
            }
        }
        public static string SuccessText7
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Chart image saved.";
                        break;
                    case "uk-UA":
                        text = "Зображення діаграми збережено.";
                        break;
                    case "ru-RU":
                        text = "Изображение диаграммы сохранено.";
                        break;
                }

                return text;
            }
        }
        public static string SuccessText8
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Chart exported.";
                        break;
                    case "uk-UA":
                        text = "Діаграма експортована.";
                        break;
                    case "ru-RU":
                        text = "Диаграмма экспортирована.";
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
                    case "ru-RU":
                        text = "Данные не было сохранено.";
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
                    case "ru-RU":
                        text = "Расчёт не был удален.";
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
                    case "ru-RU":
                        text = "Ошибка при проведении расчёта.";
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
                    case "ru-RU":
                        text = "Файла базы данных не существует(указан).";
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
                        text = "DB version mismatch.";
                        break;
                    case "uk-UA":
                        text = "Невідповідність версії БД.";
                        break;
                    case "ru-RU":
                        text = "Несоответствие версии БД.";
                        break;
                }

                return text;
            }
        }
        public static string ErrorText6
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Not enough data.";
                        break;
                    case "uk-UA":
                        text = "Недостатньо даних.";
                        break;
                    case "ru-RU":
                        text = "Недостаточно данных.";
                        break;
                }

                return text;
            }
        }
        public static string ErrorText7
        {
            get
            {
                string text = "";

                switch (Properties.Settings.Default.Language)
                {
                    case "en-US":
                        text = "Axis of the chart area - the chart area contains incompatible chart types.";
                        break;
                    case "uk-UA":
                        text = "Вісі області діаграми - в області діаграми містяться несумісні типи діаграм.";
                        break;
                    case "ru-RU":
                        text = "Оси области диаграммы - в области диаграммы содержатся несовместимые типы диаграмм.";
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
                        text = "Are you sure you want to delete the calculation?";
                        break;
                    case "uk-UA":
                        text = "Ви впевнені, що хочете видалити розрахунок?";
                        break;
                    case "ru-RU":
                        text = "Вы уверены, что хотите удалить расчёт?";
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
                    case "ru-RU":
                        text = "Сохранить измененные данные?";
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
                        text = "Are you sure you want to recalculate the calculation?";
                        break;
                    case "uk-UA":
                        text = "Ви впевнені, що хочете виконати перерахунок розрахунку?";
                        break;
                    case "ru-RU":
                        text = "Вы уверены, что хотите выполнить перерассчёт расчёта?";
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
                    case "ru-RU":
                        text = "Этот файл уже существует. Заменить его?";
                        break;
                }

                return text;
            }
        }
    }
}
