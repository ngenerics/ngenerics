/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Enqueue
    {

        [Test]
        public void Simple()
        {
            var circularQueue = new CircularQueue<int>(4);

            circularQueue.Enqueue(1);
            Assert.AreEqual(circularQueue.Dequeue(), 1);

            circularQueue.Enqueue(2);
            circularQueue.Enqueue(3);
            Assert.AreEqual(circularQueue.Dequeue(), 2);
            Assert.AreEqual(circularQueue.Dequeue(), 3);

            circularQueue.Enqueue(4);
            circularQueue.Enqueue(5);
            circularQueue.Enqueue(6);
            circularQueue.Enqueue(7);

            Assert.AreEqual(circularQueue.Dequeue(), 4);
            Assert.AreEqual(circularQueue.Dequeue(), 5);
            Assert.AreEqual(circularQueue.Dequeue(), 6);
            Assert.AreEqual(circularQueue.Dequeue(), 7);


            circularQueue.Enqueue(8);
            circularQueue.Enqueue(9);
            Assert.AreEqual(circularQueue.Dequeue(), 8);
            circularQueue.Enqueue(10);
            Assert.IsFalse(circularQueue.IsEmpty);
            Assert.IsFalse(circularQueue.IsFull);
            circularQueue.Enqueue(11);
            circularQueue.Enqueue(12);

            Assert.IsFalse(circularQueue.IsEmpty);

            Assert.IsTrue(circularQueue.IsFull);
            Assert.AreEqual(circularQueue.Count, 4);

            Assert.AreEqual(circularQueue.Dequeue(), 9);
            Assert.AreEqual(circularQueue.Count, 3);

            Assert.AreEqual(circularQueue.Dequeue(), 10);
            Assert.AreEqual(circularQueue.Count, 2);

            Assert.AreEqual(circularQueue.Dequeue(), 11);
            Assert.AreEqual(circularQueue.Count, 1);

            Assert.AreEqual(circularQueue.Dequeue(), 12);

            Assert.IsFalse(circularQueue.IsFull);
            Assert.IsTrue(circularQueue.IsEmpty);
            Assert.AreEqual(circularQueue.Count, 0);
        }

        [Test]
        public void OverFlow()
        {
            var circularQueue = new CircularQueue<int>(5);

            for (var i = 0; i < 10; i++)
            {
                circularQueue.Enqueue(i);
            }

            Assert.AreEqual(circularQueue.Count, 5);

            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(circularQueue.Count, 5 - i);
                Assert.AreEqual(circularQueue.Dequeue(), i + 5);
                Assert.AreEqual(circularQueue.Count, 4 - i);
            }

            circularQueue = new CircularQueue<int>(100);

            for (var i = 0; i < 200; i++)
            {
                circularQueue.Enqueue(i);
            }

            for (var i = 100; i < 200; i++)
            {
                Assert.AreEqual(circularQueue.Dequeue(), i);
            }
        }

    }
}