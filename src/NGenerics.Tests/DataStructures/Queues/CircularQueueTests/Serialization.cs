/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Queues;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class Serialization
    {

        [Test]
        public void Simple()
        {
            var circularQueue = new CircularQueue<int>(10);

            for (var i = 0; i < 7; i++)
            {
                circularQueue.Enqueue(i);
            }

            var newQ = SerializeUtil.BinarySerializeDeserialize(circularQueue);

            Assert.AreNotSame(circularQueue, newQ);
            Assert.AreEqual(circularQueue.Count, newQ.Count);

            while (circularQueue.Count > 0)
            {
                Assert.AreEqual(circularQueue.Dequeue(), newQ.Dequeue());
            }
        }

    }
}