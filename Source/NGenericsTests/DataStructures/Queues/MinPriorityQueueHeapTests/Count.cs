/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class Count : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new PriorityQueue<int, int>(PriorityQueueType.Minimum);
            Assert.AreEqual(priorityQueue.Count, 0);

            priorityQueue.Add(4);
            Assert.AreEqual(priorityQueue.Count, 1);

            priorityQueue.Add(99);
            Assert.AreEqual(priorityQueue.Count, 2);

            priorityQueue.Clear();
            Assert.AreEqual(priorityQueue.Count, 0);
        }
    }
}