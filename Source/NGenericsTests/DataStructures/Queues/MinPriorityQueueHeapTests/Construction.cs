/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MinPriorityQueueHeapTests
{
    [TestFixture]
    public class Construction : MinPriorityQueueTest
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);

            Assert.AreEqual(priorityQueue.Count, 0);
        }

        [Test]
        public void WithComparison()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum, (x, y) => (y.CompareTo(x)));
            Assert.AreEqual(priorityQueue.Count, 0);

            priorityQueue.Add("a", 1);
            priorityQueue.Add("b", 2);
            priorityQueue.Add("d", 4);
            priorityQueue.Add("c", 3);

            // The custom comparer switches returns results the other way around than what it should be -
            // The items should come out in a maximum fashion.
            Assert.AreEqual(priorityQueue.Dequeue(), "d");
            Assert.AreEqual(priorityQueue.Dequeue(), "c");
            Assert.AreEqual(priorityQueue.Dequeue(), "b");
            Assert.AreEqual(priorityQueue.Dequeue(), "a");
        }


        [Test]
        public void WithIComparer()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum, new SimpleReverseComparer());
            Assert.AreEqual(priorityQueue.Count, 0);

            priorityQueue.Add("a", 1);
            priorityQueue.Add("b", 2);
            priorityQueue.Add("d", 4);
            priorityQueue.Add("c", 3);

            // The custom comparer switches returns results the other way around than what it should be -
            // The items should come out in a maximum fashion.
            Assert.AreEqual(priorityQueue.Dequeue(), "d");
            Assert.AreEqual(priorityQueue.Dequeue(), "c");
            Assert.AreEqual(priorityQueue.Dequeue(), "b");
            Assert.AreEqual(priorityQueue.Dequeue(), "a");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void WithNonComparableItem()
        {
            var priorityQueue = new PriorityQueue<string, NonComparable>(PriorityQueueType.Minimum);
            Assert.AreEqual(priorityQueue.Count, 0);

            priorityQueue.Add("a", new NonComparable());
            priorityQueue.Add("b", new NonComparable());
        }

        private class NonComparable
        {

        }

        private class SimpleReverseComparer : IComparer<int>
        {
            #region IComparer<int> Members

            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }

            #endregion
        }
    }
}