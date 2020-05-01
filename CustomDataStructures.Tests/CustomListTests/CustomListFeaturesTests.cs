using CustomDataStructures.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomDataStructures.Tests.CustomListTests
{
    public class CustomListFeaturesTests
    {
        [Fact]
        public void TrueForAll_ShouldCorrectlyReturnFalse()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5, 6 };

            // Act
            bool actual = list.TrueForAll(x => x <= 5);

            // Assert 
            Assert.False(actual);
        }

        [Fact]
        public void TrueForAll_ShouldCorrectlyReturnTrue()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5, 6 };

            // Act
            bool actual = list.TrueForAll(x => x <= 6);

            // Assert 
            Assert.True(actual);
        }

        [Fact]
        public void ForEach_ExecutesActionOnEveryElement()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5, 6 };
            int[] array = new int[6];

            // Act
            list.ForEach(x => array[x-1] = x);

            // Assert 
            Assert.Equal(6,list.Intersect(array).Count());
        }

        [Fact]
        public void Revers_CorrectlyReversesTheCollection()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 0,1, 2, 3, 4, 5 };

            // Act
            list.Reverse();

            // Assert 

            Assert.NotEmpty(list);
            for (int i = 5; i >= 0; i--)
            {
                Assert.Equal(5-i, list[i]);
            }
        }

        [Fact]
        public void Sort_ShouldSortCorrectlyWithDefaultEqualityComparer()
        {
            // Arange 
            CustomList<int> list = new CustomList<int>() { 11,17,9,11,5,2,3,1,0,17,-78,21 };
            int[] expected = new int[] { -78,0,1,2,3,5,9,11,11,17,17,21 };

            // Act
            list.Sort();

            // Assert 

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], list[i]);
            }
        }

        [Fact]
        public void Sort_ShouldSortCorrectlyWithProvidedEqualityComparer()
        {
            // Arange 
            CustomList<SampleReferenceType> list = new CustomList<SampleReferenceType>() 
            {
                new SampleReferenceType("aaa",2),
                new SampleReferenceType("aaaa",1),
                new SampleReferenceType("bbbb",3),
                new SampleReferenceType("aaaa",3)
            };
            SampleReferenceType[] expected = new SampleReferenceType[]
            {
                list[1],
                list[0],
                list[3],
                list[2],
            };

            // Act
            list.Sort(Comparer<SampleReferenceType>.Create((x,y) => 
            {
                if (x.Id - y.Id != 0)
                    return x.Id - y.Id;
                else
                    return
                    x.Name.CompareTo(y.Name);     
            }));

            // Assert 
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], list[i]);
            }

        }


        [Fact]
        public void Sort_ShouldThrowWhenNoDefaultEqualityComparerFound()
        {
            // Arange 

            CustomList<SampleReferenceType> list = new CustomList<SampleReferenceType>() 
            {
                new SampleReferenceType("Test",1), 
                new SampleReferenceType("Test",2)
            };

            // Act
            Action actual = () => list.Sort();


            // Assert 
            var exception = Assert.Throws<InvalidOperationException>(actual);
            Assert.Equal("Cannot find default IComparable interface for given type", exception.Message);
        }



        private class SampleReferenceType
        {
            public SampleReferenceType(string name, int id)
            {
                Name = name;
                Id = id;
            }

            public string Name { get; set; }
            public int Id { get; set; }

        }


    }


   

}
