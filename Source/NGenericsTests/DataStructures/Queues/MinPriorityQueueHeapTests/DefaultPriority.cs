using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class DefaultPriority : MinPriorityQueueTest
    {

        [Test]
        public void Enqueue()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum) { DefaultPriority = 2 };
            priorityQueue.Enqueue("test1");
            priorityQueue.Enqueue("test2", 3);

            Assert.AreEqual(priorityQueue.Dequeue(), "test1");
            Assert.AreEqual(priorityQueue.Dequeue(), "test2");

            priorityQueue.Enqueue("test1");
            priorityQueue.Enqueue("test2", 1);

            Assert.AreEqual(priorityQueue.Dequeue(), "test2");
            Assert.AreEqual(priorityQueue.Dequeue(), "test1");
        }

        [Test]
        public void Setter()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            Assert.AreEqual(priorityQueue.DefaultPriority, 0);

            priorityQueue.DefaultPriority = 2;
            Assert.AreEqual(priorityQueue.DefaultPriority, 2);

            priorityQueue.DefaultPriority = -1;
            Assert.AreEqual(priorityQueue.DefaultPriority, -1);
        }
    }
}