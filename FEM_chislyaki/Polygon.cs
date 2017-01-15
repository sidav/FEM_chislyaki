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
        public bool isEqual(Polygon sample)
        {
            Point s1 = sample.pt1, s2 = sample.pt2, s3 = sample.pt3;
            if (
                (pt1 == s1 && pt2 == s2 && pt3 == s3) ||
                (pt1 == s1 && pt2 == s3 && pt3 == s2) ||
                (pt1 == s2 && pt2 == s1 && pt3 == s3) ||
                (pt1 == s2 && pt2 == s3 && pt3 == s1) ||
                (pt1 == s3 && pt2 == s1 && pt3 == s2) ||
                (pt1 == s3 && pt2 == s2 && pt3 == s1)
                )
                return true;
            return false;
        }
    }
}
