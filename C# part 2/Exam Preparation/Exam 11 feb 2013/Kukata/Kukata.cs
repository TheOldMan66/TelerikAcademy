using System;


class Program
{
    static sbyte posX = 1;
    static sbyte posY = 1;
    static sbyte direction = 0;

    static void DoMove(char move)
    {
        switch (move)
        {
            case 'L':
                direction--;
                direction &= 3;
                break;
            case 'R':
                direction++;
                direction &= 3;
                break;
            case 'W':
                switch (direction)
                {
                    case 0:
                        posX++;
                        if (posX == 3) posX = 0;
                        break;
                    case 1:
                        posY++;
                        if (posY == 3) posY = 0;
                        break;
                    case 2:
                        posX--;
                        if (posX == -1) posX = 2;
                        break;
                    case 3:
                        posY--;
                        if (posY == -1) posY = 2;
                        break;
                }
                break;
        }
    }

    static void Main()
    {
        string[,] cube = { { "RED", "BLUE", "RED" }, { "BLUE", "GREEN", "BLUE" }, { "RED", "BLUE", "RED" } };

        int NumLines = int.Parse(Console.ReadLine());
        string[] lines = new string[NumLines];
        for (int i = 0; i < NumLines; i++)
            lines[i] = Console.ReadLine();

        for (int i = 0; i < NumLines; i++)
        {
            posX = 1;
            posY = 1;
            char[] moves = lines[i].ToCharArray();
            for (int j = 0; j < moves.Length; j++)
            {
                DoMove(moves[j]);
            }
            Console.WriteLine(cube[posX, posY]);
        }
    }
}