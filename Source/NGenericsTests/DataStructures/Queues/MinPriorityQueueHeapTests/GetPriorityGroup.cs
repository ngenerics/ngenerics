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
    public class GetPriorityGroup : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = GetTestPriorityQueue();

            var list = priorityQueue.GetPriorityGroup(1);

            Assert.IsTrue(list.Contains("a"));
            Assert.IsTrue(list.Contains("u"));

            list = priorityQueue.GetPriorityGroup(2);

            Assert.IsTrue(list.Contains("b"));
            Assert.IsTrue(list.Contains("v"));

            list = priorityQueue.GetPriorityGroup(3);

            Assert.IsTrue(list.Contains("c"));
            Assert.IsTrue(list.Contains("w"));

            list = priorityQueue.GetPriorityGroup(4);

            Assert.IsTrue(list.Contains("d"));
            Assert.IsTrue(list.Contains("x"));

            list = priorityQueue.GetPriorityGroup(5);

            Assert.IsTrue(list.Contains("e"));
            Assert.IsTrue(list.Contains("y"));

            list = priorityQueue.GetPriorityGroup(6);

            Assert.IsTrue(list.Contains("z"));
            Assert.IsTrue(list.Contains("f"));
        }
    }
}