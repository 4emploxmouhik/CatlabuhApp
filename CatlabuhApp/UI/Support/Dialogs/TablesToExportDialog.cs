using CatlabuhAppSupportHelp.UI.Help;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CatlabuhApp.UI.Support.Dialogs
{
    public partial class TablesToExportDialog : Form
    {
        // Составляющие представления расчета. 
        private DataGridView[] dataGridViews;
        private string[] tablesNames;
        private string yearOfCalculation;
        
        // Путь к папке где храняться Excel-файлы расчетов.
        private readonly string path;

        // Прогресс выполнения операции создания и заполнения файла.
        private static int progress = 0;

        // Указывают, а был ли выбран элемент в группе(GroupBox).
        private bool IsWBChecked = false;
        private bool IsSBChecked = false;

        // Список выбранных таблиц.
        private List<Tables> tablesList = new List<Tables>();
        private enum Tables
        {
            WaterBalanceProfit, WaterBalanceConsumable, SaltBalanceProfit, SaltBalanceConsumable, None = -1
        }

        public TablesToExportDialog()
        {
            Main.Forms.MainForm.GetCultureInfo();
            InitializeComponent();

            path = Properties.Settings.Default.CalculationsDirectoryPath;
        }

        public TablesToExportDialog(DataGridView[] dataGridViews, string yearOfCalculation) : this()
        {
            this.dataGridViews = dataGridViews;
            this.yearOfCalculation = yearOfCalculation;

            tablesNames = new string[]
            {
                $"{wbGroup.Text} {wbpCheck.Text}", $"{wbGroup.Text} {wbcCheck.Text}",
                $"{sbGroup.Text} {sbpCheck.Text}", $"{sbGroup.Text} {sbcCheck.Text}",
            };
        }

        #region Обработчики кнопок
        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            try
            {
                back.Enabled = false;
                export.Enabled = false;

                string fileName = GenerateFileName();
                GetChosenTabels(out DataGridView[] chosenGridViews, out string[] chosenTablesNames);

                #region Oпрделим максимум и минимум для progressBar
                int maximumValue = chosenTablesNames.Length;

                for (int i = 0; i < chosenGridViews.Length; i++)
                {
                    maximumValue += chosenGridViews[i].ColumnCount - 5;
                    maximumValue += chosenGridViews[i].RowCount * (chosenGridViews[i].ColumnCount - 5);
                }

                progressBar.Minimum = 0;
                progressBar.Maximum = maximumValue + 1;
                progressBar.Value = 0;

                #endregion

                timer.Start();

                CreateExcelFileAsync(chosenGridViews, chosenTablesNames, fileName);
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\log\\ERRORS", true, Encoding.UTF8))
                {
                    sw.WriteLine($"\n{DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss")}\n{ex.Message}\n{ex.StackTrace}\n\n");
                    sw.Close();
                }
            }
        }

        #endregion
        #region Методы формирования выбранных пользователем элементов
        private string GenerateFileName()
        {
            string fileName = "";

            if (IsWBChecked && IsSBChecked)
            {
                fileName = $"{wbGroup.Text} and {sbGroup.Text} for {yearOfCalculation} year.xlsx"; 
            }
            else if (IsWBChecked)
            {
                fileName = GenerateFileName(ref wbGroup, ref wbpCheck, ref wbcCheck);
            }
            else if (IsSBChecked)
            {
                fileName = GenerateFileName(ref sbGroup, ref sbpCheck, ref sbcCheck);
            }

            return fileName;
        }

        private string GenerateFileName(ref GroupBox group, ref CheckBox c1, ref CheckBox c2)
        {
            string fileName = "";

            if (c1.Checked && c2.Checked)
            {
                fileName = $"{group.Text} for {yearOfCalculation} year.xlsx";
            }
            else if (c1.Checked)
            {
                fileName = $"{group.Text} {c1.Text} for {yearOfCalculation} year.xlsx";
            }
            else if (c2.Checked)
            {
                fileName = $"{group.Text} {c2.Text} for {yearOfCalculation} year.xlsx";
            }

            return fileName;
        }

        private void GetChosenTabels(out DataGridView[] chosenGridViews, out string[] chosenTablesNames)
        {
            List<DataGridView> outputGridViews = new List<DataGridView>();
            List<string> outputTabelsNames = new List<string>();

            for (int i = 0; i < tablesList.Count; i++)
            {
                switch (tablesList[i])
                {
                    case Tables.WaterBalanceProfit:
                        outputGridViews.Add(dataGridViews[0]);
                        outputTabelsNames.Add(tablesNames[0]);
                        break;
                    case Tables.WaterBalanceConsumable:
                        outputGridViews.Add(dataGridViews[1]);
                        outputTabelsNames.Add(tablesNames[1]);
                        break;
                    case Tables.SaltBalanceProfit:
                        outputGridViews.Add(dataGridViews[2]);
                        outputTabelsNames.Add(tablesNames[2]);
                        break;
                    case Tables.SaltBalanceConsumable:
                        outputGridViews.Add(dataGridViews[3]);
                        outputTabelsNames.Add(tablesNames[3]);
                        break;
                }
            }

            chosenGridViews = outputGridViews.ToArray();
            chosenTablesNames = outputTabelsNames.ToArray();
        }

        #endregion

        private void ChoiceTable_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Tables tabel = Tables.None;

            switch (checkBox.Name)
            {
                case "wbpCheck":
                    tabel = Tables.WaterBalanceProfit; 
                    break;
                case "wbcCheck":
                    tabel = Tables.WaterBalanceConsumable;
                    break;
                case "sbpCheck":
                    tabel = Tables.SaltBalanceProfit;
                    break;
                case "sbcCheck":
                    tabel = Tables.SaltBalanceConsumable;
                    break;
            }

            if (checkBox.Checked)
            {
                tablesList.Add(tabel);
            }
            else
            {
                tablesList.Remove(tabel);
            }
        }

        private void ChoiceTable_CheckStateChanged(object sender, EventArgs e)
        {
            if (wbcCheck.Checked || wbpCheck.Checked)
            {
                IsWBChecked = true;
            }
            else
            {
                IsWBChecked = false;
            }

            if (sbcCheck.Checked || sbpCheck.Checked)
            {
                IsSBChecked = true;
            }
            else
            {
                IsSBChecked = false;
            }
        }

        #region Создание Excel файла 
        private void CreateExcelFile(DataGridView[] chosenGridViews, string[] chosenTablesNames, string fileName)
        {
            progress = 0;

            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 0, step = 1; i < chosenTablesNames.Length; i++, step += 20)
            {
                worksheet.Range[worksheet.Cells[step, 1], worksheet.Cells[step, 10]].Merge();
                worksheet.Cells[step, 1] = chosenTablesNames[i] + ", " + yearOfCalculation + " р.";

                progress++;
            }

            for (int i = 0, step = 3; i < chosenGridViews.Length; i++, step += 20)
            {
                for (int j = 1; j < chosenGridViews[i].ColumnCount - 4; j++)
                {
                    if (chosenGridViews[i].Columns[j - 1].HeaderText.Equals("lg(d)") || chosenGridViews[i].Columns[j - 1].HeaderText.Equals("lg(E)"))
                    {
                        worksheet.Cells[step, j] = chosenGridViews[i].Columns[j - 1].HeaderText + "\n" + chosenGridViews[i].Columns[j - 1].HeaderCell.Tag;
                    }
                    else
                    {
                        worksheet.Cells[step, j] = chosenGridViews[i].Columns[j - 1].HeaderText + ",\n" + chosenGridViews[i].Columns[j - 1].HeaderCell.Tag;
                    }

                    worksheet.Cells[step, j].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    worksheet.Cells[step, j].Borders.Color = System.Drawing.Color.Black;
                    worksheet.Cells[step, j].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    progress++;
                }

                for (int j = 0; j < chosenGridViews[i].RowCount; j++)
                {
                    for (int k = 0; k < chosenGridViews[i].ColumnCount - 5; k++)
                    {
                        worksheet.Cells[j + step + 1, k + 1] = chosenGridViews[i].Rows[j].Cells[k].Value;
                        worksheet.Cells[j + step + 1, k + 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        worksheet.Cells[j + step + 1, k + 1].Borders.Color = System.Drawing.Color.Black;
                        worksheet.Cells[j + step + 1, k + 1].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        progress++;
                    }
                }
            }

            if (File.Exists(path + fileName))
            {
                MessageDialog md = new MessageDialog(MessageDialog.QuestionTitle, MessageDialog.QuestionText4, MessageDialog.Icon.Question);

                if (md.DialogResult == DialogResult.Yes)
                {
                SaveFile:
                    try
                    {
                        File.Delete(path + fileName);
                        workbook.SaveAs(path + fileName);
                    }
                    catch (IOException)
                    {
                        md = new MessageDialog(MessageDialog.AlertTitle1, MessageDialog.AlertText5, MessageDialog.Icon.Alert);

                        if (md.DialogResult == DialogResult.OK)
                        {
                            goto SaveFile;
                        }
                    }
                }
            }
            else
            {
                workbook.SaveAs(path + fileName);
            }

            progress++;

            app.AlertBeforeOverwriting = false;
            app.Visible = true;
        }

        private async Task CreateExcelFileAsync(DataGridView[] chosenGridViews, string[] chosenTablesNames, string fileName)
        {
            await Task.Run(() => CreateExcelFile(chosenGridViews, chosenTablesNames, fileName));
            
            MessageDialog.Show(MessageDialog.SuccessTitle, MessageDialog.SuccessText5, MessageDialog.Icon.OK); 
        }
        
        #endregion

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value != progressBar.Maximum)
            {
                progressBar.Value = progress;
                progressBar.Update();
            }
            else
            {
                timer.Stop();

                progress = 0;
                progressBar.Value = progress;
                progressBar.Update();

                back.Enabled = true;
                export.Enabled = true;
            }
        }

        #region Вызов справки
        private void TablesToExportDialog_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            new HelpForm("exportCalcText").Show();
        }

        #endregion

    
    }
}