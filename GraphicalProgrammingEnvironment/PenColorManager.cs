using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    /// <summary>
    /// Manages the pen color for drawing in the graphical programming environment.
    /// </summary>
    public class PenColorManager
    {
        private Form1 formInstance;
        private Pen currentPen;

        /// <summary>
        /// Initializes a new instance of the <see cref="PenColorManager"/> class.
        /// </summary>
        /// <param name="form">The main form instance.</param>
        public PenColorManager(Form1 form)
        {
            formInstance = form;
            currentPen = new Pen(Color.Black, 2); // Default pen color is black
        }

        /// <summary>
        /// Processes the 'pen' command, setting the current pen color.
        /// </summary>
        /// <param name="command">The command string, e.g., 'pen Red'.</param>
        public void ProcessPenCommand(string command)
        {
            if (command.StartsWith("pen ", StringComparison.OrdinalIgnoreCase))
            {
                string colorName = command.Substring(4).Trim();
                Color penColor;

                try
                {
                    penColor = Color.FromName(colorName);
                    currentPen.Color = penColor;
                    formInstance.Circle.SetPenColor(penColor); // Set color for Circle
                    formInstance.Triangle.SetPenColor(penColor); //sets pen color of triangle
                
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid color name. Using default color (Black).");
                    penColor = Color.Black;
                }
            }
            else
            {
                MessageBox.Show("Invalid command. Please use 'pen <color>'.");
            }
        }

        /// <summary>
        /// Gets the current pen used for drawing.
        /// </summary>
        /// <returns>The current pen.</returns>
        public Pen GetCurrentPen()
        {
            return currentPen;
        }
    }

}
