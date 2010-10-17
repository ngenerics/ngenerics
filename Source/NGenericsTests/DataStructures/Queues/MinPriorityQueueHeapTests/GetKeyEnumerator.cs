using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class GetKeyEnumerator : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = GetTestPriorityQueue();
            var enumerator = priorityQueue.GetKeyEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;
            }

            Assert.AreEqual(counter, priorityQueue.Count);
        }
    }
}