/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

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
    public class CocktailSorterExamples
    {
        #region Sort
        [Test]
        public void SortExample()
        {
            var sorter = new CocktailSorter<int>();

            var list = new List<int> {13, 5, 77, 9, 12};

            sorter.Sort(list, Comparer<int>.Default);

            Assert.AreEqual(5, list[0]);
            Assert.AreEqual(9, list[1]);
            Assert.AreEqual(12, list[2]);
            Assert.AreEqual(13, list[3]);
            Assert.AreEqual(77, list[4]);
        }
        #endregion
    }
}
