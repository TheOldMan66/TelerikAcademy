/* Which of the following values can be assigned to a variable of type float and which 
 * to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091? */

using System;

namespace ProperTypeForRealNumbers
{
    class RealNumbers
    {
        static void Main()
        {
            double firstDouble = 34.567839023;
            float firstFloat = 34.567839023f;
            double secondDouble = 12.345;
            float secondFloat = 12.345f;
            double thirdDouble = 8923.1234857;
            float thirdFloat = 8923.1234857f;
            double fourthDouble = 3456.091;
            float fourthFloat = 3456.091f;
            Console.WriteLine("{0} fits in Double? {1}. Saved value is: {2}", firstDouble, (firstDouble.ToString() == "34,567839023"), firstDouble);
            Console.WriteLine("{0} fits in Float? {1}. Saved value is: {2}\n", firstDouble, (firstFloat.ToString() == "34,567839023"), firstFloat);
            Console.WriteLine("{0} fits in Double? {1}. Saved value is: {2}", secondDouble, (secondDouble.ToString() == "12,345"), secondDouble);
            Console.WriteLine("{0} fits in Float? {1}. Saved value is: {2}\n", secondDouble, (secondFloat.ToString() == "12,345"), secondFloat);
            Console.WriteLine("{0} fits in Double? {1}. Saved value is: {2}", thirdDouble, (thirdDouble.ToString() == "8923,1234857"), thirdDouble);
            Console.WriteLine("{0} fits in Float? {1}. Saved value is: {2}\n", thirdDouble, (thirdFloat.ToString() == "8923,1234857"), thirdFloat);
            Console.WriteLine("{0} fits in Double? {1}. Saved value is: {2}", fourthDouble, (fourthDouble.ToString() == "3456,091"), fourthDouble);
            Console.WriteLine("{0} fits in Float? {1}. Saved value is: {2}\n", fourthDouble, (fourthFloat.ToString() == "3456,091"), fourthFloat);
        }
    }
}
