using System;
using System.Text;

static class Table
{
    private static int boardWidth = 70;
    private static int boardHeight = 24;
    private static int cellWidth = 3;
    private static int barWidth = 5;
    // element [0] is unused (for now)
    public static int[] piles = { 0, 2, 0, 0, 0, 0, -5, 0, -3, 0, 0, 0, 5, -5, 0, 0, 0, 3, 0, 5, 0, 0, 0, 0, -2 };
    //    public static int[] piles = { 0, 2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, };
    public static int[] jail = { 0, 0 };
    public static int[] safe = { 0, 0 };

    public static void DrawTable() // draw empty table
    {
        Console.Clear();
        Console.Title = "Backgammon game";
        Console.SetWindowSize(boardWidth, boardHeight);
        Console.OutputEncoding = Encoding.Unicode;

        // prepare some strings
        string upperBorder = " +" + new string('-', 6 * cellWidth) + '+' + new string('-', barWidth) + '+' + new string('-', 6 * (cellWidth)) + "+";
        string cellRow = " |";
        for (int i = 0; i < 12; i++)
        {
            cellRow = cellRow + new string(' ', cellWidth);
            if (i == 5)
                cellRow = cellRow + "|" + new string(' ', barWidth) + "|";
        }
        cellRow = cellRow + "|";

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(new string(' ', boardWidth));

        Console.Write("  "); // row with numbers 13-24
        string numStr = string.Empty;
        for (int i = 13; i < 25; i++)
        {
            numStr = (i.ToString() + " ").PadLeft(cellWidth);
            Console.Write(numStr);
            if (i == 18)
                Console.Write(new string(' ', barWidth + 2));
        }
        Console.WriteLine(" ".PadRight(boardWidth - Console.CursorLeft));

        Console.WriteLine(upperBorder.PadRight(boardWidth));

        for (int i = 0; i < 18; i++) // 18 empty rows
            Console.WriteLine(cellRow.PadRight(boardWidth));

        Console.WriteLine(upperBorder.PadRight(boardWidth)); // bottom border

        Console.Write("  ");
        for (int i = 12; i > 0; i--) // row with numbers 12-1
        {
            numStr = (i.ToString() + " ").PadLeft(cellWidth);
            Console.Write(numStr);
            if (i == 7)
                Console.Write(new string(' ', barWidth + 2));
        }
        Console.WriteLine(" ".PadRight(boardWidth - Console.CursorLeft));

        Console.Write(new string(' ', boardWidth));
        Console.SetCursorPosition(12 * cellWidth + barWidth + 6, 2);
    }

    private static int PileX(int pileNo) // calculate x position of pile
    {
        int posX;
        if (pileNo > 12)
        {
            posX = (pileNo - 12) * cellWidth;
            if (pileNo > 18)
                posX = posX + barWidth + 2;
        }
        else
        {
            posX = (13 - pileNo) * cellWidth;
            if (pileNo < 7)
                posX = posX + barWidth + 2;
        }
        return posX;
    }

    public static void DrawPile(ConsoleColor color, int pileNo) // draw pile
    {
        int absPileValue;
        int posY = pileNo > 12 ? 3 : 20;
        int posX = PileX(pileNo);
        Console.ForegroundColor = color;
        for (int i = 1; i < 9; i++)
        {
            absPileValue = Math.Abs(piles[pileNo]);
            if (i > absPileValue)
            {
                Console.SetCursorPosition(posX - 1, posY);
                Console.Write("  ");
                continue;
            }
            if (absPileValue / 8 > 0 && absPileValue % 8 >= i)
            {
                Console.SetCursorPosition(posX - 1, posY);
                Console.Write("OO");
            }
            else
            {
                Console.SetCursorPosition(posX - 1, posY);
                Console.Write(" O");
            }
            posY = posY + (pileNo > 12 ? 1 : -1);
        }
    }

    public static void DrawDices() // draw two dices
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(6 * cellWidth + barWidth - 1, 7);
        Console.Write("+-+");
        Console.SetCursorPosition(6 * cellWidth + barWidth - 1, 8);
        if (Dices.diceA == 0)
        {
            Console.Write("|X|");
        }
        else
        {
            Console.Write("|{0}|", Dices.diceA);
        }
        Console.SetCursorPosition(6 * cellWidth + barWidth - 1, 9);
        Console.Write("+-+");
        Console.SetCursorPosition(6 * cellWidth + barWidth - 1, 11);
        Console.Write("+-+");
        Console.SetCursorPosition(6 * cellWidth + barWidth - 1, 12);
        if (Dices.diceB == 0)
            Console.Write("|X|");
        else
            Console.Write("|{0}|", Dices.diceB);
        Console.SetCursorPosition(6 * cellWidth + barWidth - 1, 13);
        Console.Write("+-+");
    }

    public static void DrawJail(Player player) // draw player jail
    {
        Console.ForegroundColor = player.color;
        int posY = player.number == 0 ? 19 : 3;
        int posX = 7 * cellWidth;
        Console.SetCursorPosition(posX, posY);
        if (Table.jail[player.number] > 0)
            Console.Write("JAIL");
        else
            Console.Write("    ");
        Console.SetCursorPosition(posX + 2, posY + 1);
        if (Table.jail[player.number] > 0)
            Console.Write("{0,2}", Table.jail[player.number]);
        else
            Console.Write("  ");
    }

    public static void DrawSafe(Player player) // draw player safe
    {
        Console.ForegroundColor = player.color;
        int posY = player.number == 0 ? 5 : 17;
        int posX = 7 * cellWidth;
        Console.SetCursorPosition(posX, posY);
        if (Table.safe[player.number] > 0)
            Console.Write("SAFE");
        else
            Console.Write("    ");
        Console.SetCursorPosition(posX + 2, posY + 1);
        if (Table.safe[player.number] > 0)
            Console.Write("{0,2}", Table.safe[player.number]);
        else
            Console.Write("  ");
    }

    public static void PrintMessage(ConsoleColor color, string message) // print some mesage
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(12 * cellWidth + barWidth + 7, 8);
        if (message.Length > 0)
            Console.Write(message);
        else
            Console.WriteLine("                  ");
    }

    public static void PrintPlayer(Player player) // print player name
    {
        Console.ForegroundColor = player.color;
        Console.SetCursorPosition(12 * cellWidth + barWidth + 7, 4);
        Console.Write(player.name.PadRight(15));
        Console.SetCursorPosition(12 * cellWidth + barWidth + 7, 5);
        Console.WriteLine(new string(' ', 15));
        Console.SetCursorPosition(12 * cellWidth + barWidth + 7, 6);
        Console.WriteLine(new string(' ', 15));
    }


    public static void PrepareForUserInput(ConsoleColor color, int diceNo)
    {
        Console.ForegroundColor = color;
        if (diceNo == 0)
        {
            Console.SetCursorPosition(12 * cellWidth + barWidth + 7, 5);
            Console.WriteLine("From pile:        ");
            Console.SetCursorPosition(12 * cellWidth + barWidth + 7, 6);
            Console.WriteLine("  To pile:        ");
            Console.SetCursorPosition(12 * cellWidth + barWidth + 18, 5);
            return;
        }
        else
        {
            Console.SetCursorPosition(12 * cellWidth + barWidth + 18, 6);
            return;
        }
    }

    public static void PaintPileSign(ConsoleColor color, int pile)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(PileX(pile) - 1, pile > 12 ? 1 : 22);
        Console.WriteLine("{0,2}", pile + 1);
    }

    public static void MoveDice(Player player, int fromPos, int toPos)
    {
        if (fromPos == -1)
        {
            jail[player.number]--;
            DrawJail(player);
        }
        else
        {
            piles[fromPos] = piles[fromPos] - player.direction; // get one checker from pile (value -1 for player, or value +1 for computer)
            DrawPile(player.color, fromPos);
        }
        if (toPos == 0)
        {
            safe[player.number]++;
            DrawSafe(player);
            return;
        }
        if (piles[toPos] * player.direction < 0)    //if enemy checker is on destination pile
        {
            jail[1 - player.number]++;
            DrawJail(player.enemy);
            piles[toPos] = 0;
        }
        piles[toPos] = piles[toPos] + player.direction;
        DrawPile(player.color, toPos);
    }
}


static class Dices
{
    public static int diceA;
    public static int diceB;
    static Random rnd = new Random();


    public static void Roll()
    {
        diceA = rnd.Next(1, 7);
        diceB = rnd.Next(1, 7);
        Table.DrawDices();
    }
}

class Player
{
    public string name;
    public int number;
    public int direction;
    public ConsoleColor color;
    public Player enemy;
    public bool isComputer;
    public bool allIn; // if all checkers is in safe zone and can be collected
    public int lastPilePosition;


    public Player(int number)
    {
        this.number = number;
        if (number == 0)
        {
            color = ConsoleColor.White;
            direction = 1;
        }
        else
        {
            color = ConsoleColor.Red;
            direction = -1;
        }
    }

    public void SetType()
    {
        Console.Write("Player {0}: ", this.number + 1);
        //        Console.CursorVisible = false;
        int cursorPosX = Console.CursorLeft;
        int cursorPosY = Console.CursorTop;
        ConsoleKeyInfo userInput;
        string[] choices = { "COMPUTER", "HUMAN   " };
        int i = 0;
        do
        {
            Console.SetCursorPosition(cursorPosX, cursorPosY);
            Console.Write(choices[i]);
            userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.Spacebar)
                i = (i + 1) % 2;
        } while (userInput.Key != ConsoleKey.Enter);
        Console.WriteLine();
        if (i == 0)
        {
            isComputer = true;
            name = "COMPUTER";
        }
        else
        {
            isComputer = false;
            Console.Write("Enter name for player {0}: ", number + 1);
            name = Console.ReadLine();
            if (name == "")
                name = "Player " + (number + 1).ToString();
        }
    }

    public bool CheckForAvailableMove(int dice)
    {
        if (dice == 0)
            return false;
        if (number == 0)
        {
            allIn = true;
            if (Table.jail[number] > 0)             // if there is checker in the jail
                return Table.piles[dice] > -2;      // return true if checker can be placed ot table
            for (int i = 1; i < 25 - dice; i++)
            {
                if (allIn && i < 19 && Table.piles[i] > 0) allIn = false; // there is checker outside home zone, so user cannot safe checkers
                if (Table.piles[i] > 0 && Table.piles[i + dice] > -2) return true; // user can move checker
            }
            if (allIn)
            {
                lastPilePosition = 19;
                while (Table.piles[lastPilePosition] <= 0 && lastPilePosition < 25)
                    lastPilePosition++;
                for (int i = 24 - dice; i < 25; i++)
                    if (Table.piles[i] > 0 && i >= lastPilePosition) return true; //user can safe checker
            }
        }
        else
        {
            allIn = true;
            if (Table.jail[number] > 0)             // if there is checker in the jail
                return Table.piles[25 - dice] < 2;  // return true if checker can be placed ot table
            for (int i = 24; i > dice; i--)
            {
                if (allIn && i > 6 && Table.piles[i] < 0) allIn = false; // there is checker outside home zone, so user cannot safe checkers
                if (Table.piles[i] < 0 && Table.piles[i - dice] < 2) return true;
            }
            if (allIn)
            {
                lastPilePosition = 6;
                while (Table.piles[lastPilePosition] >= 0 && lastPilePosition > 0)
                    lastPilePosition--;
                for (int i = dice; i > 0; i--)
                    if (Table.piles[i] < 0 && i <= lastPilePosition) return true; //user can safe checker
            }
        }
        return false;
    }

    public int GetUserInput()
    {
        bool validInput;
        int userInput;
        int cursorPosX = Console.CursorLeft;
        int cursorPosY = Console.CursorTop;
        Console.ForegroundColor = color;
        do
        {
            Console.SetCursorPosition(cursorPosX, cursorPosY);
            validInput = int.TryParse(Console.ReadLine(), out userInput); // input is numerical
            validInput = validInput && (userInput >= 0 && userInput < 25); // input is in range
            if (!validInput) Console.Beep();
        } while (!validInput);
        Table.PrintMessage(color, "");
        return userInput;
    }

    public bool CheckMove(int fromPos, int toPos)
    {
        bool validMove;
        if (fromPos == -1) // play checker from jail
        {
            if (number == 0)
                validMove = Table.piles[toPos] > -2 && (toPos == Dices.diceA || toPos == Dices.diceB); // destination is friendly, empty, or has only 1 enemy checker
            else
                validMove = Table.piles[toPos] < 2 && (25 - toPos == Dices.diceA || 25 - toPos == Dices.diceB);
        }
        else // play checker from pile to pile
        {
            if (number == 0)
                validMove = (Table.piles[fromPos] > 0) && // has checker on source
                    // move is in right direction, destination is acceptable and step is equal to one of dices
                            (Table.piles[toPos] > -2 && (toPos - fromPos == Dices.diceA || toPos - fromPos == Dices.diceB) ||
                    // checker can be saved
                            (allIn && toPos == 0 && (fromPos > 24 - Dices.diceA || fromPos > 24 - Dices.diceB)));
            else
                validMove = (Table.piles[fromPos] < 0) &&  // has checker on soruce, 
                    // move is in right direction, destination is acceptable and step is equal to one of dices
                            (Table.piles[toPos] < 2 && (fromPos - toPos == Dices.diceA || fromPos - toPos == Dices.diceB) ||
                    // checker can be saved
                            (allIn && toPos == 0 && (fromPos <= Dices.diceA || fromPos <= Dices.diceB)));
        }
        return validMove;
    }

    public bool Turn()
    {
        int fromPile;
        int toPile;
        bool corectInput;
        bool pair = Dices.diceA == Dices.diceB;
        int pairCounter = 0;
        Console.ForegroundColor = color;
        Table.PrintPlayer(this);
        do
        {
            if (!(CheckForAvailableMove(Dices.diceA) || CheckForAvailableMove(Dices.diceB)))
            {
                Table.PrintMessage(color, "No move. Press key");
                Console.ReadKey();
                return false;
            }
            if (Table.jail[number] > 0)
            {
                fromPile = -1;
                Table.PrepareForUserInput(color, 0);
                Console.WriteLine("JAIL");
                do
                {
                    Table.PrepareForUserInput(color, 1);
                    toPile = GetUserInput();
                    corectInput = CheckMove(fromPile, toPile);
                    if (!corectInput)
                        Table.PrintMessage(color, "Wrong move!");
                } while (!corectInput);
                Table.MoveDice(this, fromPile, toPile);
                if (pair)
                {
                    pairCounter++;
                }
                else
                {
                    if (number == 0)
                    {
                        if (toPile == Dices.diceA)
                            Dices.diceA = 0;
                        else
                            Dices.diceB = 0;
                    }
                    else
                        if (toPile == 25 - Dices.diceA)
                            Dices.diceA = 0;
                        else
                            Dices.diceB = 0;
                }
            }
            else
            {
                do
                {
                    Table.PrepareForUserInput(color, 0);
                    fromPile = GetUserInput();
                    Table.PrepareForUserInput(color, 1);
                    toPile = GetUserInput();
                    corectInput = CheckMove(fromPile, toPile);
                    if (!corectInput)
                        Table.PrintMessage(color, "Wrong move!");
                } while (!corectInput);
                Table.MoveDice(this, fromPile, toPile);
                if (pair)
                {
                    pairCounter++;
                }
                else
                {
                    if (Math.Abs(fromPile - toPile) == Dices.diceA)
                        Dices.diceA = 0;
                    else
                        Dices.diceB = 0;
                }
            }
            Table.DrawDices();
        } while ((pair && pairCounter < 4) || (!pair && (Dices.diceA != 0 || Dices.diceB != 0)));
        return true;
    }
}

class BackgammonMain
{
    static void Main()
    {
        Player player1 = new Player(0);
        Player player2 = new Player(1);
        player1.enemy = player2;
        player2.enemy = player1;
        Console.WriteLine("Press <SPACE> to change, <ENTER> to continue.");
        player1.SetType();
        player2.SetType();
        Console.WriteLine();
        Table.DrawTable();
        for (int i = 1; i < Table.piles.Length; i++)
        {
            if (Table.piles[i] > 0)
                Table.DrawPile(player1.color, i);
            else
                Table.DrawPile(player2.color, i);
        }
        bool canMove;
        do
        {
            Dices.Roll();

            canMove = player1.Turn();
            Dices.Roll();
            canMove = player2.Turn();
        } while (true);
        //        Console.ReadLine();
    }
}