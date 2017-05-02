using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class List<T> : IList<T>
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
                if (count == 0)
                {
                    throw new ArgumentNullException("source is null");
                }
                if (count > Int32.MaxValue)
                {
                    throw new OverflowException("the number of elements in source is larger than MaxValue");
                }
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

        public void Clear()
        {
            itemList = null;
            count = 0;
        }

        private void EnsureThereIsSpace()
        {
            if (count > itemList.Length)
            {
                Array.Resize(ref itemList, itemList.Length * 2);
            }
        }

        public bool Contains(T item)
        {
            return (IndexOf(item) == -1) ? false : true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length == 0)
            {
                throw new ArgumentNullException("array is null");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex is less than 0");
            }
            if (array.Length - arrayIndex < count)
            {
                throw new ArgumentException("The number of elements in the source List<T> is " +
                                                "greater than the available space from arrayIndex " +
                                                "to the end of the destination array.");
            }
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
            CheckIndex(index);
            if (index == count)
            {
                Add(item);
            }
            ShiftRight(index);
            itemList[index] = item;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException();
            }
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
            CheckIndex(index);
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
