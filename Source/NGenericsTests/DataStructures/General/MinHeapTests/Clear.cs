using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Clear : MinHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Minimum);

            for (var i = 20; i > 0; i--)
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