using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary.SinglyLinkedList;

namespace LinkedListLibrary.Stack
{
    /// <summary>
    /// Represents custom LIFO queue 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomStack<T> 
    {
        private CustomLinkedList<T> dataSource;

        public int Count
        {
            get { return dataSource.Count; }
        }
        public bool isEmpty
        {
            get { return dataSource.isEmpty; }
        }

        public CustomStack()
        {
            dataSource = new CustomLinkedList<T>();
        }
        public CustomStack(T value)
        {
            dataSource = new CustomLinkedList<T>(value);
        }

        public void Push(T value)
        {
            dataSource.Add(value);
        }

        public T Pop()
        {
            if (Count > 0)
            {
                T output = dataSource[Count - 1];
                dataSource.Remove(Count - 1);
                return output;

            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public T Peek()
        {
            if (Count > 0)
            {
                T output = dataSource[Count - 1];
                return output;

            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool Contains(T value)
        {
            return dataSource.Contains(value);
        }

        public void Reverse()
        {
            dataSource.Reverse();
        }
 

        public void Clear()
        {
            dataSource.Clear();
        }



    }
}
