using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Contains : MinHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = GetTestHeap();

            Assert.IsTrue(heap.Contains(5));
            Assert.IsTrue(heap.Contains(4));
            Assert.IsTrue(heap.Contains(99));
            Assert.IsTrue(heap.Contains(12));
            Assert.IsTrue(heap.Contains(5));
            Assert.IsFalse(heap.Contains(3));
        }
    }
}