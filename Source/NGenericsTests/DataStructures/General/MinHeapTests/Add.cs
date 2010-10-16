using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Add : MinHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Minimum)
                           {
                               5
                           };

            Assert.AreEqual(heap.Count, 1);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 5);

            heap.Add(2);
            Assert.AreEqual(heap.Count, 2);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 2);

            heap.Add(3);
            Assert.AreEqual(heap.Count, 3);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 2);

            Assert.AreEqual(heap.RemoveRoot(), 2);

            heap.Add(1);
            Assert.AreEqual(heap.Count, 3);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 1);
        }
    }
}