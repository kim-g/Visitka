using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Vizitka
{
    public class WPF_Printer
    {
        public static void Print(FrameworkElement Element)
        {
            var dlg = new PrintDialog();
            dlg.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
            /*var result = dlg.ShowDialog();
            if (result == null || !(bool)result)
                return;*/
            var page = new Viewbox { Child =  Element  };


            page.Measure(new Size(dlg.PrintableAreaWidth, dlg.PrintableAreaHeight));
            page.Arrange(new Rect(new Point(0, 0), page.DesiredSize));

            dlg.PrintVisual(page, "Печать визиток");
        }
    }
}
