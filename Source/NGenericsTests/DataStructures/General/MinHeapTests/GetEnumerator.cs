/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class GetEnumerator : MinHeapTest
    {
        [Test]
        public void Interface()
        {
            var heap = new Heap<int>(HeapType.Maximum);

            const int maximum = 100;

            for (var i = 0; i < maximum; i++)
            {
                heap.Add(i);
            }

            var isPresent = new bool[maximum];

            for (var i = 0; i < isPresent.Length; i++)
            {
                isPresent[i] = false;
            }

            var enumerator = ((IEnumerable) heap).GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());

            do
            {
                isPresent[(int) enumerator.Current] = true;
            }
            while (enumerator.MoveNext());

            for (var i = 0; i < maximum; i++)
            {
                Assert.IsTrue(isPresent[i]);
            }
        }

        [Test]
        public void Simple()
        {
            var heap = new Heap<int>(HeapType.Minimum);

            const int maximum = 100;

            for (var i = 0; i < maximum; i++)
            {
                heap.Add(i);
            }

            var isPresent = new bool[maximum];

            for (var i = 0; i < isPresent.Length; i++)
            {
                isPresent[i] = false;
            }

            var enumerator = heap.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());

            do
            {
                isPresent[enumerator.Current] = true;
            }
            while (enumerator.MoveNext());

            for (var i = 0; i < maximum; i++)
            {
                Assert.IsTrue(isPresent[i]);
            }
        }
    }
}