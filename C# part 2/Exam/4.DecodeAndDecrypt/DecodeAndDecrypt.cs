using System;
using System.Collections.Generic;
using System.Text;

class DecodeAndDecrypt
{
    static void Main()
    {
        string s = Console.ReadLine();
        int i = s.Length - 1;
        while (char.IsDigit(s[i])) i--;
        int cypherLen = int.Parse(s.Substring(i + 1));
        s = s.Substring(0, i + 1);
        StringBuilder sb = new StringBuilder();
        int strPos = 0;
        while (strPos < s.Length)
        {
            if (!char.IsDigit(s[strPos]))
            {
                sb.Append(s[strPos]);
                strPos++;
            }
            else
            {
                int pos1 = 0;
                while (char.IsDigit(s[strPos + pos1]))
                    pos1++;
                int number = int.Parse(s.Substring(strPos, pos1));
                strPos = strPos + pos1;
                sb.Append(new string(s[strPos], number - 1));
            }
        }
        s = sb.ToString();
        string message = s.Substring(0, s.Length - cypherLen);
        string cypher = s.Substring(s.Length - cypherLen);
        StringBuilder encryptedMessage = new StringBuilder();
        char[] result = new char[message.Length];
        if (message.Length >= cypher.Length)
            for (i = 0; i < message.Length; i++)
                result[i] = (char)(((message[i] - 65) ^ (cypher[i % cypher.Length] - 65)) + 65);
        else
        {
            for (i = 0; i < message.Length; i++)
                result[i] = (char)(((message[i] - 65) ^ (cypher[i] - 65)) + 65);
            int cyperPos = message.Length;
            while (cyperPos < cypher.Length)
            {
                result[cyperPos % message.Length] = (char)(((result[cyperPos % message.Length] - 65) ^ (cypher[cyperPos] - 65)) + 65);
                cyperPos++;
            }
        }
        Console.WriteLine(new string(result));

    }
}
