using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MineSweeper
{
    public class MineSweeper
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] gameBoard = CreateGameBoard();
            char[,] bombGrid = PlaceBombs();
            int revealedCells = 0;
            bool playerIsDead = false;
            List<Player> topPlayers = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool newGame = true;
            const int SAFE_CELLS = 35;
            bool playerWin = false;

            do
            {
                if (newGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    drawBoard(gameBoard);
                    newGame = false;
                }
                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row < gameBoard.GetLength(0) && col < gameBoard.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        ShowHighScores(topPlayers);
                        break;
                    case "restart":
                        gameBoard = CreateGameBoard();
                        bombGrid = PlaceBombs();
                        drawBoard(gameBoard);
                        playerIsDead = false;
                        newGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombGrid[row, col] != '*')
                        {
                            if (bombGrid[row, col] == '-')
                            {
                                MakeTurn(gameBoard, bombGrid, row, col);
                                revealedCells++;
                            }
                            if (SAFE_CELLS == revealedCells)
                            {
                                playerWin = true;
                            }
                            else
                            {
                                drawBoard(gameBoard);
                            }
                        }
                        else
                        {
                            playerIsDead = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (playerIsDead)
                {
                    drawBoard(bombGrid);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. Daj si niknejm: ", revealedCells);
                    string name = Console.ReadLine();
                    Player player = new Player(name, revealedCells);
                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < player.Points)
                            {
                                topPlayers.Insert(i, player);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }
                    topPlayers.Sort((Player player1, Player player2) => player2.Name.CompareTo(player1.Name));
                    topPlayers.Sort((Player player1, Player player2) => player2.Points.CompareTo(player1.Points));
                    ShowHighScores(topPlayers);

                    gameBoard = CreateGameBoard();
                    bombGrid = PlaceBombs();
                    revealedCells = 0;
                    playerIsDead = false;
                    newGame = true;
                }

                if (playerWin)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    drawBoard(bombGrid);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, revealedCells);
                    topPlayers.Add(player);
                    ShowHighScores(topPlayers);
                    gameBoard = CreateGameBoard();
                    bombGrid = PlaceBombs();
                    revealedCells = 0;
                    playerWin = false;
                    newGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowHighScores(List<Player> topPlayers)
        {
            Console.WriteLine("\nTo4KI:");
            if (topPlayers.Count > 0)
            {
                for (int i = 0; i < topPlayers.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, topPlayers[i].Name, topPlayers[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeTurn(char[,] gameBoard, char[,] bombGrid, int row, int col)
        {
            char NeigbhorBombsCount = GetNeigbhorBombs(bombGrid, row, col);
            bombGrid[row, col] = NeigbhorBombsCount;
            gameBoard[row, col] = NeigbhorBombsCount;
        }

        private static void drawBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameBoard()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameBoard = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameBoard[i, j] = '-';
                }
            }

            List<int> bombCoords = new List<int>();
            while (bombCoords.Count < 15)
            {
                Random random = new Random();
                int newBombPlace = random.Next(50);
                if (!bombCoords.Contains(newBombPlace))
                {
                    bombCoords.Add(newBombPlace);
                }
            }

            foreach (int bombCoord in bombCoords)
            {
                int col = (bombCoord / cols);
                int row = (bombCoord % cols);
                if (row == 0 && bombCoord != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                gameBoard[col, row - 1] = '*';
            }

            return gameBoard;
        }

        //private static void smetki(char[,] gameBoard)
        //{
        //    int rows = gameBoard.GetLength(0);
        //    int cols = gameBoard.GetLength(1);

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < cols; j++)
        //        {
        //            if (gameBoard[i, j] != '*')
        //            {
        //                char neighborBombsCount = GetNeigbhorBombs(gameBoard, i, j);
        //                gameBoard[i, j] = neighborBombsCount;
        //            }
        //        }
        //    }
        //}

        private static char GetNeigbhorBombs(char[,] gameBoard, int row, int col)
        {
            int neigbhorBombsCount = 0;
            int rows = gameBoard.GetLength(0);
            int cols = gameBoard.GetLength(1);

            if (row > 0)
            {
                if (gameBoard[row - 1, col] == '*')
                {
                    neigbhorBombsCount++;
                }
            }
            if (row + 1 < rows)
            {
                if (gameBoard[row + 1, col] == '*')
                {
                    neigbhorBombsCount++;
                }
            }
            if (col > 0)
            {
                if (gameBoard[row, col - 1] == '*')
                {
                    neigbhorBombsCount++;
                }
            }
            if (col + 1 < cols)
            {
                if (gameBoard[row, col + 1] == '*')
                {
                    neigbhorBombsCount++;
                }
            }
            if ((row > 0) && (col > 0))
            {
                if (gameBoard[row - 1, col - 1] == '*')
                {
                    neigbhorBombsCount++;
                }
            }
            if ((row > 0) && (col + 1 < cols))
            {
                if (gameBoard[row - 1, col + 1] == '*')
                {
                    neigbhorBombsCount++;
                }
            }
            if ((row + 1 < rows) && (col > 0))
            {
                if (gameBoard[row + 1, col - 1] == '*')
                {
                    neigbhorBombsCount++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (gameBoard[row + 1, col + 1] == '*')
                {
                    neigbhorBombsCount++;
                }
            }
            return char.Parse(neigbhorBombsCount.ToString());
        }
    }
}
