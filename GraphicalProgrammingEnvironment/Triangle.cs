using GraphicalProgrammingEnvironment;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    public class Triangle : Shape
    {
        private Color currentPenColor; // Stores current pen color

        public Triangle(Form1 form) : base(form)
        {
            currentPenColor = Color.Yellow; // Default pen color is yellow
        }

        public void ProcessTriangleCommand(string[] commandPart)
        {
            if (commandPart.Length == 2 && int.TryParse(commandPart[1], out int sideLength))
            {
                DrawTriangle(sideLength);
            }
            else
            {
                MessageBox.Show("Invalid 'triangle' command. Please use 'triangle <sideLength>'.");
            }
        }

        private void DrawTriangle(int sideLength)
        {
            PictureBox pictureBox = formInstance.GetPictureBox();
            using (Graphics g = pictureBox.CreateGraphics())
            {
                // Calculates the vertices of an equilateral triangle
                int x1 = formInstance.CursorPosition.X;
                int y1 = formInstance.CursorPosition.Y - sideLength / 2;

                int x2 = formInstance.CursorPosition.X - (int)(sideLength * Math.Sqrt(3) / 2);
                int y2 = formInstance.CursorPosition.Y + sideLength / 2;

                int x3 = formInstance.CursorPosition.X + (int)(sideLength * Math.Sqrt(3) / 2);
                int y3 = formInstance.CursorPosition.Y + sideLength / 2;

                // Use the current pen color when drawing the triangle
                using (Pen pen = new Pen(currentPenColor, 2))
                {
                    g.DrawLine(pen, x1, y1, x2, y2);
                    g.DrawLine(pen, x2, y2, x3, y3);
                    g.DrawLine(pen, x3, y3, x1, y1);
                }
            }
        }

        // Sets the current pen color
        public void SetPenColor(Color color)
        {
            currentPenColor = color;
        }
    }
}