using System;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class Accept : MaxPriorityQueueTest
    {

        [Test]
        public void Done()
        {
            var priorityQueue = GetSimpleTestPriorityQueue();
            var visitor = new CompletedTrackingVisitor<string>();
            priorityQueue.AcceptVisitor(visitor);
        }

        [Test]
        public void Simple()
        {
            var a = false;
            var b = false;
            var c = false;
            var d = false;
            var e = false;
            var f = false;

            var count = 0;

            var priorityQueue = GetSimpleTestPriorityQueue();
            var visitor = new TrackingVisitor<string>();

            priorityQueue.AcceptVisitor(visitor);

            foreach (var t in visitor.TrackingList)
            {
                count++;

                if (t == "a")
                {
                    a = true;
                }
                else if (t == "b")
                {
                    b = true;
                }
                else if (t == "c")
                {
                    c = true;
                }
                else if (t == "d")
                {
                    d = true;
                }
                else if (t == "e")
                {
                    e = true;
                }
                else if (t == "f")
                {
                    f = true;
                }
            }

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsTrue(c);
            Assert.IsTrue(d);
            Assert.IsTrue(e);
            Assert.IsTrue(f);

            Assert.AreEqual(count, 6);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var priorityQueue = GetTestPriorityQueue();
            priorityQueue.AcceptVisitor(null);
        }

    }
}