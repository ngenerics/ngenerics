/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class EnqueueTail : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = new Deque<int>();
            deque.EnqueueTail(6);

            Assert.AreEqual(6, deque.Head);
            Assert.AreEqual(6, deque.Tail);
            Assert.AreEqual(1, deque.Count);

            deque.EnqueueTail(3);

            Assert.AreEqual(6, deque.Head);
            Assert.AreEqual(3, deque.Tail);
            Assert.AreEqual(2, deque.Count);

            deque.EnqueueTail(5);

            Assert.AreEqual(6, deque.Head);
            Assert.AreEqual(5, deque.Tail);
            Assert.AreEqual(3, deque.Count);
        }
    }
}