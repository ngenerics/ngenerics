/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class DefaultPriority : MaxPriorityQueueTest
    {

        [Test]
        public void Setter()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Maximum);
            Assert.AreEqual(priorityQueue.DefaultPriority, 0);

            priorityQueue.DefaultPriority = 2;
            Assert.AreEqual(priorityQueue.DefaultPriority, 2);

            priorityQueue.DefaultPriority = -1;
            Assert.AreEqual(priorityQueue.DefaultPriority, -1);
        }

        [Test]
        public void Enqueue()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Maximum) { DefaultPriority = 2 };
            priorityQueue.Enqueue("test1");
            priorityQueue.Enqueue("test2", 3);

            Assert.AreEqual(priorityQueue.Dequeue(), "test2");
            Assert.AreEqual(priorityQueue.Dequeue(), "test1");

            priorityQueue.Enqueue("test1");
            priorityQueue.Enqueue("test2", 1);

            Assert.AreEqual(priorityQueue.Dequeue(), "test1");
            Assert.AreEqual(priorityQueue.Dequeue(), "test2");
        }

    }
}