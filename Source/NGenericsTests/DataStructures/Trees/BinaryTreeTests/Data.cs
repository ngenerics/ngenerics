using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Data : BinaryTreeTest
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNull()
        {
            var binaryTree = new BinaryTree<string>("asdasd");
            Assert.AreEqual(binaryTree.Data, "asdasd");

            binaryTree.Data = null;
        }

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            binaryTree.Data = 2;

            Assert.AreEqual(binaryTree.Data, 2);
        }

    }
}