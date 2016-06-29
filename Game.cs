using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper_Project_Gyak
{
    class Game
    {
        protected int GridX = 10;
        protected int GridY = 10;
        string[,] grid = new string[10, 10];
        Random rnd = new Random();

        public void NewGame()
        {
            //Creating Mines
            int minenum = 10;
            int minecount = 0;
            int randX = rnd.Next(GridX);
            int randY = rnd.Next(GridY);
            while (minecount <= minenum && grid[randX,randY] == "*")
            {
                randX = rnd.Next(GridX);
                randY = rnd.Next(GridY);
                grid[randX, randY] = "*";
                minecount++;
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
            if (grid[x,y] == "*")
            {
                return "*";
            }
            else if (true)
            {
                int amin = 0,amax = 0;
                int bmin = 0,bmax = 0;
                //X
                if (0 < x && x < GridX)
                {
                    amin = y - 2;
                    amax = y + 2;
                }
                else if (x == 0)
                {
                    amin = y - 1;
                    amax = y + 2;
                }
                else if (x == GridX)
                {
                    amin = y - 2;
                    amax = y + 1;
                }
                //Y
                if (0 < y && y < GridY)
                {
                    bmin = y - 2;
                    bmax = y + 2;
                }
                else if (y == 0)
                {
                    bmin = y - 1;
                    bmax = y + 2;
                }
                else if (y == GridY)
                {
                    bmin = y - 2;
                    bmax = y + 1;
                }

                for (int i = amin; i < amax; i++)
                {
                    for (int j = bmin; j < bmax; j++)
                    {
                        if (grid[i,j] == "*")
                        {
                            minesnearby++;
                        }
                    }
                }

                return minesnearby + "";
            }
        }
        public void GameOver()
        {
            MessageBox.Show("Game Over!","Game Over!");
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
