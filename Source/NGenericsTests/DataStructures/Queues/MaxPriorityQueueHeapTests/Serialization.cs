/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class Serialization : MaxPriorityQueueTest
    {

        [Test]
        public void Simple()
        {
            var priorityQueue = GetTestPriorityQueue();
            var newPriorityQueue = SerializeUtil.BinarySerializeDeserialize(priorityQueue);

            Assert.AreNotSame(priorityQueue, newPriorityQueue);
            Assert.AreEqual(priorityQueue.Count, newPriorityQueue.Count);

            while (priorityQueue.Count > 0)
            {
                Assert.AreEqual(priorityQueue.Dequeue(), newPriorityQueue.Dequeue());
            }
        }

    }
}