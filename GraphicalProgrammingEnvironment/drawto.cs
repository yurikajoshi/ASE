using GraphicalProgrammingEnvironment;
using System.Drawing;
using System;

public class DrawTo
{
    private Form1 form;
    private Pen pen;

    public DrawTo(Form1 form)
    {
        this.form = form;
        this.pen = new Pen(Color.Yellow); 
    }

    public void ProcessDrawToCommand(string[] commandPart)
    {
        if (commandPart.Length == 3)
        {
            if (int.TryParse(commandPart[1], out int x) && int.TryParse(commandPart[2], out int y))
            {
                Point startPoint = form.CursorPosition; // Gets the current cursor position
                Point endPoint = new Point(x, y);

                //Drawing on the bitmap
                Bitmap drawingSurface = form.GetDrawingSurface();
                using (Graphics g = Graphics.FromImage(drawingSurface))
                {
                    g.DrawLine(pen, startPoint, endPoint);
                }

                form.GetPictureBox().Image = drawingSurface; // Updates PictureBox with the new drawing
                form.SetCursorPosition(endPoint); // Updates cursor position
                form.RefreshPictureBox(); // Refreshes the PictureBox
            }
            else
            {
                Console.WriteLine("Invalid coordinates. Please provide valid numbers for x and y.");
            }
        }
        else
        {
            Console.WriteLine("Invalid 'drawto' command format. Use 'drawto x y'.");
        }
    }
}
