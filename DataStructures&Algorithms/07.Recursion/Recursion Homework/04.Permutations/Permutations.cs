using System;
using System.Collections.Generic;

namespace _04.Permutations
{
    class Permutations
    {
        static HashSet<int> usedNumbers = new HashSet<int>();
        static int[] arr;

        static void Permutation(int currentDepth = 0)
        {
            if (currentDepth == arr.Length)
            {
                Console.WriteLine("{" + string.Join(", ", arr) + "}");
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                if (!usedNumbers.Contains(i))
                {
                    usedNumbers.Add(i);
                    arr[currentDepth] = i;
                    Permutation(currentDepth + 1);
                    usedNumbers.Remove(i);
                }
            }
        }

        static void Main(string[] args)
        {
            int count = 3;
            arr = new int[count];
            Permutation();
        }
    }
}
