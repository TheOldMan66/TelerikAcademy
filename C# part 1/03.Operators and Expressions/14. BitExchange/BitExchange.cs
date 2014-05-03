/* Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} 
 * of given 32-bit unsigned integer. */

// My goal is to solve this solutin using only "pure" bitwise operations. Sorry for unreadable expressions.

using System;

namespace _14.BitExchange
{
    class BitExchange
    {
        static void Main()
        {
            Console.Write("Enter unsigned integer value : ");
            uint value = uint.Parse(Console.ReadLine());
            bool incorrectData = false;
            byte startBit = 0;
            byte numOfBits = 0;
            byte destBit = 0;
            do
            {
                do
                {
                    Console.Write("Starting bit: ");
                    startBit = byte.Parse(Console.ReadLine());

                    Console.Write("How much bits to swap : ");
                    numOfBits = byte.Parse(Console.ReadLine());
                    incorrectData = startBit + numOfBits > 31;
                    if (incorrectData)
                        Console.WriteLine("These values exceed int data type range! Try again.");
                } while (incorrectData);
                Console.Write("Where to place bits : ");
                destBit = byte.Parse(Console.ReadLine());
                incorrectData = destBit + numOfBits > 31;
                if (incorrectData)
                {
                    Console.WriteLine("Destination position exceed int data type range! Try again.");
                }
                else
                {
                    incorrectData = startBit + numOfBits > destBit;
                    if (incorrectData)
                    {
                        Console.WriteLine("Source and destiantion regions overlapping! Try again.");
                    }
                }
            } while (incorrectData);
            // Ufff... I hope that input data is correct now

            // Swap start and destination if start > dest (this operation not affect the result)
            if (startBit > destBit)
            {
                byte tmp = startBit;
                startBit = destBit;
                destBit = tmp;
            }

            uint srcMask = (uint.MaxValue - ((uint.MaxValue >> (startBit + numOfBits)) << (startBit + numOfBits)) >> startBit) << startBit;
            Console.WriteLine("Mask to filter left group of bits:   " + PrintInBits(srcMask));
            uint destMask = (uint.MaxValue - ((uint.MaxValue >> (destBit + numOfBits)) << (destBit + numOfBits)) >> destBit) << destBit;
            Console.WriteLine("Mask to filter right group of bits:  " + PrintInBits(destMask));
            uint mask = (uint.MaxValue >> (destBit + numOfBits)) << (destBit + numOfBits);
            mask = mask + ((((uint.MaxValue << (32 - destBit)) >> (32 - destBit)) >> (startBit + numOfBits)) << (startBit + numOfBits));
            mask = mask + (uint.MaxValue << (32 - startBit) >> (32 - startBit));
            Console.WriteLine("Mask to clear places for swaped bits:" + PrintInBits(mask));
            uint result = ((value & mask) | ((value & srcMask) << (destBit - startBit))) | ((value & destMask) >> (destBit - startBit));
            
            // I REFUSE TO EXPLAIN HOW IT'S WORKS :) I... just can't expalin the logic in 2-3 rows only.
            // Please, trace program ant try to understand the logic.
            // I remeber again - my main goal is to solve problem with PURE bitwise operations only
            // (using only AND, OR, SHL & SHR)

            Console.Write("Input value is {0}, binary: ", value);
            Console.SetCursorPosition(37, Console.CursorTop);
            Console.WriteLine(PrintInBits(value));
            Console.Write("Result is {0}, binary: ", result);
            Console.SetCursorPosition(37, Console.CursorTop);
            Console.WriteLine(PrintInBits(result));
        }

        static string PrintInBits(uint val)
        {
            string str = null;
            for (int i = 0; i < 32; i++)
            {
                str = ((val >> i) % 2) + str;
                if (i % 4 == 3)
                {
                    str = " " + str;
                }
            }
            return str;
        }
    }
}