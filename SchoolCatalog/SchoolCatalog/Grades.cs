using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    public class Grades
    {
        private int[] grades;

        public Grades(int[] grades)
        {
            this.grades = grades;
        }

        public bool AreSameGrades(int[] other)
        {
            return this.grades.SequenceEqual(other);
        }
        public bool AreSameGrades(Grades other)
        {
            return this.grades.SequenceEqual(other.grades);
        }
    }
}
