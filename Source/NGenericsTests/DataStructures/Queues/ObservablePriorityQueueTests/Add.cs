using System;
using NGenerics.DataStructures.Queues;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservablePriorityQueueTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Add("foo"), "Count", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Add("foo"));
        }
        [Test]
        public void Prority()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Add("foo", 1), "Count", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionPriorityReentrancy()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Add("foo", 1));
        }
    }
}