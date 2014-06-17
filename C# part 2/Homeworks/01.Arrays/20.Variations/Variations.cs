using System;

class Permutations
{
    static int[] result;
    static int k;
    static int n;

    static void Main()
    {

        /* Write a program that reads two numbers N and K and generates all the variations 
         * of K elements from the set [1..N]. Example: N = 3, K = 2  
         * {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3} */

        Console.Write("Enter number of elements for variations: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Enter lenght of variation: ");
        k = int.Parse(Console.ReadLine());
        result = new int[k];

        // input done
        Variate(0);
    }

    static void Variate(int index)
    {
        if (index == k)
        {
            for (int i = 0; i < k; i++)
                Console.Write("{0,3}", result[i]);
            Console.WriteLine();
            return;
        }
        for (int i = 0; i < n; i++)
        {
            result[index] = i + 1;
            Variate(index + 1);
        }
    }
}