/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class Contains : MaxPriorityQueueTest
    {

        [Test]
        public void Simple()
        {
            var priorityQueue = GetTestPriorityQueue();

            Assert.IsTrue(priorityQueue.Contains("a"));
            Assert.IsTrue(priorityQueue.Contains("b"));
            Assert.IsTrue(priorityQueue.Contains("c"));
            Assert.IsTrue(priorityQueue.Contains("d"));
            Assert.IsTrue(priorityQueue.Contains("e"));
            Assert.IsTrue(priorityQueue.Contains("f"));

            Assert.IsFalse(priorityQueue.Contains("g"));
        }

    }
}