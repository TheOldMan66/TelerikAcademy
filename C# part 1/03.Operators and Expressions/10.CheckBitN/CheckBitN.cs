/* Write a boolean expression that returns if the bit at position p (counting from 0) 
 * in a given integer number v has value of 1. Example: v=5; p=1  false. */

using System;

namespace _10.CheckBitN
{
    class CheckBitN
    {
        static void Main()
        {
            Console.Write("Enter a integer value for V : ");
            int value = int.Parse(Console.ReadLine());
            byte pos;
            do
            {
                Console.Write("Enter a bit position P : ");
                pos = byte.Parse(Console.ReadLine());
                if (pos > 32) Console.WriteLine("Number is too big. Try again.\n");
            } while (pos > 32);
            Console.Write("Bit {0} of {1} is zero? ", pos, value);
            bool BitPIs1 = (value & (1 << pos)) == 0;
            Console.WriteLine(BitPIs1);
        }
    }
}
