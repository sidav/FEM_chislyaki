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
        public void Rotate(double roll, double pitch, double yaw)
        {
            double newX, newY, newZ;
            //Around X:
            newY = y * Math.Cos(pitch) - z * Math.Sin(pitch);
            newZ = y * Math.Sin(pitch) + z * Math.Cos(pitch);
            y = newY;
            z = newZ;
            //Around Y:
            newX = x * Math.Cos(yaw) + z * Math.Sin(yaw);
            newZ = -x * Math.Sin(yaw) + z * Math.Cos(yaw);
            x = newX;
            z = newZ;
            //по z:
            newX = x * Math.Cos(roll) - y * Math.Sin(roll);
            newY = x * Math.Sin(roll) + y * Math.Cos(roll);
            x = newX;
            y = newY;
        }
    }
}
