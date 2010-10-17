using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class RemovePriorityGroup : MaxPriorityQueueTest
    {

        [Test]
        public void WithPriority()
        {
            var priorityQueue = GetTestPriorityQueue();

            Assert.IsTrue(priorityQueue.RemovePriorityGroup(2));
            Assert.AreEqual(priorityQueue.Count, 10);

            Assert.IsTrue(priorityQueue.RemovePriorityGroup(3));
            Assert.AreEqual(priorityQueue.Count, 8);

            Assert.IsTrue(priorityQueue.RemovePriorityGroup(4));
            Assert.AreEqual(priorityQueue.Count, 6);

            Assert.IsTrue(priorityQueue.RemovePriorityGroup(1));
            Assert.AreEqual(priorityQueue.Count, 4);

            // z or f
            var str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "z") || (str == "f")));

            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "z") || (str == "f")));

            // y or e 
            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "y") || (str == "e")));

            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "y") || (str == "e")));
        }

    }
}