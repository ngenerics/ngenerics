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

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class CopyTo : DequeTest
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
}