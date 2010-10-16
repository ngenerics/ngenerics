/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.Observable.ObservableCircularQueueTest
{

    [TestFixture]
    public class Contruction
    {
        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableCircularQueue<int>(2));
            ObservableCollectionTester.CheckMonitor(deserialize);
        }

        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableCircularQueue<int>(2));
        }
    }
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

    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {

            var circularQueue = new ObservableCircularQueue<string>(5);
            circularQueue.Enqueue("foo");

            ObservableCollectionTester.ExpectEvents(circularQueue, obj => obj.Clear(), "Count", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            circularQueue.Enqueue("foo");
            new ReentracyTester<ObservableCircularQueue<string>>(circularQueue, obj => obj.Clear());
        }
    }

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

    [TestFixture]
    public class Dequeue
    {
        [Test]
        public void Simple()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            circularQueue.Enqueue("foo");

            ObservableCollectionTester.ExpectEvents(circularQueue, obj => obj.Dequeue(), "Count", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            circularQueue.Enqueue("foo");
            circularQueue.Enqueue("bar");
            new ReentracyTester<ObservableCircularQueue<string>>(circularQueue, obj => obj.Dequeue());
        }
    }

}
