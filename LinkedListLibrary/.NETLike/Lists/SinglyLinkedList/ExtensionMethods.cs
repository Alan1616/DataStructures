using CustomDataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures.Lists
{
    public static partial class ExtensionMethods
    {
        public static CustomLinkedList<T> ToSinglyLinkedList<T>(this IEnumerable<T> enumerable)
        {
            CustomLinkedList<T> output = new CustomLinkedList<T>();
            output.AppendRange(enumerable);
            return output;
        }

    }

}
