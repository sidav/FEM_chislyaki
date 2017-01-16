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

        public static bool operator ==(Point c1, Point c2)
        {
            bool a = false;
            if (c1.x == c2.x && c1.y == c2.y && c1.z == c2.z)
                a = true;
            return a;
        }

        public static bool operator !=(Point c1, Point c2)
        {
            bool a = true;
            if (c1.x == c2.x && c1.y == c2.y && c1.z == c2.z)
                a = false;
            return a;
        }

        public static Point operator +(Point c1, Point c2)
        {
            Point a = new Point(0,0,0,c1.number);
            a.x = c1.x + c2.x;
            a.y = c1.y + c2.y;
            a.z = c1.z + c2.z;
            return a;
        }

        public static Point operator -(Point c1, Point c2)
        {
            Point a = new Point(0, 0, 0, c1.number);
            a.x = c1.x - c2.x;
            a.y = c1.y - c2.y;
            a.z = c1.z - c2.z;
            return a;
        }

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

        public Point getRotatedAroundCenter(double roll, double pitch, double yaw)
        {
            Point res = new Point(x,y,z,number);
            res = res - Camera.getRotateCenter();
            res.Rotate(roll, pitch, yaw);
            res = res + Camera.getRotateCenter();
            return res;
        }

    }
}
