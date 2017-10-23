/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Accept
    {

        [Test]
        public void Full()
        {
            var circularQueue = CircularQueueTest.GetFullTestQueue();
            var visitor = new TrackingVisitor<int>();

            circularQueue.AcceptVisitor(visitor);

            var list = new List<int>(visitor.TrackingList);

            Assert.AreEqual(list.Count, 200);

            for (var i = 0; i < 200; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }

        [Test]
        public void HalfFull()
        {
            var circularQueue = CircularQueueTest.GetHalfFullTestQueue();
            var visitor = new TrackingVisitor<int>();

            circularQueue.AcceptVisitor(visitor);

            var list = new List<int>(visitor.TrackingList);

            Assert.AreEqual(list.Count, 200);

            for (var i = 0; i < 200; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }
        [Test]
        public void Overrun()
        {
            var circularQueue = CircularQueueTest.GetOverrunTestQueue();
            var visitor = new TrackingVisitor<int>();

            circularQueue.AcceptVisitor(visitor);

            var list = new List<int>(visitor.TrackingList);

            Assert.AreEqual(list.Count, 40);

            for (var i = 60; i < 100; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }

        [Test]
        public void Empty()
        {
            var circularQueue = new CircularQueue<int>(40);
            var visitor = new TrackingVisitor<int>();

            circularQueue.AcceptVisitor(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, 0);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var circularQueue = new CircularQueue<int>(20);
            circularQueue.AcceptVisitor(null);
        }

        [Test]
        public void StoppingVisitor()
        {
            var circularQueue = CircularQueueTest.GetFullTestQueue();
            var visitor = new CompletedTrackingVisitor<int>();

            circularQueue.AcceptVisitor(visitor);
        }

    }
}