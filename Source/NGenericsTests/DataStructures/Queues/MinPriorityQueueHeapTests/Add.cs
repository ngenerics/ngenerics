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
    public class Add : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue1 = new PriorityQueue<int, int>(PriorityQueueType.Minimum) { 4 };

            Assert.AreEqual(priorityQueue1.Count, 1);
            Assert.AreEqual(priorityQueue1.Dequeue(), 4);

            priorityQueue1.Add(5);
            priorityQueue1.Add(6, 2);

            Assert.AreEqual(priorityQueue1.Dequeue(), 5);
            Assert.AreEqual(priorityQueue1.Dequeue(), 6);

            priorityQueue1.Add(6, 2);
            priorityQueue1.Add(5);

            Assert.AreEqual(priorityQueue1.Dequeue(), 5);
            Assert.AreEqual(priorityQueue1.Dequeue(), 6);


            var priorityQueue2 = new PriorityQueue<string, int>(PriorityQueueType.Minimum)
                                     {
                                         {"a", 1},
                                         {"b", 2},
                                         {"c", 3},
                                         {"d", 4},
                                         {"e", 5},
                                         {"f", 6},
                                         {"z", 6},
                                         {"y", 5},
                                         {"x", 4},
                                         {"w", 3},
                                         {"v", 2},
                                         {"u", 1},
                                         {"z", 1},
                                         {"y", 2},
                                         {"x", 3},
                                         {"w", 4},
                                         {"v", 5},
                                         {"u", 6}
                                     };

            Assert.AreEqual(priorityQueue2.Count, 18);

            priorityQueue2.Clear();

            Assert.AreEqual(priorityQueue2.Count, 0);
        }

        [Test]
        // Unit test contributed by exyll (see the "PriorityQueue is LIFO instead of FIFO" work item.
        public void FifoSamePriority()
        {
            var priorityQueue = new PriorityQueue<object, int>(PriorityQueueType.Minimum);

            var o1 = new object();
            var o2 = new object();
            var o3 = new object();

            priorityQueue.Enqueue(o1);
            priorityQueue.Enqueue(o2);
            priorityQueue.Enqueue(o3);

            Assert.AreSame(o1, priorityQueue.Dequeue());
            Assert.AreSame(o2, priorityQueue.Dequeue());
            Assert.AreSame(o3, priorityQueue.Dequeue());
        }
    }
}