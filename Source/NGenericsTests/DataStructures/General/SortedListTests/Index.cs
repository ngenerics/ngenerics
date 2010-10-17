/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
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
            var sortedList = SortedListTest.GetTestList();
            var i = sortedList[sortedList.Count];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidIndexGet4()
        {
            var sortedList = SortedListTest.GetTestList();
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
}