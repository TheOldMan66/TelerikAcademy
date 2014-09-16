using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girls
{
    class Program
    {
        public static List<int[]> shirtsComb;
        public static List<int[]> skirtsComb;
        public static bool[] used;
        static int[] combinations;
        static int[] permutations;

        static void Combinations(List<int[]> result, int N,int K,int index, int start)
        {
            if (index >= K)
            {
                int[] arr = new int[combinations.Length];
                Array.Copy(combinations, arr, combinations.Length);
                result.Add(arr);
                return;
            }

            for (int i = start; i < N; i++)
            {
                combinations[index] = i;
                Combinations(result, N,K,index + 1, i + 1);
            }
        }

        static void Permutations(List<int[]> result, int N, int K, int index)
        {
            if (index >= K)
            {
                int[] arr = new int[combinations.Length];
                Array.Copy(combinations, arr, combinations.Length);
                result.Add(arr);
                return;
            }

            for (int i = 0; i < N; i++)
            {
                if (used[i]) continue;

                used[i] = true;

                combinations[index] = i;
                Permutations(result, N, K, index + 1);

                used[i] = false;
            }
        }
        static void Main(string[] args)
        {
            int numOfShirts = int.Parse(Console.ReadLine());
            string skirts = Console.ReadLine();
            int numOfSkirts = skirts.Length;
            int numOfGirls = int.Parse(Console.ReadLine());
            shirtsComb = new List<int[]>();
            skirtsComb = new List<int[]>();

            combinations = new int[numOfGirls];
            Combinations(shirtsComb,numOfShirts,numOfGirls,0, 0);
            used = new bool[numOfSkirts];
            Permutations(skirtsComb, numOfSkirts,numOfGirls, 0);
            SortedSet<string> set = new SortedSet<string>();


            skirtsComb = new List<int[]>();


        }
    }
}
