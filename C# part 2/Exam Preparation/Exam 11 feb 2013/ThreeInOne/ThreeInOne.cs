using System;


class ThreeInOne
{
    static void Main()
    {
        // task 1
        string input = Console.ReadLine();
        string[] inpArr = input.Split(',');
        int[] points = new int[inpArr.Length];
        int winnerPos = -1;
        int winnerPoints = -1;
        bool uniqe = true;
        int currPoint;
        for (int i = 0; i < inpArr.Length; i++)
        {
            currPoint = int.Parse(inpArr[i]);
            if (currPoint > 21) continue;
            if (currPoint > winnerPoints)
            {
                winnerPoints = currPoint;
                uniqe = true;
                winnerPos = i;
                continue;
            }
            if (currPoint == winnerPoints)
            {
                uniqe = false;
                winnerPos = -1;
            }
        }
        // end of task 1

        // task 2
        input = Console.ReadLine();
        string[] sCakeWeight = input.Split(',');
        int[] cakeWeight = new int[sCakeWeight.Length];
        for (int i = 0; i < sCakeWeight.Length; i++)
            cakeWeight[i] = int.Parse(sCakeWeight[i]);
        Array.Sort(cakeWeight);
        Array.Reverse(cakeWeight);
        int numofPlayers = int.Parse(Console.ReadLine());
        int myCakeWeight = 0;
        for (int i = 0; i < sCakeWeight.Length; i = i + numofPlayers + 1)
            myCakeWeight = myCakeWeight + cakeWeight[i];

        // task 3
        input = Console.ReadLine();

        // print results from task 1 & 2

        //print task 1 results;
        Console.WriteLine(winnerPos);
        //print task 2 results;
        Console.WriteLine(myCakeWeight);

        string[] sCoins = input.Split(' ');
        int[] myCoins = new int[3];
        int[] desiredCoins = new int[3];
        for (int i = 0; i < 3; i++)
            myCoins[i] = int.Parse(sCoins[i]);
        for (int i = 3; i < 6; i++)
            desiredCoins[i - 3] = int.Parse(sCoins[i]);
        int numOfTransactions = 0;
        bool shortOfMoney = false;

        while (myCoins[0] < desiredCoins[0] && (myCoins[1] > desiredCoins[1] || myCoins[2] > desiredCoins[2]))
        {
            myCoins[1] = myCoins[1] - 11;
            myCoins[0]++;
            numOfTransactions++;
            while (myCoins[1] < desiredCoins[1] && myCoins[2] > desiredCoins[2])
            {
                myCoins[2] = myCoins[2] - 11;
                myCoins[1]++;
                numOfTransactions++;
            }
        }

        if (myCoins[0] < desiredCoins[0])
        {
            Console.WriteLine("-1");
            return;
        }

        while (myCoins[1] < desiredCoins[1] && (myCoins[0] > desiredCoins[0] || myCoins[2] > desiredCoins[2]))
        {
            while (myCoins[0] > desiredCoins[0] && myCoins[1] < desiredCoins[1])
            {
                myCoins[0]--;
                myCoins[1] = myCoins[1] + 9;
                numOfTransactions++;
            }
            while (myCoins[2] > desiredCoins[2] && myCoins[1] < desiredCoins[1])
            {
                myCoins[2] = myCoins[2] - 11;
                myCoins[1]++;
                numOfTransactions++;
            }
        }

        if (myCoins[1] < desiredCoins[1])
        {
            Console.WriteLine("-1");
            return;
        }

        while (myCoins[2] < desiredCoins[2] && (myCoins[1] > desiredCoins[1] || myCoins[0] > desiredCoins[0]))
        {
            myCoins[1]--;
            myCoins[2] = myCoins[2] + 9;
            numOfTransactions++;
            while (myCoins[1] < desiredCoins[1] && myCoins[0] > desiredCoins[0])
            {
                myCoins[0]--;
                myCoins[1] = myCoins[1] + 9;
                numOfTransactions++;
            }
        }
        if (myCoins[2] < desiredCoins[2])
            Console.WriteLine("-1");
        else
            Console.WriteLine(numOfTransactions);

    }
}