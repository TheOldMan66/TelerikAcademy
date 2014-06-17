using System;


class CheckBrackets
{
    static void Main()
    {
        Console.Write("Enter some expression with open and closed brackets: ");
        string expression = Console.ReadLine();
        int stack = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
                stack++;
            if (expression[i] == ')')
                stack--;
            if (stack < 0)
            {
                Console.WriteLine("Incorrect closing bracket at pos {0}.", i);
                return;
            }
        }
        if (stack != 0)
            Console.WriteLine("Wrong number of open and closed brackets");
        else
            Console.WriteLine("Expression have correct bracket placing");
    }
}