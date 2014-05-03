using System;
using System.Collections.Generic;

class Factorial
{
    static List<int> Multiply(List<int> input1, int input2) // Example: input1 = {9 9 9}, input2 = 9
    {
        // method for multiplying list of ints with int

        List<int> result = new List<int>();
        for (int i = 0; i < input1.Count; i++)
            result.Add(input1[i] * input2);                 // Example: {9 9 9} * 9 -> {81 81 81}

        for (int i = 1; i < input1.Count; i++)
            if (result[i - 1] > 9)
            {
                result[i] = result[i] + result[i - 1] / 10;
                result[i - 1] = result[i - 1] % 10;         // Example: {81 81 81} -> {1 9 89}
            }
        int j = result.Count - 1;
        while (result[j] > 9)
        {
            result.Add(result[j] / 10);         // Example: {1 9 89} -> {1 9 9 8}
            result[j] = result[j] % 10;
            j++;
        }
        return result; // Done, result is reversed. Example: 999 * 9 = 8991
    }

    static void Main()
    {

        /* Write a program to calculate n! for each n in the range [1..100]. 
         * Hint: Implement first a method that multiplies a number represented as 
         * array of digits by given integer number. */

        int n = 0;
        do
        {
            Console.Write("Enter N to calculate N! (or 0 to exit): ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (n == 0) return;

            List<int> res = new List<int>();
            res.Add(1); // "Arm" list for first run with 1! = 1
            for (int i = 2; i <= n; i++)
            {
                List<int> newRes = Multiply(res, i);
                res = newRes;
            }
            Console.Write("{0} factorial is ",n);
            for (int i = res.Count- 1; i >= 0; i--)
                Console.Write(res[i]);
            Console.WriteLine();
        } while (true);
    }
}
