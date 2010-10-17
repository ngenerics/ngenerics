using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Minimum : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var i = tree.Minimum;

            Assert.AreEqual(i.Key, 1);
            Assert.AreEqual(i.Value, "1");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInvalidMin()
        {
            var tree = new BinarySearchTree<int, string>();
            var i = tree.Minimum;
        }

    }
}