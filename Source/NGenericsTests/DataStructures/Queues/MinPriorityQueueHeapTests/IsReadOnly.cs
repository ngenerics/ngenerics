using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class IsReadOnly : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new PriorityQueue<int, int>(PriorityQueueType.Minimum);
            Assert.IsFalse(priorityQueue.IsReadOnly);

            priorityQueue.Add(4);
            Assert.IsFalse(priorityQueue.IsReadOnly);

            priorityQueue.Add(99);
            Assert.IsFalse(priorityQueue.IsReadOnly);

            priorityQueue.Clear();
            Assert.IsFalse(priorityQueue.IsReadOnly);
        }
    }
}