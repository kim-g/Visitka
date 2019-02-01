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
using System.Globalization;

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
        public string PersonCompany { get { return (string)Company.Content; } set
            {
                Company.Content = value;
                Company.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public void StretchCompany()
        {
            double FS = Company.FontSize;
            FS++;
            double Wi;
            do
            {
                FS--;
                TextBlock TB = new TextBlock()
                {
                    FontFamily = Company.FontFamily,
                    FontSize = FS,
                    FontWeight = Company.FontWeight,
                    Text = PersonCompany
                };
                Wi = GetTextSize(TB).Width;
            }
            while (Company.Margin.Left + Wi >= 812);
            Company.FontSize = FS;
        }

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
            get { return ((TextBlock)(Instagram.Content)).Text; }
            set
            {
                TextBlock TB = new TextBlock()
                {
                    Text = value.Replace(' ', '_').ToUpper(),
                    TextWrapping = TextWrapping.Wrap
                };

                Instagram.Content = TB;
                Instagram.Visibility = value == "" ? Visibility.Collapsed : Visibility.Visible;
                InstaQR.Visibility = value == "" ? Visibility.Collapsed : Visibility.Collapsed;
                //if (value != "") InstaQR.Source = QRCodeWPF.GetQRCode(@"instagram://user?username=" + value);
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
                        ChangeLabel(VisitSurname, 360, 117, 52, "Formular", true, 
                            Color.FromRgb(254, 254, 254));

                        ChangeLabel(VisitName, 360, 172, 47, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(VisitSecondName, 359, 217, 47, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Company, 419, 300, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Phone, 419, 344, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(EMail, 419, 386, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Instagram, 95, 208, 26.5, "InstagramNametag", false,
                            Color.FromRgb(235, 91, 98));
                        Instagram.Width = 157;
                        Instagram.FontWeight = FontWeights.Medium;
                        Instagram.HorizontalAlignment = HorizontalAlignment.Left;
                        Instagram.HorizontalContentAlignment = HorizontalAlignment.Center;
                        /*Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(716, 24, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;*/
                        break;

                    case 2:
                        BackGroundImage = ImageBrushFromResources("Vis2.png");
                        ChangeLabel(VisitSurname, 360, 117, 52, "Formular", true,
                            Color.FromRgb(234, 90, 98));

                        ChangeLabel(VisitName, 360, 172, 47, "Formular", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(VisitSecondName, 359, 217, 47, "Formular", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Company, 419, 300, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Phone, 419, 344, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(EMail, 419, 386, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Instagram, 95, 208, 26.5, "InstagramNametag", false,
                            Color.FromRgb(235, 91, 98));
                        Instagram.Width = 157;
                        Instagram.FontWeight = FontWeights.Medium;
                        Instagram.HorizontalAlignment = HorizontalAlignment.Left;
                        Instagram.HorizontalContentAlignment = HorizontalAlignment.Center;
                        
                        /*Instagram.Visibility = Visibility.Collapsed;
                                                InstaQR.Margin = new Thickness(716, 24, 0, 0);
                                                InstaQR.Width = 82;
                                                InstaQR.Height = 82;*/
                        break;

                    case 3:
                        BackGroundImage = ImageBrushFromResources("Vis3.png");
                        ChangeLabel(VisitSurname, 349, 120, 52, "Formular", true,
                            Color.FromRgb(254, 254, 254));

                        ChangeLabel(VisitName, 349, 175, 47, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(VisitSecondName, 349, 220, 47, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Company, 365, 310, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Phone, 365, 344, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(EMail, 365, 379, 30, "Railway", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Instagram, 28, 78, 19.5, "InstagramNametag", false,
                            Color.FromRgb(235, 91, 98));
                        Instagram.Width = 116;
                        Instagram.FontWeight = FontWeights.Medium;
                        Instagram.HorizontalAlignment = HorizontalAlignment.Left;
                        Instagram.HorizontalContentAlignment = HorizontalAlignment.Center;
                        
                        /*Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(717, 25, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;*/
                        break;

                    case 4:
                        BackGroundImage = ImageBrushFromResources("Vis4.png");
                        ChangeLabel(VisitSurname, 349, 120, 52, "Formular", true,
                            Color.FromRgb(234, 90, 98));

                        ChangeLabel(VisitName, 349, 175, 47, "Formular", false,
                            Color.FromRgb(234, 90, 98), 4);

                        ChangeLabel(VisitSecondName, 349, 220, 47, "Formular", false,
                            Color.FromRgb(234, 90, 98), 4);

                        ChangeLabel(Company, 365, 310, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Phone, 365, 344, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(EMail, 365, 379, 30, "Railway", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Instagram, 28, 78, 19.5, "InstagramNametag", false,
                            Color.FromRgb(235, 91, 98));
                        Instagram.Width = 116;
                        Instagram.FontWeight = FontWeights.Medium;
                        Instagram.HorizontalAlignment = HorizontalAlignment.Left;
                        Instagram.HorizontalContentAlignment = HorizontalAlignment.Center;

                        /*Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(717, 25, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;*/
                        break;

                    case 5:
                        BackGroundImage = ImageBrushFromResources("Vis5.png");
                        ChangeLabel(VisitSurname, 348, 104, 44, "Formular", true,
                             Color.FromRgb(235, 91, 98));

                        ChangeLabel(VisitName, 348, 150, 33, "Formular", false,
                            Color.FromRgb(235, 91, 98), 4);

                        ChangeLabel(VisitSecondName, 348, 185, 33, "Formular", false,
                            Color.FromRgb(235, 91, 98), 4);

                        ChangeLabel(Company, 408, 255, 25, "Formular", false,
                            Color.FromRgb(118, 118, 117), 4);

                        ChangeLabel(Phone, 408, 319, 25, "Formular", false,
                            Color.FromRgb(118, 118, 117), 4);

                        ChangeLabel(EMail, 408, 383, 25, "Formular", false,
                            Color.FromRgb(118, 118, 117), 4);

                        ChangeLabel(Instagram, 52, 341, 17.5, "InstagramNametag", false,
                            Color.FromRgb(235, 91, 98));
                        Instagram.Width = 158;
                        Instagram.FontWeight = FontWeights.Medium;
                        Instagram.HorizontalAlignment = HorizontalAlignment.Left;
                        Instagram.HorizontalContentAlignment = HorizontalAlignment.Center;

                        /*Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(39, 331, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;*/
                        break;

                    case 6:
                        BackGroundImage = ImageBrushFromResources("Vis6.png");
                        ChangeLabel(VisitSurname, 348, 104, 44, "Formular", true,
                             Color.FromRgb(254, 254, 254));

                        ChangeLabel(VisitName, 348, 150, 33, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(VisitSecondName, 348, 185, 33, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Company, 408, 253, 25, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Phone, 408, 319, 25, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(EMail, 408, 383, 25, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Instagram, 52, 341, 17.5, "InstagramNametag", false,
                            Color.FromRgb(235, 91, 98));
                        Instagram.Width = 158;
                        Instagram.FontWeight = FontWeights.Medium;
                        Instagram.HorizontalAlignment = HorizontalAlignment.Left;
                        Instagram.HorizontalContentAlignment = HorizontalAlignment.Center;


                        /*Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(39, 331, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;*/
                        break;

                    case 7:
                        BackGroundImage = ImageBrushFromResources("Vis7.png");
                        ChangeLabel(VisitSurname, 28, 123, 50, "Formular", true,
                             Color.FromRgb(235, 91, 98));
                        VisitSurname.HorizontalContentAlignment = HorizontalAlignment.Center;

                        ChangeLabel(VisitName, 28, 186, 39, "Formular", false,
                            Color.FromRgb(235, 91, 98), 4);
                        VisitName.HorizontalContentAlignment = HorizontalAlignment.Center;

                        ChangeLabel(Company, 167, 255, 25, "Formular", false,
                            Color.FromRgb(114, 114, 113), 4);

                        ChangeLabel(Phone, 167, 332, 25, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(EMail, 167, 381, 25, "Formular", false,
                            Color.FromRgb(254, 254, 254), 4);

                        ChangeLabel(Instagram, 675, 383, 19.5, "InstagramNametag", false,
                            Color.FromRgb(235, 91, 98));
                        Instagram.Width = 116;
                        Instagram.FontWeight = FontWeights.Medium;
                        Instagram.HorizontalAlignment = HorizontalAlignment.Left;
                        Instagram.HorizontalContentAlignment = HorizontalAlignment.Center;


                        /*Instagram.Visibility = Visibility.Collapsed;
                        InstaQR.Margin = new Thickness(696, 331, 0, 0);
                        InstaQR.Width = 82;
                        InstaQR.Height = 82;*/
                        break;
                }

                Company.HorizontalAlignment = HorizontalAlignment.Left;
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
            CurLabel.FontFamily = new FontFamily(FontName);
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
            Height = 471;

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
            Company.SizeChanged += (object Sender, SizeChangedEventArgs EA) =>
            {
                StretchCompany();
            };
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

            StretchCompany();
        }

        public Visit Clone()
        {
            Visit V1 = new Visit(this.GlobalStyle)
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
            V1.StretchCompany();
            return V1;
        }

        public static Size GetTextSize(TextBlock textBlock)
        {
            FormattedText ft = new FormattedText(textBlock.Text, CultureInfo.CurrentUICulture, textBlock.FlowDirection,
                                                 new Typeface(textBlock.FontFamily, textBlock.FontStyle,
                                                              textBlock.FontWeight, textBlock.FontStretch),
                                                 textBlock.FontSize, textBlock.Foreground
                );

            return new Size(ft.Width, ft.Height);
        }

        public StackPanel MultileObject(int Width, int Height)
        {
            StackPanel NewPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0) //new Thickness(138,28,138,28)
            };
            StackPanel[] HorisontalPanels = new StackPanel[Height];
            for (int i = 0; i < Height; i++)
            {
                Thickness thickness;
                switch (i)
                {
                    case 0:
                        thickness = new Thickness(0);
                        break;
                    case 1:
                        thickness = new Thickness(0,0,0,0);
                        break;
                    case 2:
                        thickness = new Thickness(0);
                        break;
                    default:
                        thickness = new Thickness(0);
                        break;
                }
                HorisontalPanels[i] = new StackPanel() { Orientation = Orientation.Horizontal, Margin = thickness };
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
