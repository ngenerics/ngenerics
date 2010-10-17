using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class Count : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new PriorityQueue<int, int>(PriorityQueueType.Minimum);
            Assert.AreEqual(priorityQueue.Count, 0);

            priorityQueue.Add(4);
            Assert.AreEqual(priorityQueue.Count, 1);

            priorityQueue.Add(99);
            Assert.AreEqual(priorityQueue.Count, 2);

            priorityQueue.Clear();
            Assert.AreEqual(priorityQueue.Count, 0);
        }
    }
}