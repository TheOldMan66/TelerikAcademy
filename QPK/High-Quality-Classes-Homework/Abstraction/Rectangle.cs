using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return width; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width of rectangle cannot be negative.");

                }
                else
                {
                    width = value;
                }
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height of rectangle cannot be negative.");

                }
                else
                {
                    height = value;
                }
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
