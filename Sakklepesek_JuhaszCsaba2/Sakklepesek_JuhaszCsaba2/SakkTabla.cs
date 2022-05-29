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
            for (int col = 1; col <= 8; col++)
            {
                int x = bottomLeftX + (col - 1) * 60;
                if (row == 1)
                {
                    // oszlop betű
                    var letter = new Label();
                    letter.Content = "" + (char)('A' + (col - 1));
                    letter.HorizontalAlignment = HorizontalAlignment.Left;
                    letter.VerticalAlignment = VerticalAlignment.Top;
                    letter.Width = 60;
                    letter.Height = 27;
                    letter.Margin = new Thickness(x + 20, y + 60, 0, 0);
                    grid.Children.Add(letter);
                }
                var tile = new Rectangle();

            }

        }
        TablaReset();
       
    }

    private void TablaReset()
    {
        bool dark = true;
        for (int row = 1; row <= 8; row++)
        {
            for (int col = 1; col <= 8; col++)
            {
                tiles[row][col].Fill = dark ? DARK : LIGHT;
                dark = !dark;
            }
            dark = !dark;
        }
    }
    private void OnTileClick(object sender, MouseButtonEventArgs e)
    {

        TablaReset();
        Rectangle tile = (Rectangle)sender;
        string[] data = tile.Name.Substring(1).Split("_");
        //pozíciótárolás
        var pos = new Position(Int32.Parse(data[1]), Int32.Parse(data[0]));
        tileLabel.Content = "Kiválasztott mező: " + pos;
        //lehetséges lépések
        List<Position> validMoves = MoveCalculator.GetValidMoves(pos, CurrentPiece);
        validMoves.ForEach(pos =>
        {
            var t = tiles[pos.Row][pos.Column];
            if (t.Fill == DARK)
                t.Fill = MOVE_DARK;
            else
                t.Fill = MOVE_LIGHT;
        });
        moveBox.Text = "Lehetséges lépések: " + string.Join(" ", validMoves);
    }
}