using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using Vizitka;
using Excel = Microsoft.Office.Interop.Excel;
using SWF = Microsoft.Win32;

namespace List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> VisitList;
        VisitDB DB;

        public MainWindow()
        {
            InitializeComponent();
            DB = new VisitDB("History.db");
            VisitList = DB.GetVisitsList();

            foreach (string V in VisitList)
            {
                VisitsListBox.Items.Add(V);
            }
        }

        private void VisitsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PrintSelected();
        }

        private void PrintSelected()
        {
            if (VisitsListBox.SelectedIndex == -1) return;

            if (MessageBox.Show("Напечатать визитку?", "Подтверждение печати", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            string[] NumStr = VisitsListBox.SelectedValue.ToString().Split('-');
            Visit V1 = DB.GetVisit(Convert.ToInt32(NumStr[0].Trim()));
            WPF_Printer.Print(V1.MultileObject(2, 5));
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintSelected();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Закрыть список визиток?", "Закрытие", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SWF.SaveFileDialog saveDialog = new SWF.SaveFileDialog();
            saveDialog.AddExtension = true;
            saveDialog.Filter = "(*.xlsx)|*.xlsx";

            if (saveDialog.ShowDialog() == false)
                return;

            //Объявляем приложение
            Excel.Application ex = new Excel.Application();
            //Количество листов в рабочей книге
            ex.SheetsInNewWorkbook = 1;
            //Добавить рабочую книгу
            Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
            //Отключить отображение окон с сообщениями
            ex.DisplayAlerts = false;
            //Получаем первый лист документа (счет начинается с 1)
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            //Название листа (вкладки снизу)
            sheet.Name = "Список визиток";
            //Пример заполнения ячеек
            sheet.Cells[1, 1] = $"Номер";
            sheet.Cells[1, 2] = $"Тип визитки";
            sheet.Cells[1, 3] = $"Фамилия";
            sheet.Cells[1, 4] = $"Имя";
            sheet.Cells[1, 5] = $"Отчество";
            sheet.Cells[1, 6] = $"Компания";
            sheet.Cells[1, 7] = $"Должность";
            sheet.Cells[1, 8] = $"Телефон";
            sheet.Cells[1, 9] = $"Почта";
            sheet.Cells[1, 10] = $"Instagram";

            DataTable DT = DB.ReadTable("SELECT `id`, `type`, `surname`, `name`, `second_name`, "+
"`company`, `job`, `phone`, `email`, `instagram` FROM `Visits`;");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                for (int j=0; j<10; j++)
                sheet.Cells[i+2, j+1] = DT.Rows[i].ItemArray[j];
            }

            ex.Application.ActiveWorkbook.SaveAs(saveDialog.FileName, Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlShared,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
    }
}
