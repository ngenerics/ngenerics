/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var deque = new Deque<int>();
            deque.DequeueHead();
        }
    }
}