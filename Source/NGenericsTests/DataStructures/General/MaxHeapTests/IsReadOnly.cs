using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class IsReadOnly : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Maximum);
            Assert.IsFalse(heap.IsReadOnly);

            heap = GetTestHeap();
            Assert.IsFalse(heap.IsReadOnly);
        }
    }
}