using System;
using System.Collections.Generic;

class ConvertFromAnyToAny
{
    static void Main()
    {
        /* Write a program to convert from any numeral system of given base s 
         * to any other numeral system of base d (2 ≤ s, d ≤ 16). */

        List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', 
                                                  '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        Console.Write("Enter source base: ");
        byte sourceBaseSystem = byte.Parse(Console.ReadLine());
        Console.Write("Enter destinationa base: ");
        byte destinationBaseSystem = byte.Parse(Console.ReadLine());
        Console.Write("Enter number in base of {0} to convert to base of {1} : ", sourceBaseSystem, destinationBaseSystem);
        string input = Console.ReadLine().ToUpper();
        ulong inputBase10 = 0;
        for (int i = 0; i < input.Length; i++)
        {
            inputBase10 = inputBase10 * sourceBaseSystem;
            byte tmp = (byte)numbers.IndexOf(input[i]);
            if (tmp > sourceBaseSystem)
            {
                Console.WriteLine("Wrong number. Try again");
                return;
            }
            inputBase10 = inputBase10 + (ulong)tmp;
        }
        Console.WriteLine("Number {0} in base of {1} have decimal representation of {2}", input, sourceBaseSystem, inputBase10);
        string output = "";
        while (inputBase10 > 0)
        {
            output = numbers[(int)(inputBase10 % destinationBaseSystem)] + output;
            inputBase10 = inputBase10 / destinationBaseSystem;
        }
        Console.WriteLine("Number {0} entered in base {1} is {2} in base {3}",input,sourceBaseSystem,output,destinationBaseSystem);
    }
}