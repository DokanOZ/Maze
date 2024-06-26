﻿using Maze.Boards;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Scene
{
    internal class Build
    {
        private string[,] _mazeMatrix;

        public Build(string level, Canvas gameCanvas, Player player)
        {
            Level lvl = new Level();
            AutoGeneratedMaze autoLevel = new AutoGeneratedMaze();
            //_mazeMatrix = lvl.CreateLevel(level);
            _mazeMatrix = autoLevel.Maze;
            InitializeSurroundingAndPlayer(player);
            DrawBoard(gameCanvas, player);
        }

        private void InitializeSurroundingAndPlayer(Player player)
        {
            Maze.Walls = new List<string>();
            Maze.Traps = new List<string>();

            for (int y = 0; y < _mazeMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < _mazeMatrix.GetLength(1); x++)
                {
                    if (_mazeMatrix[y, x] == "p") // p = player
                    {
                        player.Location = String.Format("{0} {1}", y, x);
                    }
                    else if (_mazeMatrix[y, x] == "f") // f = finishline
                    {
                        Maze.FinishLineLocation = String.Format("{0} {1}", y, x);
                    }
                    else if (_mazeMatrix[y, x] == "w") // w = wall
                    {
                        Maze.Walls.Add(String.Format("{0} {1}", y, x)); // add all the locations of the walls in to a list
                    }
                    else if (_mazeMatrix[y, x] == "t") // t = Trap
                    {
                        Maze.Traps.Add(String.Format("{0} {1}", y, x)); // add all the locations of the walls in to a list
                    }
                }
            }
            PlayerSight(player);
        }

        private void PlayerSight(Player player) // adding the locations of the areas the player can see in to a list
        {
            player.Sight = new List<string>();

            string[] locations = player.Location.Split(' ');

            int rowLocation = Convert.ToInt32(locations[0]);
            int colLocation = Convert.ToInt32(locations[1]);

            for (int y = rowLocation - 1; y <= rowLocation + 1; y++)
            {
                for (int x = colLocation - 1; x <= colLocation + 1; x++)
                {
                    player.Sight.Add(String.Format("{0} {1}", y, x));
                }
            }
        }

        private void UpdateMatrix(Player player) // updates the matrix every time player changes location
        {
            for (int y = 0; y < _mazeMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < _mazeMatrix.GetLength(1); x++)
                {
                    if (_mazeMatrix[y, x] == "p")
                    {
                        _mazeMatrix[y, x] = "x";
                    }
                }
            }

            string[] locations = player.Location.Split(' ');

            int newY = Convert.ToInt32(locations[0]);
            int newX = Convert.ToInt32(locations[1]);

            _mazeMatrix[newY, newX] = "p";

            PlayerSight(player); // update the view the player has in its new location
        }

        public void DrawBoard(Canvas gameCanvas, Player player)
        {
            UpdateMatrix(player);
            gameCanvas.Children.Clear(); // draw board on an empty canvas
            Tile tile = new Tile();

            int height = (int)(gameCanvas.Height / _mazeMatrix.GetLength(0));
            int width = (int)(gameCanvas.Width / _mazeMatrix.GetLength(1));

            for (int y = 0; y < _mazeMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < _mazeMatrix.GetLength(1); x++)
                {
                    
                    if (_mazeMatrix[y, x] == "p")
                    {
                        player.SetModel(height, width, x, y);
                        gameCanvas.Children.Add(player.Model);
                    }

                    gameCanvas.Children.Add(tile.CreateTile(height, width, x, y, _mazeMatrix[y, x], player.Sight));
                }
            }
        }
    }
}
