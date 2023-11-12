using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingEnvironment
{
    public class CursorMove
    {
        private Form1 formInstance; // Instance of Form1

        public CursorMove(Form1 form)
        {
            formInstance = form; // Pass the current instance of Form1 to the MoveCursor class
        }
        public void ProcessMoveToCommand(string[] commandPart)
        {
            if (commandPart.Length == 3 && int.TryParse(commandPart[1], out int x) && int.TryParse(commandPart[2], out int y))
            {
                formInstance.cursorPosition = new Point(x, y); // Updates the cursor position
                formInstance.RefreshPictureBox(); // Refresh the picture box
            }
            else if (commandPart.Length == 2 && commandPart[1].Contains(','))
            {
                string[] commandCoordinate = commandPart[1].Split(',');
                if (int.TryParse(commandCoordinate[0], out int a) && int.TryParse(commandCoordinate[1], out int b))
                {
                    formInstance.cursorPosition = new Point(a, b); // Updates the cursor position in the current Form1 instance
                    formInstance.RefreshPictureBox();
                }
            }
            else
            {
                MessageBox.Show("Invalid 'moveTo' command. Please make sure to type 'moveTo x-coordinate y-coordinate'.");
            }
        }


    }
}
