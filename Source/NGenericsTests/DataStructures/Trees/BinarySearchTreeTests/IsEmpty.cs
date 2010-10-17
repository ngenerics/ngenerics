using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class IsEmpty : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();
            Assert.IsTrue(tree.IsEmpty);

            tree = GetTestTree();
            Assert.IsFalse(tree.IsEmpty);

            tree.Clear();
            Assert.IsTrue(tree.IsEmpty);
        }

    }
}