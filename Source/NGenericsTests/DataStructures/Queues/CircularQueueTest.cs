/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
    public class CircularQueueTest
    {

        [TestFixture]
        public class Accept
        {

            [Test]
            public void Full()
            {
                var circularQueue = GetFullTestQueue();
                var visitor = new TrackingVisitor<int>();

                circularQueue.AcceptVisitor(visitor);

                var list = new List<int>(visitor.TrackingList);

                Assert.AreEqual(list.Count, 200);

                for (var i = 0; i < 200; i++)
                {
                    Assert.IsTrue(list.Contains(i));
                }
            }

            [Test]
            public void HalfFull()
            {
                var circularQueue = GetHalfFullTestQueue();
                var visitor = new TrackingVisitor<int>();

                circularQueue.AcceptVisitor(visitor);

                var list = new List<int>(visitor.TrackingList);

                Assert.AreEqual(list.Count, 200);

                for (var i = 0; i < 200; i++)
                {
                    Assert.IsTrue(list.Contains(i));
                }
            }
            [Test]
            public void Overrun()
            {
                var circularQueue = GetOverrunTestQueue();
                var visitor = new TrackingVisitor<int>();

                circularQueue.AcceptVisitor(visitor);

                var list = new List<int>(visitor.TrackingList);

                Assert.AreEqual(list.Count, 40);

                for (var i = 60; i < 100; i++)
                {
                    Assert.IsTrue(list.Contains(i));
                }
            }

            [Test]
            public void Empty()
            {
                var circularQueue = new CircularQueue<int>(40);
                var visitor = new TrackingVisitor<int>();

                circularQueue.AcceptVisitor(visitor);

                Assert.AreEqual(visitor.TrackingList.Count, 0);
            }


            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var circularQueue = new CircularQueue<int>(20);
                circularQueue.AcceptVisitor(null);
            }

            [Test]
            public void StoppingVisitor()
            {
                var circularQueue = GetFullTestQueue();
                var visitor = new CompletedTrackingVisitor<int>();

                circularQueue.AcceptVisitor(visitor);
            }

        }

        [TestFixture]
		public class Add
		{

			[Test]
			public void Interface()
			{
                var circularQueue = new CircularQueue<int>(4);
                ((ICollection<int>)circularQueue).Add(1);

                Assert.AreEqual(circularQueue.Dequeue(), 1);

                ((ICollection<int>)circularQueue).Add(2);
                ((ICollection<int>)circularQueue).Add(3);

                ((ICollection<int>)circularQueue).Add(4);
                ((ICollection<int>)circularQueue).Add(5);
                ((ICollection<int>)circularQueue).Add(6);
                ((ICollection<int>)circularQueue).Add(7);

                Assert.AreEqual(circularQueue.Dequeue(), 4);
                Assert.AreEqual(circularQueue.Dequeue(), 5);
                Assert.AreEqual(circularQueue.Dequeue(), 6);
                Assert.AreEqual(circularQueue.Dequeue(), 7);
			}

		}
     
        [TestFixture]
		public class Contruction
		{

			[Test]
			public void Simple()
			{
                var circularQueue = new CircularQueue<int>(4);
				Assert.AreEqual(circularQueue.Count, 0);
				Assert.IsTrue(circularQueue.IsEmpty);
				Assert.IsFalse(circularQueue.IsFull);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidCapacity1()
			{
				new CircularQueue<int>(0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidCapacity2()
			{
				new CircularQueue<int>(-1);
			}

        }

        [TestFixture]
        public class Clear
        {

            [Test]
            public void Full()
            {
                var circularQueue = GetFullTestQueue();
                circularQueue.Clear();

                Assert.AreEqual(circularQueue.Count, 0);

                circularQueue.Enqueue(4);
                Assert.AreEqual(circularQueue.Count, 1);

                Assert.AreEqual(circularQueue.Dequeue(), 4);
                Assert.AreEqual(circularQueue.Count, 0);

                circularQueue.Clear();
                Assert.AreEqual(circularQueue.Count, 0);
            }

            [Test]
            public void Overrun()
            {
                var circularQueue = GetOverrunTestQueue();
                circularQueue.Clear();

                Assert.AreEqual(circularQueue.Count, 0);

                circularQueue.Enqueue(4);
                Assert.AreEqual(circularQueue.Count, 1);

                Assert.AreEqual(circularQueue.Dequeue(), 4);
                Assert.AreEqual(circularQueue.Count, 0);

                circularQueue.Clear();
                Assert.AreEqual(circularQueue.Count, 0);
            }

            [Test]
            public void HalfFull()
            {
                var circularQueue = GetHalfFullTestQueue();
                circularQueue.Clear();

                Assert.AreEqual(circularQueue.Count, 0);

                circularQueue.Enqueue(4);
                Assert.AreEqual(circularQueue.Count, 1);

                Assert.AreEqual(circularQueue.Dequeue(), 4);
                Assert.AreEqual(circularQueue.Count, 0);

                circularQueue.Clear();
                Assert.AreEqual(circularQueue.Count, 0);
            }

        }

        [TestFixture]
        public class Contains
        {

            [Test]
            public void Full()
            {
                var circularQueue = GetFullTestQueue();

                for (var i = 100; i < 200; i++)
                {
                    Assert.IsTrue(circularQueue.Contains(i));
                }

                for (var i = 0; i < 100; i++)
                {
                    Assert.IsTrue(circularQueue.Contains(i));
                }

                Assert.IsFalse(circularQueue.Contains(400));
            }

            [Test]
            public void HalfFull()
            {
                var circularQueue = GetHalfFullTestQueue();

                for (var i = 100; i < 200; i++)
                {
                    Assert.IsTrue(circularQueue.Contains(i));
                }

                for (var i = 0; i < 100; i++)
                {
                    Assert.IsTrue(circularQueue.Contains(i));
                }

                Assert.IsFalse(circularQueue.Contains(400));
            }

            [Test]
            public void Empty()
            {
                var circularQueue = new CircularQueue<int>(20);

                Assert.IsFalse(circularQueue.Contains(1));
                Assert.IsFalse(circularQueue.Contains(2));
            }

            [Test]
            public void Overrun()
            {
                var circularQueue = GetOverrunTestQueue();

                for (var i = 60; i < 100; i++)
                {
                    Assert.IsTrue(circularQueue.Contains(i));
                }

                Assert.IsFalse(circularQueue.Contains(400));
                Assert.IsFalse(circularQueue.Contains(40));
            }

        }

        [TestFixture]
        public class CopyTo
        {

            [Test]
            public void Full()
            {
                var circularQueue = new CircularQueue<int>(50);

                for (var i = 0; i < 20; i++)
                {
                    circularQueue.Enqueue(i);
                }

                var array = new int[20];

                circularQueue.CopyTo(array, 0);

                for (var i = 0; i < 20; i++)
                {
                    Assert.AreEqual(array[i], i);
                }
            }

            [Test]
            public void Empty()
            {
                var circularQueue = new CircularQueue<int>(50);

                var array = new int[20];

                for (var i = 0; i < 20; i++)
                {
                    array[i] = -23;
                }

                circularQueue.CopyTo(array, 0);

                for (var i = 0; i < 20; i++)
                {
                    Assert.AreEqual(array[i], -23);
                }
            }

            [Test]
            public void Overrun()
            {
                var circularQueue = GetOverrunTestQueue();

                var array = new int[40];

                circularQueue.CopyTo(array, 0);

                var counter = 0;

                for (var i = 60; i < 100; i++)
                {
                    Assert.AreEqual(array[counter], i);
                    counter++;
                }
            }

            [Test]
            public void HalfFull()
            {
                var circularQueue = GetHalfFullTestQueue();

                var array = new int[200];

                circularQueue.CopyTo(array, 0);

                var counter = 0;

                for (var i = 100; i < 200; i++)
                {
                    Assert.AreEqual(array[counter], i);
                    counter++;
                }

                for (var i = 0; i < 100; i++)
                {
                    Assert.AreEqual(array[counter], i);
                    counter++;
                }
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullArray()
            {
                var circularQueue = new CircularQueue<int>(20);
                circularQueue.CopyTo(null, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExeptionInvalidArray1()
            {
                var circularQueue = new CircularQueue<int>(30);

                for (var i = 1; i < 20; i++)
                {
                    circularQueue.Enqueue(i);
                }

                var array = new int[19];

                circularQueue.CopyTo(array, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalidArray2()
            {
                var circularQueue = new CircularQueue<int>(20);

                for (var i = 1; i < 20; i++)
                {
                    circularQueue.Enqueue(i);
                }

                var array = new int[18];

                circularQueue.CopyTo(array, 0);
            }

        }

        [TestFixture]
		public class Dequeue
		{

			[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void ExceptionEmpty()
			{
				var circularQueue = new CircularQueue<int>(40);
				circularQueue.Dequeue();
			}

		}

        [TestFixture]
		public class Enqueue
		{

			[Test]
			public void Simple()
			{
                var circularQueue = new CircularQueue<int>(4);

				circularQueue.Enqueue(1);
				Assert.AreEqual(circularQueue.Dequeue(), 1);

				circularQueue.Enqueue(2);
				circularQueue.Enqueue(3);
				Assert.AreEqual(circularQueue.Dequeue(), 2);
				Assert.AreEqual(circularQueue.Dequeue(), 3);

				circularQueue.Enqueue(4);
				circularQueue.Enqueue(5);
				circularQueue.Enqueue(6);
				circularQueue.Enqueue(7);

				Assert.AreEqual(circularQueue.Dequeue(), 4);
				Assert.AreEqual(circularQueue.Dequeue(), 5);
				Assert.AreEqual(circularQueue.Dequeue(), 6);
				Assert.AreEqual(circularQueue.Dequeue(), 7);


				circularQueue.Enqueue(8);
				circularQueue.Enqueue(9);
				Assert.AreEqual(circularQueue.Dequeue(), 8);
				circularQueue.Enqueue(10);
				Assert.IsFalse(circularQueue.IsEmpty);
				Assert.IsFalse(circularQueue.IsFull);
				circularQueue.Enqueue(11);
				circularQueue.Enqueue(12);

				Assert.IsFalse(circularQueue.IsEmpty);

				Console.WriteLine("d.IsFull");
				Assert.IsTrue(circularQueue.IsFull);
				Assert.AreEqual(circularQueue.Count, 4);

				Assert.AreEqual(circularQueue.Dequeue(), 9);
				Assert.AreEqual(circularQueue.Count, 3);

				Assert.AreEqual(circularQueue.Dequeue(), 10);
				Assert.AreEqual(circularQueue.Count, 2);

				Assert.AreEqual(circularQueue.Dequeue(), 11);
				Assert.AreEqual(circularQueue.Count, 1);

				Assert.AreEqual(circularQueue.Dequeue(), 12);

				Assert.IsFalse(circularQueue.IsFull);
				Assert.IsTrue(circularQueue.IsEmpty);
				Assert.AreEqual(circularQueue.Count, 0);
			}

			[Test]
			public void OverFlow()
			{
                var circularQueue = new CircularQueue<int>(5);

				for (var i = 0; i < 10; i++)
				{
					circularQueue.Enqueue(i);
				}

				Assert.AreEqual(circularQueue.Count, 5);

				for (var i = 0; i < 5; i++)
				{
					Assert.AreEqual(circularQueue.Count, 5 - i);
					Assert.AreEqual(circularQueue.Dequeue(), i + 5);
					Assert.AreEqual(circularQueue.Count, 4 - i);
				}

				circularQueue = new CircularQueue<int>(100);

				for (var i = 0; i < 200; i++)
				{
					circularQueue.Enqueue(i);
				}

				for (var i = 100; i < 200; i++)
				{
					Assert.AreEqual(circularQueue.Dequeue(), i);
				}
			}

		}

        [TestFixture]
        public class GetEnumerator
        {

            [Test]
            public void Simple()
            {
                var circularQueue = GetFullTestQueue();

                var list = new List<int>();

                using (var enumerator = circularQueue.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }
                }

                Assert.AreEqual(list.Count, 200);

                for (var i = 0; i < 200; i++)
                {
                    Assert.IsTrue(list.Contains(i));
                }
            }

            [Test]
            public void Interface()
            {
                IEnumerable circularQueue = GetFullTestQueue();

                var list = new List<int>();

                var enumerator = circularQueue.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    list.Add((int)enumerator.Current);
                }

                Assert.AreEqual(list.Count, 200);

                for (var i = 0; i < 200; i++)
                {
                    Assert.IsTrue(list.Contains(i));
                }
            }

        }


        [TestFixture]
		public class IsReadOnly
		{

			[Test]
			public void Simple()
			{
				var circularQueue = new CircularQueue<int>(40);
				Assert.IsFalse(circularQueue.IsReadOnly);

                circularQueue = GetFullTestQueue();
				Assert.IsFalse(circularQueue.IsReadOnly);
			}

		}

        [TestFixture]
		public class Peak
		{

			[Test]
			public void Simple()
			{
				var circularQueue = new CircularQueue<int>(20);
				circularQueue.Enqueue(5);
				circularQueue.Enqueue(6);
				circularQueue.Enqueue(7);

				Assert.AreEqual(circularQueue.Peek(), 5);
				Assert.AreEqual(circularQueue.Dequeue(), 5);

				Assert.AreEqual(circularQueue.Peek(), 6);
				Assert.AreEqual(circularQueue.Dequeue(), 6);

				Assert.AreEqual(circularQueue.Peek(), 7);
				Assert.AreEqual(circularQueue.Dequeue(), 7);
			}

			[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void ExceptionEmpty()
			{
				var circularQueue = new CircularQueue<int>(20);
				circularQueue.Peek();
			}

		}

        [TestFixture]
		public class Remove
		{

			[Test]
			public void Interface()
			{
				ICollection<int> c = new CircularQueue<int>(20);
				Assert.IsFalse(c.Remove(5));

				c.Add(2);

				Assert.AreEqual(c.Count, 1);
				Assert.IsTrue(c.Remove(2));
				Assert.AreEqual(c.Count, 0);

				c.Add(4);
				c.Add(5);
				c.Add(6);

				Assert.AreEqual(c.Count, 3);
				Assert.IsFalse(c.Remove(2));
				Assert.AreEqual(c.Count, 3);

				Assert.IsTrue(c.Remove(5));
				Assert.AreEqual(c.Count, 2);

				Assert.IsTrue(c.Remove(6));
				Assert.AreEqual(c.Count, 1);

				Assert.IsTrue(c.Remove(4));
				Assert.AreEqual(c.Count, 0);
			}
	
		}

        [TestFixture]
		public class Serialization
		{

			[Test]
			public void Simple()
			{
				var circularQueue = new CircularQueue<int>(10);

				for (var i = 0; i < 7; i++)
				{
					circularQueue.Enqueue(i);
				}

                var newQ = SerializeUtil.BinarySerializeDeserialize(circularQueue);

                Assert.AreNotSame(circularQueue, newQ);
				Assert.AreEqual(circularQueue.Count, newQ.Count);

				while (circularQueue.Count > 0)
				{
					Assert.AreEqual(circularQueue.Dequeue(), newQ.Dequeue());
				}
			}

		}

        [Test]
        public void RandomEnqueueDequeue()
        {
            var circularQueue = new CircularQueue<int>(66);

            var currentItems = new List<int>();
            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 513; i++)
            {
                var number = rand.Next(10000);

                if (number % 2 == 0)
                {
                    circularQueue.Enqueue(number);
                    currentItems.Add(number);
                }
                else
                {
                    if (circularQueue.Count > 0)
                    {
                        Assert.IsTrue(currentItems.Remove(circularQueue.Dequeue()));
                    }
                }

                foreach (var item in currentItems)
                {
                    Assert.IsTrue(circularQueue.Contains(item));
                }
            }
        }

        [Test]
        public void RandomEnqueueDequeueStartWithFullQueue()
        {
            var circularQueue = new CircularQueue<int>(50);
            var currentItems = new List<int>();

            for (var i = 0; i < 50; i++)
            {
                circularQueue.Enqueue(i);
                currentItems.Add(i);
            }

            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 500; i++)
            {
                var number = rand.Next(10000);

                if (number % 2 == 0)
                {
                    if (circularQueue.Count == circularQueue.Capacity)
                    {
                        currentItems.Remove(circularQueue.Peek());
                    }

                    circularQueue.Enqueue(number);
                    currentItems.Add(number);
                }
                else
                {
                    if (circularQueue.Count > 0)
                    {
                        var val = circularQueue.Dequeue();

                        if (!currentItems.Contains(val))
                        {
                            Console.Write("a");
                        }

                        Assert.IsTrue(currentItems.Remove(val));
                    }
                }

                foreach (var item in currentItems)
                {
                    if (circularQueue.Contains(item) == false)
                    {
                        Console.Write("a");
                    }

                    Assert.IsTrue(circularQueue.Contains(item));
                }
            }
        }



        private static CircularQueue<int> GetFullTestQueue()
        {
            var circularQueue = new CircularQueue<int>(200);

            for (var i = 100; i < 200; i++)
            {
                circularQueue.Enqueue(i);
            }

            for (var i = 0; i < 100; i++)
            {
                circularQueue.Enqueue(i);
            }

            return circularQueue;
        }

        private static CircularQueue<int> GetHalfFullTestQueue()
        {
            var circularQueue = new CircularQueue<int>(400);

            for (var i = 100; i < 200; i++)
            {
                circularQueue.Enqueue(i);
            }

            for (var i = 0; i < 100; i++)
            {
                circularQueue.Enqueue(i);
            }

            return circularQueue;
        }

        private static CircularQueue<int> GetOverrunTestQueue()
        {
            var circularQueue = new CircularQueue<int>(40);

            for (var i = 100; i < 200; i++)
            {
                circularQueue.Enqueue(i);
            }

            for (var i = 0; i < 100; i++)
            {
                circularQueue.Enqueue(i);
            }

            return circularQueue;
        }
    }
}