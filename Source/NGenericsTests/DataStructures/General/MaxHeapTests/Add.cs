using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class Add : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Maximum)
                           {
                               5
                           };

            Assert.AreEqual(heap.Count, 1);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 5);

            heap.Add(2);
            Assert.AreEqual(heap.Count, 2);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 5);

            heap.Add(3);
            Assert.AreEqual(heap.Count, 3);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 5);

            Assert.AreEqual(heap.RemoveRoot(), 5);

            heap.Add(1);
            Assert.AreEqual(heap.Count, 3);
            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Root, 3);
        }
    }
}