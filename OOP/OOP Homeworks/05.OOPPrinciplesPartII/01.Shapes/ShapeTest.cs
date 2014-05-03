using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    /* Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. 
    * Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of 
    * the figure (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable 
    * constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() 
    * method. Write a program that tests the behavior of  the CalculateSurface() method for different shapes 
    * (Circle, Rectangle, Triangle) stored in an array. */
    class ShapeTest
    {
        static void Main(string[] args)
        {
            Triangle tr = new Triangle(5, 10);
            Rectangle rect = new Rectangle(5, 10);
            Circle cr = new Circle(1);
            List<Shape> shapes = new List<Shape>();
            shapes.Add(tr);
            shapes.Add(rect);
            shapes.Add(cr);
            shapes.Add(new Rectangle(3, 3));
            shapes.Add(new Circle(4));
            shapes.Add(new Triangle(5, 3));
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("{0} - area is {1}", shape, shape.CalculateSurface());
            }
        }
    }
}
