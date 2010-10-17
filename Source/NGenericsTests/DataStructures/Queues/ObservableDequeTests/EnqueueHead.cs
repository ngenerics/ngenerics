using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservableDequeTests
{
    [TestFixture]
    public class EnqueueHead
    {
        [Test]
        public void Simple()
        {
            var deque = new ObservableDeque<string>();
            ObservableCollectionTester.ExpectEvents(deque, obj => obj.EnqueueHead("foo"), "Count", "IsEmpty", "Head", "Tail");
        }

    }
}