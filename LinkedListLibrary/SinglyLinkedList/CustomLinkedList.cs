using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary.SinglyLinkedList
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private int count;
        public T this[int index]
        {
            get { return Get(index); }
        }
        public int Count
        {
            get { return count; }
        }
        public bool isEmpty
        {
            get
            {
                if (head == null)
                    return true;
                else
                    return false;
            }
        }
        public CustomLinkedList()
        {
            head = null;
        }
        public CustomLinkedList(T value)
        {
            head = new Node<T>(value);
            count++;
        }
        public void Add(int index, T value)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index out of range");

            if (index > count)
            {
                index = count;
            }

            if (index == 0 || head == null)
            {
                head = new Node<T>(value, null);
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
            Add(count, value);
        }
        public void Clear()
        {
            head = null;
        }
        public void Remove(int index)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("Index out of range");
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
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;

                current = current.Next;
            }
            return false;
        }
        public int FirstIndexOf(T value)
        {
            int index = 0;
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return index;

                current = current.Next;
                index++;
            }
            return -1;
        }
        public CustomLinkedList<int> IndexesOf(T value)
        {
            CustomLinkedList<int> output = new CustomLinkedList<int>();
            int index = 0;
            Node<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    output.Add(index);

                current = current.Next;
                index++;
            }
            return output;
        }
        private T Get(int index)
        {
            if (index > (count - 1) || index < 0)
                throw new ArgumentOutOfRangeException("Index out of range!");

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

    }
}
