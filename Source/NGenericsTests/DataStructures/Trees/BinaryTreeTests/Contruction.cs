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
    public class Contruction : BinaryTreeTest
    {
        [Test]
        public void Simple()
        {
            var binaryTree = new BinaryTree<int>(5);

            Assert.AreEqual(binaryTree.Count, 0);
            Assert.AreEqual(binaryTree.Degree, 0);
            Assert.AreEqual(binaryTree.Data, 5);

            binaryTree = new BinaryTree<int>(5, new BinaryTree<int>(3), new BinaryTree<int>(4));

            Assert.AreEqual(binaryTree.Count, 2);
            Assert.AreEqual(binaryTree.Degree, 2);
            Assert.AreEqual(binaryTree.Data, 5);

            Assert.AreEqual(binaryTree.Left.Data, 3);
            Assert.AreEqual(binaryTree.Right.Data, 4);

            binaryTree = new BinaryTree<int>(5, 3, 4);

            Assert.AreEqual(binaryTree.Count, 2);
            Assert.AreEqual(binaryTree.Degree, 2);
            Assert.AreEqual(binaryTree.Data, 5);

            Assert.AreEqual(binaryTree.Left.Data, 3);
            Assert.AreEqual(binaryTree.Right.Data, 4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullData()
        {
            new BinaryTree<string>(null);
        }

    }
}