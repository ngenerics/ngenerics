/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class GetKeyEnumerator : MaxPriorityQueueTest
    {

        [Test]
        public void Simple()
        {
            var priorityQueue = GetTestPriorityQueue();
            var enumerator = priorityQueue.GetKeyEnumerator();

            var counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;
            }

            Assert.AreEqual(counter, priorityQueue.Count);
        }

    }
}