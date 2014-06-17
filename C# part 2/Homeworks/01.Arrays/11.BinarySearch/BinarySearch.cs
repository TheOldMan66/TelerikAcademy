using System;

class Program
{
    static void Main()
    {

        /* Write a program that finds the index of given element in a sorted array of integers 
         * by using the binary search algorithm (find it in Wikipedia). */

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            Random rnd = new Random();
            n = rnd.Next(10, 20);
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

        Array.Sort(arr);
        Console.WriteLine();
        Console.WriteLine("Sorted array:");
        for (int i = 0; i < n; i++)
            Console.Write("{0,3}", arr[i]);
        Console.WriteLine();
        Console.Write("Enter number in range 0..100: ");
        int serachValue = int.Parse(Console.ReadLine());
        Console.WriteLine();
        int left = 0;
        int right = arr.Length - 1;
        int marker = arr.Length / 2;
        do
        {
            Console.Write("Searching in: ");
            for (int i = left; i <= right; i++)
                Console.Write("{0,3}", arr[i]);
            Console.WriteLine();
            if (arr[marker] > serachValue)
            {
                right = marker - 1;
                marker = left + (right - left) / 2;
            }
            else if (arr[marker] < serachValue)
            {
                left = marker + 1;
                marker = left + (right - left) / 2;
            }
            else
                break;
        } while (right >= left);
        Console.WriteLine("Search is done.");
        if (marker == arr.Length)
        {
            Console.WriteLine("Value {0} not exist in array, but it's position is after last element ({0}).", serachValue, arr[arr.Length - 1]);
            return;
        }
        if (arr[marker] == serachValue)
            Console.WriteLine("Index of {0} in array is {1}.", serachValue, marker);
        else
        {
            Console.Write("Value {0} not exist in array, but it's position is ", serachValue);
            if (right < 0)
                Console.WriteLine("before first element ({0}).", arr[0]);
            else
                Console.WriteLine("between elements {0} and {1}.", arr[right], arr[left]);
        }
    }
}
