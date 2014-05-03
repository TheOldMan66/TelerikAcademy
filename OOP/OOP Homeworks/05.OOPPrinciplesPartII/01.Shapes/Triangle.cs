using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Triangle : Shape
    {
        public Triangle(int height, int width)
            : base(height, width)
        {

        }
        public override double CalculateSurface()
        {
            return (double)(height * width) / 2.0d;
        }
        public override string ToString()
        {
            return string.Format("Triangle: W={0}, H={1}", width, height);
        }
    }
}
