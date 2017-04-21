using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    public class SchoolClass
    {
        private string nameOfClass;
        private Student[] students;

        public SchoolClass(string name, Student[] students) 
        {
            this.nameOfClass = name;
            this.students = students;
        }

        public void AddStudent(Student newStudent)
        {
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = newStudent;
        }

        public bool IsSameClass(string other)
        {
            return this.nameOfClass.Equals(other);
        }
    }
}