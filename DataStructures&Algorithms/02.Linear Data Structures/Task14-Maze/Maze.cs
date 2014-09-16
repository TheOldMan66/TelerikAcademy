using System;

class Labyrith
{
    static string[,] grid = new string[,]
    {{ "0", "0", "0", "x", "0", "x" },
     { "0", "x", "0", "x", "0", "x" },
     { "0", "*", "x", "0", "x", "0" },
     { "0", "x", "0", "0", "0", "0" },
     { "0", "0", "0", "x", "x", "0" },
     { "0", "0", "0", "x", "0", "x" }};

    static bool IsInsideMaze(int row, int col)
    {
        bool isInside = (row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1));
        return isInside;
    }
    static void MoveToNextCell(int row, int col, int distance)
    {
        if (!IsInsideMaze(row, col) || grid[row, col] == "x")
        {
            return;
        }

        if (grid[row, col] == "0" || grid[row, col] == "*" || int.Parse(grid[row, col]) > distance)
        {
            if (grid[row, col] != "*")
            {
                grid[row, col] = distance.ToString();
            }

            MoveToNextCell(row + 1, col, distance + 1);
            MoveToNextCell(row - 1, col, distance + 1);
            MoveToNextCell(row, col + 1, distance + 1);
            MoveToNextCell(row, col - 1, distance + 1);
        }
    }

    static void PrintGrid()
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(0); col++)
            {
                if (grid[row, col] == "0")
                {
                    grid[row, col] = "u";
                }

                Console.Write("{0,3}", grid[row, col]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.WriteLine("We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x). " +
        "We can move from an empty cell to another empty cell if they share common wall. " +
        "Given a starting position (*) calculate and fill in the array the minimal distance from this " +
        "position to any other cell in the array. Use 'u' for all unreachable cells.");

        int startRow = 2;
        int startCol = 1;

        MoveToNextCell(startRow, startCol,0);

        PrintGrid();
    }
}