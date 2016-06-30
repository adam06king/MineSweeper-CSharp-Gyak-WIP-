using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_Project
{
    class Game
    {
        protected int GridX = 4;
        protected int GridY = 4;
        string[,] grid = new string[4, 4];
        int Clicks = 0;
        Random rnd = new Random();

        public void NewGame()
        {
            //Resetting clicks
            Clicks = 0;
            //Creating Mines
            int minenum = 5;
            int minecount = 0;
            int[] randX = new int[5];
            int[] randY = new int[5];
            for (int i = 0; i < randX.Length; i++)
            {
                randX[i] = rnd.Next(GridX);
            }
            for (int i = 0; i < randY.Length; i++)
            {
                randY[i] = rnd.Next(GridY);
            }
            while (minecount < minenum)
            {
                bool ok = true;
                for (int i = 0; i < 5; i++)
                {
                    if ((randX[minecount] == randX[i]) && (randY[minecount] == randY[i]))
                    {
                        ok = false;
                    }
                    if (i == minecount)
                    {
                        ok = true;
                    }
                }
                // DEBUG: MessageBox.Show("Minecount: " + minecount + " Ok: " + ok.ToString() + Environment.NewLine + "Jelenlegi randX: " + randX[minecount] + " randX elemei: " + randX[0] + " " +randX[1] + " " +randX[2] + " " + randX[3] + " " + randX[4] + Environment.NewLine + "Jelenlegi randY: " + randY[minecount] + " randY elemei: " + randY[0] + " " + randY[1] + " " + randY[2] + " " + randY[3] + " " + randY[4], "Debug");
                if (ok)
                {
                    grid[randX[minecount], randY[minecount]] = "*";
                    minecount++;
                }
                else
                {
                    randX[minecount] = rnd.Next(GridX);
                    randY[minecount] = rnd.Next(GridY);
                }
            }
        }
        public void ClearGame()
        {
            for (int i = 0; i < GridX; i++)
            {
                for (int j = 0; j < GridY; j++)
                {
                    grid[i, j] = "";
                }
            }
        }
        public string Check(int x, int y)
        {
            int minesnearby = 0;
            if (grid[x, y] == "*")
            {
                return "*";
            }
            else if (true)
            {
                int amin = 0, amax = 0;
                int bmin = 0, bmax = 0;
                //X
                if (0 < x && x < GridX-1)
                {
                    amin = x - 1;
                    amax = x + 1;
                }
                else if (x == 0)
                {
                    amin = x;
                    amax = x + 1;
                }
                else if (x == GridX-1)
                {
                    amin = x - 1;
                    amax = x;
                }
                //Y
                if (0 < y && y < GridY-1)
                {
                    bmin = y - 1;
                    bmax = y + 1;
                }
                else if (y == 0)
                {
                    bmin = y;
                    bmax = y + 1;
                }
                else if (y == GridY-1)
                {
                    bmin = y - 1;
                    bmax = y;
                }

                for (int i = amin; i < amax + 1; i++)
                {
                    for (int j = bmin; j < bmax + 1; j++)
                    {
                        if (grid[i, j] == "*")
                        {
                            minesnearby++;
                        }
                    }
                }

                return minesnearby + "";
            }
        }
        public bool Click()
        {
            Clicks++;
            bool ok;
            if (Clicks == GridX*GridY - minenum)
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }
        public void setGridsize(int a, int b)
        {
            GridX = a;
            GridY = b;
        }
        public int getGridX()
        {
            return GridX;
        }
        public int getGridY()
        {
            return GridY;
        }


    }
}
