/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues
{
	[TestFixture]
	public class DequeTest
    {
        #region Tests

        [TestFixture]
        public class Accept
        {

            [Test]
            public void Simple()
            {
                var deque = new Deque<int>();
                deque.EnqueueHead(5);
                deque.EnqueueHead(3);
                deque.EnqueueHead(2);

                var visitor = new TrackingVisitor<int>();

                deque.AcceptVisitor(visitor);

                Assert.AreEqual(visitor.TrackingList.Count, 3);
                Assert.IsTrue(visitor.TrackingList.Contains(5));
                Assert.IsTrue(visitor.TrackingList.Contains(3));
                Assert.IsTrue(visitor.TrackingList.Contains(2));
            }

            [Test]
            public void Done()
            {
                var dequeeque = new Deque<int>();
                dequeeque.EnqueueHead(5);
                dequeeque.EnqueueHead(3);
                dequeeque.EnqueueHead(2);

                var visitor = new CompletedTrackingVisitor<int>();

                dequeeque.AcceptVisitor(visitor);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var dequeeque = new Deque<int>();
                dequeeque.AcceptVisitor(null);
            }

        }

        [TestFixture]
        public class Add
        {

            [Test]
            [ExpectedException(typeof(NotSupportedException))]
            public void ExceptionInterface()
            {
                ICollection<int> dequeeque = GetTestDeque();
                dequeeque.Add(5);
            }

        }

  

        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Simple()
            {
                var deque = new Deque<int>();
                Assert.AreEqual(deque.Count, 0);
                Assert.IsTrue(deque.IsEmpty);

                var stack = new Stack<int>();

                for (var i = 0; i < 3; i++)
                {
                    stack.Push(i * 4);
                }

                deque = new Deque<int>(stack);

                for (var i = 2; i >= 0; i--)
                {
                    Assert.AreEqual(deque.DequeueHead(), i * 4);
                }
            }

        }

        [TestFixture]
        public class Contains
        {

            [Test]
            public void Simple()
            {
                var test = new Deque<int>();
                Assert.IsFalse(test.Contains(5));

                test.EnqueueHead(5);
                test.EnqueueHead(6);

                Assert.IsTrue(test.Contains(5));
                Assert.IsTrue(test.Contains(6));
            }

        }

        [TestFixture]
        public class CopyTo
        {

            [Test]
            public void Simple()
            {
                var dequeeque = new Deque<int>();

                for (var i = 1; i < 20; i++)
                {
                    dequeeque.EnqueueHead(i);
                }

                var array = new int[19];

                dequeeque.CopyTo(array, 0);

                var counter = 1;

                for (var i = 18; i > 0; i--)
                {
                    Assert.AreEqual(array[i], counter);
                    counter++;
                }
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionArrayTooSmall()
            {
                var deque = new Deque<int>();
                deque.EnqueueHead(5);
                deque.EnqueueTail(3);
                deque.EnqueueTail(2);
                deque.EnqueueHead(55);

                var array = new int[3];
                deque.CopyTo(array, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionNotEnoughSpaceFromIndex()
            {
                var deque = new Deque<int>();
                deque.EnqueueHead(5);
                deque.EnqueueTail(3);
                deque.EnqueueTail(2);
                deque.EnqueueHead(55);

                var array = new int[4];
                deque.CopyTo(array, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullArray()
            {
                var deque = new Deque<int>();
                deque.CopyTo(null, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalidArray1()
            {
                var deque = new Deque<int>();

                for (var i = 1; i < 20; i++)
                {
                    deque.EnqueueHead(i);
                }

                var array = new int[19];

                deque.CopyTo(array, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalidArray2()
            {
                var deque = new Deque<int>();

                for (var i = 1; i < 20; i++)
                {
                    deque.EnqueueHead(i);
                }

                var array = new int[18];

                deque.CopyTo(array, 0);
            }
      
        }

        [TestFixture]
        public class DequeueHead
        {

            [Test]
            public void Simple()
            {
                var deque = GetTestDeque();

                for (var i = 4; i >= 0; i--)
                {
                    Assert.AreEqual(deque.DequeueHead(), i * 3);
                    Assert.AreEqual(deque.Count, i);
                }
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionEmpty()
            {
                var deque = new Deque<int>();
                deque.DequeueHead();
            }
        }

        [TestFixture]
        public class DequeueTail
        {

            [Test]
            public void Simple()
            {
                var deque = GetTestDeque();

                for (var i = 0; i < 5; i++)
                {
                    Assert.AreEqual(deque.DequeueTail(), i * 3);
                    Assert.AreEqual(deque.Count, 4 - i);
                }
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionEmpty()
            {
                var deque = new Deque<int>();
                deque.DequeueTail();
            }
        }

        [TestFixture]
        public class EnqueueHead
        {

            [Test]
            public void Simple()
            {
                var deque = new Deque<int>();
                deque.EnqueueHead(6);

                Assert.IsFalse(deque.IsEmpty);
                Assert.AreEqual(deque.Head, 6);
                Assert.AreEqual(deque.Tail, 6);
                Assert.AreEqual(deque.Count, 1);

                deque.EnqueueHead(3);

                Assert.AreEqual(deque.Head, 3);
                Assert.AreEqual(deque.Tail, 6);
                Assert.AreEqual(deque.Count, 2);

                deque.EnqueueHead(5);

                Assert.AreEqual(deque.Head, 5);
                Assert.AreEqual(deque.Tail, 6);
                Assert.AreEqual(deque.Count, 3);
            }

        }

        [TestFixture]
        public class EnqueueTail
        {

            [Test]
            public void Simple()
            {
                var deque = new Deque<int>();
                deque.EnqueueTail(6);

                Assert.IsFalse(deque.IsEmpty);
                Assert.AreEqual(deque.Head, 6);
                Assert.AreEqual(deque.Tail, 6);

                Assert.AreEqual(deque.Count, 1);

                deque.EnqueueTail(3);

                Assert.AreEqual(deque.Head, 6);
                Assert.AreEqual(deque.Tail, 3);

                Assert.AreEqual(deque.Count, 2);

                deque.EnqueueTail(5);

                Assert.AreEqual(deque.Head, 6);
                Assert.AreEqual(deque.Tail, 5);

                Assert.AreEqual(deque.Count, 3);
            }

        }

        [TestFixture]
        public class GetEnumerator
        {

            [Test]
            public void Simple()
            {
                var deque = GetTestDeque();
                var enumerator = deque.GetEnumerator();

                var count = 5;

                while (enumerator.MoveNext())
                {
                    count--;
                    Assert.AreEqual(enumerator.Current, count * 3);
                }

                enumerator.Dispose();
            }

            [Test]
            public void Interface()
            {
                var deque = GetTestDeque();
                var enumerator = ((IEnumerable)deque).GetEnumerator();

                var count = 5;

                while (enumerator.MoveNext())
                {
                    count--;
                    Assert.AreEqual(enumerator.Current, count * 3);
                }
            }

        }

        [TestFixture]
        public class Head
        {

            [Test]
            public void Simple()
            {
                var deque = GetTestDeque();
                var i = deque.Head;
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionEmpty()
            {
                var deque = new Deque<int>();
                Assert.AreEqual(deque.Head, 15);
            }

        }

    

        [TestFixture]
        public class IsEmpty
        {

            [Test]
            public void Simple()
            {
                var deque = GetTestDeque();
                Assert.IsFalse(deque.IsEmpty);

                deque.DequeueHead();

                Assert.IsFalse(deque.IsEmpty);

                deque.Clear();
                Assert.IsTrue(deque.IsEmpty);
            }

        }

        [TestFixture]
        public class IsReadOnly
        {

            [Test]
            public void Simple()
            {
                var deque = new Deque<int>();
                Assert.IsFalse(deque.IsReadOnly);

                deque = GetTestDeque();
                Assert.IsFalse(deque.IsReadOnly);
            }

        }

        [TestFixture]
        public class Remove
        {

            [Test]
            [ExpectedException(typeof(NotSupportedException))]
            public void ExceptionInterface()
            {
                ICollection<int> deque = GetTestDeque();
                deque.Remove(5);
            }

        }

        [TestFixture]
        public class Serialization
        {

            [Test]
            public void Simple()
            {
                var deque = new Deque<int>();

                for (var i = 0; i < 100; i++)
                {
                    deque.EnqueueHead(i);
                }

                for (var i = 200; i >= 100; i--)
                {
                    deque.EnqueueHead(i);
                }

                var newDeque = SerializeUtil.BinarySerializeDeserialize(deque);

                // Test if we indeed have two different instances of deques
                Assert.IsFalse(newDeque == deque);

                TestIfSame(deque, newDeque);
            }

        }

        [TestFixture]
        public class Tail
        {

            [Test]
            public void Simple()
            {
                var deque = GetTestDeque();
                Assert.AreEqual(deque.Tail, 0);
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionEmpty()
            {
                var deque = new Deque<int>();
                var i = deque.Tail;
            }

        }

        #endregion

        #region Private Members

        private static void TestIfSame(Deque<int> deque, Deque<int> newDeque)
        {
            while (deque.Count > 0)
            {
                Assert.AreEqual(deque.DequeueHead(), newDeque.DequeueHead());
            }

            Assert.AreEqual(newDeque.Count, 0);
        }

        private static Deque<int> GetTestDeque()
		{
			var test = new Deque<int>();

			for (var i = 0; i < 5; i++)
			{
				test.EnqueueHead(i * 3);
			}

			return test;
        }

        #endregion
    }
}
