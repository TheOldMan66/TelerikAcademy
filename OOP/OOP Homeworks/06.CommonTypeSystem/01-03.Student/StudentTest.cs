using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_03.Student
{
    class StudentTest
    {
        static void Main(string[] args)
        {
            Student firstStudent = new Student("Pesho", "Ivanov", "Stoyanov", "0222222222", 3, Specailities.SoftwareEngineer,
                Univrsities.TelerikAcademy, Faculties.ComputerScience, "22 Latinka str", "0888123456", "mail@example.com");
            Student secondStudent = new Student("Gosho", "Petrov", "Nikolov", "0123456789", 2, Specailities.SoftwareEngineer,
                Univrsities.TelerikAcademy, Faculties.ComputerScience, "22 Latinka str", "0888123456", "mail@example.com");
            Student thirdStudent = new Student("Pesho", "Ivanov", "Stoyanov", "1234567890", 3, Specailities.SoftwareEngineer,
                Univrsities.TelerikAcademy, Faculties.ComputerScience, "22 Latinka str", "0888123456", "mail@example.com");
            List<Student> list = new List<Student>();
            list.Add(firstStudent);
            list.Add(secondStudent);
            list.Add(thirdStudent);
            list.Sort();
            foreach (Student student in list)
            {
                Console.WriteLine(student);
                Console.WriteLine(new string('-',50));
            }
        }
    }
}
