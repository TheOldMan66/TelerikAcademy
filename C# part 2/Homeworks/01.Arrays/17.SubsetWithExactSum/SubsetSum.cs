using System;
using System.Collections.Generic;

class SubSetSum
{
    static int[] arr;
    static int s;
    static int k;
    static bool solution = false;

    static void Main()
    {

        /*Write a program that reads three integer numbers N, K and S and an array 
         * of N elements from the console. Find in the array a subset of K elements
         * that have sum S or indicate about its absence. */


        //RECURSIVE ALGORITHM!

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        if (n == 0)
        {
            Random rnd = new Random();
            n = rnd.Next(5, 5);
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

        Console.Write("Enter number of elements in subset: ");
        k = int.Parse(Console.ReadLine());
        Console.Write("Enter subset sum to check for: ");
        s = int.Parse(Console.ReadLine());

        // inpit is done.

        List<int> subset = new List<int>();
        MakeSubset(0, subset);
        if (!solution)
            Console.WriteLine("No subset with sum of {0}.", s);

    }

    static void MakeSubset(int index, List<int> subset)
    {
        if (subset.Count == k) // if subset list is exactly K element long
        {
            int sum = 0;
            for (int i = 0; i < subset.Count; i++)
                sum = sum + subset[i]; // calculate sum of K elements
            if (sum == s) // if sum of K elements  = S
            {
                for (int i = 0; i < subset.Count; i++) // print subset
                    Console.Write("{0,3}", subset[i]);
                Console.WriteLine();
                solution = true;
            }
            return;
        }

        for (int i = index; i < arr.Length - k + subset.Count + 1; i++) // subset is exactly K elements long, so no need to check for i > N-K
        {
            subset.Add(arr[i]);
            MakeSubset(i + 1, subset);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}