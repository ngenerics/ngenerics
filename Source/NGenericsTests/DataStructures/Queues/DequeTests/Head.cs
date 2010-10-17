using System;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Head : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = GetTestDeque();
            var i = deque.Head;
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var deque = new Deque<int>();
            Assert.AreEqual(deque.Head, 15);
        }

    }
}