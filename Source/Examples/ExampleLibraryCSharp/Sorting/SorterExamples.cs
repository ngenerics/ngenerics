/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using NGenerics.Sorting;
using NUnit.Framework;

namespace ExampleLibraryCSharp.Sorting
{
    [TestFixture]
    public class SorterExamples
    {
        #region SortListComparer
        [Test]
        public void SortListComparerExample()
        {
            ComparisonSorter<int> sorter = new QuickSorter<int>();

            var list = new List<int> {13, 5, 77, 9, 12};

            sorter.Sort(list, Comparer<int>.Default);

            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(9, list[1]);
            Assert.AreEqual(12, list[2]);
            Assert.AreEqual(13, list[3]);
            Assert.AreEqual(77, list[4]);
        }
        #endregion

        #region SortListDelegate
        [Test]
        public void SortListDelegateExample()
        {
            ComparisonSorter<int> sorter = new QuickSorter<int>();

            var list = new List<int> {13, 5, 77, 9, 12};

            sorter.Sort(list, IntComparison);

            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(9, list[1]);
            Assert.AreEqual(12, list[2]);
            Assert.AreEqual(13, list[3]);
            Assert.AreEqual(77, list[4]);
        }


        private static int IntComparison(int i, int j)
        {
            if (i < j)
            {
                return -1;
            }
            if (i > j)
            {
                return 1;
            }
            return 0;
        }
        #endregion
        
        #region SortList
        [Test]
        public void SortListExample()
        {
            ComparisonSorter<int> sorter = new QuickSorter<int>();

            var list = new List<int> {13, 5, 77, 9, 12};

            sorter.Sort(list);

            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(9, list[1]);
            Assert.AreEqual(12, list[2]);
            Assert.AreEqual(13, list[3]);
            Assert.AreEqual(77, list[4]);
        }
        #endregion

        #region SortListOrder
        [Test]
        public void SortListOrderExample()
        {
            ComparisonSorter<int> sorter = new QuickSorter<int>();

            var list = new List<int> {13, 5, 77, 9, 12};

            sorter.Sort(list, SortOrder.Ascending);

            Assert.AreEqual(77, list[4]);
            Assert.AreEqual(13, list[3]);
            Assert.AreEqual(12, list[2]);
            Assert.AreEqual(9, list[1]);
            Assert.AreEqual(5, list[0]);
        }
        #endregion
    }
}
