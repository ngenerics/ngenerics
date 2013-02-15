/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class GetEnumerator : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            var enumerator = binaryTree.GetEnumerator();

            var itemCount = 6;

            while (enumerator.MoveNext())
            {
                itemCount--;
            }

            Assert.AreEqual(itemCount, 0);
        }

        [Test]
        public void Interface()
        {
            IEnumerable binaryTree = GetTestTree();
            var enumerator = binaryTree.GetEnumerator();

            var itemCount = 6;

            while (enumerator.MoveNext())
            {
                itemCount--;
            }

            Assert.AreEqual(itemCount, 0);
        }

    }
}