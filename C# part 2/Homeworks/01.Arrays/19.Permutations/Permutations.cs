using System;
using System.Collections.Generic;

    class Permutations
    {
        static int[] result;
        
        static void Main()
        {

            /* Write a program that reads a number N and generates and prints all the 
             * permutations of the numbers [1 … N]. Example: n = 3  
             * {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1} */

            Console.Write("Enter number of elements for permutation: ");
            int n = int.Parse(Console.ReadLine());
            List<int> perm = new List<int>();
            result = new int[n];
            for (int i = 1; i <= n; i++)
                perm.Add(i);
            // input done
            Permutate(perm);
        }

        static void Permutate(List<int> perm)
        {
            if (perm.Count == 0)
            {
                for (int i = 0; i < result.Length; i++)
                    Console.Write("{0,3}",result[i]);
                Console.WriteLine();
                return;
            }
            for (int i = 0; i < perm.Count; i++)
            {
                result[result.Length - perm.Count] = perm[i];
                perm.RemoveAt(i);
                Permutate(perm);
                perm.Insert(i, result[result.Length - perm.Count-1]);
            }
        }
    }