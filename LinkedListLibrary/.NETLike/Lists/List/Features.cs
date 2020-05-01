using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CustomDataStructures.Tools;

namespace CustomDataStructures.Lists
{
    public partial class CustomList<T> : ICollection<T>, IEnumerable<T>, IList<T>
    {
        private static readonly Random rnd = new Random();

        public void ForEach(Action<T> action)
        {
            foreach (T e in this)
                action(e);
        }

        public bool TrueForAll(Func<T,bool> predicate) 
        {
            foreach (T e in this)
            {
                if (!predicate(e))
                    return false;
            }
            return true;        
        }

        public void Reverse()
        {
            for (int i = 0; i < count/2; i++)
            {
                T tmp = dataSource[i];
                dataSource[i] = dataSource[count - 1 - i];
                dataSource[count - 1 - i] = tmp;
            }
        }

        public void Sort() => Sort(null);


        public void Sort(IComparer<T> comparer) 
        {
            dataSource = ImmutableSort(comparer).dataSource;
        }

        private CustomList<T> ImmutableSort(IComparer<T> comparer)
        {
            if (count <= 1)
                return this;
            
            int pivot = rnd.Next(0, count);
            T pivotValue = dataSource[pivot];
            CustomList<T> smaller = new CustomList<T>();
            CustomList<T> bigger = new CustomList<T>();

            for (int i = 0; i < count; i++)
            {
                if (i!= pivot)
                {
                    if (CompareElements(comparer, dataSource[i], pivotValue ) <= 0)
                        smaller.Add(dataSource[i]);
                    else
                        bigger.Add(dataSource[i]);
                }      
            }

            return Merge(smaller.ImmutableSort(comparer), pivotValue, bigger.ImmutableSort(comparer));
        
        }

        private CustomList<T> Merge(CustomList<T> smaller, T pivotValue, CustomList<T> bigger)
        {
            CustomList<T> ouput = new CustomList<T>();
            foreach (var e in smaller)
                ouput.Add(e);

            ouput.Add(pivotValue);

            foreach (var e in bigger)
                ouput.Add(e);

            return ouput;
        }     
  

    }

}