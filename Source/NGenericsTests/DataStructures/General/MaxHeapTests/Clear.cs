/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class Clear : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Maximum);

            for (var i = 1; i <= 20; i++)
            {
                heap.Add(i);
                Assert.AreEqual(heap.Root, i);
            }

            Assert.IsFalse(heap.IsEmpty);
            Assert.AreEqual(heap.Count, 20);

            heap.Clear();

            Assert.AreEqual(heap.Count, 0);
            Assert.IsTrue(heap.IsEmpty);
        }
    }
}