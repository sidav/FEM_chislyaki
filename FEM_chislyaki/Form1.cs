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

        private void DoMagicBtn_Click(object sender, EventArgs e)
        {
            GridRender.RenderGrid();
        }
    }
}
