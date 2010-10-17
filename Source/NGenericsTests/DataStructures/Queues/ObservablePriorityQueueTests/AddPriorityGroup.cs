using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservablePriorityQueueTests
{
    [TestFixture]
    public class AddPriorityGroup
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            var list = new List<string> { "foo" };
            ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.AddPriorityGroup(list, 2), "Count", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            var list = new List<string> { "foo" };
            new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.AddPriorityGroup(list, 2));
        }

    }
}