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
        public static void showPoint(Point p)
        {
            String s = "("+p.x.ToString() + "; " + p.y.ToString() + "; " + p.z.ToString() + ") #" + p.number.ToString();
            MessageBox.Show(s);
        }
        public static void showAllVertices()
        {

        }
    }
}
