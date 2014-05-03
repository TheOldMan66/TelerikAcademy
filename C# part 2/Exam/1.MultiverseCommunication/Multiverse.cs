using System;

class Multiverse
{
    static void Main()
    {
        string s = Console.ReadLine();
        int messageLenght = s.Length / 3;
        string[] chars = new string[messageLenght];
        long result = 0;
        long temp = 0;
        for (int i = 0; i < messageLenght; i++)
        {
            chars[i] = s.Substring(i * 3, 3);
            temp = 0;
            switch (chars[i])
            {
                case "CHU": temp = 0; break;
                case "TEL": temp = 1; break;
                case "OFT": temp = 2; break;
                case "IVA": temp = 3; break;
                case "EMY": temp = 4; break;
                case "VNB": temp = 5; break;
                case "POQ": temp = 6; break;
                case "ERI": temp = 7; break;
                case "CAD": temp = 8; break;
                case "K-A": temp = 9; break;
                case "IIA": temp = 10; break;
                case "YLO": temp = 11; break;
                case "PLA": temp = 12; break;
            }
            result = result * 13 + temp;
        }
        Console.WriteLine(result);
    }
}