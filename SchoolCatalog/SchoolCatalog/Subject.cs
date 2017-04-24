using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    public class Subject
    {
        private string nameOfSubject;
        private Grades subjectGrades;

        
        public Subject(string name, Grades grades) : this(name)
        {
            this.subjectGrades = grades;
        }
        public Subject(string name)
        {
            this.nameOfSubject = name;
        }

        public double GeneralAverage()
        {
            return subjectGrades.GeneralAverage();
        }

        public void AddGrade(int newGrade)
        {
            subjectGrades.AddGrade(newGrade);
        }

        public int GradesOfTen()
        {
            return subjectGrades.GradesOfTen();
        }

        public bool IsSameSubject(string other)
        {
            return this.nameOfSubject.Equals(other);
        }
        public bool IsSameSubject(Subject other)
        {
            return this.nameOfSubject.Equals(other.nameOfSubject);
        }
    }
}
