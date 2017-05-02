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
        private string nodeId;

        public Node(Node<T> previousNode, T data, Node<T> nextNode,string listId)
        {
            previous = previousNode;
            this.data = data;
            next = nextNode;
            this.nodeId = listId;
        }
        public string NodeId
        {
            get
            {
                return nodeId;
            }
            set
            {
                nodeId = value;
            }
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
