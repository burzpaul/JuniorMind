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
        private string listId;

        public LinkedList(string listId)
        {
            this.listId = listId;
            head = new Node<T>(null, default(T), null, this.listId);
            head.Previous = head;
            head.Next = head;

        }

        public bool IsSameList(LinkedList<T> listId)
        {
            return this.listId.Equals(listId.listId);
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
            CheckNode(node);
            Node<T> toInsert = new Node<T>(node, data, node.Next, listId);
            node.Next.Previous = toInsert;
            node.Next = toInsert;
            count++;
        }

        private void CheckNode(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node cannot be null", "node");
            }
            if (node.NodeId != listId && node.NodeId != null) 
            {
                throw new InvalidOperationException("Node is not in the current LinkedList<T>");
            }
        }

        public void AddBefore(Node<T> node, T data)
        {
            CheckNode(node);
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

        public void Remove(Node<T> toRemove)
        {
            CheckNode(toRemove);
            toRemove.Previous.Next = toRemove.Next;
            toRemove.Next.Previous = toRemove.Previous;
            count--;
        }

        public void RemoveFirst()
        {
            IsListEmpty();
            Remove(head.Next);
        }

        public bool Equal(Node<T> a, Node<T> b)
        {
            return a.GetHashCode().Equals(b.GetHashCode());
        }

        private void IsListEmpty()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
        }

        public void RemoveLast()
        {
            IsListEmpty();
            Remove(head.Previous);
        }

        public void Clear()
        {
            head.Next = head;
            head.Previous = head;
            count = 0;
        }

        public Node<T> NodeIndex(int index)
        {
            if(index > count)
            {
                throw new IndexOutOfRangeException("index it to large");
            }
            Node<T> node = head.Next;
            while(index > 0)
            {
                node = node.Next;
                index--;
            }
            return node;
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
