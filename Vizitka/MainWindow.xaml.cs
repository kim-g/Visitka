using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

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
        Visit VisitkaPreview;
        VisitDB History;

        public MainWindow()
        {
            InitializeComponent();


            VirtualKeyboard = new Keyboard(Core)
            {
                Lang = Languages.Rus,
                Width = 500,
                Height = 300,
                Visibility = Visibility.Collapsed,
                FontSize = 20,
                Background = new ImageBrush(new BitmapImage(new Uri($"pack://application:,,,/VK.png", UriKind.Absolute))
                { CreateOptions = BitmapCreateOptions.IgnoreImageCache })
            };

            Grid.SetRow(VirtualKeyboard, 0);
            VisitkaPreview = new Visit();
            Slide4.Children.Add(VisitkaPreview);
            History = new VisitDB("History.db");
        }

        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Полечение фокуса строкой ввода - открываем виртуальную клавиатуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestBox_GotFocus(object sender, RoutedEventArgs e)
        {
            VirtualKeyboard.Show((TextBox)sender);
        }

        /// <summary>
        /// СТАРОЕ!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Пользователь начал работу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slide1_Start_Click(object sender, RoutedEventArgs e)
        {
            Slide1.Visibility = Visibility.Collapsed;
            Slide2.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Пользователь выбрал тип визитки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Visit_Button_Click(object sender, RoutedEventArgs e)
        {
            NVis = Convert.ToByte(((FrameworkElement)sender).Tag);
            Slide2.Visibility = Visibility.Collapsed;
            Slide3.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Пользователь ввёл данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


            Company = PCompany.Text.Trim();
            Job = PJob.Text.Trim();
            Phone = PPhone.Text.Trim();
            EMail = PEMail.Text.Trim();
            Instagram = PIntagram.Text.Trim();

            VisitkaPreview.GlobalStyle = NVis;
            VisitkaPreview.PersonSurname = PersonName[0];
            VisitkaPreview.PersonName = PersonName[1];
            VisitkaPreview.PersonSecondName = PersonName[2];
            VisitkaPreview.PersonCompany = Company!="" && Job!="" 
                ? Company + ", " + Job
                : Company + Job;
            VisitkaPreview.StretchCompany();
            VisitkaPreview.PersonPhone = Phone;
            VisitkaPreview.PersonEMail = EMail;
            VisitkaPreview.PersonInstagram = Instagram;           
            VisitkaPreview.Margin = new Thickness(130, 765, 0, 0);

            VirtualKeyboard.Visibility = Visibility.Collapsed;
            Slide3.Visibility = Visibility.Collapsed;
            Slide4.Visibility = Visibility.Visible;
            VisitkaPreview.StretchCompany();
        }

        /// <summary>
        /// Пользователь решил отредактировать данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slide4_Edit_Click(object sender, RoutedEventArgs e)
        {
            Slide3.Visibility = Visibility.Visible;
            Slide4.Visibility = Visibility.Collapsed;

            PName.Text = $"{PersonName[0]} {PersonName[1]} {PersonName[2]}";
            PCompany.Text = Company;
            PJob.Text = Job;
            PPhone.Text = Phone;
            PEMail.Text = EMail;
            PIntagram.Text = Instagram;
        }

        /// <summary>
        /// Распечатать визитки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slide4_OK_Click(object sender, RoutedEventArgs e)
        {
            Slide4.Visibility = Visibility.Collapsed;
            Slide5.Visibility = Visibility.Visible;
            WPF_Printer.Print(VisitkaPreview.MultileObject(2, 5));
            History.Add(new VisitInfo()
            {
                Surname = this.PersonName[0],
                Name = this.PersonName[1],
                SecondName = this.PersonName[2],
                Company = this.Company,
                Job = this.Job,
                Phone = this.Phone, 
                Email = this.EMail, 
                Instagram = this.Instagram,
                VisitType = NVis
            });
            GC.Collect();
            DispatcherTimer DT = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(5),
            };
            DT.Tick += (object Sender, EventArgs ee) => 
            {
                ((DispatcherTimer)Sender).Stop();
                Slide5_OK_Click(Sender, new RoutedEventArgs());
            };
            DT.Start();
        }

        /// <summary>
        /// Сбросить всё и вернуться на первый слайд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slide5_OK_Click(object sender, RoutedEventArgs e)
        {
            Slide2.Visibility = Visibility.Collapsed;
            Slide3.Visibility = Visibility.Collapsed;
            Slide4.Visibility = Visibility.Collapsed;
            Slide5.Visibility = Visibility.Collapsed;
            VirtualKeyboard.Visibility = Visibility.Collapsed;
            PersonName[0] = "";
            PersonName[1] = "";
            PersonName[2] = "";
            Company = "";
            Job = "";
            Phone = "";
            EMail = "";
            Instagram = "";
            PName.Text = "";
            PCompany.Text = "";
            PJob.Text = "";
            PPhone.Text = "";
            PEMail.Text = "";
            PIntagram.Text = "";
            Slide1.Visibility = Visibility.Visible;
        }

        private void ListShow_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("List.exe");
        }
    }
}
