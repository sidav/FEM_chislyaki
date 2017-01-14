using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Point
    {
        public double x = 0, y = 0, z = 0;
        public int number;
        public Point(double xx, double yy, double zz)
        {
            x = xx;
            y = yy;
            z = zz;
        }
        public Point(double xx, double yy, double zz, int num)
        {
            x = xx;
            y = yy;
            z = zz;
            number = num;
        }
    }
}
