// Declare a character variable and assign it with the symbol that has Unicode code 72.

using System;

namespace CharWith74Inside
{
    class Program
    {
        static void Main()
        {
            char character = '\u0048';
            Console.WriteLine("Symbol {0} have unicode value of {1}",character, (int) character);
        }
    }
}
