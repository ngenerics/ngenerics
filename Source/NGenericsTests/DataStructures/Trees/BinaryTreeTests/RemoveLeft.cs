using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class RemoveLeft : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();

            binaryTree.RemoveLeft();

            Assert.IsNull(binaryTree.Left);
            Assert.IsNotNull(binaryTree.Right);
        }

    }
}