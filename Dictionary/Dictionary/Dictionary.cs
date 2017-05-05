using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        class Entry
        {
            public TKey key;
            public TValue value;
            public int next = -1;

            public Entry(TKey key, TValue value, int next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }

        private int[] buckets;
        private Entry[] entry;
        private int elementsCount = 0;
        private int count = 0;
        private int nextFreeSpace = -1;

        public Dictionary(int size)
        {
            buckets = new int[size];
            entry = new Entry[size];
            for (int i = 0; i < entry.Length; i++)
            {
                buckets[i] = -1;
            }
        }

        public ICollection<TKey> Keys => throw new NotImplementedException();//Not Implemented

        public ICollection<TValue> Values => throw new NotImplementedException();//Not Implemented

        public int Count
        {
            get
            {
                return elementsCount;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return entry[FindIndex(key)].value;
            }
            set
            {
                entry[FindIndex(key)].value = value;
            }
        }

        public bool ContainsKey(TKey key)
        {
            return FindIndex(key) > -1;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return FindIndex(item.Key) > -1;
        }

        private int FindIndex(TKey key)
        {
            int bucketIndex = GetKeyIndex(key);
            for (var index = buckets[bucketIndex]; index > -1; index = entry[index].next)
            {
                if (entry[index].key.Equals(key))
                {
                    return index;
                }
            }
            return -1;
        }

        public void Add(TKey key, TValue value)
        {
            var bucketIndex = GetKeyIndex(key);
            var index = GetNextFreeSpace();
            entry[index] = new Entry(key, value, buckets[bucketIndex]);
            buckets[bucketIndex] = index;
            count++;
            elementsCount++;
        }

        private int GetKeyIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % buckets.Length);
        }

        public bool Remove(TKey key)
        {
            int bucketIndex = GetKeyIndex(key);
            int previous = -1;
            for (var index = buckets[bucketIndex]; index > -1; index = entry[index].next)
            {
                if (entry[index].key.Equals(key))
                {
                    RemoveEntry(bucketIndex, previous, index);
                    elementsCount--;
                    return true;
                }
                previous = index;
            }
            return false;
        }

        private int GetNextFreeSpace()
        {
            if (nextFreeSpace > -1)
            {
                var index = nextFreeSpace;
                nextFreeSpace = entry[nextFreeSpace].next;
                return index;
            }
            return count;   
        }

        private void RemoveEntry(int bucketIndex, int previous, int index)
        {
            if (previous < 0)
            {
                buckets[bucketIndex] = entry[index].next;

            }
            else
            {
                entry[previous].next = entry[index].next;

            }
            entry[index].key = default(TKey);
            entry[index].value = default(TValue);
            entry[index].next = nextFreeSpace;
            nextFreeSpace = index;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }//Not Implemented

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }//Not Implemented

        public void Clear()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                entry[i] = null;
                buckets[i] = -1;
            }
            elementsCount = 0;
            elementsCount = 0;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }//Not Implemented

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }//Not Implemented

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < entry.Length; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(entry[i].key, entry[i].value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
