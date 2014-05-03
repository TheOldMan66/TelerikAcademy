using System;

class SelectionSort
{
    static void Main()
    {

        /* Sorting an array means to arrange its elements in increasing order. Write a program to 
         * sort an array. Use the "selection sort" algorithm: Find the smallest element, move it 
         * at the first position, find the smallest from the rest, move it at the second position, etc. */

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            // random generated array
            Random rnd = new Random();
            n = rnd.Next(10, 20);
            arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(100);
        }
        else
        {
            // user input for array elements
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Element {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // inpit is done.

        Console.WriteLine();
        Console.WriteLine("Unsorted array:");
        for (int i = 0; i < n; i++)
            Console.Write("{0,3}", arr[i]);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Sorting process:"); // some visualisation of wirking process
        for (int i = 0; i < n - 1; i++) // starting at first element
        {
            int min = arr[i]; // current smallest element is first one
            int swapPos = -1; // we dont know which element will swap
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < min) // J-th element is smaller than currently smallest?
                {
                    min = arr[j]; // yes, remember it's value
                    swapPos = j; // at it's position
                }
            }
            if (swapPos > -1) // if swapPos = -1, first element was smallest, no swaps needed
            {
                int tmp = arr[i]; // swap elements
                arr[i] = arr[swapPos];
                arr[swapPos] = tmp;
            }
            Console.Write("Step {0,2} ->", i); // again some otuput of working process
            for (int j = 0; j < n; j++)
            {
                if (swapPos > -1 && (j == swapPos || j == i)) // paint swapped elements with yellow color
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0,3}", arr[j]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Sorting is done.");
    }
}
