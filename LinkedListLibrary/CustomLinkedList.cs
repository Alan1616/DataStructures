﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public class CustomLinkedList<T>
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
        public void DisplayList()
        {
            Node<T> current = head;

            while (current != null)
            {
                Console.Write($"{current.Value}->");
                current = current.Next;
            }
        }

    }
}
