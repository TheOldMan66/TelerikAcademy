using System;

namespace Methods
{
    class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string otherInfo;
        private string cityOfBirth;

        public string FirstName {
            get {return firstName; }
            set {
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name cannot be empty");
                }
                else
                {
                    firstName = value;
                }
            } 
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name cannot be empty");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        public string DateOfBirth
        {
            get { return dateOfBirth.ToString("dd-MM-yyyy"); }
            set
            {
                DateTime validDate;
                if (!DateTime.TryParse(value, out validDate))
                {
                    throw new ArgumentNullException("Invalid date (or date format)");
                }
                else
                {
                    dateOfBirth = validDate;
                }
            }
        }
        public string CityOfBirth
        {
            get { return cityOfBirth; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("City of biryh cannot be empty");
                }
                else
                {
                    cityOfBirth = value;
                }
            }
        }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.dateOfBirth < other.dateOfBirth;
        }
    }
}
