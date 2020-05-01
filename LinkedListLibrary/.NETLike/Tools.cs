using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures
{
    public static class Tools
    {
        public static bool AreElementsEqual<T>(T first, T second)
        {
            if (first is IEquatable<T> equitable)
                return equitable.Equals(second);
            else
                return first.Equals(second);
        }

        public static int CompareElements<T>(IComparer<T> comparer, T val, T element)
        {
            if (comparer == null)
            {
                if (val is IComparable<T> comp)
                    return comp.CompareTo(element);

                throw new InvalidOperationException("Cannot find default IComparable interface for given type");
            }

            return comparer.Compare(val, element);
        }
    }
}