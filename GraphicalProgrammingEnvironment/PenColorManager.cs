using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    public class PenColorManager
    {
        private Form1 formInstance;
        private Pen currentPen;

        public PenColorManager(Form1 form)
        {
            formInstance = form;
            currentPen = new Pen(Color.Black, 2); // Default pen color is black
        }

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

        public Pen GetCurrentPen()
        {
            return currentPen;
        }
    }

}
