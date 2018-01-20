/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class Contains : MinPriorityQueueTest
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