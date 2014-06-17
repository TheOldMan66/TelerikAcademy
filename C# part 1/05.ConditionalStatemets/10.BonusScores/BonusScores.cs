/* Write a program that applies bonus scores to given scores in the range [1..9]. 
 * The program reads a digit as an input. If the digit is between 1 and 3, the 
 * program multiplies it by 10; if it is between 4 and 6, multiplies it by 100; 
 * if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value 
 * is not a digit, the program must report an error. Use a switch statement and 
 * at the end print the calculated new value in the console.*/

using System;

namespace _10.BonusScores
{
    class BonusScores
    {
        static void Main()
        {
            int score = 0;
            do
            {
                Console.Write("Enter score [1..9] (0 to exit): ");
                ConsoleKeyInfo ch = Console.ReadKey();
                switch (ch.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                        score = (ch.KeyChar - 48) * 10;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                        score = (ch.KeyChar - 48) * 100;
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:
                        score = (ch.KeyChar - 48) * 1000;
                        break;
                    case ConsoleKey.D0:
                        score = 0;
                        return;
                    default:
                        score = 0;
                        break;
                }
                Console.WriteLine();
                if (score > 0)
                    Console.WriteLine("New score is {0}", score);
                else
                    Console.WriteLine("Invalid selection.");
            } while (true);
        }
    }
}
