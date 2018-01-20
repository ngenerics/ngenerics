/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

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
        public void ExceptionNullArray()
        {
            var circularQueue = new CircularQueue<int>(20);
            Assert.Throws<ArgumentNullException>(() => circularQueue.CopyTo(null, 0));
        }

        [Test]
        public void ExeptionInvalidArray1()
        {
            var circularQueue = new CircularQueue<int>(30);

            for (var i = 1; i < 20; i++)
            {
                circularQueue.Enqueue(i);
            }

            var array = new int[19];

            Assert.Throws<ArgumentException>(() => circularQueue.CopyTo(array, 1));
        }

        [Test]
        public void ExceptionInvalidArray2()
        {
            var circularQueue = new CircularQueue<int>(20);

            for (var i = 1; i < 20; i++)
            {
                circularQueue.Enqueue(i);
            }

            var array = new int[18];

            Assert.Throws<ArgumentException>(() => circularQueue.CopyTo(array, 0));
        }

    }
}