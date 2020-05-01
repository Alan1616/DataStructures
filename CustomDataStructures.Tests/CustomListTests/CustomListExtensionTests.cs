using CustomDataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomDataStructures.Tests.CustomListTests
{
    public class CustomListExtensionTests
    {

        [Fact]
        public void ToCustomListT_ShouldConvertIEnumerableToCustomList()
        {
            // Arange 
            int[] collection = new int[] {0, 1, 2, 3, 4 };

            // Act
            CustomList<int> actual = collection.ToCustomList();

            // Assert 
            Assert.Equal(8, actual.Capacity);
            Assert.Equal(5, actual.Count);
            Assert.Equal(5, actual.Intersect(collection).Count());
        }

        
    }
}
