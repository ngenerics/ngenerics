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
    public class GetChild : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            ITree<int> binaryTree = new BinaryTree<int>(5);

            var child1 = new BinaryTree<int>(4);
            var child2 = new BinaryTree<int>(6);

            binaryTree.Add(child1);
            binaryTree.Add(child2);
            Assert.AreEqual(binaryTree.Degree, 2);
            Assert.AreEqual(binaryTree.GetChild(0), child1);
            Assert.AreEqual(binaryTree.GetChild(1), child2);
        }

    }
}