using System;


class Laser
{
    // W H D

    public static int[] cubeSize;
    public static int[] laserPos;
    public static int[] newPos;
    public static int[] direction;
    public static bool[, ,] visited;

    static int[] ReadData()
    {
        string input = Console.ReadLine();
        string[] inpArr = input.Split(' ');
        int[] output = new int[3];
        for (int i = 0; i < 3; i++)
            output[i] = int.Parse(inpArr[i]);
        return output;
    }

    static bool Visited()
    {
        for (int i = 0; i < 3; i++)
        {
            if (laserPos[i] + direction[i] < 0 || laserPos[i] + direction[i] > cubeSize[i])
                direction[i] = -direction[i];
            newPos[i] = laserPos[i] + direction[i];
        }
        return (visited[newPos[0], newPos[1], newPos[2]]);
    }

    static void MoveLaser()
    {
        Array.Copy(newPos, laserPos, 3);
        visited[laserPos[0], laserPos[1], laserPos[2]] = true;
    }

    static void MakeEdges()
    {
        for (int i = 0; i < cubeSize[0]; i++)
        {
            visited[i, 0, 0] = true;
            visited[i, 0, cubeSize[2]] = true;
            visited[i, cubeSize[1], 0] = true;
            visited[i, cubeSize[1], cubeSize[2]] = true;
        }

        for (int i = 0; i < cubeSize[1]; i++)
        {
            visited[0, i, 0] = true;
            visited[0, i, cubeSize[2]] = true;
            visited[cubeSize[0], i, 0] = true;
            visited[cubeSize[0], i, cubeSize[2]] = true;
        }
        for (int i = 0; i < cubeSize[2]; i++)
        {
            visited[0, 0, i] = true;
            visited[0, cubeSize[1], i] = true;
            visited[cubeSize[0], cubeSize[1], i] = true;
            visited[cubeSize[0], cubeSize[1], i] = true;
        }
    }

    static void Main()
    {
        cubeSize = ReadData();
        visited = new bool[cubeSize[0], cubeSize[1], cubeSize[2]];
        cubeSize[0]--;
        cubeSize[1]--;
        cubeSize[2]--;
        MakeEdges();
        laserPos = ReadData();
        laserPos[0]--;
        laserPos[1]--;
        laserPos[2]--;
        visited[laserPos[0], laserPos[1], laserPos[2]] = true;
        newPos = new int[3];
        direction = ReadData();
        while (!Visited())
        {
            MoveLaser();
        }
        Console.WriteLine("{0} {1} {2}", laserPos[0] + 1, laserPos[1] + 1, laserPos[2] + 1);
    }
}