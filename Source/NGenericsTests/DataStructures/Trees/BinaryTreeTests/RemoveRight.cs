using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class RemoveRight : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();

            binaryTree.RemoveRight();

            Assert.IsNull(binaryTree.Right);
            Assert.IsNotNull(binaryTree.Left);
        }

    }
}