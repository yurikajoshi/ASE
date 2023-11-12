using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    public class Circle : Shape
    {
        private Color currentPenColor; // Store the current pen color

        public Circle(Form1 form) : base(form)
        {
            currentPenColor = Color.Black; // Default pen color is black
        }

        public void ProcessCircleCommand(string[] commandSyntax)
        {
            if (commandSyntax.Length == 2 && int.TryParse(commandSyntax[1], out int radius))
            {
                DrawCircle(radius);
            }
            else
            {
                MessageBox.Show("Invalid 'circle' command. Please use 'circle <radius>'.");
            }
        }
        private void DrawCircle(int radius)
        {
            PictureBox pictureBox = formInstance.GetPictureBox();
            using (Graphics g = pictureBox.CreateGraphics())
            {
                int diameter = radius * 2;
                int x = (int)(formInstance.CursorPosition.X - radius);
                int y = (int)(formInstance.CursorPosition.Y - radius);

                // Use the current pen color when drawing the circle
                using (Pen pen = new Pen(currentPenColor, 2))
                {
                    g.DrawEllipse(pen, x, y, diameter, diameter);
                }
            }
        }

        // Set the current pen color
        public void SetPenColor(Color color)
        {
            currentPenColor = color;
        }
    }

}
