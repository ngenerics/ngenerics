using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class IsLeafNode : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            Assert.IsFalse(binaryTree.IsLeafNode);
            Assert.IsTrue(binaryTree.GetChild(0).GetChild(0).IsLeafNode);

            binaryTree.Clear();
            Assert.IsTrue(binaryTree.IsLeafNode);
        }

    }
}