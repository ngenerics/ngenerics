/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
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
}