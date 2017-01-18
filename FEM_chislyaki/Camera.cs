using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Camera //и зачем оно здесь?..
    {

        //double distToRotCenter = 200;

        const double degreeInRads = 0.017;

        public static double camX = 0, camY = 0, camZ = -100;
        public static double pitch = 0, roll = 0, yaw = 0;

        public static Point getRotateCenter()
        {
            return new Point(camX, camY, 0);
        }

        public static void rotX(int degrees)
        {
            pitch += degrees * degreeInRads;
        }

        public static void rotY(int degrees)
        {
            yaw += degrees * degreeInRads;
        }

        public static void rotZ(int degrees)
        {
            roll += degrees * degreeInRads;
        }

        private static void move(double factor, double mx, double my, double mz)
        {
            Point mov = new Point(mx, my, mz);
            mov.Rotate(roll, pitch, yaw);
            camX += mov.x * factor;
            camY += mov.y * factor;
            camZ += mov.z * factor;
        }

        public static void movX(double factor)
        {
            move(factor, 1, 0, 0);
        }

        public static void movY(double factor)
        {
            move(factor, 0, 1, 0);
        }

        public static void movZ(double factor)
        {
            move(factor, 0, 0, 1);
        }

        public static void Reset()
        {
            camX = 0;
            camY = 0;
            camZ = -100;
            pitch = 0;
            roll = 0;
            yaw = 0;
        }
    }
}
