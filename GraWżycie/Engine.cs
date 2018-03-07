using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWżycie
{
    class Engine
    {
        public void game()
        {
            while(true)
            {
                int licznik;

                for(int j=1;j<oknoY-1;j++)
                    for(int i=1;i<oknoX-1;i++)
                    {
                        licznik = 0;

                        for(int z=i-1;z<i+2;z++)
                            for(int c=j-1;c<j+2;c++)
                        if( cell[c,z] == true && z!=i && c !=j)
                                 licznik++;

                        if (cell[j, i] == false && licznik == warMax)
                            buff[j, i] = true;
                        else
                            buff[j, i] = false;

                        if (cell[j, i] == true)
                            if (licznik >= warMin && licznik <= warMax)
                                buff[j, i] = true;
                            else
                                buff[j, i] = false;
                    }

                for (int j = 0; j < oknoY; j++)
                    for (int i = 0; i < oknoX; i++)
                        cell[j, i] = buff[j, i];
            }
        }

        public void set_(int x,int y,int wMax,int wMin,int oX,int oY)
        {

            cell = new bool[x, y];
            buff = new bool[x, y];
            warMax = wMax;
            warMin = wMin;
            oknoX = oX;
            oknoY = oY;

            for (int i = 0; i < oY; i++)
                for (int j = 0; j < oX; j++)
                    cell[i,j] = false;

            for (int i = 0; i < oY; i++)
                for (int j = 0; j < oX; j++)
                    buff[i, j] = false;

        }

        public void set_cells(int x,int y)
        {
            cell[y, x] = true;
        }



        protected bool[,] cell;
        protected bool[,] buff;
        protected int warMax, warMin, oknoX,oknoY;
    }
}
