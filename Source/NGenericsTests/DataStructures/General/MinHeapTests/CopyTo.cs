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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArray()
        {
            var heap = GetTestHeap();
            heap.CopyTo(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidArrayLength1()
        {
            var heap = GetTestHeap();
            var array = new int[heap.Count - 1];
            heap.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidArrayLength2()
        {
            var heap = GetTestHeap();
            var array = new int[heap.Count];
            heap.CopyTo(array, 1);
        }
    }
}