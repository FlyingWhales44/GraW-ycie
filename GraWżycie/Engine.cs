using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWżycie
{
    class Engine
    {
        public bool[,] cell;
        protected bool[,] buff;
        public int warMax, warMin, oknoX, oknoY;

        public void game()
        {
            int licznik;

                for (int j = 1; j < oknoY - 1; j++)
                    for (int i = 1; i < oknoX - 1; i++)
                    {

                        licznik=Count(i, j);

                        CellDie(licznik, i, j);

                        CellLife(licznik, i, j);
                    }
                Rewrite();

            
        }

        public void CellDie(int licznik, int i, int j)
        {
            if (cell[j, i] == false && licznik == warMax)
                buff[j, i] = true;
            else
                buff[j, i] = false;
        }

        public void CellLife(int licznik, int i, int j)
        {
            if (cell[j, i] == true)
                if (licznik >= warMin && licznik <= warMax)
                    buff[j, i] = true;
                else
                    buff[j, i] = false;
        }

        public int Count( int i, int j)
        {
            int licz=0;
            for (int z = i - 1; z < i + 2; z++)
                for (int c = j - 1; c < j + 2; c++)
                    if (cell[c, z] == true && z != i && c != j)
                        licz++;
            return licz;
        }

        public void Rewrite()
        {
            for (int j = 0; j < oknoY; j++)
                for (int i = 0; i < oknoX; i++)
                    cell[j, i] = buff[j, i];
        }

        public void set_(int x, int y, int wMax, int wMin)
        {
         
            warMax = wMax;
            warMin = wMin;
            oknoX = x+2;
            oknoY = y+2;
            cell = new bool[oknoX, oknoY];
            buff = new bool[oknoX, oknoY];

            for (int i = 0; i < oknoY; i++)
                for (int j = 0; j < oknoX; j++)
                    cell[i, j] = false;

            for (int i = 0; i < oknoY; i++)
                for (int j = 0; j < oknoX; j++)
                    buff[i, j] = false;

        }

    }
}