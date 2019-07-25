using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary.DoublyLinkedList
{
    public class CustomDoublyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;
        public int Count
        {
            get
            {
                return count;
            }
        }
        public bool IsEmpty
        {
            get
            {
                if (head != null)
                    return false;
                return true;
            }
        }
        public T this[int index]
        {
            get
            {
                return Get(index);
            }

        }
        public CustomDoublyLinkedList()
        {
            head = new Node<T>();
            tail = head;
        }
        public CustomDoublyLinkedList(T value)
        {

            head = new Node<T>(value,null,null);
            tail = head;
            count++;
        }
        public void Add(int index, T value)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException();
            if (index > count)
                index = count;

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
                Node<T> toJoin = new Node<T>(value, current.Next, current);
                if (current.Next != null)
                    current.Next.Previous = toJoin;
                current.Next = toJoin;


                if (index == count)
                    tail = current.Next;
                count++;
            }
        }
        public void Add(T value)
        {
            Add(count, value);
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
        public string ToStringBackwards()
        {
            Node<T> current = tail;
            StringBuilder output = new StringBuilder();
            output.Append("null<-");
            while (current != null)
            {
                output.Append($"<-{ current.Value}");
                current = current.Previous;
            }
            return output.ToString();
        }
        public void Remove(int index)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("index out of range");
            if (index == 0)
            {
                head = head.Next;
                head.Previous = null;
                if (head == tail)
                {
                    tail = null;
                }
            }
            else
            {
                Node<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;

                }
                current.Next = current.Next.Next;
                if (current.Next != null)
                    current.Next.Previous = current;
                else
                {
                    tail = current;
                }
            }
            count--;
        }
        public void Clear()
        {
            head = null;
            tail = null;
        }
        public int FirstIndexOf(T value)
        {
            Node<T> current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Value.Equals(value))
                    return i;
                current = current.Next;
            }
            return -1;
        }
        public CustomDoublyLinkedList<int> IndexesOf(T value)
        {
            CustomDoublyLinkedList<int> output = new CustomDoublyLinkedList<int>();
            Node<T> current = head;

            for (int i = 0; i < count; i++)
            {
                if (current.Value.Equals(value))
                    output.Add(i);
                current = current.Next;
            }


            return output;
        }
        public bool Contains(T value)
        {
            if (FirstIndexOf(value) >= 0)
                return true;
            return false;
        }

        private T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException();
            Node<T> current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
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
