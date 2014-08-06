using System;
using System.Collections.Generic;

namespace School
{
    public class Student :IEquatable<Student>
    {
        private string name;
        private int number;

        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Student name cannot be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }
            private set
            {
                if (value > 9999 && value < 100000)
                {
                    this.number = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Student number is out of boundaries");
                }
            }
        }

        public bool Equals(Student other)
        {
            return this.Name == other.Name && this.Number == other.Number;
        }
    }
}
