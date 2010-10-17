using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Count : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree();
            Assert.IsFalse(redBlackTree.IsEmpty);

            redBlackTree.Clear();
            Assert.IsTrue(redBlackTree.IsEmpty);

            redBlackTree = new RedBlackTree<int, string>();
            Assert.IsTrue(redBlackTree.IsEmpty);
        }

    }
}