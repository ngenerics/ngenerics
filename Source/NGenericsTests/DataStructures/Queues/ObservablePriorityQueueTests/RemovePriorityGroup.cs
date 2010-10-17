/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Queues;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservablePriorityQueueTests
{
    [TestFixture]
    public class RemovePriorityGroup
    {
        [Test]
        public void Simple()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo", 2);

            ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.RemovePriorityGroup(2), "Count", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionPriorityReentrancy()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo", 2);
            new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.RemovePriorityGroup(2));
        }

        [Test]
        public void NotInList()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);

            ObservableCollectionTester.ExpectNoEvents(priorityQueue, obj => obj.RemovePriorityGroup(2));
        }
    }

}
