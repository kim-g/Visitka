using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Vizitka
{
    public class Visit : Grid
    {
        private Label VisitName;
        private Label Company;
        private Label Job;
        private Label EMail;
        private Label Instagram;
        private Image InstaQR;
        Rectangle Back;

        // Свойства
        /// <summary>
        /// ФИО на визитке
        /// </summary>
        public string PersonName { get { return (string)VisitName.Content; } set { VisitName.Content = value; } }
        /// <summary>
        /// Компания
        /// </summary>
        public string PersonCompany { get { return (string)Company.Content; } set { Company.Content = value; Company.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible; } }
        /// <summary>
        /// Должность / Профессия
        /// </summary>
        public string PersonJob { get { return (string)Job.Content; } set { Job.Content = value; Job.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible; } }
        /// <summary>
        /// Электронный адрес
        /// </summary>
        public string PersonEMail { get { return (string)EMail.Content; } set { EMail.Content = value; EMail.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible; } }
        /// <summary>
        /// Логин в Instagram
        /// </summary>
        public string PersonInstagram
        {
            get { return (string)Instagram.Content; }
            set
            {
                Instagram.Content = value;
                Instagram.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible;
                InstaQR.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible;
                if (value != "") InstaQR.Source = QRCodeWPF.GetQRCode(@"instagram://user?username=" + value);
            }
        }
        /// <summary>
        /// Фон визитки
        /// </summary>
        public Brush BackGroundImage
        {
            get { return Back.Fill; }
            set { Back.Fill = value; }
        }

        /// <summary>
        /// Создание новой визитки
        /// </summary>
        public Visit()
        {
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Width = 333.30;
            Height = 183;

            Back = new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Green),
                Stroke = null
            };
            Children.Add(Back);

            StackPanel HorStack = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            Children.Add(HorStack);

            StackPanel VertStack = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };
            HorStack.Children.Add(VertStack);

            VisitName = new Label();
            VertStack.Children.Add(VisitName);

            Company = new Label();
            VertStack.Children.Add(Company);

            Job = new Label();
            VertStack.Children.Add(Job);

            EMail = new Label();
            VertStack.Children.Add(EMail);

            Instagram = new Label();
            VertStack.Children.Add(Instagram);

            InstaQR = new Image();
            HorStack.Children.Add(InstaQR);
        }

        public Visit Clone()
        {
            return new Visit()
            {
                PersonName = this.PersonName,
                PersonCompany = this.PersonCompany,
                PersonJob = this.PersonJob,
                PersonEMail = this.PersonEMail,
                PersonInstagram = this.PersonInstagram
            };
        }

        public StackPanel MultileObject(int Width, int Height)
        {
            StackPanel NewPanel = new StackPanel() { Orientation = Orientation.Vertical };
            StackPanel[] HorisontalPanels = new StackPanel[Height];
            for (int i = 0; i < Height; i++)
            {
                HorisontalPanels[i] = new StackPanel() { Orientation = Orientation.Horizontal };
                for (int j = 0; j < Width; j++)
                {
                    FrameworkElement NewElement = Clone();
                    HorisontalPanels[i].Children.Add(NewElement);
                }
                NewPanel.Children.Add(HorisontalPanels[i]);
            }
            return NewPanel;
        }
    }
}
