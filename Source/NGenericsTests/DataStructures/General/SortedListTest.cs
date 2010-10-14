/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{

    public class SortedListTest
    {

        private static SortedList<int> GetTestList()
        {
            var sortedList = new SortedList<int>();

            for (var i = 50; i >= 0; i--)
            {
                sortedList.Add(i * 2);
            }

            return sortedList;
        }


        [TestFixture]
        public class Add : SortedListTest
        {
            [Test]
            public void Simple()
            {
                var sortedList = new SortedList<int>
				                 {
				                     5
				                 };

                Assert.AreEqual(sortedList.Count, 1);
                Assert.IsFalse(sortedList.IsEmpty);
                Assert.AreEqual(sortedList[0], 5);

                sortedList = GetTestList();
                sortedList.Add(-5);
                Assert.AreEqual(sortedList[0], -5);
            }

            [Test]
            public void Sorting()
            {
                var sortedList = new SortedList<int>();

                for (var i = 200; i >= 0; i--)
                {
                    sortedList.Add(i * 2);
                }

                for (var i = 0; i <= 200; i++)
                {
                    Assert.AreEqual(sortedList[i], i * 2);
                }
            }

            [Test]
            public void StressTestList()
            {

                var sortedList = new SortedList<int>();

                for (var i = 1000; i > 0; i--)
                {
                    sortedList.Add(i);
                }

                for (var i = 1000; i > 0; i--)
                {
                    sortedList.Add(i);
                }

                var counter = 0;
                var val = 1;

                while (counter <= 1000)
                {
                    Assert.AreEqual(sortedList[counter], val);
                    counter++;

                    Assert.AreEqual(sortedList[counter], val);
                    counter++;
                    val++;
                }

            }
        }

        [TestFixture]
        public class Accept
        {

            [Test]
            public void Simple()
            {
                var visitor = new TrackingVisitor<int>();
                var sortedList = GetTestList();
                sortedList.AcceptVisitor(visitor);

                Assert.AreEqual(visitor.TrackingList.Count, sortedList.Count);

                for (var i = 0; i <= 50; i++)
                {
                    Assert.IsTrue(visitor.TrackingList.Contains(i * 2));
                }
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var sortedList = GetTestList();
                sortedList.AcceptVisitor(null);
            }

        }

        [TestFixture]
        public class Construction
        {

            [Test]
            public void Simple()
            {
                var list = new List<int>();

                for (var i = 0; i < 200; i++)
                {
                    list.Add(i);
                }

                var sortedList = new SortedList<int>(list);

                for (var i = 0; i < 200; i++)
                {
                    Assert.AreEqual(sortedList[i], i);
                }

                sortedList = new SortedList<int>(50);

                for (var i = 0; i < 200; i++)
                {
                    sortedList.Add(i * 2);
                }

                for (var i = 0; i < 200; i++)
                {
                    Assert.AreEqual(sortedList[i], i * 2);
                }

                sortedList = new SortedList<int>(50, Comparer<int>.Default);
                Assert.AreEqual(sortedList.Comparer, Comparer<int>.Default);
            }

            [Test]
            public void Comparer()
            {
                var comparer = new ReverseComparer<int>();
                var sortedList = new SortedList<int>(comparer);
                Assert.AreEqual(comparer, sortedList.Comparer);
            }

        }

        [TestFixture]
        public class Clear
        {

            [Test]
            public void Simple()
            {
                var sortedList = GetTestList();
                Assert.AreEqual(sortedList.Count, 51);

                sortedList.Clear();
                Assert.AreEqual(sortedList.Count, 0);
            }

        }

        [TestFixture]
        public class GetEnumerator
        {

            [Test]
            public void Simple()
            {
                var sortedList = new SortedList<int>();

                for (var i = 0; i < 20; i++)
                {
                    sortedList.Add(i);
                }

                var counter = 0;
                var enumerator = sortedList.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    Assert.AreEqual(enumerator.Current, counter);
                    counter++;
                }

                Assert.AreEqual(counter, 20);
            }

            [Test]
            public void Interface()
            {
                var sortedList = new SortedList<int>();

                for (var i = 0; i < 20; i++)
                {
                    sortedList.Add(i);
                }

                var counter = 0;

                var enumerator = ((IEnumerable)sortedList).GetEnumerator();

                while (enumerator.MoveNext())
                {
                    Assert.AreEqual((int)enumerator.Current, counter);
                    counter++;
                }

                Assert.AreEqual(counter, 20);
            }

        }

        [TestFixture]
        public class Contains
        {

            [Test]
            public void Simple()
            {
                var sortedList = new SortedList<int>();

                for (var i = 0; i < 20; i++)
                {
                    sortedList.Add(i);
                }

                Assert.IsTrue(sortedList.Contains(5));
                Assert.IsFalse(sortedList.Contains(50));
            }

        }

        [TestFixture]
        public class Index
        {

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionInvalidIndexGet1()
            {
                var sortedList = new SortedList<int>();
                var i = sortedList[0];
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionInvalidIndexGet2()
            {
                var sortedList = new SortedList<int> { 5 };

                var test = sortedList[1];
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionInvalidIndexGet3()
            {
                var sortedList = GetTestList();
                var i = sortedList[sortedList.Count];
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionInvalidIndexGet4()
            {
                var sortedList = GetTestList();
                var i = sortedList[-1];
            }

            [Test]
            [ExpectedException(typeof(NotSupportedException))]
            public void ExceptionInvalidIndexSet()
            {
                IList<int> sortedList = new SortedList<int> { 2 };

                sortedList[0] = 5;
            }

            [Test]
            public void InterfaceGet()
            {
                IList<int> sortedList = new SortedList<int> { 5, 2 };

                Assert.AreEqual(sortedList[0], 2);
                Assert.AreEqual(sortedList[1], 5);
            }

        }

        [TestFixture]
        public class IndexOf
        {

            [Test]
            public void Simple()
            {
                var sortedList = new SortedList<int>();
                Assert.Less(sortedList.IndexOf(2), 0);

                sortedList.Add(5);
                Assert.AreEqual(sortedList.IndexOf(5), 0);

                sortedList.Add(2);
                Assert.AreEqual(sortedList.IndexOf(5), 1);
                Assert.AreEqual(sortedList.IndexOf(2), 0);

                Assert.Less(sortedList.IndexOf(10), 0);
            }

        }

        [TestFixture]
        public class RemoveAt
        {

            [Test]
            public void Simple()
            {
                var sortedList = new SortedList<int> { 5 };

                Assert.AreEqual(sortedList.Count, 1);

                sortedList.RemoveAt(0);

                Assert.AreEqual(sortedList.Count, 0);

                sortedList.Add(5);
                sortedList.Add(2);

                Assert.AreEqual(sortedList.Count, 2);
                sortedList.RemoveAt(1);

                Assert.AreEqual(sortedList.Count, 1);

                sortedList.Add(2);

                Assert.AreEqual(sortedList.Count, 2);
                sortedList.RemoveAt(0);

                Assert.AreEqual(sortedList.Count, 1);
            }

        }

        [TestFixture]
        public class Insert
        {

            [Test]
            [ExpectedException(typeof(NotSupportedException))]
            public void Simple()
            {
                IList<int> sortedList = new SortedList<int>();
                sortedList.Insert(5, 2);
            }


        }





        [TestFixture]
        public class IsReadOnly
        {

            [Test]
            public void Simple()
            {
                var sortedList = new SortedList<int>();
                Assert.IsFalse(sortedList.IsReadOnly);

                sortedList = GetTestList();
                Assert.IsFalse(sortedList.IsReadOnly);
            }

        }

        [TestFixture]
        public class Remove
        {

            [Test]
            public void Simple()
            {
                var sortedList = new SortedList<int>();

                for (var i = 50; i >= 0; i--)
                {
                    sortedList.Add(i * 2);
                }

                Assert.AreEqual(sortedList.Count, 51);

                Assert.IsTrue(sortedList.Remove(50));
                Assert.AreEqual(sortedList.Count, 50);

                Assert.IsFalse(sortedList.Remove(3));
                Assert.AreEqual(sortedList.Count, 50);
            }

        }

        [TestFixture]
        public class TestCopyTo
        {

            [Test]
            public void Simple()
            {
                var sortedList = GetTestList();
                var array = new int[sortedList.Count];
                sortedList.CopyTo(array, 0);

                var list = new List<int>(array);

                for (var i = 0; i <= 50; i++)
                {
                    Assert.IsTrue(list.Contains(i * 2));
                }
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullArray()
            {
                var sortedList = GetTestList();
                sortedList.CopyTo(null, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalidCopyTo1()
            {
                var sortedList = GetTestList();
                var array = new int[sortedList.Count - 1];
                sortedList.CopyTo(array, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalidCopyTo2()
            {
                var sortedList = GetTestList();
                var array = new int[sortedList.Count];
                sortedList.CopyTo(array, 1);
            }

        }

        [TestFixture]
        public class Serialization
        {

            [Test]
            public void Simple()
            {
                var sortedList = GetTestList();
                var newSortedList = SerializeUtil.BinarySerializeDeserialize(sortedList);

                Assert.AreNotSame(sortedList, newSortedList);
                Assert.AreEqual(sortedList.Count, newSortedList.Count);

                for (var i = 0; i < sortedList.Count; i++)
                {
                    Assert.AreEqual(sortedList[i], newSortedList[i]);
                }
            }

            [Test]
            public void NonIComparable()
            {
                var sortedList = new SortedList<NonComparableTClass>();

                for (var i = 50; i >= 0; i--)
                {
                    sortedList.Add(new NonComparableTClass(i * 2));
                }

                var newSortedList = SerializeUtil.BinarySerializeDeserialize(sortedList);

                Assert.AreNotSame(sortedList, newSortedList);
                Assert.AreEqual(sortedList.Count, newSortedList.Count);

                for (var i = 0; i < sortedList.Count; i++)
                {
                    Assert.AreEqual(sortedList[i].Number, newSortedList[i].Number);
                }
            }

        }



    }
}
