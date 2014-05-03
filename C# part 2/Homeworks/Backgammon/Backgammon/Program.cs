using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BackGammonMain
{
    class Dices
    {
        public int diceA;
        public int diceB;
        Random rnd;

        public Dices()
        {
            rnd = new Random();
        }

        void DrawDice(int posY, int dice)
        {
            Console.SetCursorPosition(6 * cellWidth + barWidth - 1, posY);
            Console.Write("+-+");
            Console.SetCursorPosition(6 * cellWidth + barWidth - 1, posY + 1);
            Console.Write("|{0}|", dice);
            Console.SetCursorPosition(6 * cellWidth + barWidth - 1, posY + 2);
            Console.Write("+-+");
        }

        public void Roll()
        {
            diceA = rnd.Next(1, 7);
            diceB = rnd.Next(1, 7);
            DrawDice(7, diceA);
            DrawDice(11, diceB);
        }
    }

    static int boardWidth = 70;
    static int boardHeight = 24;
    static int cellWidth = 3;
    static int barWidth = 5;
    //    static int[] checkers = { 2, -2, -2, -2, -2, -5, 6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -14, -13, -12, -11, -10, -9, -8, -7 };
    static int[] checkers = { 2, 0, 0, 0, 0, -5, 0, -3, 0, 0, 0, 5, -5, 0, 0, 0, 3, 0, 5, 0, 0, 0, 0, -2 };
    static int[] jail = { 0, 0, 0 };
    static int[] evadedCheckers = { 0, 0, 0 };

    static void DrawEmptyTable()
    {
        // prepare some strings
        string upperBorder = " +" + new string('-', 6 * (cellWidth)) + '+' + new string('-', barWidth) + '+' + new string('-', 6 * (cellWidth)) + "+";
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

        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(12 * cellWidth + 7 + barWidth, 8);
        Console.WriteLine(" User turn");
        Console.SetCursorPosition(12 * cellWidth + 7 + barWidth, 10);
        Console.WriteLine("From: ");
        Console.SetCursorPosition(12 * cellWidth + 7 + barWidth, 11);
        Console.WriteLine("  To:");
    }

    static ConsoleColor GetPileColor(int pile)
    {
        return pile > 0 ? ConsoleColor.White : ConsoleColor.Red;
    }

    static int GetPileX(int pile)
    {
        int posX;
        if (pile > 11)
        {
            posX = (pile - 11) * cellWidth;
            if (pile > 17)
                posX = posX + barWidth + 2;
        }
        else
        {
            posX = (12 - pile) * cellWidth;
            if (pile < 6)
                posX = posX + barWidth + 2;
        }
        return posX;
    }

    static void DrawCheckerPile(int pileNo)
    {
        int posY = pileNo > 11 ? 3 : 20;
        int posX = GetPileX(pileNo);
        ConsoleColor color = GetPileColor(checkers[pileNo]);
        for (int i = 1; i < 9; i++)
        {
            if (i > Math.Abs(checkers[pileNo]))
            {
                Console.SetCursorPosition(posX - 1, posY);
                Console.Write("  ");
                continue;
            }
            Console.ForegroundColor = color;
            if (checkers[pileNo] / 8 > 0 && checkers[pileNo] % 8 >= i)
            {
                Console.SetCursorPosition(posX - 1, posY);
                Console.Write("OO");
            }
            else
            {
                Console.SetCursorPosition(posX - 1, posY);
                Console.Write(" O");
            }
            posY = posY + (pileNo > 11 ? 1 : -1);
        }
    }


    static int GetUserInput(int posY)
    {
        bool validInput;
        int userInput;
        do
        {
            Console.SetCursorPosition(12 * cellWidth + 13 + barWidth, posY);
            validInput = int.TryParse(Console.ReadLine(), out userInput); // input is numerical
            validInput = validInput && (userInput > 0 && userInput < 25); // input is in range
            if (!validInput) Console.Beep();
        } while (!validInput);
        Console.SetCursorPosition(GetPileX(userInput - 1) - 1, userInput > 12 ? 1 : 22);
        Console.WriteLine("{0,2}", userInput);
        return userInput - 1;
    }

    static bool CheckMove(int fromPos, int toPos)
    {
        bool validMove = checkers[fromPos] > 0; // check for any user checkers in start position
        validMove = validMove && (toPos > fromPos); // check that dest > start
        validMove = validMove && (fromPos != toPos) && (checkers[toPos] > -2);  // true if desination place is empty, have user checker(s) or just 1 enemy checker and start and destination are different
        return validMove;
    }

    static void RestorePileSign(int pile)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(GetPileX(pile) - 1, pile > 12 ? 1 : 22);
        Console.WriteLine("{0,2}", pile + 1);
    }

    static void ClearUserInput(int posY)
    {
        Console.SetCursorPosition(12 * cellWidth + 13 + barWidth, posY);
        Console.Write("     ");
    }

    static void DrawJail(int player)
    {
        int posY = player < 0 ? 3 : 18;
        int posX = 7 * cellWidth;
        Console.ForegroundColor = player == 1 ? ConsoleColor.White : ConsoleColor.Red;
        Console.SetCursorPosition(posX, posY);
        if (jail[1 - player] > 0)
            Console.Write("JAIL");
        else
            Console.Write("    ");
        Console.SetCursorPosition(posX + 2, posY + 1);
        if (jail[1 - player] > 0)
            Console.Write("{0,2}", jail[1 - player]);
        else
            Console.Write("  ", jail[1 - player]);
    }

    static void MoveDice(int player, int fromPos, int toPos)
    {
        checkers[fromPos] = checkers[fromPos] - player; // get one checker from pile (value -1 for player, or value +1 for computer)
        DrawCheckerPile(fromPos); // draw checker pile with new checkers
        if (checkers[toPos] * player < 0) // if enemy checker is on destination pile
        {
            jail[1 + player]++; // jail[2] is a computer jail, jail[0] is a player jail
            DrawJail(-player); // show enemy jail
            checkers[toPos] = 0; // empty pile before place checker there
        }
        checkers[toPos] = checkers[toPos] + player; // Add checker to destination pile
        DrawCheckerPile(toPos); // and draw destintion pile
    }

    static bool CheckForAvailableMove(int player, int dice)
    {
        if (jail[1 - player] > 0)                   // if have checker in jail
        {
            int destPos = 12 - (12 * player) + (dice * player); // ufff... sorry for this :) It's return 24 - dice for player = -1 or 0 + dice for player = 1;
            return checkers[destPos] * player < -1; // return true if jailed checker can be played 
        }
        for (int i = 0; i < checkers.Length; i++) // check if any checker can be moved
        {
            if (checkers[i] * player <= 0) continue; //there is no dice on pile or is a enemy pile
            if (i + dice * player > 24 || i + dice * player < 0) continue; // destination is outside the board;
            if (checkers[i + (dice * player)] * player > -2) //destination place is empty, have players dice(s) or only one enemy dice 
                return true;
        }
        return false;
    }

    static void UserTurn(Dices dices)
    {
        bool validMove;
        bool equalDices = dices.diceA == dices.diceB;
        int equalDicesCounter = 4;
        do
        {
            int step = 0;
            int userFrom = 0;
            int userTo = 0;
            bool CanMoveDiceA;
            bool CanMoveDiceB;
            do
            {
                CanMoveDiceA = CheckForAvailableMove(1, dices.diceA);
                CanMoveDiceB = CheckForAvailableMove(1, dices.diceB);
                if (dices.diceA == 0 && !CanMoveDiceB || // first dice is moved, but second cannot 
                    dices.diceB == 0 && !CanMoveDiceA || // second dice is moved, but first cannot 
                    !(CanMoveDiceA || CanMoveDiceB)) // no dice can be moved
                {
                    Console.SetCursorPosition(15 * cellWidth + barWidth, 13);
                    Console.WriteLine("User cannot move");
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                userFrom = GetUserInput(10); // get number and check that is in range 1-24
                Console.SetCursorPosition(15 * cellWidth + barWidth, 13);
                Console.Write("                "); // erase "Wrong move" message
                userTo = GetUserInput(11); // get number and check that is in range 1-24
                validMove = CheckMove(userFrom, userTo);
                step = userTo - userFrom;
                validMove = validMove && (step == dices.diceA || step == dices.diceB); // any dice number is equal to move
                if (!validMove)
                {
                    Console.SetCursorPosition(15 * cellWidth + barWidth, 13);
                    Console.Write("Wrong move");
                    Console.Beep(1200, 500);
                }
                ClearUserInput(10);
                ClearUserInput(11);
                RestorePileSign(userFrom);
                RestorePileSign(userTo);
            } while (!validMove);

            MoveDice(1, userFrom, userTo);
            if (step == dices.diceA)
                if (equalDices)
                    equalDicesCounter--;
                else
                    dices.diceA = 0;
            else
                dices.diceB = 0;
        } while ((dices.diceA != 0 || dices.diceB != 0) && equalDicesCounter != 0);
    }

    static void ComputerTurn(Dices dices)
    {
        do
        {
            for (int i = 23; i >= 0; i--)
            {
                if (checkers[i] >= 0) continue;
                if (dices.diceA > 0 && checkers[i - dices.diceA] < 2)
                {
                    MoveDice(-1, i, i - dices.diceA);
                    dices.diceA = 0;
                    break;
                }
                if (dices.diceB > 0 && checkers[i - dices.diceB] < 2)
                {
                    MoveDice(-1, i, i - dices.diceB);
                    dices.diceB = 0;
                    break;
                }
            }
        } while (dices.diceA > 0 || dices.diceB > 0);

    }

    static void Main()
    {
        Console.Title = "Backgammon game";
        Console.SetWindowSize(boardWidth, boardHeight);
        Console.OutputEncoding = Encoding.Unicode;
        DrawEmptyTable();
        for (int i = 0; i < checkers.Length; i++)
            if (checkers[i] != 0)
                DrawCheckerPile(i);
        Dices dices = new Dices();
        do
        {
            dices.Roll();
            UserTurn(dices);
            dices.Roll();
            ComputerTurn(dices);
        } while (true);
        Console.ReadLine();
    }
}
