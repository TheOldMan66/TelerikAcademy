/* Write an expression that extracts from a given integer i the value of a given bit number b.
 * Example: i = 5; b = 2 -> value = 1. */

using System;


namespace _11.ExtractNthBit
{
    class CheckBitN
    {
        static void Main()
        {
            Console.Write("Enter a integer value for I : ");
            int value = int.Parse(Console.ReadLine());
            byte pos;
            do
            {
                Console.Write("Enter a bit position B : ");
                pos = byte.Parse(Console.ReadLine());
                if (pos > 31) Console.WriteLine("Number is too big. Try again.\n");
            } while (pos > 31);

            // (1 << pos) will return integer which have only "pos"-th bit set.
            // Bitwise AND with "value" will return zero if bit is "0" or non-zero if bit is "1"
            int i = (value & (1 << pos)) == 0 ? 0 : 1;
            Console.Write("Bit {0} of {1} is {2}.", pos, value, i);
        }
    }
}