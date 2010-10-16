/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using NGenerics.Extensions;
using NGenerics.Sorting;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions.ListExtensionsTests
{

    [TestFixture]
    public class AddRange
    {
        [Test]
        public void Simple()
        {
            IList<int> iList1 = new List<int> { 1, 2, 3, 4 };
            IList<int> iList2 = new List<int> { 5, 6 };

            iList1.AddRange(iList2);

            Assert.AreEqual(6, iList1.Count);
        }
    }

    [TestFixture]
    public class GetRange
    {
        [Test]
        public void Simple1()
        {
            var list = new List<int> { 1, 2, 3, 4, 7, 8 }; ;
            IList<int> iList = list;

            var listRange = list.GetRange(0, 2);
            var iListRange = iList.GetRange(0, 2);
            AssertListsAreTheSame(listRange, iListRange);
        }

        [Test]
        public void Simple2()
        {
            var list = new List<int> { 1, 2, 3, 4, 7, 8 }; ;
            IList<int> iList = list;

            var listRange = list.GetRange(2, 3);
            var iListRange = iList.GetRange(2, 3);
            AssertListsAreTheSame(listRange, iListRange);
        }

        private static void AssertListsAreTheSame(IList<int> list1, IList<int> list2)
        {
            Assert.AreEqual(list1.Count, list2.Count);
            for (var index = 0; index < list1.Count; index++)
            {
                Assert.AreEqual(list1[index], list2[index]);
            }
        }

    }

    [TestFixture]
    public class Sort
    {
        [Test]
        public void Simple()
        {
            IList<int> list = new List<int> { 3, 2, 1, 4 };
            list.Sort();
            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 2);
            Assert.AreEqual(list[2], 3);
            Assert.AreEqual(list[3], 4);
        }
        [Test]
        public void SimpleRevered()
        {
            IList<int> list = new List<int> { 3, 2, 1, 4 };
            list.Sort();
            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 2);
            Assert.AreEqual(list[2], 3);
            Assert.AreEqual(list[3], 4);
        }
        [Test]
        public void SimpleComparision()
        {
            IList<int> list = new List<int> { 3, 2, 1, 4 };
            list.Sort(new Comparison<int>((x, y) => y.CompareTo(x)));
            Assert.AreEqual(list[0], 4);
            Assert.AreEqual(list[1], 3);
            Assert.AreEqual(list[2], 2);
            Assert.AreEqual(list[3], 1);
        }

        [Test]
        public void SimpleComparisionReversed()
        {
            IList<int> list = new List<int> { 3, 2, 1, 4 };
            list.Sort(new Comparison<int>((x, y) => y.CompareTo(x)), SortOrder.Descending);
            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 2);
            Assert.AreEqual(list[2], 3);
            Assert.AreEqual(list[3], 4);
        }
        [Test]
        public void Property()
        {
            IList<Person> list = new List<Person>
                                     {
                                         new Person{Age = 3},
                                         new Person{Age = 2},
                                         new Person{Age = 1},
                                         new Person{Age = 4}
                                     };
            list.Sort(x => x.Age);
            Assert.AreEqual(list[0].Age, 1);
            Assert.AreEqual(list[1].Age, 2);
            Assert.AreEqual(list[2].Age, 3);
            Assert.AreEqual(list[3].Age, 4);
        }

        [Test]
        public void PropertyRevered()
        {
            IList<Person> list = new List<Person>
                                     {
                                         new Person{Age = 3},
                                         new Person{Age = 2},
                                         new Person{Age = 1},
                                         new Person{Age = 4}
                                     };
            list.Sort(x => x.Age, SortOrder.Descending);
            Assert.AreEqual(list[0].Age, 4);
            Assert.AreEqual(list[1].Age, 3);
            Assert.AreEqual(list[2].Age, 2);
            Assert.AreEqual(list[3].Age, 1);
        }

        public class Person
        {
            public int Age { get; set; }
        }
        [Test]
        public void SimpleComparer()
        {
            IList<string> list = new List<string> { "3", "2", "1", "4" };
            list.Sort(StringComparer.Ordinal);
            Assert.AreEqual(list[0], "1");
            Assert.AreEqual(list[1], "2");
            Assert.AreEqual(list[2], "3");
            Assert.AreEqual(list[3], "4");
        }
    }

    [TestFixture]
    public class Remove
    {
        [Test]
        public void RemoveSingular()
        {
            IList<int> iList = new List<int> { 1, 2, 3, 4 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(1, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 1, 2, 4 }, iList);
        }

        [Test]
        public void RemoveMultiple()
        {
            IList<int> iList = new List<int> { 1, 2, 3, 4, 3 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(2, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 1, 2, 4 }, iList);
        }
        [Test]
        public void RemoveFirst()
        {
            IList<int> iList = new List<int> { 3, 2, 4, 2 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(1, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 2, 4, 2 }, iList);
        }
        [Test]
        public void RemoveLast()
        {
            IList<int> iList = new List<int> { 1, 2, 4, 3 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(1, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 1, 2, 4 }, iList);
        }
        [Test]
        public void RemoveAll()
        {
            IList<int> iList = new List<int> { 3, 3, 3, 3 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(4, iListRemovedCount);
            Assert.AreEqual(0, iList.Count);

        }
        [Test]
        public void RemoveNone()
        {
            IList<int> iList = new List<int> { 1, 1, 1, 1 };

            var iListRemovedCount = iList.RemoveAll(Match3);

            Assert.AreEqual(0, iListRemovedCount);
            EnsureListsAreTheSame(new List<int> { 1, 1, 1, 1 }, iList);
        }

        private static void EnsureListsAreTheSame(IList<int> list1, IList<int> list2)
        {
            Assert.AreEqual(list1.Count, list2.Count);
            for (var index = 0; index < list2.Count; index++)
            {
                var iListItem = list2[index];
                var listItem = list1[index];
                Assert.AreEqual(iListItem, listItem);
            }
        }

        private static bool Match3(int obj)
        {
            return obj == 3;
        }
    }

}
