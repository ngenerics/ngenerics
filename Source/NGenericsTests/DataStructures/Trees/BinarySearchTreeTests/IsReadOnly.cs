using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class IsReadOnly : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();
            Assert.IsFalse(tree.IsReadOnly);

            tree = GetTestTree();
            Assert.IsFalse(tree.IsReadOnly);
        }

    }
}