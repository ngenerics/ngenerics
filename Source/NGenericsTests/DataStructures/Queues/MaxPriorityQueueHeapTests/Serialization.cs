using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class Serialization : MaxPriorityQueueTest
    {

        [Test]
        public void Simple()
        {
            var priorityQueue = GetTestPriorityQueue();
            var newPriorityQueue = SerializeUtil.BinarySerializeDeserialize(priorityQueue);

            Assert.AreNotSame(priorityQueue, newPriorityQueue);
            Assert.AreEqual(priorityQueue.Count, newPriorityQueue.Count);

            while (priorityQueue.Count > 0)
            {
                Assert.AreEqual(priorityQueue.Dequeue(), newPriorityQueue.Dequeue());
            }
        }

    }
}