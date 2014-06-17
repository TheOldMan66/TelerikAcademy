using System;
class FourMatrices
{
    static void Main()
    {

        /* Write a program that fills and prints a matrix of size (n, n) as shown below: 
         * (examples for n = 4) :
         *    A             B           C           D
         * 1 5 9 13     1 8 9 16    7 11 14 16  1 12 11 10
         * 2 6 10 14    2 7 10 15   4 8 12 15   2 13 16 9
         * 3 7 11 15    3 6 11 14   2 5 9 13    3 14 15 8
         * 4 8 12 16    4 5 12 13   1 3 6 10    4 5 6 7
         */
        Console.Write("Enter size of matrix N: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int counter;


        // solution "A"
        Console.WriteLine("Solution A:");
        counter = 1;
        for (int row = 0; row < n; row++)
            for (int col = 0; col < n; col++)
            {
                matrix[col, row] = counter;
                counter++;
            }
        PrintMatrix(n, matrix);

        // solution "B"
        Console.WriteLine("Solution B:");
        counter = 1;
        for (int row = 0; row < n; row++)
            for (int col = 0; col < n; col++)
            {
                if (row % 2 == 0)
                    matrix[col, row] = counter;
                else
                    matrix[n - col - 1, row] = counter;
                counter++;
            }
        PrintMatrix(n, matrix);

        // solution "C"

        Console.WriteLine("Solution C:");
        counter = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            int row = i;
            int col = 0;
            do
            {
                matrix[row, col] = counter;
                col++;
                row++;
                counter++;
            } while (row < n);
        }
        for (int i = 1; i < n; i++)
        {
            int col = i;
            int row = 0;
            do
            {
                matrix[row, col] = counter;
                col++;
                row++;
                counter++;
            } while (col < n);
        }
        PrintMatrix(n, matrix);

        // solution "D"

        Console.WriteLine("Solution D:");
        int leftColumn = 0; // First unfilled row
        int rightColumn = n - 1; // Last unfilled row
        int upperRow = 0; // Left unfilled column
        int bottomRow = n - 1; // Right unfilled column
        int count = 1; // Where we are - form 1 to N*N
        do
        {
            for (int i = upperRow; i <= bottomRow; i++) // place numbers on first available column
            {
                matrix[i, leftColumn] = count;
                count++;
            }
            leftColumn++; // This column is done, no future work with him.

            for (int i = leftColumn; i <= rightColumn; i++) // Fill the bottom row
            {
                matrix[bottomRow, i] = count;
                count++;
            }
            bottomRow--; // row is done, move boundary up

            for (int i = bottomRow; i >= upperRow; i--) // Deal with rightmost column.
            {
                matrix[i, rightColumn] = count;
                count++;
            }
            rightColumn--; // column is done, move boundary left

            for (int i = rightColumn; i >= leftColumn; i--) // and finally work with top available column
            {
                matrix[upperRow, i] = count;
                count++;
            }
            upperRow++; // adjust top limiter for column loops

        } while (count <= n * n);

        PrintMatrix(n, matrix);
    }


    private static void PrintMatrix(int n, int[,] matrix)
    {

        string divider = "+";
        for (int cols = 0; cols < n; cols++)
        {
            divider = divider + "---+";
        }
        Console.WriteLine(divider);
        for (int rows = 0; rows < n; rows++)
        {
            for (int cols = 0; cols < n; cols++)
            {
                Console.Write("|{0,3}", matrix[rows, cols]);
            }
            Console.WriteLine("|");
            Console.WriteLine(divider);
        }
        Console.WriteLine();
    }
}
