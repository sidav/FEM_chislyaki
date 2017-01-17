using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class GridFormer
    {

        public static Point[,,] fuckThis;
        public static int NX, NY, NZ;

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
            NX = nx;
            NY = ny;
            NZ = nz;
            //int totalBricks = (nx - 1) * (ny - 1) * (nz - 1); //сколько будет всего кирпичей? Не понадобилось.
            List<Tetrahedron> tetr = new List<Tetrahedron>();//Список этих тетраэдров
            //Point[,,] pts = makePlate(hz, hy, hz, nx, ny, nz); //массив всех-всех точек, тоже пока не нужен вроде
            //int current = 0; //текущ. тетраэдр, тоже не нужно
            Point p1, p2, p3, p4, p5, p6, p7, p8; //точки текущего кирпича
            fuckThis = new Point[nx, ny, nz];
            int nzny = nz * ny;
            for (int i = 0; i < nx - 1; i++)
                for (int j = 0; j < ny - 1; j++)
                    for (int k = 0; k < nz - 1; k++)
                    { //Нумерация, как это ни удивительно, работает.
                        p1 = new Point(i * hx, j * hy, k * hz,                   k + j * nz + i * nzny);
                        p2 = new Point(i * hx, (j + 1) * hy, k * hz,             k + (j+1) * nz + i * nzny);
                        p3 = new Point((i + 1) * hx, (j + 1) * hy, k * hz,       k + (j+1) * nz + (i+1) * nzny);
                        p4 = new Point((i + 1) * hx, j * hy, k * hz,             k + j * nz + (i+1) * nzny);
                        p5 = new Point(i * hx, j * hy, (k + 1) * hz,             (k+1) + j * nz + i * nzny);
                        p6 = new Point(i * hx, (j + 1) * hy, (k + 1) * hz,       (k+1) + (j+1) * nz + i * nzny);
                        p7 = new Point((i + 1) * hx, (j + 1) * hy, (k + 1) * hz, (k+1) + (j+1) * nz + (i+1) * nzny);
                        p8 = new Point((i + 1) * hx, j * hy, (k + 1) * hz,       (k+1) + j * nz + (i+1) * nzny);
                        //<Необязательное?>
                        //Сформируем модель из прямоугольников, просто потому что мы можем.
                        fuckThis[i, j, k] = p1;
                        fuckThis[i, j+1, k] = p2;
                        fuckThis[i+1, j+1, k] = p3;
                        fuckThis[i+1, j, k] = p4;
                        fuckThis[i, j, k+1] = p5;
                        fuckThis[i, j + 1, k+1] = p6;
                        fuckThis[i + 1, j + 1, k+1] = p7;
                        fuckThis[i + 1, j, k+1] = p8;
                        //</необязательное?>
                        tetr.Add(new Tetrahedron(p2, p1, p3, p6));
                        tetr.Add(new Tetrahedron(p4, p1, p8, p3));
                        tetr.Add(new Tetrahedron(p5, p1, p6, p8));
                        tetr.Add(new Tetrahedron(p7, p3, p8, p6));
                        tetr.Add(new Tetrahedron(p6, p1, p3, p8));
                    }
            return tetr;
        }
    }
}
