using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class IsReadOnly : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = new Deque<int>();
            Assert.IsFalse(deque.IsReadOnly);

            deque = GetTestDeque();
            Assert.IsFalse(deque.IsReadOnly);
        }

    }
}