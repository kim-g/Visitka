using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vizitka
{
    class KeyButton : Button
    {
        string Small;
        string Big;
        bool Shift = false;
        /// <summary>
        /// Выдаёт нажатую букву
        /// </summary>
        public string Letter { get { return Shift ? Big : Small; } }

        /// <summary>
        /// Меняет регистр на заданный и внешний вид кнопки
        /// </summary>
        /// <param name="shift"></param>
        public void SetShift(bool shift)
        {
            Shift = shift;
            Content = Letter;
        }

        /// <summary>
        /// Задаёт символы для отображения.
        /// </summary>
        /// <param name="big">Верхний регистр</param>
        /// <param name="small">Нижний регистр</param>
        public void SetLetters(string small, string big)
        {
            Background = new SolidColorBrush(Colors.Transparent);
            BorderBrush = new SolidColorBrush(Colors.White);
            FontFamily = new FontFamily("Formular");
            FontWeight = FontWeights.Bold;
            Big = big;
            Small = small;
            Content = Letter;
        }

        
    }
}
