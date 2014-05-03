using System;

class CompareArrays
{
    /* Write a program that reads two arrays from the console 
     * and compares them element by element. */

    static void Main(string[] args)
    {
        Console.Write("Enter array size:");
        int n = int.Parse(Console.ReadLine());
        int[] arr1 = new int[n];
        int[] arr2 = new int[n];
        Console.WriteLine();
        Console.WriteLine("Enter values for first array:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element {0}: ", i);
            arr1[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        Console.WriteLine("Enter values for second array:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element {0}: ", i);
            arr2[i] = int.Parse(Console.ReadLine());
        }

        bool equal = true;
        for (int i = 0; i < n; i++)
        {
            if (arr1[i] != arr2[i])
            {
                equal = false; // arrays have at least one differnet element, no need to check the rest
                break;
            }
        }
        Console.WriteLine();
        if (equal)
            Console.WriteLine("Arrays are equal.");
        else
            Console.WriteLine("Arrays are different.");
    }
}
