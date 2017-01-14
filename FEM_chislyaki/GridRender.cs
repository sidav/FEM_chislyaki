using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class GridRender
    {
        public static Graphics drawer;
        const double h = 100; //Расстояние до плоскости проекции.
        //перспективная проекция и отрисовка будут тут
        public static Point2d ProjectPoint(Point pt)
        {
            //аффинные преобразования?
            //да не, фигня какая-то.

            //ВРЕМЕННОЕ ГОВНОРЕШЕНИЕ
            double z = pt.z + h + 1;
            //
            double projX = pt.x * h / z;
            double projY = pt.y * h / z;
            Point2d pt2d = new Point2d((int)projX, (int)projY);
            return pt2d;
        }

        public static List<Point> TetrsToPolygons()
        {

        }

        public static void doShit()
        {
            SolidBrush blackBrush = new SolidBrush(System.Drawing.Color.Black);
            SolidBrush darkYellowBrush = new SolidBrush(Color.FromArgb(255, 192, 192, 0));
            Pen myPen = new Pen(Color.FromArgb(255,192,192,0));
            drawer.FillEllipse(darkYellowBrush, 0, 0, 25, 25);
        }
    }
}
