//Declare a boolean variable called isFemale and assign an
//appropriate value corresponding to your gender
using System;

namespace IsFemale
{
    class IsFemale
    {
        static void Main()
        {
            char gender;

            // I'm using nullable bool variable to avoid sexual orientation charges
            // It's a 21 century now... :) 
            bool? isFemale = null; 
            Console.Write("Press key 'M' for male or 'F' for female:");

            // ReadKey return not a simple char only, so some sort of 'cast'-ing is required
            gender = Console.ReadKey().KeyChar;
            //Let's make char uppercase
            gender = (char) (gender & 0xDF); //Bitwise operation to ensure that letter is always uppercase
            if (gender == 'M')
            {
                isFemale = false;
            }
            if (gender == 'F')
            {
                isFemale = true;
            }
            Console.WriteLine("\nValue of isFemale is {0}",isFemale);
            // if user enter 'M', value will be "hard" False, if input is "F" value will be 
            // "hard" True. Any other key will not affect null value, so gender will be ... unclear. 
        }
    }
}
