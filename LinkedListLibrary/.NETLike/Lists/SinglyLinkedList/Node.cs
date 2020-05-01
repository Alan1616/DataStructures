using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures.Lists
{
    public partial class CustomLinkedList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }

            internal Node()
            {
                this.Next = null;
            }
            internal Node(T value)
            {
                this.Value = value;
                this.Next = null;
            }
            internal Node(T value, Node<T> next)
            {
                this.Value = value;
                this.Next = next;
            }
        }

    }
   
}
