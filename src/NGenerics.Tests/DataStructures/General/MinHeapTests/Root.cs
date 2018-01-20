/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Root : MinHeapTest
    {
        [Test]
        public void SmallestItem()
        {
            var heap = new Heap<int>(HeapType.Minimum) {5};
            Assert.AreEqual(heap.Root, 5);
            Assert.AreEqual(heap.Count, 1);
        }

        [Test]
        public void ExceptionEmpty()
        {
            var heap = new Heap<int>(HeapType.Minimum);
            int i;
            Assert.Throws<InvalidOperationException>(() => i = heap.Root);
        }
    }
}