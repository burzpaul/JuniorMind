using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    public class Student
    {
        private string nameOfStudent;
        private Subject[] subjects;

        public Student(string name, Subject[] subjects)
        {
            this.nameOfStudent = name;
            this.subjects = subjects;
        }

        public bool IsSameStudent(string other)
        {
            return this.nameOfStudent.Equals(other);
        }

        public bool IsSameStudent(Student other)
        {
            return this.nameOfStudent.Equals(other.nameOfStudent);
        }

        public int WhoIsFirstAlphabetically(Student otherStudent)
        {
            return string.Compare(nameOfStudent, otherStudent.nameOfStudent);
        } 
    }
}
