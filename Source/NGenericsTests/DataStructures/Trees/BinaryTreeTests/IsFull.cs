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
    public class IsFull : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = new BinaryTree<int>(4);
            Assert.IsFalse(binaryTree.IsFull);

            binaryTree.Left = new BinaryTree<int>(3);
            Assert.IsFalse(binaryTree.IsFull);

            binaryTree.Right = new BinaryTree<int>(4);
            Assert.IsTrue(binaryTree.IsFull);

            binaryTree.RemoveLeft();
            Assert.IsFalse(binaryTree.IsFull);
        }

    }
}