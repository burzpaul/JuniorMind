using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    class StudentsOrderedByGPA
    {
        private Student[] student;
        private int index = 0;

        public StudentsOrderedByGPA(Student[] candidate)
        {
            this.student = candidate;
            HeapSort();
        }

        public bool GetNext(out Student student)
        {
            if (index < this.student.Length)
            {
                student = this.student[index++];
                return true;
            }
            student = null;
            return false;
        }

        private void HeapSort()
        {
            int n = student.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref student[0], ref student[i]);

                Heapify(i, 0);
            }
        }

        private void Heapify(int n, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < n && student[left].GpaCompare(student[largest]) == -1) 
            {
                largest = left;
            }
            if (right < n && student[right].GpaCompare(student[largest]) == -1) 
            {
                largest = right;
            }
            if (largest != root)
            {
                Swap(ref student[root], ref student[largest]);
                Heapify(n, largest);
            }
        }

        private static void Swap(ref Student student1, ref Student student2)
        {
            var temp = student1;
            student1 = student2;
            student2 = temp;
        }
    }
}
