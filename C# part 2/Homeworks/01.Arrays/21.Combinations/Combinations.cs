using System;

class Combinations
{
    static int[] result;
    static int k;
    static int n;

    static void Main()
    {

        /* Write a program that reads two numbers N and K and generates all the combinations 
         * of K distinct elements from the set [1..N]. Example: N = 5, K = 2  
         * {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5} */

        Console.Write("Enter number of elements for combinations: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Enter lenght of combination: ");
        k = int.Parse(Console.ReadLine());
        result = new int[k];

        // input done
        Combine(0,1);
    }

    static void Combine(int index, int startValue)
    {
        if (index == k)
        {
            for (int i = 0; i < k; i++)
                Console.Write("{0,3}", result[i]);
            Console.WriteLine();
            return;
        }
        for (int i = startValue; i <= n; i++)
        {
            result[index] = i;
            Combine(index + 1,i+1);
        }
    }
}