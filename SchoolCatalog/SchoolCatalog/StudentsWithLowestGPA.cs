using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    class StudentsWithLowestGPA
    {
        private Student[] students;
        private int index;

        public StudentsWithLowestGPA(Student[] students)
        {
            this.students = students;
            index = students.Length - 1;
            StudentsOrderedByGPA();
        }

        public bool GetNext(out Student student)
        {
            
            if (index > -1)
            {
                student = this.students[index--];
                return true;
            }
            student = null;
            return false;
        }

        private void StudentsOrderedByGPA()
        {
            new StudentsOrderedByGPA(students);    
        }
    }
}
