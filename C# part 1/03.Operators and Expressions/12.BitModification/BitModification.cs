/* We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence
 * of operators that modifies n to hold the value v at the position p from the binary
 * representation of n.	Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
	n = 5 (00000101), p=2, v=0 -> 1 (00000001) */

using System;

namespace _12.BitModification
{
    class BitModification
    {
        static void Main()
        {
            Console.Write("Enter a integer number N : ");
            int n = int.Parse(Console.ReadLine());

            byte v = 0;
            do
            {
                Console.Write("Enter value V (0/1) : ");
                v = byte.Parse(Console.ReadLine()); 
                if ((v != 0) & (v != 1))
                    Console.WriteLine("Wrong value. Try again.\n");
            } while ((v != 0) & (v != 1));
            // Now we have error-proof value for v

            byte p = 0;
            do
            {
                Console.Write("Enter position P : ");
                p = byte.Parse(Console.ReadLine());
                if ((p < 0) || (p > 31))
                    Console.WriteLine("Position outside limits of int data type. Try again.\n");
            } while ((p < 0) || (p > 31));
            // And error-proof value for p

            // First we must clear p-th bit
            int mask = ~(1 << p);
            // mask now have some sort of "11..11011..11" value - with only one "0" at p-th pos.

            // Let's make bitwise AND with n
            int result = n & mask;

            // Now is easy: if value "V" is "0" - job is alredy done, else we must set p-th bit
            if (v != 0)
                result = result | (1 << p); // Bitwise OR will set only the p-th bit in result

            Console.WriteLine("Initial value: {0}. {1}-th bit is changed to {2} and result is {3}", n, p, v, result);
        }
    }
}