using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    class StudentsWithMostHighestGrade
    {
        private Student[] students;
        private int index = 0;

        public StudentsWithMostHighestGrade(Student[] students)
        {
            this.students = students;
        }

        public bool GetNext(out Student student)
        {
            Array.Sort(students, delegate (Student student1, Student student2) 
            { return student2.GradesOfTen().CompareTo(student1.GradesOfTen()); });

            if (index < students.Length)
            {
                student = students[index++];
                return true;
            }
            student = null;
            return false;
        }
    }
}
