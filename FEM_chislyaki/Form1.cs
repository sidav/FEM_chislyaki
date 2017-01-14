using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FEM_chislyaki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.Black);
            formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, this.Width, this.Height));

            GridRender.drawer = formGraphics;
        }

        private void DoMagicBtn_Click(object sender, EventArgs e)
        {
            GridRender.doShit();
        }
    }
}
