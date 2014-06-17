using System;
using System.Text;

class Floating
{
    static void Main()
    {

        /* Write a program that shows the internal binary representation of given 32-bit 
         * signed floating-point number in IEEE 754 format (the C# type float). Example: 
         * -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000. */

        // Cheating method - reading bytes from memory...

        float input;
        StringBuilder result = new StringBuilder();
        while (true)
        {
            Console.Write("Enter some folating point number: ");
            bool isFloat = float.TryParse(Console.ReadLine(), out input);
            if (!isFloat)
            {
                Console.WriteLine("Invalid float format");
                continue;
            }

            byte[] digits = BitConverter.GetBytes(input);
            result.Clear();
            for (int i = 3; i >= 0; i--)
                result.Append(Convert.ToString(digits[i], 2).PadLeft(8, '0'));
            Console.WriteLine(result);
            Console.WriteLine("Sign: {0}, exponent: {1}, mantissa: {2}", result[0], result.ToString(1, 8), result.ToString(9, result.Length-9));
        }
    }
}
