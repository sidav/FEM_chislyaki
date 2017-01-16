using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Polygon
    {
        public Point[] points = new Point[3];
        public Polygon(Point p1, Point p2, Point p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }
        public bool isEqual(Polygon sample)
        {
            Point s1 = sample.points[0], s2 = sample.points[1], s3 = sample.points[2];
            if (
                (points[0] == s1 && points[1] == s2 && points[2] == s3) ||
                (points[0] == s1 && points[1] == s3 && points[2] == s2) ||
                (points[0] == s2 && points[1] == s1 && points[2] == s3) ||
                (points[0] == s2 && points[1] == s3 && points[2] == s1) ||
                (points[0] == s3 && points[1] == s1 && points[2] == s2) ||
                (points[0] == s3 && points[1] == s2 && points[2] == s1)
                )
                return true;
            return false;
        }
    }
}
