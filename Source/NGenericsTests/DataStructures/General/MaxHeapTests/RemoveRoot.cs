/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class RemoveRoot : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Maximum) { 5 };
            Assert.AreEqual(heap.Root, 5);
            Assert.AreEqual(heap.Count, 1);
            Assert.IsFalse(heap.IsEmpty);

            Assert.AreEqual(heap.RemoveRoot(), 5);
            Assert.AreEqual(heap.Count, 0);
            Assert.IsTrue(heap.IsEmpty);
        }

        [Test]
        public void Stress()
        {
            var heap = new Heap<int>(HeapType.Maximum);

            const int maximum = 5000;

            for (var i = 1; i <= maximum; i++)
            {
                heap.Add(i);

                Assert.AreEqual(heap.Root, i);
            }

            for (var i = maximum; i > 0; i--)
            {
                Assert.AreEqual(heap.RemoveRoot(), i);
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var heap = new Heap<int>(HeapType.Maximum);

            Assert.AreEqual(heap.Count, 0);

            heap.RemoveRoot();
        }
    }
}