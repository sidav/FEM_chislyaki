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
        const int rotateFactor = 5;

        public static float width, height;
        public Form1()
        {
            InitializeComponent();

            width = this.Width;
            height = this.Height;

            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            GridRender.draw = formGraphics;
            
        }

        private void parseShit()
        {
            double.TryParse(hxBox.Text, out Metadata.hx);
            double.TryParse(hyBox.Text, out Metadata.hy);
            double.TryParse(hzBox.Text, out Metadata.hz);
            int.TryParse(nxBox.Text, out Metadata.nx);
            int.TryParse(nyBox.Text, out Metadata.ny);
            int.TryParse(nzBox.Text, out Metadata.nz);
            Metadata.makeData();
        }

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
                Camera.movX(3);
            if (e.KeyChar == 'd')
                Camera.movX(-3);
            if (e.KeyChar == 'w')
                Camera.movY(-3);
            if (e.KeyChar == 's')
                Camera.movY(3);
            if (e.KeyChar == 'r')
                Camera.movZ(-3);
            if (e.KeyChar == 'f')
                Camera.movZ(3);
            if (e.KeyChar == 'q')
                Camera.rotY(-rotateFactor);
            if (e.KeyChar == 'e')
                Camera.rotY(rotateFactor);
            if (e.KeyChar == 't')
                Camera.rotX(-rotateFactor);
            if (e.KeyChar == 'g')
                Camera.rotX(rotateFactor);
            if (e.KeyChar == 'z')
                Camera.rotZ(-rotateFactor);
            if (e.KeyChar == 'c')
                Camera.rotZ(rotateFactor);
            if (e.KeyChar == '[')
                GridRender.h -= 10;
            if (e.KeyChar == ']')
                GridRender.h += 10;
            if (GridRender.h < 2)
                GridRender.h = 2;
            GridRender.Render();
            //e.Handled = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            GridRender.h = height;
            parseShit();
            Metadata.makeData();
            GridRender.Render();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Metadata.findNearestPointOnClick(e.X, e.Y);
                GridRender.Render();
            }
        }

        Point2d oldMouse, newMouse;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                newMouse.x = e.X;
                newMouse.y = e.Y;
                if (Math.Sqrt(newMouse.getSqDistanceTo(oldMouse.x, oldMouse.y)) > 50)
                {
                    oldMouse = new Point2d(e.X, e.Y);
                    Camera.rotX(rotateFactor);
                    GridRender.Render();
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            oldMouse = new Point2d(e.X, e.Y);
            newMouse = new Point2d(e.X, e.Y);
        }

        private void DoMagicBtn_Click(object sender, EventArgs e)
        {
            //Camera.Reset();
            Camera.Reset();
            parseShit();
            GridRender.Render();
                //MessageBox.Show("Succeed!" + hx.ToString());
        }
    }
}
