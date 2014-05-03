using System;
using System.Collections.Generic;

class IncreasingSubset
{
    static int[] arr;
//    static bool solution = false;
    static int[] maxSubset = new int[1];

    static void Main()
    {
        /* Write a program that reads an array of integers and removes from it a minimal 
         * number of elements in such way that the remaining array is sorted in increasing 
         * order. Print the remaining sorted array. 
         * Example: {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5} */

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        if (n == 0)
        {
            Random rnd = new Random();
            n = rnd.Next(10, 20);
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(19) - 10;
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }
        else
        {
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // inpit is done.

        List<int> subset = new List<int>(); // list for saving current sequence
        MakeSubset(0, subset);

        // calculations is done, let's output

        Console.WriteLine("Longest increasing sequence is:");
        for (int i = 0; i < maxSubset.Length; i++)
        {
            Console.Write("{0,3}", maxSubset[i]);
        }
        Console.WriteLine();
    }

    static void MakeSubset(int index, List<int> subset)
    {
        int ssc = subset.Count; // for easy writing only
        if (ssc > 1 && subset[ssc - 2] > subset[ssc - 1])  // if new,li inserted elemet <= last element
            return;                                         // sequence is broken, exit
        if (ssc >= maxSubset.Length)
        {
            maxSubset = new int[ssc];  // save new longest subset
            subset.CopyTo(maxSubset);
        }
        for (int i = index; i < arr.Length; i++) // try with next item
        {
            subset.Add(arr[i]); // add new item in subset
            MakeSubset(i + 1, subset);
            subset.RemoveAt(subset.Count - 1); // remove last item
        }
    }
}