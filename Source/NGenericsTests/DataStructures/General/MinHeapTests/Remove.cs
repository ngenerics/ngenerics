/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Remove : MinHeapTest
    {
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptionInterface()
        {
            ICollection<int> heap = GetTestHeap();
            heap.Remove(4);
        }

        [Test]
        public void SmallestItem()
        {
            var heap = new Heap<int>(HeapType.Minimum) {5};
            Assert.AreEqual(heap.Root, 5);
            Assert.AreEqual(heap.Count, 1);
            Assert.IsFalse(heap.IsEmpty);

            Assert.AreEqual(heap.RemoveRoot(), 5);
            Assert.AreEqual(heap.Count, 0);
            Assert.IsTrue(heap.IsEmpty);
        }


        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var heap = new Heap<int>(HeapType.Minimum);

            Assert.AreEqual(heap.Count, 0);

            heap.RemoveRoot();
        }

        [Test]
        public void Stress()
        {
            var heap = new Heap<int>(HeapType.Minimum);

            const int maximum = 5000;

            for (var i = maximum; i > 0; i--)
            {
                heap.Add(i);

                Assert.AreEqual(heap.Root, i);
            }

            for (var i = 1; i <= maximum; i++)
            {
                Assert.AreEqual(heap.RemoveRoot(), i);
            }
        }
    }
}