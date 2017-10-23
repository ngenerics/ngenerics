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

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class Construction : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Maximum);

            Assert.AreEqual(heap.Type, HeapType.Maximum);
            Assert.AreEqual(heap.Count, 0);
            Assert.IsTrue(heap.IsEmpty);

            heap = new Heap<int>(HeapType.Maximum, Comparer<int>.Default);

            Assert.AreEqual(heap.Type, HeapType.Maximum);
            Assert.AreEqual(heap.Count, 0);
            Assert.IsTrue(heap.IsEmpty);

            heap = new Heap<int>(HeapType.Maximum, 50);

            Assert.AreEqual(heap.Type, HeapType.Maximum);
            Assert.AreEqual(heap.Count, 0);
            Assert.IsTrue(heap.IsEmpty);

            heap = new Heap<int>(HeapType.Maximum, 50, Comparer<int>.Default);

            Assert.AreEqual(heap.Type, HeapType.Maximum);
            Assert.AreEqual(heap.Count, 0);
            Assert.IsTrue(heap.IsEmpty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer1()
        {
            new Heap<int>(HeapType.Maximum, (IComparer<int>)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer2()
        {
            new Heap<int>(HeapType.Maximum, 50, (IComparer<int>)null);
        }
    }
}