using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CustomDataStructures.Tools;

namespace CustomDataStructures.Lists
{
    [DebuggerDisplay("Count = {count}")]
    public partial class CustomLinkedList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        private Node<T> head;
        private int count;
        public T this[int index]
        {
            get => Get(index);
            set => Insert(index,value);
        }
        public int Count
        {
            get => count;
        }
        public bool IsEmpty
        {
            get => head == null;
        }

        public bool IsReadOnly => false;

        public CustomLinkedList()
        {
            head = null;
        }
        public CustomLinkedList(T value)
        {
            head = new Node<T>(value);
            count++;
        }

        public CustomLinkedList(CustomLinkedList<T> linkedList)
        {
            if (linkedList.head == null)
                throw new ArgumentNullException("linkedList");
          

            head = new Node<T> (linkedList.head.Value);
            Node<T> current = head;
            Node<T> otherCurrent = linkedList.head.Next;
            while (otherCurrent != null)
            {
                current.Next = new Node<T>(otherCurrent.Value);
                current = current.Next;
                otherCurrent = otherCurrent.Next;
            }

        }

        public void Insert(int index, T value)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index");

            if (index > count)
            {
                index = count;
            }

            if (index == 0 || head == null)
            {
                head = new Node<T>(value, head);
                count++;
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(value, current.Next);
                count++;
            }
        }
        public void Add(T value)
        {
            Insert(count, value);
        }
        public void Clear()
        {
            head = null;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("Index");
            Node<T> current = head;

            if (index == 0)
            {
                head = current.Next;
            }

            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                if (current.Next != null)
                    current.Next = current.Next.Next;
                else
                    current.Next = null;
            }

            if (count > 0)
                count--;
        }
        public bool Contains(T value)
        {
            return IndexOf(value) >= 0;
        }
        public int IndexOf(T value)
        {
            int index = 0;
            Node<T> current = head;
            while (current != null)
            {
                if(AreElementsEqual(current.Value,value))
                    return index;

                current = current.Next;
                index++;
            }
            return -1;
        }

        public int LastIndexOf(T value)
        {
            int lastIndex = -1;
            int index = 0;
            Node<T> current = head;
            while (current != null)
            {
                if (AreElementsEqual(current.Value, value))
                    lastIndex = index;

                current = current.Next;
                index++;
            }
            return lastIndex;
        }

        private T Get(int index)
        {
            if (index > (count - 1) || index < 0)
                throw new ArgumentOutOfRangeException("Index");

            Node<T> current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }
        public override string ToString()
        {
            Node<T> current = head;
            StringBuilder output = new StringBuilder();
            while (current != null)
            {
                output.Append($"{ current.Value}->");
                current = current.Next;
            }
            output.Append("null");

            return output.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currnet = head;

            for (int i = 0; i < count; i++)
            {
                yield return currnet.Value;
                currnet = currnet.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0 || arrayIndex > array.Length - 1)
                throw new ArgumentOutOfRangeException("arrayIndex");
            if (count > array.Length - arrayIndex)
                throw new ArgumentException();

            Node<T> current = head;
            while (current != null)
            {
                array[arrayIndex] = current.Value;
                arrayIndex++;
            }
        }
        public bool Remove(T item)
        {
            int index = 0;
            Node<T> current = head;
            while (current != null)
            {
                if (AreElementsEqual(current.Value, item))
                {
                    RemoveAt(index);
                    return true;
                }
                   
                index++;
                current = current.Next;
            }
            return false;
        }

    }
}
