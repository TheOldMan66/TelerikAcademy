using System;
using System.IO;

/* Write a program that enters file name along with its full file path 
 * (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
 * Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch 
 * all possible exceptions and print user-friendly error messages. */

namespace _03.PrintFileContents
{
    class PrintFile
    {
        static void Main()
        {
            Console.WriteLine("Въведете пълно име на файл (заедно с пътя до него), например: \"C:\\windows\\win.ini\"");
            Console.Write("Моля, въведете име на файла: ");
            string path = Console.ReadLine();
            try
            {
                string fileContents = File.ReadAllText(path);
                Console.WriteLine(fileContents);

            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Въведен е несъществуващ път до файла");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Има такъв път, но в него няма такъв файл.");
                Console.WriteLine("Или ако не е въведен път, тогава в текущата директория няма такъв файл.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Възникна проблем с вашите права за достъп.");
                Console.WriteLine("Това може да се случи и ако сте указали само път, без конкретен файл.");
            }
            catch (IOException)
            {
                Console.WriteLine("Файла не може да се отвори, тъй като се ползва от друго приложение");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Въведен е празен стринг");
            }
        }
    }
}
