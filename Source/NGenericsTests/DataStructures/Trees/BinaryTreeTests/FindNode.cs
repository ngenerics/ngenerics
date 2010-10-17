/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class FindNode : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = new BinaryTree<int>(5);

            var child1 = new BinaryTree<int>(2);
            var child2 = new BinaryTree<int>(3);

            binaryTree.Add(child1);
            binaryTree.Add(child2);

            var child4 = new BinaryTree<int>(9);
            var child5 = new BinaryTree<int>(12);
            var child6 = new BinaryTree<int>(13);

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            Assert.AreEqual(binaryTree.FindNode(target => target == 2), child1);

            Assert.AreEqual(binaryTree.FindNode(target => target == 9), child4);

            Assert.AreEqual(binaryTree.FindNode(target => target == 13), child6);

            Assert.AreEqual(binaryTree.FindNode(target => target == 57), null);
        }

        [Test]
        public void Interface()
        {
            var rootBinaryTree = new BinaryTree<int>(5);

            var child1 = new BinaryTree<int>(2);
            var child2 = new BinaryTree<int>(3);

            rootBinaryTree.Add(child1);
            rootBinaryTree.Add(child2);

            var child4 = new BinaryTree<int>(9);
            var child5 = new BinaryTree<int>(12);
            var child6 = new BinaryTree<int>(13);

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            ITree<int> tree = rootBinaryTree;
            Assert.AreEqual(tree.FindNode(target => target == 2), child1);

            Assert.AreEqual(tree.FindNode(target => target == 9), child4);

            Assert.AreEqual(tree.FindNode(target => target == 13), child6
                );

            Assert.AreEqual(tree.FindNode(target => target == 57), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcetpionInterfaceNullCondition()
        {
            var binaryTree = GetTestTree();
            ((ITree<int>)binaryTree).FindNode(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcepionNullCondition()
        {
            var binaryTree = GetTestTree();
            binaryTree.FindNode(null);
        }

    }
}