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
        public static Graphics draw;
        static SolidBrush myBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
        static Pen myPen = new Pen(Color.FromArgb(255, 0, 0, 0));
        //const double h = 100; //Расстояние до плоскости проекции.
        static double h = Form1.width / 2; //Расстояние до плоскости проекции.
        //перспективная проекция и отрисовка будут тут

        static void setColor(int r, int g, int b)
        {
            myBrush.Color = Color.FromArgb(255, r, g, b);
            myPen.Color = Color.FromArgb(255, r, g, b);
        }

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

        public static List<Polygon> TetrsToPolygons(List<Tetrahedron> tetrs)
        {
            List<Polygon> polys = new List<Polygon>();
            Polygon currPolygon;
            foreach (Tetrahedron t in tetrs)
            {
                currPolygon = new Polygon(t.i, t.j, t.k); //основание тетраэдра
                polys.Add(currPolygon);
                currPolygon = new Polygon(t.i, t.j, t.p); 
                polys.Add(currPolygon);
                currPolygon = new Polygon(t.j, t.k, t.p);
                polys.Add(currPolygon);
                currPolygon = new Polygon(t.k, t.i, t.p);
                polys.Add(currPolygon);
            }
            return polys;
        }

        static void drawPolygon(Polygon p)
        {
            setColor(255, 224, 0);
            Point2d a = ProjectPoint(p.pt1);
            Point2d b = ProjectPoint(p.pt2);
            Point2d c = ProjectPoint(p.pt3);
            draw.DrawLine(myPen, a.x, a.y, b.x, b.y);
            draw.DrawLine(myPen, a.x, a.y, c.x, c.y);
            draw.DrawLine(myPen, b.x, b.y, c.x, c.y);
        }

        public static void RenderGrid()
        {
            h = Form1.height / 2;
            setColor(0, 0, 0);
            draw.FillRectangle(myBrush, 0, 0, Form1.width, Form1.height);

            //test:
            Point a = new Point(100, 250, 0);
            Point b = new Point(160, 250, 0);
            Point c = new Point(130, 0, 40);
            Point d = new Point(130, 130, 0);
            Tetrahedron trhd = new Tetrahedron(a, b, c, d);
            List<Tetrahedron> lt = new List<Tetrahedron>();
            lt.Add(trhd);
            List<Polygon> lp = TetrsToPolygons(lt);
            foreach (Polygon p in lp)
                drawPolygon(p);
            //test end.

            //setColor(255, 224, 0);
            //draw.FillEllipse(myBrush, 0, 0, 25, 25);
        }
    }
}
