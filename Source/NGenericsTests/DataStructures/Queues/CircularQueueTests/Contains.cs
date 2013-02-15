/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Contains
    {

        [Test]
        public void Full()
        {
            var circularQueue = CircularQueueTest.GetFullTestQueue();

            for (var i = 100; i < 200; i++)
            {
                Assert.IsTrue(circularQueue.Contains(i));
            }

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(circularQueue.Contains(i));
            }

            Assert.IsFalse(circularQueue.Contains(400));
        }

        [Test]
        public void HalfFull()
        {
            var circularQueue = CircularQueueTest.GetHalfFullTestQueue();

            for (var i = 100; i < 200; i++)
            {
                Assert.IsTrue(circularQueue.Contains(i));
            }

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(circularQueue.Contains(i));
            }

            Assert.IsFalse(circularQueue.Contains(400));
        }

        [Test]
        public void Empty()
        {
            var circularQueue = new CircularQueue<int>(20);

            Assert.IsFalse(circularQueue.Contains(1));
            Assert.IsFalse(circularQueue.Contains(2));
        }

        [Test]
        public void Overrun()
        {
            var circularQueue = CircularQueueTest.GetOverrunTestQueue();

            for (var i = 60; i < 100; i++)
            {
                Assert.IsTrue(circularQueue.Contains(i));
            }

            Assert.IsFalse(circularQueue.Contains(400));
            Assert.IsFalse(circularQueue.Contains(40));
        }

    }
}