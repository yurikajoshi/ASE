﻿
using GraphicalProgrammingEnvironment;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    public class Circle : Shape
    {
        private Color currentPenColor; // Stores the current pen color

        public Circle(Form1 form) : base(form)
        {
            currentPenColor = Color.Yellow; // Default pen color is yellow
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

                // Uses the current pen color when drawing the circle
                using (Pen pen = new Pen(currentPenColor, 2))
                {
                    g.DrawEllipse(pen, x, y, diameter, diameter);
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