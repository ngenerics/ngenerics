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
}