/* Declare five variables choosing for each of them the most appropriate 
 * of the types byte, sbyte, short, ushort, int, uint, long, ulong to represent 
 * the following values: 52130, -115, 4825932, 97, -10000 */

using System;

namespace DeclareFiveVariables
{
    class FiveVariables
    {
        static void Main()
        {
            ushort unsignedShortInteger = 52130;
            sbyte signedByte = -115;
            uint unsignedInteger = 4825932;
            byte unsignedByte = 97;
            short signedInteger = -10000;
            Console.WriteLine("ushort {0}, sbyte {1}, uint {2}, byte {3}, short {4}", unsignedShortInteger, signedByte, unsignedInteger, unsignedByte, signedInteger);
        }
    }
}
