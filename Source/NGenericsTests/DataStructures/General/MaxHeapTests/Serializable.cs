/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class 
        Serializable : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = GetTestHeap();
            var newHeap = SerializeUtil.BinarySerializeDeserialize(heap);

            Assert.AreNotSame(heap, newHeap);
            Assert.AreEqual(heap.Count, newHeap.Count);

            while (heap.Count > 0)
            {
                Assert.AreEqual(heap.RemoveRoot(), newHeap.RemoveRoot());
            }
        }

        [Test]
        public void NonIComparable()
        {
            var heap = new Heap<NonComparableTClass>(HeapType.Maximum)
                           {
                               new NonComparableTClass(5),
                               new NonComparableTClass(4),
                               new NonComparableTClass(99),
                               new NonComparableTClass(12),
                               new NonComparableTClass(5)
                           };

            var newHeap = SerializeUtil.BinarySerializeDeserialize(heap);

            Assert.AreNotSame(heap, newHeap);
            Assert.AreEqual(heap.Count, newHeap.Count);

            while (heap.Count > 0)
            {
                Assert.AreEqual(heap.RemoveRoot().Number, newHeap.RemoveRoot().Number);
            }
        }
    }
}