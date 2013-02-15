/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class Remove : MaxPriorityQueueTest
    {

        [Test]
        public void Simple()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Maximum) { "5" };

            Assert.AreEqual(priorityQueue.Count, 1);
            Assert.IsTrue(priorityQueue.Contains("5"));
            Assert.IsTrue(priorityQueue.Remove("5"));
            Assert.AreEqual(priorityQueue.Count, 0);

            priorityQueue.Add("6");
            priorityQueue.Add("7");
            priorityQueue.Add("2", 4);

            Assert.AreEqual(priorityQueue.Count, 3);
            Assert.IsTrue(priorityQueue.Contains("6"));
            Assert.IsTrue(priorityQueue.Contains("7"));
            Assert.IsTrue(priorityQueue.Contains("2"));

            Assert.IsFalse(priorityQueue.Remove("8"));

            Assert.IsTrue(priorityQueue.Remove("7"));
            Assert.AreEqual(priorityQueue.Count, 2);
            Assert.IsTrue(priorityQueue.Remove("2"));
            Assert.AreEqual(priorityQueue.Count, 1);
            Assert.IsTrue(priorityQueue.Remove("6"));
            Assert.AreEqual(priorityQueue.Count, 0);

            Assert.IsFalse(priorityQueue.Remove("7"));
        }

        [Test]
        public void WithPriority()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Maximum);

            int priority;

            priorityQueue.Add("5", 3);
            Assert.AreEqual(priorityQueue.Count, 1);
            Assert.IsTrue(priorityQueue.Contains("5"));
            Assert.IsTrue(priorityQueue.Remove("5", out priority));
            Assert.AreEqual(priority, 3);

            Assert.AreEqual(priorityQueue.Count, 0);

            priorityQueue.Add("6");
            priorityQueue.Add("7");
            priorityQueue.Add("2", 4);


            Assert.AreEqual(priorityQueue.Count, 3);
            Assert.IsTrue(priorityQueue.Contains("6"));
            Assert.IsTrue(priorityQueue.Contains("7"));
            Assert.IsTrue(priorityQueue.Contains("2"));

            Assert.IsFalse(priorityQueue.Remove("8", out priority));

            Assert.IsTrue(priorityQueue.Remove("7", out priority));
            Assert.AreEqual(priority, 0);
            Assert.AreEqual(priorityQueue.Count, 2);

            Assert.IsTrue(priorityQueue.Remove("2", out priority));
            Assert.AreEqual(priority, 4);

            Assert.AreEqual(priorityQueue.Count, 1);
            Assert.IsTrue(priorityQueue.Remove("6", out priority));
            Assert.AreEqual(priority, 0);
            Assert.AreEqual(priorityQueue.Count, 0);

            Assert.IsFalse(priorityQueue.Remove("7", out priority));
        }

    }
}