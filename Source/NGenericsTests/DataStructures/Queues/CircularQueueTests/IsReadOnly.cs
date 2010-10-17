using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class IsReadOnly
    {

        [Test]
        public void Simple()
        {
            var circularQueue = new CircularQueue<int>(40);
            Assert.IsFalse(circularQueue.IsReadOnly);

            circularQueue = CircularQueueTest.GetFullTestQueue();
            Assert.IsFalse(circularQueue.IsReadOnly);
        }

    }
}