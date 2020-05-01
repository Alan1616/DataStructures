using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomDataStructures.Lists;

namespace CustomDataStructures.Queues
{
    /// <summary>
    /// Represents custom LIFO queue 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomStack<T> : IEnumerable<T>
    {
        private CustomList<T> dataSource;
        public int Count
        {
            get { return dataSource.Count; }
        }
        public bool IsEmpty
        {
            get { return dataSource.IsEmpty; }
        }

        public CustomStack()
        {
            dataSource = new CustomList<T>();
        }
        public CustomStack(T value)
        {
            dataSource = new CustomList<T>(value);
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
                dataSource.RemoveAt(Count - 1);
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
