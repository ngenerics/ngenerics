/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservableCircularQueueTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            circularQueue.Enqueue("foo");

            ObservableCollectionTester.ExpectEvents(circularQueue, obj => obj.Remove("foo"), "Count", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var circularQueue = new ObservableCircularQueue<string>(5);
            circularQueue.Enqueue("foo");
            circularQueue.Enqueue("foo");
            new ReentracyTester<ObservableCircularQueue<string>>(circularQueue, obj => obj.Remove("foo"));
        }
    }
}