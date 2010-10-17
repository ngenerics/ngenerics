using NGenerics.DataStructures.Queues;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Serialization : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = new Deque<int>();

            for (var i = 0; i < 100; i++)
            {
                deque.EnqueueHead(i);
            }

            for (var i = 200; i >= 100; i--)
            {
                deque.EnqueueHead(i);
            }

            var newDeque = SerializeUtil.BinarySerializeDeserialize(deque);

            // Test if we indeed have two different instances of deques
            Assert.IsFalse(newDeque == deque);

            TestIfSame(deque, newDeque);
        }

    }
}