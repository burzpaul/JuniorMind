using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private int count;

        public LinkedList()
        {
            head = new Node<T>(null, default(T), null);
            head.Previous = head;
            head.Next = head;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Add(T data)
        {
            AddLast(data);
        }

        public void AddFirst(T data)
        {
            AddAfter(head, data);
        }

        public void AddLast(T data)
        {
            AddAfter(head.Previous, data);
        }

        public void AddAfter(Node<T> node, T data)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            Node<T> toInsert = new Node<T>(node, data, node.Next);
            if (Find(toInsert.Previous) != null || Find(toInsert.Next.Value) != null) 
            {
                node.Next.Previous = toInsert;
                node.Next = toInsert;
                count++;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void AddBefore(Node<T> node, T data)
        {
            AddAfter(node.Previous, data);
        }

        public Node<T> Find(T data)
        {
            Node<T> node = head.Next;
            while (node != head)
            {
                if (node.Value.Equals(data))
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }

        public Node<T> FindLast(T data)
        {
            Node<T> node = head.Previous;
            while (node != head)
            {
                if (node.Value.Equals(data))
                {
                    return node;
                }
                node = node.Previous;
            }
            return null;
        }

        public bool Contains(T data)
        {
            return Find(data) != null ? true : false;
        }

        public bool Remove(T data)
        {
            Node<T> toRemove = Find(data); if (toRemove != null)
            {
                Remove(toRemove);
                return true;
            }
            return false;
        }

        private void Remove(Node<T> toRemove)
        {
            toRemove.Previous.Next = toRemove.Next;
            toRemove.Next.Previous = toRemove.Previous;
            count--;
        }

        public void RemoveFirst()
        {
            if (count > 0)
            {
                Remove(head.Next);
            }
        }

        public void RemoveLast()
        {
            if (count > 0)
            {
                Remove(head.Previous);
            }
        }

        public void Clear()
        {
            head.Next = head;
            head.Previous = head;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = head.Next;

            while (node != head)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
