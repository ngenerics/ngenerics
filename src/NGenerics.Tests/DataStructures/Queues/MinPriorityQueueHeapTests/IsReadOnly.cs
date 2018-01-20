/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class IsReadOnly : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new PriorityQueue<int, int>(PriorityQueueType.Minimum);
            Assert.IsFalse(priorityQueue.IsReadOnly);

            priorityQueue.Add(4);
            Assert.IsFalse(priorityQueue.IsReadOnly);

            priorityQueue.Add(99);
            Assert.IsFalse(priorityQueue.IsReadOnly);

            priorityQueue.Clear();
            Assert.IsFalse(priorityQueue.IsReadOnly);
        }
    }
}