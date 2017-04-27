using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T>
    {
        private Node<T> previous;
        private Node<T> next;
        private T data;

        public Node(Node<T> previousNode, T data, Node<T> nextNode)
        {
            previous = previousNode;
            this.data = data;
            next = nextNode;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        public Node<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
        public Node<T> Previous
        {
            get
            {
                return previous;
            }
            set
            {
                previous = value;
            }
        }
    }  
}
