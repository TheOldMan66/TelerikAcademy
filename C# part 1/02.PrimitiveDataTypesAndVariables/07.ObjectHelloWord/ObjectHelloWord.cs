/* Declare two string variables and assign them with “Hello” and “World”. 
 * Declare an object variable and assign it with the concatenation of the 
 * first two variables. Declare a third string variable and initialize it 
 * with the value of the object variable (you should perform type casting) */

using System;

namespace ObjectHelloWord
{
    class ObjectHelloWord
    {
        static void Main()
        {
            string hello = "Hello";
            string world = "World";
            object container = hello + " " + world;
            string result = (string) container;
            Console.WriteLine("As object: " + container.ToString());
            Console.WriteLine("As string: " + result);
        }
    }
}
