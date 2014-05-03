using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(int height, int width)
            : base(height, width)
        {

        }
        public override double CalculateSurface()
        {
            return (double)(height * width);
        }
        public override string ToString()
        {
            return string.Format("Rectangle: W={0}, H={1}", width, height);
        }

    }
}
