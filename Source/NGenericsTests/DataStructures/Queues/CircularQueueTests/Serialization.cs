using NGenerics.DataStructures.Queues;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Serialization
    {

        [Test]
        public void Simple()
        {
            var circularQueue = new CircularQueue<int>(10);

            for (var i = 0; i < 7; i++)
            {
                circularQueue.Enqueue(i);
            }

            var newQ = SerializeUtil.BinarySerializeDeserialize(circularQueue);

            Assert.AreNotSame(circularQueue, newQ);
            Assert.AreEqual(circularQueue.Count, newQ.Count);

            while (circularQueue.Count > 0)
            {
                Assert.AreEqual(circularQueue.Dequeue(), newQ.Dequeue());
            }
        }

    }
}