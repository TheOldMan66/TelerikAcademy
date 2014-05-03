using System;

class MaxSum1
{
    static void Main()
    {

        /* Write a program that reads two integer numbers N and K and an array of N elements 
         * from the console. Find in the array those K elements that have maximal sum. 
         
         This version of program will find maximum sum of any K consecutive elements. */

        Console.Write("Enter value for N (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int k;
        int[] arr;
        if (n == 0)
        {
            // random generated array

            Random rnd = new Random();
            n = rnd.Next(20, 30); // array size
            arr = new int[n];
            k = rnd.Next(2, n / 4);
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(19) - 9; // array element
            Console.WriteLine("Generated N is: {0}", n);
            Console.WriteLine("Generated K is: {0}", k);
            Console.WriteLine("Generated array is:");
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", arr[i]);
            Console.WriteLine();
        }
        else
        {
            Console.Write("Enter value for K: ");
            k = int.Parse(Console.ReadLine());
            if (k >= n)
            {
                Console.WriteLine("Wrong input data. Try again!");
                return;
            }
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter value for N[{0}]: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // input is done

        int bestStartPos = 0;
        int bestSum = int.MinValue;
        int sum;
        for (int i = 0; i < n - k + 1; i++) // We search sum of K elements, so 1 < i < N-K
        {
            sum = 0;
            for (int j = 0; j < k; j++) // calculate sum for K elements, startinag at I
                sum = sum + arr[i + j];
            if (sum > bestSum) // current sum is biggest so far?
            {
                bestSum = sum; // save sum
                bestStartPos = i; // and start position of sequence
            }
        }
        Console.WriteLine();
        Console.WriteLine("Maximal sum of {0} consecutive elements is: {1}", k, bestSum);
        Console.WriteLine("Sequence started at pos {0}:", bestStartPos);
        for (int i = 0; i < n; i++)
        {
            if (i == bestStartPos) // some fancy coloring :)
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (i == bestStartPos+k)
                Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}