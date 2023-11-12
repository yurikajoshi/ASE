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

        public void ProcessRectangleCommand(string[] commandPart)
        {
            try
            {
                // Ensures that the array has at least 3 elements and the second and third elements are valid integers
                if (commandPart.Length >= 3 && int.TryParse(commandPart[1], out int width) && int.TryParse(commandPart[2], out int height))
                {
                    DrawRectangle(width, height);
                }
                else
                {
                    MessageBox.Show("Invalid 'rectangle' command. Please use 'rectangle <width> <height>'.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid width or height. Please provide valid integers for the width and height.");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Invalid 'rectangle' command. Please use 'rectangle <width> <height>'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the 'rectangle' command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawRectangle(int width, int height)
        {
            PictureBox pictureBox = formInstance.GetPictureBox();
            using (Graphics g = pictureBox.CreateGraphics())
            {
                // Uses the current pen color when drawing the rectangle
                using (Pen pen = formInstance.PenColorManager.GetCurrentPen())
                {
                    // Adjusts the position based on the width and height
                    int x = formInstance.CursorPosition.X - width / 2;
                    int y = formInstance.CursorPosition.Y - height / 2;

                    g.DrawRectangle(pen, x, y, width, height);
                }
            }
        }
    }
}
