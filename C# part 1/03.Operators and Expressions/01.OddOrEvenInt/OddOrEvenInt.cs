/* Write an expression that checks if given integer is odd or even */

using System;

namespace _01.OddOrEvenInt
{
    class OddOrEvenInt
    {
        static void Main()
        {
            Console.Write("Enter a integer: ");
            int value = int.Parse(Console.ReadLine());
            Console.Write("Number {0} is ", value);
            if (value % 2 == 1)
            {
                Console.WriteLine("odd.");
            }
            else
            {
                Console.WriteLine("even.");
            }
        }

    }
}
