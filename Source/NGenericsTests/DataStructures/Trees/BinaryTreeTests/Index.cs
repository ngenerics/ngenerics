using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Index : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();

            Assert.AreEqual(binaryTree[0].Data, 2);
            Assert.AreEqual(binaryTree[1].Data, 3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionBadIndexer()
        {
            var binaryTree = GetTestTree();

            var i = binaryTree[2].Data;
        }

    }
}