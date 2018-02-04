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
    public partial class TestSort
    {
        [TestFixture]
        public class TestComparisonSortBase<T> : TestSortBase<T> 
            where T : ComparisonSorter<int>, new()
        {
            [Test]
            public void ExceptionComparisonNullList()
            {
                var sorter = new T();
                Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, IntComparison));
            }

            [Test]
            public void ExceptionComparisonNullList2()
            {
                var sorter = new T();
                Assert.Throws<ArgumentNullException>(() => sorter.Sort(null, Comparer<int>.Default));
            }

            [Test]
            public void ExceptionNullComparison2()
            {
                var sorter = new T();
                var list = GetReverseSequentialTestList();
                Assert.Throws<ArgumentNullException>(() => sorter.Sort(list, (Comparison<int>)null));
            }

            [Test]
            public void ExceptionNullComparison1()
            {
                var sorter = new T();
                var list = GetReverseSequentialTestList();
                sorter.Sort(list, IntComparison);
                AssertGeneralTestListSorted(list);
            }

            [Test]
            public void ExceptionNullComparer1()
            {
                var sorter = new BubbleSorter<int>();
                Assert.Throws<ArgumentNullException>(() => sorter.Sort(new List<int>(), (IComparer<int>)null));
            }
        }
    }
}