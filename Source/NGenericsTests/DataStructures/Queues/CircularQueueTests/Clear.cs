/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Clear
    {

        [Test]
        public void Full()
        {
            var circularQueue = CircularQueueTest.GetFullTestQueue();
            circularQueue.Clear();

            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Enqueue(4);
            Assert.AreEqual(circularQueue.Count, 1);

            Assert.AreEqual(circularQueue.Dequeue(), 4);
            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Clear();
            Assert.AreEqual(circularQueue.Count, 0);
        }

        [Test]
        public void Overrun()
        {
            var circularQueue = CircularQueueTest.GetOverrunTestQueue();
            circularQueue.Clear();

            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Enqueue(4);
            Assert.AreEqual(circularQueue.Count, 1);

            Assert.AreEqual(circularQueue.Dequeue(), 4);
            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Clear();
            Assert.AreEqual(circularQueue.Count, 0);
        }

        [Test]
        public void HalfFull()
        {
            var circularQueue = CircularQueueTest.GetHalfFullTestQueue();
            circularQueue.Clear();

            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Enqueue(4);
            Assert.AreEqual(circularQueue.Count, 1);

            Assert.AreEqual(circularQueue.Dequeue(), 4);
            Assert.AreEqual(circularQueue.Count, 0);

            circularQueue.Clear();
            Assert.AreEqual(circularQueue.Count, 0);
        }

    }
}