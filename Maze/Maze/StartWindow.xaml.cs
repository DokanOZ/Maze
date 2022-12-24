using Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Maze
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private Build _maze;
        private Player _player;
        private int _level = 1;
        public StartWindow()
        {
            InitializeComponent();
            _player = new Player(GameCanvas);
            LabelExhaustion.Content = "Exhaustion: 0";
            LabelTraps.Content = "Traps: 0";
            LabelCurrentLevel.Content = "Level " + _level;
            _maze = new Build(_level.ToString(), GameCanvas, _player);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            _player.Move(e);
            _player.Exhaustion++;
            LabelExhaustion.Content = "Exhaustion: " + _player.Exhaustion;
            _maze.DrawBoard(GameCanvas, _player);
            if (Scene.Maze.Traps.Contains(_player.Location))
            {
                Scene.Maze.Traps.Remove(_player.Location);
                Trap activateTrap = new Trap(_player);
                _player.CompletedTraps++;
                LabelTraps.Content = "Traps: " + _player.CompletedTraps;
            }
            else if (_player.Location == Scene.Maze.FinishLineLocation)
            {
                _level++;
                _maze = new Build(_level.ToString(), GameCanvas, _player);
                LabelCurrentLevel.Content = "Level " + _level;
            }
        }
    }
}
