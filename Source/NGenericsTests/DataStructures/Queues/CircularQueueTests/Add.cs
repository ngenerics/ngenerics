using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Add
    {

        [Test]
        public void Interface()
        {
            var circularQueue = new CircularQueue<int>(4);
            ((ICollection<int>)circularQueue).Add(1);

            Assert.AreEqual(circularQueue.Dequeue(), 1);

            ((ICollection<int>)circularQueue).Add(2);
            ((ICollection<int>)circularQueue).Add(3);

            ((ICollection<int>)circularQueue).Add(4);
            ((ICollection<int>)circularQueue).Add(5);
            ((ICollection<int>)circularQueue).Add(6);
            ((ICollection<int>)circularQueue).Add(7);

            Assert.AreEqual(circularQueue.Dequeue(), 4);
            Assert.AreEqual(circularQueue.Dequeue(), 5);
            Assert.AreEqual(circularQueue.Dequeue(), 6);
            Assert.AreEqual(circularQueue.Dequeue(), 7);
        }

    }
}