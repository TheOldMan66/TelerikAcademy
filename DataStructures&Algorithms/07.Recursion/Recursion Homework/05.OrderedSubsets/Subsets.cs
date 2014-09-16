using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Permutations
{
    class Permutations
    {
        static string[] subsets = new string[] { "hi", "a", "b", "and" };
        static string[] arr;

        static void Permutation(int currentDepth = 0)
        {
            if (currentDepth == arr.Length)
            {
                Console.WriteLine("{" + string.Join(", ", arr) + "}");
                return;
            }

            for (int i = 0; i < subsets.Length; i++)
            {
                arr[currentDepth] = subsets[i];
                Permutation(currentDepth + 1);
            }
        }

        static void Main(string[] args)
        {

            int maxSubsets = 2;
            arr = new string[maxSubsets];
            Permutation();
        }
    }
}
