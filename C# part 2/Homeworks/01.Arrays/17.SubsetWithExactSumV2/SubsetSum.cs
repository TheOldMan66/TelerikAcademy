using System;

class SubSetSum
{
    static void Main()
    {

        /*Write a program that reads three integer numbers N, K and S and an array 
         * of N elements from the console. Find in the array a subset of K elements
         * that have sum S or indicate about its absence. */

        //ITERATIVE ALGORITHM!

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            Random rnd = new Random();
            n = rnd.Next(20, 30);
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
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter subset sum to check for: ");
        int s = int.Parse(Console.ReadLine());

        // inpit is done.

        int[] markers = new int[k];
        for (int i = 0; i < k; i++)
            markers[i] = i;
        int markPos = k - 1;
        bool noSolution = true;
        do
        {
            int sum = 0;
            for (int i = 0; i < k; i++)
                sum = sum + arr[markers[i]];
            if (sum == s)
            {
                for (int i = 0; i < k; i++)
                    Console.Write("{0,3}", arr[markers[i]]);
                Console.WriteLine();
                noSolution = false;
            }
            markers[k - 1]++;
            if (markers[k - 1] >= arr.Length)
            {
                while ((markPos >= 0) && (markers[markPos] > arr.Length - (k - markPos) - 1))
                    markPos--;
                if (markPos >= 0)
                {
                    markers[markPos]++;
                    for (int i = markPos; i < markers.Length - 1; i++)
                        markers[i + 1] = markers[i] + 1;
                }
            }
        } while (markPos > -1);
        if (noSolution) Console.WriteLine("No subset with sum of {0}.", s);
    }
}