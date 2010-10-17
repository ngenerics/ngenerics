using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class IsFull : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = new BinaryTree<int>(4);
            Assert.IsFalse(binaryTree.IsFull);

            binaryTree.Left = new BinaryTree<int>(3);
            Assert.IsFalse(binaryTree.IsFull);

            binaryTree.Right = new BinaryTree<int>(4);
            Assert.IsTrue(binaryTree.IsFull);

            binaryTree.RemoveLeft();
            Assert.IsFalse(binaryTree.IsFull);
        }

    }
}