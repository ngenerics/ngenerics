using System;
using NGenerics.DataStructures.Queues;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Accept : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = new Deque<int>();
            deque.EnqueueHead(5);
            deque.EnqueueHead(3);
            deque.EnqueueHead(2);

            var visitor = new TrackingVisitor<int>();

            deque.AcceptVisitor(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, 3);
            Assert.IsTrue(visitor.TrackingList.Contains(5));
            Assert.IsTrue(visitor.TrackingList.Contains(3));
            Assert.IsTrue(visitor.TrackingList.Contains(2));
        }

        [Test]
        public void Done()
        {
            var dequeeque = new Deque<int>();
            dequeeque.EnqueueHead(5);
            dequeeque.EnqueueHead(3);
            dequeeque.EnqueueHead(2);

            var visitor = new CompletedTrackingVisitor<int>();

            dequeeque.AcceptVisitor(visitor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var dequeeque = new Deque<int>();
            dequeeque.AcceptVisitor(null);
        }

    }
}