using System;
using System.Collections.Generic;

class BinSearch
{

    private static void PrintArray(int n, int[] arr)
    {
        for (int i = 0; i < n; i++)
            Console.Write("{0,3}", arr[i]);
        Console.WriteLine();
    }

    static void Main()
    {

        /* Write a program, that reads from the console an array of N integers 
         * and an integer K, sorts the array and using the method Array.BinSearch() 
         * finds the largest number in the array which is ≤ K. */

        // version with .net .BinarySearch algorithm

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            Random rnd = new Random();
            n = rnd.Next(10, 20);
            Console.WriteLine();
            Console.WriteLine("Generated N: {0}", n);
            arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(100);
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

        Console.WriteLine("Unsorted array:");
        PrintArray(n, arr);

        Array.Sort(arr);

        Console.WriteLine("Sorted array:");
        PrintArray(n, arr);
        Console.WriteLine();

        Console.Write("Enter value for K: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine();
        int pos = Array.BinarySearch(arr, k);
        if (pos >= 0)
        {
            Console.WriteLine("Largest number in the array which is smaller or equal of {0} is {1}", k, arr[pos]);
        }
        else
        {
            if (pos == -1)
                Console.WriteLine("No such element which is smaller or equal of {0}",k);
            else
                Console.WriteLine("Largest number in the array which is smaller or equal of {0} is {1}", k, arr[-pos - 2]);
        }
    }
}