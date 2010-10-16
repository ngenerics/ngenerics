using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Root : MinHeapTest
    {
        [Test]
        public void SmallestItem()
        {
            var heap = new Heap<int>(HeapType.Minimum) {5};
            Assert.AreEqual(heap.Root, 5);
            Assert.AreEqual(heap.Count, 1);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var heap = new Heap<int>(HeapType.Minimum);
            var i = heap.Root;
        }
    }
}