using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public partial class Course
    {
        private string name;
        private string teacherName;

        public IList<string> Students { get; set; }
        public string Town { get; set; }

        public Course(string name)
            : this(name, null, new List<string>())
        {
        }

        public Course(string name, string teacherName)
            : this(name, teacherName, new List<string>())
        {
        }

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Town = null;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name cannot be empty");
                }

                name = value;
            }
        }
        
        public string TeacherName
        {
            get { return teacherName; }
            set { teacherName = value; }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }

    }
}
