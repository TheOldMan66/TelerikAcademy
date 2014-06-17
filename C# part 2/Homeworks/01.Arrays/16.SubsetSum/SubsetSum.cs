using System;
using System.Collections.Generic;

class SubSetSum
{
    static int[] arr;
    static int s;
    static bool solution = false;
    
    private static void PrintSubset(List<int> subset)
    {
        Console.Write("Sum = {0} ->",s);
        for (int i = 0; i < subset.Count; i++)
        {
            Console.Write("{0,3}", subset[i]);
        }
        Console.WriteLine();
    }

    private static int CalculateSum(List<int> subset)
    {
        int sum = 0;
        for (int i = 0; i < subset.Count; i++)
            sum = sum + subset[i];
        return sum;
    }

    static void MakeSubset(int index, List<int> subset)
    {

        int sum = CalculateSum(subset);
        if (sum == s) // if subset = s print subset members
        {
            PrintSubset(subset);
            solution = true;
        }

        if (subset.Count == arr.Length) // if susbset size = input array size
            return; // nothing to do more, return

        for (int i = index; i < arr.Length; i++)
        {
            subset.Add(arr[i]); // add I-th element to the susbset list
            MakeSubset(i + 1, subset); // call MakeSubset recursively
            subset.RemoveAt(subset.Count - 1); // remove last element 
        }
    }
    
    static void Main()
    {

        /* We are given an array of integers and a number S. Write a program to find 
         * if there exists a subset of the elements of the array that has a sum S.
         * Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6) */


        //RECURSIVE ALGORITHM!

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
        Console.Write("Enter subset sum to check for: ");
        s = int.Parse(Console.ReadLine());

        // inpit is done.

        List<int> subset = new List<int>();
        MakeSubset(0, subset);
        if (!solution)
            Console.WriteLine("No subset with sum of {0}.",s);
    }
}