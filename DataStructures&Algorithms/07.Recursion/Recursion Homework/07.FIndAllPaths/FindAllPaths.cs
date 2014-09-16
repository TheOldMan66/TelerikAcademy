using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PathBetweenTwoCells
{
    public class MazeCell : IEquatable<MazeCell>
    {
        public int row;
        public int col;


        public bool Equals(MazeCell other)
        {
            return this.row == other.row && this.col == other.col;
        }

        public override string ToString()
        {
            return "(" + this.row + "," + this.col + ")";
        }

        public void ShowCell()
        {
            Console.SetCursorPosition(this.col, this.row);
            Console.Write('*');
        }
        public void HideCell()
        {
            Console.SetCursorPosition(this.col, this.row);
            Console.Write(' ');
        }

    }

    class MazeSolver
    {
        public bool[,] maze;
        public string[] strMaze = new string[]
        {
        " x     x   x     x  ",
        " x xxx xxx x xxx xxx",
        "   x   x   x       x",
        " x x xxx x xxx xxx x",
        "       x x     x   x",
        "x xxxx x x x xxx xxx",
        "   x     x   x   x  ",
        " xxx xx xx x x x x x",
        "     x     x   x x  ",
        " xx xxxx x x xxx xxx",
        "     x   x         x",
        "xx x x xxx x xx xx x",
        "   x x   x       x x",
        " xxx x x xxx xxx x x",
        " x       x       x  ",
        " xxxxx x x x x x x x",
        "   x   x   x   x x  ",
        "xx x x xxx x x x x x",
        "   x x   x   x x   "};


        public void GenrateMaze()
        {
            maze = new bool[strMaze.Length, strMaze[0].Length];
            for (int i = 0; i < strMaze.Length; i++)
            {
                for (int j = 0; j < strMaze[i].Length; j++)
                {
                    maze[i, j] = strMaze[i][j] == ' ';
                }
            }

            foreach (var row in strMaze)
            {
                Console.WriteLine(row);
            }
        }


        public bool IsFree(MazeCell cell)
        {
            if (cell.row >= 0 && cell.row < maze.GetLength(0) && cell.col >= 0 && cell.col < maze.GetLength(1))
            {
                return maze[cell.row, cell.col];
            }
            else
            {
                return false;
            }
        }


        private Stack<MazeCell> route = new Stack<MazeCell>();

        bool RecursiveSolver(MazeCell endCell)
        {

            bool routeFound = false;
            MazeCell currentCell = new MazeCell();
            currentCell.row = route.Peek().row;
            currentCell.col = route.Peek().col;

            if (currentCell.Equals(endCell))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                endCell.ShowCell();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, maze.GetLength(0) + 1);
                Console.WriteLine("Path found. Press ENTER to try another route");
                Console.ReadLine();
                Console.SetCursorPosition(0, maze.GetLength(0) + 1);
                Console.WriteLine(new string(' ', 50));
                return true;
            }

            currentCell.row = currentCell.row - 1;
            if (IsFree(currentCell) && !route.Contains(currentCell))
            {
                route.Push(currentCell);
                currentCell.ShowCell();
                RecursiveSolver(endCell);
                currentCell.HideCell();
                route.Pop();
            }

            currentCell.row = currentCell.row + 2;
            if (IsFree(currentCell) && !route.Contains(currentCell))
            {
                route.Push(currentCell);
                currentCell.ShowCell();
                RecursiveSolver(endCell);
                currentCell.HideCell();
                route.Pop();
            }

            currentCell.row = currentCell.row - 1;
            currentCell.col = currentCell.col - 1;
            if (IsFree(currentCell) && !route.Contains(currentCell))
            {
                route.Push(currentCell);
                currentCell.ShowCell();
                RecursiveSolver(endCell);
                currentCell.HideCell();
                route.Pop();
            }

            currentCell.col = currentCell.col + 2;
            if (IsFree(currentCell) && !route.Contains(currentCell))
            {
                route.Push(currentCell);
                currentCell.ShowCell();
                RecursiveSolver(endCell);
                currentCell.HideCell();
                route.Pop();
            }

            return routeFound;
        }

        public bool SolveMaze(MazeCell startCell, MazeCell endCell)
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 50;

            Console.SetCursorPosition(0, maze.GetLength(0) + 1);
            Console.WriteLine("Press ENTER to find the route");
            Console.ForegroundColor = ConsoleColor.Yellow;
            endCell.ShowCell();
            startCell.ShowCell();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ReadLine();
            route.Push(startCell);
            bool success = RecursiveSolver(endCell);

            Console.ForegroundColor = ConsoleColor.Yellow;
            startCell.ShowCell();
            endCell.ShowCell();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.SetCursorPosition(0, maze.GetLength(0));
            Console.WriteLine(string.Join(", ", route));
            Console.WriteLine("Start: " + startCell + ", End: " + endCell);
            if (success)
            {
                Console.WriteLine("Route found");
            }
            else
            {
                Console.WriteLine("No route between points");
            }
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
            return success;
        }

    }

    class FindPathBetweenPoints
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            MazeSolver solver = new MazeSolver();
            solver.GenrateMaze();

            MazeCell startCell = new MazeCell();
            do
            {
                startCell.row = rnd.Next(Math.Min(solver.maze.GetLength(0), solver.maze.GetLength(1)));
                startCell.col = rnd.Next(Math.Min(solver.maze.GetLength(0), solver.maze.GetLength(1)));
            } while (!solver.IsFree(startCell));


            MazeCell endCell = new MazeCell();
            do
            {
                endCell.row = rnd.Next(Math.Min(solver.maze.GetLength(0), solver.maze.GetLength(1)));
                endCell.col = rnd.Next(Math.Min(solver.maze.GetLength(0), solver.maze.GetLength(1)));

            } while (!solver.IsFree(endCell));
            Console.WriteLine("Start:" + startCell + " End: " + endCell);
            solver.SolveMaze(startCell, endCell);
        }
    }
}
