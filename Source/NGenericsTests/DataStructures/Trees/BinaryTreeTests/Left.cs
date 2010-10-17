using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Left : BinaryTreeTest
    {
        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            binaryTree.Left = new BinaryTree<int>(99);
            Assert.AreEqual(binaryTree.Left.Data, 99);
            Assert.IsNotNull(binaryTree.Right);
            Assert.AreNotEqual(binaryTree.Right.Data, 99);
        }
    }
}