using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    class SpecificGPAStudents
    {
        private double specificGPA;
        private Student[] students;

        public SpecificGPAStudents(double specificGPA, Student[] students)
        {
            this.specificGPA = specificGPA;
            this.students = students;
        }

        public bool SearchForStudents(out Student student)
        {
            for (int i = 0; i < students.Length; i++) 
            {
                if (specificGPA == students[i].GeneralAverage())
                {
                    student = students[i];
                    return true;
                }
            }
            student = null;
            return false;
        }
    }
}
