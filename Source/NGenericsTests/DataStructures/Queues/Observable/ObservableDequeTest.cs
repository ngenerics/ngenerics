/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.Observable
{
    [TestFixture]
    public class ObservableDequeTest
    {
        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableDeque<int>());
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableDeque<int>());
            }
            [Test]
            public void Monitor2()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableDeque<int>(new List<int>()));
            }
        }
        [TestFixture]
        public class EnqueueHead
        {
            [Test]
            public void Simple()
            {
                var deque = new ObservableDeque<string>();
                ObservableCollectionTester.ExpectEvents(deque, obj => obj.EnqueueHead("foo"), "Count", "IsEmpty", "Head", "Tail");
            }

        }
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

        [TestFixture]
        public class DequeueHead
        {
            [Test]
            public void Simple()
            {
                var deque = new ObservableDeque<string>();
                deque.EnqueueHead("foo");

                ObservableCollectionTester.ExpectEvents(deque, obj => obj.DequeueHead(), "Count", "IsEmpty", "Head", "Tail");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var deque = new ObservableDeque<string>();
                deque.EnqueueHead("foo");
                new ReentracyTester<ObservableDeque<string>>(deque, obj => obj.DequeueHead());
            }
        }

        [TestFixture]
        public class DequeueTail
        {
            [Test]
            public void Simple()
            {
                var deque = new ObservableDeque<string>();
                deque.EnqueueHead("foo");

                ObservableCollectionTester.ExpectEvents(deque, obj => obj.DequeueTail(), "Count", "IsEmpty", "Head", "Tail");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var deque = new ObservableDeque<string>();
                deque.EnqueueHead("foo");
                new ReentracyTester<ObservableDeque<string>>(deque, obj => obj.DequeueTail());
            }
        }

    }
}