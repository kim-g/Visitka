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
            Visit V1 = new Visit(Core)
            {
                PersonName = PName.Text,
                PersonCompany = PCompany.Text,
                PersonJob = PJob.Text,
                PersonEMail = PEMail.Text,
                PersonInstagram = PIntagram.Text
            };
        }
    }
}
