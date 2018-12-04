using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Vizitka
{
    public class Visit : Grid
    {
        private Label VisitSurname;
        private Label VisitName;
        private Label VisitSecondName;
        private Label Company;
        private Label Job;
        private Label Phone;
        private Label EMail;
        private Label Instagram;
        private Image InstaQR;
        Rectangle Back;
        private byte VisitStyle = 1;

        // Свойства
        /// <summary>
        /// Фамилия на визитке
        /// </summary>
        public string PersonSurname { get { return (string)VisitSurname.Content; } set { VisitSurname.Content = value.ToUpper(); } }
        /// <summary>
        /// Имя на визитке
        /// </summary>
        public string PersonName { get { return (string)VisitName.Content; } set { VisitName.Content = value; } }
        /// <summary>
        /// Отчество на визитке
        /// </summary>
        public string PersonSecondName { get { return (string)VisitSecondName.Content; } set
            {
                if (GlobalStyle == 7)
                {
                    PersonName += " " + value;
                    VisitSecondName.Content = "";
                }
                else VisitSecondName.Content = value;
            } }
        /// <summary>
        /// Компания
        /// </summary>
        public string PersonCompany { get { return (string)Company.Content; } set { Company.Content = value; Company.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible; } }
        /// <summary>
        /// Должность / Профессия
        /// </summary>
        public string PersonJob { get { return (string)Job.Content; } set { Job.Content = value; Job.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible; } }
        /// <summary>
        /// Должность / Профессия
        /// </summary>
        public string PersonPhone { get { return (string)Phone.Content; } set { Phone.Content = value; Phone.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible; } }
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
                Instagram.Visibility = value == "" ? Visibility.Collapsed : Visibility.Collapsed;
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
        /// Один из предопределённых слилей визитки
        /// </summary>
        public byte GlobalStyle
        {
            get
            {
                return VisitStyle;
            }
            set
            {
                byte OldStyle = VisitStyle;
                VisitStyle = value;
                switch (VisitStyle)
                {
                    case 1:
                        BackGroundImage = ImageBrushFromResources("Vis1.png");
                        ChangeLabel(VisitSurname, 361, 110, 52, "Formular", true, 
                            Color.FromRgb(254, 254, 254));

                        ChangeLabel(VisitName, 361, 165, 47, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(VisitSecondName, 361, 210, 47, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Company, 420, 290, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Phone, 420, 335, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(EMail, 420, 375, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(716, 24, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;
                        break;

                    case 2:
                        BackGroundImage = ImageBrushFromResources("Vis2.png");
                        ChangeLabel(VisitSurname, 361, 110, 52, "Formular", true,
                            Color.FromRgb(234, 90, 98));

                        ChangeLabel(VisitName, 361, 165, 47, "Formular", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(VisitSecondName, 361, 210, 47, "Formular", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Company, 420, 290, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Phone, 420, 335, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(EMail, 420, 375, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(716, 24, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;
                        break;

                    case 3:
                        BackGroundImage = ImageBrushFromResources("Vis3.png");
                        ChangeLabel(VisitSurname, 352, 114, 52, "Formular", true,
                            Color.FromRgb(254, 254, 254));

                        ChangeLabel(VisitName, 352, 169, 47, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(VisitSecondName, 352, 214, 47, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Company, 368, 302, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Phone, 368, 336, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(EMail, 368, 369, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(717, 25, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;
                        break;

                    case 4:
                        BackGroundImage = ImageBrushFromResources("Vis4.png");
                        ChangeLabel(VisitSurname, 352, 114, 52, "Formular", true,
                            Color.FromRgb(234, 90, 98));

                        ChangeLabel(VisitName, 352, 169, 47, "Formular", false,
                            Color.FromRgb(234, 90, 98), 4);

                        ChangeLabel(VisitSecondName, 352, 214, 47, "Formular", false,
                            Color.FromRgb(234, 90, 98), 4);

                        ChangeLabel(Company, 368, 302, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Phone, 368, 336, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(EMail, 368, 369, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(717, 25, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;
                        break;

                    case 5:
                        BackGroundImage = ImageBrushFromResources("Vis5.png");
                        ChangeLabel(VisitSurname, 348, 97, 44, "Formular", true,
                             Color.FromRgb(235, 91, 98));

                        ChangeLabel(VisitName, 348, 143, 33, "Formular", false,
                            Color.FromRgb(235, 91, 98), 4);

                        ChangeLabel(VisitSecondName, 348, 178, 33, "Formular", false,
                            Color.FromRgb(235, 91, 98), 4);

                        ChangeLabel(Company, 408, 247, 25, "Railway", false,
                            Color.FromRgb(118, 118, 117), 4);

                        ChangeLabel(Phone, 408, 311, 25, "Railway", false,
                            Color.FromRgb(118, 118, 117), 4);

                        ChangeLabel(EMail, 408, 375, 25, "Railway", false,
                            Color.FromRgb(118, 118, 117), 4);

                        Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(39, 331, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;
                        break;

                    case 6:
                        BackGroundImage = ImageBrushFromResources("Vis6.png");
                        ChangeLabel(VisitSurname, 348, 97, 44, "Formular", true,
                             Color.FromRgb(254, 254, 254));

                        ChangeLabel(VisitName, 348, 143, 33, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(VisitSecondName, 348, 178, 33, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Company, 408, 247, 25, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Phone, 408, 311, 25, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(EMail, 408, 375, 25, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(39, 331, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;
                        break;

                    case 7:
                        BackGroundImage = ImageBrushFromResources("Vis7.png");
                        ChangeLabel(VisitSurname, 30, 115, 50, "Formular", true,
                             Color.FromRgb(235, 91, 98));
                        VisitSurname.HorizontalContentAlignment = HorizontalAlignment.Center;

                        ChangeLabel(VisitName, 30, 178, 39, "Formular", false,
                            Color.FromRgb(235, 91, 98), 4);
                        VisitName.HorizontalContentAlignment = HorizontalAlignment.Center;

                        ChangeLabel(Company, 169, 247, 25, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Phone, 169, 324, 25, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(EMail, 169, 373, 25, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(696, 331, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;
                        break;
                }
            }
        }

        private Brush ImageBrushFromResources(string ResName)
        {
            return new ImageBrush(new BitmapImage(new Uri($"pack://application:,,,/{ResName}", UriKind.Absolute))
            { CreateOptions = BitmapCreateOptions.IgnoreImageCache });
        }

        private void ChangeLabel(Label CurLabel, double left, double top, 
            double size, string FontName, bool Bold, Color TextColor, 
            int stretch=5)
        {
            CurLabel.Margin = new Thickness(left, top, 0, 0);
            CurLabel.FontSize = size;
            CurLabel.FontFamily = new FontFamily("Formular");
            CurLabel.FontWeight = Bold ? FontWeights.Bold : FontWeights.Regular;
            CurLabel.Foreground = new SolidColorBrush(TextColor);
            CurLabel.FontStretch = FontStretch.FromOpenTypeStretch(stretch);
        }

        /// <summary>
        /// Создание новой визитки
        /// </summary>
        public Visit(byte VisitStyle = 1)
        {
            HorizontalAlignment = HorizontalAlignment.Left;
            VerticalAlignment = VerticalAlignment.Top;
            Width = 822;
            Height = 457;

            Back = new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Green),
                Stroke = null
            };
            Children.Add(Back);

            VisitSurname = new Label();
            Children.Add(VisitSurname);

            VisitName = new Label();
            Children.Add(VisitName);

            VisitSecondName = new Label();
            Children.Add(VisitSecondName);

            Company = new Label();
            Children.Add(Company);

            Job = new Label();
            Children.Add(Job);

            Phone = new Label();
            Children.Add(Phone);

            EMail = new Label();
            Children.Add(EMail);

            Instagram = new Label();
            Children.Add(Instagram);

            InstaQR = new Image()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Children.Add(InstaQR);

            GlobalStyle = VisitStyle;
        }

        public Visit Clone()
        {
            return new Visit(this.GlobalStyle)
            {
                PersonSurname = this.PersonSurname,
                PersonName = this.PersonName,
                PersonSecondName = this.PersonSecondName,
                PersonCompany = this.PersonCompany,
                PersonJob = this.PersonJob,
                PersonPhone = this.PersonPhone,
                PersonEMail = this.PersonEMail,
                PersonInstagram = this.PersonInstagram
            };
        }

        public StackPanel MultileObject(int Width, int Height)
        {
            StackPanel NewPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(60,0,0,0)
            };
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
