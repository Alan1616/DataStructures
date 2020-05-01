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
    public partial class CustomDoublyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
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
            get => Get(index);
            set => Add(index, value);
        }
        public CustomDoublyLinkedList()
        {
            head = null;
            tail = head;
        }
        public CustomDoublyLinkedList(T value)
        {

            head = new Node<T>(value,null,null);
            tail = head;
            count++;
        }
        public CustomDoublyLinkedList(IEnumerable<T> collection)
        {
            AddRange(collection);
        }

        public void AddRange(IEnumerable collection)
        {
            Node<T> current = tail;
            foreach (T item in collection)
            {
                if (head == null)
                {
                    current = new Node<T>(item, null, current);
                    head = current;
                }
                else
                {
                    current.Next = new Node<T>(item, null, current);
                    current = current.Next;
                }               
              
                tail = current;
               
            }
            
        }
        public void Add(int index, T value)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException();
            if (index > count)
                index = count;

            Node<T> current;

            if (index == 0 || head == null)
            {
                head = new Node<T>(value, null);
                current = head;
            }
            else
            {
                current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                Node<T> toJoin = new Node<T>(value, current.Next, current);
                if (current.Next != null)
                    current.Next.Previous = toJoin;
                current.Next = toJoin;     
            }

            if (index == count)
                tail = current.Next;
            count++;
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
                if (AreElementsEqual(current.Value,value))
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
                if (AreElementsEqual(current.Value, value))
                    output.Add(i);
                current = current.Next;
            }


            return output;
        }
        public bool Contains(T value)
        {
            return FirstIndexOf(value) >= 0;
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
