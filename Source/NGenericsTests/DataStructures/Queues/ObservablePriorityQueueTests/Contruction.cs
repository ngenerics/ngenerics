/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Queues;
using NGenerics.DataStructures.Queues.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.ObservablePriorityQueueTests
{
    [TestFixture]
    public class Contruction
    {


        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservablePriorityQueue<int, int>(PriorityQueueType.Minimum));
            ObservableCollectionTester.CheckMonitor(deserialize);
        }
        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservablePriorityQueue<int, int>(PriorityQueueType.Minimum));
        }
    }
}