using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Circle : Shape
    {
        public Circle(int radius)
            : base(radius, radius)
        {

        }
        public override double CalculateSurface()
        {
            return Math.PI * width * height;
        }
        public override string ToString()
        {
            return string.Format("Circle: R={0}", width);
        }

    }
}
