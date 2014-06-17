/* Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
 * Use Windows Character Map to find the Unicode code of the © symbol. 
 * Note: the © symbol may be displayed incorrectly */

using System;
using System.Text;


namespace CopyrightTriangle
{
    class CopyrightTriangle
    {
        static void Main()
        {
            char copyright = '©';
            Console.Write("Enter lenght of the triangle side: ");
            int side = int.Parse(Console.ReadLine());
            Console.WriteLine("First variant of triangle:\n");
            for (int i = 1; i <= side; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(copyright);
                }
                Console.WriteLine();
            }
            Console.WriteLine(); 
            Console.WriteLine("Second (fancy :) ) variant of triangle:\n");
            Console.WriteLine(new string(' ',side - 1) + copyright);
            for (int i = 0; i < side - 2; i++)
            {
                Console.Write(new string(' ',side - i - 2));
                Console.Write(copyright);
                Console.Write(new string(' ', 2 * i + 1));
                Console.WriteLine(copyright);
            }
            Console.WriteLine(new string(copyright,2*side-1));
        }
    }
}
