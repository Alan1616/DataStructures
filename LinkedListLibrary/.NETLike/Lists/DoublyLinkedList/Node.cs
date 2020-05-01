using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures.Lists
{
    public partial class CustomDoublyLinkedList<T> : IEnumerable<T>
    {
        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }
            internal Node()
            {
                this.Next = null;
                this.Previous = null;
            }
            internal Node(T value, Node<T> next)
            {
                this.Value = value;
                this.Next = Next;
            }
            internal Node(T value, Node<T> next, Node<T> previous)
            {
                this.Value = value;
                this.Next = next;
                this.Previous = previous;
            }
        }


    }
 
}

