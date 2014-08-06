namespace MatrixWalk
{
    using System;

    public static class Matrix
    {
        private static Direction currentPosition = new Direction() { X = 0, Y = 0 };
        private static int[,] matrix;

        public static int[,] Solve(int rows, int cols)
        {
            if ((rows == 0) || (cols == 0))
            {
                throw new ArgumentOutOfRangeException("Matrix rows or columns cannot be 0 (Solve)");
            }

            matrix = new int[rows, cols];
            int valueToPlaceInCell = 1;
            int numOfTries = 0;
            do
            {
                do
                {
                    do
                    {
                        if (IsValidPos())
                        {
                            matrix[currentPosition.X, currentPosition.Y] = valueToPlaceInCell;
                            valueToPlaceInCell++;
                        }

                        MakeStep();
                    }
                    while (IsValidPos());
                    numOfTries = 0;
                    while (numOfTries < 9 && !IsValidPos())
                    {
                        GoBack();
                        numOfTries++;
                        MatrixDirections.Next();
                        MakeStep();
                    }
                }
                while (IsValidPos());

                GoBack();
                MatrixDirections.Reset();
            }
            while (FindFirstNonVisitedCell());

            return matrix;
        }

        private static bool Visited(Direction position)
        {
            return matrix[position.X, position.Y] != 0;
        }

        private static bool IsValidPos()
        {
            return currentPosition.X >= 0 && currentPosition.X < matrix.GetLength(0) &&
                    currentPosition.Y >= 0 && currentPosition.Y < matrix.GetLength(1) && !Visited(currentPosition);
        }

        private static void MakeStep()
        {
            // TODO: It will be nice to override "+" operator for Direction type.... 
            currentPosition.X = currentPosition.X + MatrixDirections.GetDirection.X;
            currentPosition.Y = currentPosition.Y + MatrixDirections.GetDirection.Y;
        }

        private static void GoBack()
        {
            // TODO: It will be nice to override "-" operator for Direction type.... 
            currentPosition.X = currentPosition.X - MatrixDirections.GetDirection.X;
            currentPosition.Y = currentPosition.Y - MatrixDirections.GetDirection.Y;
        }

        private static bool FindFirstNonVisitedCell()
        {
            for (currentPosition.Y = 0; currentPosition.Y < matrix.GetLength(1); currentPosition.Y++)
            {
                for (currentPosition.X = 0; currentPosition.X < matrix.GetLength(0); currentPosition.X++)
                {
                    if (!Visited(currentPosition))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
