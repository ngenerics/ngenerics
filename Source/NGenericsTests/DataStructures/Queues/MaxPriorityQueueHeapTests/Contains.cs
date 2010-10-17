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