using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap = new Bitmap(412, 302);
        private Point cursorPosition;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int starSize = 20; // Adjust the size of the star as needed
            int halfSize = starSize / 2;

            // Get the center of the star
            int centerX = cursorPosition.X;
            int centerY = cursorPosition.Y;

            // Define the points for a 5-pointed star
            Point[] starPoints = new Point[10];

            for (int i = 0; i < 10; i++)
            {
                double angle = Math.PI / 2 + 4 * Math.PI * i / 10;
                if (i % 2 == 0)
                {
                    starPoints[i] = new Point((int)(centerX + halfSize * Math.Cos(angle)),
                                              (int)(centerY + halfSize * Math.Sin(angle)));
                }
                else
                {
                    starPoints[i] = new Point((int)(centerX + (halfSize / 2) * Math.Cos(angle)),
                                              (int)(centerY + (halfSize / 2) * Math.Sin(angle)));
                }
            }

            // Draw a Yellow star centered around the cursor position
            e.Graphics.FillPolygon(Brushes.Yellow, starPoints);
        }

            private void DrawYellowStar(Graphics g, int x, int y)
        {
            // Define the points for a five-pointed star
            Point[] starPoints = new Point[10];
            for (int i = 0; i < 10; i++)
            {
                double angle = Math.PI / 5 * i;
                double radius = i % 2 == 0 ? 10 : 5; // Alternating long and short radius
                starPoints[i] = new Point((int)(x + radius * Math.Cos(angle)), (int)(y + radius * Math.Sin(angle)));
            }

            // Draw the star using a yellow brush
            g.FillPolygon(Brushes.Yellow, starPoints);
        }


    }
}
