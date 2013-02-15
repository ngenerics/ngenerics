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
    public class Contains : DequeTest
    {

        [Test]
        public void Simple()
        {
            var test = new Deque<int>();
            Assert.IsFalse(test.Contains(5));

            test.EnqueueHead(5);
            test.EnqueueHead(6);

            Assert.IsTrue(test.Contains(5));
            Assert.IsTrue(test.Contains(6));
        }

    }
}