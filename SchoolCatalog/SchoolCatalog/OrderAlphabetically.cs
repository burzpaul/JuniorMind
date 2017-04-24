using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    class OrderAlphabetically : IEnumerable<Student>
    {
        private Student[] students;

        public OrderAlphabetically(Student[] candidate)
        {
            this.students = candidate;
            HeapSort();
        }

        private void HeapSort()
        {
            int n = students.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref students[0], ref students[i]);

                Heapify(i, 0);
            }
        }

        private void Heapify(int n, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < n && students[left].WhoIsFirstAlphabetically(students[largest]) != -1)
            {
                largest = left;
            }
            if (right < n && students[right].WhoIsFirstAlphabetically(students[largest]) != -1)
            {
                largest = right;
            }
            if (largest != root)
            {
                Swap(ref students[root], ref students[largest]);
                Heapify(n, largest);
            }
        }

        private static void Swap(ref Student student1, ref Student student2)
        {
            var temp = student1;
            student1 = student2;
            student2 = temp;
        }

        public IEnumerator<Student> GetEnumerator()
        {
            foreach(var student in students)
            {
                yield return student;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
