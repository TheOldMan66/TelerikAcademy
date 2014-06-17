using System;

class Tron3D
{
    static int[,] playArea;
    static int[,] playerPositions;
    static bool[] crashed = new bool[3];
    static int[] charPos = new int[3];

    public static void MakrPlayerPlaces(int player)
    {
        playArea[playerPositions[player, 0], playerPositions[player, 1]] = player;
    }

    public static void MovePlayer(int player, string move)
    {
        while (move[charPos[player]] == 'L' || move[charPos[player]] == 'R')
        {
            if (move[charPos[player]] == 'L')
            {
                playerPositions[player, 2]++;
                if (playerPositions[player, 2] == 4)
                    playerPositions[player, 2] = 0;
            }
            if (move[charPos[player]] == 'R')
            {
                playerPositions[player, 2]--;
                if (playerPositions[player, 2] == -1)
                    playerPositions[player, 2] = 3;
            }
            charPos[player]++;
        }

        switch (playerPositions[player, 2])
        {
            case 0:
                {
                    playerPositions[player, 0]--;
                    crashed[player] = playerPositions[player, 0] < 0;
                    break;
                }
            case 2:
                {
                    playerPositions[player, 0]++;
                    crashed[player] = playerPositions[player, 0] > playArea.GetLength(0);
                    break;
                }
            case 1:
                {
                    playerPositions[player, 1]++;
                    if (playerPositions[player, 1] == playArea.GetLength(1))
                        playerPositions[player, 1] = 0;
                    break;
                }
            case 3:
                {
                    playerPositions[player, 1]--;
                    if (playerPositions[player, 1] == -1)
                        playerPositions[player, 1] = playArea.GetLength(1) - 1;
                    break;
                }
        }
        crashed[player] = crashed[player] || playArea[playerPositions[player, 0], playerPositions[player, 1]] == (3 - player);
        if (!crashed[player])
        {
            playArea[playerPositions[player, 0], playerPositions[player, 1]] = player;
        }
        charPos[player]++;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string[] sCubdeDimensons = input.Split(' ');
        int cubeX = int.Parse(sCubdeDimensons[0]);
        int cubeY = int.Parse(sCubdeDimensons[1]);
        int cubeZ = int.Parse(sCubdeDimensons[2]);
        playArea = new int[cubeX + 1, 2 * (cubeY + 1) + 2 * (cubeZ + 1)];
        playerPositions = new int[3, 3]; // 0,0 - player 0 pos X, 0,1 - player 0 pos Y 0,3 - player 0 direction
        playerPositions[1, 0] = cubeX / 2;
        playerPositions[1, 1] = cubeY / 2;
        playerPositions[1, 2] = 1;
        playerPositions[2, 0] = cubeX / 2;
        playerPositions[2, 1] = cubeY + cubeZ;
        playerPositions[2, 2] = 3;
        string[] playerMoves = new string[3];
        playerMoves[1] = Console.ReadLine();
        playerMoves[2] = Console.ReadLine();
        // input is done
        MakrPlayerPlaces(1);
        MakrPlayerPlaces(2);
        while (!crashed[1] && !crashed[2])
        {
            MovePlayer(1, playerMoves[1]);
//            Console.WriteLine("1 - {0} {1} {2}", playerPositions[1, 0], playerPositions[1, 1], playerPositions[1, 2]);
            MovePlayer(2, playerMoves[2]);
//            Console.WriteLine("2 - {0} {1} {2}", playerPositions[2, 0], playerPositions[2, 1], playerPositions[2, 2]);
        }
        if (crashed[1] == true)
        {
            if (crashed[2] == true)
                Console.WriteLine("DRAW");
            else
                Console.WriteLine("BLUE");
        }
        else
            Console.WriteLine("RED");
        int distance = Math.Abs(playerPositions[1, 0] - (cubeX / 2));
        int trackLen = 2 * (cubeY + 1) + 2 * (cubeZ + 1);
        if ((playerPositions[1, 1] - cubeY / 2) < trackLen / 2)
            distance = distance + Math.Abs(playerPositions[1, 1] - cubeY / 2);
        else
            distance = distance + (trackLen + cubeY / 2 - playerPositions[1, 1]);
        Console.WriteLine(distance);
    }
}