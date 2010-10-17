using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Clear : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = new BinaryTree<int>(5);
            binaryTree.Clear();

            Assert.AreEqual(binaryTree.Count, 0);
            Assert.IsTrue(binaryTree.IsEmpty);

            binaryTree = GetTestTree();
            binaryTree.Clear();

            Assert.AreEqual(binaryTree.Count, 0);
            Assert.IsTrue(binaryTree.IsEmpty);
        }

    }
}