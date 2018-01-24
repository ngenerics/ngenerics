/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Queues;
using NGenerics.Extensions;
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
            Assert.AreEqual(1, circularQueue.Dequeue());

            circularQueue.Enqueue(2);
            circularQueue.Enqueue(3);
            Assert.AreEqual(2, circularQueue.Dequeue());
            Assert.AreEqual(3, circularQueue.Dequeue());

            circularQueue.Enqueue(4);
            circularQueue.Enqueue(5);
            circularQueue.Enqueue(6);
            circularQueue.Enqueue(7);

            Assert.AreEqual(4, circularQueue.Dequeue());
            Assert.AreEqual(5, circularQueue.Dequeue());
            Assert.AreEqual(6, circularQueue.Dequeue());
            Assert.AreEqual(7, circularQueue.Dequeue());


            circularQueue.Enqueue(8);
            circularQueue.Enqueue(9);
            Assert.AreEqual(8, circularQueue.Dequeue());
            circularQueue.Enqueue(10);
            Assert.IsFalse(circularQueue.IsEmpty());
            Assert.IsFalse(circularQueue.IsFull);
            circularQueue.Enqueue(11);
            circularQueue.Enqueue(12);

            Assert.IsFalse(circularQueue.IsEmpty());

            Assert.IsTrue(circularQueue.IsFull);
            Assert.AreEqual(4, circularQueue.Count);

            Assert.AreEqual(9, circularQueue.Dequeue());
            Assert.AreEqual(3, circularQueue.Count);

            Assert.AreEqual(10, circularQueue.Dequeue());
            Assert.AreEqual(2, circularQueue.Count);

            Assert.AreEqual(11, circularQueue.Dequeue());
            Assert.AreEqual(1, circularQueue.Count);

            Assert.AreEqual(12, circularQueue.Dequeue());

            Assert.IsFalse(circularQueue.IsFull);
            Assert.AreEqual(0, circularQueue.Count);
        }

        [Test]
        public void OverFlow()
        {
            var circularQueue = new CircularQueue<int>(5);

            for (var i = 0; i < 10; i++)
            {
                circularQueue.Enqueue(i);
            }

            Assert.AreEqual(5, circularQueue.Count);

            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(5 - i, circularQueue.Count);
                Assert.AreEqual(i + 5, circularQueue.Dequeue());
                Assert.AreEqual(4 - i, circularQueue.Count);
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