using System;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservableCircularQueueTests
{
    [TestFixture]
    public class Enqueue
    {
        [Test]
        public void Simple()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            ObservableCollectionTester.ExpectEvents(circularQueue, obj => obj.Enqueue("foo"), "Count", "IsEmpty");
        }


        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            new ReentracyTester<ObservableCircularQueue<string>>(circularQueue, obj => obj.Enqueue("foo"));
        }
    }
}