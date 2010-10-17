using System;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Tail : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = GetTestDeque();
            Assert.AreEqual(deque.Tail, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var deque = new Deque<int>();
            var i = deque.Tail;
        }

    }
}