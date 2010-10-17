using System;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class DequeueHead : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = GetTestDeque();

            for (var i = 4; i >= 0; i--)
            {
                Assert.AreEqual(deque.DequeueHead(), i * 3);
                Assert.AreEqual(deque.Count, i);
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var deque = new Deque<int>();
            deque.DequeueHead();
        }
    }
}