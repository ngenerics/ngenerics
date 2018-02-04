/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Collections.Generic;
using System.Reflection;
using NGenerics.Sorting;
using NUnit.Framework;

namespace NGenerics.Tests.Sorting
{
    [TestFixture]
    public class TestSort
    {

        #region Sorter Tests

        [Test]
        public void TestSortInvalidSortOrder()
        {

            Exception argException = null;
            try
            {
                var sorterImplementation = new SorterImplementation();
                var method = typeof(SorterImplementation).GetMethod("Sort",new[]{typeof(IList<int>), typeof(SortOrder)});
                method.Invoke(sorterImplementation, new object[]{ new List<int>(), -1 });
            }
            catch (TargetInvocationException e)
            {
                argException = e.InnerException;
            }
            Assert.IsNotNull(argException);
        }


        #endregion
		
    [TestFixture]
        public class BubbleSortTests{

        [Test]
		public void ExceptionComparisonNullList()
        {
            var sorter = new BubbleSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, IntComparison));
        }

        [Test]
		public void ExceptionNullComparison2()
        {
            var sorter = new BubbleSorter<int>();
            var list = GetReverseSequentialTestList();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(list, (Comparison<int>)null));
        }

        [Test]
		public void ExceptionNullComparison1()
        {
            var sorter = new BubbleSorter<int>();
            var list = GetReverseSequentialTestList();
            sorter.Sort(list, IntComparison);
            AssertGeneralTestListSorted(list);
        }

        [Test]
        public void Simple()
        {
            var sorter = new BubbleSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new BubbleSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new BubbleSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new BubbleSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new BubbleSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }

     }

	[TestFixture]
	public class RadixSorterTests
	{
        [Test]
        public void ExceptionNullList()
        {
            var sorter = new RadixSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }
        
        [Test]
        public void NullComparison()
        {
            var sorter = new RadixSorter();
            var list = GetReverseSequentialTestList();
            sorter.Sort(list, SortOrder.Ascending);
            AssertGeneralTestListSorted(list);
        }

        [Test]
		public void Simple1()
        {
            var sorter = new RadixSorter();
            TestSorter(sorter);
        }



        [Test]
		public void Simple2()
        {
            var sorter = new RadixSorter();

            var list1 = new List<int> {1, 2};
            sorter.Sort(list1, SortOrder.Ascending);

            Assert.AreEqual(1, list1[0]);
            Assert.AreEqual(2, list1[1]);

            var list2 = new List<int> {1, 2};
            sorter.Sort(list2, SortOrder.Descending);

            Assert.AreEqual(2, list2[0]);
            Assert.AreEqual(1, list2[1]);


        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new RadixSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new RadixSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new RadixSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Descending));
        }
      }

	[TestFixture]
	public class OddEvenTransportSorterTests
	  {

		[Test]
		public void Simple()
		  {
			  var sorter = new OddEvenTransportSorter<int>();
			  TestSorter(sorter);
		  }

		  [Test]
		  public void ExceptionNullList1()
		  {
			  var sorter = new OddEvenTransportSorter<int>();
			  Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
		  }

		  [Test]
		  public void ExceptionNullList2()
		  {
			  var sorter = new OddEvenTransportSorter<int>();
			  Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
		  }

		  [Test]
		  public void ExceptionNullList3()
		  {
			  var sorter = new OddEvenTransportSorter<int>();
			  Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
		  }

		  [Test]
		  public void ExceptionNullComparer1()
		  {
			  var sorter = new OddEvenTransportSorter<int>();
			  Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
		  }

	  }

	[TestFixture]
	public class CombSortTests
	{

        [Test]
		public void Simple()
        {
            var sorter = new CombSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new CombSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new CombSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new CombSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new CombSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }
}

	[TestFixture]
        public class InsertionSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new InsertionSorter<int>();
            
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new InsertionSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new InsertionSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new InsertionSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new InsertionSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }

     }

	[TestFixture]
        public class SelectionSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new SelectionSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new SelectionSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new SelectionSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new SelectionSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new SelectionSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }
       }


	[TestFixture]
        public class HeapSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new HeapSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new HeapSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new HeapSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new HeapSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new HeapSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }
}

	[TestFixture]
        public class GnomeSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new GnomeSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new GnomeSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new GnomeSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new GnomeSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new GnomeSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }
    }

	[TestFixture]
        public class MergeSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new MergeSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new MergeSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new MergeSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new MergeSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new MergeSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }

      }

	[TestFixture]
        public class QuickSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new QuickSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new QuickSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new QuickSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new QuickSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new QuickSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }

}

	[TestFixture]
        public class BucketSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new BucketSorter();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new BucketSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new BucketSorter();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

       }

	[TestFixture]
        public class ShellSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new ShellSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new ShellSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new ShellSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new ShellSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new ShellSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }

       }


	[TestFixture]
        public class ShakerSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new ShakerSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new ShakerSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new ShakerSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new ShakerSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
		public void ExceptionNullComparer1()
        {
            var sorter = new ShakerSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }
       }

	[TestFixture]
        public class CocktailSorterTests{

        [Test]
		public void Simple()
        {
            var sorter = new CocktailSorter<int>();
            TestSorter(sorter);
        }

        [Test]
		public void ExceptionNullList1()
        {
            var sorter = new CocktailSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null));
        }

        [Test]
		public void ExceptionNullList2()
        {
            var sorter = new CocktailSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
        }

        [Test]
		public void ExceptionNullList3()
        {
            var sorter = new CocktailSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, SortOrder.Ascending));
        }

        [Test]
        public void ExceptionNullComparer1()
        {
            var sorter = new CocktailSorter<int>();
            Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
        }
}

        #region Private Members

        private static int IntComparison(int i, int j)
        {
            if (i < j)
            {
                return -1;
            }
            if (i > j)
            {
                return 1;
            }
            return 0;
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

            // Test already sorted list
            list = GetSortedList();
            sorter.Sort(list);
            AssertGeneralTestListSorted(list);

            // Test already reverse sorted list
            list = GetReverseSortedList();
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
           return new List<int> {5};
            }

        private static void AssertGeneralTestListSorted(List<int> sortedList)
        {
            for (var i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(sortedList[i], i);
            }
        }

        private static void AssertGeneralTestListReverseSorted(List<int> sortedList)
        {
            for (var i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(sortedList[sortedList.Count - i-1], i);
            }
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

        private static List<int> GetReverseSequentialTestList()
        {
            var list = new List<int>(500);

            for (var i = 499; i >= 0; i--)
            {
                list.Add(i);
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

        private static List<int> GetSortedList()
        {
            var list = new List<int>(500);

            for (var i = 0; i < 500; i++)
            {
                list.Add(i);
            }

            return list;
        }

        private static List<int> GetReverseSortedList()
        {
            var list = new List<int>(500);

            for (var i = 499; i >= 0; i--)
            {
                list.Add(i);
            }

            return list;
        }

        #endregion

        private class SorterImplementation : ComparisonSorter<int>
        {
            protected override void SortItems(IList<int> list, IComparer<int> comparer)
            {
                throw new NotImplementedException();
            }
        }
    }
}