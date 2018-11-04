using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Vizitka
{
    public enum Languages {Rus, Eng};

    public class Keyboard : Grid
    {
        private Grid Rus;
        private Grid Eng;
        private Grid NumEng;
        private Grid NumRus;
        private Grid Bottom;
        private double _FontSize = 14;
        private Languages _Language = Languages.Rus;
        private bool Shift = false;
        private TextBox _InTextBox;

        private KeyButton[] NumEngKeys = new KeyButton[12];
        private KeyButton[] NumRusKeys = new KeyButton[12];
        private Grid[] RusGrid = new Grid[3];
        private KeyButton[][] RusKeys = new KeyButton[3][];
        private Grid[] EngGrid = new Grid[3];
        private KeyButton[][] EngKeys = new KeyButton[3][];
        private KeyButton[] BottomKeys = new KeyButton[5];

        //свойства
        /// <summary>
        /// Размер шрифта кнопок
        /// </summary>
        public double FontSize
        {
            get { return _FontSize; }
            set
            {
                _FontSize = value;
                foreach (KeyButton KB in NumEngKeys)
                    KB.FontSize = _FontSize;
                foreach (KeyButton KB in NumRusKeys)
                    KB.FontSize = _FontSize;
                foreach (KeyButton[] KBA in RusKeys)
                    foreach (KeyButton KB in KBA)
                        KB.FontSize = _FontSize;
                foreach (KeyButton[] KBA in EngKeys)
                    foreach (KeyButton KB in KBA)
                        KB.FontSize = _FontSize;
                foreach (KeyButton KB in BottomKeys)
                    KB.FontSize = _FontSize;
            }
        }

        /// <summary>
        /// Язык кнопок
        /// </summary>
        public Languages Lang
        {
            get { return _Language; }
            set
            {
                _Language = value;
                switch (_Language)
                {
                    case Languages.Rus:
                        Rus.Visibility = Visibility.Visible;
                        Eng.Visibility = Visibility.Collapsed;
                        NumRus.Visibility = Visibility.Visible;
                        NumEng.Visibility = Visibility.Collapsed;
                        break;
                    case Languages.Eng:
                        Rus.Visibility = Visibility.Collapsed;
                        Eng.Visibility = Visibility.Visible;
                        NumRus.Visibility = Visibility.Collapsed;
                        NumEng.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        /// <summary>
        /// Элемент, в который вносятся изменения
        /// </summary>
        public TextBox InTextBox
        {
            get { return _InTextBox; }
            set { _InTextBox = value; }
        }

        public Keyboard(Panel Core)
        {
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3, GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            Rus = new Grid();
            Eng = new Grid();
            NumEng = new Grid();
            NumRus = new Grid();
            Bottom = new Grid();
            SetRow(NumEng, 0);
            SetRow(NumRus, 0);
            SetRow(Rus, 1);
            SetRow(Eng, 1);
            SetRow(Bottom, 2);

            for (int i = 0; i<NumEngKeys.Count(); i++)
            {
                NumEng.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                NumEngKeys[i] = new KeyButton();
                SetColumn(NumEngKeys[i], i);
                NumEng.Children.Add(NumEngKeys[i]);
            }
            NumEngKeys[0].SetLetters("1", "!");
            NumEngKeys[1].SetLetters("2", "@");
            NumEngKeys[2].SetLetters("3", "#");
            NumEngKeys[3].SetLetters("4", "$");
            NumEngKeys[4].SetLetters("5", "%");
            NumEngKeys[5].SetLetters("6", "^");
            NumEngKeys[6].SetLetters("7", "&");
            NumEngKeys[7].SetLetters("8", "*");
            NumEngKeys[8].SetLetters("9", "(");
            NumEngKeys[9].SetLetters("0", ")");
            NumEngKeys[10].SetLetters("-", "_");
            NumEngKeys[11].SetLetters("=", "+");

            for (int i = 0; i < NumRusKeys.Count(); i++)
            {
                NumRus.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                NumRusKeys[i] = new KeyButton();
                SetColumn(NumRusKeys[i], i);
                NumRus.Children.Add(NumRusKeys[i]);
            }
            NumRusKeys[0].SetLetters("1", "!");
            NumRusKeys[1].SetLetters("2", "\"");
            NumRusKeys[2].SetLetters("3", "№");
            NumRusKeys[3].SetLetters("4", ";");
            NumRusKeys[4].SetLetters("5", "%");
            NumRusKeys[5].SetLetters("6", ":");
            NumRusKeys[6].SetLetters("7", "?");
            NumRusKeys[7].SetLetters("8", "*");
            NumRusKeys[8].SetLetters("9", "(");
            NumRusKeys[9].SetLetters("0", ")");
            NumRusKeys[10].SetLetters("-", "_");
            NumRusKeys[11].SetLetters("=", "+");

            RusKeys[0] = new KeyButton[12];
            RusKeys[1] = new KeyButton[11];
            RusKeys[2] = new KeyButton[10];
            for (int i = 0; i < RusGrid.Count(); i++)
            {
                Rus.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                RusGrid[i] = new Grid();
                SetRow(RusGrid[i], i);
                Rus.Children.Add(RusGrid[i]);

                for (int j = 0; j < RusKeys[i].Count(); j++)
                {
                    RusGrid[i].ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    RusKeys[i][j] = new KeyButton();
                    SetColumn(RusKeys[i][j], j);
                    RusGrid[i].Children.Add(RusKeys[i][j]);
                }
            }
            RusKeys[0][0].SetLetters("й", "Й");
            RusKeys[0][1].SetLetters("ц", "Ц");
            RusKeys[0][2].SetLetters("у", "У");
            RusKeys[0][3].SetLetters("к", "К");
            RusKeys[0][4].SetLetters("е", "Е");
            RusKeys[0][5].SetLetters("н", "Н");
            RusKeys[0][6].SetLetters("г", "Г");
            RusKeys[0][7].SetLetters("ш", "Ш");
            RusKeys[0][8].SetLetters("щ", "Щ");
            RusKeys[0][9].SetLetters("з", "З");
            RusKeys[0][10].SetLetters("х", "Х");
            RusKeys[0][11].SetLetters("ъ", "Ъ");
            RusKeys[1][0].SetLetters("ф", "Ф");
            RusKeys[1][1].SetLetters("ы", "Ы");
            RusKeys[1][2].SetLetters("в", "В");
            RusKeys[1][3].SetLetters("а", "А");
            RusKeys[1][4].SetLetters("п", "П");
            RusKeys[1][5].SetLetters("р", "Р");
            RusKeys[1][6].SetLetters("о", "О");
            RusKeys[1][7].SetLetters("л", "Л");
            RusKeys[1][8].SetLetters("д", "Д");
            RusKeys[1][9].SetLetters("ж", "Ж");
            RusKeys[1][10].SetLetters("э", "Э");
            RusKeys[2][0].SetLetters("я", "Я");
            RusKeys[2][1].SetLetters("ч", "Ч");
            RusKeys[2][2].SetLetters("с", "С");
            RusKeys[2][3].SetLetters("м", "М");
            RusKeys[2][4].SetLetters("и", "И");
            RusKeys[2][5].SetLetters("т", "Т");
            RusKeys[2][6].SetLetters("ь", "Ь");
            RusKeys[2][7].SetLetters("б", "Б");
            RusKeys[2][8].SetLetters("ю", "Ю");
            RusKeys[2][9].SetLetters(".", ",");

            EngKeys[0] = new KeyButton[12];
            EngKeys[1] = new KeyButton[11];
            EngKeys[2] = new KeyButton[10];
            for (int i = 0; i < EngGrid.Count(); i++)
            {
                Eng.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                EngGrid[i] = new Grid();
                SetRow(EngGrid[i], i);
                Eng.Children.Add(EngGrid[i]);

                for (int j = 0; j < EngKeys[i].Count(); j++)
                {
                    EngGrid[i].ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                    EngKeys[i][j] = new KeyButton();
                    SetColumn(EngKeys[i][j], j);
                    EngGrid[i].Children.Add(EngKeys[i][j]);
                }
            }
            EngKeys[0][0].SetLetters("q", "Q");
            EngKeys[0][1].SetLetters("w", "W");
            EngKeys[0][2].SetLetters("e", "E");
            EngKeys[0][3].SetLetters("r", "R");
            EngKeys[0][4].SetLetters("t", "T");
            EngKeys[0][5].SetLetters("y", "Y");
            EngKeys[0][6].SetLetters("u", "U");
            EngKeys[0][7].SetLetters("i", "I");
            EngKeys[0][8].SetLetters("o", "O");
            EngKeys[0][9].SetLetters("p", "P");
            EngKeys[0][10].SetLetters("[", "{");
            EngKeys[0][11].SetLetters("]", "}");
            EngKeys[1][0].SetLetters("a", "A");
            EngKeys[1][1].SetLetters("s", "S");
            EngKeys[1][2].SetLetters("d", "D");
            EngKeys[1][3].SetLetters("f", "F");
            EngKeys[1][4].SetLetters("g", "G");
            EngKeys[1][5].SetLetters("h", "H");
            EngKeys[1][6].SetLetters("j", "J");
            EngKeys[1][7].SetLetters("k", "K");
            EngKeys[1][8].SetLetters("l", "L");
            EngKeys[1][9].SetLetters(";", ":");
            EngKeys[1][10].SetLetters("'", "\"");
            EngKeys[2][0].SetLetters("z", "Z");
            EngKeys[2][1].SetLetters("x", "X");
            EngKeys[2][2].SetLetters("c", "C");
            EngKeys[2][3].SetLetters("v", "V");
            EngKeys[2][4].SetLetters("b", "B");
            EngKeys[2][5].SetLetters("n", "N");
            EngKeys[2][6].SetLetters("m", "M");
            EngKeys[2][7].SetLetters(",", "<");
            EngKeys[2][8].SetLetters(".", ">");
            EngKeys[2][9].SetLetters("/", "?");

            for (int i = 0; i < BottomKeys.Count(); i++)
            {
                Bottom.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(i==2 ? 4 : 1, GridUnitType.Star) });
                BottomKeys[i] = new KeyButton();
                SetColumn(BottomKeys[i], i);
                Bottom.Children.Add(BottomKeys[i]);
            }
            BottomKeys[0].SetLetters("Shift", "Shift");
            BottomKeys[1].SetLetters("Backspace", "Backspace");
            BottomKeys[2].SetLetters(" ", " ");
            
            BottomKeys[3].SetLetters("En/Ru", (char)24 + "En/Ru");
            BottomKeys[4].SetLetters("OK", "OK");

            foreach (KeyButton KB in NumEngKeys)
                KB.Click += KeyButton_Click;
            foreach (KeyButton KB in NumRusKeys)
                KB.Click += KeyButton_Click;
            foreach (KeyButton[] KBA in RusKeys)
                foreach (KeyButton KB in KBA)
                    KB.Click += KeyButton_Click;
            foreach (KeyButton[] KBA in EngKeys)
                foreach (KeyButton KB in KBA)
                    KB.Click += KeyButton_Click;
            foreach (KeyButton KB in BottomKeys)
                KB.Click += KeyButton_Click;


            Children.Add(NumEng);
            Children.Add(NumRus);
            Children.Add(Rus);
            Children.Add(Eng); 
            Children.Add(Bottom);
            Core.Children.Add(this);
            FontSize = 16;
        }

        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {
            string Out = ((KeyButton)sender).Letter;
            switch (Out)
            {
                case "Shift":
                    Shift = !Shift;
                    foreach (KeyButton KB in NumEngKeys)
                        KB.SetShift(Shift);
                    foreach (KeyButton KB in NumRusKeys)
                        KB.SetShift(Shift);
                    foreach (KeyButton[] KBA in RusKeys)
                        foreach (KeyButton KB in KBA)
                            KB.SetShift(Shift);
                    foreach (KeyButton[] KBA in EngKeys)
                        foreach (KeyButton KB in KBA)
                            KB.SetShift(Shift);
                    break;
                case "En/Ru":
                    Lang = Lang == Languages.Eng ? Languages.Rus : Languages.Eng;
                    break;
                default:
                    WriteLetter(Out);
                    break;
            }
        }

        public void WriteLetter(string Letter)
        {
            if (InTextBox == null) return;

            int begin = InTextBox.SelectionStart;
            int length = InTextBox.SelectionLength;

            InTextBox.Text = InTextBox.Text.Remove(begin, length);
            if (Letter == "Backspace") InTextBox.Text = InTextBox.Text.Remove(begin-1, 1);
            else InTextBox.Text = InTextBox.Text.Insert(begin, Letter);
            InTextBox.Focus();
            if (Letter == "Backspace") InTextBox.SelectionStart = begin - 1;
            else InTextBox.SelectionStart = begin + Letter.Length;
        }
    }
}
