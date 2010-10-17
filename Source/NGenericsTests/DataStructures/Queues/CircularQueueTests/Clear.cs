using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Clear
    {

        [Test]
        public void Full()
        {
            var circularQueue = CircularQueueTest.GetFullTestQueue();
            circularQueue.Clear();

            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Enqueue(4);
            Assert.AreEqual(circularQueue.Count, 1);

            Assert.AreEqual(circularQueue.Dequeue(), 4);
            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Clear();
            Assert.AreEqual(circularQueue.Count, 0);
        }

        [Test]
        public void Overrun()
        {
            var circularQueue = CircularQueueTest.GetOverrunTestQueue();
            circularQueue.Clear();

            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Enqueue(4);
            Assert.AreEqual(circularQueue.Count, 1);

            Assert.AreEqual(circularQueue.Dequeue(), 4);
            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Clear();
            Assert.AreEqual(circularQueue.Count, 0);
        }

        [Test]
        public void HalfFull()
        {
            var circularQueue = CircularQueueTest.GetHalfFullTestQueue();
            circularQueue.Clear();

            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Enqueue(4);
            Assert.AreEqual(circularQueue.Count, 1);

            Assert.AreEqual(circularQueue.Dequeue(), 4);
            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Clear();
            Assert.AreEqual(circularQueue.Count, 0);
        }

    }
}