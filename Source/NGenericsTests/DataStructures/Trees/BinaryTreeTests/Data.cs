/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

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
    public class Data : BinaryTreeTest
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNull()
        {
            var binaryTree = new BinaryTree<string>("asdasd");
            Assert.AreEqual(binaryTree.Data, "asdasd");

            binaryTree.Data = null;
        }

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            binaryTree.Data = 2;

            Assert.AreEqual(binaryTree.Data, 2);
        }

    }
}