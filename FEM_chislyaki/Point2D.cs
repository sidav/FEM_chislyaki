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
        public bool Visibru = true; //FOR SCREEN-SPACE CULLING ONLY!

        public ulong getSqDistanceTo(int xx, int yy)
        {
            ulong tx = (ulong)(x - xx);
            ulong ty = (ulong)(y - yy);
            return (tx * tx + ty * ty);
        }

        public Point2d(int xx, int yy, int n)
        {
            x = xx;
            y = yy;
            num = n;
        }
        public Point2d(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
    }
}
