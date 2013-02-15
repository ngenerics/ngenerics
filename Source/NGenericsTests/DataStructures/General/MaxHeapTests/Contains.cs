/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class Contains : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = GetTestHeap();

            Assert.IsTrue(heap.Contains(5));
            Assert.IsTrue(heap.Contains(4));
            Assert.IsTrue(heap.Contains(99));
            Assert.IsTrue(heap.Contains(12));
            Assert.IsTrue(heap.Contains(5));
            Assert.IsFalse(heap.Contains(3));
        }
    }
}