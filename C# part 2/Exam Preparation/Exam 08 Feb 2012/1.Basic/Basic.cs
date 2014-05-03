using System;
using System.Collections.Generic;
using System.Text;

class Basic
{
    static int[] variables = new int[5];
    static List<int> lineNumbers = new List<int>();
    static List<string> programCode = new List<string>();
    static List<int> output = new List<int>();

    static int GetVar(char ch)
    {
        return ch - 86;
    }

    static void AssignValue(string codeLine)
    {
        int varIndex = GetVar(codeLine[0]);
        int posOfSign = codeLine.IndexOfAny(new char[] { '+', '-' }, 3);
        if (posOfSign == -1) posOfSign = codeLine.Length;
        int firstValue = GetVar(codeLine[2]);
        if (firstValue < 0)
            firstValue = int.Parse(codeLine.Substring(2, posOfSign - 2));
        else
            firstValue = variables[firstValue];
        if (posOfSign == codeLine.Length)
        {
            variables[varIndex] = firstValue;
            return;
        }
        int secondValue = GetVar(codeLine[posOfSign + 1]);
        if (secondValue < 0)
            secondValue = int.Parse(codeLine.Substring(posOfSign + 1));
        else
            secondValue = variables[secondValue];
        if (codeLine[posOfSign] == '+')
            variables[varIndex] = firstValue + secondValue;
        else
            variables[varIndex] = firstValue - secondValue;
    }

    static string MakeIf(string s)
    {
        string condition = s.Substring(2, s.IndexOf("THEN") - 2);
        int firstCompOperand = GetVar(condition[0]);
        int posOfSign = condition.IndexOfAny(new char[] { '>', '=', '<' }, 1);
        if (firstCompOperand < 0)
            firstCompOperand = int.Parse(condition.Substring(0, posOfSign));
        else
            firstCompOperand = variables[firstCompOperand];
        int secondCompOperand = GetVar(condition[posOfSign + 1]);
        if (secondCompOperand < 0)
            secondCompOperand = int.Parse(condition.Substring(posOfSign + 1));
        else
            secondCompOperand = variables[secondCompOperand];
        if (condition[posOfSign] == '=' && firstCompOperand != secondCompOperand) return " ";
        if (condition[posOfSign] == '<' && firstCompOperand >= secondCompOperand) return " ";
        if (condition[posOfSign] == '>' && firstCompOperand <= secondCompOperand) return " ";
        return s.Substring(s.IndexOf("THEN") + 4);
    }

    static int MakeGoto(string s)
    {
        int lineNumber = int.Parse(s.Substring(4));
        return lineNumbers.BinarySearch(lineNumber);
    }

    static void PrintLine(string s)
    {
        int varIndex = GetVar(s[5]);
        output.Add(variables[varIndex]);
    }

    static void Main()
    {

        string s = "";
        StringBuilder command = new StringBuilder();
        do
        {
            s = Console.ReadLine().Trim();
            if (s.Contains("RUN")) break;
            int firstSpacePosition = s.IndexOf(' ');
            lineNumbers.Add(int.Parse(s.Substring(0, firstSpacePosition)));
            for (int i = firstSpacePosition; i < s.Length; i++)
                if (s[i] != ' ') command.Append(s[i]);
            programCode.Add(command.ToString());
            command.Clear();
        } while (true);
        // input is done

        int currentLine = 0;
        do
        {
            s = programCode[currentLine];
//            Console.WriteLine(s);
            if (s[0] == 'I') s = MakeIf(s);
            if (s[0] > 'U') AssignValue(s);
            if (s[0] == 'G') currentLine = MakeGoto(s);
            if (s[0] == 'P') PrintLine(s);
            if (s[0] == 'C') output.Clear();
            if (s[0] == 'S') break;
            if (s[0] != 'G') currentLine++;
        } while (currentLine < programCode.Count);

        foreach (int i in output)
            Console.WriteLine(i);
    }
}