/* Write a program that prints all possible cards from a standard deck of 52 cards 
 * (without jokers). The cards should be printed with their English names. 
 * Use nested for loops and switch-case. */

using System;


namespace _10.PlayingCards
{
    class PlayingCards
    {
        static string[] names = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", 
                                    "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
        static string[] colors = { "Clubs", "Diamonds", "Hearts", "Spades"};

        static void Main()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // Version 1
                    switch (i)
                    {
                        case 0:
                            Console.Write(" A");
                            break;
                        case 9:
                            Console.Write(i + 1); // for "10" - the only 2-digit signature
                            break;
                        case 10:
                            Console.Write(" J");
                            break;
                        case 11:
                            Console.Write(" Q");
                            break;
                        case 12:
                            Console.Write(" K");
                            break;
                        default:
                            Console.Write(" " + (i + 1)); // for all numeric cards - from 2 to 9
                            break;
                    }
                    switch (j)
                    {
                        case 0:
                            Console.Write('\u2663' + " -> "); //unicode for clubs sign
                            break;
                        case 1:
                            Console.Write('\u2666' + " -> "); //unicode for diamonds sign
                            break;
                        case 2:
                            Console.Write('\u2665' + " -> "); //unicode for hearths sign
                            break;
                        case 3:
                            Console.Write('\u2660' + " -> "); //unicode for spades sign
                            break;
                    }
                    // Version 2
                    Console.WriteLine("{0} of {1}",names[i],colors[j]);
                }
            }
        }
    }
}
