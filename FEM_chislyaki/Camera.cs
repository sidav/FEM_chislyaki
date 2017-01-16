using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Camera //и зачем оно здесь?..
    {

        const double distToRotCenter = 300;

        public static double camX = 0, camY = 0, camZ = -300;
        public static double pitch = 0, roll = 0, yaw = 0;

        public static Point getRotateCenter()
        {
            return new Point(camX, camY, distToRotCenter);
        }

        public static void Reset()
        {
            camX = 0;
            camY = 0;
            camZ = -300;
            pitch = 0;
            roll = 0;
            yaw = 0;
        }
    }
}
