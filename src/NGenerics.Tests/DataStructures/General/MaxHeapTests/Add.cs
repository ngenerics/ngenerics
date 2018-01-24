/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MaxHeapTests
{
    [TestFixture]
    public class Add : MaxHeapTest
    {
        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Maximum) { 5 };

            Assert.AreEqual(1, heap.Count);
            Assert.IsFalse(heap.IsEmpty());
            Assert.AreEqual(5, heap.Root);

            heap.Add(2);
            Assert.AreEqual(2, heap.Count);
            Assert.IsFalse(heap.IsEmpty());
            Assert.AreEqual(5, heap.Root);

            heap.Add(3);
            Assert.AreEqual(3, heap.Count);
            Assert.IsFalse(heap.IsEmpty());
            Assert.AreEqual(5, heap.Root);

            Assert.AreEqual(5, heap.RemoveRoot());

            heap.Add(1);
            Assert.AreEqual(3, heap.Count);
            Assert.IsFalse(heap.IsEmpty());
            Assert.AreEqual(3, heap.Root);
        }
    }
}