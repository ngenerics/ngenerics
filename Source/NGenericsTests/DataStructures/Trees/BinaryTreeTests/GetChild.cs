using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class GetChild : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            ITree<int> binaryTree = new BinaryTree<int>(5);

            var child1 = new BinaryTree<int>(4);
            var child2 = new BinaryTree<int>(6);

            binaryTree.Add(child1);
            binaryTree.Add(child2);
            Assert.AreEqual(binaryTree.Degree, 2);
            Assert.AreEqual(binaryTree.GetChild(0), child1);
            Assert.AreEqual(binaryTree.GetChild(1), child2);
        }

    }
}