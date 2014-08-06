// P.S. I don't know can that be called "refactoring"... This program is rewriten form scratch, form clean white screen... Original code was totally useless.
namespace MatrixWalk
{
    using System;

    public struct Direction
    {
        public int X;
        public int Y;
    }

    public class TestMatrixSolver
    {
        public static void Main(string[] args)
        {
            int[,] matrix = Matrix.Solve(10, 10);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
