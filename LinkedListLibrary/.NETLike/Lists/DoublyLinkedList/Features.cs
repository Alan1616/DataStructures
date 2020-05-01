using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CustomDataStructures.Tools;
namespace CustomDataStructures.Lists
{
    public partial class CustomDoublyLinkedList<T> : IEnumerable<T>
    {
        public void ForEach(Action<T> action)
        {
            foreach (T e in this)
                action(e);
        }

        public bool TrueForAll(Func<T, bool> predicate)
        {
            foreach (T e in this)
            {
                if (!predicate(e))
                    return false;
            }
            return true;
        }

        public void Reverse()
        {
            Node<T> current = head;
            Node<T> tmp;

            while (current != null)
            {
                tmp = current.Next;
                current.Next = current.Previous;
                current.Previous = tmp;
                current = current.Previous;
            }

            tmp = head;
            head = tail;
            tail = tmp;
        }
    }
}
