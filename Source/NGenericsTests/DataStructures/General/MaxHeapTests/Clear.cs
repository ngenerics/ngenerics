using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class Clear : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Maximum);

            for (var i = 1; i <= 20; i++)
            {
                heap.Add(i);
                Assert.AreEqual(heap.Root, i);
            }

            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Count, 20);

            heap.Clear();

            Assert.AreEqual(heap.Count, 0);
            Assert.IsTrue(heap.IsEmpty);
        }
    }
}