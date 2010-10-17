using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class EnqueueHead : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = new Deque<int>();
            deque.EnqueueHead(6);

            Assert.IsFalse(deque.IsEmpty);
            Assert.AreEqual(deque.Head, 6);
            Assert.AreEqual(deque.Tail, 6);
            Assert.AreEqual(deque.Count, 1);

            deque.EnqueueHead(3);

            Assert.AreEqual(deque.Head, 3);
            Assert.AreEqual(deque.Tail, 6);
            Assert.AreEqual(deque.Count, 2);

            deque.EnqueueHead(5);

            Assert.AreEqual(deque.Head, 5);
            Assert.AreEqual(deque.Tail, 6);
            Assert.AreEqual(deque.Count, 3);
        }

    }
}