﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomDataStructures.Lists;

namespace CustomDataStructures.Queues
{
    public  class CustomQueue<T> : IEnumerable<T>
    {
        private CustomLinkedList<T> dataSource;

        public int Count
        {
            get { return dataSource.Count; }
        }
        public bool isEmpty
        {
            get { return dataSource.IsEmpty; }
        }

        public CustomQueue()
        {
            dataSource = new CustomLinkedList<T>();
        }
        public CustomQueue(T value)
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
                T output = dataSource[0];
                dataSource.RemoveAt(0);
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
                T output = dataSource[0];
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

        public IEnumerator<T> GetEnumerator()
        {
            return dataSource.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
