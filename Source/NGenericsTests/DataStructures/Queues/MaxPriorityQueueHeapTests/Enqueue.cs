using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class Enqueue : MaxPriorityQueueTest
    {

        [Test]
        public void Simple()
        {
            var priorityQueue1 = new PriorityQueue<int, int>(PriorityQueueType.Maximum);
            priorityQueue1.Enqueue(4);

            Assert.AreEqual(priorityQueue1.Count, 1);
            Assert.AreEqual(priorityQueue1.Dequeue(), 4);

            priorityQueue1.Enqueue(5);
            priorityQueue1.Enqueue(6, 2);

            Assert.AreEqual(priorityQueue1.Dequeue(), 6);
            Assert.AreEqual(priorityQueue1.Dequeue(), 5);

            priorityQueue1.Enqueue(6, 2);
            priorityQueue1.Enqueue(5);

            Assert.AreEqual(priorityQueue1.Dequeue(), 6);
            Assert.AreEqual(priorityQueue1.Dequeue(), 5);

            var priorityQueue2 = new PriorityQueue<string, int>(PriorityQueueType.Maximum);

            priorityQueue2.Enqueue("a", 1);
            priorityQueue2.Enqueue("b", 2);
            priorityQueue2.Enqueue("c", 3);
            priorityQueue2.Enqueue("d", 4);
            priorityQueue2.Enqueue("e", 5);
            priorityQueue2.Enqueue("f", 6);

            priorityQueue2.Enqueue("z", 6);
            priorityQueue2.Enqueue("y", 5);
            priorityQueue2.Enqueue("x", 4);
            priorityQueue2.Enqueue("w", 3);
            priorityQueue2.Enqueue("v", 2);
            priorityQueue2.Enqueue("u", 1);

            priorityQueue2.Enqueue("z", 1);
            priorityQueue2.Enqueue("y", 2);
            priorityQueue2.Enqueue("x", 3);
            priorityQueue2.Enqueue("w", 4);
            priorityQueue2.Enqueue("v", 5);
            priorityQueue2.Enqueue("u", 6);

            Assert.AreEqual(priorityQueue2.Count, 18);

            priorityQueue2.Clear();

            Assert.AreEqual(priorityQueue2.Count, 0);
        }

    }
}