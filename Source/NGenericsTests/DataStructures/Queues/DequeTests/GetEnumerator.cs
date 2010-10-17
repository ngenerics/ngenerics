using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class GetEnumerator : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = GetTestDeque();
            var enumerator = deque.GetEnumerator();

            var count = 5;

            while (enumerator.MoveNext())
            {
                count--;
                Assert.AreEqual(enumerator.Current, count * 3);
            }

            enumerator.Dispose();
        }

        [Test]
        public void Interface()
        {
            var deque = GetTestDeque();
            var enumerator = ((IEnumerable)deque).GetEnumerator();

            var count = 5;

            while (enumerator.MoveNext())
            {
                count--;
                Assert.AreEqual(enumerator.Current, count * 3);
            }
        }

    }
}