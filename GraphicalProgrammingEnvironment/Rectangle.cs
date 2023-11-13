using GraphicalProgrammingEnvironment;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    /// <summary>
    /// Represents a class responsible for drawing rectangles in the graphical programming environment.
    /// </summary>
    public class Rectangle : Shape
    {
        private Form1 formInstance;
       

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="form">The main form instance.</param>
        public Rectangle(Form1 form) : base(form)
        {
            formInstance = form;
        }

        /// <summary>
        /// Processes the 'rectangle' command, drawing a rectangle with the specified width and height.
        /// </summary>
        /// <param name="commandPart">An array containing the command parts.</param>
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

        /// <summary>
        /// Draws a rectangle with the specified width and height at the current cursor position.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        private void DrawRectangle(int width, int height)
        {
            PictureBox pictureBox = formInstance.GetPictureBox();
            using (Graphics g = pictureBox.CreateGraphics())
            {
                // Uses the current pen color when drawing the rectangle
                using (Pen pen = new Pen(formInstance.PenColorManager.GetCurrentPen().Color, 2))
                {
                    // Adjusts the position based on the width and height
                    int x = formInstance.CursorPosition.X - width / 2;
                    int y = formInstance.CursorPosition.Y - height / 2;

                    if (formInstance.IsFillEnabled)
                    {
                        // Fills the rectangle
                        using (Brush brush = new SolidBrush(formInstance.PenColorManager.GetCurrentPen().Color))
                        {
                            g.FillRectangle(brush, x, y, width, height);
                        }
                    }
                    else
                    {
                        // Draws the outline of the rectangle
                        g.DrawRectangle(pen, x, y, width, height);
                    }
                }
            }
        }
    }
}
