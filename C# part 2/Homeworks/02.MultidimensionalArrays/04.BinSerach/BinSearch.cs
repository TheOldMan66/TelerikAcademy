using System;
using System.Collections.Generic;

class BinSearch
{
    static void Main()
    {

        /* Write a program, that reads from the console an array of N integers 
         * and an integer K, sorts the array and using the method Array.BinSearch() 
         * finds the largest number in the array which is ≤ K. */
        
        // Statement is unclear. This variant work with my own BinSearch algorithm

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

        MyMergeSort(arr);

        Console.WriteLine("Sorted array:");
        PrintArray(n, arr);
        Console.WriteLine();

        Console.Write("Enter value for K: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine();
        int left = 0;
        int right = arr.Length - 1;
        int marker = arr.Length / 2;
        do
        {
            if (arr[marker] > k)
            {
                right = marker - 1;
                marker = left + (right - left) / 2;
            }
            else if (arr[marker] < k)
            {
                left = marker + 1;
                marker = left + (right - left) / 2;
            }
            else
                break;
        } while (right >= left);
        if (right < 0)
        {
            Console.WriteLine("No value smaller than {0}", k);
        }
        else
        {
            Console.WriteLine("Value which is <= {0} is {1}", k, arr[right]);
        }
    }

    private static void PrintArray(int n, int[] arr)
    {
        for (int i = 0; i < n; i++)
            Console.Write("{0,3}", arr[i]);
        Console.WriteLine();
    }

    static void MyMergeSort(int[] array)
    {
        if (array.Length < 2)
            return;
        int[] leftArray = new int[array.Length / 2];
        int[] rigthArray = new int[array.Length - leftArray.Length];
        Array.Copy(array, 0, leftArray, 0, leftArray.Length);
        Array.Copy(array, leftArray.Length, rigthArray, 0, rigthArray.Length);
        MyMergeSort(leftArray);
        MyMergeSort(rigthArray);
        int leftMarker = 0;
        int rightMarker = 0;
        do
        {
            if (leftArray[leftMarker] < rigthArray[rightMarker])
            {
                array[leftMarker + rightMarker] = leftArray[leftMarker];
                leftMarker++;
            }
            else
            {
                array[leftMarker + rightMarker] = rigthArray[rightMarker];
                rightMarker++;
            }
        } while (leftMarker < leftArray.Length && rightMarker < rigthArray.Length);
        for (int i = leftMarker; i < leftArray.Length; i++)
            array[i + rightMarker] = leftArray[i];
        for (int i = rightMarker; i < rigthArray.Length; i++)
            array[leftMarker + i] = rigthArray[i];
    }
}