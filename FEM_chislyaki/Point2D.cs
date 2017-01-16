using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Point2d
    {
        public int x = 0, y = 0, num = -1;//, size = 4;
        public bool Visibru = true;
        public Point2d(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        public Point2d(int xx, int yy, int n)
        {
            x = xx;
            y = yy;
            num = n;
        }
    }
}
