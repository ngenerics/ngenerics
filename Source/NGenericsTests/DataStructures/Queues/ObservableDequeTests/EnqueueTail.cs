using System;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservableDequeTests
{
    [TestFixture]
    public class EnqueueTail
    {
        [Test]
        public void Simple()
        {
            var deque = new ObservableDeque<string>();
            ObservableCollectionTester.ExpectEvents(deque, obj => obj.EnqueueTail("foo"), "Count", "IsEmpty", "Head", "Tail");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var deque = new ObservableDeque<string>();
            new ReentracyTester<ObservableDeque<string>>(deque, obj => obj.EnqueueTail("foo"));
        }

    }
}