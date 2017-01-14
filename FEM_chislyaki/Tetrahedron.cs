using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Tetrahedron
    {
        public Point i, j, k, p;
        public Tetrahedron(Point ii, Point jj, Point kk, Point pp)
        {
            i = ii;
            j = jj;
            k = kk;
            p = pp;
        }

        public double getVolume() //возвращает объём тетраэдра.
        {
            double V = -5;
            double xp, xj, xk, yp, yj, yk, zp, zj, zk;
            xp = p.x - i.x;
            xj = j.x - i.x;
            xk = k.x - i.x;
            yp = p.y - i.y;
            yj = j.y - i.y;
            yk = k.y - i.y;
            zp = p.z - i.z;
            zj = j.z - i.z;
            zk = k.z - i.z;
            V = (xp * yj * zk + yp * zj * xk + zp * xj * yk - zp * yj * xk - xp * zj * yk - yp * xj * zk) / 6;
            if (V < 0) V = -V;
            return V;
        }
    }
}
