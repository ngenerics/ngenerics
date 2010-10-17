using System;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservableCircularQueueTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            circularQueue.Enqueue("foo");

            ObservableCollectionTester.ExpectEvents(circularQueue, obj => obj.Remove("foo"), "Count", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            circularQueue.Enqueue("foo");
            circularQueue.Enqueue("foo");
            new ReentracyTester<ObservableCircularQueue<string>>(circularQueue, obj => obj.Remove("foo"));
        }
    }
}