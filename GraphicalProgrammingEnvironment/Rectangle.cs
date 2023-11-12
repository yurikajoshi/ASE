using GraphicalProgrammingEnvironment;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{

    public class Rectangle
    {
        private Form1 formInstance;

        public Rectangle(Form1 form)
        {
            formInstance = form;
        }

        public void ProcessRectangleCommand(string[] commandSyntax)
        {
            if (commandSyntax.Length == 3 && int.TryParse(commandSyntax[1], out int width) && int.TryParse(commandSyntax[2], out int height))
            {
                DrawRectangle(width, height);
            }
            else
            {
                MessageBox.Show("Invalid 'rectangle' command. Please use 'rectangle <width> <height>'.");
            }
        }

        private void DrawRectangle(int width, int height)
        {
            PictureBox pictureBox = formInstance.GetPictureBox();
            using (Graphics g = pictureBox.CreateGraphics())
            {
                // Use the current pen color when drawing the rectangle
                using (Pen pen = formInstance.PenColorManager.GetCurrentPen())
                {
                    // Adjust the position based on the width and height
                    int x = formInstance.CursorPosition.X - width / 2;
                    int y = formInstance.CursorPosition.Y - height / 2;

                    g.DrawRectangle(pen, x, y, width, height);
                }
            }
        }
    }
}