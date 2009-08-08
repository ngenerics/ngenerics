/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NGenerics.Tests.Util;
using NGenerics.UI.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.UI.Test.DataStructures.Queues
{
    [TestFixture]
    public class ObservablePriorityQueueTest
    {
        [TestFixture]
        public class Contruction
        {


            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservablePriorityQueue<int, int>(PriorityQueueType.Minimum));
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservablePriorityQueue<int, int>(PriorityQueueType.Minimum));
            }
        }
        [TestFixture]
        public class Enqueue
        {
            [Test]
            public void Simple()
            {
                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
                ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Enqueue("foo"), "Count", "IsEmpty");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
                new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Enqueue("foo"));
            }
            [Test]
            public void Prority()
            {
                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
                ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Enqueue("foo",1), "Count", "IsEmpty");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionPriorityReentrancy()
            {
                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
                new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Enqueue("foo",1));
            }
        }

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
                var list = new List<string>{"foo"};
                new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.AddPriorityGroup(list,2));
            }

        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {

                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
                priorityQueue.Enqueue("foo");

                ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Clear(), "Count", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
                priorityQueue.Enqueue("foo");

                new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Clear());
            }
        }

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
                priorityQueue.Enqueue("foo",2);
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


        [TestFixture]
        public class RemovePriorityGroup
        {
            [Test]
            public void Simple()
            {
                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
                priorityQueue.Enqueue("foo",2);

                ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.RemovePriorityGroup(2), "Count", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionPriorityReentrancy()
            {
                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
                priorityQueue.Enqueue("foo", 2);
                new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.RemovePriorityGroup(2));
            }

            [Test]
            public void NotInList()
            {
                var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);

                ObservableCollectionTester.ExpectNoEvents(priorityQueue, obj => obj.RemovePriorityGroup(2));
            }
        }

    }
}