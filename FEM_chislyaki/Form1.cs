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
        public static float width, height;
        public Form1()
        {
            InitializeComponent();

            width = this.Width;
            height = this.Height;

            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            //SolidBrush myBrush = new SolidBrush(System.Drawing.Color.Black);
            //formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, this.Width, this.Height));

            GridRender.draw = formGraphics;
            
        }

        //private void Form1_SizeChanged(object sender, EventArgs e)
        //{
        //    width = this.Width;
        //    height = this.Height;
        //}

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            width = this.Width;
            height = this.Height;
            Graphics formGraphics = this.CreateGraphics(); 
            GridRender.draw = formGraphics;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')
                Camera.camX += 10;
            if (e.KeyChar == 'd')
                Camera.camX -= 10;
            if (e.KeyChar == 'w')
                Camera.camY += 10;
            if (e.KeyChar == 's')
                Camera.camY -= 10;
            if (e.KeyChar == 'r')
                Camera.camZ += 10;
            if (e.KeyChar == 'f')
                Camera.camZ -= 10;
            if (e.KeyChar == 'q')
                Camera.yaw += 0.017;
            if (e.KeyChar == 'e')
                Camera.yaw -= 0.017;
            if (e.KeyChar == 't')
                Camera.pitch += 0.017;
            if (e.KeyChar == 'g')
                Camera.pitch -= 0.017;
            if (e.KeyChar == 'z')
                Camera.roll += 0.017;
            if (e.KeyChar == 'c')
                Camera.roll -= 0.017;
            if (e.KeyChar == '[')
                GridRender.h -= 10;
            if (e.KeyChar == ']')
                GridRender.h += 10;
            GridRender.RenderGrid();
            e.Handled = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            GridRender.h = height / 2;
            GridRender.RenderGrid();
        }

        private void DoMagicBtn_Click(object sender, EventArgs e)
        {
            Camera.Reset();
            GridRender.RenderGrid();
        }
    }
}
