using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Minimum : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);
            Assert.AreEqual(redBlackTree.Minimum.Key, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInvalidMin()
        {
            var redBlackTree = new RedBlackTree<int, string>();
            var i = redBlackTree.Minimum.Key;
        }

    }
}