using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01_03.Student
{
    // enums
    public enum Specailities { SoftwareEngineer, WebDeveloper, MobileDeveloper, SystemAdministrator };
    public enum Univrsities { SofiaUniversity, TelerikAcademy, TechnicalUniversity, ShvishtoivUniverity };
    public enum Faculties { MahtematicsAndInformatics, InformationTechnologies, ComputerScience };

    // class definitions
    class Student : ICloneable, IComparable<Student>
    {

        // private fields
        private string firstName;
        private string middleName;
        private string lastName;
        private ulong ssn;
        private string address;
        private string phone;
        private string email;
        private byte course;
        private Specailities specaility;
        private Univrsities university;
        private Faculties faculty;

        // public properties
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Invalid first name");
                }
                firstName = value;
            }
        }
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentException("Invalid middle name");
                middleName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentException("Invalid last name");
                lastName = value;
            }
        }

        public string SSN
        {
            get { return string.Format("{0:D10}", ssn); }
            set
            {
                if (value.Length != 10 || !ulong.TryParse(value, out ssn))
                {
                    ssn = 0;
                    throw new ArgumentException("Invalid SSD format");
                }

            }
        }
        public string Address
        {
            get
            {
                if (address == null || address == "")
                    return "Not specified";
                else
                    return address;
            }
            set { address = value; }
        }
        public string Phone
        {
            get
            {
                if (phone == null || phone == "")
                    return "Not specified";
                else
                    return phone;
            }
            set { phone = value; }
        }
        public string Email
        {
            get
            {
                if (email == null || email == "")
                    return "Not specified";
                else
                    return email;
            }
            set { email = value; }
        }
        public byte Course
        {
            get
            {
                if (course > 5)
                    throw new ArgumentOutOfRangeException("Invalid course");
                return course;
            }
            set { course = value; }
        }
        public Specailities Specaility
        {
            get { return specaility; }
            set { specaility = value; }
        }
        public Univrsities University
        {
            get { return university; }
            set { university = value; }
        }
        public Faculties Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        //constructor
        public Student(string fname, string mname, string lname, string ssnumber, byte courseNumber, Specailities spec,
                        Univrsities univ, Faculties fac, string addr = null, string phon = null, string mail = null)
        {
            this.FirstName = fname;
            this.MiddleName = mname;
            this.LastName = lname;
            this.SSN = ssnumber;
            this.Course = courseNumber;
            this.Specaility = spec;
            this.University = univ;
            this.Faculty = fac;
            this.Address = addr;
            this.Phone = phon;
            this.Email = mail;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student)) return false;
            Student dest = (Student)obj;
            if (ReferenceEquals(this, dest))
                return true;
            Type destType = obj.GetType();
            PropertyInfo[] destProperties = destType.GetProperties();
            Type srcType = this.GetType();
            PropertyInfo[] srcProperties = srcType.GetProperties();
            for (int i = 0; i < srcProperties.Length; i++)
                if (!srcProperties[i].GetValue(obj).Equals(srcProperties[i].GetValue(this)))
                    return false;
            return true;
        }

        public override int GetHashCode()
        {
            int newHash = 13;
            unchecked
            {
                Type srcType = this.GetType();
                PropertyInfo[] srcProperties = srcType.GetProperties();
                for (int i = 0; i < srcProperties.Length; i++)
                    newHash = newHash * 7 + srcProperties[i].GetValue(this).GetHashCode();
            }
            return newHash;
        }
        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }
        public static bool operator !=(Student student1, Student student2)
        {
            return !Student.Equals(student1, student2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + this.FirstName + " " + this.MiddleName + " " + this.LastName + " SSN:" + this.SSN + Environment.NewLine);
            sb.Append("Address: " + this.Address + " Phone:" + this.Phone + " E-mail: " + this.Email + Environment.NewLine);
            sb.Append("Speciality: " + this.Specaility + " University: " + this.University + " Faculty: " + this.Faculty);
            return sb.ToString();
        }
        object ICloneable.Clone() // task 2
        {
            return this.Clone();
        }
        public Student Clone() // task 2
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Course, this.Specaility,
                               this.University, this.Faculty, this.Address, this.Phone, this.Email);
        }

        public int CompareTo(Student other) // task 3
        {
            int compare = (this.FirstName + this.MiddleName + this.LastName).CompareTo(other.FirstName + other.MiddleName + other.LastName);
            if (compare != 0)
                return compare;
            else
                return this.SSN.CompareTo(other.SSN);
        }


    }
}
