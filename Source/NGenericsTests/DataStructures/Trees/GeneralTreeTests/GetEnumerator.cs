/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class GetEnumerator : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();
            var enumerator = generalTree.GetEnumerator();

            var itemCount = 7;

            while (enumerator.MoveNext())
            {
                itemCount--;
            }

            Assert.AreEqual(itemCount, 0);
        }

        [Test]
        public void Interface()
        {
            var generalTree = GetTestTree();
            var enumerator = ((IEnumerable)generalTree).GetEnumerator();

            var itemCount = 7;

            while (enumerator.MoveNext())
            {
                itemCount--;
            }

            Assert.AreEqual(itemCount, 0);
        }

    }
}