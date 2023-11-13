using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingEnvironment
{
    /// <summary>
    /// Represents class Shape that will be inherited by the shape classes like circle, .etc
    /// </summary>
    public class Shape
    {
        protected Form1 formInstance;
        protected Point position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="form">The main form instance.</param>
        public Shape(Form1 form)
        {
            formInstance = form;
        }

        /// <summary>
        /// Sets the position of the shape.
        /// </summary>
        /// <param name="newPosition">The new position for the shape.</param>
        public void SetPosition(Point newPosition)
        {
            position = newPosition;
        }
    }

}
