using System;
using System.Collections.Generic;

class Program
{

    static void Main()
    {

        string[] sTerrain = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        int[] terrain = new int[sTerrain.Length];
        int terrainLenght = terrain.Length;
        for (int i = 0; i < terrainLenght; i++)
            terrain[i] = int.Parse(sTerrain[i]);
        int maxlen = 0;
        for (int jump = 1; jump < terrainLenght; jump++)
        {
            bool[] used = new bool[terrainLenght];
            for (int startPos = 0; startPos < terrainLenght; startPos++)
            {
                if (used[startPos]) continue;
                int currLen = 1;
                int prevPosValue = terrain[startPos];
                int currPos = (startPos + jump) % terrainLenght;
                while (prevPosValue < terrain[currPos])
                {
                    if (startPos == 0) used[currPos] = true;
                    currLen++;
                    prevPosValue = terrain[currPos];
                    currPos = (currPos + jump) % terrainLenght;
                }
                if (maxlen < currLen)
                    maxlen = currLen;
            }
        }
        Console.WriteLine(maxlen);
    }
}