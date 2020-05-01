using CustomDataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomDataStructures.Tests.CustomListTests
{
    public class CustomListCoreFunctionalityTests
    {
        [Fact]
        public void Constructor_ShouldInitializeEmptyList()
        {
            // Arange & Act
            CustomList<int> list = new CustomList<int>();

            //Assert
            Assert.Empty(list);
            Assert.Equal(2, list.Capacity);
        }

        [Fact]
        public void Constructor_ShouldInitializeListWithOneItem()
        {
            // Arange & Act
            CustomList<int> list = new CustomList<int>(5);

            //Assert
            Assert.NotEmpty(list);
            Assert.Single(list);
            Assert.Equal(2, list.Capacity);
            Assert.Contains(5, list);
        }

        [Fact]
        public void Constructor_ShouldInitializeListWithCollection()
        {
            // Arange
            int[] collection = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            CustomList<int> list = new CustomList<int>(collection);

            //Assert
            Assert.NotEmpty(list);
            Assert.Equal(10, list.Count);
            Assert.Contains(5, list);
        }


        [Fact]
        public void Add_ShouldCorrectlyAddItemToAnEmptyList()
        {
            // Arange
            CustomList<int> list = new CustomList<int>();

            // Act
            list.Add(2);

            //Assert
            Assert.NotEmpty(list);
            Assert.Contains(2, list);
            Assert.Single(list);
        }

        [Fact]
        public void Add_ShouldCorrectlyInsertItemAtTheEndOfAList()
        {
            // Arange
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5 };

            // Act
            list.Add(6);

            //Assert
            Assert.NotEmpty(list);
            Assert.Contains(6, list);
            Assert.Equal(6, list.LastOrDefault());
        }


        [Fact]
        public void Insert_ThrowsOutOfRangeOnIndexLessThanZero()
        {
            // Arange
            CustomList<int> list = new CustomList<int>() { 0, 1, 2 };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-1, 3));
        }


        [Fact]
        public void Count_ShouldBeCorrectAfterUsingEveryPossibleOperation()
        {
            // Arange & Act
            CustomList<int> list = new CustomList<int>(2); //adds 1

            list.Add(3); //adds 1
            list.Insert(0, 1);
            list.AddRange(new int[] { 1, 2, 3 }); //adds 3
            list[10] = 10; // adds 1
            list[0] = 1;
            list.Remove(3); //removes 1
            list.RemoveAt(0); //removes 1

            //Assert
            Assert.Equal(list.Count(), list.Count);
            Assert.Equal(4, list.Count);
        }

        [Fact]
        public void IsReadOnly_ReturnsFalse()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>(0);

            // Act & Assert 
            Assert.False(list.IsReadOnly);
        }

        [Fact]
        public void IsEmpty_ReturnsCorrectlyFalse()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>(0);

            // Act & Assert 
            Assert.False(list.IsEmpty);
            Assert.NotEmpty(list);
        }
        [Fact]
        public void IsEmpty_ReturnsCorrectlyTrue()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>(0);
            list.RemoveAt(0);

            // Act & Assert 
            Assert.True(list.IsEmpty);
            Assert.Empty(list);
        }

        [Fact]
        public void IndexedProperty_CorrectlyReturnsValueOfIndex()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6 };

            // Act & Assert 
            Assert.Equal(3, list[3]);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(7)]
        public void IndexedProperty_ThrowsWhenIndexIsOutOfRange(int index)
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6 };

            // Act & Assert 
            Assert.Throws<IndexOutOfRangeException>(() => list[index]);
        }


        [Fact]
        public void IndexedProperty_CorrectlySetsValueOfIndex()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6 };

            list[3] = 10;

            // Act & Assert 
            Assert.Contains(10, list);
            Assert.Equal(10, list[3]);
        }

        [Fact]
        public void Clear_CorrectlyClearsCollection()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6 };
            list.Clear();
            // Act & Assert 
            Assert.Empty(list);
        }

        [Fact]
        public void IndexOf_ReturnsIndexOfFirstOccurenceOfGivenItem()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 5, 7 };
            // Act & Assert 
            Assert.Equal(3, list.IndexOf(3));
        }
        [Fact]
        public void IndexOf_ReturnsMinusOneWhenGivenItemNotFound()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 5, 7 };
            // Act & Assert 
            Assert.Equal(-1, list.IndexOf(10));
        }


        [Fact]
        public void Contains_CorrectlyReturnsTrue()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 5, 7 };

            // Act 
            bool actual = list.Contains(3);

            // Assert
            Assert.Contains(3, list);
            Assert.True(actual);
        }

        [Fact]
        public void Contains_CorrectlyReturnsFalse()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 5, 7 };

            // Act 
            bool actual = list.Contains(10);

            // Assert
            Assert.DoesNotContain(10, list);
            Assert.False(actual);
        }
        [Fact]
        public void CopyTo_ThrowsWhenPassedArrayIsNull()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 5, 7 };
            int[] arr = null;
            // Act & Assert 
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(arr, 1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void CopyTo_ThrowsWhenPassedIndexIsOutOfRange(int index)
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 5, 7 };
            int[] arr = new int[5];
            // Act & Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(arr, index));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void CopyTo_ThrowsWhenNotEnoughSpaceToCopy(int index)
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 5, 7 };
            int[] arr = new int[5];
            // Act & Assert 
            Assert.Throws<ArgumentException>(() => list.CopyTo(arr, index));
        }

        [Fact]
        public void CopyTo_CorrectlyCopiesWholeCollectionToArrayStartingAtIndexZero()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };
            int[] array = new int[20];

            // Act
            list.CopyTo(array, 0);


            // Assert 
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(17, array.Where(x => x == 0).Count());
        }

        [Fact]
        public void CopyTo_CorrectlyCopiesWholeCollectionToArrayStartingAtGivenIndex()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };
            int[] array = new int[20];

            // Act
            list.CopyTo(array, 5);


            // Assert 
            Assert.Equal(1, array[5]);
            Assert.Equal(2, array[6]);
            Assert.Equal(3, array[7]);
            Assert.Equal(17, array.Where(x => x == 0).Count());
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void RemoveAt_ThrowsWhenPassedIndexIsOutOfRange(int index)
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 6, 3, 5, 7 };

            // Act
            Action actual = () => list.RemoveAt(index);

            // Assert 
            Assert.Throws<IndexOutOfRangeException>(actual);
        }


        [Fact]
        public void RemoveAt_CorrectlyRemovesItemAtGivenIndex()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 3, 0 };


            // Act
            list.RemoveAt(6);

            // Assert
            Assert.Equal(7, list.Count());
            Assert.Single(list.Where(x => x == 3));
            Assert.Contains(3, list.Take(4));
            Assert.Equal(0, list.LastOrDefault());
        }


        [Fact]
        public void Remove_CorrectlyRemovesFirstOccurenceOfGivenItem()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 3, 0 };

            // Act
            list.Remove(3);

            // Assert
            Assert.Equal(7, list.Count());
            Assert.Single(list.Where(x => x == 3));
        }

        [Fact]
        public void Remove_ReturnsTrueWhenRemoved()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4, 5, 3, 0 };

            // Act

            bool actual = list.Remove(3);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void Remove_ReturnsFalseWhenItemNotFoundInCollection()
        {
            // Arange
            CustomList<int> list = new CustomList<int>() { 0, 1, 2, 3, 4 };

            // Act 
            bool actual = list.Remove(5);

            // Assert 
            Assert.False(actual);
        }

    }
}
