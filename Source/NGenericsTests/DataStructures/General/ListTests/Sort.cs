/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Sort 
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int> {3,2,6,9,1};
            listBase.Sort();
            Assert.AreEqual(1, listBase[0]);
            Assert.AreEqual(2, listBase[1]);
            Assert.AreEqual(3, listBase[2]);
            Assert.AreEqual(6, listBase[3]);
            Assert.AreEqual(9, listBase[4]);
        }

        //[Test]
        //public void EnsureSortItemsCall()
        //{
        //    var mockRepository = new MockRepository();
        //    Sort listBase = mockRepository.PartialMock<Sort>();
        //    listBase.SortItems();
        //    mockRepository.ReplayAll();
        //    listBase.Add(5);
        //    listBase.Sort();
        //    mockRepository.VerifyAll();
        //}
        [Test]
        public void Comparison()
        {
            var listBase = new ListBase<int> {3,2,6,9,1};
            Comparison<int> comparison = IntComparison;
            listBase.Sort(comparison);
            Assert.AreEqual(1, listBase[0]);
            Assert.AreEqual(2, listBase[1]);
            Assert.AreEqual(3, listBase[2]);
            Assert.AreEqual(6, listBase[3]);
            Assert.AreEqual(9, listBase[4]);
        }
        //[Test]
        //public void EnsureComparisonSortItemsCall()
        //{
        //    Comparison<int> comparison = IntComparison;
        //    var mockRepository = new MockRepository();
        //    Sort listBase = mockRepository.PartialMock<Sort>();
        //    listBase.SortItems(comparison);
        //    mockRepository.ReplayAll();
        //    listBase.Add(5);
        //    listBase.Sort(comparison);
        //    mockRepository.VerifyAll();
        //}
        [Test]
        public void Comparer()
        {
            var listBase = new ListBase<int> {3,2,6,9,1};
            listBase.Sort(Comparer<int>.Default);
            Assert.AreEqual(1, listBase[0]);
            Assert.AreEqual(2, listBase[1]);
            Assert.AreEqual(3, listBase[2]);
            Assert.AreEqual(6, listBase[3]);
            Assert.AreEqual(9, listBase[4]);
        }
        //[Test]
        //public void EnsureComparerSortItemsCall()
        //{
        //    var mockRepository = new MockRepository();
        //    Sort listBase = mockRepository.PartialMock<Sort>();
        //    listBase.SortItems(Comparer<int>.Default);
        //    mockRepository.ReplayAll();
        //    listBase.Add(5);
        //    listBase.Sort(Comparer<int>.Default);
        //    mockRepository.VerifyAll();
        //}
        [Test]
        public void IndexCountComparer()
        {
            var listBase = new ListBase<int> {3,2,6,9,1};
            listBase.Sort(0, 5, Comparer<int>.Default);
            Assert.AreEqual(1, listBase[0]);
            Assert.AreEqual(2, listBase[1]);
            Assert.AreEqual(3, listBase[2]);
            Assert.AreEqual(6, listBase[3]);
            Assert.AreEqual(9, listBase[4]);
        }
        //[Test]
        //public void EnsureIndexCountComparerSortItemsCall()
        //{
        //    var mockRepository = new MockRepository();
        //    Sort listBase = mockRepository.PartialMock<Sort>();
        //    listBase.SortItems(0, 5, Comparer<int>.Default);
        //    mockRepository.ReplayAll();
        //    listBase.Add(5);
        //    listBase.Sort(0, 5, Comparer<int>.Default);
        //    mockRepository.VerifyAll();
        //}

        private static int IntComparison(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}