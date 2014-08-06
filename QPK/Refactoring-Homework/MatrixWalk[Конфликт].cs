using System;

namespace MatrixWalk
{
    internal struct Direction
    {
        public int x;
        public int y;
    }

    internal static class MatrixDirections
    {
        private static int currentDirection = 0;

        private static Direction[] directions = {
            new Direction(){x = 1, y = 1},
            new Direction(){x = 1, y = 0},
            new Direction(){x = 1, y = -1},
            new Direction(){x = 0, y = -1},
            new Direction(){x = -1, y = -1},
            new Direction(){x = -1, y = 0},
            new Direction(){x = -1, y = 1},
            new Direction(){x = 0, y = 1}
        };

        internal static Direction Next()
        {
            currentDirection = (currentDirection + 1) % 8;
            return directions[currentDirection];
        }

        internal static Direction GetDirection
        {
            get
            {
                return directions[currentDirection];
            }
        }


        internal static void Reset()
        {
            currentDirection = 0;
        }
    }

    public static class Matrix
    {
        private static Direction currentPosition = new Direction() { x = 0, y = 0 };
        private static int[,] matrix;

        private static bool Visited(Direction position)
        {
            return matrix[position.x, position.y] != 0;
        }

        private static bool IsValidPos()
        {
            return currentPosition.x >= 0 && currentPosition.x < matrix.GetLength(0) &&
                    currentPosition.y >= 0 && currentPosition.y < matrix.GetLength(1) && !Visited(currentPosition);
        }

        private static void MakeStep()
        {
            //TODO: It will be nice to override "+" operator for Direction type.... 
            currentPosition.x = currentPosition.x + MatrixDirections.GetDirection.x;
            currentPosition.y = currentPosition.y + MatrixDirections.GetDirection.y;
        }
        private static void GoBack()
        {
            //TODO: It will be nice to override "-" operator for Direction type.... 
            currentPosition.x = currentPosition.x - MatrixDirections.GetDirection.x;
            currentPosition.y = currentPosition.y - MatrixDirections.GetDirection.y;
        }

        private static bool FindFirstNonVisitedCell()
        {
            for (currentPosition.y = 0; currentPosition.y < matrix.GetLength(1); currentPosition.y++)
            {
                for (currentPosition.x = 0; currentPosition.x < matrix.GetLength(0); currentPosition.x++)
                {
                    if (!Visited(currentPosition))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static int[,] Solve(int rows, int columns)
        {
            matrix = new int[rows, columns];
            int valueToPlaceInCell = 1;
            bool canContinue = FindFirstNonVisitedCell();
            int numOfTries = 0;
            do
            {
                do
                {
                    do
                    {
                        if (IsValidPos())
                        {
                            matrix[currentPosition.x, currentPosition.y] = valueToPlaceInCell;
                            valueToPlaceInCell++;
                        }
                        MakeStep();
                    } while (IsValidPos());
                    numOfTries = 0;
                    while (numOfTries < 9 && !IsValidPos())
                    {
                        GoBack();
                        numOfTries++;
                        MatrixDirections.Next();
                        MakeStep();
                    }
                } while (IsValidPos());
                GoBack();
                MatrixDirections.Reset();
            } while (FindFirstNonVisitedCell());

            return matrix;
        }
    }

    class MatrixSolver
    {
        static void Main(string[] args)
        {
            int[,] matrix = Matrix.Solve(9, 8);

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