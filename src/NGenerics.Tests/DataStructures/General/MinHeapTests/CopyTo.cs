/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class CopyTo : MinHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = GetTestHeap();
            var array = new int[heap.Count];

            heap.CopyTo(array, 0);

            var list = new List<int>(array);
            Assert.AreEqual(list.Count, heap.Count);
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(4));
            Assert.IsTrue(list.Contains(99));
            Assert.IsTrue(list.Contains(12));
        }

        [Test]
        public void ExceptionNullArray()
        {
            var heap = GetTestHeap();
            Assert.Throws<ArgumentNullException>(() => heap.CopyTo(null, 0));
        }

        [Test]
        public void ExceptionInvalidArrayLength1()
        {
            var heap = GetTestHeap();
            var array = new int[heap.Count - 1];
            Assert.Throws<ArgumentException>(() => heap.CopyTo(array, 0));
        }

        [Test]
        public void ExceptionInvalidArrayLength2()
        {
            var heap = GetTestHeap();
            var array = new int[heap.Count];
            Assert.Throws<ArgumentException>(() => heap.CopyTo(array, 1));
        }
    }
}