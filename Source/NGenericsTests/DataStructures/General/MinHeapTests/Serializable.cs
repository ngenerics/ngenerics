using NGenerics.DataStructures.General;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Serializable : MinHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = GetTestHeap();
            var newHeap = SerializeUtil.BinarySerializeDeserialize(heap);

            Assert.AreNotSame(heap, newHeap);
            Assert.AreEqual(heap.Count, newHeap.Count);

            while (heap.Count > 0)
            {
                Assert.AreEqual(heap.RemoveRoot(), newHeap.RemoveRoot());
            }
        }

        [Test]
        public void NonIComparable()
        {
            var heap = new Heap<NonComparableTClass>(HeapType.Minimum)
                           {
                               new NonComparableTClass(5),
                               new NonComparableTClass(4),
                               new NonComparableTClass(99),
                               new NonComparableTClass(12),
                               new NonComparableTClass(5)
                           };

            var newHeap = SerializeUtil.BinarySerializeDeserialize(heap);

            Assert.AreNotSame(heap, newHeap);
            Assert.AreEqual(heap.Count, newHeap.Count);

            while (heap.Count > 0)
            {
                Assert.AreEqual(heap.RemoveRoot().Number, newHeap.RemoveRoot().Number);
            }
        }
    }
}