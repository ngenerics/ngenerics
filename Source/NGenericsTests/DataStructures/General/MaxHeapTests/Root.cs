using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class Root : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Maximum) { 5 };
            Assert.AreEqual(heap.Root, 5);
            Assert.AreEqual(heap.Count, 1);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInvalid()
        {
            var heap = new Heap<int>(HeapType.Maximum);
            var i = heap.Root;
        }
    }
}