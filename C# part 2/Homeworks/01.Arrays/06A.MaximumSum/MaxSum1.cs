using System;

class MaxSum1
{
    static void Main()
    {

        /* Write a program that reads two integer numbers N and K and an array of N elements 
         * from the console. Find in the array those K elements that have maximal sum. 
         
         This version of program will find maximum sum of any K elements, not K consecutive elements.*/

        // Condition is ... little unclear, so I make two variants of this solution. This one is "for dummies" :)

        Console.Write("Enter value for N (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int k;
        int[] arr;
        if (n == 0)
        {
            Random rnd = new Random();
            n = rnd.Next(20, 30);
            arr = new int[n];
            k = rnd.Next(2, n / 4);
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(20)-10;
            Console.WriteLine("Generated N is: {0}",n);
            Console.WriteLine("Generated K is: {0}",k);
            Console.WriteLine("Generated array is:");
            for (int i = 0; i < n; i++)
                Console.Write("{0,3}", arr[i]);
            Console.WriteLine();
        }
        else
        {
            Console.Write("Enter value for K: ");
            k = int.Parse(Console.ReadLine());
            if (k >= n)
            {
                Console.WriteLine("Wrong input data. Try again!");
                return;
            }
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter value for N[{0}]: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        // input is done

        Array.Sort(arr);
        int sum = 0;
        Console.Write("Elements are: ");
        for (int i = 0; i < k; i++)
        {
            sum = sum + arr[n - i - 1];
            Console.Write("{0,3}", arr[n - i - 1]);
        }
        Console.WriteLine();
        Console.WriteLine("Maximum sum of {0} elements of this array is {1}", k, sum);
    }
}
