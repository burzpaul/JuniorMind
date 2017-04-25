using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    public class List<T> : IList<T>
    {
        private T[] listItems = new T[8];
        private int count;

        public T this[int index]
        {
            get
            {
                return listItems[index];
            }
            set
            {
                listItems[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            EnsureThereIsSpace();
            listItems[count] = item;
            count++;
        }

        private void EnsureThereIsSpace()
        {
            if (count > listItems.Length)
            {
                Array.Resize(ref listItems, listItems.Length * 2);
            }
        }

        public void Clear()
        {
            listItems = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            return (IndexOf(item) == -1) ? false : true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int index = arrayIndex; index < array.Length; index++)
            {
                array[index] = listItems[index];
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(listItems, item);
        }

        public void Insert(int index, T item)
        {
            if (index == count)
            {
                Add(item);
            }
            ShiftRight(index);
            listItems[index] = item;
        }

        private void ShiftRight(int index)
        {
            Array.Resize(ref listItems, listItems.Length + 1);
            for (int i = listItems.Length - 2; i >= index; i--)
            {
                listItems[i] = listItems[i + 1];
            }
            count++;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < listItems.Length - 1; i++)
            {
                listItems[i] = listItems[i + 1];
            }
            count--;
        }

        public bool Remove(T item)
        {
            var indexOfItem = IndexOf(item);

            if (indexOfItem > -1)
            {
                RemoveAt(indexOfItem);
                return true;
            }
            return true;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
        }

        public IEnumerator<T> GetEnumerator()
        {
           foreach(var itemT in listItems)
            {
                yield return itemT;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
