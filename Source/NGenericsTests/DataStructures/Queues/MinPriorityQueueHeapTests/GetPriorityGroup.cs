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