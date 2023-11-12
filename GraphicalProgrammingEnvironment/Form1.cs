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
        public Point cursorPosition;
        public PenColorManager PenColorManager;
        public Circle Circle;
        public Triangle Triangle;
        public Rectangle Rectangle;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
            PenColorManager = new PenColorManager(this);
            Circle = new Circle(this);
            Triangle = new Triangle(this);
            Rectangle = new Rectangle(this);

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string command = textBox1.Text.Trim();
            ProcessCommand(command);
    
        }

        public void RefreshPictureBox()
        {
            pictureBox1.Refresh();
        }
        public Point CursorPosition
        {
            get { return cursorPosition; }
        }

        public PictureBox GetPictureBox()
        {
            return pictureBox1;
        }

        public void SetCursorPosition(Point position)
        {
            cursorPosition = position;
        }

        public Color GetPixelColor(int x, int y)
        {
            return myBitmap.GetPixel(x, y);
        }



        public void ProcessCommand(string command)
        {
            string[] commandPart = command.Split(' ');
            if (commandPart.Length > 0)
            {
                string finalCommand = commandPart[0].ToLower();
                switch (finalCommand)
                {

                    case "pen":
                        PenColorManager.ProcessPenCommand(command);
                        break;

                    case "circle":
                        Circle.ProcessCircleCommand(commandPart);
                        break;
                    case "triangle":
                        Triangle.ProcessTriangleCommand(commandPart);
                        break;
                    case "rectangle":
                        Rectangle.ProcessRectangleCommand(commandPart);
                        break;

                    case "moveto":
                        CursorMove c = new CursorMove(this); // Passes the current instance of Form1
                        c.ProcessMoveToCommand(commandPart);
                        break;
                    case "clear":
                        pictureBox1.Image = null;
                        break;
                    case "reset":
                        pictureBox1.Image = null; // Clears the PictureBox by setting its Image property to null

                        // Reset the cursor position
                        cursorPosition = new Point(0, 0); // Assuming cursorPosition is declared globally
                        pictureBox1.Refresh(); // Refresh the PictureBox to reflect the new cursor position
                        break;

                    default:
                        MessageBox.Show("Invalid command. Please use a valid command!");
                        break;

                }

            }
        }

       

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int starSize = 15; // Size of the star as needed
            int halfSize = starSize / 2;

            // Gets the center of the star
            int centerX = cursorPosition.X;
            int centerY = cursorPosition.Y;

            // Defines the points for a 5-pointed star
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

    }
}
