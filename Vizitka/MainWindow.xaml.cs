using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QRCoder;

namespace Vizitka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Keyboard VirtualKeyboard;
        byte NVis = 0;
        string[] PersonName = new string[3];
        string Company;
        string Job;
        string Phone;
        string EMail;
        string Instagram;

        public MainWindow()
        {
            InitializeComponent();
            

            VirtualKeyboard = new Keyboard(Core)
            {
                Lang = Languages.Rus,
                Width = 500,
                Height = 300,
                Visibility = Visibility.Collapsed
            };
            Grid.SetRow(VirtualKeyboard, 0);
        }

        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TestBox_GotFocus(object sender, RoutedEventArgs e)
        {
            VirtualKeyboard.Show((TextBox)sender);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Visit V1 = new Visit(1)
            {
                PersonName = PName.Text,
                PersonCompany = PCompany.Text,
                PersonJob = PJob.Text,
                PersonEMail = PEMail.Text,
                PersonInstagram = PIntagram.Text,
                BackGroundImage = new SolidColorBrush(Colors.Aqua)
            };



            WPF_Printer.Print(V1.MultileObject(2, 10));
            GC.Collect();
        }

        private void Slide1_Start_Click(object sender, RoutedEventArgs e)
        {
            Slide1.Visibility = Visibility.Collapsed;
            Slide2.Visibility = Visibility.Visible;
        }

        private void Visit_Button_Click(object sender, RoutedEventArgs e)
        {
            NVis = Convert.ToByte(((FrameworkElement)sender).Tag);
            Slide2.Visibility = Visibility.Collapsed;
            Slide3.Visibility = Visibility.Visible;
        }

        private void Slide3_Start_Click(object sender, RoutedEventArgs e)
        {
            string[] Names = PName.Text.Trim().Split(' ');
            switch (Names.Count())
            {
                case 1: PersonName[0] = PName.Text; break;
                case 2:
                    PersonName[0] = Names[0];
                    PersonName[1] = Names[1];
                    break;
                case 3:
                    PersonName[0] = Names[0];
                    PersonName[1] = Names[1];
                    PersonName[2] = Names[2];
                    break;
                default:
                    PersonName[0] = "";
                    int i;
                    for (i = 0; i < Names.Count() - 2; i++)
                        PersonName[0] += Names[i] + " ";
                    PersonName[1] = Names[i++];
                    PersonName[2] = Names[i];
                    break;
            }

            Company = PCompany.Text;
            Job = PJob.Text;
            Phone = PPhone.Text;
            EMail = PEMail.Text;
            Instagram = PIntagram.Text;

            VirtualKeyboard.Visibility = Visibility.Collapsed;
            Slide3.Visibility = Visibility.Collapsed;
            Slide4.Visibility = Visibility.Visible;
            Visit V1 = new Visit(5)
            {
                PersonSurname = "ФАМИЛИЯ",
                PersonName = "Имя",
                PersonSecondName = "Отчество",
                PersonCompany = "компания, должность",
                PersonPhone = "телефон",
                PersonEMail = "почта", 
                PersonInstagram = "kim-g"
            };
            Slide4.Children.Add(V1);
        }
    }
}
