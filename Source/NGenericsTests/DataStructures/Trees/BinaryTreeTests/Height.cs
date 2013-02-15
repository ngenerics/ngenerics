/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Height : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = new BinaryTree<int>(5);

            Assert.AreEqual(binaryTree.Height, 0);

            binaryTree.Add(3);

            var s1 = binaryTree.Left;


            Assert.AreEqual(binaryTree.Height, 1);

            s1.Add(6);

            Assert.AreEqual(binaryTree.Height, 2);
            binaryTree.Add(4);

            Assert.AreEqual(binaryTree.Height, 2);

            binaryTree = GetTestTree();

            Assert.AreEqual(binaryTree.Height, 2);
        }

    }
}