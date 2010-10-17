using System;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservableDequeTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {

            var deque = new ObservableDeque<string>();
            deque.EnqueueHead("foo");

            ObservableCollectionTester.ExpectEvents(deque, obj => obj.Clear(), "Count", "IsEmpty", "Head", "Tail");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var deque = new ObservableDeque<string>();
            deque.EnqueueHead("foo");
            new ReentracyTester<ObservableDeque<string>>(deque, obj => obj.Clear());
        }
    }
}