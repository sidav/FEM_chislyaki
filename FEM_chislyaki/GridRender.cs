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
        static SolidBrush myBrush;// = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
        static Pen myPen;// = new Pen(Color.FromArgb(255, 0, 0, 0));
        public static double h = 0; //Расстояние до плоскости проекции.
                                    //ЗАДАЁТСЯ В ФОРМЕ В СВЯЗИ СО ВСЯКОЙ ХЕРНЁЙ.


        static void setColor(int r, int g, int b)
        {
            myBrush = new SolidBrush(Color.FromArgb(255, r, g, b));
            myPen = new Pen(Color.FromArgb(255, r, g, b));
        }

        static void drawString(String s, int x, int y)
        {
            draw.DrawString(s, new Font("Terminus", 10), myBrush, x, y);
        }

        static void drawSmallString(String s, int x, int y)
        {
            draw.DrawString(s, new Font("Arial", 8), myBrush, x, y);
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
            double projX = (x * h / z) + Form1.width / 2;
            double projY = (y * h / z) + Form1.height / 2;
            Point2d pt2d = new Point2d((int)projX, (int)projY, pt.number);
            if (z <= 0)
                pt2d.Visibru = false;
            return pt2d;
        }

        public static Point2d RotateAndProject(Point pt)
        {
            Point ptt = pt.getRotatedAroundCenter(Camera.roll, Camera.pitch, Camera.yaw);
            return ProjectPoint(ptt);
        }

        static void drawPoint2D(Point2d toDraw)
        {
            if (toDraw.Visibru)
            {
                if (toDraw.num == Metadata.lastPointClicked)
                {
                    setColor(255, 0, 255);
                    draw.FillEllipse(myBrush, toDraw.x - verticeSize / 2, toDraw.y - verticeSize / 2, verticeSize + (verticeSize / 2), verticeSize + (verticeSize / 2));
                    drawString(toDraw.num.ToString(), toDraw.x, toDraw.y);
                }
                else
                {
                    draw.FillEllipse(myBrush, toDraw.x - verticeSize / 2, toDraw.y - verticeSize / 2, verticeSize, verticeSize);
                    drawSmallString(toDraw.num.ToString(), toDraw.x - verticeSize / 2, toDraw.y - verticeSize / 2);
                }
            }
        }

        static void drawPoint3D(Point toDraw)
        {
            drawPoint2D(RotateAndProject(toDraw));
        }

        static void drawLine3d(Point from, Point to)
        {
            Point2d pt1 = RotateAndProject(from);
            Point2d pt2 = RotateAndProject(to);
            draw.DrawLine(myPen, pt1.x, pt1.y, pt2.x, pt2.y);
        }

        static void drawPolygon(Polygon p)
        {
            setColor(255, 0, 0);
            Point2d a = RotateAndProject(p.points[0]);//ProjectPoint(p.points[0]);
            Point2d b = RotateAndProject(p.points[1]);//ProjectPoint(p.points[1]);
            Point2d c = RotateAndProject(p.points[2]);//ProjectPoint(p.points[2]);
            if (a.Visibru && b.Visibru)
                draw.DrawLine(myPen, a.x, a.y, b.x, b.y);
            if (a.Visibru && c.Visibru)
                draw.DrawLine(myPen, a.x, a.y, c.x, c.y);
            if (b.Visibru && c.Visibru)
                draw.DrawLine(myPen, b.x, b.y, c.x, c.y);
            //Рисуем вершины в виде кружочков.
            setColor(128, 224, 0);
            drawPoint2D(a);
            drawPoint2D(b);
            drawPoint2D(c);
            myPen.Dispose();
            myBrush.Dispose();
        }

        public static void renderWireframe(Point[,,] wrf)
        {
            setColor(128, 128, 128);
            drawPoint2D(RotateAndProject(Camera.getRotateCenter()));
            for (int i = 0; i < GridFormer.NX; i++)
                for (int j = 0; j < GridFormer.NY; j++)
                    for (int k = 0; k < GridFormer.NZ; k++)
                    {
                        setColor(255, 0, 0);
                        if (k+1 < GridFormer.NZ)
                            drawLine3d(wrf[i, j, k], wrf[i, j, k+1]);
                        if (j + 1 < GridFormer.NY)
                            drawLine3d(wrf[i, j, k], wrf[i, j+1, k]);
                        if (i + 1 < GridFormer.NX)
                            drawLine3d(wrf[i, j, k], wrf[i+1, j, k]);
                        setColor(128, 224, 0);
                        drawPoint3D(wrf[i, j, k]);
                    }
        }

        public static void renderTetrahedrons(List<Tetrahedron> lt)
        {
            setColor(128, 128, 128);
            drawString("Всего " + Metadata.ListPolys.Count + " полигонов.", 0, 0);
            drawPoint2D(RotateAndProject(Camera.getRotateCenter()));
            //_DEBUG.showPoint(lp[0].points[0]);
            foreach (Polygon p in Metadata.ListPolys)
                drawPolygon(p);
        }

        public static void Render()
        {
            setColor(0, 0, 0);
            draw.FillRectangle(myBrush, 0, 0, Form1.width, Form1.height);
            //test:
            //Point a = new Point(60, 0, 0, 0);
            //Point b = new Point(0, 60, 0, 1);
            //Point c = new Point(0, 0, 0, 2);
            //Point d = new Point(0, 0, 60, 3);
            //Tetrahedron trhd = new Tetrahedron(a, b, c, d);
            //List<Tetrahedron> lt = new List<Tetrahedron>();
            //lt.Add(trhd);
            //renderTetrahedrons(lt);
            //test end.
            renderWireframe(Metadata.Wireframe);
            //drawString("Last clicked point is" + Metadata.lastPointClicked.ToString(), 0, 20);
            myPen.Dispose();
            myBrush.Dispose();
        }
    }
}
