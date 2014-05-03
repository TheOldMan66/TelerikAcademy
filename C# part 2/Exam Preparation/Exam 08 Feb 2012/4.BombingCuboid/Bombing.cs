using System;
using System.Collections.Generic;

class Bombing
{
    static SortedDictionary<char, int> cubeCounter = new SortedDictionary<char, int>();
    static int totalAfectedCells;

    static void ClearAffectedCells(char[, ,] cuboid, int[,] bombs, int bombNum)
    {
        int bombW = bombs[bombNum, 0];
        int bombH = bombs[bombNum, 1];
        int bombD = bombs[bombNum, 2];
        int perimeter = bombs[bombNum, 3] * bombs[bombNum, 3];

        int startW = bombW - bombs[bombNum, 3];
        if (startW < 0) startW = 0;
        int endW = bombW + bombs[bombNum, 3];
        if (endW >= cuboid.GetLength(0)) endW = cuboid.GetLength(0) - 1;

        int startH = bombH - bombs[bombNum, 3];
        if (startH < 0) startH = 0;
        int endH = bombH + bombs[bombNum, 3];
        if (endH >= cuboid.GetLength(1)) endH = cuboid.GetLength(1) - 1;

        int startD = bombD - bombs[bombNum, 3];
        if (startD < 0) startD = 0;
        int endD = bombD + bombs[bombNum, 3];
        if (endD >= cuboid.GetLength(2)) endD = cuboid.GetLength(2) - 1;

        // check for damages
        for (int w = startW; w <= endW; w++)
            for (int h = startH; h <= endH; h++)
                for (int d = startD; d <= endD; d++)
                {
                    char ch = cuboid[w, h, d];
                    if (ch == ' ') continue;
                    int distance = (w - bombW) * (w - bombW) + (h - bombH) * (h - bombH) + (d - bombD) * (d - bombD);
                    if (distance <= perimeter)
                    {
                        if (cubeCounter.ContainsKey(ch))
                            cubeCounter[ch]++;
                        else
                            cubeCounter.Add(ch, 1);
                        cuboid[w, h, d] = ' ';
                        totalAfectedCells++;
                    }
                }

        // fall cubes
        int cubeHeight = cuboid.GetLength(1);
        for (int w = startW; w <= endW; w++)
            for (int d = startD; d <= endD; d++)
            {
                int firstEmpty = startH;
                while (firstEmpty < cubeHeight && cuboid[w, firstEmpty, d] != ' ')
                    firstEmpty++;
                if (firstEmpty == cubeHeight) continue;
                int firstOccupied = firstEmpty;
                while (firstOccupied < cubeHeight && cuboid[w, firstOccupied, d] == ' ')
                    firstOccupied++;
                if (firstOccupied == cubeHeight) continue;
                while (firstOccupied < cubeHeight && cuboid[w, firstOccupied, d] != ' ')
                {
                    cuboid[w, firstEmpty, d] = cuboid[w, firstOccupied, d];
                    cuboid[w, firstOccupied, d] = ' ';
                    firstEmpty++;
                    firstOccupied++;
                }
            }
    }

    static void Main()
    {
        string[] sArray = Console.ReadLine().Split(' ');
        int cuboidW = int.Parse(sArray[0]);
        int cuboidH = int.Parse(sArray[1]);
        int cuboidD = int.Parse(sArray[2]);
        char[, ,] cuboid = new char[cuboidW, cuboidH, cuboidD];
        for (int i = 0; i < cuboidH; i++)
        {
            sArray = Console.ReadLine().Split(' ');
            for (int j = 0; j < cuboidD; j++)
                for (int k = 0; k < cuboidW; k++)
                    cuboid[k, i, j] = sArray[j][k];
        }
        int numOfBombs = int.Parse(Console.ReadLine());
        int[,] bombs = new int[numOfBombs, 4];
        for (int i = 0; i < numOfBombs; i++)
        {
            sArray = Console.ReadLine().Split(' ');
            for (int j = 0; j < 4; j++)
                bombs[i, j] = int.Parse(sArray[j]);
        }
        for (int i = 0; i < numOfBombs; i++)
        {
            ClearAffectedCells(cuboid, bombs, i);
            //            PrintCuboid(cuboid);
        }
        Console.WriteLine(totalAfectedCells);
        foreach (KeyValuePair<char, int> pair in cubeCounter)
            Console.WriteLine("{0} {1}", pair.Key, pair.Value);
    }

    static void PrintCuboid(char[, ,] cuboid)
    {
        Console.WriteLine(new string('-', 50));
        for (int h = 0; h < cuboid.GetLength(1); h++)
        {
            for (int d = 0; d < cuboid.GetLength(2); d++)
            {
                for (int w = 0; w < cuboid.GetLength(0); w++)
                    Console.Write(cuboid[w, h, d]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}