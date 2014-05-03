/* Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom
 * of the screen and can move left and right (by the arrows keys). A number of rocks of 
 * different sizes and forms constantly fall down and you need to avoid a crash. Rocks are 
 * the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. 
 * The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150). 
 * Implement collision detection and scoring system. */


using System;
using System.Text;
using System.Threading;


namespace _11.FallingRockGame
{
    class FallingRock
    {
        const byte screenWidth = 80;
        const byte screenHeight = 40;
        const string dwarfSign = "(O)";

        static string[] allRocks = { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";", "-" };
        static string[] display;
        static byte dwarfPos;
        static byte difficulty = 10;
        static int rowsPassed = 0;
        static bool crash = false;
        static int crashCount = 0;


        static void Main()
        {
            Console.SetWindowSize(screenWidth + 20, screenHeight + 5);
            dwarfPos = screenWidth/2;

            StringBuilder dwarfRow = new StringBuilder(new string(' ', screenWidth - dwarfSign.Length));
            dwarfRow.Insert(dwarfPos-1, dwarfSign);
            dwarfRow.Insert(0, "|");
            dwarfRow.Append("|");
            display = new string[screenHeight];
            for (int i = 0; i < screenHeight; i++)
            {
                display[i] = new string(' ',screenWidth);
            }


            do
            {
                PrintRocks(dwarfRow);
                Thread.Sleep(150);
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo cmd = Console.ReadKey(true);
                    if ((cmd.Key == ConsoleKey.LeftArrow) & (dwarfPos > 1))
                        dwarfPos--;
                    if ((cmd.Key == ConsoleKey.RightArrow) & (dwarfPos < screenWidth - 2))
                        dwarfPos++;
                    if (cmd.Key == ConsoleKey.Escape)
                        return;
                }
                dwarfRow = GeneratedwarfRow(display[screenHeight-1], dwarfPos);
                crash = MoveRocks();
                display[0] = GenerateNewRow();

                rowsPassed++;
                if (rowsPassed % 50 == 0)
                {
                    difficulty++;
                }
            }
            while (true);

        }

        static void PrintRocks(StringBuilder lastRow)
        {
            Console.Clear();
            for (int i = 0; i < screenHeight; i++)
            {
                Console.Write("|" + display[i] + "|");
                switch (i)
                {
                    case 0:
                        Console.WriteLine(" Difficulty:");
                        break;
                    case 1:
                        Console.WriteLine("     " + difficulty);
                        break;
                    case 2:
                        Console.WriteLine(" Rows passed:");
                        break;
                    case 3:
                        Console.WriteLine("     " + rowsPassed);
                        break;
                    case 4:
                        Console.WriteLine(" Crash Count:");
                        break;
                    case 5:
                        Console.WriteLine("     "+crashCount);
                        break;
                    case 7:
                        Console.WriteLine(" <ESC> to exit");
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
            if (crash) Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(lastRow);
            Console.BackgroundColor = ConsoleColor.Black;
            crash = false;
        }

        static bool MoveRocks()
        {
            bool crash = false;
            for (int i = screenHeight-1; i >= 1; i--)
            {
                if (i == screenHeight - 1)
                {
                    if (display[i].Substring(dwarfPos-1, dwarfSign.Length) != new string(' ', dwarfSign.Length))
                    {
                        crash = true;
                        crashCount++;
                    } 
                    display[i] = display[i - 1];
                }
                else
                {
                    display[i] = display[i - 1];
                }
            }
            return crash;
        }

        static StringBuilder GeneratedwarfRow(string row1, byte newPos)
        {
            StringBuilder row = new StringBuilder("|" + row1 + "|");
            row.Remove(newPos, dwarfSign.Length);
            row.Insert(dwarfPos, dwarfSign);
            return row;
        }

        static string GenerateNewRow()
        {
            Random rnd = new Random();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < screenWidth; i++)
            {
                if (rnd.Next(1000) < difficulty)
                {
                    str.Insert(rnd.Next(str.Length), allRocks[rnd.Next(allRocks.Length)]);
                }
                else
                {
                    str.Insert(rnd.Next(str.Length), " ");
                }
            }
            return str.ToString();
        }
    }
}
