/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

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
    public class Clear
    {
        [Test]
        public void Simple()
        {

            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo");

            ObservableCollectionTester.ExpectEvents(priorityQueue, obj => obj.Clear(), "Count", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var priorityQueue = new ObservablePriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("foo");

            new ReentracyTester<ObservablePriorityQueue<string, int>>(priorityQueue, obj => obj.Clear());
        }
    }
}