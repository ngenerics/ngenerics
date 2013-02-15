/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.MaxPriorityQueueHeapTests
{
    [TestFixture]
    public class GetEnumerator : MaxPriorityQueueTest
    {

        [Test]
        public void Simple()
        {
            var count = 0;
            var a = false;
            var b = false;
            var c = false;
            var d = false;
            var e = false;
            var f = false;

            var priorityQueue = GetSimpleTestPriorityQueue();
            var enumerator = priorityQueue.GetEnumerator();

            while (enumerator.MoveNext())
            {
                count++;

                if (enumerator.Current == "a")
                {
                    a = true;
                }
                else if (enumerator.Current == "b")
                {
                    b = true;
                }
                else if (enumerator.Current == "c")
                {
                    c = true;
                }
                else if (enumerator.Current == "d")
                {
                    d = true;
                }
                else if (enumerator.Current == "e")
                {
                    e = true;
                }
                else if (enumerator.Current == "f")
                {
                    f = true;
                }
            }

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsTrue(c);
            Assert.IsTrue(d);
            Assert.IsTrue(e);
            Assert.IsTrue(f);
            Assert.AreEqual(count, 6);
        }

        [Test]
        public void Interface()
        {
            var count = 0;
            var a = false;
            var b = false;
            var c = false;
            var d = false;
            var e = false;
            var f = false;

            var priorityQueue = GetSimpleTestPriorityQueue();
            var enumerator = ((IEnumerable)priorityQueue).GetEnumerator();

            while (enumerator.MoveNext())
            {
                count++;

                if ((string)enumerator.Current == "a")
                {
                    a = true;
                }
                else if ((string)enumerator.Current == "b")
                {
                    b = true;
                }
                else if ((string)enumerator.Current == "c")
                {
                    c = true;
                }
                else if ((string)enumerator.Current == "d")
                {
                    d = true;
                }
                else if ((string)enumerator.Current == "e")
                {
                    e = true;
                }
                else if ((string)enumerator.Current == "f")
                {
                    f = true;
                }
            }

            Assert.IsTrue(a);
            Assert.IsTrue(b);
            Assert.IsTrue(c);
            Assert.IsTrue(d);
            Assert.IsTrue(e);
            Assert.IsTrue(f);
            Assert.AreEqual(count, 6);
        }

    }
}