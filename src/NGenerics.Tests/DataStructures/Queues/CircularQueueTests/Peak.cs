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
    public class Peak
    {

        [Test]
        public void Simple()
        {
            var circularQueue = new CircularQueue<int>(20);
            circularQueue.Enqueue(5);
            circularQueue.Enqueue(6);
            circularQueue.Enqueue(7);

            Assert.AreEqual(circularQueue.Peek(), 5);
            Assert.AreEqual(circularQueue.Dequeue(), 5);

            Assert.AreEqual(circularQueue.Peek(), 6);
            Assert.AreEqual(circularQueue.Dequeue(), 6);

            Assert.AreEqual(circularQueue.Peek(), 7);
            Assert.AreEqual(circularQueue.Dequeue(), 7);
        }

        [Test]
        public void ExceptionEmpty()
        {
            var circularQueue = new CircularQueue<int>(20);
            Assert.Throws<InvalidOperationException>(() => circularQueue.Peek());
        }

    }
}