using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Contruction : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = new Deque<int>();
            Assert.AreEqual(deque.Count, 0);
            Assert.IsTrue(deque.IsEmpty);

            var stack = new Stack<int>();

            for (var i = 0; i < 3; i++)
            {
                stack.Push(i * 4);
            }

            deque = new Deque<int>(stack);

            for (var i = 2; i >= 0; i--)
            {
                Assert.AreEqual(deque.DequeueHead(), i * 4);
            }
        }

    }
}