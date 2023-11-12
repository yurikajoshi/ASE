using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingEnvironment
{
    public class Shape
    {
        protected Form1 formInstance;
        protected Point position;

        public Shape(Form1 form)
        {
            formInstance = form;
        }

        public void SetPosition(Point newPosition)
        {
            position = newPosition;
        }
    }

}
