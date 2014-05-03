using System;
using System.Collections;

class SequenceSum
{
    static void Main()
    {

        /* Write a program that finds in given array of integers a sequence of given sum S (if present). 
         * Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5} */

        Console.Write("Enter array lenght (or 0 for array autogeneration): ");
        int n = int.Parse(Console.ReadLine());
        int[] arr;
        if (n == 0)
        {
            Random rnd = new Random();
            n = rnd.Next(10, 20);
            arr = new int[n];
            Console.WriteLine("Generated N is: {0}", n);
            Console.WriteLine("Generated array is:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(18) - 9;
                Console.Write("{0,3}", arr[i]);
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
        Console.Write("Enter sum to search for: ");
        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine();

        // input is done

        bool noSolution = true;
        int allSum = 0;

        for (int i = 0; i < n; i++) // start form first element to end of array
        {
            allSum = allSum + arr[i]; // sum of a[0]+a[1]+...+a[i];
            int currSum = allSum;
            for (int j = 0; j <= i; j++) // start from first element to i-th element
            {
                if (currSum == sum) // is currnet sum = sum?
                {
                    Console.Write("Sum = {0} ->", sum);
                    for (int k = j; k <= i; k++) //yes - print sequence a[j]...a[i]
                        Console.Write("{0,3}", arr[k]);
                    Console.WriteLine();
                    noSolution = false;
                }
                currSum = currSum - arr[j]; // subtract a[j] from sum a[j]...a[i];
            }
        }
        if(noSolution) 
            Console.WriteLine("No sequence with sum of {0}.",sum);
    }
}
