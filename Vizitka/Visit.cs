using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

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

        // instagram://user?username=kim-g
        // Свойства
        public string PersonName { get { return (string)VisitName.Content; } set { VisitName.Content = value; } }
        public string PersonCompany { get { return (string)Company.Content; } set { Company.Content = value; } }
        public string PersonJob { get { return (string)Job.Content; } set { Job.Content = value; } }
        public string PersonEMail { get { return (string)EMail.Content; } set { EMail.Content = value; } }
        public string PersonInstagram
        {
            get { return (string)Instagram.Content; }
            set
            {
                Instagram.Content = value;
                if (value == "") InstaQR.Visibility = System.Windows.Visibility.Collapsed;
                else InstaQR.Source = QRCodeWPF.GetQRCode(@"instagram://user?username=" + value);
            }
        }

        public Visit(Panel Core)
        {
            HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Width = 333.30;
            Height = 183;

            Rectangle Back = new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Green),
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 3
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

            Core.Children.Add(this);
        }

        
    }
}
