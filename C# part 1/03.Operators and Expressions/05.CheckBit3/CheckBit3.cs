/* Write a boolean expression for finding if the bit 3 (counting from 0) 
 * of a given integer is 1 or 0. */

using System;

namespace _05.CheckBit3
{
    class CheckBit3
    {
        static void Main()
        {
            Console.Write("Enter a integer: ");
            int value = int.Parse(Console.ReadLine());
            Console.Write("Bit 3 of {0} is zero? ", value);
            bool Bit3Is0 = (value & (1 << 3)) == 0;
            Console.WriteLine(Bit3Is0);
        }
    }
}
