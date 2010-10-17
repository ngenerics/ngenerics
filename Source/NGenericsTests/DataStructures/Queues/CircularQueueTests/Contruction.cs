using System;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Simple()
        {
            var circularQueue = new CircularQueue<int>(4);
            Assert.AreEqual(circularQueue.Count, 0);
            Assert.IsTrue(circularQueue.IsEmpty);
            Assert.IsFalse(circularQueue.IsFull);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidCapacity1()
        {
            new CircularQueue<int>(0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidCapacity2()
        {
            new CircularQueue<int>(-1);
        }

    }
}