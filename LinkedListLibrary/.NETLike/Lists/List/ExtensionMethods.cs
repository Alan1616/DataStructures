using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures.Lists
{
    public static partial class ExtensionMethods
    {
        public static CustomList<T> ToCustomList<T>(this IEnumerable<T> enumerable)
        {
            return new CustomList<T>(enumerable);
        }
    }
}
