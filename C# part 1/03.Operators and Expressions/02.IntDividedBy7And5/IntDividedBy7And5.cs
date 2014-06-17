/* Write a boolean expression that checks for given integer if it 
 * can be divided (without remainder) by 7 and 5 in the same time. */

using System;

namespace _02.IntDividedBy7And5
{
    class IntDividedBy7And5
    {
        static void Main()
        {
            Console.Write("Enter a integer: ");
            int value = int.Parse(Console.ReadLine());
            Console.Write("Number {0} ", value);
            if ((value % 5 == 0) && (value % 7 == 0))
            {
                Console.Write("can ");
            }
            else
            {
                Console.Write("can't ");
            }
            Console.WriteLine("be divided by 5 and 7 at same time w/o remainder");
        }
    }
}
