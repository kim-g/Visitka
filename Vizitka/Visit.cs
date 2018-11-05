using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vizitka
{
    public class Visit : Grid
    {
        private Label VisitName;

        // instagram://user?username=kim-g
        // Свойства
        public string Title { get { return (string)VisitName.Content; } set { VisitName.Content = value; } }

        public Visit(Panel Core)
        {
            StackPanel VertStack = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };
            this.Children.Add(VertStack);

            VisitName = new Label();
            VertStack.Children.Add(VisitName);
            Core.Children.Add(this);
        }

        
    }
}
