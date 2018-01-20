/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Contains : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            Assert.IsTrue(binaryTree.Contains(9));
            Assert.IsTrue(binaryTree.Contains(12));
            Assert.IsTrue(binaryTree.Contains(13));
            Assert.IsFalse(binaryTree.Contains(15));
        }

    }
}