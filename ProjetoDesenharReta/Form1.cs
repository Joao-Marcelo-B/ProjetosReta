using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoDesenharReta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x1, x2, y1, y2;
        int c = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            alg_DDA(250, 359 - 50, 100, 359 - 250, bmp);

            alg_DDA(180, 359 - 50, 320, 359 - 50, bmp);

            alg_DDA(80, 359 - 200, 100, 359 - 250, bmp);

            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (c == 0)
            {
                x1 = e.X;
                y1 = e.Y;
                c++;
            }
            else
            {
                x2 = e.X;
                y2 = e.Y;
                c = 0;
            }
        }

        private void cmdDDA_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            alg_DDA(x1, (359 - y1), x2, (359-y2), bmp);
            pictureBox1.Image = bmp;
           
        }

        private void alg_Bresenham(int x1, int y1, int x2, int y2, Bitmap bmp)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int x = x1;
            int y = y1;
            int x_inc, y_inc;
            int p;
            if (dx > 0)
            {
                x_inc = 1;
            }
            else
            {
                x_inc = -1;
                dx = (int)Math.Abs(dx);
            }
            if (dy > 0)
            {
                y_inc = 1;
            }
            else
            {
                y_inc = -1;
                dy = (int)Math.Abs(dy);
            }
            //1,4,5 e 8
            if (dx > dy)
            {
                p = 2 * dy - dx;
                for (int i = 0; i < dx; i++)
                {
                    bmp.SetPixel(x, 359 - y, Color.Blue);
                    x += x_inc;
                    if (p < 0)
                    {
                        p += 2 * dy;
                    }
                    else
                    {
                        y += y_inc;
                        p += 2 * (dy - dx);
                    }
                }
            }
            else
            {
                p = 2 * dx - dy;
                for (int i = 0; i < dy; i++)
                {
                    bmp.SetPixel(x, 359 - y, Color.Blue);
                    y += y_inc;
                    if (p < 0)
                    {
                        p += 2 * dx;

                    }
                    else
                    {
                        x += x_inc;
                        p += 2 * (dx - dy);
                    }
                }
            }
        }

        public void PontoMedio(int px, int py, int r, Bitmap bmp)
        {
            int p;
            int x = 0;
            int y = r;
            
            bmp.SetPixel(px + r, py, Color.Red);
            bmp.SetPixel(px - r, py, Color.Red);
            bmp.SetPixel(px, py + r, Color.Red);
            bmp.SetPixel(px, py - r, Color.Red);
            p = 1 - r;
            while (x < y)
            {
                x++;
                if (p < 0)
                {
                    p = p + 2 * x + 1;
                    bmp.SetPixel(px + x, py + y, Color.Blue);
                    bmp.SetPixel(px + y, py + x, Color.Blue);
                    bmp.SetPixel(px + y, py - x, Color.Blue);
                    bmp.SetPixel(px - x, py + y, Color.Blue);
                    bmp.SetPixel(px - x, py - y, Color.Blue);
                    bmp.SetPixel(px - y, py - x, Color.Blue);
                    bmp.SetPixel(px - y, py + x, Color.Blue);
                    bmp.SetPixel(px + x, py - y, Color.Blue);
                }
                else
                {
                    y--;
                    p = p + 2 * x + 1 - 2 * y;
                    bmp.SetPixel(px + x, py + y, Color.Blue);
                    bmp.SetPixel(px + y, py + x, Color.Blue);
                    bmp.SetPixel(px + y, py - x, Color.Blue);
                    bmp.SetPixel(px - x, py + y, Color.Blue);
                    bmp.SetPixel(px - x, py - y, Color.Blue);
                    bmp.SetPixel(px - y, py - x, Color.Blue);
                    bmp.SetPixel(px - y, py + x, Color.Blue);
                    bmp.SetPixel(px + x, py - y, Color.Blue);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            if(Math.Abs(x2 - x1) > Math.Abs(y2 - y1))
                bresenhanH(x1, (359 - y1), x2, (359 - y2), bmp);
            else
                bresenhanV(x1, (359 - y1), x2, (359 - y2), bmp);
            
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            PontoMedio(150, 50, 50, bmp);
            alg_Bresenham(100, (359 - 50), 100, (359 - 250), bmp);
            alg_Bresenham(200, (359 - 50), 200, (359 - 250), bmp);
            PontoMedio(150, 250, 50, bmp);


            PontoMedio(300, 300, 50, bmp);
            alg_Bresenham(300, (359 - 260), 300, (359 - 300), bmp);
            alg_Bresenham(300, (359 - 300),335, (359 - 300), bmp);

            pictureBox1.Image = bmp;
        }

        //private void bresenhan(int x1, int y1, int x2, int y2, Bitmap bmp)
        //{
        //    int dx = x2 - x1;
        //    int dy = y2 - y1;

        //    int p = 2 * dy - dx;

        //    bmp.SetPixel(x1, 359 - y1, Color.Black);

        //    int x = x1;
        //    int y = y1;
        //    for(x1 = x1 +1; x1 <= x2; x1++)
        //    {
        //        if(p < 0)
        //        {
        //            x++;
        //            bmp.SetPixel(x, 359 - y, Color.Black);
        //            p += 2 * dy;
        //        } 
        //        else
        //        {
        //            x++;
        //            y++;
        //            bmp.SetPixel(x + 1, 359 - (y + 1), Color.Black);
        //            p += 2 * (dy - dx);
        //        }
        //    }
        //}

        private void bresenhanH(int x1, int y1, int x2, int y2, Bitmap bmp)
        {
            if(x1 > x2)
            {
                bresenhanH(x2, y2, x1, y1, bmp);
                return;
            }

            int dx = x2 - x1;
            int dy = y2 - y1;

            int dir = dy < 0 ? -1 : 1;
            dy *= dir;

            int p = 2 * dy - dx;
            int y = y1;
            for (int x = x1; x <= x2; x++)
            {
                bmp.SetPixel(x, 359 - y, Color.Black);
                if (p > 0)
                {
                    y+= dir;
                    p -= 2 * dx;
                }
                
                p += 2 * dy;
            }
        }

        private void bresenhanV(int x1, int y1, int x2, int y2, Bitmap bmp)
        {
            if (y1 > y2)
            {
                bresenhanV(x2, y2, x1, y1, bmp);
                return;
            }

            int dx = x2 - x1;
            int dy = y2 - y1;

            int dir = dx < 0 ? -1 : 1;
            dx *= dir;

            int p = 2 * dy - dx;
            int x = x1;
            for (int i = x1; i <= y2; i++)
            {
                bmp.SetPixel(x, 359 - y1, Color.Black);
                if (p > 0)
                {
                    x += dir;
                    p -= 2 * dy;
                }
                
                p += 2 * dx;
            }
        }

        private void alg_DDA(int x1, int y1, int x2, int y2, Bitmap bmp)
        {
            int dx = x2 - x1;
            if (dx < 0)
            {
                alg_DDA(x2, y2, x1, y1, bmp);
                return;
            }

            int dy = y2 - y1;

            float m = (float)dy / dx;

            bmp.SetPixel(x1, 359 - y1, Color.Black);

            float y = y1;
            for(x1 = x1+1; x1 <= x2; x1++)
            {
                y += m;
                bmp.SetPixel(x1, 359 - (int)y, Color.Black);
            }
        }

              

     
    }
}
