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
        private T[] itemList = new T[8];
        private int count;

        public T this[int index]
        {
            get
            {
                return itemList[index];
            }
            set
            {
                itemList[index] = value;
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
            itemList[count] = item;
            count++;
        }

        private void EnsureThereIsSpace()
        {
            if (count > itemList.Length)
            {
                Array.Resize(ref itemList, itemList.Length * 2);
            }
        }

        public void Clear()
        {
            itemList = null;
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
                array[index] = itemList[index];
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(itemList, item);
        }

        public void Insert(int index, T item)
        {
            if (index == count)
            {
                Add(item);
            }
            ShiftRight(index);
            itemList[index] = item;
        }

        private void ShiftRight(int index)
        {
            Array.Resize(ref itemList, itemList.Length + 1);
            for (int i = itemList.Length - 2; i >= index; i--)
            {
                itemList[i] = itemList[i + 1];
            }
            count++;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < itemList.Length - 1; i++)
            {
                itemList[i] = itemList[i + 1];
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
            foreach (var item in itemList)
            {
                yield return item;                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
