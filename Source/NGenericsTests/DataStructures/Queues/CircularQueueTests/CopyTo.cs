using System;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
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
            var circularQueue = CircularQueueTest.GetOverrunTestQueue();

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
            var circularQueue = CircularQueueTest.GetHalfFullTestQueue();

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
}