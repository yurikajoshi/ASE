using GraphicalProgrammingEnvironment;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    /// <summary>
    /// Represents a class responsible for drawing triangles in the graphical programming environment.
    /// </summary>
    public class Triangle : Shape
    {
        private bool isFilled;
        private Color currentPenColor; // Stores current pen color

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="form">The main form instance.</param>
        public Triangle(Form1 form) : base(form)
        {
            currentPenColor = Color.Yellow; // Default pen color is yellow
        }

        /// <summary>
        /// Processes the 'triangle' command to draw an equilateral triangle with specified length of the side of the triangle.
        /// </summary>
        /// <param name="commandPart">An array containing the command and its parameters.</param>
        /// <remarks>
        /// The 'triangle' command expects at least two elements in the array:
        ///   1. The command itself ('triangle').
        ///   2. The side length of the triangle (an integer).
        /// </remarks>
        /// <exception cref="FormatException">Thrown when the side Length are not valid integer.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when the command does not have the required number of arguments.</exception>
        public void ProcessTriangleCommand(string[] commandPart)
        {
            try
            {
                // Ensures that the array has at least 2 elements and the second element is a valid integer
                if (commandPart.Length == 2 && int.TryParse(commandPart[1], out int sideLength))
                {
                    isFilled = formInstance.IsFillEnabled; // Get the fill status from the Form1 instance using the property
                    DrawTriangle(sideLength);
                }
                else
                {
                    MessageBox.Show("Invalid 'triangle' command. Please use 'triangle <sideLength>'.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid side length. Please provide a valid integer for the side length.");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Invalid 'triangle' command. Please use 'triangle <sideLength>'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while processing the 'triangle' command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Draws an equilateral triangle based on the specified length of side around the cursor
        /// </summary>
        /// <param name="sideLength"></param>
        /// <remarks>
        /// If fill is enabled in the form, the triangle will be filled with the current pen color.
        /// Otherwise, only the outline of the triangle will be drawn.
        /// </remarks>
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

                // Uses the current pen color when drawing the triangle
                using (Pen pen = new Pen(currentPenColor, 2))
                {
                    if (isFilled)
                    {
                        // Fills the triangle
                        using (Brush brush = new SolidBrush(currentPenColor))
                        {
                            Point[] trianglePoints = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
                            g.FillPolygon(brush, trianglePoints);
                        }
                    }
                    else
                    {
                        // Draws the outline of the triangle
                        g.DrawLine(pen, x1, y1, x2, y2);
                        g.DrawLine(pen, x2, y2, x3, y3);
                        g.DrawLine(pen, x3, y3, x1, y1);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the current pen color for drawing triangles.
        /// </summary>
        /// <param name="color">The color to set.</param>
        // Sets the current pen color
        public void SetPenColor(Color color)
        {
            currentPenColor = color;
        }
    }
}
