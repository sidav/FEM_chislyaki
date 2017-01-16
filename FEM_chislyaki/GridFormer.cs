﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class GridFormer
    {
        static Point[,,] makePlate(double hx, double hy, double hz, int nx, int ny, int nz)
        {
            int num = 0;
            Point[,,] allPoints = new Point[nx, ny, nz];
            for (int i = 0; i < nx; i++)
                for (int j = 0; j < ny; j++)
                    for (int k = 0; k < nz; k++)
                    {
                        allPoints[i, j, k] = new Point(hx * i, hy * j, hz * k, num);
                        num++;
                    }
            return allPoints;
        }

        

        public static List<Tetrahedron> getTetrahedrons(double hx, double hy, double hz, int nx, int ny, int nz)
        {
            //int totalBricks = (nx - 1) * (ny - 1) * (nz - 1); //сколько будет всего кирпичей? Не понадобилось.
            List<Tetrahedron> tetr = new List<Tetrahedron>();//Список этих тетраэдров
            //Point[,,] pts = makePlate(hz, hy, hz, nx, ny, nz); //массив всех-всех точек, тоже пока не нужен вроде
            //int current = 0; //текущ. тетраэдр, тоже не нужно
            Point p1, p2, p3, p4, p5, p6, p7, p8; //точки текущего кирпича
            int WRONG_NUM = 0; //Это неправильный способ, он тут временно. Хехехе.
            for (int i = 0; i < nx - 1; i++)
                for (int j = 0; j < ny - 1; j++)
                    for (int k = 0; k < nz - 1; k++)
                    { ///СДЕЛАТЬ АДЕКВАТНУЮ НУМЕРАЦИЮ!
                        p1 = new Point(i * hx, j * hy, k * hz, WRONG_NUM);
                        p2 = new Point(i * hx, (j + 1) * hy, k * hz, WRONG_NUM+(j+1*ny));
                        p3 = new Point((i + 1) * hx, (j + 1) * hy, k * hz, WRONG_NUM+ny);
                        p4 = new Point((i + 1) * hx, j * hy, k * hz, WRONG_NUM + nx);
                        p5 = new Point(i * hx, j * hy, (k + 1) * hz, WRONG_NUM + 1);
                        p6 = new Point(i * hx, (j + 1) * hy, (k + 1) * hz, WRONG_NUM + 1 + nz);
                        p7 = new Point((i + 1) * hx, (j + 1) * hy, (k + 1) * hz, WRONG_NUM + 1);
                        p8 = new Point((i + 1) * hx, j * hy, (k + 1) * hz, WRONG_NUM + 1);
                        tetr.Add(new Tetrahedron(p2, p1, p3, p6));
                        tetr.Add(new Tetrahedron(p4, p1, p8, p3));
                        tetr.Add(new Tetrahedron(p5, p1, p6, p8));
                        tetr.Add(new Tetrahedron(p7, p3, p8, p6));
                        tetr.Add(new Tetrahedron(p6, p1, p3, p8));
                        WRONG_NUM++;
                    }
            return tetr;
        }
    }
}
