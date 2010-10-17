using System;
using NGenerics.DataStructures.Queues;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservablePriorityQueueTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo");

            ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Remove("foo"), "Count", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo");

            new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Dequeue());
        }
        [Test]
        public void Priority()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo");

            int priority;
            ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Remove("foo", out priority), "Count", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionPriorityReentrancy()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo", 2);
            int priority;
            new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Remove("foo", out priority));
        }

        [Test]
        public void NotInList()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);

            ObservableCollectionTester.ExpectNoEvents(priorityQueue, obj => obj.Remove("foo"));
        }
    }
}