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
    public class DequeueHead : DequeTest
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
        public void ExceptionEmpty()
        {
            var deque = new Deque<int>();
            Assert.Throws<InvalidOperationException>(() => deque.DequeueHead());
        }
    }
}