using System;

class Dwarf
{
    static long CountCoins(int[] valley, string strPattern)
    {
        string[] sPatt = strPattern.Split(new string[] {", "},StringSplitOptions.RemoveEmptyEntries);
        bool[] visited = new bool[valley.Length];
        int[] pattern = new int[sPatt.Length];
        int valleyPos = 0;
        int patternPos = 0;
        long count = 0;
        while (valleyPos > -1 && valleyPos < valley.Length && !visited[valleyPos] )
        {
            count = count + valley[valleyPos];
            visited[valleyPos] = true;
            valleyPos = valleyPos + int.Parse(sPatt[patternPos]);
            patternPos = (patternPos + 1) % sPatt.Length;
        }
        return count;
    }

    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] sValley = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        int[] valley = new int[sValley.Length];
        for (int i = 0; i < sValley.Length; i++)
            valley[i] = int.Parse(sValley[i]);
        int numOfPatterns = int.Parse(Console.ReadLine());
        string pattern;
        long maxCoins = int.MinValue;
        long currCoins;
        for (int i = 0; i < numOfPatterns; i++)
        {
            pattern = Console.ReadLine();
            currCoins = CountCoins(valley, pattern);
            if (currCoins > maxCoins)
                maxCoins = currCoins;
        }
        Console.WriteLine(maxCoins);
    }
}