using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vizitka;

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
            WPF_Printer.Print(V1.MultileObject(3, 4));
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
    }
}
