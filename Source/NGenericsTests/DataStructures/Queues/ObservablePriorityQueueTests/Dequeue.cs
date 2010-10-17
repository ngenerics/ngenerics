using System;
using NGenerics.DataStructures.Queues;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservablePriorityQueueTests
{
    [TestFixture]
    public class Dequeue
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo");

            ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Dequeue(), "Count", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo");

            new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Dequeue());
        }

    }
}