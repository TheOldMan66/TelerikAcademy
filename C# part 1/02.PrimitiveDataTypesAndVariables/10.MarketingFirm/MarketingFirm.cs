/* A marketing firm wants to keep record of its employees. Each record would have 
 * the following characteristics – first name, family name, age, gender (m or f), 
 * ID number, unique employee number (27560000 to 27569999). Declare the variables 
 * needed to keep the information for a single employee using appropriate data types 
 * and descriptive names. */

using System;

class MarketingFirm
{
    static void Main()
    {
        string firstName = "Pesho";
        string lastName = "Ivanov";
        byte age = 47;

        // Boolean is better choice for this data, but implementation is difficult
        char gender = 'm'; 

        // long data type is not best solution for next variable - kids 
        // (born in 21 century) have ID (ЕГН) with leading "0", so additional 
        /// check is required... or may be change data type to "string"..
        long idNumber = 7504230812;

        // Let's save 2 bytes and save just last 4 digits. First 4 are same for all employees.
        ushort employeeNumber = 5386; 
        Console.WriteLine("Employee {0} {1}: {2} years old {3}.\nID number: {4}, employee number: 2756{5}\n", firstName, lastName, age, gender, idNumber, employeeNumber);
    }
}


