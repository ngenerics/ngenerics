/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class EnqueueHead : DequeTest
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
}