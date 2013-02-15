/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Queues;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Serialization : DequeTest
    {

        [Test]
        public void Simple()
        {
            var deque = new Deque<int>();

            for (var i = 0; i < 100; i++)
            {
                deque.EnqueueHead(i);
            }

            for (var i = 200; i >= 100; i--)
            {
                deque.EnqueueHead(i);
            }

            var newDeque = SerializeUtil.BinarySerializeDeserialize(deque);

            // Test if we indeed have two different instances of deques
            Assert.IsFalse(newDeque == deque);

            TestIfSame(deque, newDeque);
        }

    }
}