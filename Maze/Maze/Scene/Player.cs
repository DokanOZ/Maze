using Maze;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Scene
{
    internal class Player
    {
        private Canvas _gameCanvas;
        public Player(Canvas gameCanvas)
        {
            _gameCanvas = gameCanvas;
            Exhaustion = 0;
            CompletedTraps = 0;
        }

        public string Name { get; set; }

        public string? Location { get; set; }

        public int Exhaustion { get; set; }

        public int CompletedTraps { get; set; }

        public Ellipse Model { get; set; }

        public List<string> Sight { get; set; }

        public void Move(KeyEventArgs e)
        {
            _gameCanvas.Children.Remove(Model);

            string[] locations = Location.Split(' ');
            int y = Convert.ToInt32(locations[0]);
            int x = Convert.ToInt32(locations[1]);

            switch (e.Key)
            {
                case Key.Up:
                    if (y != 0 && !Maze.Walls.Contains(String.Format("{0} {1}", y - 1, x))) { y--;}
                    break;

                case Key.Down:
                    if (_gameCanvas.Height > Model.Height * (y + 1) && !Maze.Walls.Contains(String.Format("{0} {1}", y + 1, x))) { y++; }
                    break;

                case Key.Left:
                    if (x != 0! && !Maze.Walls.Contains(String.Format("{0} {1}", y, x - 1))) { x--; }
                    break;

                case Key.Right:
                    if (_gameCanvas.Width > Model.Width * (x + 1) && !Maze.Walls.Contains(String.Format("{0} {1}", y, x + 1))) { x++; }
                    break;
            }

            Location = String.Format("{0} {1}", y, x);
            Model.Margin = new Thickness(Model.Width * x, Model.Height * y, 0, 0);
            _gameCanvas.Children.Add(Model);
        }

        public void SetModel(int height, int width, int x, int y)
        {
            Model = new Ellipse();
            Model.Height = height;
            Model.Width = width;
            Model.Fill = new SolidColorBrush(Colors.Red);
            Model.Margin = new Thickness(width * x, height * y, 0, 0);
        }
    }
}
