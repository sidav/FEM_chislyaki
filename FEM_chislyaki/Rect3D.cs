using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Rect3D //четырёхугольник в трёхмерном пространстве. 
    {
        Point[] points = new Point[4];
        public Rect3D(Point a, Point b, Point c, Point d)
        {
            points[0] = a;
            points[1] = b;
            points[2] = c;
            points[3] = d;
        }
    }
}
