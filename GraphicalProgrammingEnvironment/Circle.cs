
using GraphicalProgrammingEnvironment;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    /// <summary>
    /// Represents a circle shape in the graphical programming environment. Where circle is inheriting shape
    /// </summary>
    public class Circle : Shape
    {
        private Color currentPenColor; // Stores the current pen color

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="form">The main form instance.</param>
        public Circle(Form1 form) : base(form)
        {
            currentPenColor = Color.Yellow; // Default pen color is yellow
        }

        /// <summary>
        /// Processes the 'circle' command and draws a circle with the specified radius.
        /// </summary>
        /// <param name="commandPart">An array containing the command parts.</param>
        public void ProcessCircleCommand(string[] commandPart)

        {
            try
            {
                if (commandPart.Length == 2 && int.TryParse(commandPart[1], out int radius))
                {

                    DrawCircle(radius);
                }
                else
                {
                    MessageBox.Show("Invalid 'circle' command. Please use 'circle <radius>'.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing the circle command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Draws a circle with the specified radius at the current cursor position.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        private void DrawCircle(int radius)
        {
            try
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
            catch (Exception ex){
                MessageBox.Show($"Error drawing circle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets the current pen color for drawing circles.
        /// </summary>
        /// <param name="color">The color to set for the pen.</param>
        public void SetPenColor(Color color)
        {
            currentPenColor = color;
        }
    }
}