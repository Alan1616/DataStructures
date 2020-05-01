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
    public partial class  CustomList<T> : ICollection<T>, IEnumerable<T>,IList<T>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private T[] dataSource;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int count;
        public int Capacity
        {
            get => dataSource.Length;
            set
            {
                if (count > value)
                    throw new ArgumentOutOfRangeException();

                ResizeArray(value);
            }
        }

        public CustomList()
        {
            InitNewEmpty();
        }
        public CustomList(T value)
        {
            InitNewEmpty();
            Add(value);
        }

        private void InitNewEmpty()
        {
            count = 0;
            Capacity = 2;
        }

        public CustomList(IEnumerable<T> collection)
        {
            InitNewEmpty();
            AddRange(collection);
        }

        public T this[int index]
        {
            get => Get(index);
            set => Insert(index, value);
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            Insert(count, item);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T e in collection)
            {
                Add(e);
            }
        }

        public  void Insert(int index, T item)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index");
            if (index > count)
                index = count;

            if (index == count)
                InsertNew(item);

            else
            dataSource[index] = item;
        }

        private void InsertNew(T item)
        {
            if (IsFull())
            {
                AutomaticResizeArray();
            }

            dataSource[count] = item;
            count++;
        }
        public bool IsEmpty => count == 0;

        private bool IsFull() => count == Capacity;

        private void ResizeArray(int newSize)
        {
            T[] resized = new T[newSize];
            if (dataSource!= null)
            {
                for (int i = 0; i < dataSource.Length; i++)
                {
                    resized[i] = dataSource[i];
                }
            }   
            dataSource = resized;
        }
        private void AutomaticResizeArray()
        {
            ResizeArray((Capacity > 0 ? Capacity : 1) * 2);
        }

        private T Get(int index)
        {
            if (index > count - 1 || index < 0)
                throw new IndexOutOfRangeException();
            return dataSource[index];
        }

        public void Clear()
        {
            dataSource = null;
            InitNewEmpty();
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0 || arrayIndex > array.Length - 1)
                throw new ArgumentOutOfRangeException("index");
            if (array.Length < arrayIndex + count)
                throw new ArgumentException();

            for (int i = 0; i < count; i++)
            {
                array[i + arrayIndex] = dataSource[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                if (dataSource[i] != null)
                    yield return dataSource[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (AreElementsEqual(dataSource[i],item))
                    return i;
            }
            return -1;
        }

        public void RemoveAt(int index)
        {
            if (index > count - 1 || index < 0)
                throw new IndexOutOfRangeException();
            
            ShiftDataSourceLeft(index);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                ShiftDataSourceLeft(index);
                return true;
            }
            return false;
        }

        private void ShiftDataSourceLeft(int index)
        {
            T tmp = default(T);
            for (int i = count - 1; i >= index; i--)
            {
                T tmp2 = dataSource[i];
                dataSource[i] = tmp;
                tmp = tmp2;
            }
            count--;
        }
    }
}
