using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Clear : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();
            tree.Clear();

            Assert.AreEqual(tree.Count, 0);

            tree = GetTestTree();
            Assert.IsTrue(tree.ContainsKey(19));

            tree.Clear();
            Assert.AreEqual(tree.Count, 0);
            Assert.IsFalse(tree.ContainsKey(19));
        }

    }
}