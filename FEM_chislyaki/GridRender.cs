using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class GridRender //перспективная проекция и отрисовка будут тут
    {
        const int verticeSize = 4;
        public static Graphics draw;
        static SolidBrush myBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
        static Pen myPen = new Pen(Color.FromArgb(255, 0, 0, 0));
        public static double h = 0; //Расстояние до плоскости проекции.
                                    //ЗАДАЁТСЯ В ФОРМЕ В СВЯЗИ СО ВСЯКОЙ ХЕРНЁЙ.


        static void setColor(int r, int g, int b)
        {
            myBrush.Color = Color.FromArgb(255, r, g, b);
            myPen.Color = Color.FromArgb(255, r, g, b);
        }

        public static Point2d ProjectPoint(Point pt)
        {
            //аффинные преобразования?
            //да не, фигня какая-то.
            //Перевод в координаты камеры:
            double x = pt.x, y = pt.y, z = pt.z;
            x -= Camera.camX;
            y -= Camera.camY;
            z -= Camera.camZ;
            ////Нужен поворот отн. ЦЕНТРА, а не камеры!
            ////поворот отн. камеры по x:
            //double newY = y * Math.Cos(Camera.pitch) - z * Math.Sin(Camera.pitch);
            //double newZ = y * Math.Sin(Camera.pitch) + z * Math.Cos(Camera.pitch);
            //y = newY;
            //z = newZ;
            ////поворот отн. камеры по y:
            //double newX = x * Math.Cos(Camera.yaw) + z * Math.Sin(Camera.yaw);
            //newZ = -x * Math.Sin(Camera.yaw) + z * Math.Cos(Camera.yaw);
            //x = newX;
            //z = newZ;
            ////по z:
            //newX = x * Math.Cos(Camera.roll) - y * Math.Sin(Camera.roll);
            //newY = x * Math.Sin(Camera.roll) + y * Math.Cos(Camera.roll);

            //x = newX;
            //y = newY;
            //z = newZ;

            double projX = (x * h / z) + Form1.width / 2;
            double projY = (y * h / z) + Form1.height / 2;
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

        static List<Polygon> rotatePolys(List<Polygon> polysIn)
        {
            List<Polygon> rotatedPolys = polysIn;
            double cr = Camera.roll, cp = Camera.pitch, cy = Camera.yaw;
            //Вычисляем центр многогранника, заданного кучей полигонов.
            Point meanPoint = new Point(0, 0, 0);
            foreach (Polygon p in polysIn)
            {
                meanPoint.x += p.pt1.x + p.pt2.x + p.pt3.x;
                meanPoint.y += p.pt1.y + p.pt2.y + p.pt3.y;
                meanPoint.z += p.pt1.z + p.pt2.z + p.pt3.z;
            }
            meanPoint.x /= (polysIn.Count*3);
            meanPoint.y /= (polysIn.Count*3);
            meanPoint.z /= (polysIn.Count*3);
            //Центр есть, теперь надо повернуть многогранник относительно центра.
            //Переходим в собственные координаты многогранника:
            foreach (Polygon p in rotatedPolys)
            {
                p.pt1.x -= meanPoint.x;
                p.pt2.x -= meanPoint.x;
                p.pt3.x -= meanPoint.x;
                p.pt1.y -= meanPoint.y;
                p.pt2.y -= meanPoint.y;
                p.pt3.y -= meanPoint.y;
                p.pt1.z -= meanPoint.z;
                p.pt2.z -= meanPoint.z;
                p.pt3.z -= meanPoint.z;
                //Ок. Поворачиваем эту хреновину.
                p.pt1.Rotate(cr, cp, cy);
                p.pt2.Rotate(cr, cp, cy);
                p.pt3.Rotate(cr, cp, cy);
            }
            return rotatedPolys;
        }

        static void drawPolygon(Polygon p)
        {
            setColor(255, 0, 0);
            Point2d a = ProjectPoint(p.pt1);
            Point2d b = ProjectPoint(p.pt2);
            Point2d c = ProjectPoint(p.pt3);
            draw.DrawLine(myPen, a.x, a.y, b.x, b.y);
            draw.DrawLine(myPen, a.x, a.y, c.x, c.y);
            draw.DrawLine(myPen, b.x, b.y, c.x, c.y);
            setColor(128, 224, 0);
            draw.FillEllipse(myBrush, a.x-verticeSize/2, a.y-verticeSize/2, verticeSize, verticeSize);
            draw.FillEllipse(myBrush, b.x - verticeSize / 2, b.y - verticeSize / 2, verticeSize, verticeSize);
            draw.FillEllipse(myBrush, c.x - verticeSize / 2, c.y - verticeSize / 2, verticeSize, verticeSize);
        }

        public static void RenderGrid()
        {
            setColor(0, 0, 0);
            draw.FillRectangle(myBrush, 0, 0, Form1.width, Form1.height);

            //test:
            Point a = new Point(60, 0, 0);
            Point b = new Point(0, 60, 0);
            Point c = new Point(0, 0, 0);
            Point d = new Point(0, 0, 60);
            Tetrahedron trhd = new Tetrahedron(a, b, c, d);
            List<Tetrahedron> lt = new List<Tetrahedron>();
            lt.Add(trhd);
            List<Polygon> lp = TetrsToPolygons(lt);
            lp = rotatePolys(lp);
            foreach (Polygon p in lp)
                drawPolygon(p);
            //test end.
        }
    }
}
