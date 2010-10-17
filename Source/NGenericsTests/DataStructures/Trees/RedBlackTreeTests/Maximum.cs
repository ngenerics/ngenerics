using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Maximum : RedBlackTreeTest
    {
        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);
            Assert.AreEqual(redBlackTree.Maximum.Key, 19);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInvalidMax()
        {
            var redBlackTree = new RedBlackTree<int, string>();
            var i = redBlackTree.Maximum.Key;
        }
    }
}