using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FEM_chislyaki
{
    class _DEBUG
    {
        public static void showVertice(Point p)
        {
            String s = "x " + p.x.ToString() + " y " + p.y.ToString() + " z " + p.z.ToString();
            MessageBox.Show(s);
        }
        public static void showAllVertices()
        {

        }
    }
}
