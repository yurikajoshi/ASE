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
    /// Handles the movement of the cursor in the graphical programming environment.
    /// </summary>
    public class CursorMove
    {
        private Form1 formInstance; // Instance of Form1

        /// <summary>
        /// Initializes a new instance of the <see cref="CursorMove"/> class.
        /// </summary>
        /// <param name="form">The instance of the main form (Form1).</param>
        public CursorMove(Form1 form)
        {
            formInstance = form; // Passes the current instance of Form1 to the MoveCursor class
        }

        /// <summary>
        /// Processes the 'moveTo' command, updating the cursor position on the form.
        /// </summary>
        /// <param name="commandPart">An array containing the command parts.</param>
        public void ProcessMoveToCommand(string[] commandPart)
        {
            try
            {
                if (commandPart.Length == 3 && int.TryParse(commandPart[1], out int x) && int.TryParse(commandPart[2], out int y))
                {
                    // Updates cursor position with specified coordinates
                    formInstance.cursorPosition = new Point(x, y);
                    // Refreshes the PictureBox to reflect the new cursor position
                    formInstance.RefreshPictureBox();
                }
                else if (commandPart.Length == 2 && commandPart[1].Contains(','))
                {
                    // Parse coordinates separated by a comma
                    string[] commandCoordinate = commandPart[1].Split(',');
                    if (int.TryParse(commandCoordinate[0], out int a) && int.TryParse(commandCoordinate[1], out int b))
                    {
                        // Updates cursor position with parsed coordinates
                        formInstance.cursorPosition = new Point(a, b);
                        // Refreshes the PictureBox to reflect the new cursor position
                        formInstance.RefreshPictureBox();
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid 'moveTo' command. Please make sure to type 'moveTo x-coordinate y-coordinate'.");
                }
            }
            catch (Exception ex)
            {
                // Handles the exception (display an error message, log the exception, etc.)
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



    }
}
