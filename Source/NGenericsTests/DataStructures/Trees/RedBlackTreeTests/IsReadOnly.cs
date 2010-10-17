using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class IsReadOnly : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = new RedBlackTree<int, string>();
            Assert.IsFalse(redBlackTree.IsReadOnly);
        }

    }
}