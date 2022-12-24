﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Maze.Boards
{
    internal class AutoGeneratedMaze
    {
        public string[,] Maze { get; set; }

        public AutoGeneratedMaze()
        {
            Random rnd = new Random();
            int random = rnd.Next(12, 26);
            Maze = new string[random, random];
            FillMaze();

            
            Maze = CreateMaze(Maze);
            PrintMaze(Maze);
        }

        public void FillMaze()
        {
            for (int y = 0; y < Maze.GetLength(0); y++)
            {
                for (int x = 0; x < Maze.GetLength(1); x++)
                {
                    Maze[y, x] = "w";
                }
            }
        }

        private string[,] DummyMaze()
        {
            int length = 6;
            string[,] dummyMaze = new string[length, length];
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    dummyMaze[0, x] = "x";
                    dummyMaze[y, x] = "w";
                }
            }
            return dummyMaze;
        }

        public string[,] CreateMaze(string[,] maze)
        {
            for (int y = 2; y < maze.GetLength(0); y += 2)
            {
                Random random = new Random();
                int start = 0;
                int runTime = random.Next(start, maze.GetLength(1));
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    while (x != runTime)
                    {
                        maze[y, x] = "x";

                        maze[y - 1, random.Next(start, runTime)] = "x";
                        x++;
                    }
                    start = x;
                    runTime = random.Next(start + 1, maze.GetLength(1));
                }
            }
            maze[0, 0] = "p";
            return maze;
        }

        public void PrintMaze(string[,] maze)
        {
            string b = "";
            for (int y = 0; y < maze.GetLength(0); y++)
            {
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    b += maze[y, x];
                }
                b += Environment.NewLine;
            }

            Trace.WriteLine(b);
        }
    }
}