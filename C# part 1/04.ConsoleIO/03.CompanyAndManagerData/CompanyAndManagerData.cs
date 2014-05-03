/* A company has name, address, phone number, fax number, web site and manager. 
 * The manager has first name, last name, age and a phone number. Write a program 
 * that reads the information about a company and its manager and prints them on the console. */

using System;

namespace _03.CompanyAndManagerData
{
    public class Person
    {
        public string firstName;
        public string lastName;
        public byte age;
        public string phone;
    }

    class Company
    {
        public string name;
        public string address;
        public string phone;
        public string fax;
        public string webSite;
        public Person manager;
    }

    class CompanyAndManagerData
    {
        static void Main()
        {
            Company company = new Company();
            Console.Write("Enter company name: ");
            company.name = Console.ReadLine();
            Console.Write("Enter company address: ");
            company.address = Console.ReadLine();
            Console.Write("Enter company phone: ");
            company.phone = Console.ReadLine();
            Console.Write("Enter company fax: ");
            company.fax = Console.ReadLine();
            Console.Write("Enter company website: ");
            company.webSite = Console.ReadLine();

            company.manager = new Person();
            Console.Write("Enter manager's first name: ");
            company.manager.firstName = Console.ReadLine();
            Console.Write("Enter manager's last name: ");
            company.manager.lastName = Console.ReadLine();
            bool correctInput = false;
            do
            {
                Console.Write("Enter manager's age: ");
                correctInput = byte.TryParse(Console.ReadLine(), out company.manager.age);
                if (!correctInput)
                    Console.WriteLine("Incorrect input. Try again.");
            } while (!correctInput);
            Console.Write("Enter manager's phone: ");
            company.manager.phone = Console.ReadLine();

            Console.WriteLine(new string('-',40));
            Console.WriteLine("Company name    : {0}",company.name);
            Console.WriteLine("Company address : {0}",company.address);
            Console.WriteLine("Company phone   : {0}", company.name);
            Console.WriteLine("Company fax     : {0}", company.address);
            Console.WriteLine("Company website : {0}", company.name);
            Console.WriteLine("Company manager : {0} {1}", company.manager.firstName, company.manager.lastName);
            Console.WriteLine("\n{0} {1} is {2} years old. You can call him/her at phone {3}", 
                company.manager.firstName,company.manager.lastName,company.manager.age,company.manager.phone);
        }
    }
}
