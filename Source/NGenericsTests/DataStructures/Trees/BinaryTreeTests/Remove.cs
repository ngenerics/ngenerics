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
    public class Remove : BinaryTreeTest
    {

        [Test]
        public void Interface()
        {
            ITree<int> binaryTree = new BinaryTree<int>(5);

            var child1 = new BinaryTree<int>(4);
            var child2 = new BinaryTree<int>(6);
            var child3 = new BinaryTree<int>(7);

            binaryTree.Add(child1);
            binaryTree.Add(child2);
            Assert.AreEqual(binaryTree.Degree, 2);
            Assert.IsTrue(binaryTree.Remove(child1));
            Assert.AreEqual(binaryTree.Degree, 1);
            Assert.IsFalse(binaryTree.Remove(child3));
            Assert.AreEqual(binaryTree.Degree, 1);
            Assert.IsTrue(binaryTree.Remove(child2));
            Assert.AreEqual(binaryTree.Degree, 0);
        }

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();

            Assert.IsTrue(binaryTree.Remove(2));
            Assert.IsFalse(binaryTree.Remove(5));
            Assert.IsTrue(binaryTree.Remove(3));

            Assert.IsNull(binaryTree.Left);
            Assert.IsNull(binaryTree.Right);
        }

    }
}