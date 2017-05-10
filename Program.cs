using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SolitaryDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Initialize();

            Level lvl1 = new Level(20, 20);
            Game.CurrentLevel = lvl1;
            Player p = new Player(lvl1, 3, 3);
            Zombie z = new Zombie(lvl1, 8, 8);

            while (Game.IsAlive)
                while (!Game.IsPaused)
                {
                    Thread.Sleep(16);
                    p.Update();
                }
            if (Game.IsWon)
                Menu.ShowWin();
            else
                Menu.ShowGameOver();
        }
    }
}
