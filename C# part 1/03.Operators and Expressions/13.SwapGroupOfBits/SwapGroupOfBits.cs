/* Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 
 * of given 32-bit unsigned integer. */

using System;

namespace _13.SwapGroupOfBits
{
    class SwapGroupOfBits
    {
        static void Main()
        {
            Console.Write("Enter unsigned integer value : ");
            uint value = uint.Parse(Console.ReadLine());

            // shift input by 3 bits right and get 3 last bits
            uint result = (value >> 3) % 8;

            // shift result by 21 (24-3) bits right. Bit 3 will be at pos 24, 4 at pos 25 and  5 at pos 26
            result = result << 21;

            // now shift input value by 24 pos right and add last 3 bits to result
            result = result + (value >> 24) % 8;

            //shift result by 3 bits left. Bits now are positioned at correct places.
            result = result << 3;

            // Now let's first clear (using bitwise "AND" and mask) bits 3,4,5,24,25 and 26
            // and "inject" (using "OR") "result" variable.
            uint mask = 0xF8FFFFC7; // in binary representation: 1111 1000 1111 1111 1111 1111 1100 0111
            result = (value & mask) | result;

            // Prepare visualisation
            string inpVal = null;
            string outpVal = null;
            for (int i = 0; i < 32; i++)
            {
                inpVal = ((value >> i) % 2) + inpVal; // Yes, i know that string "+" is very slow operation...
                outpVal = ((result >> i) % 2) + outpVal; // I promise to use StringBuilder in future versions :)
                if (i % 4 == 3)
                {
                    inpVal = " " + inpVal; 
                    outpVal = " " + outpVal;
                }
            }
            // "Look, it works!!!"
            Console.WriteLine(" Input value {0} (decimal {1})",inpVal,value);
            Console.WriteLine("Output value {0} (decimal {1})", outpVal, result);
        }
    }
}
