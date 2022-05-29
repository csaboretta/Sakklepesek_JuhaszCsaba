using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chess;

public class SakkTabla
{
    private readonly Brush DARK = new SolidColorBrush(Color.FromRgb(209, 139, 71));
    private readonly Brush LIGHT = new SolidColorBrush(Color.FromRgb(255, 206, 158));
    private readonly Brush MOVE_DARK = new SolidColorBrush(Color.FromRgb(209, 190, 171));
    private readonly Brush MOVE_LIGHT = new SolidColorBrush(Color.FromRgb(255, 233, 209));
    private Dictionary<int, Dictionary<int, Rectangle>> tiles = new();
    private int baseX;
    private int baseY;

    private Image? CurrentImage;

    public Tabla(int bottomLeftX, int bottomLeftY)
    {
        
        baseX = bottomLeftX;
        baseY = bottomLeftY;
        for (int row = 1; row <= 8; row++)
        {
            int y = bottomLeftY - (row - 1) * 60;
            var number = new Label();
            number.Content = "" + row;
            number.HorizontalAlignment = HorizontalAlignment.Left;
            number.VerticalAlignment = VerticalAlignment.Top;
            number.Width = 60;
            number.Height = 27;
            number.Margin = new Thickness(bottomLeftX - 20, y + 20, 0, 0);
            grid.Children.Add(number);
          

        }
       
    }



   
}