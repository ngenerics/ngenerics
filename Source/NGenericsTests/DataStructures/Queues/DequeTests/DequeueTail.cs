using System;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class DequeueTail : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = GetTestDeque();

            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(deque.DequeueTail(), i * 3);
                Assert.AreEqual(deque.Count, 4 - i);
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var deque = new Deque<int>();
            deque.DequeueTail();
        }
    }
}