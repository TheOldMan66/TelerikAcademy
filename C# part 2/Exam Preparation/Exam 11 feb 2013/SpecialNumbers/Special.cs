using System;
using System.Collections.Generic;

class Special
{
    public static int[][] matrix;
    public static bool[][] visited;

    static void ResetVisited(List<int> path)
    {
        for (int i = 0; i < path.Count; i++)
            visited[i % visited.Length][path[i]] = false;
    }


    static void Main()
    {
        int numOfRows = int.Parse(Console.ReadLine());
        matrix = new int[numOfRows][];
        visited = new bool[numOfRows][];
        List<int> path = new List<int>();

        for (int i = 0; i < numOfRows; i++)
        {
            string[] input = Console.ReadLine().Split(',');
            matrix[i] = new int[input.Length];
            visited[i] = new bool[input.Length];
            for (int j = 0; j < matrix[i].Length; j++)
                matrix[i][j] = int.Parse(input[j].Trim());
        }
        int maxValue = 0;
        for (int i = 0; i < matrix[0].Length; i++)
        {
            ResetVisited(path);
            path.Clear();
            int row = 0;
            int column = i;
            do
            {
                path.Add(column);
                visited[row][column] = true;
                if (matrix[row][column] < 0)
                {
                    if (maxValue < path.Count - matrix[row][column])
                        maxValue = path.Count - matrix[row][column];
                    break;
                }
                column = matrix[row][column];
                row = (row + 1) % numOfRows;
            } while (!visited[row][column]);
        }
        Console.WriteLine(maxValue);
    }
}