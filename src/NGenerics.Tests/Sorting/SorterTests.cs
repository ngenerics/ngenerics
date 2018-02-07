/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Collections.Generic;
using NGenerics.Sorting;
using NUnit.Framework;

namespace NGenerics.Tests.Sorting
{
    [TestFixture(typeof(RadixSorter))]
    [TestFixture(typeof(BucketSorter))]
    public class SorterTests<T> where T : ISorter<int>, new()
    {
        [Test]
        public void Simple()
        {
            var sorter = new T();
            TestSorter(sorter);
        }

        [Test]
        public void ExceptionNullList1()
        {
            var sorter = new T();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
        public void ExceptionNullList2()
        {
            var sorter = new T();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
        public void ExceptionNullList3()
        {
            var sorter = new T();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Descending));
        }

        #region Protected Members

        protected static int IntComparison(int i, int j)
        {
            return i.CompareTo(j);
        }

        protected static List<int> GetReverseSequentialTestList()
        {
            var list = new List<int>(500);

            for (var i = 499; i >= 0; i--)
            {
                list.Add(i);
            }

            return list;
        }

        protected static void AssertGeneralTestListSorted(List<int> sortedList)
        {
            for (var i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(sortedList[i], i);
            }
        }

        #endregion


        #region Private Members

        private static void AssertGeneralTestListReverseSorted(List<int> sortedList)
        {
            for (var i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(sortedList[sortedList.Count - i - 1], i);
            }
        }

        private static void TestSorter(ISorter<int> sorter)
            {
                // Test Reverse sequential list
                var list = GetReverseSequentialTestList();
                sorter.Sort(list, SortOrder.Ascending);
                AssertGeneralTestListSorted(list);

                // Test sequential list
                list = GetSequentialTestList();
                sorter.Sort(list, SortOrder.Descending);
                AssertGeneralTestListReverseSorted(list);

                // Test half sequential list
                list = GetHalfSequentialList();
                sorter.Sort(list);
                AssertGeneralTestListSorted(list);

                // Test half sequential list reversed
                list = GetHalfSequentialList();
                sorter.Sort(list, SortOrder.Descending);
                AssertGeneralTestListReverseSorted(list);

                // Test double numbers
                list = GetDoubleNumbers();
                sorter.Sort(list);
                AssertDoubleNumbersList(list);

                // Test reversed double numbers
                list = GetDoubleNumbers();
                sorter.Sort(list, SortOrder.Descending);
                AssertDoubleNumbersReversedList(list);

                // Test with list with one item in it
                list = GetSingleItemList();
                sorter.Sort(list);
                AssertSingleList(list);

                // Test with list with one item in it
                list = GetSingleItemList();
                sorter.Sort(list, SortOrder.Descending);
                AssertSingleList(list);

                // Test empty List
                list = new List<int>();
                sorter.Sort(list, SortOrder.Descending);
            }

            private static void AssertSingleList(List<int> list)
            {
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(5, list[0]);
            }

            private static List<int> GetSingleItemList()
            {
                return new List<int> { 5 };
            }


            private static void AssertDoubleNumbersList(List<int> sortedList)
            {
                for (var i = 0; i < sortedList.Count; i++)
                {
                    if ((i % 2) == 0)
                    {
                        Assert.AreEqual(sortedList[i], i);
                    }
                    else
                    {
                        Assert.AreEqual(sortedList[i], i - 1);
                    }
                }
            }

            private static void AssertDoubleNumbersReversedList(List<int> sortedList)
            {
                for (var i = 0; i < sortedList.Count; i++)
                {
                    if ((i % 2) == 0)
                    {
                        Assert.AreEqual(sortedList[sortedList.Count - i - 1], i);
                    }
                    else
                    {
                        Assert.AreEqual(sortedList[sortedList.Count - i - 1], i - 1);
                    }
                }
            }

            private static List<int> GetDoubleNumbers()
            {
                var list = new List<int>(500);

                for (var i = 499; i >= 0; i--)
                {
                    if ((i % 2) == 0)
                    {
                        list.Add(i);
                    }
                    else
                    {
                        list.Add(i - 1);
                    }
                }

                return list;
            }

            private static List<int> GetSequentialTestList()
            {
                var list = new List<int>(500);

                for (var i = 0; i < 500; i++)
                {
                    list.Add(i);
                }

                return list;
            }

            private static List<int> GetHalfSequentialList()
            {
                var list = new List<int>(500);

                for (var i = 499; i >= 200; i--)
                {
                    list.Add(i);
                }

                for (var i = 199; i >= 0; i--)
                {
                    list.Add(i);
                }

                return list;
            }

            #endregion
    }
}