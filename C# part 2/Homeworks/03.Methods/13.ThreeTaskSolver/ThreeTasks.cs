using System;

class ThreeTasks
{
    static int ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Three tasks project.");
        Console.WriteLine();
        Console.WriteLine("Please select a task:");
        Console.WriteLine("1. Reverses the digits of a number");
        Console.WriteLine("2. Calculates the average of a sequence of integers");
        Console.WriteLine("3. Solves a linear equation a * x + b = 0");
        Console.WriteLine("0. Exit the program");
        Console.WriteLine();
        ConsoleKeyInfo ans;
        do
        {
            Console.Write("\r Enter 0, 1, 2 or 3: ");
            ans = Console.ReadKey();
        } while ("0123".IndexOf(ans.KeyChar) == -1); //check if allowed key is pressed
        return ans.KeyChar;
    }

    static void ReverseDigits()
    {
        Console.Clear();
        Console.WriteLine("Task one: reverses the digits of a number");
        Console.WriteLine();
        string input;
        decimal dInput;
        bool parseOK;
        do
        {
            Console.Write("Enter a decimal positive digit: ");
            input = Console.ReadLine();
            parseOK = decimal.TryParse(input, out dInput);
            if (parseOK)
                parseOK = parseOK && dInput >= 0m;
            if (!parseOK)
                Console.WriteLine("Incorrect decimal format. Try again.");
        } while (!parseOK);
        Console.WriteLine();
        Console.Write("Reversed digit is: ");
        input = dInput.ToString();
        for (int i = input.Length - 1; i >= 0; i--)
            Console.Write(input[i]);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press enter to return to main menu");
        Console.ReadLine();
    }

    static void Average()
    {
        Console.Clear();
        Console.WriteLine("Task two: calculates the average of a sequence of integers");
        Console.WriteLine();
        Console.WriteLine("Please enter sequence elements, divided by commas(','):");
        string input = Console.ReadLine();
        string[] split = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length == 0)
        {
            Console.WriteLine("No elements found. Can not continue.");
            Console.Write("Press enter to return to main menu");
            Console.ReadLine();
            return;
        }
        int sum = 0;
        int tmp;
        for (int i = 0; i < split.Length; i++)
        {
            if (int.TryParse(split[i], out tmp))
                sum = sum + tmp;
            else
            {
                Console.WriteLine();
                Console.WriteLine("Incorect format at element {0}.Can not continue.", i);
                Console.WriteLine();
                Console.Write("Press enter to return to main menu");
                Console.ReadLine();
                return;
            }
        }
        double average = (double)sum / split.Length;
        Console.WriteLine();
        Console.WriteLine("Average of elements is {0}", average);
        Console.WriteLine();
        Console.Write("Press enter to return to main menu");
        Console.ReadLine();
    }

    static void EquationSolver()
    {
        Console.Clear();
        Console.WriteLine("Task three: solve a linear equation a * x + b = 0");
        Console.WriteLine();
        Console.Write("Please enter integer value for a: ");
        int a = int.Parse(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Incorrect input: a = 0. Exiting.");
            Console.WriteLine();
            Console.Write("Press enter to return to main menu");
            Console.ReadLine();
            return;
        }
        Console.Write("Please enter integer value for b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Solving equation {0} * x + {1} = 0", a, b);
        Console.WriteLine("Solution is x = {0}",-b/(double)a);
        Console.WriteLine();
        Console.Write("Press enter to return to main menu");
        Console.ReadLine();
    }

    static void Main()
    {

        /* Write a program that can solve these tasks:
         *  Reverses the digits of a number
         *  Calculates the average of a sequence of integers
         *  Solves a linear equation a * x + b = 0
         * Create appropriate methods. Provide a simple text-based menu for the user
         * to choose which task to solve. Validate the input data:
         *  The decimal number should be non-negative
         *  The sequence should not be empty
         *  a should not be equal to 0 */

        int taskNum = 0;
        do
        {
            taskNum = ShowMenu();
            switch (taskNum)
            {
                case 49: // key "1"
                    ReverseDigits();
                    break;
                case 50: // key "2"
                    Average();
                    break;
                case 51: // key "3"
                    EquationSolver();
                    break;
            }
        } while (taskNum != 48);
        Console.WriteLine();
    }
}