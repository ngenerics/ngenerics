using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class Serialization : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = GetTestPriorityQueue();
            var newQ = SerializeUtil.BinarySerializeDeserialize(priorityQueue);

            Assert.AreNotSame(priorityQueue, newQ);
            Assert.AreEqual(priorityQueue.Count, newQ.Count);

            while (priorityQueue.Count > 0)
            {
                Assert.AreEqual(priorityQueue.Dequeue(), newQ.Dequeue());
            }
        }
    }
}