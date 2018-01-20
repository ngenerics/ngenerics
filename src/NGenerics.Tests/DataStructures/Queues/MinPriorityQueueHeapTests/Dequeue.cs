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

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class Dequeue : MinPriorityQueueTest
    {

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Dequeue();
        }

        [Test]
        public void WithPriority()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("dog", 2);
            priorityQueue.Enqueue("canary", 1);
            priorityQueue.Enqueue("cat", 3);

            int priority;

            // Peek gives us "canary"
            Assert.AreEqual("canary", priorityQueue.Dequeue(out priority));

            // With priority 1
            Assert.AreEqual(priority, 1);

            // Peek gives us "dog"
            Assert.AreEqual("dog", priorityQueue.Dequeue(out priority));

            // With priority 2
            Assert.AreEqual(priority, 2);

            // Peek gives us "cat"
            Assert.AreEqual("cat", priorityQueue.Dequeue(out priority));

            // With priority 3
            Assert.AreEqual(priority, 3);
        }

        [Test]
        public void ReverseSequencing()
        {
            var priorityQueue = GetTestPriorityQueue();

            // u or a
            var str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "u") || (str == "a")));

            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "u") || (str == "a")));

            // v or b
            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "v") || (str == "b")));

            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "v") || (str == "b")));

            // w or c
            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "w") || (str == "c")));

            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "w") || (str == "c")));

            // x or d
            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "x") || (str == "d")));

            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "x") || (str == "d")));


            // y or e 
            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "y") || (str == "e")));

            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "y") || (str == "e")));

            // z or f
            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "z") || (str == "f")));

            str = priorityQueue.Dequeue();
            Assert.IsTrue(((str == "z") || (str == "f")));
        }
    }
}