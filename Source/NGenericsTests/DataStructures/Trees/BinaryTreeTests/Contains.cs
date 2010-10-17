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