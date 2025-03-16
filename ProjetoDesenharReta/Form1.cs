using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bresenhan(x1, (359 - y1), x2, (359 - y2), bmp);
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

        private void bresenhan(int x1, int y1, int x2, int y2, Bitmap bmp)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;

            int p = 2 * dy - dx;

            bmp.SetPixel(x1, 359 - y1, Color.Black);

            int x = x1;
            int y = y1;
            for(x1 = x1 +1; x1 <= x2; x1++)
            {
                if(p < 0)
                {
                    x++;
                    bmp.SetPixel(x, 359 - y, Color.Black);
                    p += 2 * dy;
                } 
                else
                {
                    x++;
                    y++;
                    bmp.SetPixel(x + 1, 359 - (y + 1), Color.Black);
                    p += 2 * (dy - dx);
                }
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
