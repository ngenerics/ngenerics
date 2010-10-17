using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class IsEmpty : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = GetTestDeque();
            Assert.IsFalse(deque.IsEmpty);

            deque.DequeueHead();

            Assert.IsFalse(deque.IsEmpty);

            deque.Clear();
            Assert.IsTrue(deque.IsEmpty);
        }

    }
}