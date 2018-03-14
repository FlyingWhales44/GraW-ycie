using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWżycie
{
    class Engine
    {
        public List<List<bool>> cell { get; set; }
        protected List<List<bool>> buff { get; set; }
        public int MaxLife, MinLife, MaxDead, MinDead, oknoX, oknoY;

        public void game()
        {
            int licznik;

            for (int j = 1; j < oknoY - 1; j++)
            {
                for (int i = 1; i < oknoX - 1; i++)
                {

                    licznik = Count(i, j);

                    if (cell[j][i] == true)
                    { CellLife(licznik, i, j); }
                    else
                    { CellDie(licznik, i, j); }

                }
            }
            Rewrite();


        }

        public void CellDie(int licznik, int i, int j)
        {
            if ((licznik <= MaxDead) && (licznik >= MinDead))
                buff[j][i] = true;
            else
                buff[j][i] = false;
        }

        public void CellLife(int licznik, int i, int j)
        {
            if ((licznik <= MaxLife) && (licznik >= MinLife))
                buff[j][i] = true;
            else
                buff[j][i] = false;
        }

        public int Count(int i, int j)
        {
            int licz = 0;

            for (int z = j - 1; z < j + 2; z++)
                for (int c = i - 1; c < i + 2; c++)
                {
                    if (cell[z][c] == true)
                    {
                        if (z != j || c != i)
                        { licz++; }
                    }
                }

            return licz;
        }

        public void Rewrite()
        {
            for (int j = 0; j < oknoY; j++)
                for (int i = 0; i < oknoX; i++)
                    cell[j][i] = buff[j][i];
        }

        public void set_(int x, int y, int MaxL, int MinL, int MaxD, int MinD)
        {
            MaxLife = MaxL;
            MinLife = MinL;
            MaxDead = MaxD;
            MinDead = MinD;


            oknoX = x + 2;
            oknoY = y + 2;

            cell = new List<List<bool>>();
            buff = new List<List<bool>>();

            for (int i = 0; i < oknoY; i++)
            {
                cell.Add(new List<bool>());
                for (int j = 0; j < oknoX; j++)
                    cell[i].Add(false);
            }


            for (int i = 0; i < oknoY; i++)
            {
                buff.Add(new List<bool>());
                for (int j = 0; j < oknoX; j++)
                   buff[i].Add(false);
            }

        }

    }
}