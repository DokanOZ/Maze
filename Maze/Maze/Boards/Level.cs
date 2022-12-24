using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Maze.Boards
{
    internal class Level
    {
        public string[,] CreateLevel(string level)
        {
            string[] lines = ImportLevel(level).Split(Environment.NewLine);
            return Transform(lines);
        }

        private string ImportLevel(string level)
        {
            ResourceManager rm = new ResourceManager("Maze.Boards.Level", Assembly.GetExecutingAssembly());
            return rm.GetString(level);
        }

        private static string[,] Transform(string[] array) // Transform array into multidimensional array
        {
            int rows = array.Length;
            int cols = array[0].Length;

            string[,] multiDimensionalArray = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    multiDimensionalArray[y, x] = array[y].Substring(x, 1);
                }
            }

            return multiDimensionalArray;
        }
    }
}
