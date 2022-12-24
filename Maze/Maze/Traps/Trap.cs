using Scene;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    internal class Trap
    {
        public Trap(Player player)
        {
            CreateTraps();

            TrapWindow trapWin = new TrapWindow(GetRandomTrap());
            trapWin.ShowDialog();
        }

        private List<string>? ListTraps { get; set; }

        private void CreateTraps()
        {
            ListTraps = new List<string>();

            ListTraps.Add("Caesar Cipher");
            // .. add your traps here
        }

        private string GetRandomTrap()
        {
            Random rnd = new Random();
            int range = ListTraps.Count;

            return ListTraps.ElementAt(rnd.Next(range));
        }
    }
}
