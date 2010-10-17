using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Clear : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree();
            redBlackTree.Clear();

            Assert.AreEqual(redBlackTree.Count, 0);
            Assert.IsFalse(redBlackTree.ContainsKey(40));
            Assert.IsFalse(redBlackTree.ContainsKey(41));
        }

    }
}