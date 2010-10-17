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