using System;

class MaxSum
{
    static void Main()
    {

        /* Write a program that finds the sequence of maximal sum in given array. Example:
         * {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
         * Can you do it with only one loop (with single scan through the elements of the array)? */

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            //random generated array

            Random rnd = new Random();
            n = rnd.Next(10, 20);
            arr = new int[n];
            Console.WriteLine("Generated N is: {0}", n);
            Console.WriteLine("Generated array is:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(19) - 9;
                Console.Write("{0,3}", arr[i]);
            }
            Console.WriteLine();
        }
        else
        {
            // user enter array vaules
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // input is done

        int maxSum = 0;
        int currSum = 0;
        int maxStart = 0;
        int maxEnd = 0;
        int currStart = 0;
        int maxNegative = int.MinValue;
        bool allNegative = true;
        for (int i = 0; i < arr.Length; i++)
        {
            // Hey, folks! If all elements in array are negative what is "max sum"? :)

            if (allNegative)
            {
                if (arr[i] < 0)
                {
                    if (arr[i] > maxNegative)
                        maxNegative = arr[i];
                }
                else
                    allNegative = false;
            } // end of "all negative" check

            currSum = currSum + arr[i]; // google "Kadane's algorithm" for detailed explanation 
            if (currSum < 0)            // if sum of element so far < 0, all sequence is useless - adding negative 
            {                           // number to next element will not make sequence bigger than if we use only next element
                currStart = i + 1;      // to speak clear - if sum so far is -5, and next value is 3, we get only vaule 3, sum -5 is useless
                currSum = 0;
            }
            else if (currSum > maxSum)
            {
                maxSum = currSum;       // save maximum sum so far
                maxStart = currStart;   // it's start position
                maxEnd = i;             // and it's end position.
            }
        }
        Console.WriteLine();
        if (allNegative)
            Console.WriteLine("All values are negative. Max sequence not exist. Max value is {0}", maxNegative);
        else
        {
            Console.WriteLine("Maximum sum is {0} and start at pos {1}. Sequence is:", maxSum, maxStart);
            for (int i = 0; i < n; i++)
            {
                if (i > maxEnd)
                    Console.ForegroundColor = ConsoleColor.Gray; // coloring max sum sequence
                if (i == maxStart)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0,3}", arr[i]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}