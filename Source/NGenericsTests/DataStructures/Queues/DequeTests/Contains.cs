using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Contains : DequeTest
    {

        [Test]
        public void Simple()
        {
            var test = new Deque<int>();
            Assert.IsFalse(test.Contains(5));

            test.EnqueueHead(5);
            test.EnqueueHead(6);

            Assert.IsTrue(test.Contains(5));
            Assert.IsTrue(test.Contains(6));
        }

    }
}