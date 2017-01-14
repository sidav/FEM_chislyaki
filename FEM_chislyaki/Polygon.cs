using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Polygon
    {
        public Point pt1, pt2, pt3;
        public Polygon(Point p1, Point p2, Point p3)
        {
            pt1 = p1;
            pt2 = p2;
            pt3 = p3;
        }
    }
}
