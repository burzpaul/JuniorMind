﻿using System;
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

        public double GeneralAverage()
        {
            double gpaTotal = 0;
            for (int i = 0; i < subjects.Length; i++)
            {
                gpaTotal = gpaTotal + subjects[i].GeneralAverage();
            }
            return  gpaTotal / subjects.Length;
        }

        public bool IsSameStudent(string other)
        {
            return this.nameOfStudent.Equals(other);
        }

        public bool IsSameStudent(Student other)
        {
            return this.nameOfStudent.Equals(other.nameOfStudent);
        }

        public int GpaCompare(Student other)
        {
            return GeneralAverage().CompareTo(other.GeneralAverage());
        }

        public int WhoIsFirstAlphabetically(Student otherStudent)
        {
            return string.Compare(nameOfStudent, otherStudent.nameOfStudent);
        } 
    }
}
