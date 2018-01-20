/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Right : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            binaryTree.Right = new BinaryTree<int>(99);

            Assert.IsNotNull(binaryTree.Left);
            Assert.AreNotEqual(binaryTree.Left.Data, 99);
            Assert.AreEqual(binaryTree.Right.Data, 99);
        }

    }
}