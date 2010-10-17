/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class Peek : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);

            priorityQueue.Enqueue("g", 6);
            Assert.AreEqual(priorityQueue.Peek(), "g");

            priorityQueue.Enqueue("h", 5);
            Assert.AreEqual(priorityQueue.Peek(), "h");

            priorityQueue.Enqueue("i", 7);
            Assert.AreEqual(priorityQueue.Peek(), "h");
        }


        [Test]
        public void SimpleWithPriority()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);

            int priority;

            priorityQueue.Enqueue("g", 6);

            var item = priorityQueue.Peek(out priority);

            Assert.AreEqual(item, "g");
            Assert.AreEqual(priority, 6);
            Assert.AreEqual(priorityQueue.Count, 1);

            priorityQueue.Enqueue("h", 5);

            item = priorityQueue.Peek(out priority);

            Assert.AreEqual(item, "h");
            Assert.AreEqual(priority, 5);
            Assert.AreEqual(priorityQueue.Count, 2);

            priorityQueue.Enqueue("i", 7);

            item = priorityQueue.Peek(out priority);

            Assert.AreEqual(item, "h");
            Assert.AreEqual(priority, 5);
            Assert.AreEqual(priorityQueue.Count, 3);
        }
    }
}