using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Sakklepesek_JuhaszCsaba2
{
    internal class SakkTabla
    {
        private readonly Brush DARK = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private readonly Brush LIGHT = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        private readonly Brush MOVE_DARK = new SolidColorBrush(Color.FromRgb(50, 50, 50));
        private readonly Brush MOVE_LIGHT = new SolidColorBrush(Color.FromRgb(205, 205, 205));
    }
}
