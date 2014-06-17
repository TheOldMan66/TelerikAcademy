/* Declare  two integer variables and assign them with 5 and 10 and after that 
 * exchange their values. */

using System;

namespace SwapIntegers
{
    class Program
    {
        static void Main()
        {
            int first = 5;
            int second = 10;
            int swap;

            Console.WriteLine("First value is {0} and second is {1}", first, second);
            swap = first;
            first = second;
            second = swap;
            Console.WriteLine("First value is {0} and second is {1}", first, second);
        }
    }
}
