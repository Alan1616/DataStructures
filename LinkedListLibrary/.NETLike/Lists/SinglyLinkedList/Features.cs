using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CustomDataStructures.Tools;
namespace CustomDataStructures.Lists
{
    public partial class CustomLinkedList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        public IEnumerable<int> IndexesOf(T value)
        {
            CustomLinkedList<int> output = new CustomLinkedList<int>();
            int index = 0;
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    yield return index;

                current = current.Next;
                index++;
            }
        }
        public void Reverse()
        {
            Node<T> current = head;
            Node<T> previous = null;
            Node<T> next;

            for (int i = 0; i < count; i++)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;

            }
            head = previous;
        }
        public T[] ToArray()
        {
            T[] output = new T[count];
            Node<T> current = head;
            int index = 0;

            while (current!= null)
            {
                output[index] = current.Value;
                index++;
                current = current.Next;
            }
            return output;
        }
        public void ForEach(Action<T> action)
        {
            Node<T> current = head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
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

        public void AppendRange(IEnumerable<T> elements)
        {
            Node<T> current = head;
            while (current?.Next!= null)
            {
                current = current.Next;
            }

            foreach (T e in elements)
            {
                if (count == 0)
                {
                    head = new Node<T>(e);
                    current = head;
                }
                else
                {
                 
                    current.Next = new Node<T>(e);
                    current = current.Next;
                }
                
                count++;
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            if (head == null || head.Next == null)
                return;

            CustomLinkedList<T> left = new CustomLinkedList<T>();
            Node<T> tmp = head;
            left.head = tmp;
            Node<T> slowPointer = head;
            Node<T> fastPointer = head;


            while (fastPointer!= null && fastPointer.Next!= null)
            {
                tmp = slowPointer;
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;

            }

            tmp.Next = null;

            CustomLinkedList<T> right = new CustomLinkedList<T>();
            right.head = slowPointer;

            right.Sort(comparer);
            left.Sort(comparer);

             Merge(left, right,comparer);     
        }

        private void Merge(CustomLinkedList<T> left, CustomLinkedList<T> right, IComparer<T> comparer)
        {
            if (left.head == null)
                head = right.head;
            if (right.head == null)
                head = left.head;


            Node<T> currentLeft = left.head;
            Node<T> currentRight = right.head;

            if (CompareElements(comparer,currentLeft.Value,currentRight.Value) <= 0)
            {
                head = currentLeft;
                currentLeft = currentLeft.Next;
            }
            else
            {
                head = currentRight;
                currentRight = currentRight.Next;
            }

            Node<T> current = head;

            while (currentRight != null && currentLeft != null)
            {
                if (CompareElements(comparer, currentLeft.Value, currentRight.Value) <= 0)
                {
                    current.Next = currentLeft;
                 
                    current = current.Next;
                    current.Next = currentRight;

                }
                else
                {
                    current.Next = currentRight;
                    current = current.Next;
                    current.Next = currentLeft;
                }
                currentLeft = currentLeft.Next;
                currentRight = currentRight.Next;
            }

            if (currentRight != null)
                current.Next = currentRight;

            if (currentLeft != null)
                current.Next = currentLeft;
        }

        public void Sort()
        {
             Sort(null);
        }

    }
}
