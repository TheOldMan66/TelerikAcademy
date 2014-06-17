using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    abstract class Shape
    {
        protected int height;
        protected int width;
        public abstract double CalculateSurface();
        public Shape(int height, int width)
        {
            if (height <= 0 || width <= 0)
                throw new ArgumentOutOfRangeException("Size of shape must be > 0");
            this.height = height;
            this.width = width;
        }
    }
}
