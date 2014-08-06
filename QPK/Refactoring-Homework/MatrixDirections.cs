namespace MatrixWalk
{
    internal static class MatrixDirections
    {
        private static int currentDirection = 0;

        internal static Direction[] directions = 
        {
            new Direction(){X = 1, Y = 1},
            new Direction(){X = 1, Y = 0},
            new Direction(){X = 1, Y = -1},
            new Direction(){X = 0, Y = -1},
            new Direction(){X = -1, Y = -1},
            new Direction(){X = -1, Y = 0},
            new Direction(){X = -1, Y = 1},
            new Direction(){X = 0, Y = 1}
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
}