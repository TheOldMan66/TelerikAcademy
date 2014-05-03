/* Write an expression that calculates rectangle’s area by given width and height. */

using System;

namespace _03.RectangleArea
{
    class RectangleArea
    {
        static void Main()
        {
            Console.Write("Enter a rectahgle height: ");
            double heigth = double.Parse(Console.ReadLine());
            Console.Write("Enter a rectahgle width: ");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine("Rectangle’s area is {0}",heigth * width);
        }
    }
}
