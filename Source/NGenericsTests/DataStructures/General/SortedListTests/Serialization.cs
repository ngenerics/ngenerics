/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Serialization
    {

        [Test]
        public void Simple()
        {
            var sortedList = SortedListTest.GetTestList();
            var newSortedList = SerializeUtil.BinarySerializeDeserialize(sortedList);

            Assert.AreNotSame(sortedList, newSortedList);
            Assert.AreEqual(sortedList.Count, newSortedList.Count);

            for (var i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(sortedList[i], newSortedList[i]);
            }
        }

        [Test]
        public void NonIComparable()
        {
            var sortedList = new SortedList<NonComparableTClass>();

            for (var i = 50; i >= 0; i--)
            {
                sortedList.Add(new NonComparableTClass(i * 2));
            }

            var newSortedList = SerializeUtil.BinarySerializeDeserialize(sortedList);

            Assert.AreNotSame(sortedList, newSortedList);
            Assert.AreEqual(sortedList.Count, newSortedList.Count);

            for (var i = 0; i < sortedList.Count; i++)
            {
                Assert.AreEqual(sortedList[i].Number, newSortedList[i].Number);
            }
        }

    }
}