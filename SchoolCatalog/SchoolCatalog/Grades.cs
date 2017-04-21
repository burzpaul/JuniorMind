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

        public double GeneralAverage()
        {
            double result = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                result = result + grades[i];
            }
            return result / grades.Length;
        }    

        public void NewGrade(int newGrade)
        {
            Array.Resize(ref grades, grades.Length + 1);
            grades[grades.Length - 1] = newGrade;
        }
    }
}
