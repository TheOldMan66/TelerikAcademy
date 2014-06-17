/* Write an expression that checks for given integer if its 
 * third digit (right-to-left) is 7. E. g. 1732  true. */

using System;

namespace _04.ThirdDigitIs7
{
    class ThirdDigitIs7
    {
        static void Main()
        {
            Console.Write("Enter a integer: ");
            int value = int.Parse(Console.ReadLine());
            bool isThirdA7 = (value / 100) % 10 == 7 ;
                Console.WriteLine("Is third digit of {0} a 7? {1} ",value, isThirdA7);
        }
    }
}
