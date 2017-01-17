using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEM_chislyaki
{
    class Metadata
    {
        public static List<Tetrahedron> ListTetrs;
        public static List<Polygon> ListPolys;
        public static Point[,,] Wireframe;
        public static int lastPointClicked = -1;

        public static void makeData()
        {
            ListTetrs = GridFormer.getTetrahedrons(10, 10, 10, 4, 4, 2);
            Wireframe = GridFormer.fuckThis;
            ListPolys = TetrsToPolygons(ListTetrs);
            ListPolys = reducePolygonsNumber(ListPolys);
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

        public static void findNearestPointOnClick(int clickx, int clicky)
        {
            int nearestNum = Wireframe[0, 0, 0].number;
            ulong nearestDist = GridRender.RotateAndProject(Wireframe[0, 0, 0]).getSqDistanceTo(clickx, clicky);
            foreach (Point pt in Wireframe)
            {
                ulong currDist = GridRender.RotateAndProject(pt).getSqDistanceTo(clickx, clicky);
                if (nearestDist > currDist)
                {
                    nearestNum = pt.number;
                    nearestDist = currDist;
                }
            }
            lastPointClicked = nearestNum;
        }

        public static List<Polygon> reducePolygonsNumber(List<Polygon> polysIn)
        {
            List<Polygon> reduced = new List<Polygon>();
            int allPolys = polysIn.Count;
            reduced.Add(polysIn[0]);
            bool add = true;
            for (int i = 1; i < allPolys; i++)
            {
                add = true;
                for (int j = 0; j < i; j++)
                {
                    if (polysIn[i].isEqual(polysIn[j]))
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                    reduced.Add(polysIn[i]);
            }
            return reduced;
        }

    }
}
