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
}