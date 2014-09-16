using System;
using System.Collections.Generic;


namespace _04.Permutations
{
    class Permutations
    {
        static HashSet<string> usedNumbers = new HashSet<string>();
        static string[] setOfStrings = new string[] { "test", "rock", "fun", "drink", "sleep" };
        static string[] currentSet;

        static void Permutation(int start = 0, int currentDepth = 0)
        {
            if (currentDepth == currentSet.Length)
            {
                Console.WriteLine("{" + string.Join(", ", currentSet) + "}");
                return;
            }

            for (int i = start; i < setOfStrings.Length; i++)
            {
                if (!usedNumbers.Contains(setOfStrings[i]))
                {
                    usedNumbers.Add(setOfStrings[i]);
                    currentSet[currentDepth] = setOfStrings[i];
                    Permutation(i + 1, currentDepth + 1);
                    usedNumbers.Remove(setOfStrings[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            int count = 3;
            currentSet = new string[count];
            Permutation();
        }
    }
}
