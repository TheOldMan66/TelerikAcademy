using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Substring
{

    /* Implement an extension method Substring(int index, int length) for the class StringBuilder 
     * that returns new StringBuilder and has the same functionality as Substring in the class String. */

    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index)
        {
            if (index >= sb.Length)
                throw new IndexOutOfRangeException();
            return new StringBuilder(sb.ToString(index, sb.Length - index));
        }

        public static StringBuilder Substring(this StringBuilder sb, int index, int lenght)
        {
            if (index + lenght > sb.Length)
                throw new IndexOutOfRangeException();
            return new StringBuilder(sb.ToString(index, lenght));
        }

    }

    class Substring
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder("This is a test text for checking substring extension.");
            Console.WriteLine("Initial string:");
            Console.WriteLine(builder);
            Console.WriteLine();
            Console.WriteLine("Substring form pos 40 to end:");
            Console.WriteLine(builder.Substring(40));
            Console.WriteLine();
            Console.WriteLine("Substring - 10 chars starting fom pos 30:");
            Console.WriteLine(builder.Substring(30,10));
        }
    }
}
