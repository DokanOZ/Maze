using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Scene
{
    internal class Tile
    {
        public Rectangle CreateTile(int height, int width, int x, int y, string typeOfTile, List<string> Sight)
        {
            Rectangle tile = new Rectangle();
            tile.Height = height;
            tile.Width = width;
            tile.Margin = new Thickness(width * x, height * y, 0, 0);
            tile.Stroke = new SolidColorBrush(Colors.Black);

            switch (typeOfTile)
            {
                case "w": // wall
                    tile.Fill = new SolidColorBrush(Colors.Brown);
                    break;
                case "t": // trap
                    tile.Fill = new SolidColorBrush(Colors.LightGreen);
                    break;
                case "f": // finishline
                    tile.Fill = new SolidColorBrush(Colors.Yellow);
                    break;
            }

            if(InSight(Sight, x, y) is false)
            {
                tile.Fill = new SolidColorBrush(Colors.Black);
            }

            return tile;
        }

        private bool InSight(List<string> Sight, int x, int y)
        {
            if (Sight.Contains(string.Format("{0} {1}", y, x)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
