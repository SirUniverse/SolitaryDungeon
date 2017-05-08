using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaryDungeon
{
    static class Pathfinding
    {
        private static bool InBoder(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Game.CurentLevel.Width && y < Game.CurentLevel.Height)
                return true;
            return false;
        }

        public static Direction NextStep(int Xstart, int Ystart, int Xtarget, int Ytarget)
        {
            //reversing the input
            Xstart += Ystart;
            Ystart = Xstart - Ystart;
            Xstart -= Ystart;

            Xtarget += Ytarget;
            Ytarget = Xtarget - Ytarget;
            Xtarget -= Ytarget;

            int[,] dp = new int[Game.CurentLevel.Width, Game.CurentLevel.Height];
            int[] dx = { 0, -1, 0, 1 };
            int[] dy = { -1, 0, 1, 0 };

            Queue<int> qx = new Queue<int>();
            Queue<int> qy = new Queue<int>();

            dp[Xtarget, Ytarget] = 1;
            qx.Enqueue(Xtarget);
            qy.Enqueue(Ytarget);
            while (qx.Count != 0)
            {
                int x = qx.First();
                int y = qy.First();
                qx.Dequeue();
                qy.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (InBoder(nx, ny) == false) continue;
                    if (Game.CurentLevel.Map[nx, ny].IsSolid == false && dp[nx, ny] == 0)
                    {
                        dp[nx, ny] = dp[x, y] + 1;
                        qx.Enqueue(nx);
                        qy.Enqueue(ny);
                    }
                }
            }

            int nextValue = 100000000;
            int dir = 0;
            for (int i = 0; i < 4; i++)
            {
                int nx = Xstart + dx[i];
                int ny = Ystart + dy[i];

                if (InBoder(nx, ny) == true && Game.CurentLevel.Map[nx, ny].IsSolid == false && dp[nx, ny] < nextValue)
                {
                    nextValue = dp[nx, ny];
                    dir = i;
                }
            }


            switch (dir)
            {
                case 0: return Direction.Left;
                case 1: return Direction.Up;
                case 2: return Direction.Right;
                default: return Direction.Down;
            }
        }
    }
}
