/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Trees;
using NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
    [TestFixture]
    public class BinarySearchTreeTestsCollection : BinarySearchTreeTest
    {
        [Test]
        public void Clear_Removes_Items_From_Tree()
        {
            var tree = new BinarySearchTree<int, string>();
            tree.Clear();

            Assert.AreEqual(0, tree.Count);

            tree = GetTestTree();
            Assert.IsTrue(tree.ContainsKey(19));

            tree.Clear();
            Assert.AreEqual(0, tree.Count);
            Assert.IsFalse(tree.ContainsKey(19));
        }
    }
}
