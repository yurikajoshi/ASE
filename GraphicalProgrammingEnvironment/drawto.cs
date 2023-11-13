using GraphicalProgrammingEnvironment;
using System;
using System.Drawing;

/// <summary>
/// Represents a class responsible for drawing lines in the graphical programming environment.
/// </summary>
public class DrawTo
{
    private Form1 form;
    private Pen pen;

    /// <summary>
    /// Initializes a new instance of the <see cref="DrawTo"/> class.
    /// </summary>
    /// <param name="form">The main form instance.</param>
    public DrawTo(Form1 form)
    {
        this.form = form;
        this.pen = new Pen(Color.Yellow);
    }

    /// <summary>
    /// Processes the 'drawto' command, drawing a line from the current cursor position to the specified coordinates given by the user.
    /// </summary>
    /// <param name="commandPart">An array containing the command parts.</param>
    public void ProcessDrawToCommand(string[] commandPart)
    {
        try
        {
            // Ensure that the array has at least 3 elements and the second and third elements are valid integers
            if (commandPart.Length == 3 && int.TryParse(commandPart[1], out int x) && int.TryParse(commandPart[2], out int y))
            {
                Point startPoint = form.CursorPosition; // Gets the current cursor position
                Point endPoint = new Point(x, y);

                // Drawing on the bitmap
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
        catch (FormatException)
        {
            Console.WriteLine("Invalid coordinates. Please provide valid numbers for x and y.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid 'drawto' command format. Use 'drawto x y'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while processing the 'drawto' command: {ex.Message}");
        }
    }
}
